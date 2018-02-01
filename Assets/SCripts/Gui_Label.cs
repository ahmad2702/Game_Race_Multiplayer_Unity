using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    /*
     * Die Klasse Gui_Label rechnet den Timer des Spiels (Zeit)
     */
public class Gui_Label : MonoBehaviour
{
    /*
     * Alle 10 Sekunden wird der Timer zurückgesetzt
     */
    Text text;
    private static readonly float TIMER_IN_SECOND = 90f;
    public static float currentTimeOnScreen = TIMER_IN_SECOND;
    private Trigger currentGame = new Trigger();


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (!currentGame.IsGameOver())
        {
            currentTimeOnScreen -= Time.deltaTime;
            if (currentTimeOnScreen < 0)
            {
                currentTimeOnScreen = TIMER_IN_SECOND;
                currentGame.ResetPlayerScore();
            }
        }
    }

    /*
     * Die Platzierung des Timers. Und die Anzeigefunktion.
     */
    private void OnGUI()
    {
        if (!currentGame.IsGameOver())
        {
            GUI.Label(new Rect(200, 15, 150, 25), "Time Left: " + Mathf.Round(currentTimeOnScreen));
        }
        else
        {
            GUI.Label(new Rect(200, 15, 150, 25), "Time Left: GAME OVER");
        }

    }



    public float GetTimeForPlayers()
    {
        return currentTimeOnScreen;
    }



}
