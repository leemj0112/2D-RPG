using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillExplainUI;
    public Image SkiilIamge;
    public Text SkiilText;

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
}
