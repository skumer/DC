using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointControler : MonoBehaviour {

	private int lifePoints = 0;
	public Text lpText;

	public int LifePoints{
		get{
			return lifePoints;
		}
		set{
			lifePoints = value;
			if (lifePoints < 0) {
				lifePoints = 0;
			}
			UpdateView();
		}
	}
	void Awake(){
		LifePoints = PlayerPrefs.GetInt ("LPs");
	}
	void UpdateView(){
		lpText.text = lifePoints.ToString();
	}
	void onDestroy(){
		PlayerPrefs.SetInt ("LPs", lifePoints);
	}
}