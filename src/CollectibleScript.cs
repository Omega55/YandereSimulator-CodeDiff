using System;
using UnityEngine;

[Serializable]
public class CollectibleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string Name;

	public int ID;

	public CollectibleScript()
	{
		this.Name = string.Empty;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt(this.Name + "_" + this.ID + "_Collected") == 1)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			PlayerPrefs.SetInt(this.Name + "_" + this.ID + "_Collected", 1);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
