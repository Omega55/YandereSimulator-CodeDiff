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
				this.Return();
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
			else if (this.Yandere.Laughing)
			{
				this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3((float)0, 0.2f, -0.4f), Time.deltaTime * (float)10);
				float x = Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 22.5f, Time.deltaTime * (float)10);
				Vector3 localEulerAngles = this.Stand.transform.localEulerAngles;
				float num = localEulerAngles.x = x;
				Vector3 vector = this.Stand.transform.localEulerAngles = localEulerAngles;
				this.Stand.animation.CrossFade("StandAttack");
			}
			else
			{
				this.Return();
				this.Stand.animation.CrossFade("StandIdle");
			}
		}
	}

	public virtual void Return()
	{
		this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3((float)0, (float)0, -0.5f), Time.deltaTime * (float)10);
		float x = Mathf.Lerp(this.Stand.transform.localEulerAngles.x, (float)0, Time.deltaTime * (float)10);
		Vector3 localEulerAngles = this.Stand.transform.localEulerAngles;
		float num = localEulerAngles.x = x;
		Vector3 vector = this.Stand.transform.localEulerAngles = localEulerAngles;
	}

	public virtual void Main()
	{
	}
}
