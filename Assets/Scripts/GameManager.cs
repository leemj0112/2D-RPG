using UnityEngine;

[System.Serializable]
public class CharterStat
{
    public float Hp = 100f; //체력
    public float Exp = 1f; //경험치
    public float Mp = 100f; //MP
    public float Def = 1f; //방어력
    public int Lv = 1; //레벨
    public int Coin = 1000; //코인
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Define.Player SelectPalyer;
    public string UserID;

    public CharterStat PlayerStat = new CharterStat();

    [HideInInspector] 
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
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectPalyer.ToString());
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