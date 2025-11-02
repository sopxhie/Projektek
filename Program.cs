using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iroda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dolgozo1 = new Iroda("Kiss Lilien", "programozó", 21, 500000);
            var dolgozo2 = new Iroda("Nagy Ádám", "vezető", 45, 1000000);
            var dolgozo3 = new Iroda("Tóth Réka", "könyvelő", 30, 600000);
            var dolgozo4 = new Iroda("Szabó Bence", "rendszergazda", 28, 450000);
            var dolgozo5 = new Iroda("Varga Anna", "programozó", 35, 700000);

            Iroda.dolgozok.Add(dolgozo1);
            Iroda.dolgozok.Add(dolgozo2);
            Iroda.dolgozok.Add(dolgozo3);
            Iroda.dolgozok.Add(dolgozo4);
            Iroda.dolgozok.Add(dolgozo5);

            //1. feladat
            var elso = Iroda.Legidosebb();
            Console.WriteLine("A legidősebb dolgozó: {0}",elso);

            //2. feladat
            var masodik = Iroda.Átlag();
            Console.WriteLine("A dolgozók átlagkeresete: {0} Ft", masodik);

            //3. feladat
            var harmadik = Iroda.Van();
            if (harmadik)
            {
                Console.WriteLine("Van 800000 Ft-nál többet kereső dolgozó.");
            }
            else
            {
                Console.WriteLine("Nincs 800000 Ft-nál többet kereső dolgozó.");
            }


            //4. feladat
            var negyedik = Iroda.Atlagonfelul();
            Console.WriteLine("Az átlagon felül kereső dolgozók: ");
            foreach (var nev in negyedik)
            {
                Console.WriteLine(nev);
            }

            //5. feladat
            var otodik = Iroda.Fiatal();
            Console.WriteLine("{0} dolgozó keres kevesebbet az átlagkeresetnél és fiatalabb az átlag életkornál", otodik);

        }

    }
    public class Iroda
    {
        public static List<Iroda> dolgozok = new List<Iroda>();

        public string nev;
        public string foglalkozás;
        public int kor;
        public int kereset;

        public string Nev
        {
            get => nev;
            set => nev = (value.Length > 1) ? value : throw new Exception(nameof(Nev) + "Kérlek minimum 2 karakteru legyen a megadott név");
        }

        public string Foglalkozás
        {
            get => foglalkozás;
            set => foglalkozás = (value.Length > 3) ? value : throw new Exception(nameof(Foglalkozás) + "Kérlek minimum 3 karakteru legyen a megadott foglalkozás");
        }

        public int Kor
        {
            get => kor;
            set => kor = (value >= 18 ) ? value : throw new Exception(nameof(Kor) + "Kérlek 18 feletti életkort adj meg");
        }

        public int Kereset
        {
            get => kereset;
            set => kereset = (value >= 0) ? value : throw new Exception(nameof(Kereset) + "Kérlek pozitív számot adj meg a keresetre");
        }

        public Iroda(string nev, string foglalkozás, int kor, int kereset)
        {
            Nev = nev;
            Foglalkozás = foglalkozás;
            Kor = kor;
            Kereset = kereset;
        }

        public static string Legidosebb()
        {
            int max = dolgozok[0].kor;
            foreach (var dolgozo in dolgozok)
            {
                if (dolgozo.kor > max)
                {
                    max = dolgozo.kor;
                }
            }
            string legidosebb = "";
            foreach (var dolgozo in dolgozok)
            {
                if (dolgozo.kor == max)
                {
                    legidosebb += dolgozo.nev;
                }
            }
            return legidosebb;

        }

        public static double Átlag()
        {
            double osszeg = 0;
            foreach (var dolgozo in dolgozok)
            {
                osszeg += dolgozo.kereset;
            }
            double atlag = osszeg / dolgozok.Count;

            return atlag;
        }

        public static bool Van()
        {
            int max = 800000;
            bool van = false;
            foreach (var dolgozo in dolgozok)
            {
                if (dolgozo.kereset > max)
                {
                    van = true;
                }
            }
            return van;
        }

        public static List<string> Atlagonfelul()
        {
            List<string> atlagonfelul = new List<string>();

            double osszeg = 0;
            foreach (var dolgozo in dolgozok)
            {
                osszeg += dolgozo.kereset;
            }
            double atlag = osszeg / dolgozok.Count;

            foreach (var dolgozo in dolgozok)
            {
                if (dolgozo.kereset > atlag)
                {
                    atlagonfelul.Add(dolgozo.nev);
                }
            }
            return atlagonfelul;
        }

        public static int Fiatal()
        {
            
            int hany = 0;
            double osszeg = 0;
            foreach (var dolgozo in dolgozok)
            {
                osszeg += dolgozo.kereset;
            }
            double atlagkereset = osszeg / dolgozok.Count;

            double osszegkor = 0;
            foreach (var dolgozo in dolgozok)
            {
                osszegkor += dolgozo.kor;
            }
            double atlagkor = osszegkor / dolgozok.Count;

            foreach (var dolgozo in dolgozok)
            {
                if (dolgozo.kereset < atlagkereset && dolgozo.kor < atlagkor)
                {
                    hany++;
                }
            }
            return hany;
        }


    }
}
