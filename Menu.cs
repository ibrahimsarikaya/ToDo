using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ToDo_Uygulaması
{
    public class Menu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");

            int selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    SelectionOperation.ListTheBoard();
                    break;
                case 2:
                    SelectionOperation.AddCardToBoard();
                    break;
                case 3:
                    SelectionOperation.RemoveCardFromBoard();
                    break;
                case 4:
                    SelectionOperation.MoveTheCard();
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız.");
                    Menu.ShowMenu();
                    break;


            }


        }
    }
}