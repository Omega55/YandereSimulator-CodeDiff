using System;
using UnityEngine;

[Serializable]
public class TaskManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public GameObject[] TaskObjects;

	public PromptScript[] Prompts;

	public virtual void Start()
	{
		this.UpdateTaskStatus();
	}

	public virtual void Update()
	{
		if (PlayerPrefs.GetInt("Task_6_Status") == 1 && this.Prompts[6].Circle[3].fillAmount <= (float)0)
		{
			if (this.StudentManager.Students[6] != null)
			{
				this.StudentManager.Students[6].TaskPhase = 5;
			}
			PlayerPrefs.SetInt("Task_6_Status", 2);
			UnityEngine.Object.Destroy(this.TaskObjects[6]);
		}
		if (!this.Yandere.Talking)
		{
			if (PlayerPrefs.GetInt("Task_32_Status") == 1 && this.Yandere.Inventory.Cigs)
			{
				if (this.StudentManager.Students[32] != null)
				{
					this.StudentManager.Students[32].TaskPhase = 5;
				}
				PlayerPrefs.SetInt("Task_32_Status", 2);
			}
			if (PlayerPrefs.GetInt("Task_32_Status") == 2 && !this.Yandere.Inventory.Cigs)
			{
				if (this.StudentManager.Students[32] != null)
				{
					this.StudentManager.Students[32].TaskPhase = 4;
				}
				PlayerPrefs.SetInt("Task_32_Status", 1);
			}
		}
	}

	public virtual void UpdateTaskStatus()
	{
		if (PlayerPrefs.GetInt("Task_6_Status") == 1)
		{
			if (this.StudentManager.Students[6] != null)
			{
				if (this.StudentManager.Students[6].TaskPhase == 0)
				{
					this.StudentManager.Students[6].TaskPhase = 4;
				}
				this.TaskObjects[6].active = true;
			}
		}
		else if (this.TaskObjects[6] != null)
		{
			this.TaskObjects[6].active = false;
		}
		if (PlayerPrefs.GetInt("Task_7_Status") == 1 && this.StudentManager.Students[7] != null && this.StudentManager.Students[7].TaskPhase == 0)
		{
			this.StudentManager.Students[7].TaskPhase = 4;
		}
	}

	public virtual void Main()
	{
	}
}
