using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointHandling : MonoBehaviour
{
    private int currentPoint;
    private int maxTurns;
    private int TotalPairs;
    private int comboValue;


    public TextMeshProUGUI pointText;
    public TextMeshProUGUI turnsText;
    public TextMeshProUGUI comboText;
    public GameObject gameWinPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameoverPointText;
    public TextMeshProUGUI gamewinPointText;






    void Start()
    {
        currentPoint = 0;
        comboValue = 1;
        maxTurns = LevelManager.Instance.rows * LevelManager.Instance.columns;
        TotalPairs = (LevelManager.Instance.rows * LevelManager.Instance.columns) / 2;
        UpdatePointText();
        UpdateTurnsText();
        ComboUIUpdate();
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        
    }

    public void checkingGamewin()
    {
        TotalPairs -= 1;
        if(TotalPairs == 0)
        {
            gameWinPanel.SetActive(true);
            gamewinPointText.text = "YOUR POINT IS : " + currentPoint.ToString();
        }
    }
    public void AddingPoints()
    {
        currentPoint += 1*comboValue;
        comboValue++;
    }
    public void SubtractTurns()
    {
        maxTurns -= 1;
        if(maxTurns == 0&&TotalPairs!=0)
        {
            gameOverPanel.SetActive(true);
            gameoverPointText.text="YOUR POINT IS : "+currentPoint.ToString();
        }
    }
    public void UpdatePointText()
    {
        pointText.text = currentPoint.ToString();
    }
    public void UpdateTurnsText()
    {
        turnsText.text= maxTurns.ToString();
    }
    public void ComboUIUpdate()
    {
        comboText.text = comboValue+"x".ToString();
    }
    public void ResetComboValue()
    {
        comboValue = 1;
    }

}
