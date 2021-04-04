using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{   
    public Controller2D player;
    public GameManager gameManager;
    public Rigidbody coin;
    public Rigidbody health;
    
    float coolDown;

    public int damageValue = 1;

    public int shooterHealth = 3;

    float takenDamage = 0.2f;
    
    public bool lookRight = true;

　　public float attackRate = 1.5f;

    public Rigidbody shooterBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        // BulletAttack() when F key is pressed
　　		if (Time.time >= coolDown) 
                {
　　				shooterAttack ();	
　　			}
　　	}

    void OnTriggerEnter(Collider col){
			// damage player if collides with enemy
　　		if (col.gameObject.CompareTag("Player")){
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

    void EnemyDamaged(int damage){
		player.points += 2;
			// destroy enemy if shooterHealth is <=0
　　		if (shooterHealth > 0) {
　　			shooterHealth -= damage;		
　　		}
　　
　　		if (shooterHealth <= 0) {
　　			shooterHealth = 0;
                DropCoin();
                DropHealth();
　　			Destroy(gameObject);
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

    void shooterAttack(){
　　		if (lookRight) {
　　			// shoot right if facing right
　　			Rigidbody bPrefab = Instantiate (shooterBulletPrefab, transform.position, Quaternion.identity)as Rigidbody;
　　			bPrefab.GetComponent<Rigidbody>().AddForce (Vector3.right * 500);
　　			coolDown = Time.time + attackRate;
　　				}
　　		else {
　　			// shoot left if facing left
　　			Rigidbody bPrefab = Instantiate (shooterBulletPrefab, transform.position, Quaternion.identity)as Rigidbody;
　　			bPrefab.GetComponent<Rigidbody>().AddForce (-Vector3.right * 500);
　　			coolDown = Time.time + attackRate;
　　		}
　　	}

    void DropHealth(){
            Vector3 healthDrop = transform.position;
            Vector3 offsetH = new Vector3 (0,1.7f,0);
            healthDrop.z = 0f;
            int chance = Random.Range(1,3);
            if (chance == 1){
            Instantiate(health, healthDrop + offsetH, Quaternion.identity);
            }
        }

    void DropCoin(){
			Vector3 coinDrop = transform.position;
			Vector3 offsetH = new Vector3(0.5f,0f,0f);
			Vector3 offsetV = new Vector3(0f,0.5f,0f);
            coinDrop.z = 0f;
            Instantiate (coin, coinDrop, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetH, Quaternion.identity);
			Instantiate (coin, coinDrop - offsetH, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetH + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop - offsetH + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV * 2, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV * 2 + offsetH, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV * 2 - offsetH, Quaternion.identity);
		}
    
}
