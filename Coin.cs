using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject == player)
		{
			LevelManager.instance.CollectedCoin();
			Destroy(gameObject);
		}
	}
}
