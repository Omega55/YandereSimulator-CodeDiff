using System;
using UnityEngine;

[Serializable]
public class LoveManagerScript : MonoBehaviour
{
	public ConfessionSceneScript ConfessionScene;

	public StudentManagerScript StudentManager;

	public StudentScript Follower;

	public YandereScript Yandere;

	public ClockScript Clock;

	public Transform[] Targets;

	public Transform MythHill;

	public int SuitorProgress;

	public int TotalTargets;

	public int Phase;

	public int ID;

	public float AngleLimit;

	public bool HoldingHands;

	public bool RivalWaiting;

	public bool LeftNote;

	public bool Courted;

	public LoveManagerScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.SuitorProgress = PlayerPrefs.GetInt("SuitorProgress");
	}

	public virtual void LateUpdate()
	{
		if (this.Follower != null)
		{
			this.ID = 0;
			while (this.ID < this.TotalTargets)
			{
				if (this.Targets[this.ID] != null && this.Follower.transform.position.y > this.Targets[this.ID].position.y - (float)2 && this.Follower.transform.position.y < this.Targets[this.ID].position.y + (float)2 && Vector3.Distance(this.Follower.transform.position, new Vector3(this.Targets[this.ID].position.x, this.Follower.transform.position.y, this.Targets[this.ID].position.z)) < 2.5f)
				{
					float f = Vector3.Angle(this.Follower.transform.forward, this.Follower.transform.position - new Vector3(this.Targets[this.ID].position.x, this.Follower.transform.position.y, this.Targets[this.ID].position.z));
					if (Mathf.Abs(f) > this.AngleLimit)
					{
						if (!this.Follower.Gush)
						{
							this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)1);
							this.Follower.GushTarget = this.Targets[this.ID];
							this.Follower.Hearts.enableEmission = true;
							this.Follower.Hearts.emissionRate = (float)5;
							this.Follower.Hearts.Play();
							this.Follower.Gush = true;
						}
					}
					else
					{
						this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)0);
						this.Follower.Hearts.enableEmission = false;
						this.Follower.Gush = false;
					}
				}
				this.ID++;
			}
		}
		if (this.LeftNote && this.StudentManager.Students[7] != null && this.StudentManager.Students[13] != null && this.StudentManager.Students[7].ConfessPhase == 6 && this.StudentManager.Students[13].ConfessPhase == 4 && Vector3.Distance(this.Yandere.transform.position, this.MythHill.position) > (float)10 && Vector3.Distance(this.Yandere.transform.position, this.MythHill.position) < (float)25)
		{
			this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.CanMove = false;
			this.StudentManager.Students[13].enabled = false;
			this.StudentManager.Students[7].enabled = false;
			this.ConfessionScene.enabled = true;
			this.Clock.StopTime = true;
			this.LeftNote = false;
		}
		if (this.HoldingHands)
		{
			this.StudentManager.Students[7].MyController.Move(this.transform.forward * Time.deltaTime);
			this.StudentManager.Students[13].transform.position = this.StudentManager.Students[7].transform.position;
			float x = this.StudentManager.Students[13].transform.position.x - 0.5f;
			Vector3 position = this.StudentManager.Students[13].transform.position;
			float num = position.x = x;
			Vector3 vector = this.StudentManager.Students[13].transform.position = position;
			if (this.StudentManager.Students[7].transform.position.z > (float)-50)
			{
				this.StudentManager.Students[13].MyController.radius = 0.12f;
				this.StudentManager.Students[13].enabled = true;
				this.StudentManager.Students[13].Cosmetic.MyRenderer.materials[this.StudentManager.Students[13].Cosmetic.FaceID].SetFloat("_BlendAmount", (float)0);
				this.StudentManager.Students[13].Hearts.enableEmission = false;
				this.StudentManager.Students[7].MyController.radius = 0.12f;
				this.StudentManager.Students[7].enabled = true;
				this.StudentManager.Students[7].Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)0);
				this.StudentManager.Students[7].Hearts.enableEmission = false;
				this.StudentManager.Students[13].HoldingHands = false;
				this.StudentManager.Students[7].HoldingHands = false;
				this.HoldingHands = false;
			}
		}
	}

	public virtual void CoupleCheck()
	{
		if (this.SuitorProgress == 2 && this.StudentManager.Students[7] != null && this.StudentManager.Students[13] != null)
		{
			this.StudentManager.Students[13].Character.animation.Play("walkHands_00");
			this.StudentManager.Students[13].transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.StudentManager.Students[13].transform.position = new Vector3(-0.25f, (float)0, (float)-100);
			this.StudentManager.Students[13].Pathfinding.canSearch = false;
			this.StudentManager.Students[13].Pathfinding.canMove = false;
			this.StudentManager.Students[13].MyController.radius = (float)0;
			this.StudentManager.Students[13].enabled = false;
			this.StudentManager.Students[7].Character.animation.Play("f02_walkHands_00");
			this.StudentManager.Students[7].transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.StudentManager.Students[7].transform.position = new Vector3(0.25f, (float)0, (float)-100);
			this.StudentManager.Students[7].Pathfinding.canSearch = false;
			this.StudentManager.Students[7].Pathfinding.canMove = false;
			this.StudentManager.Students[7].MyController.radius = (float)0;
			this.StudentManager.Students[7].enabled = false;
			this.StudentManager.Students[13].Cosmetic.MyRenderer.materials[this.StudentManager.Students[13].Cosmetic.FaceID].SetFloat("_BlendAmount", (float)1);
			this.StudentManager.Students[13].Hearts.enableEmission = true;
			this.StudentManager.Students[13].Hearts.emissionRate = (float)5;
			this.StudentManager.Students[13].Hearts.Play();
			this.StudentManager.Students[7].Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)1);
			this.StudentManager.Students[7].Hearts.enableEmission = true;
			this.StudentManager.Students[7].Hearts.emissionRate = (float)5;
			this.StudentManager.Students[7].Hearts.Play();
			this.StudentManager.Students[13].HoldingHands = true;
			this.StudentManager.Students[7].HoldingHands = true;
			this.HoldingHands = true;
		}
	}

	public virtual void Main()
	{
	}
}
