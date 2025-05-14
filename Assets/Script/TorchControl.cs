using UnityEngine;

public class TorchControl : MonoBehaviour
{
    public static GameManager MasterControl;

    [SerializeField] private int Season;
    private int torchSeason;

    [SerializeField] private GameObject torchOn;
    [SerializeField] private GameObject torchOff;

    private void Start()
    {
        MasterControl = GameManager.Instance;
        torchSeason = Season;
    }
    private void Update()
    {
        if (MasterControl.IsTreasureBack(torchSeason))
        {
            torchOn.SetActive(true);
            torchOff.SetActive(false);
        }
        else
        {
            torchOn.SetActive(false);
            torchOff.SetActive(true);
        }
    }

}