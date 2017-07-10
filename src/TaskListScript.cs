using System;
using System.Collections;
using UnityEngine;

public class TaskListScript : MonoBehaviour
{
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

	public int ID = 1;

	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.ID--;
			if (this.ID < 1)
			{
				this.ID = 16;
			}
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.InputManager.TappedDown)
		{
			this.ID++;
			if (this.ID > 16)
			{
				this.ID = 1;
			}
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			this.MainMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	public void UpdateTaskList()
	{
		for (int i = 1; i < this.TaskNames.Length; i++)
		{
			this.TaskNameLabels[i].text = ((PlayerPrefs.GetInt("Task_" + i.ToString() + "_Status") != 0) ? this.TaskNames[i] : "?????");
			this.Checkmarks[i].enabled = (PlayerPrefs.GetInt("Task_" + i + "_Status") == 3);
		}
	}

	public IEnumerator UpdateTaskInfo()
	{
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		if (PlayerPrefs.GetInt("Task_" + this.ID.ToString() + "_Status") == 0)
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
				this.ID.ToString(),
				".png"
			});
			WWW www = new WWW(path);
			yield return www;
			this.StudentIcon.mainTexture = www.texture;
			this.TaskIcon.mainTexture = this.TaskIcons[this.ID];
			this.TaskDesc.text = this.TaskDescs[this.ID];
		}
		yield break;
	}
}
