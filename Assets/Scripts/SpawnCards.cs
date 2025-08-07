using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class SpawnCards : MonoBehaviour
{
    public GameObject cardPrefab;
    [SerializeField] Sprite[] sprites;
    List<Sprite> spritesList;
    private int rows=2;
    private int columns=2;
    public void Initialize(int _rows, int _columns, RectTransform container)
    {
        rows = _rows;
        columns = _columns;

        SpriteSelection();
        CardSpawn(container);
    }
    public void SpriteSelection()
    {
        spritesList = new List<Sprite>();
        int totalCards = rows * columns;
        for(int i = 0; i < totalCards/2; i++)
        {
            spritesList.Add(sprites[i]);
            spritesList.Add(sprites[i]);
        }
        ShuffleCards(spritesList);

    }
    public void ShuffleCards(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }
    public void CardSpawn(RectTransform CardContainer)
    {
        
        for( int i = 0;i < spritesList.Count; i++)
        {
           GameObject card= Instantiate(cardPrefab, CardContainer);
           Image frontSprite=card.transform.Find("ImageFront").GetComponent<Image>();
            if(frontSprite != null)
            {
                frontSprite.sprite = spritesList[i];
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
