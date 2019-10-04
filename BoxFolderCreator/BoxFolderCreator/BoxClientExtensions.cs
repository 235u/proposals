using Box.V2;
using Box.V2.Models;
using Box.V2.Models.Request;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ActinUranium.BoxFolderCreator
{
    public static class BoxClientExtensions
    {
        public static async Task<string> CreateFolderAsync(this BoxClient client, string name, string parentFolderId)
        {
            // NOTE: The search engine may be out of synch, while calling this method with the same parameters multiple
            // times, leading to BoxConflictExceptions. Use client.FoldersManager.GetItemsAsync(parentFolderId) instead?
            BoxCollection<BoxItem> result = await client.SearchManager.QueryAsync(
                query: name,
                type: BoxType.folder.ToString(),
                ancestorFolderIds: new string[] { parentFolderId });

            if (result.TotalCount == 0)
            {
                var request = new BoxFolderRequest
                {
                    Name = name,
                    Parent = new BoxRequestEntity
                    {
                        Id = parentFolderId,
                        Type = BoxType.folder
                    }
                };

                BoxFolder newFolder = await client.FoldersManager.CreateAsync(request);
                return newFolder.Id;
            }
            else
            {
                BoxItem existingFolder = result.Entries[0];
                return existingFolder.Id;
            }
        }

        public static async Task<string> CreateGroupAsync(this BoxClient client, string name)
        {
            BoxCollection<BoxGroup> allGroups = await client.GroupsManager.GetAllGroupsAsync();
            BoxGroup group = allGroups.Entries.SingleOrDefault(g => g.Name.Equals(name, StringComparison.Ordinal));
            if (group == null)
            {
                var request = new BoxGroupRequest
                {
                    Name = name
                };

                group = await client.GroupsManager.CreateAsync(request);
            }

            return group.Id;
        }

        public static async Task CreateCollaborationAsync(this BoxClient client, string folderId, string userGroupId)
        {
            BoxCollection<BoxCollaboration> existingCollaborations = 
                await client.FoldersManager.GetCollaborationsAsync(folderId);

            string userGroupType = BoxType.group.ToString();
            BoxCollaboration collaboration = existingCollaborations.Entries
                .FirstOrDefault(c => 
                    c.AccessibleBy.Id.Equals(userGroupId, StringComparison.Ordinal) &&
                    c.AccessibleBy.Type.Equals(userGroupType, StringComparison.Ordinal));

            string editorRole = BoxCollaborationRole.Editor.ToString();
            if (collaboration == null)
            {
                var request = new BoxCollaborationRequest
                {
                    Item = new BoxRequestEntity
                    {
                        Id = folderId,
                        Type = BoxType.folder
                    },
                    AccessibleBy = new BoxCollaborationUserRequest
                    {
                        Id = userGroupId,
                        Type = BoxType.group
                    },
                    Role = editorRole
                };

                await client.CollaborationsManager.AddCollaborationAsync(request);
            }
            else
            {
                if (!collaboration.Role.Equals(editorRole, StringComparison.Ordinal))
                {
                    // ignore
                }
            }
        }
    }
}
