﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDialog : MonoBehaviour
{

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
            GameObject.FindGameObjectWithTag("TextBox").GetComponent<DialogueMessages>();
        if (thisQuest.getActiveObjective() == null)
        {
            d.spawnTextBox("Public PC Quest Dialog!", name);

            player.GetComponent<QuestSystem>().assignMission(thisQuest, gameObject);
        }
        else
        {
            d.spawnTextBox("I really appreciate your help.", name);
        }
    }
}