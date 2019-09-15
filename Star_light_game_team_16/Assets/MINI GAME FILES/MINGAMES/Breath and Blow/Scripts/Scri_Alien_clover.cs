using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scri_Alien_clover : MonoBehaviour
{
    private Vector3 OG_rotate;

    private float degrees_change = 90.0f;

    public GameObject Alien_breath;

    public GameObject Clover_seed;

    public GameObject[] clover_get;

    private bool check_num = false;

    private float bloow_times = 1.0f;

    public float Max_breath = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        float start_r = -90.0f;

        for (int i = 0; i < 6; i++) {

            var clovers = Instantiate(Clover_seed, new Vector3(transform.position.x + 1.8f + Random.Range(-0.1f, 0.1f), transform.position.y , transform.position.z), transform.rotation * Quaternion.Euler(0f , 0f, start_r));
            clovers.transform.parent = gameObject.transform;

            start_r += 1705.0f * Time.deltaTime; 
        }


      clover_get = GameObject.FindGameObjectsWithTag("Clover");
    }

    // Update is called once per frame
    void Update()
    {
        Scri_Alien_main AB = Alien_breath.GetComponent<Scri_Alien_main>();

        bloow_times = 1f;

        if (gameObject.name == "Clover_obj")
        {
            if (AB.clover_count == 0)
            {
                bloow_times = 7f;
            }
        }
        else if (gameObject.name == "Clover_obj_2")
        {
           if(AB.clover_count == 1)
            {
                bloow_times = 7f;
            }       
        }
        else if (gameObject.name == "Clover_obj_3")
        {
            if (AB.clover_count == 2)
            {
                bloow_times = 7f;
            }
        }

        if (AB.blow == false)
        {
            degrees_change = 90;
        }
        else
        {
            degrees_change = 90 - (AB.Breath_grow * bloow_times);

            if (AB.Breath_grow > Max_breath && check_num == false && bloow_times == 7f)
            {
                Clover_fly();

                check_num = true;

                AB.clover_count += 1;
            }
        }

        Vector3 Ro_move = new Vector3(0, 0, degrees_change);


        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, Ro_move, 3 * Time.deltaTime);
    }

    void Clover_fly()
    {


        for (int ii = 1; ii < this.gameObject.transform.childCount; ii++)
        {
            this.gameObject.transform.GetChild(ii).GetComponent<Scri_Alien_clover_move>().Clover_move = true;
        }
      
    }
}


