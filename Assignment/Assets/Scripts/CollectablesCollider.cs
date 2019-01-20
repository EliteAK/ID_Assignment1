using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesCollider : MonoBehaviour {

	HUD_Controller HC;

	private AudioSource source;
	[SerializeField] private AudioClip clip;

	void Start()
	{
		GameObject ccgo = GameObject.Find ("HUDController");
		HC = ccgo.GetComponent<HUD_Controller> ();
	}

	void OnTriggerEnter (Collider col)
	{
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot(clip);
		HC.IncrementCount (gameObject);
		Destroy(gameObject);
	}
}
