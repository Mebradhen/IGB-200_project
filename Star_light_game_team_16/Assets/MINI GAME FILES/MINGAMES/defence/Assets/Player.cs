using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float movementSpeed = 1;

    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(-80, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.up * movementSpeed;

        if (Input.GetKeyDown(KeyCode.W))
        {
           transform.position = new Vector3(-12, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(24, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(42, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("object collided");
        print("object's tag: " + other.tag);
        if (other.gameObject.tag == "Star")
        {
            print("tag check worked");
            Destroy(other.gameObject);
            movementSpeed += 2;
        }
    }

}
