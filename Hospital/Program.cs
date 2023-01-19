namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Delegate View = x => Console.WriteLine(x);

            var alex = new Patient("Alex", 45, "Heart attack");
            var dima = new Patient("Dima", 59, "Stroke");
            var misha = new Patient("Misha", 27, "Healthy");
            var alexandr = new Patient("Alexandr", 34, "Heart attack");
            var aleksey = new Patient("Aleksey", 59, "Stroke");
            var mihail = new Patient("Mihail", 27, "Healthy");
            var andrey = new Patient("Andrey", 45, "Heart attack");
            var roman = new Patient("Roman", 59, "Stroke");
            var anton = new Patient("Anton", 27, "Healthy");
            var kirill = new Patient("Kirill", 45, "Heart attack");
            var matvey = new Patient("Matvey", 59, "Stroke");
            var yuriy = new Patient("Yuriy", 27, "Healthy");
            var maksim = new Patient("Maksim", 45, "Heart attack");
            var anna = new Patient("Anna", 59, "Stroke");
            var anzhela = new Patient("Anzhela", 27, "Healthy");
            var nastya = new Patient("Nastya", 45, "Heart attack");
            var dmitryi = new Patient("Dmitriy", 59, "Stroke");
            var ivan = new Patient("Ivan", 27, "Healthy");

            var hospital = new Hospital();

            hospital.overflow += hospital.Notify;
            hospital.patientAdding += s => Console.WriteLine(s);
            hospital.patientRemoving += s => Console.WriteLine(s);
            hospital.patientChangingDiagnosis += s => Console.WriteLine(s);

            hospital.AddPatient(alex);
            hospital.AddPatient(dima);
            hospital.AddPatient(misha);
            hospital.AddPatient(alexandr);
            hospital.AddPatient(aleksey);
            hospital.AddPatient(mihail);
            hospital.AddPatient(andrey);
            hospital.AddPatient(roman);
            hospital.AddPatient(anton);
            hospital.AddPatient(kirill);
            hospital.AddPatient(matvey);
            hospital.AddPatient(yuriy);
            hospital.AddPatient(maksim);
            hospital.AddPatient(anna);
            hospital.AddPatient(anzhela);
            hospital.AddPatient(nastya);
            hospital.AddPatient(dmitryi);
            hospital.AddPatient(ivan);


            View(hospital.ToString());
            //Console.WriteLine(hospital.ToString());

            hospital.ChangeDiagnosis(alex, "Healthy");
            View(hospital.ToString());
            //Console.WriteLine(hospital.ToString());

            hospital.RemovePatient(dima);
            View(hospital.ToString());
            //Console.WriteLine(hospital.ToString());
        }
    }
}