using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject front_Face;
    public GameObject Back_Face;


    public int card_Id;
    public bool isMatched = false;

    private bool isFlipped = false;
    private bool isAnimating = false;
    private GameManager gameManager;
   




    void Start()
    {
        gameManager=FindAnyObjectByType<GameManager>();
        
        front_Face.SetActive(false);
        Back_Face.SetActive(true);

        StartCoroutine(StartShow());


    }
    public void OnCardClicked()
    {
        if (isFlipped || isMatched || isAnimating || gameManager.IsFlippingLocked)
        {
            return;
        }
        StartCoroutine(FlipCard(true));
        gameManager.StoreFlippedCard(this);


    }
    public void FlipBack()
    {
        if (!isFlipped || isMatched || isAnimating)
            return;

        StartCoroutine(FlipCard(false));
    }

    IEnumerator StartShow()
    {
        StartCoroutine(FlipCard(true));
        yield return new WaitForSeconds(3);
        FlipBack();
    }
    IEnumerator FlipCard(bool showFront)
    {
        isAnimating = true;
        float duration = 0.2f;
        float elapsed = 0f;


        Vector3 startScale = transform.localScale;
        Vector3 midScale = new Vector3(0f, startScale.y, startScale.z);
        Vector3 endScale = new Vector3(startScale.x, startScale.y, startScale.z);


        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(startScale, midScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = midScale;

        front_Face.SetActive(showFront);
        Back_Face.SetActive(!showFront);
        isFlipped = showFront;


        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(midScale, endScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;

        isAnimating = false;

    }
    void Update()
    {

    }

}
