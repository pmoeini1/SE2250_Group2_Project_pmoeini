    using UnityEngine;
　　using System.Collections;
    
　　
　　public class Controller2D : MonoBehaviour, IController2D {
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
        public Rigidbody mine;
        public Transform player;
　　	Vector3 moveDirection = Vector3.zero;
　　	float horizontal = 0;
　　	float attackRate = 0.5f;
　　	float coolDown;
　　	bool lookRight = true;
        bool custom = false;
　　	
　　	void Start () {
　　		characterController = GetComponent<CharacterController>();
            custom = false;
　　	}
　　	
　　	
　　	void Update () {
　　		
　　		characterController.Move (moveDirection * Time.deltaTime);
　　		horizontal = Input.GetAxis("Horizontal");
　　		
　　		moveDirection.y -= gravity * Time.deltaTime;
　　
　　		if (horizontal == 0) {
　　			moveDirection.x = horizontal;		
　　		}
　　		
　　		if (horizontal > 0.01f) {
　　			lookRight = true;
　　			moveDirection.x = horizontal * walkSpeed;
　　		}
　　		
　　		if (horizontal < -0.01f) {
　　			lookRight = false;
　　			moveDirection.x = horizontal * walkSpeed;
　　		}
　　		
　　		if (characterController.isGrounded) {
　　			if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)){
　　				moveDirection.y = jumpHeight;
　　			}
　　		}
　　		
　　		if (Time.time >= coolDown) {
　　			if (Input.GetKeyDown (KeyCode.F)){
　　				BulletAttack ();	
　　			}
　　		}

            if (Input.GetKeyDown("c") && !custom){
                Custom();
                custom = true;
            }

            if (Input.GetKeyDown("u") && custom){
                UndoCustom();
                custom = false;
            }
            if (Input.GetKeyDown("m")){
                MineAttack();
            }
　　	}
　　	
　　	
　　	void BulletAttack(){
　　		if (lookRight) {
　　			
　　			Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity)as Rigidbody;
　　			bPrefab.GetComponent<Rigidbody>().AddForce (Vector3.right * 500);
　　			coolDown = Time.time + attackRate;
　　				}
　　		else {
　　			
　　			Rigidbody bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity)as Rigidbody;
　　			bPrefab.GetComponent<Rigidbody>().AddForce (-Vector3.right * 500);
　　			coolDown = Time.time + attackRate;
　　		}
　　	}

        void MineAttack(){
            // Instantiate mine
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

        public void Custom() {

            player.localScale += new Vector3(0.5f, 0.5f, 0);
            walkSpeed -= 1.5f;
            
            takenDamage += 0.2f;
        }

        public void UndoCustom() {

            player.localScale -= new Vector3(0.5f, 0.5f, 0);
            walkSpeed += 1.5f;
            
            takenDamage -= 0.2f;
        }
　　}