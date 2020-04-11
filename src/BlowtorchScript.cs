using System;
using UnityEngine;

public class BlowtorchScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public Transform Flame;

	public float Timer;

	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
		float num = Random.Range(0.9f, 1f);
		this.Flame.localScale = new Vector3(num, num, num);
		if (this.Timer == 5f)
		{
			this.Flame.localScale = Vector3.zero;
			this.Yandere.Cauterizing = false;
			this.Yandere.CanMove = true;
			base.enabled = false;
			base.GetComponent<AudioSource>().Stop();
			this.Timer = 0f;
		}
	}
}
