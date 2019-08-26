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
        //GameObject[] miniGamesTemp;

        //miniGamesTemp = GameObject.FindGameObjectsWithTag("Minigames");

        //for (int i = 0; i < miniGamesTemp.Length; i++)
        //{
        //    for (int j = 0; j < miniGames.Length; j++)
        //    {
        //        if (miniGamesTemp[i] = miniGames[j])
        //        {
        //            break;
        //        }
        //        //miniGamesInScene + miniGamesTemp[i].GetComponent<MiniGameClassSet>()
        //    }
        //}
        //hubCorrectAngle = hubGameObject.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        //tryed to code it, gave up doing it with animations now.

        //if (rotating)
        //{
        //    Vector3 to = new Vector3(0, hubCorrectAngle, 0);
        //    if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
        //    {
        //        hubGameObject.transform.rotation = Quaternion.Lerp(hubGameObject.transform.rotation, Quaternion.Euler(0, hubCorrectAngle, 0), rotationSpeed * Time.time);
        //    }
        //    else
        //    {
        //        transform.eulerAngles = to;
        //        rotating = false;
        //    }
        //}

        
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
