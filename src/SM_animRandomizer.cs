using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SM_animRandomizer : MonoBehaviour
{
	public AnimationClip[] animList;

	public AnimationClip actualAnim;

	public float minSpeed;

	public float maxSpeed;

	public SM_animRandomizer()
	{
		this.minSpeed = 0.7f;
		this.maxSpeed = 1.5f;
	}

	public virtual void Start()
	{
		float num = Mathf.Round((float)UnityEngine.Random.Range(0, Extensions.get_length(this.animList)));
		this.actualAnim = this.animList[(int)num];
		this.animation.Play(this.actualAnim.name);
		this.animation[this.actualAnim.name].speed = UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
	}

	public virtual void Main()
	{
	}
}
