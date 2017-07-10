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
		if (PlayerPrefs.GetInt("Task_6_Status") == 1 && this.Prompts[6].Circle[3].fillAmount <= 0f)
		{
			if (this.StudentManager.Students[6] != null)
			{
				this.StudentManager.Students[6].TaskPhase = 5;
			}
			PlayerPrefs.SetInt("Task_6_Status", 2);
			UnityEngine.Object.Destroy(this.TaskObjects[6]);
		}
		if (PlayerPrefs.GetInt("Task_15_Status") == 1 && this.Prompts[15].Circle[3] != null && this.Prompts[15].Circle[3].fillAmount <= 0f)
		{
			if (this.StudentManager.Students[15] != null)
			{
				this.StudentManager.Students[15].TaskPhase = 5;
			}
			PlayerPrefs.SetInt("Task_15_Status", 2);
			UnityEngine.Object.Destroy(this.TaskObjects[15]);
		}
		if (PlayerPrefs.GetInt("Task_33_Status") == 1 && this.Prompts[33].Circle[3] != null && this.Prompts[33].Circle[3].fillAmount <= 0f)
		{
			if (this.StudentManager.Students[33] != null)
			{
				this.StudentManager.Students[33].TaskPhase = 5;
			}
			PlayerPrefs.SetInt("Task_33_Status", 2);
			UnityEngine.Object.Destroy(this.TaskObjects[33]);
		}
		if (!this.Yandere.Talking)
		{
			if (PlayerPrefs.GetInt("Task_32_Status") == 1)
			{
				if (this.Yandere.Inventory.Cigs)
				{
					if (this.StudentManager.Students[32] != null)
					{
						this.StudentManager.Students[32].TaskPhase = 5;
					}
					PlayerPrefs.SetInt("Task_32_Status", 2);
				}
			}
			else if (PlayerPrefs.GetInt("Task_32_Status") == 2 && !this.Yandere.Inventory.Cigs)
			{
				if (this.StudentManager.Students[32] != null)
				{
					this.StudentManager.Students[32].TaskPhase = 4;
				}
				PlayerPrefs.SetInt("Task_32_Status", 1);
			}
		}
	}

	public void UpdateTaskStatus()
	{
		if (PlayerPrefs.GetInt("Task_6_Status") == 1)
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
		if (PlayerPrefs.GetInt("Task_7_Status") == 1 && this.StudentManager.Students[7] != null && this.StudentManager.Students[7].TaskPhase == 0)
		{
			this.StudentManager.Students[7].TaskPhase = 4;
		}
		if (PlayerPrefs.GetInt("Task_13_Status") == 1 && this.StudentManager.Students[13] != null)
		{
			this.StudentManager.Students[13].TaskPhase = 4;
			for (int i = 1; i < 26; i++)
			{
				if (PlayerPrefs.GetInt("KittenPhoto_" + i.ToString()) == 1)
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
				this.TaskObjects[15].SetActive(true);
			}
		}
		else if (this.TaskObjects[15] != null)
		{
			this.TaskObjects[15].SetActive(false);
		}
		if (PlayerPrefs.GetInt("Task_33_Status") == 1)
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
