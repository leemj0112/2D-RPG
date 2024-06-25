using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject DialogueUI;

    private GameObject PlayerObj;
    private float distance;

    public GameObject[] DialogueTextObj;
    private int dindex = 0;

    private void Update()
    {
        if (PlayerObj == null) PlayerObj = GameManager.Instance.player;
        if (PlayerObj == null) return;

        distance = Vector2.Distance(transform.position, PlayerObj.transform.position);
        Debug.Log($"distance:{distance}");

        if(distance <= 3)
            DialogueUI.SetActive(true);
        else 
            DialogueUI.SetActive(false);
    }

    public void NextBtn(string name)
    {
        DialogueTextObj[dindex].SetActive(false);
        if(name == "Next")
        {
            if (dindex < DialogueTextObj.Length - 1) dindex++;
        }
        else if(name =="Prev")
        {
            if (dindex > 0) dindex--;    
        }
        DialogueTextObj[dindex].SetActive(true);
    }

    public void TownBtn()
    {
        SceneManager.LoadScene("TownScene");
    }
}
