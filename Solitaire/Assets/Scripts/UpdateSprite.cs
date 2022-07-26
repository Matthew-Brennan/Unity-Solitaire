using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Playable playable;
    private Solitaire solitaire;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Solitaire.GenerateDeck();
        solitaire = FindObjectOfType<Solitaire>();
        int i = 0;
        foreach (string card in deck)
        {
            
            if (this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        playable = GetComponent<Playable>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
        
    }
}
