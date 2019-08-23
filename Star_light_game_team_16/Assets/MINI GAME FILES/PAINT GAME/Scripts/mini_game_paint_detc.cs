using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_game_paint_detc : MonoBehaviour
{

    private int the_check = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public virtual void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ball")
        {
            if(the_check == 0)
            {


                the_check = 1;

                GameObject go = GameObject.Find("Object_detection");

                main_count cs = go.GetComponent<main_count>();

                cs.count += 1; 

            }
        }
    }
}
