using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float cameraXOffset = 0f;

    [SerializeField]
    private float cameraYOffset = 5f;

    [SerializeField]
    private float cameraZOffset = 10f;

    [SerializeField]
    private bool shouldFollowPlayer;

    private bool isPlayerTarget => target == null && shouldFollowPlayer;

    // The starting value for the Lerp
    // private float t = 0.0f;
    // private float xMax = 1.0f;
    // private float xMin = -1.0f;
    // private float zMax = 1.0f;
    // private float zMin = -1.0f;

    private float cameraMovementXOffset => target.transform.position.x - transform.position.x;
    private float cameraMovementZOffset => target.transform.position.z - transform.position.z;

    [SerializeField]
    private float cameraMovementDelay = 0.5f;

    [SerializeField]
    private float delayTimer = 0;
    private float cameraXPos => target.transform.position.x - cameraXOffset;
    private float cameraYPos => target.transform.position.y  + cameraYOffset;
    private float cameraZPos => target.transform.position.z - cameraZOffset;


    void Awake()
    {
        if(isPlayerTarget){
            target = GameObject.FindGameObjectWithTag("Player");
        }
        transform.position = new Vector3(cameraXPos, cameraYPos, cameraZPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delayTimer >= cameraMovementDelay){
            delayTimer = 1f;
        }   

        if(transform.position.x != cameraXPos || transform.position.z != cameraZPos){
            delayTimer = 0f;
        }

        delayTimer += cameraMovementDelay * Time.deltaTime;

        float transformX = Mathf.Lerp(transform.position.x, cameraXPos, delayTimer);
        float transformY = cameraYPos;
        float transformZ = Mathf.Lerp(transform.position.z, cameraZPos, delayTimer);

        transform.position = new Vector3(transformX, transformY, transformZ);
    }
}
