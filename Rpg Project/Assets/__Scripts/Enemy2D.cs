using UnityEngine;
using System.Collections;
　　
　　public class Enemy2D : MonoBehaviour {
　　	
　　	public GameManager gameManager;
　　	
　　	float startPos;
　　	float endPos;
　　	float takenDamage = 0.2f;

　　	public int unitsToMove = 5;
　　	
　　	public int moveSpeed = 2;
　　	
　　	bool moveRight = true;
　　
　　	int enemyHealth = 1;
　　	
　　	public bool basicEnemy;
　　	public bool advancedEnemy;


　　
　　	void Awake(){
　　		startPos = transform.position.x;
　　		endPos = startPos + unitsToMove;
　　
　　		if (basicEnemy) {
　　			enemyHealth = 3;		
　　		}
　　
　　		if (advancedEnemy) {
　　			enemyHealth = 6;		
　　		}
　　	}
　　	
　　	void Update(){
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
　　	
　　
　　	int damageValue = 1;
　　	
　　	void OnTriggerEnter(Collider col){
　　		if (col.gameObject.tag == "Player") {
　　			gameManager.SendMessage("PlayerDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
　　			gameManager.controller2D.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
　　		}
　　	}

        
        public IEnumerator TakenDamage(){
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
　　		if (enemyHealth > 0) {
　　			enemyHealth -= damage;		
　　		}
　　
　　		if (enemyHealth <= 0) {
　　			enemyHealth = 0;
　　			Destroy(gameObject);
　　		}
　　	}
　　}
