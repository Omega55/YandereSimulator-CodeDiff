using System;
using UnityEngine;

[Serializable]
public class ShoulderCameraScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public PortalScript Portal;

	public GameObject HeartbrokenCamera;

	public Transform Smartphone;

	public Transform Teacher;

	public Transform ShoulderFocus;

	public Transform ShoulderPOV;

	public Transform CameraFocus;

	public Transform CameraPOV;

	public Transform NoticedFocus;

	public Transform NoticedPOV;

	public Transform StruggleFocus;

	public Transform StrugglePOV;

	public Transform Focus;

	public Vector3 LastPosition;

	public Vector3 TeacherLossFocus;

	public Vector3 TeacherLossPOV;

	public Vector3 LossFocus;

	public Vector3 LossPOV;

	public bool AimingCamera;

	public bool OverShoulder;

	public bool DoNotMove;

	public bool LookDown;

	public bool Scolding;

	public bool Struggle;

	public bool Counter;

	public bool Noticed;

	public bool Spoken;

	public AudioClip StruggleLose;

	public AudioClip Slam;

	public float NoticedHeight;

	public float NoticedTimer;

	public float NoticedSpeed;

	public float Height;

	public float PullBackTimer;

	public float Timer;

	public int NoticedLimit;

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
					((Camera)this.GetComponent(typeof(Camera))).cullingMask = (((Camera)this.GetComponent(typeof(Camera))).cullingMask & -8193);
					if (((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).Teacher)
					{
						this.NoticedHeight = 1.6f;
						this.NoticedLimit = 6;
					}
					else if (((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).Witnessed == "Stalking")
					{
						this.NoticedHeight = 1.481275f;
						this.NoticedLimit = 6;
					}
					else
					{
						this.NoticedHeight = 1.375f;
						this.NoticedLimit = 6;
					}
					this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward * (float)1 + Vector3.up * this.NoticedHeight;
					this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight);
					this.NoticedFocus.position = this.transform.position + this.transform.forward * (float)1;
					this.NoticedSpeed = (float)10;
				}
				this.NoticedTimer += Time.deltaTime;
				if (this.Phase == 1)
				{
					this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * (float)10);
					this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * -0.075f);
					if (this.NoticedTimer > (float)1 && !this.Spoken)
					{
						((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).DetermineSenpaiReaction();
						this.Spoken = true;
					}
					if (this.NoticedTimer > (float)this.NoticedLimit)
					{
						((StudentScript)this.Yandere.Senpai.GetComponent(typeof(StudentScript))).Character.active = false;
						((Camera)this.GetComponent(typeof(Camera))).cullingMask = (((Camera)this.GetComponent(typeof(Camera))).cullingMask | 8192);
						this.Yandere.Subtitle.UpdateLabel("Yandere Whimper", 1, 3.5f);
						this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * (float)1 + Vector3.up * 1.375f;
						this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
						this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 1.375f;
						this.transform.position = this.NoticedPOV.position;
						this.Phase = 2;
					}
				}
				else if (this.Phase == 2)
				{
					this.Yandere.EyeShrink = this.Yandere.EyeShrink + Time.deltaTime * 0.25f;
					this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
					if (this.NoticedTimer > (float)(this.NoticedLimit + 4))
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
			else if (this.Scolding)
			{
				if (this.Timer == (float)0)
				{
					this.NoticedHeight = 1.6f;
					this.NoticedPOV.position = this.Teacher.position + this.Teacher.forward * (float)1 + Vector3.up * this.NoticedHeight;
					this.NoticedPOV.LookAt(this.Teacher.position + Vector3.up * this.NoticedHeight);
					this.NoticedFocus.position = this.Teacher.position + Vector3.up * this.NoticedHeight;
					this.NoticedSpeed = (float)10;
				}
				this.transform.position = Vector3.Lerp(this.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				this.transform.LookAt(this.NoticedFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)6)
				{
					this.Portal.Transition = true;
					this.Portal.FadeOut = true;
				}
				if (this.Timer > (float)7)
				{
					this.Scolding = false;
					this.Timer = (float)0;
				}
			}
			else if (this.Counter)
			{
				if (this.Timer == (float)0)
				{
					this.StruggleFocus.position = this.transform.position + this.transform.forward * (float)1;
					this.StrugglePOV.position = this.transform.position;
				}
				this.transform.position = Vector3.Lerp(this.transform.position, this.StrugglePOV.position, Time.deltaTime * (float)10);
				this.transform.LookAt(this.StruggleFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f && this.Phase < 2)
				{
					this.Yandere.CameraEffects.MurderWitnessed();
					this.Yandere.Jukebox.GameOver();
					this.Phase++;
				}
				if (this.Timer > 1.4f && this.Phase < 3)
				{
					this.Yandere.Subtitle.UpdateLabel("Teacher Attack Reaction", 1, (float)4);
					this.Phase++;
				}
				if (this.Timer > (float)6 && this.Yandere.Armed)
				{
					this.Yandere.Weapon[this.Yandere.Equipped].Drop();
				}
				if (this.Timer > 6.66666f && this.Phase < 4)
				{
					this.audio.PlayOneShot(this.Slam);
					this.Phase++;
				}
				if (this.Timer > (float)10 && this.Phase < 5)
				{
					this.HeartbrokenCamera.active = true;
					this.Phase++;
				}
				if (this.Timer < (float)5)
				{
					this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * 1.4f, Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.5f, 1.4f, 0.3f), Time.deltaTime);
				}
				else if (this.Timer < (float)10)
				{
					if (this.Timer < 6.5f)
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 1.5f, Time.deltaTime);
					}
					else
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, (float)0, Time.deltaTime * 0.428571433f);
					}
					this.transform.Translate(Vector3.back * Time.deltaTime * (float)10 * this.PullBackTimer);
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3((float)0, 0.114666663f, -0.84f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.6f, 0.114666663f, -0.84f), Time.deltaTime);
				}
				else
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3((float)0, 0.3f, -0.4f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(1.05f, 0.3f, -0.4f), Time.deltaTime);
				}
			}
			else if (this.Struggle)
			{
				this.transform.position = Vector3.Lerp(this.transform.position, this.StrugglePOV.position, Time.deltaTime * (float)10);
				this.transform.LookAt(this.StruggleFocus);
				if (this.Yandere.Lost)
				{
					this.StruggleFocus.localPosition = Vector3.MoveTowards(this.StruggleFocus.localPosition, this.LossFocus, Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.MoveTowards(this.StrugglePOV.localPosition, this.LossPOV, Time.deltaTime);
					if (this.Timer == (float)0)
					{
						this.audio.clip = this.StruggleLose;
						this.audio.Play();
					}
					this.Timer += Time.deltaTime;
					if (this.Timer < (float)3)
					{
						this.transform.Translate(Vector3.back * Time.deltaTime * (float)10 * this.Timer * ((float)3 - this.Timer));
					}
					else if (!this.HeartbrokenCamera.active)
					{
						this.HeartbrokenCamera.active = true;
						this.Yandere.Jukebox.GameOver();
						this.enabled = false;
					}
				}
			}
			else if (this.Yandere.Attacked)
			{
				this.Focus.transform.parent = null;
				this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime);
				this.transform.LookAt(this.Focus);
			}
			else if (this.LookDown)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer < (float)5)
				{
					this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.Hips.position + Vector3.up * (float)3 + Vector3.right * 0.1f, Time.deltaTime * this.Timer);
					this.Focus.transform.parent = null;
					this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime * this.Timer);
					this.transform.LookAt(this.Focus);
				}
				else if (!this.HeartbrokenCamera.active)
				{
					this.HeartbrokenCamera.active = true;
					this.Yandere.Jukebox.GameOver();
					this.enabled = false;
				}
			}
			else if ((this.Yandere.Talking || this.Yandere.Won) && !this.RPGCamera.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer < 0.5f)
				{
					this.transform.position = Vector3.Lerp(this.transform.position, this.LastPosition, Time.deltaTime * (float)10);
					if (this.Yandere.Talking)
					{
						this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * (float)10);
						this.transform.LookAt(this.ShoulderFocus);
					}
					else
					{
						this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * (float)10);
						this.transform.LookAt(this.StruggleFocus);
					}
				}
				else
				{
					this.RPGCamera.enabled = true;
					this.Yandere.MyController.enabled = true;
					this.Yandere.Talking = false;
					this.Yandere.CanMove = true;
					this.Yandere.Pursuer = null;
					this.Yandere.Chased = false;
					this.Yandere.Won = false;
					this.Timer = (float)0;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
