using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;
using ProtoBuf.Meta;
using Redzen.Numerics.Distributions;
using SharpNeat.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace SharpNeat.Tests.Network
{
    [TestClass]
    public class ProtobufNetTests
    {
        private static readonly string OriginalXmlDataFile = $@"Data\original.gnm.xml";

        private readonly RuntimeTypeModel _model = TypeModel.Create();

        [TestMethod]
        public void Test()
        {
            List<NetworkDefinition> networkDefinitionList = null;
            using (var reader = XmlReader.Create(OriginalXmlDataFile))
            {
                networkDefinitionList = NetworkXmlIO.ReadCompleteNetworkDefinitionList(reader, nodeFnIds: false);
            }

            MetaType metaType = _model.Add(typeof(NetworkDefinition), false);
            metaType.UseConstructor = false;
            metaType.Add(1, "_activationFnLib", );

            MetaType metaType = AddMetaType(typeof(IActivationFunctionLibrary));
            metaType.AddSubType()
            AddMetaType(typeof(ActivationFunctionInfo));
            AddMetaType(typeof(LeakyReLU));
            AddMetaType(typeof(DiscreteDistribution));

            using (var stream = new MemoryStream())
            {
                _model.Serialize(stream, networkDefinitionList);
            }            
        }
    }
}
