using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kill_Count_Counter : MonoBehaviour
{
    public TMP_Text killCounter;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        killCounter = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        killCounter.text = player.killCount.ToString("0");
    }
}
