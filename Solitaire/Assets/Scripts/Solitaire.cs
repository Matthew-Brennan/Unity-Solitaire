using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solitaire : MonoBehaviour
{
    
    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public static string[] suits = new string[] {"C", "D", "H", "S"};
    public static string[] value = new string[] {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};

    public List<string> deck;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        deal();
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in value)
            {
                newDeck.Add(s + v); 
            }
        }
        return newDeck;
    }

    //Fisher-Yates shuffle
    public static void Shuffle<T>(List<T> list)  
    {  
        
        System.Random random = new System.Random();
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = random.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }


    void deal()
    {
        float yOffset = 0.1f;
        float zOffset = 0.03f;

        foreach (string card in deck)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3 (transform.position.x, transform.position.y - yOffset, transform.position.z - zOffset), Quaternion.identity);
            newCard.name = card;
            newCard.GetComponent<Playable>().faceUp = true;

            yOffset = yOffset + 0.3f;
            zOffset = zOffset + 0.03f;
        }
    }
}
