using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMsgManager : MonoBehaviour
{
    public static PopupMsgManager instance;
    public Text popupText;
    public float popuptime;

    private GameObject panel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        panel = popupText.transform.parent.parent.gameObject;
    }

    public void ShowPopupMassage(string message)
    {
        panel.SetActive(true);
        popupText.text = message;
        StartCoroutine(HideMessareAfterDelay());

    }

    IEnumerator HideMessareAfterDelay()
    {
        yield return new WaitForSeconds(popuptime);
        popupText.text = "";
        panel.SetActive(false);
    }
}
