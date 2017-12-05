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
	public float force = 10.0f;

	void Start(){
		playerScriptReference = player.GetComponent<Player>();
	
	}

	public void OnTriggerEnter (Collider collider){

		if(collider.tag == "Player"){
			PlayerDamaged ();
			Player player = collider.GetComponent<Player> ();
			if (player != null) {
				Vector3 attackVector = collider.transform.position - transform.position;
				attackVector.y = 0.0f;
				player.KnockBack(attackVector.normalized * force);
			}
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
