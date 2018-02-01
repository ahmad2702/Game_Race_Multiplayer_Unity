using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * @autors Sadullaev A. & Prakhov K.
 * Die Klasse Trigger wurde im Rahmen CG WS17 implementiert.
 */

public class Trigger : MonoBehaviour
{
    /*
     *Referenz auf TextGameObject, wo die Score von Player ausgegeben werden
     */
    public GameObject scoreText;
    /*
     * Constante für die Checkpoint, die für den Gewinn notwendig sind
     */
    private static readonly int MAX_POINTS_SIZE_FOR_FINISH = 4;
    /*
     * List mit der Playersinformation, inkl. Name und Score [Name][Score]
     */
    static List<string[]> players = new List<string[]>();
    /*
     * Der aktuelle Player, der Checkpoint einsammelt
     */
    private string currentPlayer;
    /*
     * Das Zeitlimit für die Generierung des Checkpoints (in Sekunden)
     */
    int cubeLifeTime = 8;
    public static bool gameOver = false;

    /*
     * StartCoroutine
     */
    private void Start()
    {
        StartCoroutine(WaitThenDie());
    }

    /*
     * Zeige Scores auf dem Bildschierm
     */
    private void Update()
    {
        DisplayScoresOnScreen();
    }

    /*
     * Die Generierung von Cubes (Checkpoints)
     */
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(cubeLifeTime);

        string triggerFigureName = gameObject.name;
        if (triggerFigureName.Contains("Cube"))
        {
            // die Random-Generierung an unterschiedlichen Positionen im bestimmten Bereich (innerhalb Terrains)
            float newPosition_X = Random.Range(-475f, 338f);
            float newPosition_Y = gameObject.transform.position.y;
            float newPosition_Z = Random.Range(-340f, 478);

            gameObject.transform.position = new Vector3(newPosition_X, newPosition_Y, newPosition_Z);

            // "create" cube
            GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }

        Start();
    }

    /*
     * Aktion Listener
     */
    void OnTriggerEnter(Collider col)
    {
        currentPlayer = col.transform.parent.parent.name;

        string triggerFigureName = gameObject.name;

        if (!gameOver)
        {
            if (triggerFigureName.Contains("Cube"))
            {

                //  "destroy" cube
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Renderer>().enabled = false;


                // UPDATE 
                UpdatePlayerScore(currentPlayer);

                DisplayScoresOnScreen();

            }

            if (triggerFigureName.Contains("Finish"))
            {
                Gui_Label gui_Label = new Gui_Label();
                float currentTimeOnTimer = gui_Label.GetTimeForPlayers();

                int playerScore = 0;
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i][0].Equals(currentPlayer))
                    {
                        playerScore = System.Int32.Parse(players[i][1]);

                    }
                }


                //wenn der Player 4 Punkte erreicht hat, und das letzte Collectable (=Finish) gesammelt hat
                if (currentTimeOnTimer > 0 && playerScore >= MAX_POINTS_SIZE_FOR_FINISH)
                {
                    gameOver = true;
                    //gui_Label.gameover();
                    scoreText.GetComponent<Text>().text = "WIN: " + currentPlayer + " !";
                }
            }

            if (triggerFigureName.Contains("PlayerStartPosition"))
            {
                DisplayScoresOnScreen();
            }

        }


    }

    /*
     * Die Points bei jedem Player werden initialisiert/updaded/gespeichert
     */
    private void UpdatePlayerScore(string playerName)
    {
        bool playerIsFoundInList = false;

        if (players.Count > 0)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i][0].Equals(playerName))
                {
                    int currentPoints = System.Int32.Parse(players[i][1]);
                    int newPoints = currentPoints + 1;
                    players[i][1] = "" + newPoints;
                    playerIsFoundInList = true;
                }
            }
        }

        if (players.Count == 0 || !playerIsFoundInList)
        {
            CreateNewPlayerWithScore(playerName, 1);
        }
    }

    /*
     * Der neuer Player wird erstellt
     */
    public void CreateNewPlayerWithScore(string playerName, int score)
    {
        string[] data = new string[2];
        data[0] = playerName;
        data[1] = "" + score;
        players.Add(data);

        Debug.Log("Size: " + players.Count + " - " + players[0][0]);
    }

    /*
     * Die Scorespoints werden zurückgesetzt
     */
    public void ResetPlayerScore()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i][1] = "" + 0;
            Debug.Log(players[i][0] + " : " + players[i][1]);
        }
    }

    /*
     * Die Scorespoints werden ausgegeben
     */
    public void DisplayScoresOnScreen()
    {
        string screenText = "";
        for (int i = 0; i < players.Count; i++)
        {
            screenText += players[i][0] + " : " + players[i][1] + "/" + MAX_POINTS_SIZE_FOR_FINISH + " ";
        }
        scoreText.GetComponent<Text>().text = screenText;
    }
    /*
     * Getters
     */
    public GameObject GetTextScreen()
    {
        return scoreText;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    /*
     * Prüefe, ob die Liste null ist
     */
    public bool IsPlayerListNotNull()
    {
        if (players.Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}