﻿using System.Collections.Generic;
using UnityEngine;


public class NPCWaitState
{
    public bool pathFinding = false;




    public void PathFinding(int currentNode)
    {
        SetupMap m = GameObject.Find("Map").GetComponent<SetupMap>();
        // Get a random goal
        var goal = -1;
        do
        {
            goal = Random.Range(0, m.grid.Length - 1);
        } while (SetupMap.nodeGraph.nodes[goal].solid == true);



        pathFinding = true;



        //GameObject goalSprite = Instantiate(nodeSprite, graph.nodes[goal].position, Quaternion.identity);
        //goalSprite.name = "GOAL NODE";
        //goalSprite.GetComponent<SpriteRenderer>().color = Color.red;
        //goalSprite.GetComponent<SpriteRenderer>().sortingOrder = 2;


        var search = new Search(SetupMap.nodeGraph);
        search.Start(SetupMap.nodeGraph.nodes[currentNode], SetupMap.nodeGraph.nodes[goal]);

        while (!search.finished)
        {
            search.Step();
        }


        Debug.Log("Search done. Path length " + search.path.Count + " iterations " + search.iterations);
    }
}
