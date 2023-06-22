using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	[Header ("Dialogue Objects")]
	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	private PlayerController playerController;

	// Use this for initialization
	void Start () 
	{
		sentences = new Queue<string>();
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool("isOpen", true);
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";

		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
    
	void EndDialogue()
	{
		animator.SetBool("isOpen", false);
		//playerController.EnableMove();
		playerController.canMove = true;
	}
}
