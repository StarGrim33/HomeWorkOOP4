namespace HomeWorkOOP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandTakeCard = "1";
            const string CommandShowAllCards = "2";
            const string CommandShowMyCards = "3";
            const string CommandExit = "4";

            bool isProgramOn = true;

            Player player = new("Влад");
            Deck deck = new Deck();

            while (isProgramOn)
            {
                Console.Write(player.Name);

                Console.Clear();

                Console.WriteLine($"{CommandTakeCard}-Взять карту");
                Console.WriteLine($"{CommandShowAllCards}-Показать все карты");
                Console.WriteLine($"{CommandShowMyCards}-Показать мои карты");
                Console.WriteLine($"{CommandExit}-Выйти из программы");

                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case CommandTakeCard:
                        player.TakeCard(deck);
                        break;
                    case CommandShowAllCards:
                        deck.ShowAllCards();
                        break;
                    case CommandShowMyCards:
                        player.ShowPlayerCards();
                        break;
                    case CommandExit:
                        isProgramOn = false;
                        break;
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

    private List<Cards> _cardsOnHand = new List<Cards>();

    public void TakeCard(Deck deck)
    {
        if(deck.TryGetCard(out Cards? cards))
        {
            _cardsOnHand.Add(cards);
            Console.WriteLine("Вы взяли карту");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Закончились карты в колоде");
        }
    }

    public void ShowPlayerCards()
    {
        int minValueCard = 1;

        if (_cardsOnHand.Count >= minValueCard)
        {
            for (int i = 0; i < _cardsOnHand.Count; i++)
            {
                Console.WriteLine($"Карта-{_cardsOnHand[i].Name}.Номинал-{_cardsOnHand[i].Value}");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("У вас сейчас нет карт на руках");
            Console.ReadKey();
        }
    }
}

class Deck
{
    public List<Cards> _cards = new List<Cards> { new Cards("6", "Черви"), new Cards("7", "Черви"), new Cards("8", "Черви"), new Cards("Король", "Черви")};

    public void ShowAllCards()
    {
        Console.Clear();
        Console.WriteLine("Колода карт:");

        for(int i = 0; i < _cards.Count; i++)
        {
            Console.WriteLine($"Карта - {_cards[i].Name}, номинал - {_cards[i].Value}");
        }

        Console.ReadKey();
    }

    public bool TryGetCard(out Cards? cards)
    {
        if(_cards.Count >= 1)
        {
            cards = _cards[^1];
            _cards.Remove(cards);
            return true;
        }
        else
        {
            cards = null;
            Console.WriteLine("Ошибка");
            return false;
        }
    }
}

class Cards
{
    public Cards(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get;  set; }
    public string Value { get;  set; }
}