using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public Vector2 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Jump.onGround == true)
        {            
            movementVector.x = Input.GetAxis("Horizontal");
           
            if (movementVector.x < 0)
            {
                transform.Translate(Vector2.left * Time.deltaTime*3);
            }

            if (movementVector.x > 0)
            {
                transform.Translate(Vector2.right * Time.deltaTime*3);
            }
        }
    }
}
