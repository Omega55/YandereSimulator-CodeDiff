using System;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
	public GameObject AlarmDisc;

	public Renderer MyRenderer;

	public Texture OffTexture;

	public Texture OnTexture;

	public StudentScript Victim;

	public PromptScript Prompt;

	public float CooldownTimer;

	public bool On;

	private void Update()
	{
		if (this.CooldownTimer > 0f)
		{
			this.CooldownTimer = Mathf.MoveTowards(this.CooldownTimer, 0f, Time.deltaTime);
			if (this.CooldownTimer == 0f)
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			UISprite uisprite = this.Prompt.Circle[0];
			if (uisprite.fillAmount == 0f)
			{
				uisprite.fillAmount = 1f;
				if (!this.On)
				{
					this.MyRenderer.material.mainTexture = this.OnTexture;
					base.GetComponent<AudioSource>().Play();
					this.On = true;
				}
				else
				{
					this.CooldownTimer = 1f;
					this.TurnOff();
				}
			}
		}
		if (this.On && this.Victim == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
			AlarmDiscScript component = gameObject.GetComponent<AlarmDiscScript>();
			component.SourceRadio = this;
			component.NoScream = true;
			component.Radio = true;
		}
	}

	public void TurnOff()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
		this.MyRenderer.material.mainTexture = this.OffTexture;
		this.Victim = null;
		base.GetComponent<AudioSource>().Stop();
		this.On = false;
	}
}
