namespace villamlasok_arpas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var villamlasok = new List<Villam>();
            villamlasok.AddRange(File.ReadAllLines(@"..\..\..\src\villam.txt").Select((s,i) => new Villam(s,i)));

            Console.WriteLine("\n2. feladat:");
            foreach (var item in villamlasok) Console.WriteLine(item);

            Console.WriteLine("\n3. feladat:");
            LegtobbetVillamlott(villamlasok);

            Console.WriteLine("\n4. feladat:");

            VillamlasVoltE(villamlasok);
            Console.WriteLine("A fájlbeírás megtörtént.");

            Console.WriteLine("\n5. feladat:");
            HanyVillamlas(villamlasok);

            Console.WriteLine("\n6. feladat:");
            ElsoIlyen(villamlasok);

            Console.WriteLine("\n7. feladat:");
            VoltE0(villamlasok);

            Console.WriteLine("\n8. feladat:");
            ElsoKetOra(villamlasok);

            Console.WriteLine("\n9. feladat:");
            VillamlasokSzama(villamlasok);

            Console.WriteLine("\n10. feladat:");
            LegkevesebbetVillamlott(villamlasok);

            Console.WriteLine("\n11. feladat:");
            LegkevesebbetVillamlott(villamlasok);

            Console.WriteLine("\n12. feladat:");
            LegtobbVillamlas7en(villamlasok);

            Console.ReadKey();
        }

        static void LegtobbetVillamlott(List<Villam> l) {

            var f3 = l.MaxBy(e => e.Orak.Max());
            var hely = f3.Orak.IndexOf(f3.Orak.Max());
            Console.WriteLine($"A {f3.Nap} napon volt a legtöbb villámlás, a(z) {hely + 1}. órában");
        }
        static void VillamlasVoltE(List<Villam> l)
        {
            List<string> result = new List<string>();

            foreach (var item in l)
            {
                var villamlasKezdete = item.Orak.FirstOrDefault(e => e > 0);
                string ertek = $"{l.IndexOf(item) + 1}. nap: {(villamlasKezdete == 0 ? "null" : (item.Orak.IndexOf(villamlasKezdete) + 1))}";
                result.Add(ertek);
            }

            File.WriteAllLines(@"..\..\..\src\ujFajl.txt", result);
        }

        static void HanyVillamlas(List<Villam> l) => Console.WriteLine($"{l.Sum(e => e.Orak.Count(i => i > 0))} alkalommal villámlott.");
        static void ElsoIlyen(List<Villam> l) => Console.WriteLine($"{l.First(e => e.Orak.Sum() < 200).Nap}. nap volt 200 alatti villámlás először.");
        static void VoltE0(List<Villam> l) {
            var x = l.FirstOrDefault(e => e.Orak.Sum() == 0);

            if (x != null)
            {
                Console.WriteLine($"Az {x.Nap}. nap volt az első nap, amikor nem volt villámlás");
            }
            else
            {
                Console.WriteLine("Nem volt olyan nap, amikor nem volt villámlás");
            }
        } 
        static void ElsoKetOra(List<Villam> l) => Console.WriteLine($"{l.SelectMany(e => e.Orak.Take(2)).Count(e => e > 0)} olyan óra volt a hónapban, amikor villámlott éjfél után az első és második órában.");
        static void VillamlasokSzama(List<Villam> l) => Console.WriteLine($"{l.Where(e => e.Nap < 21).ToList().Sum(e => e.Orak.Count(e => e > 0))} villámlást regisztráltak aug 1-20 közt.");
        static void LegkevesebbetVillamlott(List<Villam> l)
        {
            var minVillam = l.SelectMany(v => v.Orak.Where(x => x > 0).Select((val, hour) => new { Day = v.Nap, Value = val, Hour = hour })).MinBy(v => v.Value);
            Console.WriteLine($"A {minVillam.Day + 1}. napon volt a legkevesebb villámlás, a(z) {minVillam.Hour + 1}. órában. Az értéke: {minVillam.Value}");
        }
        static void LegtobbVillamlas7en(List<Villam> l)
        {
            var x = l.First(e => e.Nap == 7).Orak;
            Console.WriteLine($"A 7. napon a {x.IndexOf(x.Max()) + 1}. órában villámlott a legtöbbet, ez {x.Max()} villámlás volt.");
        }
    }
}
