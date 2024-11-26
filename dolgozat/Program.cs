namespace dolgozat
{
	internal class Program
	{
		static List<string> vasarloKosar = new List<string>();
		static List<int> kosarMennyisegek = new List<int>();

		static string[] raktarTermekek = new string[10];
		static int[] raktarMennyisegek = new int[10];
		static int[] raktarArak = new int[10];

		static void Main()
		{
			bool fut = true;
			while (fut)
			{
				Console.WriteLine("1. Termékek megjelenítése a raktárból");
				Console.WriteLine("2. Termék hozzáadása a kosárhoz");
				Console.WriteLine("3. Kosár tartalmának megjelenítése");
				Console.WriteLine("4. Termék eltávolítása a kosárból");
				Console.WriteLine("5. Kosár ürítése");
				Console.WriteLine("6. Vásárlás szimuláció");
				Console.WriteLine("7. Legdrágább termék a raktárban");
				Console.WriteLine("8. Legolcsóbb termék a raktárban");
				Console.WriteLine("9. Kosár statisztika");
				Console.WriteLine("10. Kosár teljes értéke");
				Console.WriteLine("11. Új termék felvétele a raktárba");
				Console.WriteLine("12.  Termékek rendezése ár szerint");

				if (!int.TryParse(Console.ReadLine(), out int opcio))
				{
					Console.WriteLine("Hibás bevitel! Kérlek, adj meg egy érvényes számot.");
					continue;
				}

				switch (opcio)
				{
					case 1:
						Console.Clear();
						RaktarMegtekintes();
						break;
					case 2:
						Console.Clear();
						Hozzaadas();
						break;
					case 3:
						Console.Clear();
						kosarMegtekintes();
						break;
					case 4:
						Console.Clear();
						TermekTorlese();
						break;
					case 5:
						Console.Clear();
						kosarUrites();
						break;
					case 6:
						Console.Clear();
						vasarlasSzimulacio();
						break;
					case 7:
						Console.Clear();
						legragabbKereses();
						break;
					case 8:
						Console.Clear();
						legolcsobbKereses();
						break;
					case 9:
						break;
					case 10:
						break;
					case 11:
						break;
					case 12:
						break;

					default:
						Console.WriteLine("Érvénytelen opció! Próbáld újra.");
						break;
				}
			}

		}

		static void vasarlasSzimulacio()
		{
			int osszeg = 0;
			for (int i = 0; i < raktarArak.Count(); i++)
			{
				osszeg += raktarArak[i];

			}
			for (int i = 0; i < vasarloKosar.Count; i++)
			{
				Console.WriteLine($"- {vasarloKosar[i]}: {kosarMennyisegek[i]}db {raktarArak} ft.");
				Console.WriteLine($"Összesen: {osszeg} ft.");
			}
		}
		static void RaktarMegtekintes()
		{
			Console.WriteLine("Raktárkészlet:");
			for (int i = 0; i < raktarTermekek.Length; i++)
			{
				if (raktarTermekek[i] != null)
				{
					Console.WriteLine($"- {raktarTermekek[i]}: {raktarMennyisegek[i]} db");
				}
			}
		}
		static void kosarMegtekintes()
		{
			if (vasarloKosar.Count == 0)
			{
				Console.WriteLine("A bevásárlólista üres.");
				return;
			}

			Console.WriteLine("Bevásárlólista:");
			for (int i = 0; i < vasarloKosar.Count; i++)
			{
				Console.WriteLine($"- {vasarloKosar[i]}: {kosarMennyisegek[i]} db");
			}

			static void kosarMegtekintes()
			{
				if (vasarloKosar.Count == 0)
				{
					Console.WriteLine("A bevásárlólista üres.");
					return;
				}

				Console.WriteLine("Bevásárlólista:");
				for (int i = 0; i < vasarloKosar.Count; i++)
				{
					Console.WriteLine($"- {vasarloKosar[i]}: {kosarMennyisegek[i]} db");
				}
			}
		}
		static void kosarUrites()
		{
			vasarloKosar.Clear();
			kosarMennyisegek.Clear();
		}
		static void Hozzaadas()
		{
			Console.Write("Add meg a termék nevét: ");
			string termek = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(termek))
			{
				Console.WriteLine("A termék neve nem lehet üres!");
				return;
			}

			Console.Write("Add meg a mennyiséget: ");
			if (!int.TryParse(Console.ReadLine(), out int mennyiseg) || mennyiseg <= 0)
			{
				Console.WriteLine("A mennyiség csak pozitív egész szám lehet!");
				return;
			}

			if (vasarloKosar.Contains(termek))
			{
				Console.WriteLine("Ez a termék már szerepel a bevásárlólistán. Frissítsd a mennyiséget!");
				return;
			}

			raktarTermekek.Add(termek);
			raktarMennyisegek.Add(mennyiseg);
			Console.WriteLine($"A(z) {termek} hozzáadva a bevásárlólistához, {mennyiseg} db.");
		}
		static void TermekTorlese()
		{
			if (vasarloKosar.Count == 0)
			{
				Console.WriteLine("A bevásárlólista üres, nincs mit törölni.");
				return;
			}

			Console.Write("Add meg a törölni kívánt termék nevét: ");
			string termek = Console.ReadLine();

			int index = vasarloKosar.IndexOf(termek);
			if (index == -1)
			{
				Console.WriteLine("Ez a termék nincs a bevásárlólistán.");
				return;
			}

			vasarloKosar.RemoveAt(index);
			kosarMennyisegek.RemoveAt(index);
			Console.WriteLine($"A(z) {termek} törölve a bevásárlólistáról.");
		}

		static void legragabbKereses()
		{
			int max = 0;
			for (int i = 0; i < raktarArak.Count(); i++)
			{
				if (raktarArak[i] > max)
				{
					max = raktarArak[i];
				}
			}

		}
		static void legolcsobbKereses()
		{
			int min = 0;
			for (int i = 0; i < raktarArak.Count(); i++)
			{
				if (raktarArak[i] > min)
				{
					min = raktarArak[i];
				}
			}

		}

		static void kosarStatisztika()
		{
			int kulonbozoTermek = 0;
			int osszTermek = 0;
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
				osszTermek += i;
            }
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                
            }
        }

	}
}
