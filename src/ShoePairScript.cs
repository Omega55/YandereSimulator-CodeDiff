using System;
using UnityEngine;

public class ShoePairScript : MonoBehaviour
{
	public PoliceScript Police;

	public PromptScript Prompt;

	public GameObject Note;

	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		if (Globals.LanguageGrade + Globals.LanguageBonus < 1)
		{
			this.Prompt.enabled = false;
		}
		this.Note.SetActive(false);
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Police.Suicide = true;
			this.Note.SetActive(true);
		}
	}
}
