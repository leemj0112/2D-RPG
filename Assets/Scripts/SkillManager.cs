using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillExplainUI;
    public Image SkiilIamge;
    public Text SkiilText;

    public Image[] Skills;
    private float SkillSpeed = 5f;

    public void Explain_SkillBtn(int numder)
    {
        SkillExplainUI.SetActive(true);
        SkiilIamge.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;

        switch (GameManager.Instance.SelectPalyer)
        {
            case Define.Player.Warrior:
                if (numder == 0) SkiilText.text = "전사의 첫 번째 스킬";
                else if (numder == 1) SkiilText.text = "전사의 두 번째 스킬";
                else if (numder == 2) SkiilText.text = "전사의 세 번째 스킬";
                break;
            case Define.Player.Archer:
                if (numder == 0) SkiilText.text = "궁수의 첫 번째 스킬";
                else if (numder == 1) SkiilText.text = "궁수의 두 번째 스킬";
                else if (numder == 2) SkiilText.text = "궁수의 세 번째 스킬";
                break;
            case Define.Player.Mage:
                if (numder == 0) SkiilText.text = "마법사의 첫 번째 스킬";
                else if (numder == 1) SkiilText.text = "마법사의 두 번째 스킬";
                else if (numder == 2) SkiilText.text = "마법사의 세 번째 스킬";
                break;
        }
        Invoke("ExitExplan", 5f);
    }

    private void ExitExplan()
    {
        SkillExplainUI.SetActive(false);
    }
    private void Update()
    {
        SkillUse();
    }
    public void SkillUse()
    {
        if (GameManager.Instance.PlayerStat.Lv >= 5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Skills[0].fillAmount >= 1)
                {
                    GameManager.Instance.PlayerStat.Mp -= 10f;
                    GameManager.Instance.charator.AttackAnimation();

                    GameObject playerPrefab = Resources.Load<GameObject>("Skill/W_SKILL_0");

                    Quaternion rotation = Quaternion.identity;
                    float speed = SkillSpeed;
                    if (GameManager.Instance.player.transform.localScale.x < 0)
                    {
                        rotation = Quaternion.Euler(0, 180, 0);
                        speed = SkillSpeed * -1;
                    }
                    GameObject obj = Instantiate(playerPrefab, GameManager.Instance.player.transform.position, rotation);
                    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
                    Destroy(obj, 5f);

                    StartCoroutine(SkillAmount(0));
                }
            }
        }

        IEnumerator SkillAmount(int SkillIndex)
        {
            Skills[SkillIndex].fillAmount = 0f;
            while (Skills[SkillIndex].fillAmount < 1)
            {
                Skills[SkillIndex].fillAmount += 0.01f;
                yield return new WaitForSeconds(0.05f);
            }
            Skills[SkillIndex].fillAmount = 1;
        }
    }

}
