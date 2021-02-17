    using UnityEngine;
　　using System.Collections;
　　
　　public class Controller2D : MonoBehaviour {
　　	
　　	CharacterController characterController;
　　	
　　	public float gravity = 10;
　　	
　　	public float walkSpeed = 5;
　　	
　　	public float jumpHeight = 5;
　　
　　	
　　	float takenDamage = 0.2f;
　　
　　	
　　	Vector3 moveDirection = Vector3.zero;
　　	float horizontal = 0;
　　	
　　	public Rigidbody bulletPrefab;
　　	float attackRate = 0.5f;
　　	float coolDown;
　　	bool lookRight = true;
　　	
　　	void Start () {
　　		characterController = GetComponent<CharacterController>();
　　
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
　　			if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.K)){
　　				moveDirection.y = jumpHeight;
　　			}
　　		}
　　		
　　		if (Time.time >= coolDown) {
　　			if (Input.GetKeyDown (KeyCode.F)){
　　				BulletAttack ();	
　　			}
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
　　}