using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static ScenesManager SceneControl;

    private string NextScene = "00";
    private bool changeScene = true;

    private bool[] SeasonCheck = { false, false, false, false };
    private int[] TreasureChance = { 0, 20, 40, 60, 100 };
    private int CountChange = 0;

    private System.Random random = new System.Random();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneControl = FindAnyObjectByType<ScenesManager>();
    }
    private void Update()
    {
        if (changeScene)
        {
            SceneControl.LoadScene(NextScene);
            CountChange++;
            if (CountChange >= TreasureChance.Length)
            {
                CountChange--;
            }
            if (NextScene == "00")
            {
                CountChange = 0;
            }
            changeScene = false;
        }
    }
    public bool IsTreasureBack(int count)
    {
        return SeasonCheck[count];
    }
    public void SetTreasureBack(int count)
    {
        SeasonCheck[count] = true;
    }

    public void SetNextScene()
    {
        int text = random.Next(1, 17);
        string sceneName;
        if (text < 10)
        {
            sceneName = "0" + text.ToString();
        }
        else
        {
            sceneName = text.ToString();
        }
        NextScene = sceneName;
        changeScene = true;
    }
    public bool IsTreasureChance()
    {
        int chance = random.Next(0, 100);
        Debug.Log(chance);
        Debug.Log(CountChange);
        if (chance < TreasureChance[CountChange])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GetTreasure()
    {
        NextScene = "00";
        changeScene = true;
    }

}
