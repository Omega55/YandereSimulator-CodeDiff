using System;
using UnityEngine;

[Serializable]
public class MopScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Collider HeadCollider;

	public Vector3 Rotation;

	public Renderer Blood;

	public Transform Head;

	public float Bloodiness;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.HeadCollider.enabled = false;
		this.UpdateBlood();
	}

	public virtual void Update()
	{
		if (this.Yandere.PickUp == this.PickUp)
		{
			if (this.Prompt.HideButton[0])
			{
				this.Prompt.HideButton[0] = false;
				this.Prompt.HideButton[3] = true;
				this.Yandere.Mop = this;
			}
			if (this.Yandere.Bucket == null)
			{
				this.Prompt.Label[0].text = "     " + "Sweep";
				if (Input.GetButtonDown("A"))
				{
					this.Yandere.Mopping = true;
					this.HeadCollider.enabled = true;
				}
			}
			else
			{
				this.Prompt.Label[0].text = "     " + "Dip";
				if (Input.GetButtonDown("A"))
				{
					this.Yandere.YandereVision = false;
					this.Yandere.CanMove = false;
					this.Yandere.Dipping = true;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			if (this.Yandere.Mopping)
			{
				this.Head.LookAt(this.Head.position + Vector3.down);
				float x = this.Head.localEulerAngles.x + (float)90;
				Vector3 localEulerAngles = this.Head.localEulerAngles;
				float num = localEulerAngles.x = x;
				Vector3 vector = this.Head.localEulerAngles = localEulerAngles;
				int num2 = 0;
				Vector3 localEulerAngles2 = this.Head.localEulerAngles;
				float num3 = localEulerAngles2.z = (float)num2;
				Vector3 vector2 = this.Head.localEulerAngles = localEulerAngles2;
			}
			else
			{
				this.Rotation = Vector3.Lerp(this.Head.localEulerAngles, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Head.localEulerAngles = this.Rotation;
			}
		}
		else if (!this.Prompt.HideButton[0])
		{
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[3] = false;
			if (this.Yandere.Mop == this)
			{
				this.Yandere.Mop = null;
			}
		}
		if (!this.Yandere.Mopping && this.HeadCollider.enabled)
		{
			this.HeadCollider.enabled = false;
		}
	}

	public virtual void UpdateBlood()
	{
		float a = this.Bloodiness / (float)100 * 0.9f;
		Color color = this.Blood.material.color;
		float num = color.a = a;
		Color color2 = this.Blood.material.color = color;
	}

	public virtual void Main()
	{
	}
}
