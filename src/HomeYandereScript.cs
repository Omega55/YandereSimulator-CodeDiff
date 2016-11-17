using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class HomeYandereScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $ApplyCustomCostume$3024 : GenericGenerator<WWW>
	{
		internal HomeYandereScript $self_$3030;

		public $ApplyCustomCostume$3024(HomeYandereScript self_)
		{
			this.$self_$3030 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new HomeYandereScript.$ApplyCustomCostume$3024.$(this.$self_$3030);
		}
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class $ApplyCustomFace$3031 : GenericGenerator<WWW>
	{
		internal HomeYandereScript $self_$3036;

		public $ApplyCustomFace$3031(HomeYandereScript self_)
		{
			this.$self_$3036 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new HomeYandereScript.$ApplyCustomFace$3031.$(this.$self_$3036);
		}
	}

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

	public virtual void Start()
	{
		if (this.CutsceneYandere != null)
		{
			this.CutsceneYandere.animation["f02_texting_00"].speed = 0.1f;
		}
		if (Application.loadedLevelName == "HomeScene")
		{
			if (PlayerPrefs.GetInt("DraculaDefeated") == 0)
			{
				this.transform.position = new Vector3((float)0, (float)0, (float)0);
				this.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
				if (PlayerPrefs.GetInt("Night") == 0)
				{
					this.ChangeSchoolwear();
					this.StartCoroutine_Auto(this.ApplyCustomCostume());
				}
				else
				{
					this.WearPajamas();
				}
			}
			else if (PlayerPrefs.GetInt("StartInBasement") == 1)
			{
				PlayerPrefs.SetInt("StartInBasement", 0);
				this.transform.position = new Vector3((float)0, (float)-135, (float)0);
				this.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
			}
			else
			{
				this.transform.position = new Vector3((float)1, (float)0, (float)0);
				this.transform.eulerAngles = new Vector3((float)0, (float)90, (float)0);
				this.Character.animation.Play("f02_discScratch_00");
				this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				this.Controller.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-180);
				this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
				this.HomeCamera.Target = this.HomeCamera.Targets[5];
				this.Disc.active = true;
				this.WearPajamas();
			}
		}
		Time.timeScale = (float)1;
		this.UpdateHair();
	}

	public virtual void Update()
	{
		if (!this.Disc.active)
		{
			if (this.CanMove)
			{
				this.MyController.Move(Physics.gravity * 0.01f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
				a.y = (float)0;
				a = a.normalized;
				Vector3 a2 = new Vector3(a.z, (float)0, -a.x);
				Vector3 vector = axis2 * a2 + axis * a;
				if (vector != Vector3.zero)
				{
					Quaternion to = Quaternion.LookRotation(vector);
					this.transform.rotation = Quaternion.Lerp(this.transform.rotation, to, Time.deltaTime * (float)10);
				}
				else
				{
					Quaternion to = new Quaternion((float)0, (float)0, (float)0, (float)0);
				}
				if (axis != (float)0 || axis2 != (float)0)
				{
					if (Input.GetButton("LB"))
					{
						this.Character.animation.CrossFade("f02_run_00");
						this.MyController.Move(this.transform.forward * this.RunSpeed * Time.deltaTime);
					}
					else
					{
						this.Character.animation.CrossFade("f02_walk_00");
						this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime);
					}
				}
				else
				{
					this.Character.animation.CrossFade("f02_idleShort_00");
				}
			}
			else
			{
				this.Character.animation.CrossFade("f02_idleShort_00");
			}
		}
		else if (this.HomeDarkness.color.a == (float)0)
		{
			if (this.Timer == (float)0)
			{
				this.audio.Play();
			}
			else if (this.Timer > this.audio.clip.length + (float)1)
			{
				PlayerPrefs.SetInt("DraculaDefeated", 0);
				this.Disc.active = false;
				this.HomeVideoGames.Quit();
			}
			this.Timer += Time.deltaTime;
		}
		if (this.rigidbody != null)
		{
			this.rigidbody.velocity = new Vector3((float)0, (float)0, (float)0);
		}
		if (Input.GetKeyDown("h"))
		{
			this.UpdateHair();
		}
		if (Input.GetKeyDown("k"))
		{
			PlayerPrefs.SetInt("KidnapVictim", this.VictimID);
			PlayerPrefs.SetFloat("Student_" + this.VictimID + "_Sanity", 100f);
			PlayerPrefs.SetInt("Scheme_6_Stage", 5);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown(KeyCode.F1))
		{
			PlayerPrefs.SetInt("FemaleUniform", 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			PlayerPrefs.SetInt("FemaleUniform", 2);
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (Input.GetKeyDown(KeyCode.F3))
		{
			PlayerPrefs.SetInt("FemaleUniform", 3);
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (Input.GetKeyDown(KeyCode.F4))
		{
			PlayerPrefs.SetInt("FemaleUniform", 4);
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (Input.GetKeyDown(KeyCode.F5))
		{
			PlayerPrefs.SetInt("FemaleUniform", 5);
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public virtual void LateUpdate()
	{
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
			this.Ponytail.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			this.HairR.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
			this.HairL.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
		}
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)1, 0.75f, (float)1);
		this.PigtailR.active = false;
		this.PigtailL.active = false;
		this.Drills.active = false;
		this.HidePony = true;
		this.Hairstyle++;
		if (this.Hairstyle > 7)
		{
			this.Hairstyle = 1;
		}
		if (this.Hairstyle == 1)
		{
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == 2)
		{
			this.PigtailR.active = true;
		}
		else if (this.Hairstyle == 3)
		{
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == 4)
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
		}
		else if (this.Hairstyle == 5)
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.HidePony = false;
			this.Ponytail.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairR.localScale = new Vector3((float)1, (float)1, (float)1);
			this.HairL.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == 6)
		{
			this.PigtailR.active = true;
			this.PigtailL.active = true;
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
		}
		else if (this.Hairstyle == 7)
		{
			this.Drills.active = true;
		}
	}

	public virtual void ChangeSchoolwear()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.StartCoroutine_Auto(this.ApplyCustomCostume());
	}

	public virtual void WearPajamas()
	{
		this.MyRenderer.sharedMesh = this.PajamaMesh;
		this.MyRenderer.materials[0].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[1].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.StartCoroutine_Auto(this.ApplyCustomFace());
	}

	public virtual IEnumerator ApplyCustomCostume()
	{
		return new HomeYandereScript.$ApplyCustomCostume$3024(this).GetEnumerator();
	}

	public virtual IEnumerator ApplyCustomFace()
	{
		return new HomeYandereScript.$ApplyCustomFace$3031(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
