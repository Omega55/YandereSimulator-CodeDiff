﻿using System;
using UnityEngine;

public class HenshinScript : MonoBehaviour
{
	public RiggedAccessoryAttacher MiyukiCostume;

	public SkinnedMeshRenderer MiyukiRenderer;

	public Renderer WhiteMiyukiRenderer;

	public Renderer MiyukiHairRenderer;

	public Renderer White;

	public Animation WhiteMiyukiAnim;

	public Animation MiyukiAnim;

	public GameObject HenshinSparkleBlast;

	public GameObject MiyukiHair;

	public ParticleSystem HenshinSparkles;

	public ParticleSystem SpinSparkles;

	public ParticleSystem Sparkles;

	public AudioListener Listener;

	public YandereScript Yandere;

	public GameObject[] Cameras;

	public Camera MiyukiCamera;

	public Transform RightHand;

	public Transform Miyuki;

	public Transform Wand;

	public Transform TV;

	public float Rotation;

	public float Timer;

	public int Phase;

	public Texture MiyukiFace;

	public Texture MiyukiSkin;

	public Mesh NudeMesh;

	public Texture OriginalBody;

	public Texture OriginalFace;

	public Mesh OriginalMesh;

	public bool TransformingYandere;

	public bool Debugging;

	public Quaternion OriginalRotation;

	public Vector3 OriginalPosition;

	public AudioSource MyAudio;

	public AudioClip Catchphrase;

	public void TransformYandere()
	{
		this.TransformingYandere = true;
		this.Cameras[1].SetActive(false);
		this.Cameras[2].SetActive(false);
		this.Cameras[3].SetActive(false);
		this.Cameras[4].SetActive(false);
		this.Cameras[5].SetActive(false);
		this.Cameras[6].SetActive(false);
		this.MiyukiCamera.targetTexture = null;
		this.Listener.enabled = true;
		this.OriginalPosition = this.Yandere.transform.position;
		this.OriginalRotation = this.Yandere.transform.rotation;
		this.Yandere.CharacterAnimation.Play("f02_henshin_00");
		this.Yandere.transform.parent = this.Miyuki;
		this.Yandere.enabled = false;
		this.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
		this.Yandere.Accessories[this.Yandere.AccessoryID].SetActive(false);
		Physics.SyncTransforms();
		AudioSource.PlayClipAtPoint(this.Catchphrase, base.transform.position);
		this.MyAudio.Play();
		this.Start();
	}

