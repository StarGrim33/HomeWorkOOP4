namespace HomeWorkOOP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pack[] cards = { new Pack("7 червей"), new Pack("8 червей"), new Pack("Король червей"), new Pack("Туз червей") };
            bool isProgramOn = true;

            while (isProgramOn)
            {
                Console.WriteLine("Нажмите любую клавишу, чтобы взять карту");

                for (int i = 0; i < cards.Length; i++)
                {
                    cards[i].ShowAllCards();
                }


            }
        }
    }
}

class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void TakeCard()
    {
        //Console.WriteLine
    }
}

class Pack
{
    public Pack(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public int CardsRemaining { get; private set; }

    public void ShowAllCards()
    {
        Console.WriteLine("\nКолода карт: \nКарта - " + Name);
        Console.ReadKey();
    }

}