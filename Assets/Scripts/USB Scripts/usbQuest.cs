﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usbQuest : MonoBehaviour 
{
	[SerializeField]
	private Mission usbMission;
	[SerializeField]
	private MissionObjective usbPickupObjective;
	[SerializeField]
	private MissionObjective usbSortObjective;

	private bool playerEnter;

	private GameObject player;


	// Use this for initialization
	void Start () 
	{
		playerEnter = false;

	}
		
	// Update is called once per frame
	void Update () 
	{		
		if(playerEnter && Input.GetKeyDown(KeyCode.E))
		{
			player.GetComponent<QuestSystem> ().assignMission (usbMission, this.gameObject);
		}
			
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (player == null) 
		{
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		if(coll.gameObject == player)
		{
			playerEnter = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject == player)
		{
			playerEnter = false;
		}
	}
}
