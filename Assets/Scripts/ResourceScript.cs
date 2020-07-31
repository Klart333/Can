using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourceScript : MonoBehaviour
{
    public static List<string> resourceStringsCap = new List<string>() { "Wood", "Clay", "Sheep", "Wheat", "Stone" };
    public static List<string> resourceStrings = new List<string>() { "wood", "clay", "sheep", "wheat", "stone" };


    static GameObject resourcePanel;

    private void Start()
    {
        resourcePanel = gameObject;

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("so rn you have " + PlayerScript.activePlayer.stoneAmount + " stone");

            ResourceScript.GiveStone(-1);

            print("yup, just took one, now you have " + PlayerScript.activePlayer.stoneAmount + " stone");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            print("Players Resources: " + PlayerScript.player1.woodAmount + "  " + PlayerScript.player1.clayAmount + "  " + PlayerScript.player1.sheepAmount + "  " + PlayerScript.player1.wheatAmount + "  " + PlayerScript.player1.stoneAmount);
            print("ActivePlayers Resources: " + PlayerScript.activePlayer.woodAmount + "  " + PlayerScript.activePlayer.clayAmount + "  " + PlayerScript.activePlayer.sheepAmount + "  " +  PlayerScript.activePlayer.wheatAmount + "  " + PlayerScript.activePlayer.stoneAmount);
        }
    }
    public static void GiveWood(int amount)
    {
        PlayerScript.activePlayer.woodAmount += amount;
        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.woodAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.woodAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.woodAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.woodAmount += amount;
        }

        resourcePanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.woodAmount.ToString();
    }
    public static void GiveClay(int amount)
    {
        PlayerScript.activePlayer.clayAmount += amount;
        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.clayAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.clayAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.clayAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.clayAmount += amount;
        }

        resourcePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.clayAmount.ToString();
    }
    public static void GiveSheep(int amount)
    {
        PlayerScript.activePlayer.sheepAmount += amount;
        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.sheepAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.sheepAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.sheepAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.sheepAmount += amount;
        }

        resourcePanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.sheepAmount.ToString();
    }
    public static void GiveWheat(int amount)
    {
        PlayerScript.activePlayer.wheatAmount += amount;
        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.wheatAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.wheatAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.wheatAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.wheatAmount += amount;
        }

        resourcePanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.wheatAmount.ToString();
    }
    public static void GiveStone(int amount)
    {
        PlayerScript.activePlayer.stoneAmount += amount;

        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.stoneAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.stoneAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.stoneAmount += amount;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.stoneAmount += amount;
        }
        resourcePanel.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.stoneAmount.ToString();
    }

    #region To all players, called from resourceDividense

    public static void GiveWoodP(int amount, PlayerScript.Player player)
    {
        if (player.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.woodAmount += amount;
        }
        else if (player.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.woodAmount += amount;
        }
        else if (player.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.woodAmount += amount;
        }
        else if (player.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.woodAmount += amount;
        }

        if (PlayerScript.activePlayer.colour == player.colour)
        {
            PlayerScript.activePlayer.woodAmount += amount;
            resourcePanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.woodAmount.ToString();
        }

    }
    public static void GiveClayP(int amount, PlayerScript.Player player)
    {
        if (player.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.clayAmount += amount;
        }
        else if (player.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.clayAmount += amount;
        }
        else if (player.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.clayAmount += amount;
        }
        else if (player.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.clayAmount += amount;
        }

        if (PlayerScript.activePlayer.colour == player.colour)
        {
            PlayerScript.activePlayer.clayAmount += amount;
            resourcePanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.clayAmount.ToString();
        }
    }
    public static void GiveSheepP(int amount, PlayerScript.Player player)
    {

        if (player.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.sheepAmount += amount;
        }
        else if (player.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.sheepAmount += amount;
        }
        else if (player.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.sheepAmount += amount;
        }
        else if (player.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.sheepAmount += amount;
        }

        if (PlayerScript.activePlayer.colour == player.colour)
        {
            PlayerScript.activePlayer.sheepAmount += amount;
            resourcePanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.sheepAmount.ToString();
        }
    }
    public static void GiveWheatP(int amount, PlayerScript.Player player)
    {
        if (player.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.wheatAmount += amount;
        }
        else if (player.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.wheatAmount += amount;
        }
        else if (player.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.wheatAmount += amount;
        }
        else if (player.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.wheatAmount += amount;
        }

        if (PlayerScript.activePlayer.colour == player.colour)
        {
            PlayerScript.activePlayer.wheatAmount += amount;
            resourcePanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.wheatAmount.ToString();
        }
    }
  
    public static void GiveStoneP(int amount, PlayerScript.Player player)
    {
        if (player.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.stoneAmount += amount;
        }
        else if (player.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.stoneAmount += amount;
        }
        else if (player.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.stoneAmount += amount;
        }
        else if (player.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.stoneAmount += amount;
        }

        if (PlayerScript.activePlayer.colour == player.colour)
        {
            PlayerScript.activePlayer.stoneAmount += amount;
            resourcePanel.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = PlayerScript.activePlayer.stoneAmount.ToString();
        }
    }
    #endregion
}
