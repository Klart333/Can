using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StatsButton : MonoBehaviour
{
    public void NextSlidePlease()
    {
        SceneManager.LoadScene("StatsScene");
    }
}
