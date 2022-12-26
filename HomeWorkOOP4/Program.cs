﻿namespace HomeWorkOOP4
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
    private List<Card> _cardsOnHand = new();
    public string Name { get; private set; }

    public Player(string name)
    {
        Name = name;
        SetName();
    }

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

    public void SetName()
    {
        Console.WriteLine("Здравствуйте, как Вас зовут?");
        Name = Console.ReadLine();
    }
}

class Deck
{
    private Random random = new();

    private List<Card> _cards = new List<Card>();

    public Deck()
    {
        _cards.Add(new Card("6", "Черви"));
        _cards.Add(new Card("7", "Черви"));
        _cards.Add(new Card("8", "Черви"));
        _cards.Add(new Card("9", "Черви"));
        _cards.Add(new Card("10", "Черви"));
        _cards.Add(new Card("Валет", "Черви"));
        _cards.Add(new Card("Дама", "Черви"));
        _cards.Add(new Card("Король", "Черви"));
        _cards.Add(new Card("Туз", "Черви"));
        _cards.Add(new Card("6", "Буби"));
        _cards.Add(new Card("7", "Буби"));
        _cards.Add(new Card("8", "Буби"));
        _cards.Add(new Card("9", "Буби"));
        _cards.Add(new Card("10", "Буби"));
        _cards.Add(new Card("Валет", "Буби"));
        _cards.Add(new Card("Дама", "Буби"));
        _cards.Add(new Card("Король", "Буби"));
        _cards.Add(new Card("Туз", "Буби"));
        _cards.Add(new Card("6", "Пики"));
        _cards.Add(new Card("7", "Пики"));
        _cards.Add(new Card("8", "Пики"));
        _cards.Add(new Card("9", "Пики"));
        _cards.Add(new Card("10", "Пики"));
        _cards.Add(new Card("Валет", "Пики"));
        _cards.Add(new Card("Дама", "Пики"));
        _cards.Add(new Card("Король", "Пики"));
        _cards.Add(new Card("Туз", "Пики"));
        _cards.Add(new Card("6", "Кресты"));
        _cards.Add(new Card("7", "Кресты"));
        _cards.Add(new Card("8", "Кресты"));
        _cards.Add(new Card("9", "Кресты"));
        _cards.Add(new Card("10", "Кресты"));
        _cards.Add(new Card("Валет", "Кресты"));
        _cards.Add(new Card("Дама", "Кресты"));
        _cards.Add(new Card("Король", "Кресты"));
        _cards.Add(new Card("Туз", "Кресты"));
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
            numberCard = random.Next(_cards.Count);

        }

        return numberCard;
    }
}

class Card
{
    public string Name { get; private set; }
    public string Value { get; private set; }

    public Card(string name, string value)
    {
        Name = name;
        Value = value;
    }
}