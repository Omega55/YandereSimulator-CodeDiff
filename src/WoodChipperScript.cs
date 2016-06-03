using System;
using UnityEngine;

[Serializable]
public class WoodChipperScript : MonoBehaviour
{
	public ParticleSystem BloodSpray;

	public PromptScript BucketPrompt;

	public YandereScript Yandere;

	public PickUpScript Bucket;

	public PromptScript Prompt;

	public AudioClip CloseAudio;

	public AudioClip ShredAudio;

	public AudioClip OpenAudio;

	public Transform BucketPoint;

	public Transform DumpPoint;

	public Transform Lid;

	public float Rotation;

	public float Timer;

	public bool Shredding;

	public bool Occupied;

	public bool Open;

	public int VictimID;

	public int ID;

	public virtual void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (!this.Yandere.PickUp.Bucket.Full)
				{
					this.BucketPrompt.HideButton[0] = false;
					if (this.BucketPrompt.Circle[0].fillAmount == (float)0)
					{
						this.Bucket = this.Yandere.PickUp;
						this.Yandere.EmptyHands();
						this.Bucket.transform.eulerAngles = this.BucketPoint.eulerAngles;
						this.Bucket.transform.position = this.BucketPoint.position;
						this.Bucket.rigidbody.useGravity = false;
						this.Bucket.MyCollider.enabled = false;
					}
				}
				else
				{
					this.BucketPrompt.HideButton[0] = true;
				}
			}
			else
			{
				this.BucketPrompt.HideButton[0] = true;
			}
		}
		else
		{
			this.BucketPrompt.HideButton[0] = true;
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.MoveTowards(this.Rotation, (float)0, Time.deltaTime * (float)360);
			if (this.Rotation > (float)-36)
			{
				if (this.Rotation < (float)0)
				{
					this.audio.clip = this.CloseAudio;
					this.audio.Play();
				}
				this.Rotation = (float)0;
			}
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.Lid.transform.localEulerAngles;
			float num = localEulerAngles.x = rotation;
			Vector3 vector = this.Lid.transform.localEulerAngles = localEulerAngles;
		}
		else
		{
			if (this.Lid.transform.localEulerAngles.x == (float)0)
			{
				this.audio.clip = this.OpenAudio;
				this.audio.Play();
			}
			this.Rotation = Mathf.MoveTowards(this.Rotation, (float)-90, Time.deltaTime * (float)360);
			float rotation2 = this.Rotation;
			Vector3 localEulerAngles2 = this.Lid.transform.localEulerAngles;
			float num2 = localEulerAngles2.x = rotation2;
			Vector3 vector2 = this.Lid.transform.localEulerAngles = localEulerAngles2;
		}
		if (!this.BloodSpray.isPlaying)
		{
			if (!this.Occupied)
			{
				if (this.Yandere.Ragdoll == null)
				{
					this.Prompt.HideButton[3] = true;
				}
				else
				{
					this.Prompt.HideButton[3] = false;
				}
			}
			else if (this.Bucket == null)
			{
				this.Prompt.HideButton[0] = true;
			}
			else if (this.Bucket.Bucket.Full)
			{
				this.Prompt.HideButton[0] = true;
			}
			else
			{
				this.Prompt.HideButton[0] = false;
			}
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			Time.timeScale = (float)1;
			if (this.Yandere.Ragdoll != null)
			{
				if (!this.Yandere.Carrying)
				{
					this.Yandere.Character.animation.CrossFade("f02_dragIdle_00");
				}
				else
				{
					this.Yandere.Character.animation.CrossFade("f02_carryIdleA_00");
				}
				this.Yandere.YandereVision = false;
				this.Yandere.Chipping = true;
				this.Yandere.CanMove = false;
				this.Open = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			PlayerPrefs.SetInt("Student_" + this.VictimID + "_Missing", 1);
			this.audio.clip = this.ShredAudio;
			this.audio.Play();
			this.Prompt.HideButton[3] = false;
			this.Prompt.HideButton[0] = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.Police.Corpses = this.Yandere.Police.Corpses - 1;
			if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
			{
				this.Yandere.Police.MurderScene = false;
			}
			if (this.Yandere.Police.Corpses == 0)
			{
				this.Yandere.Police.MurderScene = false;
			}
			this.Shredding = true;
		}
		if (this.Shredding)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer >= (float)10)
			{
				this.Prompt.enabled = true;
				this.Shredding = false;
				this.Occupied = false;
				this.Timer = (float)0;
			}
			else if (this.Timer >= (float)9)
			{
				if (this.Bucket != null)
				{
					this.Bucket.MyCollider.enabled = true;
					this.Bucket.Bucket.FillSpeed = (float)1;
					this.Bucket = null;
					this.BloodSpray.Stop();
				}
			}
			else if (this.Timer >= 0.33333f)
			{
				this.Bucket.Bucket.Bloodiness = (float)100;
				this.Bucket.Bucket.FillSpeed = 0.05f;
				this.Bucket.Bucket.Full = true;
				this.BloodSpray.Play();
			}
		}
	}

	public virtual void Main()
	{
	}
}
