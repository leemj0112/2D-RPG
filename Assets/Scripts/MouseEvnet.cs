using UnityEngine;

public class MouseEvnet : MonoBehaviour
{
    public GameObject PotionUI;
    public GameObject PowerUI;
    public GameObject BattleUI;

    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "PowerNPC")
                {
                    Debug.Log("PowerNPC ����");
                    PowerUI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "PotionNPC")
                {
                    Debug.Log("PotionNPC ����");
                    PotionUI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "BattleNPC")
                {
                    Debug.Log("BattleNPC ����");
                    BattleUI.SetActive(true);
                }
            }
        }
    }
}
