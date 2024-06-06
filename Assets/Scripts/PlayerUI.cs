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
        IDtext.text = "ID: " + GameManager.Instance.UserID;//아이디 표시
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform); //플레이어 스폰

    }

    void Update()
    {
        display();
        Cointext.text = "Coin: " + GameManager.Instance.Coin; //코인 개수 표시
        Dietext.text = "남은 적 수: " + GameManager.Instance.monsterCount; //남은 적 수 표시

        //플레이 타임 
        TimerSecond += Time.deltaTime;
        TimeTxt.text = "Time: " + (int)TimerMint + "분 " + (int)TimerSecond + "초";

        if (TimerSecond >= 60)
        {
            TimerMint++;
            TimerSecond = 0;
        }

        //클리어 후 이동

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
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite; //프로필 사진
        HpSlider.value = GameManager.Instance.PlayerHp; //Hp바 기록
    }

}
