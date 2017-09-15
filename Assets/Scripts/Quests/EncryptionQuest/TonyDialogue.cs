﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonyDialogue : MonoBehaviour {

	GameObject player;
	bool playerInBox;
	Mission thisQuest;
	[SerializeField]
	GameObject computerTrigger;

	void Start()
	{
		thisQuest = GetComponentInParent<Mission>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (col.gameObject == player)
		{
			playerInBox = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (col.gameObject == player)
		{
			playerInBox = false;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerInBox)
		{
			interact();
		}
	}

	void interact()
	{
		DialogueMessages d =
			GameObject.FindGameObjectWithTag ("TextBox").GetComponent<DialogueMessages> ();
		if (thisQuest.getActiveObjective () == null) {
			d.spawnTextBox ("I have some very very important E-Mails to send, but I really need to wait here for a parcel.");
			d.spawnTextBox ("As I know you so well, please could you go onto the computer in the room here and send my E-Mails?");
			d.spawnTextBox ("Unfortunately the information is very important. So it must be encrypted.");
			d.spawnTextBox ("If the E-Mails don't get encrypted, there is a risk that someone could intercept the E-Mails and learn my secrets.");
			d.spawnTextBox ("Each letter in the message needs to translated to another letter.");
			d.spawnTextBox ("For example, in a 1 Caeser Shift, B needs to be typed instead of B and C needs to be typed instead of B");

			computerTrigger.GetComponent<BoxCollider2D> ().enabled = true;

			player.GetComponent<QuestSystem> ().assignMission (thisQuest, gameObject);
		} else {
			d.spawnTextBox ("You are doing a quest for me");
		}
	}
}
