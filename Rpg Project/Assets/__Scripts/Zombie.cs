using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{   
    public float speed; 
    public float range;
    
    private Transform target;
    public Rigidbody flyer;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < range){
            Chase();
        }

        
    }

    void Chase(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col){
			// damage player if collides with enemy
　　		
            if (col.gameObject.tag == "Mine") {
　　			Destroy(gameObject);
				DropFlyer();
　　		}
			if (col.gameObject.tag == "Shield") {
　　			Destroy(gameObject);
				DropFlyer();
　　		}
             if (col.gameObject.tag == "Bullet") {
　　			Destroy(gameObject);
                DropFlyer();
　　		}
　　	}

        void DropFlyer(){
			Vector3 flyerDrop = transform.position;
            Vector3 offsetH = new Vector3(2f,0f,0f);
            flyerDrop.z = 0f;
            Instantiate (flyer, flyerDrop + offsetH, Quaternion.identity);
            Instantiate (flyer, flyerDrop - offsetH, Quaternion.identity);
		}

}
