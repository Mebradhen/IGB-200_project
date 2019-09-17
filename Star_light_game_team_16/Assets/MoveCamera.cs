using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField]
    Vector3 directionToMoveCamera;
    GameObject cameraToMove;



    // Start is called before the first frame update
    void Start()
    {
        cameraToMove = Camera.main.gameObject;
    }

    private void OnMouseOver()
    {
        if (directionToMoveCamera.y > 0)
        {
            if (cameraToMove.transform.position.y <= 10)
            {
                cameraToMove.transform.Translate(directionToMoveCamera * Time.deltaTime);
            }

        }
        else
        {
            if (cameraToMove.transform.position.y >= 5.5)
            {
                cameraToMove.transform.Translate(directionToMoveCamera * Time.deltaTime);
            }
        }

        
    }
}
