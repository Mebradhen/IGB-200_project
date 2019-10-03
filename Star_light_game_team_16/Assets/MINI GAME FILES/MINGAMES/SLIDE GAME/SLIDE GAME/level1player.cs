using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1player : MonoBehaviour

{
    private float speed = 2f;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody>().velocity = transform.up;

        if (Input.GetKeyDown(KeyCode.Q) && transform.position == new Vector3(transform.position.x, transform.position.y, 2))
        {
           // transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
