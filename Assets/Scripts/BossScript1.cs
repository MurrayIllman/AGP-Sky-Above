using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript1 : MonoBehaviour {

	public int HP = 500;
	public Slider hpSlider;

	void Start () 
	{
		hpSlider.value = HP;
	}

	void Update () 
	{
		
	}
}
