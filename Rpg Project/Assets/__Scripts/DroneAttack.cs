using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    public Rigidbody drone;
    

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            DropDrones();
        }
    }

    void DropDrones(){
        Vector3 droneDrop = transform.position;
        droneDrop.z = 0;
        droneDrop.y += 5f;
        Vector3 offsetH = new Vector3(0.8f,0f,0f);
        Instantiate(drone, droneDrop, Quaternion.identity);
        Instantiate(drone, droneDrop + offsetH, Quaternion.identity);
        Instantiate(drone, droneDrop - offsetH, Quaternion.identity);
    }
}
