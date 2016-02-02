using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public string Accessory;

	public string Hairstyle;

	public int StudentID;

	public int Club;

	public GameObject[] MaleHairstyles;

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

	public PortraitChanScript()
	{
		this.Accessory = string.Empty;
		this.Hairstyle = string.Empty;
	}

	public virtual void Start()
	{
		if (this.RightEye != null)
		{
			this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
			this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
		}
		if (this.Kidnapped)
		{
			this.StudentID = PlayerPrefs.GetInt("KidnapVictim");
			this.Character.animation.Play("f02_kidnapIdle_00");
			this.TwintailR.transform.localEulerAngles = new Vector3((float)10, (float)-90, (float)0);
			this.TwintailL.transform.localEulerAngles = new Vector3((float)10, (float)90, (float)0);
		}
		if (this.Bullied)
		{
			this.StudentID = 7;
			this.Character.animation.Play("f02_bulliedPose_00");
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
			this.Character.animation["sadFace_00"].layer = 1;
			this.Character.animation.Play("sadFace_00");
			this.Character.animation["sadFace_00"].weight = (float)1;
		}
		this.Bandana.active = false;
		if (this.Club == 100)
		{
			this.BecomeTeacher();
		}
		else if (this.Club == 6)
		{
			this.Bandana.active = true;
		}
		this.SetColors();
		if (!this.Male && !this.Teacher)
		{
			this.SetFemaleUniform();
		}
		this.UpdateSanity();
	}

	public virtual void SetColors()
	{
		string a = this.JSON.StudentColors[this.StudentID];
		if (!this.Male)
		{
			if (a == "Red")
			{
				this.HairTexture = this.StudentManager.Colors[0];
			}
			else if (a == "Yellow")
			{
				this.HairTexture = this.StudentManager.Colors[1];
			}
			else if (a == "Green")
			{
				this.HairTexture = this.StudentManager.Colors[2];
			}
			else if (a == "Cyan")
			{
				this.HairTexture = this.StudentManager.Colors[3];
			}
			else if (a == "Blue")
			{
				this.HairTexture = this.StudentManager.Colors[4];
			}
			else if (a == "Purple")
			{
				this.HairTexture = this.StudentManager.Colors[5];
				this.DrillTexture = this.StudentManager.Colors[6];
			}
			else if (a == "Brown")
			{
				this.HairTexture = this.StudentManager.Colors[7];
			}
			else if (a == "Pippi")
			{
				this.HairTexture = this.StudentManager.Colors[8];
			}
			else if (a == "Black")
			{
				this.HairTexture = this.StudentManager.Colors[9];
			}
			else if (a == "LongGreen")
			{
				this.HairTexture = this.StudentManager.Colors[10];
			}
			else if (a == "Succubus1")
			{
				this.HairTexture = this.StudentManager.Colors[11];
			}
			else if (a == "Succubus2")
			{
				this.HairTexture = this.StudentManager.Colors[12];
			}
			else if (a == "Kuudere")
			{
				this.HairTexture = this.StudentManager.Colors[13];
			}
			else if (a == "LongPink")
			{
				this.HairTexture = this.StudentManager.Colors[14];
			}
			else if (a == "ShortBrown")
			{
				this.HairTexture = this.StudentManager.Colors[15];
			}
			else if (a == "ShortOrange")
			{
				this.HairTexture = this.StudentManager.Colors[16];
			}
			else if (a == "Occult1")
			{
				this.HairTexture = this.StudentManager.Colors[17];
			}
			else if (a == "Occult3")
			{
				this.HairTexture = this.StudentManager.Colors[19];
			}
			else if (a == "Occult5")
			{
				this.HairTexture = this.StudentManager.Colors[21];
			}
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
			else
			{
				if (a == "Brown")
				{
					((Renderer)this.TeacherHair[1].GetComponent(typeof(Renderer))).material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
					((Renderer)this.TeacherHair[2].GetComponent(typeof(Renderer))).material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
					((Renderer)this.TeacherHair[3].GetComponent(typeof(Renderer))).material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
					((Renderer)this.TeacherHair[4].GetComponent(typeof(Renderer))).material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
					((Renderer)this.TeacherHair[5].GetComponent(typeof(Renderer))).material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
					((Renderer)this.TeacherHair[6].GetComponent(typeof(Renderer))).material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
				}
				this.MyRenderer.materials[1].mainTexture = this.StudentManager.Colors[7];
			}
			if (this.Accessory == "Bandage")
			{
				this.Bandage.active = true;
			}
			else if (this.Accessory == "Eyepatch")
			{
				this.Eyepatch.active = true;
			}
		}
		else
		{
			this.MaleHairstyles[UnityBuiltins.parseInt(this.Hairstyle)].active = true;
			if (UnityBuiltins.parseInt(this.Hairstyle) < 8)
			{
				this.MaleHairRenderer = (Renderer)this.MaleHairstyles[UnityBuiltins.parseInt(this.Hairstyle)].GetComponent(typeof(Renderer));
				if (a == "Black")
				{
					this.MaleHairRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (a == "Red")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)0, (float)0);
				}
				else if (a == "Yellow")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)1, (float)0);
				}
				else if (a == "Green")
				{
					this.MaleHairRenderer.material.color = new Color((float)0, (float)1, (float)0);
				}
				else if (a == "Cyan")
				{
					this.MaleHairRenderer.material.color = new Color((float)0, (float)1, (float)1);
				}
				else if (a == "Blue")
				{
					this.MaleHairRenderer.material.color = new Color((float)0, (float)0, (float)1);
				}
				else if (a == "Purple")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, (float)0, (float)1);
				}
				else if (a == "Orange")
				{
					this.MaleHairRenderer.material.color = new Color((float)1, 0.5f, (float)0);
				}
				else if (a == "Brown")
				{
					this.MaleHairRenderer.material.color = new Color(0.5f, 0.25f, (float)0);
				}
				this.EyeR.material.color = this.MaleHairRenderer.material.color;
				this.EyeL.material.color = this.MaleHairRenderer.material.color;
				if (this.Club == 6)
				{
					int num = -1;
					Vector3 localScale = this.MaleHairstyles[UnityBuiltins.parseInt(this.Hairstyle)].transform.localScale;
					float num2 = localScale.x = (float)num;
					Vector3 vector = this.MaleHairstyles[UnityBuiltins.parseInt(this.Hairstyle)].transform.localScale = localScale;
					this.Bandana.active = true;
				}
			}
			else if (a == "Occult2" || a == "Occult4" || a == "Occult6")
			{
				this.MaleHairRenderer = (Renderer)this.MaleHairstyles[UnityBuiltins.parseInt(this.Hairstyle)].GetComponent(typeof(Renderer));
				this.MyRenderer.materials[2].mainTexture = this.MaleHairRenderer.material.mainTexture;
				this.EyeR.material.mainTexture = this.MaleHairRenderer.material.mainTexture;
				this.EyeL.material.mainTexture = this.MaleHairRenderer.material.mainTexture;
			}
			if (this.Accessory == "ShinyGlasses")
			{
				this.ShinyGlasses.active = true;
				this.IrisLight[0].active = false;
				this.IrisLight[1].active = false;
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

	public virtual void UpdateHair()
	{
		this.PonyRenderer.gameObject.active = false;
		this.NewLongHair.gameObject.active = false;
		this.PigtailR.gameObject.active = false;
		this.PigtailL.gameObject.active = false;
		this.LongHair.gameObject.active = false;
		this.TwinPony.gameObject.active = false;
		this.Drills.gameObject.active = false;
		this.OccultHair[1].active = false;
		this.OccultHair[3].active = false;
		this.OccultHair[5].active = false;
		this.CirnoHair.active = false;
		this.PippiHair.active = false;
		this.ShortHair.active = false;
		if (this.Hairstyle == "PonyTail")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
		}
		else if (this.Hairstyle == "RightTail")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
			this.PigtailR.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailR.gameObject.active = true;
			this.HidePony = true;
		}
		else if (this.Hairstyle == "LeftTail")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
			this.PigtailL.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailL.gameObject.active = true;
			this.HidePony = true;
		}
		else if (this.Hairstyle == "PigTails")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
			this.PigtailR.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailL.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailR.gameObject.active = true;
			this.PigtailL.gameObject.active = true;
			this.HidePony = true;
		}
		else if (this.Hairstyle == "TriTails")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
			this.PigtailR.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailL.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailR.gameObject.active = true;
			this.PigtailL.gameObject.active = true;
			this.PigtailR.transform.localScale = new Vector3((float)1, (float)1, (float)1);
			this.PigtailL.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		}
		else if (this.Hairstyle == "TwinTails")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
			this.PigtailR.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailL.transform.parent.transform.parent.gameObject.active = true;
			this.PigtailR.gameObject.active = true;
			this.PigtailL.gameObject.active = true;
			this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			this.HidePony = true;
		}
		else if (this.Hairstyle == "Drills")
		{
			this.PonyRenderer.transform.parent.gameObject.active = true;
			this.PonyRenderer.gameObject.active = true;
			this.Drills.transform.parent.transform.parent.gameObject.active = true;
			this.Drills.gameObject.active = true;
			this.HidePony = true;
		}
		else if (this.Hairstyle == "Short")
		{
			this.ShortHair.active = true;
		}
		else if (this.Hairstyle == "Pippi")
		{
			this.PippiHair.active = true;
		}
		else if (this.Hairstyle == "Cirno")
		{
			this.CirnoHair.active = true;
		}
		else if (this.Hairstyle == "Long")
		{
			this.LongHair.transform.parent.gameObject.active = true;
			this.LongHair.gameObject.active = true;
		}
		else if (this.Hairstyle == "NewLong")
		{
			this.NewLongHair.transform.parent.gameObject.active = true;
			this.NewLongHair.gameObject.active = true;
			this.VeryLongHair = false;
		}
		else if (this.Hairstyle == "VeryLong")
		{
			this.NewLongHair.transform.parent.gameObject.active = true;
			this.NewLongHair.gameObject.active = true;
			this.VeryLongHair = true;
		}
		else if (this.Hairstyle == "TwinPony")
		{
			this.TwinPony.transform.parent.transform.parent.gameObject.active = true;
			this.TwinPony.gameObject.active = true;
		}
		else if (this.Hairstyle == "Occult1")
		{
			this.OccultHair[1].active = true;
		}
		else if (this.Hairstyle == "Occult3")
		{
			this.OccultHair[3].active = true;
		}
		else if (this.Hairstyle == "Occult5")
		{
			this.OccultHair[5].active = true;
		}
		else if (this.Hairstyle == "Teacher1")
		{
			this.TeacherHair[1].active = true;
			this.TeacherGlasses[1].active = true;
		}
		else if (this.Hairstyle == "Teacher2")
		{
			this.TeacherHair[2].active = true;
			this.TeacherGlasses[2].active = true;
		}
		else if (this.Hairstyle == "Teacher3")
		{
			this.TeacherHair[3].active = true;
			this.TeacherGlasses[3].active = true;
		}
		else if (this.Hairstyle == "Teacher4")
		{
			this.TeacherHair[4].active = true;
			this.TeacherGlasses[4].active = true;
		}
		else if (this.Hairstyle == "Teacher5")
		{
			this.TeacherHair[5].active = true;
			this.TeacherGlasses[5].active = true;
		}
		else if (this.Hairstyle == "Teacher6")
		{
			this.TeacherHair[6].active = true;
			this.TeacherGlasses[6].active = true;
		}
		if (this.HidePony)
		{
			this.Ponytail.parent.transform.localScale = new Vector3((float)1, (float)1, 0.93f);
			this.Ponytail.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairR.localScale = new Vector3((float)0, (float)0, (float)0);
			this.HairL.localScale = new Vector3((float)0, (float)0, (float)0);
		}
	}

	public virtual void BecomeTeacher()
	{
		this.MyRenderer.sharedMesh = this.TeacherMesh;
		this.Teacher = true;
		this.MyRenderer.materials[0].mainTexture = this.TeacherTexture;
		this.MyRenderer.materials[1].mainTexture = this.TeacherTexture;
		this.MyRenderer.materials[2].mainTexture = this.TeacherTexture;
	}

	public virtual void LateUpdate()
	{
		if (this.Kidnapped)
		{
			if (!this.Tortured)
			{
				if (this.Sanity > (float)0)
				{
					if (this.YandereDetector.YandereDetected && Vector3.Distance(this.transform.position, this.HomeYandere.position) < (float)2)
					{
						Quaternion to;
						if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
						{
							to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
							this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
						}
						else
						{
							to = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
							this.HairRotation = Mathf.Lerp(this.HairRotation, (float)-45, Time.deltaTime * (float)2);
						}
						this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
						this.TwintailR.transform.localEulerAngles = new Vector3((float)15, (float)-75, this.HairRotation);
						this.TwintailL.transform.localEulerAngles = new Vector3((float)15, (float)75, (float)-1 * this.HairRotation);
					}
					else
					{
						if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
						{
							Quaternion to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
							this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
						}
						else
						{
							Quaternion to = Quaternion.LookRotation(this.transform.position + this.transform.forward - this.Neck.position);
							this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
						}
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)45, Time.deltaTime * (float)2);
						this.TwintailR.transform.localEulerAngles = new Vector3((float)15, (float)-75, this.HairRotation);
						this.TwintailL.transform.localEulerAngles = new Vector3((float)15, (float)75, (float)-1 * this.HairRotation);
					}
				}
				else
				{
					float x = this.Neck.localEulerAngles.x - (float)45;
					Vector3 localEulerAngles = this.Neck.localEulerAngles;
					float num = localEulerAngles.x = x;
					Vector3 vector = this.Neck.localEulerAngles = localEulerAngles;
				}
			}
			else
			{
				this.EyeShrink += Time.deltaTime * 0.1f;
			}
			this.LastRotation = this.Neck.rotation;
			if (!this.Tortured && this.Sanity < (float)100 && this.Sanity > (float)0)
			{
				this.TwitchTimer += Time.deltaTime;
				if (this.TwitchTimer > this.NextTwitch)
				{
					this.Twitch.x = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
					this.Twitch.y = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
					this.Twitch.z = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
					this.NextTwitch = UnityEngine.Random.Range((float)0, 1f);
					this.TwitchTimer = (float)0;
				}
				this.Twitch = Vector3.Lerp(this.Twitch, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Neck.localEulerAngles = this.Neck.localEulerAngles + this.Twitch;
			}
		}
		if (this.VeryLongHair)
		{
			int num2 = 2;
			Vector3 localScale = this.LongHairBone.localScale;
			float num3 = localScale.x = (float)num2;
			Vector3 vector2 = this.LongHairBone.localScale = localScale;
		}
		if (this.Emo)
		{
			float x2 = -0.1f;
			Vector3 localPosition = this.HairF.localPosition;
			float num4 = localPosition.x = x2;
			Vector3 vector3 = this.HairF.localPosition = localPosition;
			float y = -0.285f;
			Vector3 localPosition2 = this.HairF.localPosition;
			float num5 = localPosition2.y = y;
			Vector3 vector4 = this.HairF.localPosition = localPosition2;
		}
		if (this.Tortured && this.RightEye != null)
		{
			if (this.EyeShrink > (float)1)
			{
				this.EyeShrink = (float)1;
			}
			if (this.Sanity >= (float)50)
			{
				float z = this.LeftEye.localPosition.z - this.EyeShrink * 0.009f;
				Vector3 localPosition3 = this.LeftEye.localPosition;
				float num6 = localPosition3.z = z;
				Vector3 vector5 = this.LeftEye.localPosition = localPosition3;
				float z2 = this.RightEye.localPosition.z + this.EyeShrink * 0.009f;
				Vector3 localPosition4 = this.RightEye.localPosition;
				float num7 = localPosition4.z = z2;
				Vector3 vector6 = this.RightEye.localPosition = localPosition4;
				float x3 = this.LeftEye.localPosition.x - this.EyeShrink * 0.002f;
				Vector3 localPosition5 = this.LeftEye.localPosition;
				float num8 = localPosition5.x = x3;
				Vector3 vector7 = this.LeftEye.localPosition = localPosition5;
				float x4 = this.RightEye.localPosition.x - this.EyeShrink * 0.002f;
				Vector3 localPosition6 = this.RightEye.localPosition;
				float num9 = localPosition6.x = x4;
				Vector3 vector8 = this.RightEye.localPosition = localPosition6;
				float x5 = this.LeftEye.localEulerAngles.x + (float)5 + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles2 = this.LeftEye.localEulerAngles;
				float num10 = localEulerAngles2.x = x5;
				Vector3 vector9 = this.LeftEye.localEulerAngles = localEulerAngles2;
				float y2 = this.LeftEye.localEulerAngles.y + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles3 = this.LeftEye.localEulerAngles;
				float num11 = localEulerAngles3.y = y2;
				Vector3 vector10 = this.LeftEye.localEulerAngles = localEulerAngles3;
				float z3 = this.LeftEye.localEulerAngles.z + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles4 = this.LeftEye.localEulerAngles;
				float num12 = localEulerAngles4.z = z3;
				Vector3 vector11 = this.LeftEye.localEulerAngles = localEulerAngles4;
				float x6 = this.RightEye.localEulerAngles.x - (float)5 + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles5 = this.RightEye.localEulerAngles;
				float num13 = localEulerAngles5.x = x6;
				Vector3 vector12 = this.RightEye.localEulerAngles = localEulerAngles5;
				float y3 = this.RightEye.localEulerAngles.y + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles6 = this.RightEye.localEulerAngles;
				float num14 = localEulerAngles6.y = y3;
				Vector3 vector13 = this.RightEye.localEulerAngles = localEulerAngles6;
				float z4 = this.RightEye.localEulerAngles.z + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles7 = this.RightEye.localEulerAngles;
				float num15 = localEulerAngles7.z = z4;
				Vector3 vector14 = this.RightEye.localEulerAngles = localEulerAngles7;
				float x7 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale2 = this.LeftEye.localScale;
				float num16 = localScale2.x = x7;
				Vector3 vector15 = this.LeftEye.localScale = localScale2;
				float y4 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale3 = this.LeftEye.localScale;
				float num17 = localScale3.y = y4;
				Vector3 vector16 = this.LeftEye.localScale = localScale3;
				float x8 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale4 = this.RightEye.localScale;
				float num18 = localScale4.x = x8;
				Vector3 vector17 = this.RightEye.localScale = localScale4;
				float y5 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale5 = this.RightEye.localScale;
				float num19 = localScale5.y = y5;
				Vector3 vector18 = this.RightEye.localScale = localScale5;
			}
		}
	}

	public virtual void UpdateSanity()
	{
		if (this.Kidnapped)
		{
			this.Sanity = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_Sanity");
			if (this.Sanity == (float)0)
			{
				this.RightIris.active = true;
				this.LeftIris.active = true;
			}
			else
			{
				this.RightIris.active = false;
				this.LeftIris.active = false;
			}
		}
	}

	public virtual void SetFemaleUniform()
	{
		if (this.Tortured)
		{
			this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.PonyRenderer.material.mainTexture = this.HairTexture;
		}
	}

	public virtual void Main()
	{
	}
}
