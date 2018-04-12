using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

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
	
	// Update is called once per frame
	void UpdateView() {
		if (healthGui != null) {
			healthGui.fillAmount = health / maxHealth;
		}
	}
}
