using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NotenSpiegler
{
    [Serializable]
    class ObjectToSerialize : ISerializable
    {
        public List<Marks> Marks { get; set; }
        public ObjectToSerialize(List<Marks> marks)
        {
            Marks = new List<Marks>(marks);
        }

        public ObjectToSerialize(SerializationInfo info, StreamingContext context)
        {
            Marks = (List<Marks>)info.GetValue("Marks", typeof(List<Marks>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Marks", Marks);
        }

        public override string ToString()
        {
            return $"{Marks.ToString()} ";
        }
    }
}
