using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RandomAnimScript : MonoBehaviour
{
	public string[] AnimationNames;

	public string CurrentAnim;

	public RandomAnimScript()
	{
		this.CurrentAnim = string.Empty;
	}

	public virtual void Start()
	{
		this.PickRandomAnim();
		this.animation.CrossFade(this.CurrentAnim);
	}

	public virtual void Update()
	{
		if (this.animation[this.CurrentAnim].time >= this.animation[this.CurrentAnim].length)
		{
			this.PickRandomAnim();
		}
	}

	public virtual void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, Extensions.get_length(this.AnimationNames))];
		this.animation.CrossFade(this.CurrentAnim);
	}

	public virtual void Main()
	{
	}
}
