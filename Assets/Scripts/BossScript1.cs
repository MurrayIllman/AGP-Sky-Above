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
	public Animator Anim = null;

	[SerializeField]
	Transform _destination;

	NavMeshAgent _navMeshAgent;

	void Start ()
	{
		_navMeshAgent = this.GetComponent<NavMeshAgent> ();
		if (_navMeshAgent == null) 
		{
			Debug.LogError ("Nav mesh agent component not attached to" + gameObject.name);
		}
		Anim = GetComponent <Animator> ();
		StartCoroutine (AttackRoutine ());
	}

	void Update ()
	{
	}

	private void SetDestination()
	{
		if (_destination != null)
		{
			Vector3 targetVector = _destination.transform.position;
			_navMeshAgent.SetDestination (targetVector);
			Anim.SetBool ("IsMoving", true);
		}
	}

	IEnumerator AttackRoutine()
	{
		var random = new System.Random ();
		var shuffledAttacks = attacks.OrderBy ((attack) => random.Next ());
		var dealtAttack = shuffledAttacks.GetEnumerator ();

		while (true) {

			Debug.Log ("Close in");
			while (Vector3.Distance (transform.position, _destination.transform.position) >= _navMeshAgent.stoppingDistance) {
			
				SetDestination ();
				transform.LookAt (Player);
				yield return true;
			}
			Anim.SetBool ("IsMoving", false);

			if (!dealtAttack.MoveNext ()) {

				dealtAttack = shuffledAttacks.GetEnumerator ();
				dealtAttack.MoveNext ();
			}

			IAttack attack = (dealtAttack.Current as IAttack);
			if (attack != null) {
				Debug.Log ("attack");
				yield return attack.Attack ();
			}


			Anim.SetBool ("IsMoving", false);

			Debug.Log ("wait");
			yield return new WaitForSeconds (1);
		}
	}
}
