using System;
using UnityEngine;

[Serializable]
public class BucketScript : MonoBehaviour
{
	public ParticleSystem PourEffect;

	public YandereScript Yandere;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public GameObject WaterCollider;

	public GameObject BloodCollider;

	public GameObject GasCollider;

	public GameObject BloodSpillEffect;

	public GameObject GasSpillEffect;

	public GameObject SpillEffect;

	public GameObject[] Dumbbell;

	public Transform[] Positions;

	public Renderer Water;

	public Renderer Blood;

	public Renderer Gas;

	public RaycastHit hit;

	public float Bloodiness;

	public float FillSpeed;

	public float Distance;

	public float Rotate;

	public int Dumbbells;

	public bool Gasoline;

	public bool Dropped;

	public bool Poured;

	public bool Full;

	public bool Fly;

	public BucketScript()
	{
		this.FillSpeed = 1f;
	}

	public virtual void Start()
	{
		int num = 0;
		Vector3 localPosition = this.Water.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Water.transform.localPosition = localPosition;
		this.Water.transform.localScale = new Vector3(0.235f, (float)1, 0.14f);
		int num3 = 0;
		Color color = this.Water.material.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Water.material.color = color;
		int num5 = 0;
		Color color3 = this.Blood.material.color;
		float num6 = color3.a = (float)num5;
		Color color4 = this.Blood.material.color = color3;
		int num7 = 0;
		Vector3 localPosition2 = this.Gas.transform.localPosition;
		float num8 = localPosition2.y = (float)num7;
		Vector3 vector2 = this.Gas.transform.localPosition = localPosition2;
		this.Gas.transform.localScale = new Vector3(0.235f, (float)1, 0.14f);
		int num9 = 0;
		Color color5 = this.Gas.material.color;
		float num10 = color5.a = (float)num9;
		Color color6 = this.Gas.material.color = color5;
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		this.Distance = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
		if (this.Distance < (float)1)
		{
			if (this.Yandere.Bucket == null)
			{
				if (this.transform.position.y > this.Yandere.transform.position.y - 0.1f && this.transform.position.y < this.Yandere.transform.position.y + 0.1f && Physics.Linecast(this.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out this.hit) && this.hit.collider.gameObject == this.Yandere.gameObject)
				{
					this.Yandere.Bucket = this;
				}
			}
			else
			{
				if (Physics.Linecast(this.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out this.hit) && this.hit.collider.gameObject != this.Yandere.gameObject)
				{
					this.Yandere.Bucket = null;
				}
				if (this.transform.position.y < this.Yandere.transform.position.y - 0.1f || this.transform.position.y > this.Yandere.transform.position.y + 0.1f)
				{
					this.Yandere.Bucket = null;
				}
			}
		}
		else if (this.Yandere.Bucket == this)
		{
			this.Yandere.Bucket = null;
		}
		if (this.Yandere.Bucket == this && this.Yandere.Dipping)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.55f, Time.deltaTime * (float)10);
			Quaternion to = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, Time.deltaTime * (float)10);
		}
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.JerryCan)
			{
				if (!this.Yandere.PickUp.Empty)
				{
					this.Prompt.Label[0].text = "     " + "Pour Gasoline";
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (this.Yandere.PickUp == this.PickUp && (this.Yandere.v != (float)0 || this.Yandere.h != (float)0) && this.Full && Input.GetButtonDown("RB"))
			{
				this.Yandere.EmptyHands();
				this.Yandere.Character.animation.CrossFade("f02_bucketTrip_00");
				this.Yandere.Tripping = true;
				this.Yandere.CanMove = false;
				this.Full = false;
				this.Fly = true;
			}
		}
		else if (this.Yandere.Equipped > 0)
		{
			if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 12)
			{
				if (this.Dumbbells < 5)
				{
					this.Prompt.Label[0].text = "     " + "Place Dumbbell";
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		else if (this.Dumbbells == 0)
		{
			this.Prompt.HideButton[0] = true;
		}
		else
		{
			this.Prompt.Label[0].text = "     " + "Remove Dumbbell";
			this.Prompt.HideButton[0] = false;
		}
		if (this.Dumbbells > 0)
		{
			if (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus") == 0)
			{
				this.Prompt.Label[3].text = "     " + "Physical Stat Too Low";
				this.Prompt.Circle[3].fillAmount = (float)1;
			}
			else
			{
				this.Prompt.Label[3].text = "     " + "Carry";
			}
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.Prompt.Label[0].text == "     " + "Place Dumbbell")
			{
				this.Dumbbells++;
				this.Dumbbell[this.Dumbbells] = this.Yandere.Weapon[this.Yandere.Equipped].gameObject;
				this.Yandere.EmptyHands();
				((WeaponScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(WeaponScript))).enabled = false;
				((PromptScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(PromptScript))).enabled = false;
				((PromptScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(PromptScript))).Hide();
				((Collider)this.Dumbbell[this.Dumbbells].GetComponent(typeof(Collider))).enabled = false;
				this.Dumbbell[this.Dumbbells].rigidbody.useGravity = false;
				this.Dumbbell[this.Dumbbells].rigidbody.isKinematic = true;
				this.Dumbbell[this.Dumbbells].transform.parent = this.transform;
				this.Dumbbell[this.Dumbbells].transform.localPosition = this.Positions[this.Dumbbells].localPosition;
				this.Dumbbell[this.Dumbbells].transform.localEulerAngles = new Vector3((float)90, (float)0, (float)0);
			}
			else if (this.Prompt.Label[0].text == "     " + "Remove Dumbbell")
			{
				this.Yandere.EmptyHands();
				((WeaponScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(WeaponScript))).enabled = true;
				((PromptScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(PromptScript))).enabled = true;
				((WeaponScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(WeaponScript))).Prompt.Circle[3].fillAmount = (float)0;
				this.Dumbbell[this.Dumbbells].rigidbody.isKinematic = false;
				this.Dumbbell[this.Dumbbells] = null;
				this.Dumbbells--;
			}
			else
			{
				this.Yandere.PickUp.Empty = true;
				this.Gasoline = true;
				this.Full = true;
			}
		}
		if (this.Full)
		{
			if (!this.Gasoline)
			{
				this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.285f, (float)1, 0.17f), Time.deltaTime * (float)5 * this.FillSpeed);
				float y = Mathf.Lerp(this.Water.transform.localPosition.y, 0.2f, Time.deltaTime * (float)5 * this.FillSpeed);
				Vector3 localPosition = this.Water.transform.localPosition;
				float num = localPosition.y = y;
				Vector3 vector = this.Water.transform.localPosition = localPosition;
				float a = Mathf.Lerp(this.Water.material.color.a, 0.5f, Time.deltaTime * (float)5);
				Color color = this.Water.material.color;
				float num2 = color.a = a;
				Color color2 = this.Water.material.color = color;
			}
			else
			{
				this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(0.285f, (float)1, 0.17f), Time.deltaTime * (float)5 * this.FillSpeed);
				float y2 = Mathf.Lerp(this.Gas.transform.localPosition.y, 0.2f, Time.deltaTime * (float)5 * this.FillSpeed);
				Vector3 localPosition2 = this.Gas.transform.localPosition;
				float num3 = localPosition2.y = y2;
				Vector3 vector2 = this.Gas.transform.localPosition = localPosition2;
				float a2 = Mathf.Lerp(this.Gas.material.color.a, 0.5f, Time.deltaTime * (float)5);
				Color color3 = this.Gas.material.color;
				float num4 = color3.a = a2;
				Color color4 = this.Gas.material.color = color3;
			}
		}
		else
		{
			this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.235f, (float)1, 0.14f), Time.deltaTime * (float)5);
			float y3 = Mathf.Lerp(this.Water.transform.localPosition.y, (float)0, Time.deltaTime * (float)5);
			Vector3 localPosition3 = this.Water.transform.localPosition;
			float num5 = localPosition3.y = y3;
			Vector3 vector3 = this.Water.transform.localPosition = localPosition3;
			float a3 = Mathf.Lerp(this.Water.material.color.a, (float)0, Time.deltaTime * (float)5);
			Color color5 = this.Water.material.color;
			float num6 = color5.a = a3;
			Color color6 = this.Water.material.color = color5;
			this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(0.235f, (float)1, 0.14f), Time.deltaTime * (float)5);
			float y4 = Mathf.Lerp(this.Gas.transform.localPosition.y, (float)0, Time.deltaTime * (float)5);
			Vector3 localPosition4 = this.Gas.transform.localPosition;
			float num7 = localPosition4.y = y4;
			Vector3 vector4 = this.Gas.transform.localPosition = localPosition4;
			float a4 = Mathf.Lerp(this.Gas.material.color.a, (float)0, Time.deltaTime * (float)5);
			Color color7 = this.Gas.material.color;
			float num8 = color7.a = a4;
			Color color8 = this.Gas.material.color = color7;
		}
		float a5 = Mathf.Lerp(this.Blood.material.color.a, this.Bloodiness / (float)100, Time.deltaTime);
		Color color9 = this.Blood.material.color;
		float num9 = color9.a = a5;
		Color color10 = this.Blood.material.color = color9;
		float y5 = this.Water.transform.localPosition.y + 0.001f;
		Vector3 localPosition5 = this.Blood.transform.localPosition;
		float num10 = localPosition5.y = y5;
		Vector3 vector5 = this.Blood.transform.localPosition = localPosition5;
		this.Blood.transform.localScale = this.Water.transform.localScale;
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket == this)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			else
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			if (this.Fly)
			{
				if (this.Rotate < (float)360)
				{
					if (this.Rotate == (float)0)
					{
						this.transform.rotation = this.Yandere.transform.rotation;
						if (this.Bloodiness < (float)50)
						{
							if (!this.Gasoline)
							{
								UnityEngine.Object.Instantiate(this.SpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
							}
							else
							{
								UnityEngine.Object.Instantiate(this.GasSpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
								this.Gasoline = false;
							}
						}
						else
						{
							UnityEngine.Object.Instantiate(this.BloodSpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
							this.Bloodiness = (float)0;
						}
						this.rigidbody.AddRelativeForce(Vector3.forward * (float)150);
						this.rigidbody.AddRelativeForce(Vector3.up * (float)250);
						this.transform.Translate(Vector3.forward * 0.5f);
					}
					this.Rotate += Time.deltaTime * (float)360;
					this.transform.Rotate(Vector3.right * Time.deltaTime * (float)360);
				}
				else
				{
					this.Fly = false;
					this.Rotate = (float)0;
				}
			}
			this.Prompt.enabled = true;
		}
		if (Input.GetKeyDown("b"))
		{
			this.Bloodiness = (float)100;
		}
	}

	public virtual void Empty()
	{
		this.Bloodiness = (float)0;
		this.Full = false;
	}

	public virtual void Fill()
	{
		this.Full = true;
	}

	public virtual void OnCollisionEnter(Collision other)
	{
		if (this.Dropped && other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null)
			{
				this.audio.Play();
				while (this.Dumbbells > 0)
				{
					((WeaponScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(WeaponScript))).enabled = true;
					((PromptScript)this.Dumbbell[this.Dumbbells].GetComponent(typeof(PromptScript))).enabled = true;
					((Collider)this.Dumbbell[this.Dumbbells].GetComponent(typeof(Collider))).enabled = true;
					this.Dumbbell[this.Dumbbells].rigidbody.constraints = RigidbodyConstraints.None;
					this.Dumbbell[this.Dumbbells].rigidbody.isKinematic = false;
					this.Dumbbell[this.Dumbbells].rigidbody.useGravity = true;
					this.Dumbbell[this.Dumbbells].transform.parent = null;
					this.Dumbbell[this.Dumbbells] = null;
					this.Dumbbells--;
				}
				this.Dropped = false;
				studentScript.Dead = true;
				studentScript.BecomeRagdoll();
			}
		}
	}

	public virtual void Main()
	{
	}
}
