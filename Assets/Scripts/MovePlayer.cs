using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public float moveSpeed = 5.0F;
	public float rotationSpeed = 300.0F;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private Quaternion destRotation;
	void Start () {
		controller = GetComponent <CharacterController> ();
		destRotation = transform.rotation;
	}
	

	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection = moveDirection * moveSpeed;
		controller.SimpleMove (moveDirection);

		//destRotation.eulerAngles += new Vector3 (-Input.GetAxis ("Mouse Y") * rotationSpeed, 0, 0);
		//destRotation.eulerAngles += new Vector3 (0, Input.GetAxis ("Mouse X") * rotationSpeed, 0);

		if (Input.GetKeyDown("q")){
			destRotation.eulerAngles = destRotation.eulerAngles - new Vector3 (0, 90, 0);
		}
		if (Input.GetKeyDown("e")){
			destRotation.eulerAngles = destRotation.eulerAngles + new Vector3 (0, 90, 0);
		}
		float step = rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, destRotation, step);
	}
}