using System;
using UnityEngine;

[Serializable]
public class TitleSenpaiScript : MonoBehaviour
{
	public GameObject Character;

	public float BlendWeight;

	public virtual void Update()
	{
		if (this.BlendWeight > (float)0)
		{
			this.Character.animation.Blend("getup_20_p", this.BlendWeight);
			this.BlendWeight -= Time.deltaTime * (float)10;
		}
		else
		{
			this.Character.animation.CrossFade("liedown_05");
		}
	}

	public virtual void Stabbed()
	{
		this.Character.animation["getup_20_p"].time = (float)0;
		this.BlendWeight = (float)1;
	}

	public virtual void Main()
	{
	}
}
