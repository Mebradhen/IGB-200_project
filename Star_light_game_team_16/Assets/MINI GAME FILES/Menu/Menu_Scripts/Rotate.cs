using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    [SerializeField]
    Vector3 rotate = new Vector3(0, 0, 0);
    [SerializeField]
    float range = 0;

    // Start is called before the first frame update
    void Start()
    {
        range = range / 2;
        if (rotate.x != 0)
            rotate.x = Random.Range(rotate.x - range, rotate.x + range);
        if (rotate.y != 0)
            rotate.y = Random.Range(rotate.y - range, rotate.y + range);
        if (rotate.z != 0)
            rotate.z = Random.Range(rotate.z - range, rotate.z + range);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotate);
    }
}
