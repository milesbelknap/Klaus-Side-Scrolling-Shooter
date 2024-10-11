using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattlePoints : MonoBehaviour
{
    public TMP_Text battlePoints;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        battlePoints = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        battlePoints.text = player.totalBattlePoints.ToString("0");
    }
}
