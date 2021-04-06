using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public Transform aimTransform;
    public GameObject bullet;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float bulletSpeed = 10.0f;

    private void Awake(){
        aimTransform = GameObject.FindGameObjectWithTag("Gun").GetComponent<Transform>();
    }

    private void Update() {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0, angle);

        
        HandleShooting(aimDirection, angle);
    }


    

    private void HandleShooting(Vector3 direction, float rotationZ){
        if(timeBtwShots <= 0){
            if (Input.GetMouseButtonDown(0)) {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = aimTransform.transform.position;
            b.transform.rotation = Quaternion.Euler(0,0,rotationZ);
            b.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
            timeBtwShots = startTimeBtwShots;
            }
        } else{
            timeBtwShots -= Time.deltaTime;
        }

    }

    public static Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ() {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
     public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
     public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
