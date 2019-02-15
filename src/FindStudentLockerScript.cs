using System;
using UnityEngine;

public class FindStudentLockerScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.PauseScreen.StudentInfoMenu.FindingLocker = true;
			this.Prompt.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
			this.Prompt.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
			this.Prompt.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
			this.Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
			this.Prompt.StartCoroutine(this.Prompt.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
			this.Prompt.Yandere.PauseScreen.MainMenu.SetActive(false);
			this.Prompt.Yandere.PauseScreen.Panel.enabled = true;
			this.Prompt.Yandere.PauseScreen.Sideways = true;
			this.Prompt.Yandere.PauseScreen.Show = true;
			Time.timeScale = 0.0001f;
			this.Prompt.Yandere.PromptBar.ClearButtons();
			this.Prompt.Yandere.PromptBar.Label[1].text = "Cancel";
			this.Prompt.Yandere.PromptBar.UpdateButtons();
			this.Prompt.Yandere.PromptBar.Show = true;
		}
	}
}
