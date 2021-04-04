using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeProjectile : MonoBehaviour
{
    public float speed;
    private float lifeTime = 4.25f;
    private Transform player;
    private Vector2 target;

    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update(){

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }



        // Destroy Bullet once out of screen
　　void FixedUpdate(){
　　		Destroy (gameObject, lifeTime);
　　	}


    void DestroyProjectile(){

        Destroy(gameObject);
    }
}
