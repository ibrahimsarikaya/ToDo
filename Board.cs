using System.Collections.Generic;

namespace Console_ToDo_Uygulaması
{
    public class Board
    {
        public static List<Card> CardList = new();

        public Board()
        {
            CardList.Add(new Card("CS50x", "CS50x hakkında daha fazla bilgi edin.", "1", 2, "ToDo"));
            CardList.Add(new Card("Proje", "Çizim projesini tamamla.", "2", 5, "InProgress"));
            CardList.Add(new Card("İş", "Yeni bir dükkan satın al.", "3", 3, "Done"));
        }
    }
}