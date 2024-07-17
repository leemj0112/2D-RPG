using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectChange : MonoBehaviour
{

    [Header("Infer")]
    public Text NameTxt;
    public Text FeatureTxt;
    public Image Charimage;

    [Header("Charater")]
    public GameObject[] Charcters; //전사, 궁수, 마법사
    public CharacterInfo[] characterInfos;
    private int charindex;

    [Header("GameStart")]
    public GameObject GameStart;
    public Text GameCountTxt;
    private bool isPlayButtonClicked = false;
    private float gameCount = 5f;

    //private static string CharactorName;

    private void Start()
    {
        SetPanelInfo();
    }

    private void Update()
    {
        if (isPlayButtonClicked)
        {
            gameCount -= Time.deltaTime;
            if (gameCount <= 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            GameCountTxt.text = $"곧 게임이 시작됩니다... \n {gameCount:F1}";
        }
    }

    public void PlayBtn()
    {
        GameStart.SetActive(true);
        isPlayButtonClicked = true;
        Define.Player player = (Define.Player)Enum.Parse(typeof(Define.Player), Charcters[charindex].name);
        GameManager.Instance.SelectPalyer= player;
    }

    public void selectCharaterRtn(string btnNase)
    {

        Charcters[charindex].SetActive(false);

        if (btnNase == "Next")
        {
            charindex++;
            charindex = charindex % Charcters.Length;
        }

        if (btnNase == "Prev")
        {
            charindex--;
            charindex = charindex % Charcters.Length;
            charindex = charindex < 0 ? charindex + Charcters.Length : charindex;
        }

        Debug.Log($"캐릭터 인덱스: {charindex}");
        Charcters[charindex].SetActive(true);
        SetPanelInfo();
    }

    private void SetPanelInfo()
    {
        NameTxt.text = characterInfos[charindex].Name;
        FeatureTxt.text = characterInfos[charindex].Feature;
        Charimage.sprite = Charcters[charindex].GetComponent<SpriteRenderer>().sprite;
    }
}
