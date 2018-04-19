using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthController {

	public AudioClip hurtClip;
	public AudioClip deathClip;
	public Image healthGui;
	private LifePointController lifePointController;
	private float maxHealth;private Text messageText;private AudioSource audioSource;

	void Start () {
		messageText = GameObject.FindGameObjectWithTag ("Message").GetComponent<Text>();
		lifePointController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LifePointController>();
		audioSource = GetComponent<AudioSource> ();
		maxHealth = health;
		UpdateView ();
	}

	public override void Damaging(){
		audioSource.clip = hurtClip;
		audioSource.Play ();
		UpdateView ();
	}

	public override void Dying(){
		audioSource.clip = deathClip;
		audioSource.Play ();
		UpdateView ();
		lifePointController.LifePoints -= 1;
		if (lifePointController.LifePoints > 0) {
			Invoke ("Restart", 1);
		} else {
			messageText.text = "Game Over";
		}
	}

	void Restart()
	{
		Application.LoadLevel(Application.loadedLevel) ;
	}
	// Update is called once per frame
	void UpdateView() {
		if (healthGui != null) {
			healthGui.fillAmount = health / maxHealth;
		}
	}
}
