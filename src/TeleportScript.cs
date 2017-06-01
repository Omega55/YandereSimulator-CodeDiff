using System;
using UnityEngine;

[Serializable]
public class TeleportScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform Destination;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
		}
	}

	public virtual void Main()
	{
	}
}
