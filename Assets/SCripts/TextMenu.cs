using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMenu : MonoBehaviour {

    Text text;
   
    readonly string menuText = "Herzlich Willkommen zum HTW Rennspiel!\n\nVor dem Start lesen " +
        "Sie bitte die folgenden Regeln:" +
        "\n\n-Verbindungsregeln-\n" +
        "1. Spieler1: Starte den Server mit dem Button 'LAN Host'\n" +
        "2. Spieler2: Gebe im Textfeld 'LAN Client' die IP-Adresse Spieler1 und\nklick mal auf dem Button 'LAN Client'\n" +
        "3. Auf den beiden Rechnern muss der Port '7777' freigeschaltet werden\n" +
        "\n-Spielregeln-\n" +
        "1. Spieler muss vier Collectables einsammeln\n" +
        "2. Nach der Erfüllung der ersten Regel muss man 'Finish-Checkpoint' durchfahren\n" +
        "   Der Player muss durch den doppelten Ring fahren um das Finish-Checkpoint zu erreichen.\n" +
        "3. Für die ersten zwei Aufgaben haben Sie neunzig Sekunden Zeit\n" +
        "4. Sollte die erste drei Aufgaben nicht erfüllt werden,\n" +
        "   wird sowohl die Anzahl des gesammelten Collectables\n" +
        "   als auch das Zeitlimit zurückgesetzt\n\n" +
        " Türkisblaues Checkpoint > Collectable; Orange/Schwarze Wand > Finish";

    Trigger currentGame = new Trigger();

    void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnGUI()
    {
        if (!currentGame.IsPlayerListNotNull())
        {
            GUI.contentColor = Color.black;
            GUI.backgroundColor = Color.black;
            GUI.Label(new Rect(270, 35, 1175, 1575), menuText,"");
        }
        else
        {
            GUI.Label(new Rect(270, 35, 1175, 1575), "", "");
        }
        
        
        

    }

   
}
