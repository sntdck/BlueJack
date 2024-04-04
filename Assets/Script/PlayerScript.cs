using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CardScript cardScript;
    public DeckScript deckScript;

    public int handValue = 0;

    private int money = 2000;

    public GameObject[] hand;
    public int cardIndex = 0;
    List<CardScript> aceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    public int GetCard()
    {
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        handValue += cardValue;
        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        AceCheck();
        cardIndex++;
        return handValue;
    }

    public void AceCheck()
    {
        foreach (CardScript ace in aceList)
        {
            if (handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                ace.SetValue(11);
                handValue += 10;
            }
            else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }

    public void AdjustMoney(int amount)
    {
        money += amount;
    }

    public int GetMoney()
    {
        return money;
    }

    public void ResetHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<CardScript>();
    }
    /*
    public void GetHandValue()
    {
        int cardValue = 10;

        if (cardValue == 10)
        {
            hand[cardIndex].GetComponent<Renderer>().enabled = true;
            cardScript.SetValue(cardValue);
            deckScript.GetSpriteByValue(cardValue);
            deckScript.GetCardValueByNumber(cardValue);
            handValue += cardValue;
            cardIndex++;
        }

    }
    public void GetHandValue1()
    {
            int cardValue1 = 8;
                if (cardValue1 == 8)
                {
                    hand[cardIndex].GetComponent<Renderer>().enabled = true;
                    cardScript.SetValue(cardValue1);
                    deckScript.GetSpriteByValue(cardValue1);
                    deckScript.GetCardValueByNumber( cardValue1);
                    handValue += cardValue1;
                    cardIndex++;
                }
    }*/
}
