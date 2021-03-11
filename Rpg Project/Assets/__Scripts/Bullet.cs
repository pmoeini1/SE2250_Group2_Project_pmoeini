using System.Collections;
using System.Collections.Generic;
using UnityEngine;
　　
　　
　　
　　public class Bullet : MonoBehaviour {

        private static Bullet _instance;

        public static Bullet Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<Bullet>();
                }

                return _instance;
            }
        }
　　
　　	int damageValue = 1;
　　

　　	void OnTriggerEnter(Collider other){
　　		if (other.gameObject.tag == "Enemy") {
　　			Destroy(gameObject);
　　			other.gameObject.SendMessage("EnemyDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
                other.gameObject.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
                
　　		}
            if (other.gameObject.tag == "Walls") {
            Destroy(gameObject);
            }
　　	}
　　
　　	void FixedUpdate(){
　　		Destroy (gameObject, 1.25f);
　　	}
　　}