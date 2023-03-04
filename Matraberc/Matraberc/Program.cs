using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matraberc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. feladat

            List<Versenyzo> adatok = new List<Versenyzo>();

            foreach (var item in File.ReadAllLines("matraberc.txt").Skip(1))
            {
                adatok.Add(new Versenyzo(item));
            }

            // 3. feladat

            Console.WriteLine($"Az adatok száma: {adatok.Count}");

            // 4. feladat

            double no = 0;

            foreach (var item in adatok)
            {
                if (item.Nem == "Nő")
                    no++;
            }
            double result4 = (no / adatok.Count) * 100;

            Console.WriteLine($"Az indulók {result4.ToString("0.00")} %-a nő");

            // 5. feladat

            var noi = adatok.Where(x => x.Nem == "Nő").Select(x => x);

            int num = 9999;
            string nyertesN  = "";
            string nyertesI = "";

            foreach (var item in noi)
            {
                string[] idomertek = item.Ido.Split(':');
                int perc = Convert.ToInt32(idomertek[0]);
                int masodperc = Convert.ToInt32(idomertek[1]);
                int adott = (perc*60) + masodperc;
                if (adott < num)
                {
                    num = adott;
                    nyertesN = item.Nev;
                    nyertesI = item.Ido;
                }
            }

            Console.WriteLine($"A győztes nő neve: {nyertesN} és a győztes idő: {nyertesI}");

            // 6. feladat

            List<string> tel = new List<string>();

            int szam = 0;

            foreach (var item in adatok)
            {
                if (!tel.Contains(item.Telepules))
                {
                    string tempt = item.Telepules;
                    tel.Add(tempt);
                    foreach (var k in adatok)
                    { 
                        if (tempt == k.Telepules)
                        {
                            szam++;
                        }
                    }
                    Console.WriteLine($"{tempt} : {szam}");
                    szam = 0;
                }
            }

            // 7. feladat

            var nok = adatok.Where(x => x.Nem == "Nő").Select(x => x);

            string code = "";

            foreach (var item in nok)
            {
                string c1 = Convert.ToString(item.Ev).Substring(3, 1);

                string[] nevecske = item.Nev.Split(' ');
                if (item.Nev.ToUpper().StartsWith("DR."))
                {
                    nevecske[0] = nevecske[1];
                    nevecske[1] = nevecske[2];
                }
                string c2 = nevecske[0].Substring(0, 2).ToLower();
                string c3 = nevecske[1].Substring(0, 3).ToLower();
                code = c1 + c2 + c3;

                Console.WriteLine($"{item.Ev} {item.Nev} {code}");
            }

            // Férfiak átlagideje

            var ferfi = adatok.Where(x => x.Nem == "Férfi").Select(x => x);

            int osszIdo = 0;

            foreach (var item in ferfi)
            {
                string[] ido = item.Ido.Split(':');
                int ido1 = int.Parse(ido[0]);
                int ido2 = int.Parse(ido[1]);

                osszIdo += (ido1 * 60) + ido2;
            }

            int ido4 = (osszIdo / ferfi.Count()) / 60;
            int ido5 = (osszIdo / ferfi.Count()) % 60;
            string ido6 = ido4 + ":" + ido5;

            Console.WriteLine($"A férfi átlag idő: {ido6}");

            Console.ReadLine();
        }
    }
}
