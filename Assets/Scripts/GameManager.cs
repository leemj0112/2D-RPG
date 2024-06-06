using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string ChararterName;
    public string UserID;

    public float PlayerHp = 100f; //체력
    public float PlayerExp = 1f; //경험치

    public int Coin = 0; //코인
    public int monsterCount; //남은 적 수

    public GameObject ClearPanel;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance! == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }
    void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

    void Update()
    {
        
    }

 
    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + GameManager.Instance.ChararterName);
        GameObject player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return playerPrefab;
    }
}