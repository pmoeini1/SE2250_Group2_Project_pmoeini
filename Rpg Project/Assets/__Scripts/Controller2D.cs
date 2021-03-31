    using UnityEngine;
　　using System.Collections;
    
　　
　　public class Controller2D : MonoBehaviour, IController2D {
        
        // points counter
        public int points;
        // number of enemy collisions
        public int hitsTaken = 0;
        // particle system
        public ParticleSystem dust;
　　	//Reference to the chracterController 
　　	CharacterController characterController;
　　	//For changing how fast the player fall( less gravity = jump higher + longer)
　　	public float gravity = 10;
　　	//For changing the speed of the player 
　　	public float walkSpeed = 5;
　　	//For changing how high the player could jump
　　	public float jumpHeight = 5;
　　	//How long the player is invulnerable for after taken damage
　　	float takenDamage = 0.2f;
        //Refrence to the bullet prefab
        public Rigidbody bulletPrefab;
        //referece to mine prefab
        public Rigidbody mine;
        //reference to player object
        public Transform player;
        //the direction the player is moving toward
　　	Vector3 moveDirection = Vector3.zero;
　　	float horizontal = 0;
        //how fast the player attacks
　　	float attackRate = 0.5f;
　　	float coolDown;
　　	bool lookRight = true;
        bool custom = false;
　　	
　　	void Start () {
　　		characterController = GetComponent<CharacterController>();
            custom = false;
            points = 0;
            Debug.Log(points);
　　	}
　　	
　　	
　　	void Update () {
            Debug.Log("Points: " + points.ToString());
            //Transforms the scaling of the character 
            Vector3 characterScale = transform.localScale;
　　		// set up horizontal player movement
　　		characterController.Move (moveDirection * Time.deltaTime);
　　		horizontal = Input.GetAxis("Horizontal");
　　		// fall if unsupported
　　		moveDirection.y -= gravity * Time.deltaTime;
            // stay static if no input
　　		if (horizontal == 0) {
　　			moveDirection.x = horizontal;		
　　		}
　　		// set up left & right movement
　　		if (horizontal > 0.01f) {
　　			lookRight = true;
　　			moveDirection.x = horizontal * walkSpeed;
　　		}
　　		
　　		if (horizontal < -0.01f) {
　　			lookRight = false;
　　			moveDirection.x = horizontal * walkSpeed;
　　		}

            //Creates dust when moving left 
            if(Input.GetAxis("Horizontal")<0){
                CreateDust();
            }

            //Creates dust when moving right 
            if(Input.GetAxis("Horizontal")>0){
               CreateDust();
            }

　　		// jump if player is touching ground
　　		if (characterController.isGrounded) {
　　			if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)){
　　				moveDirection.y = jumpHeight;
　　			}
　　		}
            // allow player to fly if customized and in bounds
            if (custom && InBounds()){
                if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)){
　　				moveDirection.y = jumpHeight;
　　			}
            }

　　		// BulletAttack() when F key is pressed
　　		if (Time.time >= coolDown) {
　　			if (Input.GetKeyDown (KeyCode.F)){
　　				BulletAttack ();	
　　			}
　　		}
            // Custom() when C key is pressed and player is not already customized
            if (Input.GetKeyDown("c") && !custom){
                Custom();
                custom = true;
            }
            // UndoCustom() when U key is pressed and player is already customized
            if (Input.GetKeyDown("u") && custom){
                UndoCustom();
                custom = false;
            }
            // MineAttack() when M key is pressed
            if (Input.GetKeyDown("m")){
                if (GameManager.numOfMine > 0){
                MineAttack();
                }
            }
            
           
　　	}
　　	
　　	
　　	void BulletAttack(){
　　		if (lookRight) {
　　			// shoot right if facing right
　　			Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity)as Rigidbody;
　　			bPrefab.GetComponent<Rigidbody>().AddForce (Vector3.right * 500);
　　			coolDown = Time.time + attackRate;
　　				}
　　		else {
　　			// shoot left if facing left
　　			Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity)as Rigidbody;
　　			bPrefab.GetComponent<Rigidbody>().AddForce (-Vector3.right * 500);
　　			coolDown = Time.time + attackRate;
　　		}
　　	}

        void MineAttack(){
            // Instantiate mine where player drops it
            Vector3 mineDrop = transform.position;
            mineDrop -= new Vector3(0.7f, 0.5f, -1f);
            Instantiate (mine, mineDrop, Quaternion.identity);
            GameManager.numOfMine --;
            
        }

        
        void OnTriggerEnter(Collider other){
            //adds player health when player collides with health pickup
		    if (other.tag == "Health") {
                 if (GameManager.playersHealth < 5){
			        GameManager.playersHealth++;
                }
                GameManager.playersEXP += 50;
			    Destroy(other.gameObject);  
		    }

             if (other.tag == "Mine Refill") {
                 if (GameManager.numOfMine < 15){
			        GameManager.numOfMine += 5;
                }
                GameManager.playersEXP += 50;
			    Destroy(other.gameObject);  
		    }

           //add player health when player collides with speed boost pickup
            if (other.tag == "Speed") {
			  StartCoroutine(increaseSpeed(5f));
                GameManager.playersEXP += 50;
			    Destroy(other.gameObject);
		    }

            //push player upwards when player collides with trampoline gameobject
            if (other.tag == "Trampoline"){
            moveDirection.y = jumpHeight* 1.25f;
            }

            if(other.tag == "Gold"){
                GameManager.playersWealth++;
                Destroy(other.gameObject);
                points++;
            }
        
	    }

      
	
　　	
　　	public IEnumerator TakenDamage(){
            // flash object once damage is taken
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
            hitsTaken++;
            walkSpeed += 1f;
            jumpHeight += 1f;
　　	} 


        IEnumerator increaseSpeed(float duration){
            walkSpeed = 10;
            yield return new WaitForSeconds(duration);
            walkSpeed = 5;
        }

        public void Custom() {
            // increase player size, player invulnerability, decrease speed
            player.localScale += new Vector3(0.5f, 0.5f, 0);
            walkSpeed -= 1.5f;
            jumpHeight -= 2.5f;
            takenDamage += 0.2f;
        }

        public void UndoCustom() {
            // undo changes from Custom() method
            player.localScale -= new Vector3(0.5f, 0.5f, 0);
            walkSpeed += 1.5f;
            jumpHeight += 2.5f;
            takenDamage -= 0.2f;
        }

        public void CreateDust(){
            //Plays dust animation
            dust.Play();
        }

        public bool InBounds(){
            if (transform.position.y <= 8){
                return true;
            } else {
                return false;
            }
        }

        
　　}