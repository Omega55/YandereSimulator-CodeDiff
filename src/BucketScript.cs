using System;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
	public ParticleSystem PourEffect;

	public ParticleSystem Sparkles;

	public YandereScript Yandere;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public GameObject WaterCollider;

	public GameObject BloodCollider;

	public GameObject GasCollider;

	[SerializeField]
	private GameObject BloodSpillEffect;

	[SerializeField]
	private GameObject GasSpillEffect;

	[SerializeField]
	private GameObject SpillEffect;

	[SerializeField]
	private GameObject Effect;

	[SerializeField]
	private GameObject[] Dumbbell;

	[SerializeField]
	private Transform[] Positions;

	[SerializeField]
	private Renderer Water;

	[SerializeField]
	private Renderer Blood;

	[SerializeField]
	private Renderer Gas;

	public float Bloodiness;

	public float FillSpeed = 1f;

	[SerializeField]
	private float Distance;

	[SerializeField]
	private float Rotate;

	public int Dumbbells;

	public bool Bleached;

	public bool Gasoline;

	public bool Dropped;

	public bool Poured;

	public bool Full;

	public bool Trap;

	public bool Fly;

	private void Start()
	{
		this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, 0f, this.Water.transform.localPosition.z);
		this.Water.transform.localScale = new Vector3(0.235f, 1f, 0.14f);
		this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, 0f);
		this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, 0f);
		this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, 0f, this.Gas.transform.localPosition.z);
		this.Gas.transform.localScale = new Vector3(0.235f, 1f, 0.14f);
		this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, 0f);
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	private void Update()
	{
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
		if (this.Distance < 1f)
		{
			if (this.Yandere.Bucket == null)
			{
				RaycastHit raycastHit;
				if (base.transform.position.y > this.Yandere.transform.position.y - 0.1f && base.transform.position.y < this.Yandere.transform.position.y + 0.1f && Physics.Linecast(base.transform.position, this.Yandere.transform.position + Vector3.up, out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
				{
					this.Yandere.Bucket = this;
				}
			}
			else
			{
				RaycastHit raycastHit;
				if (Physics.Linecast(base.transform.position, this.Yandere.transform.position + Vector3.up, out raycastHit) && raycastHit.collider.gameObject != this.Yandere.gameObject)
				{
					this.Yandere.Bucket = null;
				}
				if (base.transform.position.y < this.Yandere.transform.position.y - 0.1f || base.transform.position.y > this.Yandere.transform.position.y + 0.1f)
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
			base.transform.position = Vector3.Lerp(base.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.55f, Time.deltaTime * 10f);
			Quaternion b = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.JerryCan)
			{
				if (!this.Yandere.PickUp.Empty)
				{
					this.Prompt.Label[0].text = "     Pour Gasoline";
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (this.Yandere.PickUp.Bleach)
			{
				if (this.Full && !this.Gasoline && !this.Bleached)
				{
					this.Prompt.Label[0].text = "     Pour Bleach";
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (this.Yandere.PickUp == this.PickUp && (this.Yandere.v != 0f || this.Yandere.h != 0f) && this.Full && Input.GetButtonDown("RB"))
			{
				this.Yandere.EmptyHands();
				this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_bucketTrip_00");
				this.Yandere.Tripping = true;
				this.Yandere.CanMove = false;
				this.Full = false;
				this.Fly = true;
			}
		}
		else if (this.Yandere.Equipped > 0)
		{
			if (!this.Full)
			{
				if (this.Yandere.EquippedWeapon.WeaponID == 12)
				{
					if (this.Dumbbells < 5)
					{
						this.Prompt.Label[0].text = "     Place Dumbbell";
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
			this.Prompt.Label[0].text = "     Remove Dumbbell";
			this.Prompt.HideButton[0] = false;
		}
		if (this.Dumbbells > 0)
		{
			if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus == 0)
			{
				this.Prompt.Label[3].text = "     Physical Stat Too Low";
				this.Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				this.Prompt.Label[3].text = "     Carry";
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Label[0].text == "     Place Dumbbell")
			{
				this.Dumbbells++;
				this.Dumbbell[this.Dumbbells] = this.Yandere.EquippedWeapon.gameObject;
				this.Yandere.EmptyHands();
				this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = false;
				this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = false;
				this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().Hide();
				this.Dumbbell[this.Dumbbells].GetComponent<Collider>().enabled = false;
				Rigidbody component = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
				component.useGravity = false;
				component.isKinematic = true;
				this.Dumbbell[this.Dumbbells].transform.parent = base.transform;
				this.Dumbbell[this.Dumbbells].transform.localPosition = this.Positions[this.Dumbbells].localPosition;
				this.Dumbbell[this.Dumbbells].transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			else if (this.Prompt.Label[0].text == "     Remove Dumbbell")
			{
				this.Yandere.EmptyHands();
				this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = true;
				this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = true;
				this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().Prompt.Circle[3].fillAmount = 0f;
				Rigidbody component2 = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
				component2.isKinematic = false;
				this.Dumbbell[this.Dumbbells] = null;
				this.Dumbbells--;
			}
			else if (this.Prompt.Label[0].text == "     Pour Gasoline")
			{
				this.Yandere.PickUp.Empty = true;
				this.Gasoline = true;
				this.Full = true;
			}
			else
			{
				this.Sparkles.Play();
				this.Bleached = true;
			}
		}
		if (this.Full)
		{
			if (!this.Gasoline)
			{
				this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.285f, 1f, 0.17f), Time.deltaTime * 5f * this.FillSpeed);
				this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, Mathf.Lerp(this.Water.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * this.FillSpeed), this.Water.transform.localPosition.z);
				this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, Mathf.Lerp(this.Water.material.color.a, 0.5f, Time.deltaTime * 5f));
			}
			else
			{
				this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(0.285f, 1f, 0.17f), Time.deltaTime * 5f * this.FillSpeed);
				this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, Mathf.Lerp(this.Gas.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * this.FillSpeed), this.Gas.transform.localPosition.z);
				this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, Mathf.Lerp(this.Gas.material.color.a, 0.5f, Time.deltaTime * 5f));
			}
		}
		else
		{
			this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.235f, 1f, 0.14f), Time.deltaTime * 5f);
			this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, Mathf.Lerp(this.Water.transform.localPosition.y, 0f, Time.deltaTime * 5f), this.Water.transform.localPosition.z);
			this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, Mathf.Lerp(this.Water.material.color.a, 0f, Time.deltaTime * 5f));
			this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(0.235f, 1f, 0.14f), Time.deltaTime * 5f);
			this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, Mathf.Lerp(this.Gas.transform.localPosition.y, 0f, Time.deltaTime * 5f), this.Gas.transform.localPosition.z);
			this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, Mathf.Lerp(this.Gas.material.color.a, 0f, Time.deltaTime * 5f));
		}
		this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, Mathf.Lerp(this.Blood.material.color.a, this.Bloodiness / 100f, Time.deltaTime));
		this.Blood.transform.localPosition = new Vector3(this.Blood.transform.localPosition.x, this.Water.transform.localPosition.y + 0.001f, this.Blood.transform.localPosition.z);
		this.Blood.transform.localScale = this.Water.transform.localScale;
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket == this)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			else if (!this.Trap)
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			if (this.Fly)
			{
				if (this.Rotate < 360f)
				{
					if (this.Rotate == 0f)
					{
						base.transform.rotation = this.Yandere.transform.rotation;
						if (this.Bloodiness < 50f)
						{
							if (!this.Gasoline)
							{
								this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.SpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							}
							else
							{
								this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.GasSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
								this.Gasoline = false;
							}
						}
						else
						{
							this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.BloodSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							this.Bloodiness = 0f;
						}
						if (this.Trap)
						{
							this.Effect.transform.LookAt(this.Effect.transform.position - Vector3.up);
						}
						else
						{
							Rigidbody component3 = base.GetComponent<Rigidbody>();
							component3.AddRelativeForce(Vector3.forward * 150f);
							component3.AddRelativeForce(Vector3.up * 250f);
							base.transform.Translate(Vector3.forward * 0.5f);
						}
					}
					this.Rotate += Time.deltaTime * 360f;
					base.transform.Rotate(Vector3.right * Time.deltaTime * 360f);
				}
				else
				{
					this.Sparkles.Stop();
					this.Rotate = 0f;
					this.Trap = false;
					this.Fly = false;
				}
			}
			if (!this.Trap)
			{
				this.Prompt.enabled = true;
			}
		}
		if (Input.GetKeyDown("b"))
		{
			this.Bloodiness = 100f;
		}
	}

	public void Empty()
	{
		this.Bloodiness = 0f;
		this.Bleached = false;
		this.Sparkles.Stop();
		this.Full = false;
	}

	public void Fill()
	{
		this.Full = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (this.Dropped && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				base.GetComponent<AudioSource>().Play();
				while (this.Dumbbells > 0)
				{
					this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = true;
					this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = true;
					this.Dumbbell[this.Dumbbells].GetComponent<Collider>().enabled = true;
					Rigidbody component2 = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
					component2.constraints = RigidbodyConstraints.None;
					component2.isKinematic = false;
					component2.useGravity = true;
					this.Dumbbell[this.Dumbbells].transform.parent = null;
					this.Dumbbell[this.Dumbbells] = null;
					this.Dumbbells--;
				}
				this.Dropped = false;
				component.DeathType = DeathType.Weapon;
				component.BecomeRagdoll();
			}
		}
	}
}
