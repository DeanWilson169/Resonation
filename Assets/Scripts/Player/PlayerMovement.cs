using System.Timers;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    // Public Properties
    public new Rigidbody rigidbody;
    void Awake()
    {
        if(rigidbody == null){
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        else{
            rigidbody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
