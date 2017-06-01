using System;
using UnityEngine;

[Serializable]
public class StandScript : MonoBehaviour
{
	public AmplifyMotionEffect MotionBlur;

	public FalconPunchScript FalconPunch;

	public StandPunchScript StandPunch;

	public Transform SummonTransform;

	public GameObject SummonEffect;

	public GameObject StandCamera;

	public YandereScript Yandere;

	public GameObject Stand;

	public Transform[] Hands;

	public int FinishPhase;

	public int Finisher;

	public int Weapons;

	public int Phase;

	public virtual void Update()
	{
		if (!this.Stand.active)
		{
			if (this.Weapons == 8 && this.Yandere.transform.position.y > 11.9f && Input.GetButtonDown("RB"))
			{
				this.Yandere.Jojo();
			}
		}
		else if (this.Phase == 0)
		{
			if (this.Stand.animation["StandSummon"].time >= (float)2 && this.Stand.animation["StandSummon"].time <= 2.5f)
			{
				UnityEngine.Object.Instantiate(this.SummonEffect, this.SummonTransform.position, Quaternion.identity);
			}
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
			else if (this.Yandere.RPGCamera.enabled)
			{
				if (this.Yandere.Laughing)
				{
					if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3((float)0, 0.2f, -0.4f)) > 0.01f)
					{
						this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3((float)0, 0.2f, 0.1f), Time.deltaTime * (float)10);
						float x = Mathf.Lerp(this.Stand.transform.localEulerAngles.x, 22.5f, Time.deltaTime * (float)10);
						Vector3 localEulerAngles = this.Stand.transform.localEulerAngles;
						float num = localEulerAngles.x = x;
						Vector3 vector = this.Stand.transform.localEulerAngles = localEulerAngles;
					}
					this.Stand.animation.CrossFade("StandAttack");
					this.StandPunch.MyCollider.enabled = true;
				}
				else if (this.Phase == 1)
				{
					this.audio.Play();
					this.Finisher = UnityEngine.Random.Range(1, 3);
					this.Stand.animation.CrossFade("StandFinisher" + this.Finisher);
					this.Phase++;
				}
				else if (this.Phase == 2)
				{
					if (this.Stand.animation["StandFinisher" + this.Finisher].time >= 0.5f)
					{
						this.FalconPunch.MyCollider.enabled = true;
						this.StandPunch.MyCollider.enabled = false;
						this.Phase++;
					}
				}
				else if (this.Phase == 3 && (this.StandPunch.MyCollider.enabled || this.Stand.animation["StandFinisher" + this.Finisher].time >= this.Stand.animation["StandFinisher" + this.Finisher].length))
				{
					this.Stand.animation.CrossFade("StandIdle");
					this.FalconPunch.MyCollider.enabled = false;
					this.Yandere.CanMove = true;
					this.Phase = 1;
				}
			}
		}
	}

	public virtual void Spawn()
	{
		this.FalconPunch.MyCollider.enabled = false;
		this.StandPunch.MyCollider.enabled = false;
		this.StandCamera.active = true;
		this.MotionBlur.enabled = true;
		this.Stand.active = true;
	}

	public virtual void Return()
	{
		if (Vector3.Distance(this.Stand.transform.localPosition, new Vector3((float)0, (float)0, -0.5f)) > 0.01f)
		{
			this.Stand.transform.localPosition = Vector3.Lerp(this.Stand.transform.localPosition, new Vector3((float)0, (float)0, -0.5f), Time.deltaTime * (float)10);
			float x = Mathf.Lerp(this.Stand.transform.localEulerAngles.x, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.Stand.transform.localEulerAngles;
			float num = localEulerAngles.x = x;
			Vector3 vector = this.Stand.transform.localEulerAngles = localEulerAngles;
		}
	}

	public virtual void Main()
	{
	}
}
