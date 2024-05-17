using UnityEngine;
using UnityEngine.UI;

public class SelectChange : MonoBehaviour
{

    [Header("Infer")]
    public Text NameTxt;
    public Text FeatureTxttxt;
    public Image Charimage;

    [Header("Charater")]
    public GameObject[] Charcters; //����, �ü�, ������
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

        Debug.Log( $"ĳ���� �ε���: {charindex}");
        Charcters[charindex].SetActive(true);
    }
}
