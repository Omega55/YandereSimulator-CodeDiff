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
			PlayerPrefs.SetInt("Task_6_Status", 2);
			UnityEngine.Object.Destroy(this.TaskObjects[6]);
		}
	}

	public virtual void UpdateTaskStatus()
	{
		if (PlayerPrefs.GetInt("Task_6_Status") == 1)
		{
			if (this.StudentManager.Students[6] != null)
			{
				this.StudentManager.Students[6].TaskPhase = 5;
				this.TaskObjects[6].active = true;
			}
		}
		else if (this.TaskObjects[6] != null)
		{
			this.TaskObjects[6].active = false;
		}
	}

	public virtual void Main()
	{
	}
}
