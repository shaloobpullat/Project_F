using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int rows ;
    public int columns ;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevel(int r, int c)
    {
        rows = r;
        columns = c;
    }

    public bool GoToNextLevel()
    {
        if (rows == 2 && columns == 2)
            SetLevel(2, 3);     
        else if (rows == 2 && columns == 3) 
            SetLevel(3, 3); 
        else if (rows == 3 && columns == 3)
            SetLevel(4, 4); 
        else return false; 

        return true;
    }
}
