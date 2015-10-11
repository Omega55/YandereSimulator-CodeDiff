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
	internal sealed class $ApplyCustomCostume$1794 : GenericGenerator<WWW>
	{
		internal HomeYandereScript $self_$1800;

		public $ApplyCustomCostume$1794(HomeYandereScript self_)
		{
			this.$self_$1800 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new HomeYandereScript.$ApplyCustomCostume$1794.$(this.$self_$1800);
		}
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class $ApplyCustomFace$1801 : GenericGenerator<WWW>
	{
		internal HomeYandereScript $self_$1806;

		public $ApplyCustomFace$1801(HomeYandereScript self_)
		{
			this.$self_$1806 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new HomeYandereScript.$ApplyCustomFace$1801.$(this.$self_$1806);
		}
	}

	public CharacterController MyController;

	public GameObject Character;

	public GameObject Victim;

	public float WalkSpeed;

	public float RunSpeed;

	public bool CanMove;

	public Renderer PonytailRenderer;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Transform Ponytail;

	public Transform HairR;

	public Transform HairL;

	public bool HidePony;

	public int Hairstyle;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] UniformTextures;

	public Texture FaceTexture;

	public Mesh[] Uniforms;

	public Texture PajamaTexture;

	public Mesh PajamaMesh;

	public virtual void Start()
	{
		if (Application.loadedLevelName == "HomeScene")
		{
			this.transform.position = new Vector3((float)0, (float)0, (float)0);
			this.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
		}
		Time.timeScale = (float)1;
		this.UpdateHair();
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

	public virtual void Update()
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
		if (this.rigidbody != null)
		{
			this.rigidbody.velocity = new Vector3((float)0, (float)0, (float)0);
		}
		if (Input.GetKeyDown("h"))
		{
			this.UpdateHair();
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
			this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
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
		return new HomeYandereScript.$ApplyCustomCostume$1794(this).GetEnumerator();
	}

	public virtual IEnumerator ApplyCustomFace()
	{
		return new HomeYandereScript.$ApplyCustomFace$1801(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
