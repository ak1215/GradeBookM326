using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NotenSpiegler
{
    [Serializable()]
    class Marks : ISerializable
    {
        public double Mark { get; set; }
        public string Name { get; set; }
        public double Weighting { get; set; }
        public Subject NameOfSubject { get; set; }

        public Marks(string nameOfMarks,double marks, double weighting, Subject nameOFSubject)
        {
            Mark = marks;
            Name = nameOfMarks;
            Weighting = weighting;
            NameOfSubject = nameOFSubject;
        }

        public override string ToString()
        {
            return $"School:{NameOfSubject.NameOfSchool.SchoolName} Subject:{NameOfSubject.SubjectName} Name:{Name} Mark:{Mark} Weight:{Weighting} \n";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Mark", Mark);
            info.AddValue("Name", Name);
            info.AddValue("Weighting", Weighting);
            NameOfSubject.GetObjectData(info, context);

        }

        public Marks(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Mark = (double)info.GetValue("Mark", typeof(double));
            Weighting = (double)info.GetValue("Weighting", typeof(double));
            NameOfSubject = new Subject(info, context);

        }
    }
}
