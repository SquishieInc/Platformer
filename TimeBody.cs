﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

	bool isRewinding = false;
	public float secondsToRewind = 5f;

	List<PointInTime> pointsInTime;

	// Use this for initialization
	void Start()
	{
		pointsInTime = new List<PointInTime>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			StartRewind();
		}
		if (Input.GetKeyUp(KeyCode.Return))
        {
			StopRewind();
        }
	}

	private void FixedUpdate()
	{
		if(isRewinding)
		{
			Rewind();
		}
		else
		{
			Record();
		}
	}

	public void StartRewind()
	{
		isRewinding = true;
	}

    public void StopRewind()
	{
		isRewinding = false;
	}

    void Record()
	{
		if(pointsInTime.Count > Mathf.Round (secondsToRewind / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

    void Rewind()
	{
		if(pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
			transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;

            pointsInTime.RemoveAt(0);
		}
		else
		{
			StopRewind();
		}
	}
}
