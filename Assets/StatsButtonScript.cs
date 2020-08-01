using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StatsButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool mouseOver = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        GetComponent<Image>().enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        GetComponent<Image>().enabled = false;

    }
    private void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("StatsScene");
        }
    }
}

