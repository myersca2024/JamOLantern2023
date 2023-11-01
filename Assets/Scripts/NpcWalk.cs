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
    [SerializeField]float SPEED = 2.0f;
    bool isSad;
    bool isWalking;
    [SerializeField]float WaitingTime = 2;
    float timer;
    
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
        if(isWalking){
            float step = SPEED * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,waypoints[target].transform.position,step);
            float dist = Vector3.Distance(transform.position,waypoints[target].transform.position);
            if (waypoints[target].CompareTag("door") && dist <= 0.001f){
                isWalking = false;
                timer = 0.0f;
            }
            else if (dist <= 0.001f){
                
                GetNextTarget();
            }
        } else {
            if(timer >= WaitingTime){
                isWalking = true;
                GetNextTarget();
            } else {
                timer+=Time.deltaTime;
            }
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
