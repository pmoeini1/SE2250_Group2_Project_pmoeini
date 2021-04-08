using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite : MonoBehaviour
{
    public Animator animator;
    public float speed;
    bool jump;
    private float getMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed * Time.deltaTime;
        getMovement = Input.GetAxis("Horizontal");
        //Every animation has a right and left like when shooting
        //Need to add additional code to account for this in the Controller 2D script 
        //Can add a && operator in the if statement to check which direction the character is facing using the lookRight variable in controller2D
        //If you goto Unity Animator window then you can change the speed of the animation by clicking on the line connecting each state 

        //When f is pressed then the player attacks right 
          if (Input.GetKeyDown(KeyCode.F)){
              animator.Play("AttackRight"); //Plays the animation from Unity Animator 
              //Add attack method 
          }

          if(Input.GetKeyDown(KeyCode.Space)){
              animator.Play("jumpRight"); //Plays the animation from Unity Animator
              //Add jump  code  
          }
        
          if (Input.GetKeyDown(KeyCode.F)){
              animator.Play("AttackLeft"); //Plays the animation from Unity Animator 
              //Add attack method 
          }

          if(Input.GetKeyDown(KeyCode.Space)){
              animator.Play("jumpLeft"); //Plays the animation from Unity Animator 
              //Add jump code 
          }
        
    }
}
