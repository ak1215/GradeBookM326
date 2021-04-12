using System;
using System.Collections.Generic;
using System.Text;

namespace NotenSpiegler
{
    class Calculator
    {
        public void ShowOverview(ObjectToSerialize serializedObj)
        {
            foreach (Marks marks in serializedObj.Marks)
            {
                Console.WriteLine(marks.ToString());
            }
            Console.WriteLine($"Avrg Of all Marks: {CalculateAvrgOfAll(serializedObj)}");
        }

        public double CalculateAvrgOfAll(ObjectToSerialize serializedObj)
        {
            double avrgOfMarks = 0;
            double[] listElements = CalculateWeighting(serializedObj);
            foreach(var listElement in listElements)
            {
                avrgOfMarks += listElement;
            }
           return avrgOfMarks = avrgOfMarks / listElements.Length;
        } 
        public double[] CalculateWeighting(ObjectToSerialize serializedObj)
        {
            double[] weightingSumList = new double[serializedObj.Marks.Count];

            for (int i = 0; i < serializedObj.Marks.Count; i++)
            {
                double weightingSum = serializedObj.Marks[i].Mark * serializedObj.Marks[i].Weighting;
                weightingSumList[i] = weightingSum;
            }
            return weightingSumList;
        }
    }
}
