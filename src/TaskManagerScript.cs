using System;
using UnityEngine;

public class TaskManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public GameObject[] TaskObjects;

	public PromptScript[] Prompts;

	private void Start()
	{
		this.UpdateTaskStatus();
	}

	private void Update()
	{
		if (TaskGlobals.GetTaskStatus(6) == 1 && this.Prompts[6].Circle[3].fillAmount == 0f)
		{
			if (this.StudentManager.Students[6] != null)
			{
				this.StudentManager.Students[6].TaskPhase = 5;
			}
			TaskGlobals.SetTaskStatus(6, 2);
			UnityEngine.Object.Destroy(this.TaskObjects[6]);
		}
		if (TaskGlobals.GetTaskStatus(15) == 1 && this.Prompts[15].Circle[3] != null && this.Prompts[15].Circle[3].fillAmount == 0f)
		{
			if (this.StudentManager.Students[15] != null)
			{
				this.StudentManager.Students[15].TaskPhase = 5;
			}
			TaskGlobals.SetTaskStatus(15, 2);
			UnityEngine.Object.Destroy(this.TaskObjects[15]);
		}
		if (TaskGlobals.GetTaskStatus(33) == 1 && this.Prompts[33].Circle[3] != null && this.Prompts[33].Circle[3].fillAmount == 0f)
		{
			if (this.StudentManager.Students[33] != null)
			{
				this.StudentManager.Students[33].TaskPhase = 5;
			}
			TaskGlobals.SetTaskStatus(33, 2);
			UnityEngine.Object.Destroy(this.TaskObjects[33]);
		}
		if (!this.Yandere.Talking)
		{
			if (TaskGlobals.GetTaskStatus(32) == 1)
			{
				if (this.Yandere.Inventory.Cigs)
				{
					if (this.StudentManager.Students[32] != null)
					{
						this.StudentManager.Students[32].TaskPhase = 5;
					}
					TaskGlobals.SetTaskStatus(32, 2);
				}
			}
			else if (TaskGlobals.GetTaskStatus(32) == 2 && !this.Yandere.Inventory.Cigs)
			{
				if (this.StudentManager.Students[32] != null)
				{
					this.StudentManager.Students[32].TaskPhase = 4;
				}
				TaskGlobals.SetTaskStatus(32, 1);
			}
		}
	}

	public void UpdateTaskStatus()
	{
		if (TaskGlobals.GetTaskStatus(6) == 1)
		{
			if (this.StudentManager.Students[6] != null)
			{
				if (this.StudentManager.Students[6].TaskPhase == 0)
				{
					this.StudentManager.Students[6].TaskPhase = 4;
				}
				this.TaskObjects[6].SetActive(true);
			}
		}
		else if (this.TaskObjects[6] != null)
		{
			this.TaskObjects[6].SetActive(false);
		}
		if (TaskGlobals.GetTaskStatus(7) == 1 && this.StudentManager.Students[7] != null && this.StudentManager.Students[7].TaskPhase == 0)
		{
			this.StudentManager.Students[7].TaskPhase = 4;
		}
		if (TaskGlobals.GetTaskStatus(13) == 1 && this.StudentManager.Students[13] != null)
		{
			this.StudentManager.Students[13].TaskPhase = 4;
			for (int i = 1; i < 26; i++)
			{
				if (TaskGlobals.GetKittenPhoto(i))
				{
					this.StudentManager.Students[13].TaskPhase = 5;
				}
			}
		}
		if (TaskGlobals.GetTaskStatus(14) == 1)
		{
			if (this.StudentManager.Students[14] != null && this.StudentManager.Students[14].TaskPhase == 0)
			{
				this.StudentManager.Students[14].TaskPhase = 4;
			}
		}
		else if (TaskGlobals.GetTaskStatus(14) == 2 && this.StudentManager.Students[14] != null)
		{
			this.StudentManager.Students[14].TaskPhase = 5;
		}
		if (TaskGlobals.GetTaskStatus(15) == 1)
		{
			if (this.StudentManager.Students[15] != null)
			{
				if (this.StudentManager.Students[15].TaskPhase == 0)
				{
					this.StudentManager.Students[15].TaskPhase = 4;
				}
				this.TaskObjects[15].SetActive(true);
			}
		}
		else if (this.TaskObjects[15] != null)
		{
			this.TaskObjects[15].SetActive(false);
		}
		if (TaskGlobals.GetTaskStatus(32) == 3 && this.StudentManager.Students[32] != null)
		{
			this.StudentManager.Students[32].WaitAnim = "f02_smokeAttempt_00";
			this.StudentManager.Students[32].Cigarette.SetActive(true);
			this.StudentManager.Students[32].Lighter.SetActive(true);
		}
		if (TaskGlobals.GetTaskStatus(33) == 1)
		{
			if (this.StudentManager.Students[33] != null)
			{
				if (this.StudentManager.Students[33].TaskPhase == 0)
				{
					this.StudentManager.Students[33].TaskPhase = 4;
				}
				this.TaskObjects[33].SetActive(true);
			}
		}
		else if (this.TaskObjects[33] != null)
		{
			this.TaskObjects[33].SetActive(false);
		}
	}
}
