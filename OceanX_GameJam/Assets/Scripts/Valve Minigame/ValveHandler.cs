using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ValveHandler : MonoBehaviour
{
    [SerializeField] private ValveMinigame[] spinners;

    [SerializeField] private GameObject _indicatorLight;

    private void Start()
    {
        _indicatorLight.SetActive(false);
    }

    private void Update()
    {
        if (CheckAll())
        { 
            GameManager.Instance.CompleteValveTask();
        }
    }

    private bool CheckAll()
    {
        foreach (ValveMinigame valve in spinners)
        {
            if (valve.keepSpin)
            {
                return false;
            }
        }

        return true;
    }
}