using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveHandler : MonoBehaviour
{

    [SerializeField] ValveMinigame[] spinners;
    [SerializeField] public GameObject light;

    public bool winCon;

    // Start is called before the first frame update
    void Start()
    {
        winCon = false;
    }

    private bool checkAll()
    {

        foreach (ValveMinigame thisOne in spinners)
        {

            if(thisOne.keepSpin == true)
            {

                return false;

            }

        }

        return true;

    }

    // Update is called once per frame
    void Update()
    {

        light.SetActive(winCon);

        if (checkAll())
        {

            winCon = true;

        }

    }
}
