using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace NotenSpiegler
{
    class UserInput
    {
        List<Marks> arrayMarks = new List<Marks>();
        List<Subject> arraySubject = new List<Subject>();
        List<School> arraySchool = new List<School>();
        ObjectToSerialize objectToSerialize;
        Serializer serializer = new Serializer();
        Calculator calculator = new Calculator();


        string path = @"C:\Users\anushya.nagulanandan\Documents\Ausbildung\2021\Project\NotenSpiegler\";
        string fileName;
        string fileFullName;

        string selectedSchool;
        string selectedSubject;
        string marks;
        string weighting;

        public void Menu()
        {
            FindFileName();
            ObjectToSerialize serializedObj = null;
            if (File.Exists(fileFullName))
            {
                serializedObj = serializer.DeserializeObject(fileFullName);
            }

            bool isExit;
            do
            {
                Console.WriteLine("What you wanna do?");
                Console.WriteLine("1. Show Overview\n" +
                    "2. Add Marks");
                string selectedOption = Console.ReadLine();
                int selctedOptionInt = int.Parse(selectedOption);

                SelectOptionPanel(serializedObj, selctedOptionInt);

                isExit = IsExit();
            } while (isExit);

        }

        private bool IsExit()
        {
            bool parseSuccessful;
            char continueStatement;
            do
            {
                Console.WriteLine("Do you want to continue?(t/f)");
                string userInput = Console.ReadLine();
                parseSuccessful = Char.TryParse(userInput, out continueStatement);
            } while (!parseSuccessful);
            if (continueStatement == 't')
            {
                return true;
            }
            else if (continueStatement == 'f')
            {
                return false;
            }
            return false;
        }
        private void SelectOptionPanel(ObjectToSerialize serializedObj, int selctedOptionInt)
        {
            if (selctedOptionInt == 1)
            {
                calculator.ShowOverview(serializedObj);
            }
            else if (selctedOptionInt == 2)
            {
                if (serializedObj != null)
                {
                    arrayMarks = new List<Marks>(serializedObj.Marks);
                    GetArrayOfSubject(serializedObj);
                    GetArrayOfSchool(serializedObj);
                }
                AddMarks();
            }
        }

        public void GetArrayOfSubject(ObjectToSerialize serializedObj)
        {
            foreach(Marks marks in serializedObj.Marks)
            {
                arraySubject.Add(new Subject(marks.NameOfSubject.SubjectName, marks.NameOfSubject.NameOfSchool));
            }
        }

        public void GetArrayOfSchool(ObjectToSerialize serializedObj)
        {
            foreach (Marks marks in serializedObj.Marks)
            {
                arraySchool.Add(new School(marks.NameOfSubject.NameOfSchool.SchoolName));
            }
        }
        public void AddMarks()
        {
            int selctedSchoolInt = SelectionOfSchool();

            int selctedSubjectInt = SelcetionOfSubject(selctedSchoolInt);

            Console.WriteLine("Type in the name of exam:");
            string nameOfExam = Console.ReadLine();

            Console.WriteLine("Type in your marks:");
            marks = Console.ReadLine();

            Console.WriteLine("Type in your weighting:");
            weighting = Console.ReadLine();

            arrayMarks.Add(new Marks(nameOfExam, Convert.ToDouble(marks), Convert.ToDouble(weighting), arraySubject[selctedSubjectInt - 1]));
            
            objectToSerialize = new ObjectToSerialize(arrayMarks);
            serializer.SerializeObject(fileFullName, objectToSerialize);

        }

        private int SelcetionOfSubject(int selctedSchoolInt)
        {
            Console.WriteLine("Choose your Subject:");
            int j = 1;
            foreach (var subject in arraySubject)
            {
                Console.WriteLine($"{j++} {subject.SubjectName.ToString()}");
            }
            Console.WriteLine($"{j} Create new subject");
            selectedSubject = Console.ReadLine();
            int selctedSubjectInt = int.Parse(selectedSubject);
            if (j == selctedSubjectInt)
            {
                AddSubject(selctedSchoolInt);
            }

            return selctedSubjectInt;
        }

        private int SelectionOfSchool()
        {
            Console.WriteLine("Choose your School:");
            int i = 1;
            foreach (var school in arraySchool)
            {
                Console.WriteLine($"{i++} {school.SchoolName.ToString()}");
            }
            Console.WriteLine($"{i} Create new school");

            selectedSchool = Console.ReadLine();
            int selctedSchoolInt = int.Parse(selectedSchool);
            if (i == selctedSchoolInt)
            {
                AddSchool();
            }

            return selctedSchoolInt;
        }

        public void AddSubject(int selctedSchoolInt)
        {
            Console.WriteLine("Type in the name of subject:");
            string nameOfSubject = Console.ReadLine();
            arraySubject.Add(new Subject(nameOfSubject, arraySchool[selctedSchoolInt-1]));
        }

        public void AddSchool()
        {
            Console.WriteLine("Type in the name of school:");
            string nameOfSchool = Console.ReadLine();
            arraySchool.Add(new School(nameOfSchool));

        }

        private void FindFileName()
        {
            Console.WriteLine("Whats ur name:");
            fileName = Console.ReadLine();
            fileFullName = path + fileName + ".txt";
        }
    }

}
