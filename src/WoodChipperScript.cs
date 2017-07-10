using System;
using UnityEngine;

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

	public int Victims;

	public int ID;

	public int[] VictimList;

	private void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (!this.Yandere.PickUp.Bucket.Full)
				{
					this.BucketPrompt.HideButton[0] = false;
					if (this.BucketPrompt.Circle[0].fillAmount == 0f)
					{
						this.Bucket = this.Yandere.PickUp;
						this.Yandere.EmptyHands();
						this.Bucket.transform.eulerAngles = this.BucketPoint.eulerAngles;
						this.Bucket.transform.position = this.BucketPoint.position;
						this.Bucket.GetComponent<Rigidbody>().useGravity = false;
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
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.Open)
		{
			this.Rotation = Mathf.MoveTowards(this.Rotation, 0f, Time.deltaTime * 360f);
			if (this.Rotation > -36f)
			{
				if (this.Rotation < 0f)
				{
					component.clip = this.CloseAudio;
					component.Play();
				}
				this.Rotation = 0f;
			}
			this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
		}
		else
		{
			if (this.Lid.transform.localEulerAngles.x == 0f)
			{
				component.clip = this.OpenAudio;
				component.Play();
			}
			this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 360f);
			this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
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
		if (this.Prompt.Circle[3].fillAmount <= 0f)
		{
			Time.timeScale = 1f;
			if (this.Yandere.Ragdoll != null)
			{
				if (!this.Yandere.Carrying)
				{
					this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_dragIdle_00");
				}
				else
				{
					this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_carryIdleA_00");
				}
				this.Yandere.YandereVision = false;
				this.Yandere.Chipping = true;
				this.Yandere.CanMove = false;
				this.Victims++;
				this.VictimList[this.Victims] = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
				this.Open = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= 0f)
		{
			PlayerPrefs.SetInt("Student_" + this.VictimID.ToString() + "_Missing", 1);
			component.clip = this.ShredAudio;
			component.Play();
			this.Prompt.HideButton[3] = false;
			this.Prompt.HideButton[0] = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Yandere.Police.Corpses--;
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
			if (this.Timer >= 10f)
			{
				this.Prompt.enabled = true;
				this.Shredding = false;
				this.Occupied = false;
				this.Timer = 0f;
			}
			else if (this.Timer >= 9f)
			{
				if (this.Bucket != null)
				{
					this.Bucket.MyCollider.enabled = true;
					this.Bucket.Bucket.FillSpeed = 1f;
					this.Bucket = null;
					this.BloodSpray.Stop();
				}
			}
			else if (this.Timer >= 0.333333343f)
			{
				this.Bucket.Bucket.Bloodiness = 100f;
				this.Bucket.Bucket.FillSpeed = 0.05f;
				this.Bucket.Bucket.Full = true;
				this.BloodSpray.Play();
			}
		}
	}
}
