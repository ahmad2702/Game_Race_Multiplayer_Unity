using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUILabel : MonoBehaviour {

     


    public static float timeForPlayers = 60f;



    Text text;
    

     void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        timeForPlayers -= Time.deltaTime;
        if (timeForPlayers < 0)
            timeForPlayers = 60f;

    }
    private void OnGUI()
    {
        GUI.Label(new Rect(200, 15, 150, 25), "Time Left: " + Mathf.Round(timeForPlayers));
    }
}
