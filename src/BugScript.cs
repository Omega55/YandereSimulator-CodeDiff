using System;
using UnityEngine;

public class BugScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Renderer MyRenderer;

	private void Start()
	{
		this.MyRenderer.enabled = false;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.MyRenderer.enabled = true;
			Globals.PantyShots += 5;
			base.enabled = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}
}
