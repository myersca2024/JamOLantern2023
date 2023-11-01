using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class NpcWalk : MonoBehaviour
{
    public GameObject[] waypoints;
    float SPEED = 2.0f;
    bool isSad;
    bool isWalking;
    
    int target;
    // Start is called before the first frame update
    void Start()
    {
        target = UnityEngine.Random.Range(0,waypoints.Length);
        transform.position = waypoints[target].transform.position;
        GetNextTarget();
        
        isSad = false;
        isWalking = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = SPEED * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,waypoints[target].transform.position,step);
        float dist = Vector3.Distance(transform.position,waypoints[target].transform.position);
        if (waypoints[target].CompareTag("door") && dist <= 0.001f){
            isWalking = false;
        }
        else if (dist <= 1){
            
            GetNextTarget();
        }
    }

    void GetNextTarget(){
        target += 1;
        if(target == waypoints.Length){
            target = 0;
        }
    }

    void makeSad(){
        isSad = true;
    }
}
