﻿using System;
using UnityEngine;

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

	public bool Summoning;

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

	private void LateUpdate()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.OverShoulder)
			{
				if (this.RPGCamera.enabled)
				{
					this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
					this.LastPosition = base.transform.position;
					this.RPGCamera.enabled = false;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.ShoulderPOV.position, Time.deltaTime * 10f);
				this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * 10f);
				base.transform.LookAt(this.ShoulderFocus);
			}
			else if (this.AimingCamera)
			{
				base.transform.position = this.CameraPOV.position;
				base.transform.LookAt(this.CameraFocus);
			}
			else if (this.Noticed)
			{
				if (this.NoticedTimer == 0f)
				{
					base.GetComponent<Camera>().cullingMask &= -8193;
					StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
					if (component.Teacher)
					{
						this.NoticedHeight = 1.6f;
						this.NoticedLimit = 6;
					}
					else if (component.Witnessed == StudentWitnessType.Stalking)
					{
						this.NoticedHeight = 1.481275f;
						this.NoticedLimit = 7;
					}
					else
					{
						this.NoticedHeight = 1.375f;
						this.NoticedLimit = 6;
					}
					this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward + Vector3.up * this.NoticedHeight;
					this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight);
					this.NoticedFocus.position = base.transform.position + base.transform.forward;
					this.NoticedSpeed = 10f;
				}
				this.NoticedTimer += Time.deltaTime;
				if (this.Phase == 1)
				{
					this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * 10f);
					this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * -0.075f);
					if (this.NoticedTimer > 1f && !this.Spoken && !this.Yandere.Senpai.GetComponent<StudentScript>().Teacher)
					{
						this.Yandere.Senpai.GetComponent<StudentScript>().DetermineSenpaiReaction();
						this.Spoken = true;
					}
					if (this.NoticedTimer > (float)this.NoticedLimit)
					{
						this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(false);
						base.GetComponent<Camera>().cullingMask |= 8192;
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.YandereWhimper, 1, 3.5f);
						this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward + Vector3.up * 1.375f;
						this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
						this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 1.375f;
						base.transform.position = this.NoticedPOV.position;
						this.Phase = 2;
					}
				}
				else if (this.Phase == 2)
				{
					this.Yandere.EyeShrink += Time.deltaTime * 0.25f;
					this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
					if (this.NoticedTimer > (float)(this.NoticedLimit + 4))
					{
						this.NoticedPOV.Translate(Vector3.back * 2f);
						this.NoticedPOV.transform.position = new Vector3(this.NoticedPOV.transform.position.x, this.Yandere.transform.position.y + 1f, this.NoticedPOV.transform.position.z);
						this.NoticedSpeed = 1f;
						this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
						this.HeartbrokenCamera.SetActive(true);
						this.Yandere.Collapse = true;
						this.Phase = 3;
					}
				}
				else if (this.Phase == 3)
				{
					this.NoticedFocus.transform.position = new Vector3(this.NoticedFocus.transform.position.x, Mathf.Lerp(this.NoticedFocus.transform.position.y, this.Yandere.transform.position.y + 1f, Time.deltaTime), this.NoticedFocus.transform.position.z);
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				base.transform.LookAt(this.NoticedFocus);
			}
			else if (this.Scolding)
			{
				if (this.Timer == 0f)
				{
					this.NoticedHeight = 1.6f;
					this.NoticedPOV.position = this.Teacher.position + this.Teacher.forward + Vector3.up * this.NoticedHeight;
					this.NoticedPOV.LookAt(this.Teacher.position + Vector3.up * this.NoticedHeight);
					this.NoticedFocus.position = this.Teacher.position + Vector3.up * this.NoticedHeight;
					this.NoticedSpeed = 10f;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				base.transform.LookAt(this.NoticedFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 6f)
				{
					this.Portal.ClassDarkness.enabled = true;
					this.Portal.Transition = true;
					this.Portal.FadeOut = true;
				}
				if (this.Timer > 7f)
				{
					this.Scolding = false;
					this.Timer = 0f;
				}
			}
			else if (this.Counter)
			{
				if (this.Timer == 0f)
				{
					this.StruggleFocus.position = base.transform.position + base.transform.forward;
					this.StrugglePOV.position = base.transform.position;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
				base.transform.LookAt(this.StruggleFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f && this.Phase < 2)
				{
					this.Yandere.CameraEffects.MurderWitnessed();
					this.Yandere.Jukebox.GameOver();
					this.Phase++;
				}
				if (this.Timer > 1.4f && this.Phase < 3)
				{
					this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherAttackReaction, 1, 4f);
					this.Phase++;
				}
				if (this.Timer > 6f && this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.Drop();
				}
				if (this.Timer > 6.66666f && this.Phase < 4)
				{
					base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
					this.Phase++;
				}
				if (this.Timer > 10f && this.Phase < 5)
				{
					this.HeartbrokenCamera.SetActive(true);
					this.Phase++;
				}
				if (this.Timer < 5f)
				{
					this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * 1.4f, Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.5f, 1.4f, 0.3f), Time.deltaTime);
				}
				else if (this.Timer < 10f)
				{
					if (this.Timer < 6.5f)
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 1.5f, Time.deltaTime);
					}
					else
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 0f, Time.deltaTime * 0.428571433f);
					}
					base.transform.Translate(Vector3.back * Time.deltaTime * 10f * this.PullBackTimer);
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.114666663f, -0.84f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.6f, 0.114666663f, -0.84f), Time.deltaTime);
				}
				else
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.3f, -0.4f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(1.05f, 0.3f, -0.4f), Time.deltaTime);
				}
			}
			else if (this.Struggle)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
				base.transform.LookAt(this.StruggleFocus);
				if (this.Yandere.Lost)
				{
					this.StruggleFocus.localPosition = Vector3.MoveTowards(this.StruggleFocus.localPosition, this.LossFocus, Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.MoveTowards(this.StrugglePOV.localPosition, this.LossPOV, Time.deltaTime);
					if (this.Timer == 0f)
					{
						AudioSource component2 = base.GetComponent<AudioSource>();
						component2.clip = this.StruggleLose;
						component2.Play();
					}
					this.Timer += Time.deltaTime;
					if (this.Timer < 3f)
					{
						base.transform.Translate(Vector3.back * (Time.deltaTime * 10f * this.Timer * (3f - this.Timer)));
					}
					else if (!this.HeartbrokenCamera.activeInHierarchy)
					{
						this.HeartbrokenCamera.SetActive(true);
						this.Yandere.Jukebox.GameOver();
						base.enabled = false;
					}
				}
			}
			else if (this.Yandere.Attacked)
			{
				this.Focus.transform.parent = null;
				this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime);
				base.transform.LookAt(this.Focus);
			}
			else if (this.LookDown)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer < 5f)
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.Yandere.Hips.position + Vector3.up * 3f + Vector3.right * 0.1f, Time.deltaTime * this.Timer);
					this.Focus.transform.parent = null;
					this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime * this.Timer);
					base.transform.LookAt(this.Focus);
				}
				else if (!this.HeartbrokenCamera.activeInHierarchy)
				{
					this.HeartbrokenCamera.SetActive(true);
					this.Yandere.Jukebox.GameOver();
					base.enabled = false;
				}
			}
			else if (this.Summoning)
			{
				if (this.Phase == 1)
				{
					this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 1.7f + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f;
					this.NoticedFocus.position = base.transform.position + base.transform.forward;
					this.NoticedSpeed = 10f;
					this.Phase++;
				}
				else if (this.Phase == 2)
				{
					this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
					this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.transform.position + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f, Time.deltaTime * 10f);
					this.Timer += Time.deltaTime;
					if (this.Timer > 2f)
					{
						this.Yandere.Stand.Spawn();
						this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 2f + Vector3.up * 2.4f;
						this.Timer = 0f;
						this.Phase++;
					}
				}
				else if (this.Phase == 3)
				{
					this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
					this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 2.4f;
					this.Yandere.Stand.Stand.SetActive(true);
					this.Timer += Time.deltaTime;
					if (this.Timer > 5f)
					{
						this.Phase++;
					}
				}
				else if (this.Phase == 4)
				{
					this.Yandere.Stand.transform.localPosition = new Vector3(this.Yandere.Stand.transform.localPosition.x, 0f, this.Yandere.Stand.transform.localPosition.z);
					this.Yandere.Jukebox.PlayJojo();
					this.Yandere.Talking = true;
					this.Summoning = false;
					this.Timer = 0f;
					this.Phase = 1;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				base.transform.LookAt(this.NoticedFocus);
			}
			else if ((this.Yandere.Talking || this.Yandere.Won) && !this.RPGCamera.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer < 0.5f)
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.LastPosition, Time.deltaTime * 10f);
					if (this.Yandere.Talking)
					{
						this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * 10f);
						base.transform.LookAt(this.ShoulderFocus);
					}
					else
					{
						this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * 10f);
						base.transform.LookAt(this.StruggleFocus);
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
					this.Timer = 0f;
				}
			}
		}
	}
}
