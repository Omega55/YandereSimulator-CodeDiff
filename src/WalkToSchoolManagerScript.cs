using System;
using UnityEngine;

[Serializable]
public class WalkToSchoolManagerScript : MonoBehaviour
{
	public CosmeticScript Yandere;

	public CosmeticScript Senpai;

	public CosmeticScript Rival;

	public Transform[] Neighborhood;

	public Transform RivalNeck;

	public Transform RivalHead;

	public Transform RivalEyeR;

	public Transform RivalEyeL;

	public Transform RivalJaw;

	public Transform RivalLipL;

	public Transform RivalLipR;

	public Transform SenpaiNeck;

	public Transform SenpaiHead;

	public Transform SenpaiEyeR;

	public Transform SenpaiEyeL;

	public Transform YandereNeck;

	public Transform YandereHead;

	public Transform YandereEyeR;

	public Transform YandereEyeL;

	public float ScrollSpeed;

	public float TimerLimit;

	public float TalkSpeed;

	public float LipStrength;

	public float MouthExtent;

	public float MouthTarget;

	public float MouthTimer;

	public WalkToSchoolManagerScript()
	{
		this.ScrollSpeed = 1f;
		this.TimerLimit = 0.1f;
		this.TalkSpeed = 10f;
		this.LipStrength = 0.0001f;
		this.MouthExtent = 5f;
	}

	public virtual void Start()
	{
		this.Yandere.Character.animation["f02_newWalk_00"].time = UnityEngine.Random.Range((float)0, this.Yandere.Character.animation["f02_newWalk_00"].length);
		this.Yandere.WearOutdoorShoes();
		this.Senpai.WearOutdoorShoes();
		this.Rival.WearOutdoorShoes();
	}

	public virtual void Update()
	{
		for (int i = 1; i < 3; i++)
		{
			float x = this.Neighborhood[i].position.x - Time.deltaTime * this.ScrollSpeed;
			Vector3 position = this.Neighborhood[i].position;
			float num = position.x = x;
			Vector3 vector = this.Neighborhood[i].position = position;
			if (this.Neighborhood[i].position.x < (float)-160)
			{
				float x2 = this.Neighborhood[i].position.x + (float)320;
				Vector3 position2 = this.Neighborhood[i].position;
				float num2 = position2.x = x2;
				Vector3 vector2 = this.Neighborhood[i].position = position2;
			}
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)10;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)10;
		}
		if (Input.GetKeyDown("space"))
		{
			this.Yandere.WearOutdoorShoes();
			this.Senpai.WearOutdoorShoes();
			this.Rival.WearOutdoorShoes();
		}
	}

	public virtual void LateUpdate()
	{
		int num = 15;
		Vector3 localEulerAngles = this.RivalNeck.localEulerAngles;
		float num2 = localEulerAngles.y = (float)num;
		Vector3 vector = this.RivalNeck.localEulerAngles = localEulerAngles;
		int num3 = 15;
		Vector3 localEulerAngles2 = this.RivalHead.localEulerAngles;
		float num4 = localEulerAngles2.y = (float)num3;
		Vector3 vector2 = this.RivalHead.localEulerAngles = localEulerAngles2;
		int num5 = 95;
		Vector3 localEulerAngles3 = this.RivalEyeR.localEulerAngles;
		float num6 = localEulerAngles3.y = (float)num5;
		Vector3 vector3 = this.RivalEyeR.localEulerAngles = localEulerAngles3;
		int num7 = -85;
		Vector3 localEulerAngles4 = this.RivalEyeL.localEulerAngles;
		float num8 = localEulerAngles4.y = (float)num7;
		Vector3 vector4 = this.RivalEyeL.localEulerAngles = localEulerAngles4;
		int num9 = -15;
		Vector3 localEulerAngles5 = this.SenpaiNeck.localEulerAngles;
		float num10 = localEulerAngles5.y = (float)num9;
		Vector3 vector5 = this.SenpaiNeck.localEulerAngles = localEulerAngles5;
		int num11 = -15;
		Vector3 localEulerAngles6 = this.SenpaiHead.localEulerAngles;
		float num12 = localEulerAngles6.y = (float)num11;
		Vector3 vector6 = this.SenpaiHead.localEulerAngles = localEulerAngles6;
		int num13 = 85;
		Vector3 localEulerAngles7 = this.SenpaiEyeR.localEulerAngles;
		float num14 = localEulerAngles7.y = (float)num13;
		Vector3 vector7 = this.SenpaiEyeR.localEulerAngles = localEulerAngles7;
		int num15 = -95;
		Vector3 localEulerAngles8 = this.SenpaiEyeL.localEulerAngles;
		float num16 = localEulerAngles8.y = (float)num15;
		Vector3 vector8 = this.SenpaiEyeL.localEulerAngles = localEulerAngles8;
		float y = 7.5f;
		Vector3 localEulerAngles9 = this.YandereNeck.localEulerAngles;
		float num17 = localEulerAngles9.y = y;
		Vector3 vector9 = this.YandereNeck.localEulerAngles = localEulerAngles9;
		float y2 = 7.5f;
		Vector3 localEulerAngles10 = this.YandereHead.localEulerAngles;
		float num18 = localEulerAngles10.y = y2;
		Vector3 vector10 = this.YandereHead.localEulerAngles = localEulerAngles10;
		this.MouthTimer += Time.deltaTime;
		if (this.MouthTimer > this.TimerLimit)
		{
			this.MouthTarget = UnityEngine.Random.Range(40f, 40f + this.MouthExtent);
			this.MouthTimer = (float)0;
		}
		float z = Mathf.Lerp(this.RivalJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed);
		Vector3 localEulerAngles11 = this.RivalJaw.localEulerAngles;
		float num19 = localEulerAngles11.z = z;
		Vector3 vector11 = this.RivalJaw.localEulerAngles = localEulerAngles11;
		float y3 = Mathf.Lerp(this.RivalLipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed);
		Vector3 localPosition = this.RivalLipL.localPosition;
		float num20 = localPosition.y = y3;
		Vector3 vector12 = this.RivalLipL.localPosition = localPosition;
		float y4 = Mathf.Lerp(this.RivalLipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed);
		Vector3 localPosition2 = this.RivalLipR.localPosition;
		float num21 = localPosition2.y = y4;
		Vector3 vector13 = this.RivalLipR.localPosition = localPosition2;
	}

	public virtual void Main()
	{
	}
}
