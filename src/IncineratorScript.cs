using System;
using UnityEngine;

[Serializable]
public class IncineratorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public AudioSource FlameSound;

	public ParticleSystem Flames;

	public ParticleSystem Smoke;

	public Transform DumpPoint;

	public Transform RightDoor;

	public Transform LeftDoor;

	public GameObject Panel;

	public UILabel TimeLabel;

	public UISprite Circle;

	public bool YandereHoldingEvidence;

	public bool Ready;

	public bool Open;

	public int BloodyUniforms;

	public int MurderWeapons;

	public int Corpses;

	public float OpenTimer;

	public float Timer;

	public AudioClip IncineratorActivate;

	public AudioClip IncineratorClose;

	public AudioClip IncineratorOpen;

	public virtual void Start()
	{
		this.Panel.active = false;
	}

	public virtual void Update()
	{
		if (!this.Open)
		{
			float y = Mathf.MoveTowards(this.RightDoor.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)360);
			Vector3 localEulerAngles = this.RightDoor.transform.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.RightDoor.transform.localEulerAngles = localEulerAngles;
			float y2 = Mathf.MoveTowards(this.LeftDoor.transform.localEulerAngles.y, (float)0, Time.deltaTime * (float)360);
			Vector3 localEulerAngles2 = this.LeftDoor.transform.localEulerAngles;
			float num2 = localEulerAngles2.y = y2;
			Vector3 vector2 = this.LeftDoor.transform.localEulerAngles = localEulerAngles2;
			if (this.RightDoor.transform.localEulerAngles.y < (float)36)
			{
				if (this.RightDoor.transform.localEulerAngles.y > (float)0)
				{
					this.audio.clip = this.IncineratorClose;
					this.audio.Play();
				}
				int num3 = 0;
				Vector3 localEulerAngles3 = this.RightDoor.transform.localEulerAngles;
				float num4 = localEulerAngles3.y = (float)num3;
				Vector3 vector3 = this.RightDoor.transform.localEulerAngles = localEulerAngles3;
			}
		}
		else
		{
			if (this.RightDoor.transform.localEulerAngles.y == (float)0)
			{
				this.audio.clip = this.IncineratorOpen;
				this.audio.Play();
			}
			float y3 = Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles4 = this.RightDoor.transform.localEulerAngles;
			float num5 = localEulerAngles4.y = y3;
			Vector3 vector4 = this.RightDoor.transform.localEulerAngles = localEulerAngles4;
			float y4 = Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, (float)135, Time.deltaTime * (float)10);
			Vector3 localEulerAngles5 = this.LeftDoor.transform.localEulerAngles;
			float num6 = localEulerAngles5.y = y4;
			Vector3 vector5 = this.LeftDoor.transform.localEulerAngles = localEulerAngles5;
			if (this.RightDoor.transform.localEulerAngles.y > (float)134)
			{
				int num7 = 135;
				Vector3 localEulerAngles6 = this.RightDoor.transform.localEulerAngles;
				float num8 = localEulerAngles6.y = (float)num7;
				Vector3 vector6 = this.RightDoor.transform.localEulerAngles = localEulerAngles6;
			}
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
			Time.timeScale = (float)1;
			if (this.Yandere.Ragdoll != null)
			{
				this.Yandere.Character.animation.CrossFade("f02_dragIdle_00");
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
			this.audio.clip = this.IncineratorActivate;
			this.audio.Play();
			this.Flames.Play();
			this.Smoke.Play();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.Police.IncineratedWeapons = this.Yandere.Police.IncineratedWeapons + this.MurderWeapons;
			this.Yandere.Police.BloodyUniforms = this.Yandere.Police.BloodyUniforms - this.BloodyUniforms;
			this.Yandere.Police.BloodyWeapons = this.Yandere.Police.BloodyWeapons - this.MurderWeapons;
			this.Yandere.Police.Corpses = this.Yandere.Police.Corpses - this.Corpses;
			if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
			{
				this.Yandere.Police.MurderScene = false;
			}
			if (this.Yandere.Police.Corpses == 0)
			{
				this.Yandere.Police.MurderScene = false;
			}
		}
		if (this.Smoke.isPlaying)
		{
			this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / (float)60);
			this.FlameSound.volume = this.FlameSound.volume + Time.deltaTime;
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
				this.Flames.Stop();
				this.Smoke.Stop();
			}
		}
		else
		{
			this.FlameSound.volume = this.FlameSound.volume - Time.deltaTime;
		}
		if (this.Panel.active)
		{
			int num9 = Mathf.CeilToInt(this.Timer * (float)60);
			int num10 = num9 / 60;
			int num11 = num9 % 60;
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", num10, num11);
		}
	}

	public virtual void Main()
	{
	}
}
