using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite : MonoBehaviour
{
    public Animator animator;
    public float speed;
    bool jump;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed * Time.deltaTime;

        if(Input.GetButtonDown("Jump")){
            animator.SetBool("Jump",true);
            jump = true;
        }

        else if (Input.GetButtonUp("Jump")){
            animator.SetBool("Jump", false);
            jump=false;
        }
        
    }
}
