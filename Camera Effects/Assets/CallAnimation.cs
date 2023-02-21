using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimation : MonoBehaviour {

    [SerializeField] private GameObject model;
    [SerializeField] private Animator anim;
    private float startTime;
    bool started = false;

    // Use this for initialization
    void Start () {
        anim.Play("idle");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1") && !started)
        {
            anim.Play("idle");
            transform.position = new Vector3(-16.0f, transform.position.y, transform.position.z);
            started = true;
        }

        if (Input.GetKeyDown("4") && !started)
        {
            anim.Play("walk");
            startTime = Time.time;
            started = true;
        }

        if (Input.GetKeyDown("5") && !started)
        {
            anim.Play("idle");
            transform.position = new Vector3(-16.0f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 270.0f, transform.rotation.z);
            started = true;
        }

        if (Input.GetKeyDown("6") && !started)
        {
            anim.Play("idle");
            started = false;
        }

            if (Input.GetKeyDown("7") && !started)
        {
            anim.Play("idle");
            transform.position = new Vector3(-16.0f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 270.0f, transform.rotation.z);
            started = true;
        }

        if (started && transform.position.x < -15.0f)
        {
            float t = Time.time - startTime;

            transform.position = new Vector3(transform.position.x + (t/100),transform.position.y,transform.position.z);
        }
        else if(transform.position.x > -15.0f)
        {
            anim.Play("idle");
        }


    }
}
