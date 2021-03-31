using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

　　
    public class GameManager : MonoBehaviour {
　　	//Reference to the controller script
　　	public Controller2D controller2D;
        //Place to put the Texture for health bar
　　	public Texture playersHealthTexture;
        //Place to put the Texture for coins
        public Texture playersWealthTexture;
        //Place to put the Texture for exp
        public Texture playersEXPTexture;
　　	//X, Y location of the health bar 
　　	public float screenPositionX;
　　	public float screenPositionY;
        public float iconOffset;
　　	//Size of the health bar 
　　	public int iconSizeX = 25;
　　	public int iconSizeY = 25;
　　	//How many lives the player has 
　　	public static int playersHealth = 5;
        public static int playersWealth = 0;
        public static int playerEXP = 0;

        //Declare player as a GameObject
　　	GameObject player;
　　	
        //Find the player object at the start of game
　　	void Start(){
　　		player = GameObject.FindGameObjectWithTag("Player");
　　	}
　　
　　	
　　	void OnGUI(){
　　		for (int h = 0; h < playersHealth; h++) {
                        //Draw health bar
　　			GUI.DrawTexture(new Rect(screenPositionX + (h*iconSizeX),
                                                 screenPositionY,
                                                 iconSizeX,iconSizeY),
                                                 playersHealthTexture,
                                                 ScaleMode.ScaleToFit,
                                                 true,0
                                                 );
　　		}
                        //Draw Gold bar
                        GUI.DrawTexture(new Rect(screenPositionX, 
                                                 screenPositionY + iconOffset * 1, 
                                                 iconSizeX, iconSizeY),
                                                 playersWealthTexture,
                                                 ScaleMode.ScaleToFit,
                                                 true,0
                                                );

                        //Draw Gold bar
                        GUI.DrawTexture(new Rect(screenPositionX, 
                                                 screenPositionY + iconOffset * 2, 
                                                 iconSizeX, iconSizeY),
                                                 playersEXPTexture,
                                                 ScaleMode.ScaleToFit,
                                                 true,0
                                                );

               
　　	        }

        //Method that lets the player take damage when hit by enemy
　　	void PlayerDamaged(int damage){   
            //Make sure that the player do not get hit by the enemy repeatedly 
　　		if (player.GetComponent<Renderer>().enabled) {
                            //decrease health when hit
　　			if (playersHealth > 0) {
　　				playersHealth -= damage;	
　　			}
                        //Restart scene when player health = 0
　　			if (playersHealth <= 0) {
                                playersHealth = 5;
　　				RestartScene ();	
　　			  }
　　			}
　　	}

        //Restart method
　　	void RestartScene(){
　　		  SceneManager.LoadScene("Scene1");
　　	}
　　}
