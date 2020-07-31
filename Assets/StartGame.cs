using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
public class StartGame : MonoBehaviour
{
    public void StartGameButton()
    {
        if (EnterMapSizeScript.mapSizeString == "")
        {
            EnterMapSizeScript.mapSizeString = "12";
        }

        SceneManager.LoadScene("GameScene");

        #region Bot stuff

        for (int i = 4; i > 4 - BotScript.botAmount; i--)
        {
            if (i == 4)
            {
                PlayerScript.player4.isBot = true;
                PlayerScript.player3.isBot = false;
                PlayerScript.player2.isBot = false;
                PlayerScript.player1.isBot = false;
            }
            
            if (i == 3)
            {
                PlayerScript.player3.isBot = true;
                PlayerScript.player2.isBot = false;
                PlayerScript.player1.isBot = false;
            }
            if (i == 2)
            {
                PlayerScript.player2.isBot = true;
                PlayerScript.player1.isBot = false;
            }
            if (i == 1)
            {
                PlayerScript.player1.isBot = true;
                
            }
        }
        #endregion
    }
}
