using System;
using UnityEngine;

[Serializable]
public class RadioScript : MonoBehaviour
{
	public GameObject AlarmDisc;

	public Renderer MyRenderer;

	public Texture OffTexture;

	public Texture OnTexture;

	public StudentScript Victim;

	public PromptScript Prompt;

	public bool On;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.On)
			{
				this.MyRenderer.material.mainTexture = this.OnTexture;
				this.audio.Play();
				this.On = true;
			}
			else
			{
				this.TurnOff();
			}
		}
		if (this.On && this.Victim == null)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AlarmDisc, this.transform.position + Vector3.up, Quaternion.identity);
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).SourceRadio = this;
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).NoScream = true;
			((AlarmDiscScript)gameObject.GetComponent(typeof(AlarmDiscScript))).Radio = true;
		}
	}

	public virtual void TurnOff()
	{
		this.MyRenderer.material.mainTexture = this.OffTexture;
		this.Victim = null;
		this.audio.Stop();
		this.On = false;
	}

	public virtual void Main()
	{
	}
}
