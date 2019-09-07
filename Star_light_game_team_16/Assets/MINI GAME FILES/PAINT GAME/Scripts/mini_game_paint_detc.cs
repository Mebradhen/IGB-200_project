using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_game_paint_detc : MonoBehaviour
{

    private int the_check = 0;

    public GameObject paint_green;

    public GameObject paint_red;

    public GameObject paint_blue;

    private GameObject the_object_out;

    void Start()
    {
        if (transform.parent.tag == "Dc_green")
        {
            the_object_out = paint_green;
        }

        if (transform.parent.tag == "Dc_blue")
        {
            the_object_out = paint_blue;
        }

        if (transform.parent.tag == "Dc_red")
        {
            the_object_out = paint_red;
        }

        Instantiate(the_object_out, new Vector3(transform.position.x, transform.position.y, transform.position.z-1.0f), transform.rotation);
    }

    public virtual void OnTriggerEnter(Collider other)
    {

        if (the_check == 0)
        {
            if (other.tag == "Paint_red" && transform.parent.tag == "Dc_red")
        {
                the_check = 1;

                GameObject go = GameObject.Find("Object_detection");

                main_count cs = go.GetComponent<main_count>();

                cs.count += 1;

            }

            if (other.tag == "Paint_blue" && transform.parent.tag == "Dc_blue")
        {
                the_check = 1;

                GameObject go = GameObject.Find("Object_detection");

                main_count cs = go.GetComponent<main_count>();

                cs.count += 1;

            }

            if (other.tag == "Paint_green" && transform.parent.tag == "Dc_green")
        {
                the_check = 1;

                GameObject go = GameObject.Find("Object_detection");

                main_count cs = go.GetComponent<main_count>();

                cs.count += 1;

            }

        }
        
    }
}


