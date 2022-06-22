using System;

namespace Console_ToDo_Uygulaması
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new();
            PersonList PersonList = new();

            Menu.ShowMenu();
        }
    }
}