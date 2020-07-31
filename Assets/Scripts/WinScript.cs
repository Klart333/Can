using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinScript : MonoBehaviour
{
    public static void Win()
    {
        GameObject winPanel = Instantiate((GameObject)Resources.Load("UI/Win/WinPanel"), GameObject.Find("Canvas").transform);
        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player 1";
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = Color.red;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player 2";
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = Color.blue;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player 3";
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = Color.green;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Player 4";
            winPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = Color.yellow;
        }
        GameObject.Find("BuyPanel").SetActive(false);
        GameObject.Find("CandlePanel").SetActive(false);

        PlayerPrefs.SetInt("wins", PlayerPrefs.GetInt("wins") + 1);

    }
}
