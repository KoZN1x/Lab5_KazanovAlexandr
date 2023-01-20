using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Patient
    {
        public event Action<string>? patientChangingDiagnosis;
        private string name;
        private uint age;
        private string diagnosis;

        public Patient(string name, uint age, string diagnosis)
        {
            this.name = name;
            this.age = age;
            this.diagnosis = diagnosis;
            patientChangingDiagnosis += s => Console.WriteLine(s);
        }
        public string SetDiagnosis(string diagnosis)
        {
            this.diagnosis = diagnosis;
            patientChangingDiagnosis?.Invoke($"{name}'s diagnosis was changed to {diagnosis}");
            return this.diagnosis;
        }
        public string GetPatientInfo()
        {
            return $"Patients name is {name}. Patients age is {age}. Patients diagnosis is {diagnosis}.";
        }
        public string GetPatientName()
        {
            return name;
        }
    }
}
