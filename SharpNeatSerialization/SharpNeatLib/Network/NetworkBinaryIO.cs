using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SharpNeat.Network
{
    public static class NetworkBinaryIO
    {
        private static readonly BinaryFormatter Formatter = new BinaryFormatter();

        public static List<NetworkDefinition> ReadCompleteNetworkDefinitionList(Stream stream)
        {
            return Formatter.Deserialize(stream) as List<NetworkDefinition>;
        }

        public static void WriteComplete(Stream stream, IList<NetworkDefinition> networkDefList)
        {
            Formatter.Serialize(stream, networkDefList);
        }
    }
}
