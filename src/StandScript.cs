using System;
using UnityEngine;

[Serializable]
public class StandScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Stand;

	public int Phase;

	public virtual void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Stand.animation["StandSummon"].time >= this.Stand.animation["StandSummon"].length)
			{
				this.Stand.animation.CrossFade("StandIdle");
				this.Phase++;
			}
		}
		else
		{
			float axis = Input.GetAxis("Vertical");
			float axis2 = Input.GetAxis("Horizontal");
			if (this.Yandere.CanMove)
			{
				if (axis != (float)0 || axis2 != (float)0)
				{
					if (Input.GetButton("LB"))
					{
						this.Stand.animation.CrossFade("StandRun");
					}
					else
					{
						this.Stand.animation.CrossFade("StandWalk");
					}
				}
				else
				{
					this.Stand.animation.CrossFade("StandIdle");
				}
			}
			else
			{
				this.Stand.animation.CrossFade("StandIdle");
			}
		}
	}

	public virtual void Main()
	{
	}
}
