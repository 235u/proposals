using Box.V2;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace ActinUranium.BoxFolderCreator
{
    [TestClass]
    public class BoxFolderBuilderTests
    {
        // Admin Console > Content > corresponding user > browser's address bar > first numeric value
        private const string ProjectsFolderOwnerId = "10201618305";

        // Dev Console > My Apps > Create New App > Custom App > Next > OAuth 2.0 with JWT (Server Authentication) >
        // Give your app a unique name... > Create App > Configuration > activate both Advanced Features >
        // Generate a Public/Private Keypair > (activate the 2-factor verification, if not yet activated; repeat) >
        // store the generated config in the test project's folder > update it's properties > 
        // Copy to Output Directory > Copy if newer
        // Admin Console > Authorize New App > enter the clientID from the config.json as the API-Key
        // run the following test (update project's folder name; repeat) > (watch out for exceptions) >
        // check the contents of the Projects folder in its owner account (manually / visually)
        // See also: https://developer.box.com/docs/authenticate-with-jwt
        private static BoxClient CreateClient()
        {
            string configJsonString = File.ReadAllText("config.json");
            IBoxConfig config = BoxConfig.CreateFromJsonString(configJsonString);
            var jwt = new BoxJWTAuth(config);
            string token = jwt.AdminToken();
            return jwt.AdminClient(token, asUser: ProjectsFolderOwnerId);
        }

        [TestMethod]
        public async Task BuildAsync()
        {
            // Arrange
            BoxClient client = CreateClient();
            BoxFolderBuilder folderBuilder = await BoxFolderBuilder.CreateAsync(client);

            // Act
            await folderBuilder.BuildAsync(folderName: "P3019126");
        }
    }
}
