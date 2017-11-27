//Goes on "Mesh" GameObject. Child of "Boss" GameObject
//Hi phil it's sem


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
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

	[SerializeField]
	Transform _destination;

	NavMeshAgent _navMeshAgent;

	void Start ()
	{
		StartCoroutine (AttackRoutine ());
	}

	void Update ()
	{
		_navMeshAgent = this.GetComponent<NavMeshAgent> ();
		if (_navMeshAgent == null) 
		{
			Debug.LogError ("Nav mesh agent component not attached to" + gameObject.name);
		}
		else 
		{
			SetDestination();
		}
	}

	private void SetDestination()
	{
		if (_destination != null)
		{
			Vector3 targetVector = _destination.transform.position;
			_navMeshAgent.SetDestination (targetVector);
		}
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
