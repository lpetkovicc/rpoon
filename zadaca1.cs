using System;
using System.Collections.Generic;
namespace Zadaca
{
    public abstract class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int ID;

        public Osoba(string ime, string prezime, int id)
        {
            Ime = ime;
            Prezime = prezime;
            ID = id;
        }
    }


    public class Student : Osoba
    {
        public List<int> Ocjene { get; set; }
        public string Razred { get; set; }

        public Student(string ime, string prezime, int id, string razred) : base(ime, prezime, id)
        {
            Ocjene = new List<int>();
            Razred = razred;
        }

        public void DodajOcjenu(int ocjena)
        {
            Ocjene.Add(ocjena);
        }

        public void PregledOcjena()
        {
            Console.WriteLine($"Ocjene studenta {Ime} {Prezime}: {string.Join(", ", Ocjene)}");
        }
    }


    public class Ucitelj : Osoba
    {
        public List<string> Predmeti { get; set; }

        public Ucitelj(string ime, string prezime, int id, List<string> predmeti) : base(ime, prezime, id)
        {
           Predmeti = new List<string>();;
        }

        public void DodajOcjenuStudentu(Student student, int ocjena)
        {
            student.DodajOcjenu(ocjena);
        }

        public void PregledOcjenaUcenika(Student student)
        {
            student.PregledOcjena();
        }

        public void PregledOcjenaRazreda(List<Student> razred)
        {
            foreach (var student in razred)
            {
                PregledOcjenaUcenika(student);
            }
        }
    }

   
    public class Ravnatelj : Osoba
    {
        public List<Ucitelj> Ucitelji { get; set; }
        public List<Student> Studenti { get; set; }

        public Ravnatelj(string ime, string prezime, int id) : base(ime, prezime, id)
        {
            Ucitelji = new List<Ucitelj>();
            Studenti = new List<Student>();
        }

        public void DodajUcitelja(Ucitelj ucitelj)
        {
            Ucitelji.Add(ucitelj);
        }

        public void DodajStudenta(Student student)
        {
            Studenti.Add(student);
        }

        public void UkloniUcitelja(Ucitelj ucitelj)
        {
            Ucitelji.Remove(ucitelj);
        }

        public void UkloniStudenta(Student student)
        {
            Studenti.Remove(student);
        }

        public void PregledOpćihOcjenaSkole()
        {
            foreach (var student in Studenti)
            {
                student.PregledOcjena();
            }
        }
    }


    public class Razred
    {
        public string NazivRazreda { get; set; }
        public List<Student> Studenti { get; set; }

        public Razred(string nazivRazreda)
        {
            NazivRazreda = nazivRazreda;
            Studenti = new List<Student>();
        }

        public void DodajStudenta(Student student)
        {
            Studenti.Add(student);
        }

        public void UkloniStudenta(Student student)
        {
            Studenti.Remove(student);
        }

        public void PrikaziOcjeneRazreda()
        {
            foreach (var student in Studenti)
            {
                student.PregledOcjena();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Primjer upotrebe
            Ravnatelj ravnatelj = new Ravnatelj("MATKO", "JOSIPOVIC", 1);

            Ucitelj ucitelj = new Ucitelj("FILIP", "JURIC", 2, new List<string> { "Engleski", "Hrvatski" });
            ravnatelj.DodajUcitelja(ucitelj);

            Student student = new Student("Luka", "Petkovic", 3, "3A");
            ravnatelj.DodajStudenta(student);

            Razred razred3A = new Razred("3A");
            razred3A.DodajStudenta(student);

            ucitelj.DodajOcjenuStudentu(student, 5);

            ravnatelj.PregledOpćihOcjenaSkole();
            ucitelj.PregledOcjenaRazreda(razred3A.Studenti);
        }
    }
}
