using System;
using UnityEngine;

[Serializable]
public class CassetteScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string Prefix;

	public int ID;

	public CassetteScript()
	{
		this.Prefix = string.Empty;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt(this.Prefix + "Tape_" + this.ID + "_Collected") == 1)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			PlayerPrefs.SetInt(this.Prefix + "Tape_" + this.ID + "_Collected", 1);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
