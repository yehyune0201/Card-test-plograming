using UnityEngine;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{
    
    public List<Card> cards = new List <Card>();
    public List<Sprite> sprite = new List <Sprite>();
    private Card firstCard = null;
    private Card secoundCard = null;
    private bool isChecking = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        List<int> pairNumbers = GenerratePairNumbers(cards.Count);  

        for(int i = 0; i < pairNumbers.Count; ++i)
        {
            cards[i].SetCardNumber(pairNumbers[i]);

            cards[i].SetImage(sprite[pairNumbers[i]]);
        }
        for(int i = 0; i < cards.Count; ++i)
        {
            cards[i].isFront = false;
        }
    }
    void CheakCard()
    {
        isChecking = true;

        if(firstCard.number == secoundCard.number)
        {
            
            firstCard.ChangeColor(Color.red);
            secoundCard.ChangeColor(Color.red);

            firstCard.isMatched = true;
            secoundCard.isMatched = true;

            firstCard = null;
            secoundCard = null;
            
            isChecking = false;

        }
        else
        {
            Invoke("HideCard", 1.0f);

        }

    }
    

    public void onClickCard(Card card)
    {
        if(isChecking)
        {
            return;
        }

        if(firstCard == null)
        {
            firstCard = card;
            firstCard.Flip(true);
        }
        else
        {
            secoundCard = card;
            secoundCard.Flip(true);
        }
        if(firstCard != null && secoundCard != null)
        {
            CheakCard();
        }

    }
    void HideCard()
    {
        firstCard.isFront = false;
        secoundCard.isFront = false;

        firstCard.Flip(false);
        secoundCard.Flip(false);

        firstCard = null;
        secoundCard = null;

        isChecking = false;

    }
    // 랜덤
    List<int> GenerratePairNumbers(int cardCount)
    {
        int pairCount = cardCount / 2;
        List<int> newCardNumbers = new List <int>();

        for(int i = 0; i < pairCount; ++i)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }
        for(int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            int temp = newCardNumbers[i];

            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;
        }
        return newCardNumbers;
    }
}
