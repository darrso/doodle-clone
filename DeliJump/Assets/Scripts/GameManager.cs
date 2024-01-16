using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Deli deli;
    private int count;
    public float revorder;
    public TextMeshProUGUI counterTMP;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        count = 0;
        counterTMP.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(deli.transform.position.y * revorder > count)
        {
            count = Convert.ToInt32(deli.transform.position.y * revorder);
            counterTMP.text = count.ToString();
        }
        
    }
}
