using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour {

	public int lives = 10;
	DodgeMover dm;
	public Slider healthSLider;
	public Text evasionScore;
	int score;
	public int dodgeScore;
	public GameObject exploasion;
	public GameObject exploasionGameOver;
	public Animator AnimShake;
	public Animator AnimHalo;
	private AudioSource EAS;
	public AudioClip[] explosionSounds;
	public Canvas gameOverMenu;

	void Start () {
		dm = GetComponent<DodgeMover> ();
		EAS = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Projectile" && dm.movementLock == false) {
			lives--;
			Destroy(other.gameObject);
			Debug.Log ("Test");
			healthSLider.value = lives;
			Instantiate (exploasion, transform.position, Quaternion.identity);
			AnimShake.SetTrigger("Shake");
			PlaySound (explosionSounds [0], 0.05f);
		} else {
			score += dodgeScore;
			evasionScore.text = string.Format ("Evasion Score: {0}", score);
			AnimHalo.SetTrigger ("PointGain");
		}
		if (lives <= 0) {
			GameOver ();
		}
	}

	void PlaySound(AudioClip sfx, float sfxVolume)
	{
		EAS.clip = sfx;
		EAS.volume = sfxVolume;
		EAS.Play();
	}

	void GameOver()
	{
		//Debug.Log("Gameover");
		PlaySound (explosionSounds [1], 0.3f);

		//Stop all audiosource components on this object
		//AudioSource[] Sources = GetComponents<AudioSource>();
		//if(Sources [2]!=null)
			//Sources [2].Stop ();

		//Destroy(gameObject, 1f);
		//Debug.Log("Dead. Explosion prefab is: " + exploasionGameOver.name);
		Instantiate (exploasionGameOver, transform.position, Quaternion.identity);

		GetComponent<Collider> ().enabled = false;
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<DodgeMover> ().enabled = false;
		gameOverMenu.enabled = true;
		//GetComponent<Halo> ().enabled = false;
	}


}