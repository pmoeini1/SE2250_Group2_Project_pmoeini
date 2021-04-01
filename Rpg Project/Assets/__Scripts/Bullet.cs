using System.Collections;
using System.Collections.Generic;
using UnityEngine;
　　
　　
　　
　　public class Bullet : MonoBehaviour {
        // Bullet Singleton
        private static Bullet _instance;
        // Bullet property
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
        // set value of damage
　　	int damageValue = 1;
　　
        // handle collisions with enemies
　　	void OnTriggerEnter(Collider other){
　　		if (other.gameObject.tag == "Enemy") {
                GameManager.playersEXP += 20;
　　			Destroy(gameObject);
　　			other.gameObject.SendMessage("EnemyDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
                other.gameObject.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
                
　　		}
            if (other.gameObject.tag == "Chest") {
                GameManager.playersEXP += 50;
　　			Destroy(gameObject);
　　			other.gameObject.SendMessage("ChestDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
                other.gameObject.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
                
　　		}
            // handle collisions with walls
            if (other.gameObject.tag == "Walls") {
            Destroy(gameObject);
            }
　　	}
        // Destroy Bullet once out of screen
　　	void FixedUpdate(){
　　		Destroy (gameObject, 1.25f);
　　	}
　　}