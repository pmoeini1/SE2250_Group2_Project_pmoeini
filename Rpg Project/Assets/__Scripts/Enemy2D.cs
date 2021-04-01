using UnityEngine;
using System.Collections;
　　
　　public class Enemy2D : MonoBehaviour {
　　	public Controller2D player;
　　	public GameManager gameManager;
		public Rigidbody coin;

　　	
　　	float startPos;
　　	float endPos;
　　	float takenDamage = 0.2f;

　　	public int unitsToMove = 5;
　　	
　　	public int moveSpeed = 2;
　　	
		public int damageValue = 1;

　　	bool moveRight = true;
　　
　　	int enemyHealth = 1;
　　	
　　	public bool basicEnemy;
　　	public bool advancedEnemy;


　　
　　	void Awake(){
			// set up boundaries for horizontal movement
　　		startPos = transform.position.x;
　　		endPos = startPos + unitsToMove;
			// set up small enemy health
　　		if (basicEnemy) {
　　			enemyHealth = 3;		
　　		}
			// set up large enemy health
　　		if (advancedEnemy) {
　　			enemyHealth = 6;		
　　		}
　　	}
　　	
　　	void Update(){
					// move left and right within boundaries
　　		        if (moveRight) {
　　				GetComponent<Rigidbody>().position += Vector3.right * moveSpeed * Time.deltaTime;	
　　				}
　　				if (GetComponent<Rigidbody>().position.x >= endPos) {
　　						moveRight = false;
　　				}
　　				if (moveRight==false) {
　　						GetComponent<Rigidbody>().position -= Vector3.right * moveSpeed * Time.deltaTime;	
　　				}
　　				if (GetComponent<Rigidbody>().position.x <= startPos) {
　　						moveRight = true;
　　				}
　　		}
　　	
　　	
　　	void OnTriggerEnter(Collider col){
			// damage player if collides with enemy
　　		if (col.gameObject.tag == "Player") {
　　			gameManager.SendMessage("PlayerDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
　　			gameManager.controller2D.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
　　		}
			if (col.gameObject.CompareTag("Mine")){
			DropCoin();
            Destroy(col.gameObject);
            Destroy(gameObject);
			player.points += 3;
        	}
　　	}

        
        public IEnumerator TakenDamage(){
			// flash enemy if it takes damage
		    GetComponent<Renderer>().enabled = false;
		    yield return new WaitForSeconds(takenDamage);
		    GetComponent<Renderer>().enabled = true;
		    yield return new WaitForSeconds(takenDamage);
		    GetComponent<Renderer>().enabled = false;
		    yield return new WaitForSeconds(takenDamage);
		    GetComponent<Renderer>().enabled = true;
		    yield return new WaitForSeconds(takenDamage);
		    GetComponent<Renderer>().enabled = false;
		    yield return new WaitForSeconds(takenDamage);
		    GetComponent<Renderer>().enabled = true;
		    yield return new WaitForSeconds(takenDamage);
				
	    } 
　　	
　　	void EnemyDamaged(int damage){
		player.points += 2;
			// destroy enemy if enemyHealth is <=0
　　		if (enemyHealth > 0) {
　　			enemyHealth -= damage;		
　　		}
　　
　　		if (enemyHealth <= 0) {
　　			enemyHealth = 0;
				DropCoin();
　　			Destroy(gameObject);
				
　　		}
　　	}

		void DropCoin(){
			Vector3 coinDrop = transform.position;
            coinDrop.z = 0;
            Instantiate (coin, coinDrop, Quaternion.identity);
		}
　　}
