using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class President : MonoBehaviour
{
    public int no_players = 4;
    public int no_decks = 1;
    public static string[] suits = new string[] { "C","D","H","S" };
    public static string[] values = new string[] {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};

    private List<string> deck;
    private List<List<string>> cards;

    //List<GameObject>[,] Grid = new List<GameObject>[Layers, Width, Height];

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        deck = GenerateDeck();
        deck.ShuffleCards();
        DivideCards();

        foreach (string card in cards[0])
        {
            print(card);
        }
    }

    public List<string> GenerateDeck() {

        List<string> deck = new List<string>();

        for (int i = 0; i < no_decks; i++)
        {
            foreach (string s in suits)
            {
                foreach (string v in values)
                {
                    deck.Add(s + v);
                }
            }
        }
        return deck;
    }

    public void DivideCards()
    {
        cards = new List<List<string>>();

        for (int i=0; i < no_players; i++)
        {
            cards.Add(new List<string>());
        }

        int card_no = 0;

        foreach (string card in deck)
        {
            cards[card_no % no_players].Add(card);
            card_no++;
        }
    }
}
