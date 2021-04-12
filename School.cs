using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NotenSpiegler
{
    [Serializable()]
    class School : ISerializable
    {
        public string SchoolName { get; set; }

        public School(string name)
        {
            SchoolName = name;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SchoolName", SchoolName);
        }

        public School(SerializationInfo info, StreamingContext context)
        {
            SchoolName = (string)info.GetValue(nameof(SchoolName), typeof(string));
        }
    }
}
