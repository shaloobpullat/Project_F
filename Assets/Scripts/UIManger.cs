using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class UIManger : MonoBehaviour
{  
    
    
    public void OnEasyClick()
    {
        LevelManager.Instance.SetLevel(2, 2);
        SceneManager.LoadScene(2);
    }

    public void OnMediumClick()
    {
        LevelManager.Instance.SetLevel(2, 3);
        SceneManager.LoadScene(2);
    }

    public void OnHardClick()
    {
        LevelManager.Instance.SetLevel(3, 3);
        SceneManager.LoadScene(2);
    }

    public void OnVeryHardClick()
    {
        LevelManager.Instance.SetLevel(4, 4);
        SceneManager.LoadScene(2);
    }
    public void onHomeClick()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToNextLevel()
    {
        int rows =LevelManager.Instance.rows;
        int columns=LevelManager.Instance.columns;
        if (rows == 2 && columns == 2)
        {
            LevelManager.Instance.SetLevel(2, 3);
            SceneManager.LoadScene(2);
        }
        else if (rows == 2 && columns == 3)
        {
            LevelManager.Instance.SetLevel(3, 3);
            SceneManager.LoadScene(2);
        }            
        else if (rows == 3 && columns == 3)
        {
            LevelManager.Instance.SetLevel(4, 4);
            SceneManager.LoadScene(2);
        }           
        else
        {
            Debug.Log("no more level");
        }
    }
    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Levelscene()
    {
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
