using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string ChararterName;
    public string UserID;

    public float PlayerHp = 100f; //체력
    public float PlayerExp = 1f; //경험치
    public float PlayerMp = 100f; //MP
    public float PlayerDef = 1f; //방어력
    public int Coin = 1000;

    public GameObject player;

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
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return playerPrefab;
    }

    public Charator charator
    {
        get
        {
            return player.GetComponent<Charator>();
        }
    }

    public Attack CharaterAttack
    {
        get
        {
            return charator.AttackObj.GetComponent<Attack>();
        }
    }
}