//Goes on "Mesh" GameObject. Child of "Boss" GameObject
//Hi phil it's sem


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public interface IAttack
{
	IEnumerator Attack ();
}

public class BossScript1 : MonoBehaviour
{
	public Transform Player;
	public Behaviour[] attacks;
	public int HP = 500;

	void Start ()
	{
		StartCoroutine (AttackRoutine ());
	}

	IEnumerator AttackRoutine()
	{
		var random = new System.Random();
		var shuffledAttacks = attacks.OrderBy((attack) => random.Next());

		while (true) {

			foreach (IAttack attack in shuffledAttacks) {

				float time = 0.0f;

				while (time < 5.0f) {

					time += Time.deltaTime;
					// This make the boss always look at the player
					transform.LookAt (Player);
					yield return null;
				}

				yield return attack.Attack ();
			}
			
		}
	}
}
