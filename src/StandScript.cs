using System;
using UnityEngine;

[Serializable]
public class StandScript : MonoBehaviour
{
	public int Phase;

	public virtual void Update()
	{
		if (this.Phase == 0 && this.gameObject.animation["StandSummon"].time >= this.gameObject.animation["StandSummon"].length)
		{
			this.gameObject.animation.CrossFade("StandIdle");
			this.Phase++;
		}
	}

	public virtual void Main()
	{
	}
}
