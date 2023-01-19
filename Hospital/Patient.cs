using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Patient
    {
        private string name;
        private uint age;
        private string diagnosis;
        public Patient(string name, uint age, string diagnosis)
        {
            this.name = name;
            this.age = age;
            this.diagnosis = diagnosis;
        }
        public string SetDiagnosis(string diagnosis)
        {
            this.diagnosis = diagnosis;
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
