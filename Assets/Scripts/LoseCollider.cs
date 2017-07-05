using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Function to catch collision message
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    // Function to catch trigger message
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("Loose");
    }
}
