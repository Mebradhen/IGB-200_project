using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour
{

    //public bool fadeOpen;

    [SerializeField]
    GameObject onClickEffect;

    [SerializeField]
    Animator[] animators;

    [SerializeField]
    GameObject hubGameObject;

    public
    float hubCorrectAngle;

    public
    bool rotating;

    [SerializeField]
    float rotationSpeed;

    public GameObject[] miniGames;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerFade()
    {
        foreach (var animator in animators)
            animator.GetComponent<Animator>().SetTrigger("ChangeOpenClose");

    }

    public void TriggerRotationRight()
    {
        hubGameObject.GetComponent<Animator>().SetTrigger("RotateRight");
    }

    public void TriggerRotationLeft()
    {
        hubGameObject.GetComponent<Animator>().SetTrigger("RotateLeft");
    }


    public void PlayEffectOnClick(Transform effectPosition)
    {
        GameObject.Instantiate(onClickEffect, effectPosition);
    }


}
