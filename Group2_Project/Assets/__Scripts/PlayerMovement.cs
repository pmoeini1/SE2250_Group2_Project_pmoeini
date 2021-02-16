using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.5f;
    float thrust = 2f;
    public Rigidbody rb;
    Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = Vector3.left;
        }

        gameObject.transform.position = gameObject.transform.position + move * speed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            rb.AddForce(jump*thrust);
        }
    }
}
