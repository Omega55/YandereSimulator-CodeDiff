using System;
using UnityEngine;

[Serializable]
public class HomePrisonerChanScript : MonoBehaviour
{
	public HomeYandereDetectorScript YandereDetector;

	public HomeCameraScript HomeCamera;

	public CosmeticScript Cosmetic;

	public JsonScript JSON;

	public Vector3 RightEyeRotOrigin;

	public Vector3 LeftEyeRotOrigin;

	public Vector3 PermanentAngleR;

	public Vector3 PermanentAngleL;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 Twitch;

	public Quaternion LastRotation;

	public Transform HomeYandere;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform TwintailR;

	public Transform TwintailL;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform Skirt;

	public Transform Neck;

	public GameObject RightMindbrokenEye;

	public GameObject LeftMindbrokenEye;

	public GameObject Blindfold;

	public GameObject Character;

	public GameObject Tripod;

	public float HairRotation;

	public float TwitchTimer;

	public float NextTwitch;

	public float BreastSize;

	public float EyeShrink;

	public float Sanity;

	public float HairRot1;

	public float HairRot2;

	public float HairRot3;

	public float HairRot4;

	public float HairRot5;

	public bool LookAhead;

	public bool Tortured;

	public bool Male;

	public int StudentID;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("KidnapVictim") > 0)
		{
			this.PermanentAngleR = this.TwintailR.eulerAngles;
			this.PermanentAngleL = this.TwintailL.eulerAngles;
			this.StudentID = PlayerPrefs.GetInt("KidnapVictim");
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Arrested") == 0 && PlayerPrefs.GetInt("Student_" + this.StudentID + "_Dead") == 0)
			{
				this.Cosmetic.StudentID = this.StudentID;
				this.Cosmetic.enabled = true;
				this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
				this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
				this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
				this.RightEyeOrigin = this.RightEye.localPosition;
				this.LeftEyeOrigin = this.LeftEye.localPosition;
				this.UpdateSanity();
				this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)-90);
				this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90);
				this.Blindfold.active = false;
				this.Tripod.active = false;
				if (this.StudentID == 32 && PlayerPrefs.GetInt("Scheme_6_Stage") > 4)
				{
					this.Blindfold.active = true;
					this.Tripod.active = true;
				}
			}
			else
			{
				PlayerPrefs.SetInt("KidnapVictim", 0);
				this.active = false;
			}
		}
		else
		{
			this.active = false;
		}
	}

	public virtual void LateUpdate()
	{
		this.Skirt.transform.localPosition = new Vector3((float)0, -0.135f, 0.01f);
		float y = 1.2f;
		Vector3 localScale = this.Skirt.transform.localScale;
		float num = localScale.y = y;
		Vector3 vector = this.Skirt.transform.localScale = localScale;
		if (!this.Tortured)
		{
			if (this.Sanity > (float)0)
			{
				if (this.LookAhead)
				{
					float x = this.Neck.localEulerAngles.x - (float)45;
					Vector3 localEulerAngles = this.Neck.localEulerAngles;
					float num2 = localEulerAngles.x = x;
					Vector3 vector2 = this.Neck.localEulerAngles = localEulerAngles;
				}
				else if (this.YandereDetector.YandereDetected && Vector3.Distance(this.transform.position, this.HomeYandere.position) < (float)2)
				{
					Quaternion to;
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot1, Time.deltaTime * (float)2);
					}
					else
					{
						to = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot2, Time.deltaTime * (float)2);
					}
					this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
					this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, (float)180, (float)-90);
					this.TwintailL.transform.localEulerAngles = new Vector3((float)-1 * this.HairRotation, (float)0, (float)-90);
				}
				else
				{
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						Quaternion to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot3, Time.deltaTime * (float)2);
					}
					else
					{
						Quaternion to = Quaternion.LookRotation(this.transform.position + this.transform.forward - this.Neck.position);
						this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
					}
					this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot4, Time.deltaTime * (float)2);
					this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, (float)180, (float)-90);
					this.TwintailL.transform.localEulerAngles = new Vector3((float)-1 * this.HairRotation, (float)0, (float)-90);
				}
			}
			else
			{
				float x2 = this.Neck.localEulerAngles.x - (float)45;
				Vector3 localEulerAngles2 = this.Neck.localEulerAngles;
				float num3 = localEulerAngles2.x = x2;
				Vector3 vector3 = this.Neck.localEulerAngles = localEulerAngles2;
			}
		}
		this.LastRotation = this.Neck.rotation;
		if (!this.Tortured && this.Sanity < (float)100 && this.Sanity > (float)0)
		{
			this.TwitchTimer += Time.deltaTime;
			if (this.TwitchTimer > this.NextTwitch)
			{
				this.Twitch.x = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.Twitch.y = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.Twitch.z = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.NextTwitch = UnityEngine.Random.Range((float)0, 1f);
				this.TwitchTimer = (float)0;
			}
			this.Twitch = Vector3.Lerp(this.Twitch, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.Neck.localEulerAngles = this.Neck.localEulerAngles + this.Twitch;
		}
		if (this.Tortured)
		{
			this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot5, Time.deltaTime * (float)2);
			this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, (float)180, (float)-90);
			this.TwintailL.transform.localEulerAngles = new Vector3((float)-1 * this.HairRotation, (float)0, (float)-90);
		}
	}

	public virtual void UpdateSanity()
	{
		this.Sanity = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_Sanity");
		if (this.Sanity == (float)0)
		{
			this.RightMindbrokenEye.active = true;
			this.LeftMindbrokenEye.active = true;
		}
		else
		{
			this.RightMindbrokenEye.active = false;
			this.LeftMindbrokenEye.active = false;
		}
	}

	public virtual void Main()
	{
	}
}
