using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Zad1_KsiazkaTelefoniczna
{
    class MechanizmDzialania 
    {
        List<Osoba> KsiazkaTelefoniczna = new List<Osoba>();
        public void RysujMenu()
        {
            while (true)
            {
                int wybor = 0;
                System.Console.Clear();
                Console.WriteLine("Wybierz opcje do realizacji:");
                Console.WriteLine("1. Dodaj kontakt");
                Console.WriteLine("2. Usuń kontakt");
                Console.WriteLine("3. Wyswietl wszystkie kontakty");
                Console.WriteLine("4. Posortuj elementy wg nazwiska");
                Console.WriteLine("5. Szukaj osoby wg numeru");
                Console.WriteLine("6. Wyjdź z programu");
                try
                {
                    wybor = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} - wystapil exception", e);
                    Console.ReadLine();
                }


                switch (wybor)
                {
                    case 1:
                        System.Console.Clear();
                        this.DodajKontakt();
                        Console.Clear();
                        break;
                    case 2:
                        UsunPozycje();
                        break;
                    case 3:
                        this.WyswietlListe();
                        Console.WriteLine("Wciśnij dowolny klawisz ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        KsiazkaTelefoniczna.Sort((x, y) => string.Compare(x.Nazwisko, y.Nazwisko));
                        break;
                    case 5:
                        SzukajWgNumeru();
                        break;
                    case 6:
                        System.Console.Clear();
                        System.Threading.Thread.Sleep(1000);
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nie ma takiej opcji!");

                        break;
                }
            }
        }

        public void DodajKontakt()
        {            
            Console.Clear();
            Console.WriteLine("Podaj kolejno imie, nazwisko, numer. Potwierdzaj klawiszem enter");
            string imie = PobierzDane();
            string nazwisko = PobierzDane();
            int numer;
            bool sukces = int.TryParse(PobierzDane(),out numer); 

            KsiazkaTelefoniczna.Add(new Osoba { Imie = imie, Nazwisko = nazwisko, NumerTelefonu = numer});            
        }

        public string PobierzDane()
        {
            string dane = "";
            
            try
            {
                dane = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Wyłapano wyjatek! {0}", e);
            }

            return dane;
        }

        public void WyswietlListe()
        {
            Console.Clear();
            int i = 1;
            foreach (var item in KsiazkaTelefoniczna)
            {
                Console.WriteLine(i + ". imie: {0} \tnazwisko: {1} \tnumer: {2}", item.Imie, item.Nazwisko, item.NumerTelefonu);
                i++;
            }
        }

        public void UsunPozycje()
        {
            Console.Clear();
            this.WyswietlListe();
            Console.Write("Którą pozycje mam usunąć?");
            int linia = int.Parse(Console.ReadLine());

            KsiazkaTelefoniczna.RemoveAt(linia-1);
            Console.ReadLine();
        }

        public void SzukajWgNumeru()
        {
            Console.Clear();
            Console.WriteLine("Podaj numer i zatwierdź klawiszem enter:");
            int numer;
            bool sukces = int.TryParse(PobierzDane(), out numer);

            foreach (var item in KsiazkaTelefoniczna)
            {
                if(item.NumerTelefonu == numer)
                {
                    Console.WriteLine("imie: {0} \tnazwisko: {1} \tnumer: {2}", item.Imie, item.Nazwisko, item.NumerTelefonu);
                }
            }
            Console.WriteLine("Wciśnij dowolny klawisz ...");
            Console.ReadKey();
        }
    }
}
