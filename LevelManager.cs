using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance = null;

	LevelChanger levelChanger;

	public int coins;
	public int m_numberOfCollectables;
	int m_collectablesFound;
	int m_startingCollectables;

	Text m_collectableText;
	Text m_coinsText;
    

	void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () 
	{
		m_collectablesFound = 0;
		coins = 0;

		m_numberOfCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
		m_startingCollectables = m_numberOfCollectables;

		levelChanger = FindObjectOfType<LevelChanger>().GetComponent<LevelChanger>();
		m_collectableText = GameObject.Find("CollectablesText").GetComponent<Text>();
		m_collectableText.text = m_startingCollectables + "/" + m_collectablesFound.ToString();

		m_coinsText = GameObject.Find("CoinsText").GetComponent<Text>();
		m_coinsText.text = coins.ToString();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public void CollectedCoin()
	{
		coins++;
		m_coinsText.text = coins.ToString();
	}

    public void FoundCollectable()
	{
		m_numberOfCollectables--;
		m_collectablesFound++;
		m_collectableText.text = m_startingCollectables + "/" + m_collectablesFound.ToString();
	}

    public void LevelWon()
	{
		if (m_numberOfCollectables == 0)
        {
            levelChanger.FadeToLevel();
        }
	}
}
