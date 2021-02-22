using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

　　
　　public class GameManager : MonoBehaviour {
　　	
　　	public Controller2D controller2D;
　　	
　　	public Texture playersHealthTexture;
　　	
　　	public float screenPositionX;
　　	public float screenPositionY;
　　	
　　	public int iconSizeX = 25;
　　	public int iconSizeY = 25;
　　	
　　	public int playersHealth = 3;
　　	GameObject player;
　　	
　　	void Start(){
　　		player = GameObject.FindGameObjectWithTag("Player");
　　	}
　　
　　	
　　	void OnGUI(){
　　		for (int h =0; h < playersHealth; h++) {
　　			GUI.DrawTexture(new Rect(screenPositionX + (h*iconSizeX),screenPositionY,iconSizeX,iconSizeY),playersHealthTexture,ScaleMode.ScaleToFit,true,0);
　　		}
　　	}
　　
　　	void PlayerDamaged(int damage){   
　　		if (player.GetComponent<Renderer>().enabled) {
　　						if (playersHealth > 0) {
　　								playersHealth -= damage;	
　　						}
　　
　　						if (playersHealth <= 0) {
　　								RestartScene ();	
　　						}
　　				}
　　	}
　　
　　	void RestartScene(){
　　		  SceneManager.LoadScene("Scene1");
　　	}
　　}
