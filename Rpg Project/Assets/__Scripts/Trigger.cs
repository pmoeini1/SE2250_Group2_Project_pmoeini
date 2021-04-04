using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Rigidbody spawnItem;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player") {
				spawn();
        }
    }

    void spawn(){
			Vector3 triggerLocation = transform.position;
            Vector3 offSetV = new Vector3(0f, 1f, 0f);
            triggerLocation.z = 0f;
            Instantiate (spawnItem, triggerLocation + offSetV, Quaternion.identity);
    }
}
