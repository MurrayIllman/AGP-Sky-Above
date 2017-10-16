﻿//Goes on player damage hitbox
//Hi phil it's sem again

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackCode: MonoBehaviour {

	public Slider sliderUI;

	public GameObject boss;
	public BossScript1 bossScriptReference;
	public int bossHPReference;

	void Start(){
		bossScriptReference = boss.GetComponent<BossScript1>();
		bossHPReference = bossScriptReference.HP;
	}

	public void OnTriggerEnter (Collider collider){

		if(GameObject.FindGameObjectWithTag("Boss")){
			BossDamaged ();
			SliderFunction ();
		}

	}

	void OnTriggerExit (Collider collider){
		collider.isTrigger = false;
	}

	public void BossDamaged (){
		bossHPReference -= 50;
	}

	public void SliderFunction(){
		sliderUI.value = bossHPReference;
	}

}