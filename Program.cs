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
            public string nev;
            public string knev;
            public long ktav;
            public int atmero;

            public Egitest Uj(string nev, string knev, long tav, int atmero)
            {
                this.nev = nev;
                this.knev = knev;
                this.ktav = tav;
                this.atmero = atmero;
                return this;
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
                egitestek.Add(new Egitest().Uj(tmp[0], tmp[1], Convert.ToInt64(tmp[2]), Convert.ToInt32(tmp[3])));
            }
            sr.Close();
        }

        static void A() //átlagos méret
        {
            long sum = 0;
            foreach (var item in egitestek)
            {
                sum += item.atmero;
            }
            Console.WriteLine($"Átlagos átmérő: {(double)sum/egitestek.Count :0.000} (km), átlagos térfogat: {(4*Math.Pow(((double)sum / egitestek.Count) /2, 3) * Math.PI) /(3) :0.000} (km3)");
        }

        static void B()
        {
            int maxi = 0;
            for (int i = 0; i < egitestek.Count; i++)
            {
                if (egitestek[i].atmero > egitestek[maxi].atmero) maxi = i;
            }
            Console.WriteLine($"Legnagyobb átmérőjű égitest: {egitestek[maxi].nev}, átmérője: {egitestek[maxi].atmero}");
        }

        static void C()
        {
            int c = 0;
            for (int i = 0; i < egitestek.Count; i++)
            {
                if (egitestek[i].knev == "Neptunusz") c++;
            }
            Console.WriteLine($"Neptunusz holdjainak száma: {c}");
        }

        static void D()
        {
            List<string> bolygok = new List<string>();
            for (int i = 0; i < egitestek.Count; i++)
            {
                if (egitestek[i].knev == "Nap") bolygok.Add(egitestek[i].nev);
            }
            foreach (var item in bolygok)
            {
                Console.Write(item + " ");
            }
        }

        static void E()
        {
            List<string> jholdak = new List<string>();
            List<long> jtavolsag = new List<long>();

            for (int i = 0; i < egitestek.Count; i++)
            {
                if (egitestek[i].knev == "Jupiter")
                {
                    jholdak.Add(egitestek[i].nev);
                    jtavolsag.Add(egitestek[i].ktav);
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

            Console.WriteLine("\nÚj fájlba írtam :)");
        }
    }
}
