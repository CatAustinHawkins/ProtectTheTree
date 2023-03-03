using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Player;

    public Vector3 TargetPosition;

    public float timer;
    public bool timerbegin;

    public GameObject otherportal;

    private void Update()
    {
        if (timerbegin)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if (timer > 1.5f)
        {
            timerbegin = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(!timerbegin)
        {
            Player.transform.position = TargetPosition;
            otherportal.GetComponent<Portal>().Entered();
        }
        Debug.Log("1");
        
    }

    public void Entered()
    {
        timerbegin = true;

    }
}
