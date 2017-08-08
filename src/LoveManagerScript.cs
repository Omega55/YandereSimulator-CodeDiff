using System;
using UnityEngine;

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

	public int Phase = 1;

	public int ID;

	public float AngleLimit;

	public bool HoldingHands;

	public bool RivalWaiting;

	public bool LeftNote;

	public bool Courted;

	private void Start()
	{
		this.SuitorProgress = PlayerPrefs.GetInt("SuitorProgress");
	}

	private void LateUpdate()
	{
		if (this.Follower != null && this.Follower.Alive)
		{
			this.ID = 0;
			while (this.ID < this.TotalTargets)
			{
				Transform transform = this.Targets[this.ID];
				if (transform != null && this.Follower.transform.position.y > transform.position.y - 2f && this.Follower.transform.position.y < transform.position.y + 2f && Vector3.Distance(this.Follower.transform.position, new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z)) < 2.5f)
				{
					float f = Vector3.Angle(this.Follower.transform.forward, this.Follower.transform.position - new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z));
					if (Mathf.Abs(f) > this.AngleLimit)
					{
						if (!this.Follower.Gush)
						{
							this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
							this.Follower.GushTarget = transform;
							ParticleSystem.EmissionModule emission = this.Follower.Hearts.emission;
							emission.enabled = true;
							emission.rateOverTime = 5f;
							this.Follower.Hearts.Play();
							this.Follower.Gush = true;
						}
					}
					else
					{
						this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
						this.Follower.Hearts.emission.enabled = false;
						this.Follower.Gush = false;
					}
				}
				this.ID++;
			}
		}
		StudentScript studentScript = this.StudentManager.Students[7];
		StudentScript studentScript2 = this.StudentManager.Students[13];
		if (this.LeftNote && studentScript != null && studentScript2 != null && studentScript.Alive && studentScript2.Alive && studentScript.ConfessPhase == 7 && studentScript2.ConfessPhase == 4)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, this.MythHill.position);
			if (num > 10f && num < 25f)
			{
				this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.CanMove = false;
				studentScript2.enabled = false;
				studentScript.enabled = false;
				this.ConfessionScene.enabled = true;
				this.Clock.StopTime = true;
				this.LeftNote = false;
			}
		}
		if (this.HoldingHands)
		{
			studentScript.MyController.Move(base.transform.forward * Time.deltaTime);
			studentScript2.transform.position = new Vector3(studentScript.transform.position.x - 0.5f, studentScript.transform.position.y, studentScript.transform.position.z);
			if (studentScript.transform.position.z > -50f)
			{
				studentScript2.MyController.radius = 0.12f;
				studentScript2.enabled = true;
				studentScript2.Cosmetic.MyRenderer.materials[studentScript2.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
				studentScript2.Hearts.emission.enabled = false;
				studentScript.MyController.radius = 0.12f;
				studentScript.enabled = true;
				studentScript.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				studentScript.Hearts.emission.enabled = false;
				studentScript2.HoldingHands = false;
				studentScript.HoldingHands = false;
				this.HoldingHands = false;
			}
		}
	}

	public void CoupleCheck()
	{
		if (this.SuitorProgress == 2)
		{
			StudentScript studentScript = this.StudentManager.Students[7];
			StudentScript studentScript2 = this.StudentManager.Students[13];
			if (studentScript != null && studentScript2 != null)
			{
				studentScript2.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				studentScript.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				studentScript2.Character.GetComponent<Animation>().enabled = true;
				studentScript.Character.GetComponent<Animation>().enabled = true;
				studentScript2.Character.GetComponent<Animation>().Play("walkHands_00");
				studentScript2.transform.eulerAngles = Vector3.zero;
				studentScript2.transform.position = new Vector3(-0.25f, 0f, -100f);
				studentScript2.Pathfinding.canSearch = false;
				studentScript2.Pathfinding.canMove = false;
				studentScript2.MyController.radius = 0f;
				studentScript2.enabled = false;
				studentScript.Character.GetComponent<Animation>().Play("f02_walkHands_00");
				studentScript.transform.eulerAngles = Vector3.zero;
				studentScript.transform.position = new Vector3(0.25f, 0f, -100f);
				studentScript.Pathfinding.canSearch = false;
				studentScript.Pathfinding.canMove = false;
				studentScript.MyController.radius = 0f;
				studentScript.enabled = false;
				studentScript2.Cosmetic.MyRenderer.materials[studentScript2.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission = studentScript2.Hearts.emission;
				emission.enabled = true;
				emission.rateOverTime = 5f;
				studentScript2.Hearts.Play();
				studentScript.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission2 = studentScript.Hearts.emission;
				emission2.enabled = true;
				emission2.rateOverTime = 5f;
				studentScript.Hearts.Play();
				studentScript2.HoldingHands = true;
				studentScript.HoldingHands = true;
				studentScript2.CoupleID = 7;
				studentScript2.Couple = true;
				studentScript.CoupleID = 13;
				studentScript.Couple = true;
				this.HoldingHands = true;
			}
		}
	}
}
