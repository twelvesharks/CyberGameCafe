using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualTriggers : MonoBehaviour {

	private GameObject gameController;
    private GameObject player;
    private GameObject mazeRunner;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D col)
	{
        Debug.Log("collision"); 
        mazeRunner = GameObject.FindGameObjectWithTag("MazeRunner");
        player = GameObject.FindGameObjectWithTag("Player");

        if (col.gameObject == mazeRunner)
        {
            Debug.Log("Mouse!");
            Destroy(col.gameObject);
            gameController.GetComponent<MazeTrigger>().MazeManager(false);
        }
        if (col.gameObject == player)
        {
            Debug.Log("Player");
            Destroy(gameObject);
            gameController.GetComponent<MazeTrigger>().MazeManager(true);
        }
	}
}
