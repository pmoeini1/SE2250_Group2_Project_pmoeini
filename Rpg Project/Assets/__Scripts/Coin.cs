using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // set speed that coin chases player
    public float speed; 
    // set up target to chase
    private Transform target;
    // determines if coin chases player
    bool doChase = false;
    
     void Start()
    {
        // make player into target if it has magnet
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z 

        if (doChase){
            Chase();
        }
    }

    void Chase(){
        // move coin towards magnet
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

     void OnTriggerEnter(Collider col){
            // chase magnet　		
            if (col.gameObject.tag == "Magnet") {
　　			doChase = true;
　　		}
     }
}
