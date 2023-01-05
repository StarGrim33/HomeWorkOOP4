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
            int cursorPosition = 50;
            Player player = new("Аноним");
            Deck deck = new();

            while (isProgramOn)
            {
                Console.Clear();
                Console.SetCursorPosition(cursorPosition, 0);
                Console.WriteLine($"Игрок - {player.Name}");
                Console.WriteLine($"{CommandTakeCard}-Взять карту");
                Console.WriteLine($"{CommandShowAllCards}-Показать все карты");
                Console.WriteLine($"{CommandShowMyCards}-Показать мои карты");
                Console.WriteLine($"{CommandExit}-Выйти из программы");

                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeCard:
                        player.TakeCard(deck.GiveCard());
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
    public Player(string name)
    {
        Name = name;
        ChangeName();
    }

    public string Name { get; private set; }

    private List<Card> _cardsOnHand = new();

    public void TakeCard(Card card)
    {
        _cardsOnHand.Add(card);
        Console.WriteLine("Вы взяли карту");
        Console.ReadKey();
    }

    public void ShowCards()
    {
        if (_cardsOnHand.Count >= 0)
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

    public void ChangeName()
    {
        Console.WriteLine("Здравствуйте, как Вас зовут?");
        Name = Console.ReadLine();
    }
}

class Deck
{
    public Deck()
    {
        string[] _value = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
        string[] _symbol = { "Черви", "Буби", "Пики", "Кресты" };

        for (int i = 0; i < _symbol.Length; i++)
        {
            for (int j = 0; j < _value.Length; j++)
            {
                _cards.Add(new Card(_value[j], _symbol[i]));
            }
        }
    }

    private Random _random = new();
    private List<Card> _cards = new List<Card>();

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

    public Card GiveCard()
    {
        Card? card = null;

        if (_cards.Count > 0)
        {
            card = _cards[GetNumber()];
            _cards.Remove(card);
        }

        return card;
    }

    private int GetNumber()
    {
        int numberCard = 0;

        if (_cards.Count > 0)
        {
            numberCard = _random.Next(_cards.Count);

        }

        return numberCard;
    }
}

class Card
{
    public Card(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; private set; }
    public string Value { get; private set; }
}