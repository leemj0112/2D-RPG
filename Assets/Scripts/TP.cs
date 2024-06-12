using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TP : MonoBehaviour
{
    public Transform Tatget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = Tatget.position;
            Debug.Log("텔레포트");
        }
    }
}
