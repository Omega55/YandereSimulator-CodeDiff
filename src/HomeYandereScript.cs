﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeYandereScript : MonoBehaviour
{
	public CharacterController MyController;

	public HomeVideoGamesScript HomeVideoGames;

	public HomeCameraScript HomeCamera;

	public UISprite HomeDarkness;

	public GameObject CutsceneYandere;

	public GameObject Controller;

	public GameObject Character;

	public GameObject Disc;

	public float WalkSpeed;

	public float RunSpeed;

	public bool CanMove;

	public AudioClip DiscScratch;

	public Renderer PonytailRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Transform Ponytail;

	public Transform HairR;

	public Transform HairL;

	public bool HidePony;

	public int Hairstyle;

	public int VictimID;

	public float Timer;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] UniformTextures;

	public Texture FaceTexture;

	public Mesh[] Uniforms;

	public Texture PajamaTexture;

	public Mesh PajamaMesh;

	private void Start()
	{
		if (this.CutsceneYandere != null)
		{
			this.CutsceneYandere.GetComponent<Animation>()["f02_texting_00"].speed = 0.1f;
		}
		if (SceneManager.GetActiveScene().name.Equals("HomeScene"))
		{
			if (PlayerPrefs.GetInt("DraculaDefeated") == 0)
			{
				base.transform.position = Vector3.zero;
				base.transform.eulerAngles = Vector3.zero;
				if (PlayerPrefs.GetInt("Night") == 0)
				{
					this.ChangeSchoolwear();
					base.StartCoroutine(this.ApplyCustomCostume());
				}
				else
				{
					this.WearPajamas();
				}
			}
			else if (PlayerPrefs.GetInt("StartInBasement") == 1)
			{
				PlayerPrefs.SetInt("StartInBasement", 0);
				base.transform.position = new Vector3(0f, -135f, 0f);
				base.transform.eulerAngles = Vector3.zero;
			}
			else
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				this.Character.GetComponent<Animation>().Play("f02_discScratch_00");
				this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				this.Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
				this.HomeCamera.Target = this.HomeCamera.Targets[5];
				this.Disc.SetActive(true);
				this.WearPajamas();
			}
		}
		Time.timeScale = 1f;
		this.UpdateHair();
	}

	private void Update()
	{
		if (!this.Disc.activeInHierarchy)
		{
			Animation component = this.Character.GetComponent<Animation>();
			if (this.CanMove)
			{
				this.MyController.Move(Physics.gravity * 0.01f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
				a.y = 0f;
				a = a.normalized;
				Vector3 a2 = new Vector3(a.z, 0f, -a.x);
				Vector3 vector = axis2 * a2 + axis * a;
				if (vector != Vector3.zero)
				{
					Quaternion b = Quaternion.LookRotation(vector);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
				}
				if (axis != 0f || axis2 != 0f)
				{
					if (Input.GetButton("LB"))
					{
						component.CrossFade("f02_run_00");
						this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
					}
					else
					{
						component.CrossFade("f02_walk_00");
						this.MyController.Move(base.transform.forward * this.WalkSpeed * Time.deltaTime);
					}
				}
				else
				{
					component.CrossFade("f02_idleShort_00");
				}
			}
			else
			{
				component.CrossFade("f02_idleShort_00");
			}
		}
		else if (this.HomeDarkness.color.a == 0f)
		{
			AudioSource component2 = base.GetComponent<AudioSource>();
			if (this.Timer == 0f)
			{
				component2.Play();
			}
			else if (this.Timer > component2.clip.length + 1f)
			{
				PlayerPrefs.SetInt("DraculaDefeated", 0);
				this.Disc.SetActive(false);
				this.HomeVideoGames.Quit();
			}
			this.Timer += Time.deltaTime;
		}
		Rigidbody component3 = base.GetComponent<Rigidbody>();
		if (component3 != null)
		{
			component3.velocity = Vector3.zero;
		}
		if (Input.GetKeyDown("h"))
		{
			this.UpdateHair();
		}
		if (Input.GetKeyDown("k"))
		{
			PlayerPrefs.SetInt("KidnapVictim", this.VictimID);
			PlayerPrefs.SetFloat("Student_" + this.VictimID.ToString() + "_Sanity", 100f);
			PlayerPrefs.SetInt("Scheme_6_Stage", 5);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (Input.GetKeyDown(KeyCode.F1))
		{
			PlayerPrefs.SetInt("FemaleUniform", 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			PlayerPrefs.SetInt("FemaleUniform", 2);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (Input.GetKeyDown(KeyCode.F3))
		{
			PlayerPrefs.SetInt("FemaleUniform", 3);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (Input.GetKeyDown(KeyCode.F4))
		{
			PlayerPrefs.SetInt("FemaleUniform", 4);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (Input.GetKeyDown(KeyCode.F5))
		{
			PlayerPrefs.SetInt("FemaleUniform", 5);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (Input.GetKeyDown(KeyCode.F6))
		{
			PlayerPrefs.SetInt("FemaleUniform", 6);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	private void LateUpdate()
	{
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3(1f, 1f, 0.93f);
			this.Ponytail.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			this.HairR.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			this.HairL.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
		}
	}

	private void UpdateHair()
	{
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(1f, 0.75f, 1f);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(1f, 0.75f, 1f);
		this.PigtailR.gameObject.SetActive(false);
		this.PigtailL.gameObject.SetActive(false);
		this.Drills.gameObject.SetActive(false);
		this.HidePony = true;
		this.Hairstyle++;
		if (this.Hairstyle > 7)
		{
			this.Hairstyle = 1;
		}
		if (this.Hairstyle == 1)
		{
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3(1f, 1f, 1f);
			this.HairR.localScale = new Vector3(1f, 1f, 1f);
			this.HairL.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (this.Hairstyle == 2)
		{
			this.PigtailR.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == 3)
		{
			this.PigtailL.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == 4)
		{
			this.PigtailR.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == 5)
		{
			this.PigtailR.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3(1f, 1f, 1f);
			this.HairR.localScale = new Vector3(1f, 1f, 1f);
			this.HairL.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (this.Hairstyle == 6)
		{
			this.PigtailR.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
		}
		else if (this.Hairstyle == 7)
		{
			this.Drills.gameObject.SetActive(true);
		}
	}

	private void ChangeSchoolwear()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomCostume());
	}

	private void WearPajamas()
	{
		this.MyRenderer.sharedMesh = this.PajamaMesh;
		this.MyRenderer.materials[0].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[1].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomFace());
	}

	private IEnumerator ApplyCustomCostume()
	{
		if (PlayerPrefs.GetInt("FemaleUniform") == 1)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 2)
		{
			WWW CustomLong = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomLong;
			if (CustomLong.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomLong.texture;
				this.MyRenderer.materials[1].mainTexture = CustomLong.texture;
			}
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 3)
		{
			WWW CustomSweater = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomSweater;
			if (CustomSweater.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomSweater.texture;
				this.MyRenderer.materials[1].mainTexture = CustomSweater.texture;
			}
		}
		else if (PlayerPrefs.GetInt("FemaleUniform") == 4 || PlayerPrefs.GetInt("FemaleUniform") == 5)
		{
			WWW CustomBlazer = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomBlazer;
			if (CustomBlazer.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomBlazer.texture;
				this.MyRenderer.materials[1].mainTexture = CustomBlazer.texture;
			}
		}
		base.StartCoroutine(this.ApplyCustomFace());
		yield break;
	}

	private IEnumerator ApplyCustomFace()
	{
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
			this.FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			this.PonytailRenderer.material.mainTexture = CustomHair.texture;
			this.PigtailR.material.mainTexture = CustomHair.texture;
			this.PigtailL.material.mainTexture = CustomHair.texture;
		}
		WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
		yield return CustomDrills;
		if (CustomDrills.error == null)
		{
			this.Drills.materials[0].mainTexture = CustomDrills.texture;
			this.Drills.materials[1].mainTexture = CustomDrills.texture;
			this.Drills.materials[2].mainTexture = CustomDrills.texture;
		}
		yield break;
	}
}
