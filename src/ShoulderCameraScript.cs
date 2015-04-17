using System;
using UnityEngine;

[Serializable]
public class ShoulderCameraScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public GameObject HeartbrokenCamera;

	public Transform Smartphone;

	public Transform ShoulderFocus;

	public Transform ShoulderPOV;

	public Transform CameraFocus;

	public Transform CameraPOV;

	public Transform NoticedFocus;

	public Transform NoticedPOV;

	public Vector3 LastPosition;

	public bool AimingCamera;

	public bool OverShoulder;

	public bool Noticed;

	public float NoticedHeight;

	public float NoticedTimer;

	public float NoticedSpeed;

	public float Height;

	public float Timer;

	public int Phase;

	public virtual void LateUpdate()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.OverShoulder)
			{
				if (this.RPGCamera.enabled)
				{
					this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
					this.LastPosition = this.transform.position;
					this.RPGCamera.enabled = false;
				}
				this.transform.position = Vector3.Lerp(this.transform.position, this.ShoulderPOV.position, Time.deltaTime * (float)10);
				this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * (float)10);
				this.transform.LookAt(this.ShoulderFocus);
			}
			else if (this.AimingCamera)
			{
				this.transform.position = this.CameraPOV.position;
				this.transform.LookAt(this.CameraFocus);
			}
			else if (this.Noticed)
			{
				if (this.NoticedTimer == (float)0)
				{
					this.Yandere.MyRenderer.enabled = false;
					if (((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).Witnessed == "Stalking")
					{
						this.NoticedHeight = 1.481275f;
						this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward * (float)1 + Vector3.up * 1.481275f;
						this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * 1.481275f);
					}
					else
					{
						this.NoticedHeight = 1.375f;
						this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward * (float)1 + Vector3.up * 1.375f;
						this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * 1.375f);
					}
					this.NoticedFocus.position = this.transform.position + this.transform.forward * (float)1;
					this.NoticedSpeed = (float)10;
				}
				this.NoticedTimer += Time.deltaTime;
				if (this.Phase == 1)
				{
					this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * (float)10);
					this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.1f);
					if (this.NoticedTimer > (float)5)
					{
						((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).MyRenderer.enabled = false;
						this.Yandere.MyRenderer.enabled = true;
						this.Yandere.Subtitle.UpdateLabel("Yandere Whimper", 1, 3.5f);
						this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * (float)1 + Vector3.up * 1.375f;
						this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
						this.NoticedFocus.position = this.transform.position + this.transform.forward * (float)1;
						this.Phase = 2;
					}
				}
				else if (this.Phase == 2)
				{
					this.Yandere.EyeShrink = this.Yandere.EyeShrink + Time.deltaTime * 0.25f;
					this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.transform.position + Vector3.up * 1.375f, Time.deltaTime * (float)10);
					this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.1f);
					if (this.NoticedTimer > (float)9)
					{
						this.NoticedPOV.Translate(Vector3.back * (float)2);
						float y = this.Yandere.transform.position.y + (float)1;
						Vector3 position = this.NoticedPOV.transform.position;
						float num = position.y = y;
						Vector3 vector = this.NoticedPOV.transform.position = position;
						this.NoticedSpeed = (float)1;
						this.Yandere.Character.animation.CrossFade("f02_down_22");
						this.HeartbrokenCamera.active = true;
						this.Yandere.Collapse = true;
						this.Phase = 3;
					}
				}
				else if (this.Phase == 3)
				{
					float y2 = Mathf.Lerp(this.NoticedFocus.transform.position.y, this.Yandere.transform.position.y + (float)1, Time.deltaTime);
					Vector3 position2 = this.NoticedFocus.transform.position;
					float num2 = position2.y = y2;
					Vector3 vector2 = this.NoticedFocus.transform.position = position2;
				}
				this.transform.position = Vector3.Lerp(this.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				this.transform.LookAt(this.NoticedFocus);
			}
			else if (this.Yandere.Talking && !this.RPGCamera.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer < 0.5f)
				{
					this.transform.position = Vector3.Lerp(this.transform.position, this.LastPosition, Time.deltaTime * (float)10);
					this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * (float)10);
					this.transform.LookAt(this.ShoulderFocus);
				}
				else
				{
					this.RPGCamera.enabled = true;
					this.Yandere.Talking = false;
					this.Yandere.CanMove = true;
					this.Timer = (float)0;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
