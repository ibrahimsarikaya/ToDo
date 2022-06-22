namespace Console_ToDo_Uygulaması
{
    public class Card
    {
        private string _title;
        private string _content;
        private string _personalID;
        private int _size;
        private string _line;

        public string Title { get => _title; set => _title = value; }
        public string Content { get => _content; set => _content = value; }
        public string PersonalID { get => _personalID; set => _personalID = value; }
        public int Size { get => _size; set => _size = value; }
        public string Line { get => _line; set => _line = value; }

        public Card(string title, string content, string personalID, int size, string line)
        {
            Title = title;
            Content = content;
            PersonalID = personalID;
            Size = size;
            Line = line;
        }
    }
}