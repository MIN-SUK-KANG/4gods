using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    public bool isOpen = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void PlayerFindKey()
    {
        isOpen = true;
    }
}
