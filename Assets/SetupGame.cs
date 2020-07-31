using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupGame : MonoBehaviour
{
    public void OnButtonP()
    {
        SceneManager.LoadScene("GameSetup");
    }
}

