//Goes on "Mesh" GameObject. Child of "Boss" GameObject
//Hi phil it's sem


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript1 : MonoBehaviour
{
	public Transform Player;
	public patternOne pattern1;
	public int HP = 500;

	void Start ()
	{
		StartCoroutine (AttackRoutine ());
	}

	IEnumerator AttackRoutine()
	{
		while (true) {
			
			float time = 0.0f;

			while (time < 5.0f) {

				time += Time.deltaTime;
				// This make the boss always look at the player
				transform.LookAt (Player);
				yield return null;
			}

			yield return pattern1.Attack ();
		}
	}
}
