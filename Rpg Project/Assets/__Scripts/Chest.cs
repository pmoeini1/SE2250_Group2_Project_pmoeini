using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Controller2D player;
　　public GameManager gameManager;
	public Rigidbody coin;
    public Rigidbody health;
    public Rigidbody diamond;
    float takenDamage = 0.2f;

    public int chestHitPoint = 2;

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

        void ChestDamaged(int damage){
		player.points += 2;
			
　　		if (chestHitPoint > 0) {
　　			chestHitPoint -= damage;		
　　		}
　　
　　		if (chestHitPoint <= 0) {
　　			chestHitPoint = 0;
				DropLoot();
　　			Destroy(gameObject);
				
　　		}
　　	} 

        

        void DropLoot(){
			Vector3 coinDrop = transform.position;
			Vector3 offsetH = new Vector3(1f,0f,0f);
			Vector3 offsetV = new Vector3(0f,1f,0f);
            coinDrop.z = 0f;
            Instantiate (health, coinDrop, Quaternion.identity);
			Instantiate (diamond, coinDrop + offsetH, Quaternion.identity);
			Instantiate (diamond, coinDrop - offsetH, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetH + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop - offsetH + offsetV, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV, Quaternion.identity);
			Instantiate (diamond, coinDrop + offsetV * 2, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV * 2 + offsetH, Quaternion.identity);
			Instantiate (coin, coinDrop + offsetV * 2 - offsetH, Quaternion.identity);
		}


}
