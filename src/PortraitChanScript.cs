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

	public Renderer PigtailR;

	public Renderer PigtailL;

	public Renderer Drills;

	public Renderer EyeR;

	public Renderer EyeL;

	public Transform HomeYandere;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairL;

	public Transform HairR;

	public Texture UniformTexture;

	public Texture DrillTexture;

	public Texture HairTexture;

	public GameObject TeacherGlasses;

	public GameObject TeacherHair;

	public GameObject Character;

	public GameObject PippiHair;

	public GameObject LongHair;

	public bool HidePony;

	public bool Bullied;

	public bool Teacher;

	public bool Male;

	public float BreastSize;

	public string Hairstyle;

	public int StudentID;

	public int Club;

	public GameObject[] MaleHairstyles;

	public Mesh TeacherMesh;

	public Texture TeacherTexture;

	public Mesh BaldMesh;

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

	public PortraitChanScript()
	{
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
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.TeacherGlasses.active = false;
			this.UpdateHair();
		}
		if (this.Club == 9)
		{
			this.BecomeTeacher();
		}
		this.SetColors();
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
			if (!this.Teacher)
			{
				this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[2].mainTexture = this.HairTexture;
				this.MyRenderer.materials[3].mainTexture = this.HairTexture;
			}
			else
			{
				if (a == "Brown1")
				{
					this.TeacherHairRenderer.material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
				}
				else if (a == "Brown2")
				{
					this.TeacherHairRenderer.material.color = new Color(0.45f, 0.225f, (float)0, (float)1);
				}
				else if (a == "Brown3")
				{
					this.TeacherHairRenderer.material.color = new Color(0.4f, 0.2f, (float)0, (float)1);
				}
				else if (a == "Brown4")
				{
					this.TeacherHairRenderer.material.color = new Color(0.35f, 0.175f, (float)0, (float)1);
				}
				else if (a == "Brown5")
				{
					this.TeacherHairRenderer.material.color = new Color(0.3f, 0.15f, (float)0, (float)1);
				}
				else if (a == "Brown6")
				{
					this.TeacherHairRenderer.material.color = new Color(0.25f, 0.125f, (float)0, (float)1);
				}
				this.MyRenderer.materials[1].mainTexture = this.StudentManager.Colors[7];
				this.MyRenderer.materials[2].mainTexture = this.StudentManager.Colors[7];
				this.TeacherGlasses.active = true;
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
				this.EyeR.material.color = this.MaleHairRenderer.material.color;
				this.EyeL.material.color = this.MaleHairRenderer.material.color;
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
		if (this.Hairstyle == "Long" || this.Hairstyle == "Pippi")
		{
			this.BecomeBald();
		}
	}

	public virtual void UpdateHair()
	{
		this.PigtailR.gameObject.active = false;
		this.PigtailL.gameObject.active = false;
		this.Drills.gameObject.active = false;
		this.TeacherHair.active = false;
		this.PippiHair.active = false;
		this.LongHair.active = false;
		if (!(this.Hairstyle == "PonyTail"))
		{
			if (this.Hairstyle == "RightTail")
			{
				this.PigtailR.gameObject.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "LeftTail")
			{
				this.PigtailL.gameObject.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "PigTails")
			{
				this.PigtailR.gameObject.active = true;
				this.PigtailL.gameObject.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "TriTails")
			{
				this.PigtailR.gameObject.active = true;
				this.PigtailL.gameObject.active = true;
				this.PigtailR.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.PigtailL.transform.localScale = new Vector3((float)1, (float)1, (float)1);
			}
			else if (this.Hairstyle == "TwinTails")
			{
				this.PigtailR.gameObject.active = true;
				this.PigtailL.gameObject.active = true;
				this.HidePony = true;
				this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
				this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3((float)2, (float)2, (float)2);
			}
			else if (this.Hairstyle == "Drills")
			{
				this.Drills.gameObject.active = true;
				this.HidePony = true;
			}
			else if (this.Hairstyle == "Short")
			{
				this.PigtailR.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				this.PigtailL.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				this.HairR.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				this.HairL.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			}
			else if (this.Hairstyle == "Pippi")
			{
				this.PippiHair.active = true;
			}
			else if (this.Hairstyle == "Long")
			{
				this.LongHair.active = true;
			}
			else if (this.Hairstyle == "Teacher")
			{
				this.TeacherHair.active = true;
			}
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
		this.MyRenderer.materials[3].mainTexture = this.TeacherTexture;
	}

	public virtual void BecomeBald()
	{
		this.MyRenderer.sharedMesh = this.BaldMesh;
		this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
		this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
		this.MyRenderer.materials[2].mainTexture = this.HairTexture;
		this.MyRenderer.materials[3].mainTexture = this.HairTexture;
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
						if (this.HomeCamera.Target == this.HomeCamera.Targets[9])
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
						if (this.HomeCamera.Target == this.HomeCamera.Targets[9])
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
		if (this.Tortured && this.RightEye != null)
		{
			if (this.EyeShrink > (float)1)
			{
				this.EyeShrink = (float)1;
			}
			if (this.Sanity >= (float)50)
			{
				float z = this.LeftEye.localPosition.z - this.EyeShrink * 0.009f;
				Vector3 localPosition = this.LeftEye.localPosition;
				float num2 = localPosition.z = z;
				Vector3 vector2 = this.LeftEye.localPosition = localPosition;
				float z2 = this.RightEye.localPosition.z + this.EyeShrink * 0.009f;
				Vector3 localPosition2 = this.RightEye.localPosition;
				float num3 = localPosition2.z = z2;
				Vector3 vector3 = this.RightEye.localPosition = localPosition2;
				float x2 = this.LeftEye.localPosition.x - this.EyeShrink * 0.002f;
				Vector3 localPosition3 = this.LeftEye.localPosition;
				float num4 = localPosition3.x = x2;
				Vector3 vector4 = this.LeftEye.localPosition = localPosition3;
				float x3 = this.RightEye.localPosition.x - this.EyeShrink * 0.002f;
				Vector3 localPosition4 = this.RightEye.localPosition;
				float num5 = localPosition4.x = x3;
				Vector3 vector5 = this.RightEye.localPosition = localPosition4;
				float x4 = this.LeftEye.localEulerAngles.x + (float)5 + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles2 = this.LeftEye.localEulerAngles;
				float num6 = localEulerAngles2.x = x4;
				Vector3 vector6 = this.LeftEye.localEulerAngles = localEulerAngles2;
				float y = this.LeftEye.localEulerAngles.y + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles3 = this.LeftEye.localEulerAngles;
				float num7 = localEulerAngles3.y = y;
				Vector3 vector7 = this.LeftEye.localEulerAngles = localEulerAngles3;
				float z3 = this.LeftEye.localEulerAngles.z + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles4 = this.LeftEye.localEulerAngles;
				float num8 = localEulerAngles4.z = z3;
				Vector3 vector8 = this.LeftEye.localEulerAngles = localEulerAngles4;
				float x5 = this.RightEye.localEulerAngles.x - (float)5 + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles5 = this.RightEye.localEulerAngles;
				float num9 = localEulerAngles5.x = x5;
				Vector3 vector9 = this.RightEye.localEulerAngles = localEulerAngles5;
				float y2 = this.RightEye.localEulerAngles.y + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles6 = this.RightEye.localEulerAngles;
				float num10 = localEulerAngles6.y = y2;
				Vector3 vector10 = this.RightEye.localEulerAngles = localEulerAngles6;
				float z4 = this.RightEye.localEulerAngles.z + UnityEngine.Random.Range(this.EyeShrink * -1f, this.EyeShrink * 1f);
				Vector3 localEulerAngles7 = this.RightEye.localEulerAngles;
				float num11 = localEulerAngles7.z = z4;
				Vector3 vector11 = this.RightEye.localEulerAngles = localEulerAngles7;
				float x6 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale = this.LeftEye.localScale;
				float num12 = localScale.x = x6;
				Vector3 vector12 = this.LeftEye.localScale = localScale;
				float y3 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale2 = this.LeftEye.localScale;
				float num13 = localScale2.y = y3;
				Vector3 vector13 = this.LeftEye.localScale = localScale2;
				float x7 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale3 = this.RightEye.localScale;
				float num14 = localScale3.x = x7;
				Vector3 vector14 = this.RightEye.localScale = localScale3;
				float y4 = (float)1 - this.EyeShrink * 0.5f;
				Vector3 localScale4 = this.RightEye.localScale;
				float num15 = localScale4.y = y4;
				Vector3 vector15 = this.RightEye.localScale = localScale4;
			}
		}
	}

	public virtual void UpdateSanity()
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

	public virtual void Main()
	{
	}
}
