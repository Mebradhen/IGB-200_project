using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scri_Alien_clover_move : MonoBehaviour
{
    public bool Clover_move = false;
    Rigidbody Rigidbody_ye;
    float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody_ye = GetComponent<Rigidbody>();

        Speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Clover_move == true)
        {
            Rigidbody_ye.velocity = transform.right * Speed;

            Vector3 Ro_move = new Vector3(0, 0, 0);

            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, Ro_move, 3 * Time.deltaTime);

              transform.parent = null;
        }
    }
}
