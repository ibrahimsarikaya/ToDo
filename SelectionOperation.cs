using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_ToDo_Uygulaması
{
    public class SelectionOperation
    {
        public static void ListTheLine(List<Card> cards, string line)
        {
            foreach (var card in cards)
            {
                if (card.Line == line)
                {
                    Console.WriteLine("\nBaşlık: " + card.Title);
                    Console.WriteLine("İçerik: " + card.Content);
                    Console.WriteLine("Atanan Kişi: " + PersonList.persons.Find(person => person.PersonalID == card.PersonalID).Name);
                    Console.WriteLine("Büyüklük: " + card.Size);
                    Console.WriteLine("-");
                }
            }
        }

        public static void ListTheBoard()
        {
            Console.WriteLine("\nTODO Line");
            Console.WriteLine("************************");
            ListTheLine(Board.CardList, "ToDo");

            Console.WriteLine("\nIN PROGRESS Line");
            Console.WriteLine("************************");
            ListTheLine(Board.CardList, "InProgress");

            Console.WriteLine("\nDONE Line");
            Console.WriteLine("************************");
            ListTheLine(Board.CardList, "Done");

            Menu.ShowMenu();
        }

        public static void AddCardToBoard()
        {
            Console.WriteLine("\nBaşlık Giriniz\t:");
            string _title = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz\t:");
            string _content = Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) :");
            int _size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kişi Seçiniz\t:");
            string _personalID = Console.ReadLine();

            if (PersonList.persons.Find(person => person.PersonalID == _personalID).PersonalID == _personalID)
            {
                Board.CardList.Add(new Card(_title, _content, _personalID, _size, "ToDo"));
            }
            else
            {
                Console.WriteLine("Hatalı Giriş Yaptınız!");
            }
            Menu.ShowMenu();
        }

        public static void RemoveCardFromBoard()
        {
            Console.WriteLine("\nÖncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            string _title = (Console.ReadLine().ToUpper());
            List<Card> CardsToBeRemoved = Board.CardList.Where(card => card.Title.ToUpper() == _title).ToList();
            if (CardsToBeRemoved.Count > 0)
            {
                for (int i = 0; i < CardsToBeRemoved.Count; i++)
                {
                    Board.CardList.RemoveAll(card => card.Title.ToUpper() == _title);
                }
                Console.WriteLine("Kart silindi.");
            }
            else
            {
                CardHasNotFound();
            }
        }

        public static void MoveTheCard()
        {
            Console.WriteLine("\nÖncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:  ");
            string _title = (Console.ReadLine().ToUpper());
            List<Card> CardsWillBeChange = Board.CardList.Where(card => card.Title.ToUpper() == _title).ToList();
            if (CardsWillBeChange.Count > 0)
            {
                ShowTheCard(_title);

                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: ");
                Console.WriteLine(" (1) TODO");
                Console.WriteLine(" (2) IN PROGRESS");
                Console.WriteLine(" (3) DONE");
                int selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        CardsWillBeChange[0].Line = "ToDo";
                        break;
                    case 2:
                        CardsWillBeChange[0].Line = "InProgress";
                        break;
                    case 3:
                        CardsWillBeChange[0].Line = "Done";
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız!");
                        break;
                }
                Menu.ShowMenu();
            }
            else
            {
                CardHasNotFound();
            }
        }

        public static void ShowTheCard(string title)
        {
            List<Card> CardsWillBeChange = Board.CardList.Where(card => card.Title.ToUpper() == title).ToList();
            Console.WriteLine("\nBulunan Kart Bilgileri:");
            Console.WriteLine(" **************************************");
            Console.WriteLine("Başlık: " + CardsWillBeChange[0].Title);
            Console.WriteLine("İçerik: " + CardsWillBeChange[0].Content);
            Console.WriteLine("Atanan Kişi: " + PersonList.persons.Find(person => person.PersonalID == CardsWillBeChange[0].PersonalID).Name);
            Console.WriteLine("Büyüklük: " + CardsWillBeChange[0].Size);
            Console.WriteLine("Line: " + CardsWillBeChange[0].Line);
        }

        public static void CardHasNotFound([CallerMemberName] string callerMemberName = "")
        {
            Console.WriteLine("\nAradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız:");
            Console.WriteLine("* İşlemi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            int selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    Menu.ShowMenu();
                    break;
                case 2:
                    if (callerMemberName == "RemoveCardFromBoard")
                    {
                        RemoveCardFromBoard();
                    }
                    else if (callerMemberName == "MoveTheCard")
                    {
                        MoveTheCard();
                    }
                    break;
                default:
                    Console.WriteLine("Yanlış seçim yaptınız.");
                    Menu.ShowMenu();
                    break;
            }
        }
    }
}