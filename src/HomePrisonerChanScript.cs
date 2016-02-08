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

	public Transform Neck;

	public GameObject RightMindbrokenEye;

	public GameObject LeftMindbrokenEye;

	public GameObject Character;

	public float HairRotation;

	public float TwitchTimer;

	public float NextTwitch;

	public float BreastSize;

	public float EyeShrink;

	public float Sanity;

	public bool Tortured;

	public bool Male;

	public int StudentID;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("KidnapVictim") > 0)
		{
			this.StudentID = PlayerPrefs.GetInt("KidnapVictim");
			this.Cosmetic.StudentID = this.StudentID;
			this.Cosmetic.enabled = true;
			this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
			this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
			this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
			this.UpdateSanity();
			this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)90);
			this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90);
		}
		else
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void LateUpdate()
	{
		if (!this.Tortured)
		{
			if (this.Sanity > (float)0)
			{
				if (this.YandereDetector.YandereDetected && Vector3.Distance(this.transform.position, this.HomeYandere.position) < (float)2)
				{
					Quaternion to;
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
					}
					else
					{
						to = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)60, Time.deltaTime * (float)2);
					}
					this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
					this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)90 - this.HairRotation);
					this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90 - this.HairRotation);
				}
				else
				{
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						Quaternion to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
					}
					else
					{
						Quaternion to = Quaternion.LookRotation(this.transform.position + this.transform.forward - this.Neck.position);
						this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
					}
					this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
					this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)90 - this.HairRotation);
					this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90 - this.HairRotation);
				}
			}
			else
			{
				float x = this.Neck.localEulerAngles.x - (float)45;
				Vector3 localEulerAngles = this.Neck.localEulerAngles;
				float num = localEulerAngles.x = x;
				Vector3 vector = this.Neck.localEulerAngles = localEulerAngles;
			}
		}
		else
		{
			this.EyeShrink += Time.deltaTime * 0.1f;
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
			this.HairRotation = Mathf.Lerp(this.HairRotation, (float)60, Time.deltaTime * (float)2);
			this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)90 - this.HairRotation);
			this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90 - this.HairRotation);
			if (this.EyeShrink > (float)1)
			{
				this.EyeShrink = (float)1;
			}
			if (this.Sanity >= (float)50)
			{
				float z = this.LeftEye.localPosition.z - this.EyeShrink * 0.009f;
				Vector3 localPosition = this.LeftEye.localPosition;
				float num2 = localPosition.z = z;
				Vector3 vector2 = this.LeftEye.localPosition = localPosition;
				float z2 = this.RightEye.localPosition.z + this.EyeShrink * 0.009f;
				Vector3 localPosition2 = this.RightEye.localPosition;
				float num3 = localPosition2.z = z2;
				Vector3 vector3 = this.RightEye.localPosition = localPosition2;
				float x2 = this.LeftEye.localPosition.x - this.EyeShrink * 0.002f;
				Vector3 localPosition3 = this.LeftEye.localPosition;
				float num4 = localPosition3.x = x2;
				Vector3 vector4 = this.LeftEye.localPosition = localPosition3;
				float x3 = this.RightEye.localPosition.x - this.EyeShrink * 0.002f;
				Vector3 localPosition4 = this.RightEye.localPosition;
				float num5 = localPosition4.x = x3;
				Vector3 vector5 = this.RightEye.localPosition = localPosition4;
				float x4 = this.LeftEye.localEulerAngles.x + (float)5 + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles2 = this.LeftEye.localEulerAngles;
				float num6 = localEulerAngles2.x = x4;
				Vector3 vector6 = this.LeftEye.localEulerAngles = localEulerAngles2;
				float y = this.LeftEye.localEulerAngles.y + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles3 = this.LeftEye.localEulerAngles;
				float num7 = localEulerAngles3.y = y;
				Vector3 vector7 = this.LeftEye.localEulerAngles = localEulerAngles3;
				float z3 = this.LeftEye.localEulerAngles.z + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles4 = this.LeftEye.localEulerAngles;
				float num8 = localEulerAngles4.z = z3;
				Vector3 vector8 = this.LeftEye.localEulerAngles = localEulerAngles4;
				float x5 = this.RightEye.localEulerAngles.x - (float)5 + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles5 = this.RightEye.localEulerAngles;
				float num9 = localEulerAngles5.x = x5;
				Vector3 vector9 = this.RightEye.localEulerAngles = localEulerAngles5;
				float y2 = this.RightEye.localEulerAngles.y + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles6 = this.RightEye.localEulerAngles;
				float num10 = localEulerAngles6.y = y2;
				Vector3 vector10 = this.RightEye.localEulerAngles = localEulerAngles6;
				float z4 = this.RightEye.localEulerAngles.z + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles7 = this.RightEye.localEulerAngles;
				float num11 = localEulerAngles7.z = z4;
				Vector3 vector11 = this.RightEye.localEulerAngles = localEulerAngles7;
				float x6 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale = this.LeftEye.localScale;
				float num12 = localScale.x = x6;
				Vector3 vector12 = this.LeftEye.localScale = localScale;
				float y3 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale2 = this.LeftEye.localScale;
				float num13 = localScale2.y = y3;
				Vector3 vector13 = this.LeftEye.localScale = localScale2;
				float x7 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale3 = this.RightEye.localScale;
				float num14 = localScale3.x = x7;
				Vector3 vector14 = this.RightEye.localScale = localScale3;
				float y4 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale4 = this.RightEye.localScale;
				float num15 = localScale4.y = y4;
				Vector3 vector15 = this.RightEye.localScale = localScale4;
			}
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
