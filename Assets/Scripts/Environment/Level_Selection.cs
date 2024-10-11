using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selection : MonoBehaviour
{

    int levelsUnlocked;

    public Button[] lvlButtons;

    // Start is called before the first frame update
    public void Start()
    {

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);   

        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if(i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
                lvlButtons[i].interactable = true;
        }

    }
 
}
