using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBtn : MonoBehaviour
{
    public Text IDTextHere;

     private void Start()
    {
        IDTextHere.text = $"ID: { GameManager.Instance.UserID}";
    }

    public void GameExitBtn()
    {
        Application.Quit();
        Debug.Log("게임 꺼짐");
    }

    public void ChangeBtn()
    {
        SceneManager.LoadScene("SelectScene");
        Debug.Log("선택 화면으로");
    }

    public void GameMainBtn()
    {
        SceneManager.LoadScene("StartScene");
        Debug.Log("시작 화면으로");
    }

   
}
