﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator animator;
	public int levelToLoad;
    
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			FadeToLevel();
		}
	}

    public void FadeToLevel(/*int levelIndex*/)
	{
		//levelToLoad = levelIndex;
		animator.SetTrigger("FadeOut");
	}

	public void FadeToIntLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}
