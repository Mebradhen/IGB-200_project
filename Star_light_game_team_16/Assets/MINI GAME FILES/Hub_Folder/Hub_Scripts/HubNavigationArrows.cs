using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubNavigationArrows : MonoBehaviour
{
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    GameObject hubController;

    [SerializeField]
    bool rotatingLeft;


    // Start is called before the first frame update
    void Start()
    {
        hubController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        HubController HC = hubController.GetComponent<HubController>();

        //if (HC.rotating != true)
        //{
        //    HC.hubCorrectAngle += amountToRotate;
        //    HC.rotating = true;
        //}

        if (rotatingLeft)
        {
            HC.TriggerRotationLeft();
        }
        else
        {
            HC.TriggerRotationRight();
        }
            
    }
}
