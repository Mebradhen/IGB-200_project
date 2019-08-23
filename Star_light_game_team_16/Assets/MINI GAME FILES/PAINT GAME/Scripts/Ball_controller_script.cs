using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody2D))]
public class Ball_controller_script : MonoBehaviour
{
    public float speed = 90;

    private Rigidbody2D rb;
    private Vector2 movementVector;

    public GameObject paint_smoge;

    private float paint_wait = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = Vector2.zero;
    }

    void Update()
    {

        if (transform.position.x > 8.0f)
        {
            movementVector.x = -1;
        }
        else if(transform.position.x < -8.0f)
        {
            movementVector.x = 1;
        }
        else
        {
            movementVector.x = Input.GetAxis("Horizontal");
        }


        if (transform.position.y > 6.0f)
        {
            movementVector.y = -1;
        }
        else if (transform.position.y < -2.0f)
        {
            movementVector.y = 1;
        }
        else
        {
            movementVector.y = Input.GetAxis("Vertical");
        }

        paint_wait += 15.0f * Time.deltaTime;

        rb.velocity = movementVector * speed * Time.deltaTime;

        if ((movementVector.x > 0.3f || movementVector.x < -0.3f) || (movementVector.y > 0.3f || movementVector.y < -0.3f))
        { 
            if (paint_wait > 1.0f)
            {

                Instantiate(paint_smoge, transform.position, transform.rotation);

                paint_wait = 0.00f;
            }
         }

 
    }
}
