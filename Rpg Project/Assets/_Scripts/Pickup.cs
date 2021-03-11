using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IPickup
{
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player"){
            Disappear();
        }
        
    }

    public void Disappear(){
        print("Pickup hit");
        Destroy(this.gameObject);
    }
}
