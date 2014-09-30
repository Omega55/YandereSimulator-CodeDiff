using System;
using UnityEngine;

[Serializable]
public class SM_animSpeedRandomizer : MonoBehaviour
{
	public float minSpeed;

	public float maxSpeed;

	public SM_animSpeedRandomizer()
	{
		this.minSpeed = 0.7f;
		this.maxSpeed = 1.5f;
	}

	public virtual void Start()
	{
		this.animation[this.animation.clip.name].speed = UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
	}

	public virtual void Main()
	{
	}
}
