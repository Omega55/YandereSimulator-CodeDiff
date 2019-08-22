using System;
using System.Collections;
using UnityEngine;

public class TaskListScript : MonoBehaviour
{
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

	public int ListPosition;

	public int ID = 1;

	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			if (this.ID == 1)
			{
				this.ListPosition--;
				if (this.ListPosition < 0)
				{
					this.ListPosition = 84;
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
				if (this.ListPosition > 84)
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
		if (Input.GetButtonDown("B"))
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

	public void UpdateTaskList()
	{
		for (int i = 1; i < this.TaskNameLabels.Length; i++)
		{
			if (TaskGlobals.GetTaskStatus(i + this.ListPosition) == 0)
			{
				this.TaskNameLabels[i].text = "Undiscovered Task #" + (i + this.ListPosition);
			}
			else
			{
				this.TaskNameLabels[i].text = this.JSON.Students[i + this.ListPosition].Name + "'s Task";
			}
			this.Checkmarks[i].enabled = (TaskGlobals.GetTaskStatus(i + this.ListPosition) == 3);
		}
	}

	public IEnumerator UpdateTaskInfo()
	{
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		if (TaskGlobals.GetTaskStatus(this.ID + this.ListPosition) == 0)
		{
			this.StudentIcon.mainTexture = this.Silhouette;
			this.TaskIcon.mainTexture = this.QuestionMark;
			this.TaskDesc.text = "This task has not been discovered yet.";
		}
		else
		{
			string path = string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				(this.ID + this.ListPosition).ToString(),
				".png"
			});
			WWW www = new WWW(path);
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
		}
		yield break;
	}
}
