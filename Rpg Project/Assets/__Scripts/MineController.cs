using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        // Destroy enemy and mine if they both collide
        if (other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
    }
}
