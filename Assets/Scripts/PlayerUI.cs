using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image Charaterimg;
    public Text IDtext;
    public Text Cointext;
    public Text Dietext;

    public float TimerSecond;
    public float TimerMint;
    public Text TimeTxt;

    public Slider HpSlider;

    public GameObject ClearPanel;

    private GameObject player;

    public GameObject spawnPos;


    void Start()
    {
        IDtext.text = "ID: " + GameManager.Instance.UserID;//���̵� ǥ��
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform); //�÷��̾� ����

    }

    void Update()
    {
        display();
        Cointext.text = "Coin: " + GameManager.Instance.Coin; //���� ���� ǥ��
        Dietext.text = "���� �� ��: " + GameManager.Instance.monsterCount; //���� �� �� ǥ��

        //�÷��� Ÿ�� 
        TimerSecond += Time.deltaTime;
        TimeTxt.text = "Time: " + (int)TimerMint + "�� " + (int)TimerSecond + "��";

        if (TimerSecond >= 60)
        {
            TimerMint++;
            TimerSecond = 0;
        }

        //Ŭ���� �� �̵�

        if (GameManager.Instance.monsterCount <= 0)
        {
            ClearPanel.SetActive(true);
            StartCoroutine(ClearGo());
        }
    }
    IEnumerator ClearGo()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("ClearScene");
    }

    private void display()
    {
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite; //������ ����
        HpSlider.value = GameManager.Instance.PlayerHp; //Hp�� ���
    }

}
