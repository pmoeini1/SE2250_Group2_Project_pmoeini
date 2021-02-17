using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.7f;
    float thrust = 50f;
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

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            
            rb.AddForce(jump*thrust);
        }

        if (gameObject.transform.position.y < 12 || gameObject.transform.position.x < -65 || gameObject.transform.position.x > 340) 
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Scene1");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("Scene1");
        }
    }
}
