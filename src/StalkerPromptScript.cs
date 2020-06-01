using System;
using UnityEngine;

public class StalkerPromptScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public SmoothLookAtScript Cat;

	public StalkerScript Stalker;

	public GameObject StairBlocker;

	public GameObject FrontDoor;

	public GameObject Father;

	public GameObject Mother;

	public AudioSource MyAudio;

	public UISprite MySprite;

	public Transform CatCage;

	public Transform Door;

	public bool ServedPurpose;

	public bool OpenDoor;

	public float TargetRotation = 5.5f;

	public float Rotation;

	public float Alpha;

	public float Speed;

	public int ID;

	private void Update()
	{
		base.transform.LookAt(this.Yandere.MainCamera.transform);
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
		{
			if (!this.ServedPurpose)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			}
			if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 2f && !this.ServedPurpose && Input.GetButtonDown("A"))
			{
				if (this.ID == 1)
				{
					this.Yandere.MyAnimation.CrossFade("f02_climbTrellis_00");
					this.Yandere.Climbing = true;
					this.Yandere.CanMove = false;
					UnityEngine.Object.Destroy(base.gameObject);
					UnityEngine.Object.Destroy(this.MySprite);
				}
				else if (this.ID == 2)
				{
					this.Stalker.enabled = true;
					this.ServedPurpose = true;
					this.OpenDoor = true;
					this.MyAudio.Play();
				}
				else if (this.ID == 3)
				{
					this.Yandere.MyAnimation["f02_grip_00"].layer = 1;
					this.Yandere.MyAnimation.Play("f02_grip_00");
					this.Yandere.Object = this.CatCage;
					this.CatCage.parent = this.Yandere.RightHand;
					this.CatCage.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.CatCage.localPosition = new Vector3(0.075f, -0.025f, 0.0125f);
					this.StairBlocker.SetActive(true);
					this.FrontDoor.SetActive(true);
					this.Father.SetActive(false);
					this.Mother.SetActive(false);
					this.Cat.enabled = false;
					this.MyAudio.Play();
					UnityEngine.Object.Destroy(base.gameObject);
					UnityEngine.Object.Destroy(this.MySprite);
				}
				else if (this.ID == 4)
				{
					this.ServedPurpose = true;
					this.OpenDoor = true;
					this.MyAudio.Play();
				}
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		if (this.OpenDoor)
		{
			this.Speed += Time.deltaTime * 0.1f;
			this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * this.Speed);
			this.Door.transform.localEulerAngles = new Vector3(this.Door.transform.localEulerAngles.x, this.Rotation, this.Door.transform.localEulerAngles.z);
		}
		this.MySprite.color = new Color(1f, 1f, 1f, this.Alpha);
	}
}
