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
        Debug.Log("���� ����");
    }

    public void ChangeBtn()
    {
        SceneManager.LoadScene("SelectScene");
        Debug.Log("���� ȭ������");
    }

    public void GameMainBtn()
    {
        SceneManager.LoadScene("StartScene");
        Debug.Log("���� ȭ������");
    }

   
}
