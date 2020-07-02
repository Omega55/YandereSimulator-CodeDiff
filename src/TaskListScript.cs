using System;
using System.Collections;
using UnityEngine;

public class TaskListScript : MonoBehaviour
{
	public TutorialWindowScript TutorialWindow;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public TaskWindowScript TaskWindow;

	public JsonScript JSON;

	public GameObject MainMenu;

	public UITexture StudentIcon;

	public UITexture TaskIcon;

	public UILabel TaskDesc;

	public Texture QuestionMark;

	public Transform Highlight;

	public Texture Silhouette;

	public UILabel[] TaskNameLabels;

	public UISprite[] Checkmarks;

	public Texture[] TutorialTextures;

	public string[] TutorialDescs;

	public string[] TutorialNames;

	public int ListPosition;

	public int Limit = 84;

	public int ID = 1;

	public bool Tutorials;

	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			if (this.ID == 1)
			{
				this.ListPosition--;
				if (this.ListPosition < 0)
				{
					this.ListPosition = this.Limit - 16;
					this.ID = 16;
				}
			}
			else
			{
				this.ID--;
			}
			this.UpdateTaskList();
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.InputManager.TappedDown)
		{
			if (this.ID == 16)
			{
				this.ListPosition++;
				if (this.ID + this.ListPosition > this.Limit)
				{
					this.ListPosition = 0;
					this.ID = 1;
				}
			}
			else
			{
				this.ID++;
			}
			this.UpdateTaskList();
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.Tutorials)
		{
			if (!this.TutorialWindow.Hide && !this.TutorialWindow.Show)
			{
				if (Input.GetButtonDown("A"))
				{
					OptionGlobals.TutorialsOff = false;
					this.TutorialWindow.ForceID = this.ListPosition + this.ID;
					this.TutorialWindow.ShowTutorial();
					this.TutorialWindow.enabled = true;
					this.TutorialWindow.SummonWindow();
				}
				if (Input.GetButtonDown("B"))
				{
					this.Exit();
					return;
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.Exit();
		}
	}

	public void UpdateTaskList()
	{
		if (this.Tutorials)
		{
			for (int i = 1; i < this.TaskNameLabels.Length; i++)
			{
				this.TaskNameLabels[i].text = this.TutorialNames[i + this.ListPosition];
			}
			return;
		}
		for (int j = 1; j < this.TaskNameLabels.Length; j++)
		{
			if (TaskGlobals.GetTaskStatus(j + this.ListPosition) == 0)
			{
				this.TaskNameLabels[j].text = "Undiscovered Task #" + (j + this.ListPosition);
			}
			else
			{
				this.TaskNameLabels[j].text = this.JSON.Students[j + this.ListPosition].Name + "'s Task";
			}
			this.Checkmarks[j].enabled = (TaskGlobals.GetTaskStatus(j + this.ListPosition) == 3);
		}
	}

	public IEnumerator UpdateTaskInfo()
	{
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		if (this.Tutorials)
		{
			this.TaskIcon.mainTexture = this.TutorialTextures[this.ID + this.ListPosition];
			this.TaskDesc.text = "This tutorial will teach you about " + this.TutorialNames[this.ID + this.ListPosition];
		}
		else if (TaskGlobals.GetTaskStatus(this.ID + this.ListPosition) == 0)
		{
			this.StudentIcon.mainTexture = this.Silhouette;
			this.TaskIcon.mainTexture = this.QuestionMark;
			this.TaskDesc.text = "This task has not been discovered yet.";
		}
		else
		{
			string url = string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				(this.ID + this.ListPosition).ToString(),
				".png"
			});
			WWW www = new WWW(url);
			yield return www;
			this.StudentIcon.mainTexture = www.texture;
			this.TaskWindow.AltGenericCheck(this.ID + this.ListPosition);
			if (this.TaskWindow.Generic)
			{
				this.TaskIcon.mainTexture = this.TaskWindow.Icons[0];
				this.TaskDesc.text = this.TaskWindow.Descriptions[0];
			}
			else
			{
				this.TaskIcon.mainTexture = this.TaskWindow.Icons[this.ID + this.ListPosition];
				this.TaskDesc.text = this.TaskWindow.Descriptions[this.ID + this.ListPosition];
			}
			www = null;
		}
		yield break;
	}

	public void Exit()
	{
		this.PauseScreen.PromptBar.ClearButtons();
		this.PauseScreen.PromptBar.Label[0].text = "Accept";
		this.PauseScreen.PromptBar.Label[1].text = "Back";
		this.PauseScreen.PromptBar.Label[4].text = "Choose";
		this.PauseScreen.PromptBar.Label[5].text = "Choose";
		this.PauseScreen.PromptBar.UpdateButtons();
		this.PauseScreen.Sideways = false;
		this.PauseScreen.PressedB = true;
		this.MainMenu.SetActive(true);
		base.gameObject.SetActive(false);
	}
}
