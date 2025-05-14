using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    private GameManager gameManager;
    private string SceneName;
    private int SceneIndex;
    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            SceneName = SceneManager.GetActiveScene().name;
            int.TryParse(SceneName, out SceneIndex);
            SceneIndex = Mathf.FloorToInt((SceneIndex - 1) / 4);
        }
        CreateCheck();
    }

    public void CreateCheck()
    {
        if ( !gameManager.IsTreasureChance() || gameManager.IsTreasureBack(SceneIndex) )
        {
            gameObject.SetActive(false);
        }
    }

    public void acquire()
    {
        gameManager.SetTreasureBack(SceneIndex);
        gameManager.GetTreasure();
        Destroy(gameObject);
    }
}
