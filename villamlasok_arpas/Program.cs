namespace villamlasok_arpas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var villamlasok = new List<Villam>();

            using var sr = new StreamReader(@"..\..\..\src\villam.txt");

            int index = 0;

            while (!sr.EndOfStream)
            {
                villamlasok.Add(new(sr.ReadLine(), index));
                index++;
            }

            Console.WriteLine("\n2. feladat:");

            foreach (var item in villamlasok)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n3. feladat:");

            LegtobbetVillamlott(villamlasok);

            Console.WriteLine("\n4. feladat:");

            VillamlasVoltE(villamlasok);
            Console.WriteLine("A fájlbeírás megtörtént.");

            Console.WriteLine("\n5. feladat:");
            Console.WriteLine($"{HanyVillamlas(villamlasok)} alkalommal villámlott.");

            Console.WriteLine("\n6. feladat:");
            Console.WriteLine($"{ElsoIlyen(villamlasok).Nap+1}. nap volt 200 alatti villámlás először.");


            Console.WriteLine("\n7. feladat:");
            var x = VoltE0(villamlasok);

            if (x != null)
            {
                Console.WriteLine($"Az {x.Nap+1}. nap volt az első nap, amikor nem volt villámlás");
            }

            Console.ReadKey();
        }

        static void LegtobbetVillamlott(List<Villam> l) {
            var f3 = l.MaxBy(e => e.Orak.Max());
            var legtobbVillamOra = f3.Orak[0];
            var legtobbVillamOraIndex = 0;

            foreach (var item in f3.Orak)
            {

            }

            for (int i = 0; i < f3.Orak.Count; i++)
            {
                if (f3.Orak[i] > legtobbVillamOra)
                {
                    legtobbVillamOra = f3.Orak[i];
                    legtobbVillamOraIndex = i;
                }
            }

            Console.WriteLine($"A {f3.Nap} napon volt a legtöbb villámlás, a(z) {legtobbVillamOraIndex + 1}. órában");
        }
        
        static void VillamlasVoltE(List<Villam> l)
        {
            List<string> result = new List<string>();
            foreach (var item in l)
            {
                for (int i = 0; i < item.Orak.Count; i++)
                {
                    if (item.Orak[i] > 0)
                    {
                        result.Add($"{i}");
                    }
                    else
                    {
                        result.Add("null");
                    }
                }
            }

            using var sw = new StreamWriter(@"..\..\..\src\ujFajl.txt");
            for (int i = 0; i < 31; i++)
            {
                sw.WriteLine($"{i + 1}. Nap: {result[i]}");
            }
        }

        static int HanyVillamlas(List<Villam> l) => l.Sum(e => e.Orak.Count(i => i > 0));
        static Villam ElsoIlyen(List<Villam> l) => l.First(e => e.Orak.Sum() < 200);
        static Villam VoltE0(List<Villam> l) => l.First(e => e.Orak.Sum() == 0);
    }
}
