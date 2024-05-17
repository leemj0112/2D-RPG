using UnityEngine;
using UnityEngine.UI;

public class SelectChange : MonoBehaviour
{

    [Header("Infer")]
    public Text NameTxt;
    public Text FeatureTxttxt;
    public Image Charimage;

    [Header("Charater")]
    public GameObject[] Charcters; //전사, 궁수, 마법사
    private int charindex;

    public void seectCharaterRtn(string btnNase)
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

        Debug.Log( $"캐릭터 인덱스: {charindex}");
        Charcters[charindex].SetActive(true);
    }
}
