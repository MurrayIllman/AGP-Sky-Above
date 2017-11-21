using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossAttackCode: MonoBehaviour {

	public Slider sliderUI;
	public bool attackOportunity;
	public GameObject player;
	public Player playerScriptReference;
	public int playerHPReference;


	void Start(){
		playerScriptReference = player.GetComponent<Player>();
	
	}

	public void OnTriggerEnter (Collider collider){

		if(collider.tag == "Player"){
			PlayerDamaged ();
			SliderFunction ();
		}

	}

	void OnTriggerExit (Collider collider){
		collider.isTrigger = false;
	}

	public void PlayerDamaged (){
		print("Im being hit");
		playerHPReference -= 10;
	}
			
	public void SliderFunction(){
		sliderUI.value = playerHPReference;
	}

}
