using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;



public class PlayerController : MonoBehaviour {

	public Camera camera;
	public NavMeshAgent agent;
    public static float steps;

	Animator myAnim;
	float dist;
	RaycastHit hit;

	public bool isMoving = false;

	Quaternion newRotation;
	float rotSpeed = 5.0f ;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				agent.SetDestination (hit.point);
				myAnim.SetBool ("isRunning", true);
				isMoving = true;
			}
		}

		if (isMoving == true) 
		{
            steps = steps + Time.deltaTime*3;
            HUD_Controller.score = HUD_Controller.score -(Time.deltaTime * 3);

            Vector3 relativePos = hit.point - transform.position;
			newRotation = Quaternion.LookRotation (relativePos, Vector3.up);
			newRotation.x = 0.0f;
			newRotation.z = 0.0f;

			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, rotSpeed * Time.deltaTime);

			dist = Vector3.Distance (hit.point, transform.position);
			//Debug.Log ("Distance" + dist);
			if (dist < 1f) {
				myAnim.SetBool ("isRunning", false);
				isMoving = false;
			}
		}
	}
}
