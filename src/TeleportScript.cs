using System;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform Destination;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
		}
	}
}
