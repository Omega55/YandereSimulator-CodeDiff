using System;
using UnityEngine;

public class TaskPickupScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ButtonID = 3;

	private void Update()
	{
		if (this.Prompt.Circle[this.ButtonID].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
		}
	}
}
