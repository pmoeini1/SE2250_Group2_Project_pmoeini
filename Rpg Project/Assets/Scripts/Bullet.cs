using System.Collections;
using System.Collections.Generic;
using UnityEngine;
　　
　　
　　
　　public class Bullet : MonoBehaviour {
　　
　　	int damageValue = 1;
　　

　　	void OnTriggerEnter(Collider other){
　　		if (other.gameObject.tag == "Enemy") {
　　			Destroy(gameObject);
　　			other.gameObject.SendMessage("EnemyDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
　　		}
　　	}
　　
　　	void FixedUpdate(){
　　		Destroy (gameObject, 1.25f);
　　	}
　　}