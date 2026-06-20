using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class ValveMinigame : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] public GameObject back;
    [SerializeField] public GameObject spinner;
    [SerializeField] public float speed = 3.0f;
    [SerializeField] public int hitBox = 15;

    public bool keepSpin;

    // Start is called before the first frame update
    void Start()
    {
        keepSpin = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (keepSpin)
        {

            spinner.transform.Rotate(0,0,Time.deltaTime * speed);

        }   

    }

    public void OnPointerClick(PointerEventData eventData) {

        //Debug.Log("Item clicked");

        if(spinner.transform.eulerAngles.z > (back.transform.eulerAngles.z - hitBox) && spinner.transform.eulerAngles.z < (back.transform.eulerAngles.z + hitBox))
        {

            Debug.Log("Clicked on time");

            keepSpin = false;

        }
    
    }

}
