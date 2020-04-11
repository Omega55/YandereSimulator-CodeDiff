using System;
using UnityEngine;

public class MusicAudienceScript : MonoBehaviour
{
	public MusicMinigameScript MusicMinigame;

	public float JumpStrength;

	public float Threshold;

	public float Minimum;

	public float Jump;

	private void Start()
	{
		this.JumpStrength += Random.Range(-0.0001f, 0.0001f);
	}

	private void Update()
	{
		if (this.MusicMinigame.Health >= this.Threshold)
		{
			this.Minimum = Mathf.MoveTowards(this.Minimum, 0.2f, Time.deltaTime * 0.1f);
		}
		else
		{
			this.Minimum = Mathf.MoveTowards(this.Minimum, 0f, Time.deltaTime * 0.1f);
		}
		base.transform.localPosition += new Vector3(0f, this.Jump, 0f);
		this.Jump -= Time.deltaTime * 0.01f;
		if (base.transform.localPosition.y < this.Minimum)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.Minimum, 0f);
			this.Jump = this.JumpStrength;
		}
	}
}
