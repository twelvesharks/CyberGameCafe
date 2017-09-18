using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualTriggers : MonoBehaviour {

	public GameObject gameController;

	void OnTriggerEnter2D(Collider2D col)
	{
		gameController.GetComponent<MazeTrigger> ().DestroyTrigger ();
	}
}
