using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockLevels : MonoBehaviour
{
   

    [SerializeField] Button buttonEasy;
    [SerializeField] Button buttonMedium;
    [SerializeField] Button buttonHard;
    [SerializeField] Button buttonVeryHard;

    [SerializeField] GameObject mediumLockImage;
    [SerializeField] GameObject hardLockImage;
    [SerializeField] GameObject verHardLockImage;

    

    void Start()
    {
        if (!PlayerPrefs.HasKey("IsFirstTime"))
        {
            
            PlayerPrefs.SetInt("medium",0 );          
            PlayerPrefs.SetInt("Hard", 0);
            PlayerPrefs.SetInt("VeryHard", 0);
            PlayerPrefs.SetInt("IsFirstTime", 1); // So it doesn't run again
            PlayerPrefs.Save();
        }
        updateButton();
    }

    public void updateButton()
    {
        buttonEasy.interactable = true;

        buttonMedium.interactable = PlayerPrefs.GetInt("medium", 0) == 1;
        mediumLockImage.SetActive(!buttonMedium.interactable);

        buttonHard.interactable = PlayerPrefs.GetInt("hard", 0) == 1;
        hardLockImage.SetActive(!buttonHard.interactable);

        buttonVeryHard.interactable = PlayerPrefs.GetInt("VeryHard", 0) == 1;
        verHardLockImage.SetActive(!buttonVeryHard.interactable);
    }
    
    
}
