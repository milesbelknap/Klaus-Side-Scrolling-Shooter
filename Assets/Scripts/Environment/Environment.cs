using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Environment : MonoBehaviour
{
    public TMP_Text healthPercentage;
    public Player player;

    void Awake()
    {
        healthPercentage = GetComponent<TMP_Text>();
    }

    void Update()
    {
        healthPercentage.text = player.health.ToString("0");
    }
}
