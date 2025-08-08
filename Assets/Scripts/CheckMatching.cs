using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CheckMatching : MonoBehaviour
{
    

    private List<Card> flippedCards = new List<Card>();
    public bool IsFlippingLocked = false;
   
    public UnityEvent onCardsMatched;
    public UnityEvent onCardsNotMatched;

   



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
        string firstImageName = first.front_Face.GetComponent<UnityEngine.UI.Image>().sprite.name;
        string secondImageName = second.front_Face.GetComponent<UnityEngine.UI.Image>().sprite.name;


        flippedCards.RemoveRange(0, 2);


        yield return new WaitForSeconds(1f);

        if (firstImageName == secondImageName)
        {
            first.isMatched = true;
            second.isMatched = true;

            onCardsMatched?.Invoke();

            

            // Play match animation/sound
        }
        else
        {
            first.FlipBack();
            second.FlipBack();

            onCardsNotMatched?.Invoke();
        }
    }

}
