using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class UIManger : MonoBehaviour
{  
    
    
    public void OnEasyClick()
    {
        AudioManager.Instance.PlayButtonClick();
        LevelManager.Instance.SetLevel(2, 2);
        SceneManager.LoadScene(2);
        
    }

    public void OnMediumClick()
    {
        AudioManager.Instance.PlayButtonClick();
        LevelManager.Instance.SetLevel(2, 3);
        SceneManager.LoadScene(2);
    }

    public void OnHardClick()
    {
        AudioManager.Instance.PlayButtonClick();
        LevelManager.Instance.SetLevel(4, 5);
        SceneManager.LoadScene(2);
    }

    public void OnVeryHardClick()
    {
        AudioManager.Instance.PlayButtonClick();
        LevelManager.Instance.SetLevel(5, 5);
        SceneManager.LoadScene(2);
    }
    public void onHomeClick()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene(1);
    }
    public void GoToNextLevel()
    {
        AudioManager.Instance.PlayButtonClick();
        int rows =LevelManager.Instance.rows;
        int columns=LevelManager.Instance.columns;
        if (rows == 2 && columns == 2)
        {
            LevelManager.Instance.SetLevel(2, 3);
            SceneManager.LoadScene(2);
        }
        else if (rows == 2 && columns == 3)
        {
            LevelManager.Instance.SetLevel(4, 5);
            SceneManager.LoadScene(2);
        }            
        else if (rows == 4 && columns == 5)
        {
            LevelManager.Instance.SetLevel(5, 5);
            SceneManager.LoadScene(2);
        }           
        else
        {
            Debug.Log("no more level");
        }
    }
    public void ResetGameData()
    {
        AudioManager.Instance.PlayButtonClick();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        AudioManager.Instance.PlayButtonClick();
        Application.Quit();
    }
    public void Levelscene()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene(0);
    }
}
