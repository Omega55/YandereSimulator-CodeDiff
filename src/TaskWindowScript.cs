﻿using System;
using UnityEngine;

[Serializable]
public class TaskWindowScript : MonoBehaviour
{
	public DialogueWheelScript DialogueWheel;

	public TaskManagerScript TaskManager;

	public PromptBarScript PromptBar;

	public UILabel TaskDescLabel;

	public YandereScript Yandere;

	public UITexture Portrait;

	public UITexture Icon;

	public GameObject[] TaskCompleteLetters;

	public string[] Descriptions;

	public Texture[] Portraits;

	public Texture[] Icons;

	public bool TaskComplete;

	public GameObject Window;

	public int StudentID;

	public int ID;

	public float TrueTimer;

	public float Timer;

	public virtual void Start()
	{
		this.Window.active = false;
	}

	public virtual void UpdateWindow(int ID)
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Accept";
		this.PromptBar.Label[1].text = "Refuse";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.TaskDescLabel.transform.parent.gameObject.active = true;
		this.TaskDescLabel.text = string.Empty + this.Descriptions[ID];
		this.Portrait.mainTexture = this.Portraits[ID];
		this.Icon.mainTexture = this.Icons[ID];
		this.Window.active = true;
		this.StudentID = ID;
	}

	public virtual void Update()
	{
		if (this.Window.active)
		{
			if (Input.GetButtonDown("A"))
			{
				PlayerPrefs.SetInt("Task_" + this.StudentID + "_Status", 1);
				this.Yandere.TargetStudent.TalkTimer = (float)100;
				this.Yandere.TargetStudent.Interaction = 5;
				this.Yandere.TargetStudent.TaskPhase = 4;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Window.active = false;
			}
			else if (Input.GetButtonDown("B"))
			{
				this.Yandere.TargetStudent.TalkTimer = (float)100;
				this.Yandere.TargetStudent.Interaction = 5;
				this.Yandere.TargetStudent.TaskPhase = 0;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Window.active = false;
			}
		}
		if (this.TaskComplete)
		{
			if (this.TrueTimer == (float)0)
			{
				this.audio.Play();
			}
			this.TrueTimer += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.ID < this.TaskCompleteLetters.Length && this.Timer > 0.05f)
			{
				this.TaskCompleteLetters[this.ID].active = true;
				this.Timer = (float)0;
				this.ID++;
			}
			if (this.TaskCompleteLetters[12].transform.localPosition.y < (float)-725)
			{
				this.ID = 0;
				while (this.ID < this.TaskCompleteLetters.Length)
				{
					((GrowShrinkScript)this.TaskCompleteLetters[this.ID].GetComponent(typeof(GrowShrinkScript))).Return();
					this.ID++;
				}
				this.TaskCheck();
				this.DialogueWheel.End();
				this.TaskComplete = false;
				this.TrueTimer = (float)0;
				this.Timer = (float)0;
				this.ID = 0;
			}
		}
	}

	public virtual void TaskCheck()
	{
		if (this.Yandere.TargetStudent.StudentID == 15)
		{
			this.DialogueWheel.Yandere.TargetStudent.Cosmetic.MaleAccessories[1].active = true;
		}
	}

	public virtual void Main()
	{
	}
}
