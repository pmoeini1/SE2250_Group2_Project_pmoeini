using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    public Controller2D controller2D;
    void FixedUpdate(){
　　		Destroy (gameObject, 9.25f);
　　	}
}
