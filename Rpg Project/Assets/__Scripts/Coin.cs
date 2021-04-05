using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z 
    }
}
