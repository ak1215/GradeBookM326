using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NotenSpiegler
{
    class Serializer
    {
        public Serializer()
        {

        }

        public void SerializeObject(string filename,ObjectToSerialize objectToSerialize)
        {
            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToSerialize);
            }
             
        }

        public ObjectToSerialize DeserializeObject(string filename)
        {
            ObjectToSerialize objectToSerialize;
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                objectToSerialize = (ObjectToSerialize)binaryFormatter.Deserialize(stream);
            }

            return objectToSerialize;
        }
    }
}
