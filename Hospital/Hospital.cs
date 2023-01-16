using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{

    delegate void Delegate(string s);
    internal class Hospital : INotifyable
    {
        public event Action<Patient> overflow;
        private List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient patient)
        {
            if (IsOverflowed())
            {
                overflow?.Invoke(patient);
            }
            else
            {
                patients.Add(patient);
            }
        }
        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
        }
        public void ChangeDiagnosis(Patient patient, string diagnosis)
        {
            foreach (Patient pat in patients)
            {
                if (patient == pat)
                {
                    pat.SetDiagnosis(diagnosis);
                }
            }
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
            if (patients.Count >= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Notify(Patient patient)
        {
            Console.WriteLine($"Hospital is overflowed! Can't add patient: {patient.GetPatientInfo()}");
        }
    }
}
