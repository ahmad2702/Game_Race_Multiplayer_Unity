using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
   /*
    *Die Klasse generiert die Namen
    */
public class PlayerSetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;

    //public GameObject screenText;

    private static int newNumberForPlayer = 1;

    private static Trigger currentGame = new Trigger();

    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
                componentsToDisable[i].enabled = false;
        }

        //transform.name = "Player " + GetComponent<NetworkIdentity>().netId;
        string newPlayerName = "Player " + newNumberForPlayer;
        transform.name = newPlayerName;
        newNumberForPlayer++;

        currentGame.createNewPlayerWithScore(newPlayerName, 0);
        //screenText.GetComponent<Text> ().text = newPlayerName + " : " + 0 + " ";
    }



}
