using System;
using UnityEngine;

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

	public float ScrollSpeed = 1f;

	public float TimerLimit = 0.1f;

	public float TalkSpeed = 10f;

	public float LipStrength = 0.0001f;

	public float MouthExtent = 5f;

	public float MouthTarget;

	public float MouthTimer;

	private void Start()
	{
		this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].time = UnityEngine.Random.Range(0f, this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].length);
		this.Yandere.WearOutdoorShoes();
		this.Senpai.WearOutdoorShoes();
		this.Rival.WearOutdoorShoes();
	}

	private void Update()
	{
		for (int i = 1; i < 3; i++)
		{
			Transform transform = this.Neighborhood[i];
			transform.position = new Vector3(transform.position.x - Time.deltaTime * this.ScrollSpeed, transform.position.y, transform.position.z);
			if (transform.position.x < -160f)
			{
				transform.position = new Vector3(transform.position.x + 320f, transform.position.y, transform.position.z);
			}
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 10f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 10f;
		}
		if (Input.GetKeyDown("space"))
		{
			this.Yandere.WearOutdoorShoes();
			this.Senpai.WearOutdoorShoes();
			this.Rival.WearOutdoorShoes();
		}
	}

	private void LateUpdate()
	{
		this.RivalNeck.localEulerAngles = new Vector3(this.RivalNeck.localEulerAngles.x, 15f, this.RivalNeck.localEulerAngles.z);
		this.RivalHead.localEulerAngles = new Vector3(this.RivalHead.localEulerAngles.x, 15f, this.RivalHead.localEulerAngles.z);
		this.RivalEyeR.localEulerAngles = new Vector3(this.RivalEyeR.localEulerAngles.x, 95f, this.RivalEyeR.localEulerAngles.z);
		this.RivalEyeL.localEulerAngles = new Vector3(this.RivalEyeL.localEulerAngles.x, -85f, this.RivalEyeL.localEulerAngles.z);
		this.SenpaiNeck.localEulerAngles = new Vector3(this.SenpaiNeck.localEulerAngles.x, -15f, this.SenpaiNeck.localEulerAngles.z);
		this.SenpaiHead.localEulerAngles = new Vector3(this.SenpaiHead.localEulerAngles.x, -15f, this.SenpaiHead.localEulerAngles.z);
		this.SenpaiEyeR.localEulerAngles = new Vector3(this.SenpaiEyeR.localEulerAngles.x, 85f, this.SenpaiEyeR.localEulerAngles.z);
		this.SenpaiEyeL.localEulerAngles = new Vector3(this.SenpaiEyeL.localEulerAngles.x, -95f, this.SenpaiEyeL.localEulerAngles.z);
		this.YandereNeck.localEulerAngles = new Vector3(this.YandereNeck.localEulerAngles.x, 7.5f, this.YandereNeck.localEulerAngles.z);
		this.YandereHead.localEulerAngles = new Vector3(this.YandereHead.localEulerAngles.x, 7.5f, this.YandereHead.localEulerAngles.z);
		this.MouthTimer += Time.deltaTime;
		if (this.MouthTimer > this.TimerLimit)
		{
			this.MouthTarget = UnityEngine.Random.Range(40f, 40f + this.MouthExtent);
			this.MouthTimer = 0f;
		}
		this.RivalJaw.localEulerAngles = new Vector3(this.RivalJaw.localEulerAngles.x, this.RivalJaw.localEulerAngles.y, Mathf.Lerp(this.RivalJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
		this.RivalLipL.localPosition = new Vector3(this.RivalLipL.localPosition.x, Mathf.Lerp(this.RivalLipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.RivalLipL.localPosition.z);
		this.RivalLipR.localPosition = new Vector3(this.RivalLipR.localPosition.x, Mathf.Lerp(this.RivalLipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.RivalLipR.localPosition.z);
	}
}
