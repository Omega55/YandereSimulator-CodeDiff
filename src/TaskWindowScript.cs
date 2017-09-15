using System;
using UnityEngine;

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

	private void Start()
	{
		this.Window.SetActive(false);
	}

	public void UpdateWindow(int ID)
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Accept";
		this.PromptBar.Label[1].text = "Refuse";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.TaskDescLabel.transform.parent.gameObject.SetActive(true);
		this.TaskDescLabel.text = this.Descriptions[ID];
		this.Icon.mainTexture = this.Icons[ID];
		this.Window.SetActive(true);
		this.GetPortrait(ID);
		this.StudentID = ID;
	}

	private void Update()
	{
		if (this.Window.activeInHierarchy)
		{
			if (Input.GetButtonDown("A"))
			{
				TaskGlobals.SetTaskStatus(this.StudentID, 1);
				this.Yandere.TargetStudent.TalkTimer = 100f;
				this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
				this.Yandere.TargetStudent.TaskPhase = 4;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Window.SetActive(false);
			}
			else if (Input.GetButtonDown("B"))
			{
				this.Yandere.TargetStudent.TalkTimer = 100f;
				this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
				this.Yandere.TargetStudent.TaskPhase = 0;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Window.SetActive(false);
			}
		}
		if (this.TaskComplete)
		{
			if (this.TrueTimer == 0f)
			{
				base.GetComponent<AudioSource>().Play();
			}
			this.TrueTimer += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.ID < this.TaskCompleteLetters.Length && this.Timer > 0.05f)
			{
				this.TaskCompleteLetters[this.ID].SetActive(true);
				this.Timer = 0f;
				this.ID++;
			}
			if (this.TaskCompleteLetters[12].transform.localPosition.y < -725f)
			{
				this.ID = 0;
				while (this.ID < this.TaskCompleteLetters.Length)
				{
					this.TaskCompleteLetters[this.ID].GetComponent<GrowShrinkScript>().Return();
					this.ID++;
				}
				this.TaskCheck();
				this.DialogueWheel.End();
				this.TaskComplete = false;
				this.TrueTimer = 0f;
				this.Timer = 0f;
				this.ID = 0;
			}
		}
	}

	private void TaskCheck()
	{
		if (this.Yandere.TargetStudent.StudentID == 15)
		{
			this.DialogueWheel.Yandere.TargetStudent.Cosmetic.MaleAccessories[1].SetActive(true);
		}
	}

	private void GetPortrait(int ID)
	{
		string url = string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			ID.ToString(),
			".png"
		});
		WWW www = new WWW(url);
		this.Portrait.mainTexture = www.texture;
	}
}
