using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hospital
{
    delegate void Delegate(string s);
    internal class Hospital
    {
        public event Action? overflow;
        public event Action<string>? patientAdding;
        public event Action<string>? patientRemoving;
        public List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            if (IsOverflowed())
            {
                overflow?.Invoke();
            }
            else
            {
                patients.Add(patient);
                patientAdding?.Invoke($"Patient {patient.GetPatientName()} was successfully added to the hospital!");
            }
        }

        public void RemovePatient(Patient patient)
        {
            if (patients.Contains(patient))
            {
                patients.Remove(patient);
                patientRemoving?.Invoke($"Patient {patient.GetPatientName()} was successfully removed from the hospital!");
            }
            else Console.WriteLine($"Patient {patient.GetPatientName()} doesn't exist!");
        }

        public void ChangeDiagnosis(Patient patient, string diagnosis)
        {
            if (patients.Contains(patient))
            {
                patient.SetDiagnosis(diagnosis);
            }
            else Console.WriteLine($"Patient {patient.GetPatientName()} doesn't exist!"); ;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (Patient pat in patients)
            {
                stringBuilder.AppendLine(pat.GetPatientInfo());
            }
            return stringBuilder.ToString();
        }

        private bool IsOverflowed()
        {
            return patients.Count >= 15;  
        }
    }
}
