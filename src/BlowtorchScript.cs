using System;
using UnityEngine;

[Serializable]
public class BlowtorchScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public Transform Flame;

	public float Timer;

	public virtual void Start()
	{
		this.Flame.localScale = new Vector3((float)0, (float)0, (float)0);
		this.enabled = false;
	}

	public virtual void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, (float)5, Time.deltaTime);
		float num = UnityEngine.Random.Range(0.9f, 1f);
		this.Flame.localScale = new Vector3(num, num, num);
		if (this.Timer == (float)5)
		{
			this.Flame.localScale = new Vector3((float)0, (float)0, (float)0);
			this.Yandere.Cauterizing = false;
			this.Yandere.CanMove = true;
			this.enabled = false;
			this.audio.Stop();
			this.Timer = (float)0;
		}
	}

	public virtual void Main()
	{
	}
}
