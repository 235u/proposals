using Box.V2;
using Box.V2.Exceptions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ActinUranium.BoxFolderCreator
{
    public sealed class BoxFolderBuilder
    {
        private const string RootFolderId = "0";
        private const string ProjectsFolderName = "Projects";       
        private const string AccountingFolderName = "Accounting";
        private const string ArchitectureFolderName = "Architecture";
        private const string PermitsFolderName = "Permits";
        private const string PlanningFolderName = "Planning";
        private const string ProposalsFolderName = "Proposals";
        private const string AllUsersGroupName = "All Users";       
        private const string AccountantsGroupName = "Accountants";        
        private const string ArchitectsGroupName = "Architects";

        private readonly BoxClient _client;

        private string _projectsFolderId = string.Empty;
        private string _allUsersGroupId = string.Empty;
        private string _accountantsGroupId = string.Empty;
        private string _architectsGroupId = string.Empty;

        private BoxFolderBuilder(BoxClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Ensures the existence of all the required entities and caches their ids for later use.
        /// </summary>
        /// <returns>A task representing this operation.</returns>
        /// <remarks>Takes 1-2 seconds to run.</remarks>
        public static async Task<BoxFolderBuilder> CreateAsync(BoxClient client)
        {
            var builder = new BoxFolderBuilder(client);
            await builder.InitializeAsync();
            return builder;
        }

        /// <summary>
        /// Builds the required folder structure and assigns the permissions.
        /// </summary>
        /// <param name="folderName">The name of the project's folder.</param>
        /// <returns>A task representing this operation.</returns>
        /// <remarks>
        /// <para>
        /// Note, that the subfolders inherit the permissions from the parent folder: assigning all users the editor
        /// role on the project folder impacts all its subfolders, being irrevocable at the subfolder level (deleting
        /// the collaboration entity for any subfolder leads to its deletion for the parent folder).
        /// </para>
        /// <para>
        /// Note, that the .NET Core SDK (NuGet package) is async by design, as any Web API is by its nature.
        /// </para>
        /// <para>Takes ~10 seconds to run.</para>
        /// <seealso href="https://developer.box.com/docs/install-the-sdk" />
        /// </remarks>
        public async Task BuildAsync(string folderName)
        {
            string newProjectFolderId = await _client.CreateFolderAsync(folderName, _projectsFolderId);
            
            string currentFolderId = await _client.CreateFolderAsync(AccountingFolderName, newProjectFolderId);
            await _client.CreateCollaborationAsync(currentFolderId, _accountantsGroupId);

            currentFolderId = await _client.CreateFolderAsync(ArchitectureFolderName, newProjectFolderId);
            await _client.CreateCollaborationAsync(currentFolderId, _architectsGroupId);

            currentFolderId = await _client.CreateFolderAsync(PermitsFolderName, newProjectFolderId);
            await _client.CreateCollaborationAsync(currentFolderId, _allUsersGroupId);

            currentFolderId = await _client.CreateFolderAsync(PlanningFolderName, newProjectFolderId);
            await _client.CreateCollaborationAsync(currentFolderId, _allUsersGroupId);

            currentFolderId = await _client.CreateFolderAsync(ProposalsFolderName, newProjectFolderId);
            await _client.CreateCollaborationAsync(currentFolderId, _allUsersGroupId);
        }

        public async Task<bool> TryBuildAsync(string folderName)
        {
            var success = true;
            try
            {
                await BuildAsync(folderName);
            }
            catch (BoxException ex)
            {
                Debug.WriteLine(ex.ToString());
                success = false;
            }

            return success;
        }

        private async Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(_projectsFolderId))
            {
                _projectsFolderId = await _client.CreateFolderAsync(ProjectsFolderName, RootFolderId);
            }

            if (string.IsNullOrEmpty(_allUsersGroupId))
            {
                _allUsersGroupId = await _client.CreateGroupAsync(AllUsersGroupName);
            }

            if (string.IsNullOrEmpty(_accountantsGroupId))
            {
                _accountantsGroupId = await _client.CreateGroupAsync(AccountantsGroupName);
            }

            if (string.IsNullOrEmpty(_architectsGroupId))
            {
                _architectsGroupId = await _client.CreateGroupAsync(ArchitectsGroupName);
            }
        }
    }
}
