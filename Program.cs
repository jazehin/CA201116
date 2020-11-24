using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201116
{
    class Program
    {
        struct Egitest
        {
            public string Nev;
            public string Knev;
            public long Ktav;
            public int Atmero;

            public Egitest(string nev, string knev, long tav, int atmero)
            {
                Nev = nev;
                Knev = knev;
                Ktav = tav;
                Atmero = atmero;
            }
        }

        static List<Egitest> egitestek = new List<Egitest>();

        static void Main()
        {
            Beolvas();
            A();
            B();
            C();
            D();
            E();
            Console.ReadKey();
        }

        static void Beolvas()
        {
            var sr = new StreamReader(@"..\..\Res\egitestek.txt", Encoding.UTF8, true);
            while (!sr.EndOfStream)
            {
                string[] tmp = sr.ReadLine().Split(' ');
                egitestek.Add(new Egitest(tmp[0], tmp[1], Convert.ToInt64(tmp[2]), Convert.ToInt32(tmp[3])));
            }
            sr.Close();
        }

        static void A() //átlagos méret
        {
            long sum = 0;
            foreach (var item in egitestek)
            {
                sum += item.Atmero;
            }
            Console.WriteLine($"Átlagos átmérő: {(double)sum/egitestek.Count :0.000} (km), átlagos térfogat: {(4*Math.Pow(((double)sum / egitestek.Count) /2, 3) * Math.PI) /(3) :0.000} (km3)");
        }

        static void B()
        {
            int maxi = 0;
            for (int i = 0; i < egitestek.Count; i++)
            {
                if (egitestek[i].Atmero > egitestek[maxi].Atmero) maxi = i;
            }
            Console.WriteLine($"Legnagyobb átmérőjű égitest: {egitestek[maxi].Nev}, átmérője: {egitestek[maxi].Atmero}");
        }

        static void C()
        {
            int c = 0;
            foreach (var e in egitestek)
            {
                if (e.Knev == "Neptunusz") c++;
            }
            Console.WriteLine($"Neptunusz holdjainak száma: {c}");
        }

        static void D()
        {
            foreach (var e in egitestek)
            {
                if (e.Knev == "Nap") Console.Write(e.Nev + " ");
            }
        }

        static void E()
        {
            List<string> jholdak = new List<string>();
            List<long> jtavolsag = new List<long>();

            for (int i = 0; i < egitestek.Count; i++)
            {
                if (egitestek[i].Knev == "Jupiter")
                {
                    jholdak.Add(egitestek[i].Nev);
                    jtavolsag.Add(egitestek[i].Ktav);
                }
            }

            for (int i = jholdak.Count - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if(jtavolsag[j] > jtavolsag[j + 1])
                    {
                        string tempNev = jholdak[j];
                        jholdak[j] = jholdak[j + 1];
                        jholdak[j + 1] = tempNev;

                        long tempTav = jtavolsag[j];
                        jtavolsag[j] = jtavolsag[j + 1];
                        jtavolsag[j + 1] = tempTav;
                    }
                }
            }

            var sw = new StreamWriter(@"..\..\Res\jupiter.txt", false, Encoding.UTF8);

            foreach (var item in jholdak)
            {
                sw.WriteLine(item);
            }

            sw.Flush();
            sw.Close();

            Console.WriteLine("\n(Új) fájlba írtam :)");
        }
    }
}
