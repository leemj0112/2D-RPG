using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PusBtn : MonoBehaviour
{
    public GameObject PusPanel;

    public void PusClick()
    {
        PusPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameBackBtn()
    {
        PusPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
