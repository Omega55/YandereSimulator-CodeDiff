using System;
using UnityEngine;

[Serializable]
public class ShoePairScript : MonoBehaviour
{
	public PoliceScript Police;

	public PromptScript Prompt;

	public GameObject Note;

	public virtual void Start()
	{
		this.Police = (PoliceScript)GameObject.Find("Police").GetComponent(typeof(PoliceScript));
		if (PlayerPrefs.GetInt("LanguageGrade") < 2)
		{
			this.Prompt.enabled = false;
		}
		this.Note.active = false;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Police.Suicide = true;
			this.Note.active = true;
		}
	}

	public virtual void Main()
	{
	}
}
