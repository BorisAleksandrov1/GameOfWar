using System.ComponentModel.Design.Serialization;

class Game
{
    public static void Main()
    {
        PrintRules();

        List<string> deck = Card.Deck();
        Card.Shuffle(deck);

            List<string> playerOneDeck = PlayerGetDeck(deck, 0, deck.Count() / 2);
            List<string> playerTwoDeck = PlayerGetDeck(deck, deck.Count() / 2, deck.Count());

        int playerOneCardValue = 0;
        int playertwoCardValue = 0;

        int movesCount = 0;

        while(playerOneDeck.Count != deck.Count && playerTwoDeck.Count != deck.Count)
        {
            Console.Clear();
            System.Console.WriteLine($"First player has drawn: {playerOneDeck[0]}");
            System.Console.WriteLine($"Second player has drawn {playerTwoDeck[0]}");

            playerOneCardValue = GetCardValue(playerOneDeck, 0);
            playertwoCardValue = GetCardValue(playerTwoDeck, 0);
            
            if(playerOneCardValue > playertwoCardValue)
            {
                playerOneDeck.Add(playerOneDeck[0]);
                playerOneDeck.Add(playerTwoDeck[0]);
                System.Console.WriteLine("The first player has won the cards!");
            }
            else if(playertwoCardValue > playerOneCardValue)
            {
                playerTwoDeck.Add(playerOneDeck[0]);
                playerTwoDeck.Add(playerTwoDeck[0]);
                System.Console.WriteLine("The second player has won the cards!");
            }
            else
            {
                if(playerOneDeck.Count < 3 || playerTwoDeck.Count < 3)
                {
                    break;
                }
                {
                    War(playerOneDeck,playerTwoDeck); 
                }
            }
            movesCount++;
            playerOneDeck.RemoveAt(0);
            playerTwoDeck.RemoveAt(0);

            System.Console.WriteLine("===========================================================");
            System.Console.WriteLine($"First player currently has {playerOneDeck.Count} cards.");
            System.Console.WriteLine($"Second player currently has {playerTwoDeck.Count} cards.");

            Console.ReadLine();
        }

        string winner = string.Empty;

        if(playerOneDeck.Count > playerTwoDeck.Count)
        {
            winner = "first player";
        }
        else
        {
            winner = "second player";
        }

        System.Console.WriteLine("=============================");
        System.Console.WriteLine($"After a total of {movesCount} moves, the {winner} has won!");
    }

    public static void PrintRules()
    {
        //rules
    }

    public static List<string> PlayerGetDeck(List<string> deck, int StartFromDeckPoss, int EndFromDeckPoss)
        {
            List<string> result = new List<string>();
            {
                for(int i = StartFromDeckPoss; i < EndFromDeckPoss; i++)
                {
                    result.Add(deck[i]);
                }
            }
            return result;
        }

    public static int GetCardValue(List<string> cards, int index)
    {
            string playerTwoCard = cards[index];
            string cardChar = playerTwoCard[0].ToString();

            int cardValue = 0;
                if(!int.TryParse(cardChar, out cardValue))
                {
                    switch(cardChar)
                   {
                    case "J":
                        cardValue = 11;
                        break;
                        case "Q":
                        cardValue = 12;
                        break;
                        case "K":
                        cardValue = 13;
                        break;
                        case "A":
                        cardValue = 14;
                        break;
                   }
                }
            return cardValue;
    }

    public static void War(List<string> deck1, List<string> deck2)
    {
        System.Console.WriteLine("==========================");
        System.Console.WriteLine("Its War Time");

        int playerOneWarValue = GetCardValue(deck1, 4);
        int playerTwoWarValue = GetCardValue(deck2, 4);

        System.Console.WriteLine($"First player has drawn the war card: {deck1[4]}");
        System.Console.WriteLine($"Second player has drawn the war card: {deck2[4]}");

        if(playerOneWarValue > playerTwoWarValue)
        {
            System.Console.WriteLine("The first player has won the cards!");
            for(int i = 0; i < 5; i++)
            {
                
                deck1.Add(deck1[i]);
                deck1.Add(deck2[i]);
            }
        }
        else if(playerTwoWarValue > playerOneWarValue)
        {
            System.Console.WriteLine("The second player has won the cards!");
            for(int i = 0; i < 5; i++)
            {
                deck2.Add(deck1[i]);
                deck2.Add(deck2[i]);
            }
        }
        else
        {
            War(deck1,deck2);
        }
        
        for(int i = 1; i < 5; i++)
            {
                deck1.RemoveAt(i);
                deck2.RemoveAt(i);
            }
    }
}