	private void Start()
	{
		if (this.OriginalMesh == null)
		{
			this.OriginalMesh = this.MiyukiRenderer.sharedMesh;
			this.OriginalFace = this.MiyukiRenderer.materials[0].mainTexture;
			this.OriginalBody = this.MiyukiRenderer.materials[1].mainTexture;
		}
		this.MiyukiRenderer.sharedMesh = this.OriginalMesh;
		this.MiyukiRenderer.materials[0].mainTexture = this.OriginalFace;
		this.MiyukiRenderer.materials[1].mainTexture = this.OriginalBody;
		this.MiyukiRenderer.materials[2].mainTexture = this.OriginalBody;
		this.MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, 0f);
		this.WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, 0f);
		this.WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
		this.WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, 0f);
		this.Wand.gameObject.SetActive(true);
		this.Wand.transform.parent = base.transform.parent;
		this.Wand.localPosition = new Vector3(0f, -0.6538f, 0.04405f);
		this.White.material.color = new Color(1f, 1f, 1f, 1f);
		this.Miyuki.gameObject.SetActive(false);
		if (this.MiyukiCostume.newRenderer != null)
		{
			this.MiyukiCostume.newRenderer.enabled = false;
		}
		this.HenshinSparkleBlast.SetActive(false);
		this.HenshinSparkles.emissionRate = 1f;
		this.HenshinSparkles.Clear();
		this.HenshinSparkles.Stop();
		this.SpinSparkles.Clear();
		this.SpinSparkles.Stop();
		this.Sparkles.emissionRate = 1f;
		this.Sparkles.startSize = 0.1f;
		this.Sparkles.Clear();
		this.Sparkles.Stop();
		this.Rotation = 3600f;
		this.Timer = 0f;
		this.Phase = 1;
		if (this.Debugging)
		{
			Time.timeScale = 1f;
		}
	}

	private void Update()
	{
		if (this.TransformingYandere && Input.GetKeyDown("="))
		{
			this.MyAudio.pitch += 1f;
			Time.timeScale += 1f;
		}
		if (this.Debugging)
		{
			if (Input.GetKeyDown("="))
			{
				Time.timeScale += 1f;
			}
			else if (Input.GetKeyDown("-"))
			{
				Time.timeScale -= 1f;
			}
		}
		if (Vector3.Distance(this.Yandere.transform.position, this.TV.position) > 15f)
		{
			this.MiyukiCamera.enabled = false;
		}
		else
		{
			this.MiyukiCamera.enabled = true;
			if (this.Phase < 3)
			{
				this.Wand.localPosition = Vector3.Lerp(this.Wand.localPosition, new Vector3(0f, -0.2833333f, 1f), Time.deltaTime);
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 2f);
				this.Wand.localEulerAngles = new Vector3(-90f, 0f, this.Rotation);
			}
			if (this.Phase == 1)
			{
				this.White.material.color -= new Color(0f, 0f, 0f, Time.deltaTime);
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					this.White.material.color = new Color(1f, 1f, 1f, 0f);
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (!this.Sparkles.isPlaying)
				{
					this.Sparkles.Play();
				}
				this.Sparkles.startSize += Time.deltaTime * 0.25f;
				this.Sparkles.emissionRate += Time.deltaTime * 5f;
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					this.White.material.color += new Color(1f, 1f, 1f, Time.deltaTime);
					if (this.White.material.color.a >= 1f)
					{
						this.Miyuki.localEulerAngles = new Vector3(0f, 180f, 45f);
						this.Miyuki.localPosition = new Vector3(0f, 0f, 0.5f);
						this.Miyuki.gameObject.SetActive(true);
						this.Wand.gameObject.SetActive(false);
						if (this.TransformingYandere)
						{
							this.MiyukiHairRenderer.enabled = false;
							this.MiyukiRenderer.enabled = false;
							this.MiyukiHair.SetActive(false);
							this.Yandere.CharacterAnimation.Play("f02_henshin_00");
						}
						this.Sparkles.emissionRate = 1f;
						this.Sparkles.startSize = 0.1f;
						this.Sparkles.Clear();
						this.Sparkles.Stop();
						this.Timer = 0f;
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 3)
			{
				this.White.material.color -= new Color(0f, 0f, 0f, Time.deltaTime);
				this.Miyuki.localPosition -= new Vector3(Time.deltaTime * 0.1f, Time.deltaTime * 0.1f, 0f);
				this.Rotation += Time.deltaTime;
				this.Miyuki.Rotate(0f, this.Rotation * 360f * Time.deltaTime, 0f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 2f)
				{
					if (!this.TransformingYandere)
					{
						float a = this.Timer - 2f;
						this.MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, a);
						this.WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, a);
						this.WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, a);
						this.WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, a);
					}
					if (this.Timer > 5f)
					{
						this.Miyuki.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Miyuki.localPosition = new Vector3(0f, -0.795f, 2f);
						this.Timer = 0f;
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 4)
			{
				this.Miyuki.Rotate(0f, this.Rotation * 360f * Time.deltaTime, 0f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					if (!this.HenshinSparkles.isPlaying)
					{
						this.HenshinSparkles.Play();
					}
					this.HenshinSparkles.emissionRate += Time.deltaTime * 100f;
					if (this.Timer > 5f)
					{
						this.Wand.gameObject.SetActive(true);
						this.Wand.parent = this.RightHand;
						this.Wand.localEulerAngles = new Vector3(0f, 0f, 90f);
						this.Wand.localPosition = new Vector3(0f, 0f, 0f);
						if (this.TransformingYandere)
						{
							this.MiyukiRenderer.enabled = true;
							this.Yandere.gameObject.SetActive(false);
						}
						this.MiyukiCostume.gameObject.SetActive(true);
						this.MiyukiHair.SetActive(true);
						if (this.MiyukiCostume.newRenderer != null)
						{
							this.MiyukiCostume.newRenderer.enabled = true;
						}
						this.MiyukiRenderer.sharedMesh = this.NudeMesh;
						this.MiyukiRenderer.materials[0].mainTexture = this.MiyukiFace;
						this.MiyukiRenderer.materials[1].mainTexture = this.MiyukiSkin;
						this.MiyukiRenderer.materials[2].mainTexture = this.MiyukiSkin;
						this.MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, 0f);
						this.WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, 0f);
						this.WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
						this.WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, 0f);
						this.Miyuki.localEulerAngles = new Vector3(15f, -135f, 15f);
						this.WhiteMiyukiAnim.Play("f02_miyukiPose_00");
						this.MiyukiAnim.Play("f02_miyukiPose_00");
						this.HenshinSparkleBlast.SetActive(true);
						this.HenshinSparkles.emissionRate = 1f;
						this.HenshinSparkles.Clear();
						this.HenshinSparkles.Stop();
						this.SpinSparkles.Clear();
						this.SpinSparkles.Stop();
						this.Timer = 0f;
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 5)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.White.material.color += new Color(0f, 0f, 0f, Time.deltaTime);
					if (this.White.material.color.a >= 1f)
					{
						if (this.TransformingYandere)
						{
							this.Cameras[1].SetActive(true);
							this.Cameras[2].SetActive(true);
							this.Cameras[3].SetActive(true);
							this.Cameras[4].SetActive(true);
							this.Cameras[5].SetActive(true);
							this.Cameras[6].SetActive(true);
							base.gameObject.SetActive(false);
							this.Yandere.transform.parent = null;
							this.Yandere.gameObject.SetActive(true);
							this.Yandere.transform.position = this.OriginalPosition;
							this.Yandere.transform.rotation = this.OriginalRotation;
							this.Yandere.Stance.Current = StanceType.Standing;
							this.Yandere.WeaponManager.Weapons[19].AnimID = 0;
							this.Yandere.SetAnimationLayers();
							this.Yandere.enabled = true;
							this.Yandere.CanMove = true;
							this.Yandere.Miyuki();
							base.transform.parent.gameObject.SetActive(false);
							Time.timeScale = 1f;
						}
						else
						{
							this.Start();
						}
					}
				}
			}
		}
	}
}
