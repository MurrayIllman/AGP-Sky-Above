//Goes on player damage hitbox
//Hi phil it's sem again

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttackCode : MonoBehaviour {

	public Slider sliderUI;

	public GameObject boss;
	public BossScript1 bossScriptReference;
	public int bossHPReference;

	void Start(){
		bossScriptReference = boss.GetComponent<BossScript1>();
	//	bossHPReference = bossScriptReference.HP;
	}

	public void OnTriggerEnter (Collider collider){

		if(collider.tag == "Boss"){
			BossDamaged ();
			SliderFunction ();
		}

	}

	void OnTriggerExit (Collider collider){
		collider.isTrigger = false;
	}

	public void BossDamaged (){
		print("Im hitting him");
		bossHPReference -= 50;
	}

	public void SliderFunction(){
		sliderUI.value = bossHPReference;
	}

}
