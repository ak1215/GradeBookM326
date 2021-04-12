using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NotenSpiegler
{
    [Serializable()]
    class Subject : ISerializable
    {
        public string SubjectName { get; set; }
        public School NameOfSchool { get; set; }

        public Subject(string subjectName, School school)
        {
            SubjectName = subjectName;
            NameOfSchool = school;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SubjectName", SubjectName);
            NameOfSchool.GetObjectData(info, context);
        }

        public Subject(SerializationInfo info, StreamingContext context)
        {
            SubjectName = (string)info.GetValue("SubjectName", typeof(string));
            NameOfSchool = new School(info, context);
        }
    }
}
