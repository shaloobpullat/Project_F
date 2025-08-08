using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGridManager : MonoBehaviour
{
    
   [SerializeField] private int rows ;
   [SerializeField] private int columns ;

    public RectTransform cardContainer;
    private GridLayoutGroup grid;
    private SpawnCards spawnCards;

    private void Start()
    {
        rows = LevelManager.Instance.rows;
        columns = LevelManager.Instance.columns;
        spawnCards=FindAnyObjectByType<SpawnCards>();
        grid = cardContainer.GetComponent<GridLayoutGroup>();


        GenerateGrid();
    }

    void GenerateGrid()
    {
        ClearGrid();

        float containerWidth = cardContainer.rect.width;
        float containerHeight = cardContainer.rect.height;

        float spacingX = grid.spacing.x;
        float spacingY = grid.spacing.y;

        float totalSpacingX = spacingX * (columns - 1);
        float totalSpacingY = spacingY * (rows - 1);

        float cellWidth = (containerWidth - totalSpacingX) / columns;
        float cellHeight = (containerHeight - totalSpacingY) / rows;

        grid.cellSize = new Vector2(cellWidth, cellHeight);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = columns;

        spawnCards.Initialize(rows,columns,cardContainer);
    }

    void ClearGrid()
    {
        foreach (Transform child in cardContainer)
        {
            Destroy(child.gameObject);
        }
    }

    // You can call this to update layout during gameplay
    public void SetGridSize(int newRows, int newCols)
    {
        rows = newRows;
        columns = newCols;
        GenerateGrid();
    }
}
