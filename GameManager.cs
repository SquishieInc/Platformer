using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	int m_lives;
	int m_coins;
	int m_lastLevelPasted;
	public int m_LastWorldUnlocked;

	void Start()
	{
		m_lives = PlayerPrefs.GetInt("Lives", 3);
		m_coins = PlayerPrefs.GetInt("Coins", 0);
		m_lastLevelPasted = PlayerPrefs.GetInt("LastUnlockedLevel", 1);
		m_LastWorldUnlocked = PlayerPrefs.GetInt("LastWorldUnlocked", 1);
	}

	void Awake()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);
       
		DontDestroyOnLoad(gameObject);
	}

	public void addCoins(int coins)
	{
		m_coins += coins;
	}

    public void removeCoins(int coins)
	{
		m_coins -= coins;
	}

    public void LoseLife()
	{
		m_lives--;
	}

    public void GainLife()
	{
		m_lives++;
	}


}
