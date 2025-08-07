using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    private List<Card> flippedCards = new List<Card>();
    public bool IsFlippingLocked = false;

    

    public void StoreFlippedCard(Card card)
    {
        flippedCards.Add(card);


        if (flippedCards.Count >= 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        Card first = flippedCards[0];
        Card second = flippedCards[1];


        flippedCards.RemoveRange(0, 2);


        yield return new WaitForSeconds(1f);

        if (first.card_Id == second.card_Id)
        {
            first.isMatched = true;
            second.isMatched = true;
            // Play match animation/sound
        }
        else
        {
            first.FlipBack();
            Debug.Log("first");
            second.FlipBack();
            Debug.Log("first");
        }
    }

}
