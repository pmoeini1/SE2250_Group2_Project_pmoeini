using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer2D : MonoBehaviour
{
        public Controller2D player;
　　	public GameManager gameManager;
		public Rigidbody coin;

　　	
　　	float startPos;
　　	float endPos;
　　

　　	public int unitsToMove = 5;
　　	
　　	public int moveSpeed = 2;
　　	
		public int damageValue = 1;

　　	bool moveUp = true;
　　
　　	public int enemyHealth = 1;
　　	


　　
　　	void Awake(){
			// set up boundaries for horizontal movement
　　		startPos = transform.position.y;
　　		endPos = startPos + unitsToMove;
		
　　	}
　　	
　　	void Update(){
					// move up and down within boundaries
　　		        if (moveUp) {
　　				GetComponent<Rigidbody>().position += Vector3.up * moveSpeed * Time.deltaTime;	
　　				}
　　				if (GetComponent<Rigidbody>().position.y >= endPos) {
　　						moveUp = false;
　　				}
　　				if (moveUp==false) {
　　						GetComponent<Rigidbody>().position -= Vector3.up * moveSpeed * Time.deltaTime;	
　　				}
　　				if (GetComponent<Rigidbody>().position.y <= startPos) {
　　						moveUp = true;
　　				}
　　		}
　　	
　　	
　　	

        
        void OnTriggerEnter(Collider col){
			// damage player if collides with enemy
　　		if (col.gameObject.tag == "Player") {
　　			gameManager.SendMessage("PlayerDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
　　			gameManager.controller2D.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
　　		}
            if (col.gameObject.tag == "Mine") {
　　			Destroy(gameObject);
				DropCoin();
　　		}
			if (col.gameObject.tag == "Shield") {
　　			Destroy(gameObject);
				DropCoin();
　　		}
             if (col.gameObject.tag == "Bullet") {
　　			Destroy(gameObject);
                DropCoin();
　　		}
　　	}

		void DropCoin(){
			Vector3 coinDrop = transform.position;
			Vector3 offsetH = new Vector3(0.5f,0f,0f);
            coinDrop.z = 0f;
            Instantiate (coin, coinDrop, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetH, Quaternion.identity);
			Instantiate (coin, coinDrop - offsetH, Quaternion.identity);
		}
}
