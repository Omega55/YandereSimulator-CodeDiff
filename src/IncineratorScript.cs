using System;
using UnityEngine;

[Serializable]
public class IncineratorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public ParticleSystem Smoke;

	public PromptScript Prompt;

	public ClockScript Clock;

	public UISprite Circle;

	public Transform DumpPoint;

	public Transform RightDoor;

	public Transform LeftDoor;

	public GameObject Panel;

	public bool YandereHoldingEvidence;

	public bool Ready;

	public bool Open;

	public int BloodyUniforms;

	public int MurderWeapons;

	public int Corpses;

	public float OpenTimer;

	public float Timer;

	public virtual void Start()
	{
		this.Prompt.enabled = false;
		this.Panel.active = false;
	}

	public virtual void Update()
	{
		if (!this.Open)
		{
			float y = Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.RightDoor.transform.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.RightDoor.transform.localEulerAngles = localEulerAngles;
			float y2 = Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles2 = this.LeftDoor.transform.localEulerAngles;
			float num2 = localEulerAngles2.y = y2;
			Vector3 vector2 = this.LeftDoor.transform.localEulerAngles = localEulerAngles2;
		}
		else
		{
			float y3 = Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles3 = this.RightDoor.transform.localEulerAngles;
			float num3 = localEulerAngles3.y = y3;
			Vector3 vector3 = this.RightDoor.transform.localEulerAngles = localEulerAngles3;
			float y4 = Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles4 = this.LeftDoor.transform.localEulerAngles;
			float num4 = localEulerAngles4.y = y4;
			Vector3 vector4 = this.LeftDoor.transform.localEulerAngles = localEulerAngles4;
		}
		if (this.OpenTimer > (float)0)
		{
			this.OpenTimer -= Time.deltaTime;
			if (this.OpenTimer <= (float)1)
			{
				this.Open = false;
			}
			if (this.OpenTimer <= (float)0)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (!this.Smoke.isPlaying)
		{
			if (this.Yandere.Ragdoll != null)
			{
				this.YandereHoldingEvidence = true;
			}
			else
			{
				this.YandereHoldingEvidence = false;
			}
			if (!this.YandereHoldingEvidence)
			{
				if (this.Yandere.PickUp != null)
				{
					if (this.Yandere.PickUp.Evidence)
					{
						this.YandereHoldingEvidence = true;
					}
					else
					{
						this.YandereHoldingEvidence = false;
					}
				}
				else
				{
					this.YandereHoldingEvidence = false;
				}
			}
			if (!this.YandereHoldingEvidence)
			{
				if (this.Yandere.Weapon[this.Yandere.Equipped] != null)
				{
					if (this.Yandere.Weapon[this.Yandere.Equipped].Evidence)
					{
						this.YandereHoldingEvidence = true;
					}
					else
					{
						this.YandereHoldingEvidence = false;
					}
				}
				else
				{
					this.YandereHoldingEvidence = false;
				}
			}
			if (!this.YandereHoldingEvidence)
			{
				if (!this.Prompt.HideButton[3])
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else if (this.Prompt.HideButton[3])
			{
				this.Prompt.HideButton[3] = false;
			}
			if (this.Ready)
			{
				if (!this.Smoke.isPlaying)
				{
					if (this.Prompt.HideButton[0])
					{
						this.Prompt.HideButton[0] = false;
					}
				}
				else if (!this.Prompt.HideButton[0])
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			if (!this.YandereHoldingEvidence && !this.Ready)
			{
				if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (!this.Prompt.enabled)
			{
				this.Prompt.enabled = true;
			}
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			if (this.Yandere.Ragdoll != null)
			{
				this.Yandere.YandereVision = false;
				this.Yandere.CanMove = false;
				this.Yandere.Dumping = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Open = true;
			}
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Incinerator = this;
				this.Yandere.PickUp.Dumped = true;
				this.Yandere.PickUp.Drop();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.OpenTimer = (float)2;
				this.Ready = true;
				this.Open = true;
			}
			if (this.Yandere.Weapon[this.Yandere.Equipped] != null)
			{
				this.Yandere.Weapon[this.Yandere.Equipped].Incinerator = this;
				this.Yandere.Weapon[this.Yandere.Equipped].Dumped = true;
				this.Yandere.Weapon[this.Yandere.Equipped].Drop();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.OpenTimer = (float)2;
				this.Ready = true;
				this.Open = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Panel.active = true;
			this.Timer = 60f;
			this.Smoke.Play();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.Police.IncineratedWeapons = this.Yandere.Police.IncineratedWeapons + this.MurderWeapons;
			this.Yandere.Police.BloodyUniforms = this.Yandere.Police.BloodyUniforms - this.BloodyUniforms;
			this.Yandere.Police.BloodyWeapons = this.Yandere.Police.BloodyWeapons - this.MurderWeapons;
			this.Yandere.Police.Corpses = this.Yandere.Police.Corpses - this.Corpses;
		}
		if (this.Smoke.isPlaying)
		{
			this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / (float)60);
			this.Circle.fillAmount = (float)1 - this.Timer / (float)60;
			if (this.Timer <= (float)0)
			{
				this.Prompt.HideButton[0] = true;
				this.Prompt.enabled = true;
				this.Panel.active = false;
				this.Ready = false;
				this.BloodyUniforms = 0;
				this.MurderWeapons = 0;
				this.Corpses = 0;
				this.Smoke.Stop();
			}
		}
	}

	public virtual void Main()
	{
	}
}
