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
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform); //플레이어 스폰
        IDtext.text = $"ID: {GameManager.Instance.UserID}";//아이디 표시
        TimerStart = true;

    }
    void Update()
    {
        display();
        Cointext.text = "Coin: " + GameManager.Instance.Coin; //코인 개수 표시
        Dietext.text = "남은 적 수: " + GameManager.Instance.monsterCount; //남은 적 수 표시
       //Speedtext.text = $"Speed: {GetComponent<Charator>().Speed = 4f}"; //속도 기록
       //Attacktext.text = $"Attack: {GetComponent<Attack>().AttackDamage = 4f}"; //공격력

        //타이머 시작
        Timer();

        //클리어 후 이동

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
    //플레이타임
    public void Timer()
    {
        if(TimerStart == true)
        TimerSecond += Time.deltaTime;
        TimeTxt.text = "Time: " + (int)TimerMint + "분 " + (int)TimerSecond + "초";

        if (TimerSecond >= 60)
        {
            TimerMint++;
            TimerSecond = 0;
        }
    }

    private void display()
    {
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite; //프로필 사진
        HpSlider.value = GameManager.Instance.PlayerHp; //Hp바 기록
    }

}
