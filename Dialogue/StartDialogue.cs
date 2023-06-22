using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDialogue : MonoBehaviour {

	private GameObject player;

	DialogueTrigger dialogueTrigger;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
		dialogueTrigger = GetComponent<DialogueTrigger>();
    }

	private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject == player)
        {
			dialogueTrigger.TriggerDialogue();
			player.GetComponent<PlayerController>().EnableMove();
        }
    }
}
