using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    Vector3 lookOffset;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = mainCamera.transform.position - this.transform.position;

        Vector3 newDir = Vector3.RotateTowards(this.transform.forward+lookOffset, targetDir, 10, 10);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
