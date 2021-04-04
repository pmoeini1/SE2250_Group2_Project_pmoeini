using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI : MonoBehaviour
{   
    public Controller2D player1;
　　public GameManager gameManager;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public int damageValue = 1;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Rigidbody coin;
  
    

    public GameObject projectile;

    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } 
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){
            
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0){

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } 
        else {

            timeBtwShots -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider col){
			// damage player if collides with enemy
　　		if (col.gameObject.tag == "Player") {
　　			gameManager.SendMessage("PlayerDamaged",damageValue,SendMessageOptions.DontRequireReceiver);
　　			gameManager.controller2D.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);
　　		}
            if (col.gameObject.tag == "Walls") {
　　			Destroy(gameObject);
　　		}
             if (col.gameObject.tag == "Bullet") {
　　			Destroy(gameObject);
                DropCoin();
　　		}
            if (col.gameObject.tag == "Shield") {
　　			Destroy(gameObject);
                DropCoin();
　　		}
　　	}
      

        void DropCoin(){
			Vector3 coinDrop = transform.position;
			Vector3 offsetH = new Vector3(0.5f,0f,0f);
			Vector3 offsetV = new Vector3(0f,0.5f,0f);
            coinDrop.z = 0f;
            Instantiate (coin, coinDrop, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetH + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop - offsetH + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV * 2, Quaternion.identity);
		}
}
