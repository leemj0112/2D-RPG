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
                if (numder == 0) SkiilText.text = "������ ù ��° ��ų";
                else if (numder == 1) SkiilText.text = "������ �� ��° ��ų";
                else if (numder == 2) SkiilText.text = "������ �� ��° ��ų";
                break;
            case Define.Player.Archer:
                if (numder == 0) SkiilText.text = "�ü��� ù ��° ��ų";
                else if (numder == 1) SkiilText.text = "�ü��� �� ��° ��ų";
                else if (numder == 2) SkiilText.text = "�ü��� �� ��° ��ų";
                break;
            case Define.Player.Mage:
                if (numder == 0) SkiilText.text = "�������� ù ��° ��ų";
                else if (numder == 1) SkiilText.text = "�������� �� ��° ��ų";
                else if (numder == 2) SkiilText.text = "�������� �� ��° ��ų";
                break;
        }
        Invoke("ExitExplan", 5f);
    }

    private void ExitExplan()
    {
        SkillExplainUI.SetActive(false);
    }
}
