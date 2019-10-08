using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRight : MonoBehaviour
{
    public float x = 10f;
    public float y = 0.1f;
    public float z = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(x, y, z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("object collided");
        print("object's tag: " + other.tag);
        if (other.gameObject.tag == "Enemy")
        {
            print("tag check worked");
            Destroy(other.gameObject);

        }
    }
}