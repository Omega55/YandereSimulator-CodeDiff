using System;
using UnityEngine;

[Serializable]
public class RefrigeratorScript : MonoBehaviour
{
	public CookingEventScript CookingEvent;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PlatePickUp;

	public PromptScript PlatePrompt;

	public Collider PlateCollider;

	public GameObject[] Octodogs;

	public GameObject Refrigerator;

	public GameObject Octodog;

	public GameObject Sausage;

	public Transform CookingSpot;

	public Transform CookingClub;

	public Transform JarLid;

	public Transform Knife;

	public Transform Jar;

	public bool Empty;

	public int EventPhase;

	public float Rotation;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.CookingEvent.EventCheck = false;
			this.Yandere.CanMove = false;
			this.Yandere.Cooking = true;
			this.Yandere.EmptyHands();
		}
		if (this.Yandere.Cooking)
		{
			Quaternion to = Quaternion.LookRotation(new Vector3(this.Octodogs[1].transform.position.x, this.Yandere.transform.position.y, this.Octodogs[1].transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, to, Time.deltaTime * (float)10);
			this.Yandere.MoveTowardsTarget(this.CookingSpot.position);
			if (this.EventPhase == 0)
			{
				this.Yandere.Character.animation.Play("f02_prepareFood_00");
				this.Octodog.transform.parent = this.Yandere.RightHand;
				this.Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
				this.Octodog.transform.localEulerAngles = new Vector3((float)-90, (float)0, (float)0);
				this.Sausage.transform.parent = this.Yandere.RightHand;
				this.Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
				this.Sausage.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.EventPhase++;
			}
			else if (this.EventPhase == 1)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time > (float)1)
				{
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 2)
			{
				this.Refrigerator.animation.Play("FridgeOpen");
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time > (float)3)
				{
					this.Jar.parent = this.Yandere.RightHand;
					this.Jar.localPosition = new Vector3((float)0, -0.033333f, -0.14f);
					this.Jar.localEulerAngles = new Vector3((float)90, (float)0, (float)0);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 3)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time > (float)5)
				{
					this.JarLid.transform.parent = this.Yandere.LeftHand;
					this.JarLid.localPosition = new Vector3(0.033333f, (float)0, (float)0);
					this.JarLid.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 4)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time > (float)6)
				{
					this.JarLid.parent = this.CookingClub;
					this.JarLid.localPosition = new Vector3(0.334585f, (float)1, -0.2528915f);
					this.JarLid.localEulerAngles = new Vector3((float)0, (float)30, (float)0);
					this.Jar.parent = this.CookingClub;
					this.Jar.localPosition = new Vector3(0.29559f, (float)1, 0.2029152f);
					this.Jar.localEulerAngles = new Vector3((float)0, (float)-150, (float)0);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 5)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time > (float)7)
				{
					((WeaponScript)this.Knife.GetComponent(typeof(WeaponScript))).FingerprintID = 100;
					this.Knife.parent = this.Yandere.LeftHand;
					this.Knife.localPosition = new Vector3((float)0, -0.01f, (float)0);
					this.Knife.localEulerAngles = new Vector3((float)0, (float)0, (float)-90);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 6)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time >= this.Yandere.Character.animation["f02_prepareFood_00"].length)
				{
					this.Yandere.Character.animation.CrossFade("f02_cutFood_00");
					this.Sausage.active = true;
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 7)
			{
				if (this.Yandere.Character.animation["f02_cutFood_00"].time > 2.66666f)
				{
					this.Octodog.active = true;
					this.Sausage.active = false;
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 8)
			{
				if (this.Yandere.Character.animation["f02_cutFood_00"].time > (float)3)
				{
					this.Rotation = Mathf.MoveTowards(this.Rotation, (float)90, Time.deltaTime * (float)360);
					float rotation = this.Rotation;
					Vector3 localEulerAngles = this.Octodog.transform.localEulerAngles;
					float num = localEulerAngles.x = rotation;
					Vector3 vector = this.Octodog.transform.localEulerAngles = localEulerAngles;
					float z = Mathf.MoveTowards(this.Octodog.transform.localPosition.z, 0.012f, Time.deltaTime);
					Vector3 localPosition = this.Octodog.transform.localPosition;
					float num2 = localPosition.z = z;
					Vector3 vector2 = this.Octodog.transform.localPosition = localPosition;
				}
				if (this.Yandere.Character.animation["f02_cutFood_00"].time > (float)6)
				{
					this.Octodog.active = false;
					for (int i = 1; i < this.Octodogs.Length; i++)
					{
						this.Octodogs[i].active = true;
					}
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 9)
			{
				if (this.Yandere.Character.animation["f02_cutFood_00"].time >= this.Yandere.Character.animation["f02_cutFood_00"].length)
				{
					this.Yandere.Character.animation.Play("f02_prepareFood_00");
					this.Yandere.Character.animation["f02_prepareFood_00"].time = this.Yandere.Character.animation["f02_prepareFood_00"].length;
					this.Yandere.Character.animation["f02_prepareFood_00"].speed = (float)-1;
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 10)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time < this.Yandere.Character.animation["f02_prepareFood_00"].length - (float)1)
				{
					this.Knife.parent = this.CookingClub;
					this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.33333f);
					this.Knife.localEulerAngles = new Vector3((float)45, (float)-90, (float)-90);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 11)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time < this.Yandere.Character.animation["f02_prepareFood_00"].length - (float)2)
				{
					this.JarLid.parent = this.Yandere.LeftHand;
					this.JarLid.localPosition = new Vector3(0.033333f, (float)0, (float)0);
					this.JarLid.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.Jar.parent = this.Yandere.RightHand;
					this.Jar.localPosition = new Vector3((float)0, -0.033333f, -0.14f);
					this.Jar.localEulerAngles = new Vector3((float)90, (float)0, (float)0);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 12)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time < this.Yandere.Character.animation["f02_prepareFood_00"].length - (float)3)
				{
					this.JarLid.parent = this.Jar;
					this.JarLid.localPosition = new Vector3((float)0, 0.175f, (float)0);
					this.JarLid.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.Refrigerator.animation.Play("FridgeOpen");
					this.Refrigerator.animation["FridgeOpen"].time = this.Refrigerator.animation["FridgeOpen"].length;
					this.Refrigerator.animation["FridgeOpen"].speed = (float)-1;
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 13)
			{
				if (this.Yandere.Character.animation["f02_prepareFood_00"].time < this.Yandere.Character.animation["f02_prepareFood_00"].length - (float)5)
				{
					this.Jar.parent = this.CookingClub;
					this.Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
					this.Jar.localEulerAngles = new Vector3((float)0, (float)90, (float)0);
					this.EventPhase++;
				}
			}
			else if (this.EventPhase == 14 && this.Yandere.Character.animation["f02_prepareFood_00"].time <= (float)0)
			{
				this.PlateCollider.enabled = true;
				this.PlatePickUp.enabled = true;
				this.PlatePrompt.enabled = true;
				this.Yandere.Cooking = false;
				this.Yandere.CanMove = true;
				this.Empty = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.enabled = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
