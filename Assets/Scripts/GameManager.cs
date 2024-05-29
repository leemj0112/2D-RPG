using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string ChararterName;
    public string UserID;

    public float PlayerHp = 100f;
    public float PlayerExp = 1f;

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
}
