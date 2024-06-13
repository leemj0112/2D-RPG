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
    public Text Speedtext;
    public Text Attacktext;

    public float TimerSecond;
    public float TimerMint;
    public Text TimeTxt;

    public Slider HpSlider;

    public GameObject ClearPanel;

    private GameObject player;

    public GameObject spawnPos;

    private bool TimerStart = false;


    void Start()
    {
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform); //�÷��̾� ����
        IDtext.text = $"ID: {GameManager.Instance.UserID}";//���̵� ǥ��
        TimerStart = true;

    }
    void Update()
    {
        display();
        Cointext.text = "Coin: " + GameManager.Instance.Coin; //���� ���� ǥ��
        Dietext.text = "���� �� ��: " + GameManager.Instance.monsterCount; //���� �� �� ǥ��
       //Speedtext.text = $"Speed: {GetComponent<Charator>().Speed = 4f}"; //�ӵ� ���
       //Attacktext.text = $"Attack: {GetComponent<Attack>().AttackDamage = 4f}"; //���ݷ�

        //Ÿ�̸� ����
        Timer();

        //Ŭ���� �� �̵�

        if (GameManager.Instance.monsterCount <= 0)
        {
            ClearPanel.SetActive(true);
            StartCoroutine(ClearGo());
            TimerStart = false;
        }


    }
    IEnumerator ClearGo()
    {
        
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("ClearScene");
    }
    //�÷���Ÿ��
    public void Timer()
    {
        if(TimerStart == true)
        TimerSecond += Time.deltaTime;
        TimeTxt.text = "Time: " + (int)TimerMint + "�� " + (int)TimerSecond + "��";

        if (TimerSecond >= 60)
        {
            TimerMint++;
            TimerSecond = 0;
        }
    }

    private void display()
    {
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite; //������ ����
        HpSlider.value = GameManager.Instance.PlayerHp; //Hp�� ���
    }

}
