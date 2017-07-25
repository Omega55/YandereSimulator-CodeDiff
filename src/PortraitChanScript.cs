using System;
using System.Collections.Generic;
using UnityEngine;

public class PortraitChanScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public HomeCameraScript HomeCamera;

	public JsonScript JSON;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer TeacherHairRenderer;

	public Renderer MaleHairRenderer;

	public Renderer PonyRenderer;

	public Renderer NewLongHair;

	public Renderer ShortHair;

	public Renderer TwinPony;

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer LongHair;

	public Renderer Drills;

	public Renderer EyeR;

	public Renderer EyeL;

	public Transform LongHairBone;

	public Transform HomeYandere;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairF;

	public Transform HairL;

	public Transform HairR;

	public Texture UniformTexture;

	public Texture DrillTexture;

	public Texture HairTexture;

	public GameObject[] TeacherGlasses;

	public GameObject[] TeacherHair;

	public GameObject[] OccultHair;

	public GameObject[] IrisLight;

	public GameObject ShinyGlasses;

	public GameObject CirnoHair;

	public GameObject Character;

	public GameObject PippiHair;

	public GameObject Eyepatch;

	public GameObject Bandage;

	public GameObject Bandana;

	public bool VeryLongHair;

	public bool HidePony;

	public bool Bullied;

	public bool Teacher;

	public bool Male;

	public bool Emo;

	public float BreastSize;

	public string Accessory = string.Empty;

	public string Hairstyle = string.Empty;

	public int StudentID;

	public int Club;

	public GameObject[] MaleHairstyles;

	private Dictionary<string, Color> HairColors;

	public Mesh TeacherMesh;

	public Texture TeacherTexture;

	public HomeYandereDetectorScript YandereDetector;

	public Quaternion LastRotation;

	public GameObject RightIris;

	public GameObject LeftIris;

	public Transform TwintailR;

	public Transform TwintailL;

	public Transform Neck;

	public Vector3 RightEyeRotOrigin;

	public Vector3 LeftEyeRotOrigin;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3 Twitch;

	public float HairRotation;

	public float TwitchTimer;

	public float NextTwitch;

	public float EyeShrink;

	public float Sanity;

	public bool Kidnapped;

	public bool Tortured;

	public Mesh[] FemaleUniforms;

	public Texture[] FemaleUniformTextures;

	private void Awake()
	{
		this.HairColors = new Dictionary<string, Color>
		{
			{
				"Black",
				new Color(0.5f, 0.5f, 0.5f)
			},
			{
				"Red",
				new Color(1f, 0f, 0f)
			},
			{
				"Yellow",
				new Color(1f, 1f, 0f)
			},
			{
				"Green",
				new Color(0f, 1f, 0f)
			},
			{
				"Cyan",
				new Color(0f, 1f, 1f)
			},
			{
				"Blue",
				new Color(0f, 0f, 1f)
			},
			{
				"Purple",
				new Color(1f, 0f, 1f)
			},
			{
				"Orange",
				new Color(1f, 0.5f, 0f)
			},
			{
				"Brown",
				new Color(0.5f, 0.25f, 0f)
			}
		};
	}

	private void Start()
	{
		if (this.RightEye != null)
		{
			this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
			this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
		}
		Animation component = this.Character.GetComponent<Animation>();
		if (this.Kidnapped)
		{
			this.StudentID = PlayerPrefs.GetInt("KidnapVictim");
			component.Play("f02_kidnapIdle_00");
			this.TwintailR.transform.localEulerAngles = new Vector3(10f, -90f, 0f);
			this.TwintailL.transform.localEulerAngles = new Vector3(10f, 90f, 0f);
		}
		if (this.Bullied)
		{
			this.StudentID = 7;
			component.Play("f02_bulliedPose_00");
		}
		this.Club = this.JSON.StudentClubs[this.StudentID];
		this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
		this.Hairstyle = this.JSON.StudentHairstyles[this.StudentID];
		this.Accessory = this.JSON.StudentAccessories[this.StudentID];
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.UpdateHair();
		}
		else if (this.Club == 3)
		{
			component["sadFace_00"].layer = 1;
			component.Play("sadFace_00");
			component["sadFace_00"].weight = 1f;
		}
		this.Bandana.SetActive(false);
		if (this.Club == 100)
		{
			this.BecomeTeacher();
		}
		else if (this.Club == 6)
		{
			this.Bandana.SetActive(true);
		}
		this.SetColors();
		if (!this.Male && !this.Teacher)
		{
			this.SetFemaleUniform();
		}
		this.UpdateSanity();
	}

	private void SetColors()
	{
		string text = this.JSON.StudentColors[this.StudentID];
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[2].mainTexture = this.HairTexture;
				this.PonyRenderer.material.mainTexture = this.HairTexture;
				this.NewLongHair.material.mainTexture = this.HairTexture;
				this.ShortHair.material.mainTexture = this.HairTexture;
				this.LongHair.material.mainTexture = this.HairTexture;
				this.PigtailR.material.mainTexture = this.HairTexture;
				this.PigtailL.material.mainTexture = this.HairTexture;
				this.Drills.materials[0].mainTexture = this.DrillTexture;
				this.Drills.materials[1].mainTexture = this.DrillTexture;
				this.Drills.materials[2].mainTexture = this.DrillTexture;
			}
			else if (text == "Brown")
			{
				this.TeacherHair[1].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
				this.TeacherHair[2].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
				this.TeacherHair[3].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
				this.TeacherHair[4].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
				this.TeacherHair[5].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
				this.TeacherHair[6].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
			}
			if (this.Accessory == "Bandage")
			{
				this.Bandage.SetActive(true);
			}
			else if (this.Accessory == "Eyepatch")
			{
				this.Eyepatch.SetActive(true);
			}
		}
		else
		{
			this.MaleHairstyles[int.Parse(this.Hairstyle)].SetActive(true);
			if (int.Parse(this.Hairstyle) < 8)
			{
				this.MaleHairRenderer = this.MaleHairstyles[int.Parse(this.Hairstyle)].GetComponent<Renderer>();
				Color color;
				bool flag = this.HairColors.TryGetValue(text, out color);
				this.MaleHairRenderer.material.color = color;
				this.EyeR.material.color = this.MaleHairRenderer.material.color;
				this.EyeL.material.color = this.MaleHairRenderer.material.color;
				if (this.Club == 6)
				{
					Transform transform = this.MaleHairstyles[int.Parse(this.Hairstyle)].transform;
					transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
					this.Bandana.SetActive(true);
				}
			}
			else if (text == "Occult2" || text == "Occult4" || text == "Occult6")
			{
				this.MaleHairRenderer = this.MaleHairstyles[int.Parse(this.Hairstyle)].GetComponent<Renderer>();
				this.MyRenderer.materials[2].mainTexture = this.MaleHairRenderer.material.mainTexture;
				this.EyeR.material.mainTexture = this.MaleHairRenderer.material.mainTexture;
				this.EyeL.material.mainTexture = this.MaleHairRenderer.material.mainTexture;
			}
			if (this.Accessory == "ShinyGlasses")
			{
				this.ShinyGlasses.SetActive(true);
				this.IrisLight[0].SetActive(false);
				this.IrisLight[1].SetActive(false);
			}
		}
		if (!this.Male)
		{
			this.PigtailR.material.mainTexture = this.HairTexture;
			this.PigtailL.material.mainTexture = this.HairTexture;
			if (this.DrillTexture != null)
			{
				this.Drills.materials[0].mainTexture = this.DrillTexture;
				this.Drills.materials[1].mainTexture = this.DrillTexture;
				this.Drills.materials[2].mainTexture = this.DrillTexture;
			}
		}
	}

	private void UpdateHair()
	{
		this.PonyRenderer.gameObject.SetActive(false);
		this.NewLongHair.gameObject.SetActive(false);
		this.PigtailR.gameObject.SetActive(false);
		this.PigtailL.gameObject.SetActive(false);
		this.LongHair.gameObject.SetActive(false);
		this.TwinPony.gameObject.SetActive(false);
		this.Drills.gameObject.SetActive(false);
		this.OccultHair[1].SetActive(false);
		this.OccultHair[3].SetActive(false);
		this.OccultHair[5].SetActive(false);
		this.CirnoHair.SetActive(false);
		this.PippiHair.SetActive(false);
		this.ShortHair.gameObject.SetActive(false);
		if (this.Hairstyle == "PonyTail")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == "RightTail")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
			this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailR.gameObject.SetActive(true);
			this.HidePony = true;
		}
		else if (this.Hairstyle == "LeftTail")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
			this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
			this.HidePony = true;
		}
		else if (this.Hairstyle == "PigTails")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
			this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailR.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
			this.HidePony = true;
		}
		else if (this.Hairstyle == "TriTails")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
			this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailR.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
			this.PigtailR.transform.localScale = new Vector3(1f, 1f, 1f);
			this.PigtailL.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (this.Hairstyle == "TwinTails")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
			this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
			this.PigtailR.gameObject.SetActive(true);
			this.PigtailL.gameObject.SetActive(true);
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
			this.HidePony = true;
		}
		else if (this.Hairstyle == "Drills")
		{
			this.PonyRenderer.transform.parent.gameObject.SetActive(true);
			this.PonyRenderer.gameObject.SetActive(true);
			this.Drills.transform.parent.transform.parent.gameObject.SetActive(true);
			this.Drills.gameObject.SetActive(true);
			this.HidePony = true;
		}
		else if (this.Hairstyle == "Short")
		{
			this.ShortHair.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == "Pippi")
		{
			this.PippiHair.SetActive(true);
		}
		else if (this.Hairstyle == "Cirno")
		{
			this.CirnoHair.SetActive(true);
		}
		else if (this.Hairstyle == "Long")
		{
			this.LongHair.transform.parent.gameObject.SetActive(true);
			this.LongHair.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == "NewLong")
		{
			this.NewLongHair.transform.parent.gameObject.SetActive(true);
			this.NewLongHair.gameObject.SetActive(true);
			this.VeryLongHair = false;
		}
		else if (this.Hairstyle == "VeryLong")
		{
			this.NewLongHair.transform.parent.gameObject.SetActive(true);
			this.NewLongHair.gameObject.SetActive(true);
			this.VeryLongHair = true;
		}
		else if (this.Hairstyle == "TwinPony")
		{
			this.TwinPony.transform.parent.transform.parent.gameObject.SetActive(true);
			this.TwinPony.gameObject.SetActive(true);
		}
		else if (this.Hairstyle == "Occult1")
		{
			this.OccultHair[1].SetActive(true);
		}
		else if (this.Hairstyle == "Occult3")
		{
			this.OccultHair[3].SetActive(true);
		}
		else if (this.Hairstyle == "Occult5")
		{
			this.OccultHair[5].SetActive(true);
		}
		else if (this.Hairstyle == "Teacher1")
		{
			this.TeacherHair[1].SetActive(true);
			this.TeacherGlasses[1].SetActive(true);
		}
		else if (this.Hairstyle == "Teacher2")
		{
			this.TeacherHair[2].SetActive(true);
			this.TeacherGlasses[2].SetActive(true);
		}
		else if (this.Hairstyle == "Teacher3")
		{
			this.TeacherHair[3].SetActive(true);
			this.TeacherGlasses[3].SetActive(true);
		}
		else if (this.Hairstyle == "Teacher4")
		{
			this.TeacherHair[4].SetActive(true);
			this.TeacherGlasses[4].SetActive(true);
		}
		else if (this.Hairstyle == "Teacher5")
		{
			this.TeacherHair[5].SetActive(true);
			this.TeacherGlasses[5].SetActive(true);
		}
		else if (this.Hairstyle == "Teacher6")
		{
			this.TeacherHair[6].SetActive(true);
			this.TeacherGlasses[6].SetActive(true);
		}
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3(1f, 1f, 0.93f);
			this.Ponytail.localScale = Vector3.zero;
			this.HairR.localScale = Vector3.zero;
			this.HairL.localScale = Vector3.zero;
		}
	}

	private void BecomeTeacher()
	{
		this.MyRenderer.sharedMesh = this.TeacherMesh;
		this.Teacher = true;
		this.MyRenderer.materials[0].mainTexture = this.TeacherTexture;
		this.MyRenderer.materials[1].mainTexture = this.TeacherTexture;
		this.MyRenderer.materials[2].mainTexture = this.TeacherTexture;
	}

	private void LateUpdate()
	{
		if (this.Kidnapped)
		{
			if (!this.Tortured)
			{
				if (this.Sanity > 0f)
				{
					if (this.YandereDetector.YandereDetected && Vector3.Distance(base.transform.position, this.HomeYandere.position) < 2f)
					{
						Quaternion b;
						if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
						{
							b = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
							this.HairRotation = Mathf.Lerp(this.HairRotation, 0f, Time.deltaTime * 2f);
						}
						else
						{
							b = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
							this.HairRotation = Mathf.Lerp(this.HairRotation, -45f, Time.deltaTime * 2f);
						}
						this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b, Time.deltaTime * 2f);
						this.TwintailR.transform.localEulerAngles = new Vector3(15f, -75f, this.HairRotation);
						this.TwintailL.transform.localEulerAngles = new Vector3(15f, 75f, -this.HairRotation);
					}
					else
					{
						if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
						{
							Quaternion b2 = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
							this.HairRotation = Mathf.Lerp(this.HairRotation, 0f, Time.deltaTime * 2f);
						}
						else
						{
							Quaternion b2 = Quaternion.LookRotation(base.transform.position + base.transform.forward - this.Neck.position);
							this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b2, Time.deltaTime * 2f);
						}
						this.HairRotation = Mathf.Lerp(this.HairRotation, 45f, Time.deltaTime * 2f);
						this.TwintailR.transform.localEulerAngles = new Vector3(15f, -75f, this.HairRotation);
						this.TwintailL.transform.localEulerAngles = new Vector3(15f, 75f, -this.HairRotation);
					}
				}
				else
				{
					this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
				}
			}
			else
			{
				this.EyeShrink += Time.deltaTime * 0.1f;
			}
			this.LastRotation = this.Neck.rotation;
			if (!this.Tortured && this.Sanity < 100f && this.Sanity > 0f)
			{
				this.TwitchTimer += Time.deltaTime;
				if (this.TwitchTimer > this.NextTwitch)
				{
					this.Twitch = new Vector3((1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f));
					this.NextTwitch = UnityEngine.Random.Range(0f, 1f);
					this.TwitchTimer = 0f;
				}
				this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
				this.Neck.localEulerAngles += this.Twitch;
			}
		}
		if (this.VeryLongHair)
		{
			this.LongHairBone.localScale = new Vector3(2f, this.LongHairBone.localScale.y, this.LongHairBone.localScale.z);
		}
		if (this.Emo)
		{
			this.HairF.localPosition = new Vector3(-0.1f, -0.285f, this.HairF.localPosition.z);
		}
		if (this.Tortured && this.RightEye != null)
		{
			if (this.EyeShrink > 1f)
			{
				this.EyeShrink = 1f;
			}
			if (this.Sanity >= 50f)
			{
				this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x - this.EyeShrink * 0.002f, this.LeftEye.localPosition.y, this.LeftEye.localPosition.z - this.EyeShrink * 0.009f);
				this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x - this.EyeShrink * 0.002f, this.RightEye.localPosition.y, this.RightEye.localPosition.z + this.EyeShrink * 0.009f);
				this.LeftEye.localEulerAngles = new Vector3(this.LeftEye.localEulerAngles.x + 5f + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.LeftEye.localEulerAngles.y + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.LeftEye.localEulerAngles.z + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink));
				this.RightEye.localEulerAngles = new Vector3(this.RightEye.localEulerAngles.x - 5f + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.RightEye.localEulerAngles.y + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.RightEye.localEulerAngles.z + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink));
				this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
				this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
			}
		}
	}

	private void UpdateSanity()
	{
		if (this.Kidnapped)
		{
			this.Sanity = PlayerPrefs.GetFloat("Student_" + this.StudentID.ToString() + "_Sanity");
			this.RightIris.SetActive(this.Sanity == 0f);
			this.LeftIris.SetActive(this.Sanity == 0f);
		}
	}

	private void SetFemaleUniform()
	{
		if (this.Tortured)
		{
			this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.PonyRenderer.material.mainTexture = this.HairTexture;
		}
	}
}
