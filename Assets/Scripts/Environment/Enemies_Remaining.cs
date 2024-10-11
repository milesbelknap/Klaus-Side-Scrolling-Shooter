using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemies_Remaining : MonoBehaviour
{
    public float enemiesRemaining;
    public TMP_Text enemiesRemainingText;
    public Player player;

    // Start is called before the first frame update
    public void Start()
    {
        enemiesRemainingText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    public void Update()
    {
        enemiesRemaining = player.killsToWin - player.killCount;
        enemiesRemainingText.text = enemiesRemaining.ToString("0");
    }
}
