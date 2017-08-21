﻿using System;
using UnityEngine;

public class ReputationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform CurrentRepMarker;

	public Transform PendingRepMarker;

	public UILabel PendingRepLabel;

	public ClockScript Clock;

	public float Reputation;

	public float PendingRep;

	public int Phase;

	public bool MissionMode;

	public GameObject FlowerVase;

	public GameObject Grafitti;

	private void Start()
	{
		if (Globals.MissionMode)
		{
			this.MissionMode = true;
		}
		this.Reputation = Globals.Reputation;
		this.Bully();
	}

	private void Update()
	{
		if (this.Phase == 1)
		{
			if (this.Clock.PresentTime / 60f > 8.5f)
			{
				this.Reputation += this.PendingRep;
				this.PendingRep = 0f;
				this.Phase++;
				this.StudentManager.WipePendingRep();
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Clock.PresentTime / 60f > 13.5f)
			{
				this.Reputation += this.PendingRep;
				this.PendingRep = 0f;
				this.Phase++;
				this.StudentManager.WipePendingRep();
			}
		}
		else if (this.Phase == 3 && this.Clock.PresentTime / 60f > 18f)
		{
			this.Reputation += this.PendingRep;
			this.PendingRep = 0f;
			this.Phase++;
			this.StudentManager.WipePendingRep();
		}
		if (!this.MissionMode)
		{
			this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, -830f + this.Reputation * 1.5f, Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		else
		{
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, -980f + this.PendingRep * -3f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x < -980f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x < -980f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x > -680f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x > -680f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (!this.MissionMode)
		{
			if (this.PendingRep > 0f)
			{
				this.PendingRepLabel.text = "+" + this.PendingRep.ToString();
			}
			else if (this.PendingRep < 0f)
			{
				this.PendingRepLabel.text = this.PendingRep.ToString();
			}
			else
			{
				this.PendingRepLabel.text = string.Empty;
			}
		}
		else if (this.PendingRep < 0f)
		{
			this.PendingRepLabel.text = (-this.PendingRep).ToString();
		}
		else
		{
			this.PendingRepLabel.text = string.Empty;
		}
	}

	private void Bully()
	{
		int studentReputation = Globals.GetStudentReputation(7);
		this.FlowerVase.SetActive(false);
		this.Grafitti.SetActive(false);
		if (!Globals.GetStudentDead(7))
		{
			if ((float)studentReputation < -33.33333f && (float)studentReputation > -66.66666f)
			{
				this.FlowerVase.SetActive(true);
			}
			else if ((float)studentReputation < -66.66666f)
			{
				this.Grafitti.SetActive(true);
			}
		}
		else
		{
			this.FlowerVase.SetActive(true);
		}
	}
}
