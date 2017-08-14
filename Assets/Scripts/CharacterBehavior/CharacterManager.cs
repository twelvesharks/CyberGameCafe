﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject playerPrefab = null;
    public List<GameObject> players = new List<GameObject>();


    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.A))
        {
            //print("Create New Player");
            SpawnNewPlayer();
        }
    }


    /// <summary>
    /// Create a new player into the scene at a specified spawn node. 
    /// </summary>
    public void SpawnNewPlayer()
    {
       GameObject player = Instantiate(playerPrefab, this.transform);

        var id = -1;
        do
        {
            id = Random.Range(0, SetupMap.nodeGraph.nodes.Length - 1);
        } while (SetupMap.nodeGraph.nodes[id].solid);

        var node = SetupMap.nodeGraph.nodes[id];
        player.GetComponentInChildren<NPCMovement>().currentNode = node;
        player.transform.position = node.position;
        players.Add(player);

        player.name = "ID: " + players.Count + ", Name: Muffasa ) ";
        print("Current Node Id: " + node.label);
    }

}
