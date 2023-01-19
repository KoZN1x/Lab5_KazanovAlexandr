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
        public event Action<Patient>? overflow;
        public event Action<string>? patientAdding;
        public event Action<string>? patientRemoving;
        public event Action<string>? patientChangingDiagnosis;
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
                patientAdding?.Invoke($"Patient {patient.GetPatientName()} was successfully added to the hospital!");
            }
        }
        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
            patientRemoving?.Invoke($"Patient {patient.GetPatientName()} was successfully removed from the hospital!");
        }
        public void ChangeDiagnosis(Patient patient, string diagnosis)
        {
            foreach (Patient pat in patients)
            {
                if (patient == pat)
                {
                    pat.SetDiagnosis(diagnosis);
                    patientChangingDiagnosis?.Invoke($"{patient.GetPatientName} diagnosis have been changed to {diagnosis}");
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
            Console.WriteLine($"Hospital is overflowed! Can't add patient: {patient.GetPatientName()}");
        }
    }
}
