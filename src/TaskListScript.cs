using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TaskListScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UpdateTaskInfo$2566 : GenericGenerator<WWW>
	{
		internal TaskListScript $self_$2572;

		public $UpdateTaskInfo$2566(TaskListScript self_)
		{
			this.$self_$2572 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new TaskListScript.$UpdateTaskInfo$2566.$(this.$self_$2572);
		}
	}

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public GameObject MainMenu;

	public UITexture StudentIcon;

	public UITexture TaskIcon;

	public UILabel TaskDesc;

	public Texture QuestionMark;

	public Transform Highlight;

	public Texture Silhouette;

	public UILabel[] TaskNameLabels;

	public UISprite[] Checkmarks;

	public Texture[] TaskIcons;

	public string[] TaskDescs;

	public string[] TaskNames;

	public int ID;

	public TaskListScript()
	{
		this.ID = 1;
	}

	public virtual void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.ID--;
			if (this.ID < 1)
			{
				this.ID = 16;
			}
			this.StartCoroutine_Auto(this.UpdateTaskInfo());
		}
		if (this.InputManager.TappedDown)
		{
			this.ID++;
			if (this.ID > 16)
			{
				this.ID = 1;
			}
			this.StartCoroutine_Auto(this.UpdateTaskInfo());
		}
		if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			this.MainMenu.active = true;
			this.active = false;
		}
	}

	public virtual void UpdateTaskList()
	{
		for (int i = 1; i < Extensions.get_length(this.TaskNames); i++)
		{
			if (PlayerPrefs.GetInt("Task_" + i + "_Status") == 0)
			{
				this.TaskNameLabels[i].text = "?????";
			}
			else
			{
				this.TaskNameLabels[i].text = this.TaskNames[i];
			}
			if (PlayerPrefs.GetInt("Task_" + i + "_Status") == 3)
			{
				this.Checkmarks[i].enabled = true;
			}
			else
			{
				this.Checkmarks[i].enabled = false;
			}
		}
	}

	public virtual IEnumerator UpdateTaskInfo()
	{
		return new TaskListScript.$UpdateTaskInfo$2566(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
