using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinReturnToMenu : MonoBehaviour
{
    public void ToTheMenuWeGO()
    {
        SceneManager.LoadScene("Menu");
    }
}
