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
		if (PlayerPrefs.GetInt("Task_15_Status") == 1 && this.Prompts[15].Circle[3] != null && this.Prompts[15].Circle[3].fillAmount <= (float)0)
		{
			if (this.StudentManager.Students[15] != null)
			{
				this.StudentManager.Students[15].TaskPhase = 5;
			}
			PlayerPrefs.SetInt("Task_15_Status", 2);
			UnityEngine.Object.Destroy(this.TaskObjects[15]);
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
		if (PlayerPrefs.GetInt("Task_13_Status") == 1 && this.StudentManager.Students[13] != null)
		{
			this.StudentManager.Students[13].TaskPhase = 4;
			for (int i = 1; i < 26; i++)
			{
				if (PlayerPrefs.GetInt("KittenPhoto_" + i) == 1)
				{
					this.StudentManager.Students[13].TaskPhase = 5;
				}
			}
		}
		if (PlayerPrefs.GetInt("Task_14_Status") == 1)
		{
			if (this.StudentManager.Students[14] != null && this.StudentManager.Students[14].TaskPhase == 0)
			{
				this.StudentManager.Students[14].TaskPhase = 4;
			}
		}
		else if (PlayerPrefs.GetInt("Task_14_Status") == 2 && this.StudentManager.Students[14] != null)
		{
			this.StudentManager.Students[14].TaskPhase = 5;
		}
		if (PlayerPrefs.GetInt("Task_15_Status") == 1)
		{
			if (this.StudentManager.Students[15] != null)
			{
				if (this.StudentManager.Students[15].TaskPhase == 0)
				{
					this.StudentManager.Students[15].TaskPhase = 4;
				}
				this.TaskObjects[15].active = true;
			}
		}
		else if (this.TaskObjects[15] != null)
		{
			this.TaskObjects[15].active = false;
		}
	}

	public virtual void Main()
	{
	}
}
