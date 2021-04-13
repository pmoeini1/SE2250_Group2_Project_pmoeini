using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // hold size of character
    private Vector3 localScale;
    // hold horizontal direction
    private float dirX;
    // determine which way player faces
    private bool facingRight = true;
    

    void Start()
    {
        // get size of character
       localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // get horizontal direction
        dirX = Input.GetAxisRaw("Horizontal") * 2f;
    }

    private void LateUpdate(){
        // set up which way player is facing dynamically
        if(dirX > 0){
            facingRight = true;
        }
        else if (dirX < 0){
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0))){
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
}
