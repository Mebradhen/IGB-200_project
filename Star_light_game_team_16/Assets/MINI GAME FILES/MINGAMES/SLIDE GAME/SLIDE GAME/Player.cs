using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float movementSpeed = 1;

    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(-80, 0, 0);
    [SerializeField]
    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<EventController>().miniGame_Start == true)
        {
            GetComponent<Rigidbody>().velocity = transform.up * movementSpeed;

            if (Input.GetButtonDown("Fire2"))
            {
                transform.position = new Vector3(-12, transform.position.y, transform.position.z);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                transform.position = new Vector3(6, transform.position.y, transform.position.z);
            }

            if (Input.GetButtonDown("Fire3"))
            {
                transform.position = new Vector3(24, transform.position.y, transform.position.z);
            }

            if (Input.GetButtonDown("Jump"))
            {
                transform.position = new Vector3(42, transform.position.y, transform.position.z);
            }
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
        if (other.gameObject.tag == "MainStar")
        {
            gameController.GetComponent<EventController>().miniGame_Ended = true;
        }
    }

}
