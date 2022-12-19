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
            Deck deck = new();

            while (isProgramOn)
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine($"Игрок - {player.Name}");
                Console.WriteLine($"{CommandTakeCard}-Взять карту");
                Console.WriteLine($"{CommandShowAllCards}-Показать все карты");
                Console.WriteLine($"{CommandShowMyCards}-Показать мои карты");
                Console.WriteLine($"{CommandExit}-Выйти из программы");

                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeCard:
                        player.TakeCard(deck);
                        break;
                    case CommandShowAllCards:
                        deck.ShowAll();
                        break;
                    case CommandShowMyCards:
                        player.ShowCards();
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
    private List<Cards> _cardsOnHand = new();

    public string Name { get; private set; }

    public Player(string name)
    {
        Name = name;
    }

    public void TakeCard(Deck deck)
    {
        if (deck.Remove(out Cards? cards))
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

    public void ShowCards()
    {
        int minValueCard = 1;

        if (_cardsOnHand.Count >= minValueCard)
        {
            Console.WriteLine("Ваши карты:");

            for (int i = 0; i < _cardsOnHand.Count; i++)
            {
                Console.WriteLine($"{_cardsOnHand[i].Name}.Номинал-{_cardsOnHand[i].Value}");
            }
            Console.ReadKey();
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
    public Random random { get; private set; } = new();

    private List<Cards> _cards = new List<Cards>();

    public Deck()
    {
        _cards.Add(new Cards("6", "Черви"));
        _cards.Add(new Cards("7", "Черви"));
        _cards.Add(new Cards("8", "Черви"));
        _cards.Add(new Cards("9", "Черви"));
        _cards.Add(new Cards("10", "Черви"));
        _cards.Add(new Cards("Валет", "Черви"));
        _cards.Add(new Cards("Дама", "Черви"));
        _cards.Add(new Cards("Король", "Черви"));
        _cards.Add(new Cards("Туз", "Черви"));
    }

    public void ShowAll()
    {
        Console.Clear();
        Console.WriteLine("Колода карт:");

        for (int i = 0; i < _cards.Count; i++)
        {
            Console.WriteLine($"Карта - {_cards[i].Name}, номинал - {_cards[i].Value}");
        }

        Console.ReadKey();
    }

    public bool Remove(out Cards? cards)
    {
        if (_cards.Count >= 1)
        {
            cards = _cards[GetNumber()];
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

    private int GetNumber()
    {
        int numberCard = 0;

        if (_cards.Count > 0)
        {
            numberCard = random.Next(_cards.Count);
            return numberCard;
        }
        else
        {
            return numberCard;
        }
    }
}

class Cards
{
    public string Name { get; private set; }
    public string Value { get; private set; }

    public Cards(string name, string value)
    {
        Name = name;
        Value = value;
    }   
}