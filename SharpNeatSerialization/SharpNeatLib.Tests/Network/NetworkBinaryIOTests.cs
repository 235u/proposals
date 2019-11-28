using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SharpNeat.Network.Tests
{
    [TestClass]
    public class NetworkBinaryIOTests
    {
        private const string FileNamePostfix = "gnm"; // "pop"
        
        private static readonly string OriginalXmlDataFile = $@"Data\original.{FileNamePostfix}.xml";
        private static readonly string InterimXmlDataFile = $@"Data\interim.{FileNamePostfix}.xml";
        private static readonly string ActualXmlDataFile = $@"Data\actual.{FileNamePostfix}.xml";
        private static readonly string ActualBinaryDataFile = $@"Data\actual.{FileNamePostfix}.bin";
        private static readonly XmlWriterSettings XmlWriterSettings = new XmlWriterSettings
        {
            Indent = true
        };

        [TestMethod]
        [Ignore("Explorative")]
        public void ReadWriteXml()
        {
            // Arrange
            List<NetworkDefinition> networkDefinitionList = null;
            using (var reader = XmlReader.Create(OriginalXmlDataFile))
            {
                networkDefinitionList = NetworkXmlIO.ReadCompleteNetworkDefinitionList(reader, nodeFnIds: false);
            }

            // Act
            using (var xmlWriter = XmlWriter.Create(InterimXmlDataFile, XmlWriterSettings))
            {
                NetworkXmlIO.WriteComplete(xmlWriter, networkDefinitionList, nodeFnIds: false);
            }
        }

        [TestMethod]
        public void ReadWriteBinary()
        {
            // Arrange
            ReadWriteXml();

            List<NetworkDefinition> networkDefinitionList = null;
            using (var reader = XmlReader.Create(InterimXmlDataFile))
            {
                networkDefinitionList = NetworkXmlIO.ReadCompleteNetworkDefinitionList(reader, nodeFnIds: false);
            }

            // Act
            using (var stream = File.Create(ActualBinaryDataFile))
            {
                NetworkBinaryIO.WriteComplete(stream, networkDefinitionList);
                stream.Seek(0, SeekOrigin.Begin);
                networkDefinitionList = NetworkBinaryIO.ReadCompleteNetworkDefinitionList(stream);
            }

            // Assert
            using (var xmlWriter = XmlWriter.Create(ActualXmlDataFile, XmlWriterSettings))
            {
                NetworkXmlIO.WriteComplete(xmlWriter, networkDefinitionList, nodeFnIds: false);
            }

            string expectedText = File.ReadAllText(InterimXmlDataFile);
            string actualText = File.ReadAllText(ActualXmlDataFile);
            Assert.AreEqual(expectedText, actualText);

            var xmlFileInfo = new FileInfo(ActualXmlDataFile);
            var binaryFileInfo = new FileInfo(ActualBinaryDataFile);
            Assert.IsTrue(xmlFileInfo.Length < binaryFileInfo.Length);
        }
    }
}
