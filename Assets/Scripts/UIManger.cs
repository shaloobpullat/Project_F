using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class UIManger : MonoBehaviour
{  
    
    public static UIManger Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void OnEasyClick()
    {
        LevelManager.Instance.SetLevel(2, 2);
        SceneManager.LoadScene(1);
    }

    public void OnMediumClick()
    {
        LevelManager.Instance.SetLevel(2, 3);
        SceneManager.LoadScene(1);
    }

    public void OnHardClick()
    {
        LevelManager.Instance.SetLevel(3, 3);
        SceneManager.LoadScene(1);
    }

    public void OnVeryHardClick()
    {
        LevelManager.Instance.SetLevel(4, 4);
        SceneManager.LoadScene(1);
    }
    public void onHomeClick()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToNextLevel()
    {
        int rows =LevelManager.Instance.rows;
        int columns=LevelManager.Instance.columns;
        if (rows == 2 && columns == 2)
        {
            LevelManager.Instance.SetLevel(2, 3);
            SceneManager.LoadScene(1);
        }
        else if (rows == 2 && columns == 3)
        {
            LevelManager.Instance.SetLevel(3, 3);
            SceneManager.LoadScene(1);
        }            
        else if (rows == 3 && columns == 3)
        {
            LevelManager.Instance.SetLevel(4, 4);
            SceneManager.LoadScene(1);
        }           
        else
        {
            Debug.Log("no more level");
        }


        


    }
}
