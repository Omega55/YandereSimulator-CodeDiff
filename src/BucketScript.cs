using System;
using UnityEngine;

[Serializable]
public class BucketScript : MonoBehaviour
{
	public ParticleSystem PourEffect;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject WaterCollider;

	public GameObject BloodCollider;

	public Renderer Water;

	public Renderer Blood;

	public RaycastHit hit;

	public float Bloodiness;

	public float Distance;

	public float FillSpeed;

	public bool Poured;

	public bool Full;

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
		this.Water.transform.localScale = new Vector3(0.12f, (float)1, 0.12f);
		int num3 = 0;
		Color color = this.Water.material.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Water.material.color = color;
		int num5 = 0;
		Color color3 = this.Blood.material.color;
		float num6 = color3.a = (float)num5;
		Color color4 = this.Blood.material.color = color3;
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
		if (this.Full)
		{
			this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.143f, (float)1, 0.143f), Time.deltaTime * (float)5 * this.FillSpeed);
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
			this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.12f, (float)1, 0.12f), Time.deltaTime * (float)5);
			float y2 = Mathf.Lerp(this.Water.transform.localPosition.y, (float)0, Time.deltaTime * (float)5);
			Vector3 localPosition2 = this.Water.transform.localPosition;
			float num3 = localPosition2.y = y2;
			Vector3 vector2 = this.Water.transform.localPosition = localPosition2;
			float a2 = Mathf.Lerp(this.Water.material.color.a, (float)0, Time.deltaTime * (float)5);
			Color color3 = this.Water.material.color;
			float num4 = color3.a = a2;
			Color color4 = this.Water.material.color = color3;
		}
		float a3 = Mathf.Lerp(this.Blood.material.color.a, this.Bloodiness / (float)100, Time.deltaTime);
		Color color5 = this.Blood.material.color;
		float num5 = color5.a = a3;
		Color color6 = this.Blood.material.color = color5;
		float y3 = this.Water.transform.localPosition.y + 0.001f;
		Vector3 localPosition3 = this.Blood.transform.localPosition;
		float num6 = localPosition3.y = y3;
		Vector3 vector3 = this.Blood.transform.localPosition = localPosition3;
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

	public virtual void Main()
	{
	}
}
