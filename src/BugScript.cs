using System;
using UnityEngine;

public class BugScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Renderer MyRenderer;

	public AudioSource MyAudio;

	public AudioClip[] Praise;

	private void Start()
	{
		this.MyRenderer.enabled = false;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.MyAudio.clip = this.Praise[Random.Range(0, this.Praise.Length)];
			this.MyAudio.Play();
			this.MyRenderer.enabled = true;
			this.Prompt.Yandere.Inventory.PantyShots += 5;
			base.enabled = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}
}
