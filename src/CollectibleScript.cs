using System;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string Name = string.Empty;

	public int ID;

	private void Start()
	{
		if (PlayerPrefs.GetInt(this.Name + "_" + this.ID.ToString() + "_Collected") == 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= 0f)
		{
			PlayerPrefs.SetInt(this.Name + "_" + this.ID.ToString() + "_Collected", 1);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
