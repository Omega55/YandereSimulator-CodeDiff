using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CosmeticScript : MonoBehaviour
{
	public StudentScript Student;

	public JsonScript JSON;

	public GameObject[] TeacherAccessories;

	public GameObject[] FemaleAccessories;

	public GameObject[] MaleAccessories;

	public GameObject[] ClubAccessories;

	public GameObject[] TeacherHair;

	public GameObject[] FemaleHair;

	public GameObject[] MaleHair;

	public GameObject[] Eyewear;

	public Renderer[] TeacherHairRenderers;

	public Renderer[] FemaleHairRenderers;

	public Renderer[] MaleHairRenderers;

	public Texture[] FemaleUniformTextures;

	public Texture[] MaleUniformTextures;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Renderer HairRenderer;

	public Mesh SchoolUniform;

	public Texture DefaultFaceTexture;

	public Texture TeacherBodyTexture;

	public Texture CoachBodyTexture;

	public Texture CoachFaceTexture;

	public Texture FaceTexture;

	public GameObject RightIrisLight;

	public GameObject LeftIrisLight;

	public GameObject Character;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Color CorrectColor;

	public Mesh TeacherMesh;

	public Mesh CoachMesh;

	public bool CustomHair;

	public bool Kidnapped;

	public bool Teacher;

	public bool Male;

	public float BreastSize;

	public string EyeColor;

	public int Accessory;

	public int Hairstyle;

	public int StudentID;

	public int Club;

	public int ID;

	public CosmeticScript()
	{
		this.EyeColor = string.Empty;
	}

	public virtual void Start()
	{
		this.JSON = (JsonScript)GameObject.Find("JSON").GetComponent(typeof(JsonScript));
		this.Accessory = UnityBuiltins.parseInt(this.JSON.StudentAccessories[this.StudentID]);
		this.Hairstyle = UnityBuiltins.parseInt(this.JSON.StudentHairstyles[this.StudentID]);
		this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
		string a = this.JSON.StudentColors[this.StudentID];
		this.Club = this.JSON.StudentClubs[this.StudentID];
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		}
		else if (this.Club == 3)
		{
			this.Character.animation["sadFace_00"].layer = 1;
			this.Character.animation.Play("sadFace_00");
			this.Character.animation["sadFace_00"].weight = (float)1;
		}
		if (this.Club == 100)
		{
			this.MyRenderer.sharedMesh = this.TeacherMesh;
			this.Teacher = true;
		}
		else if (this.Club == 101)
		{
			this.Character.animation["f02_smile_00"].layer = 1;
			this.Character.animation.Play("f02_smile_00");
			this.Character.animation["f02_smile_00"].weight = (float)1;
			this.RightEyeRenderer.gameObject.active = false;
			this.LeftEyeRenderer.gameObject.active = false;
			this.MyRenderer.sharedMesh = this.CoachMesh;
			this.Teacher = true;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FemaleAccessories))
		{
			if (this.FemaleAccessories[this.ID] != null)
			{
				this.FemaleAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.MaleAccessories))
		{
			if (this.MaleAccessories[this.ID] != null)
			{
				this.MaleAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.ClubAccessories))
		{
			if (this.ClubAccessories[this.ID] != null)
			{
				this.ClubAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TeacherAccessories))
		{
			if (this.TeacherAccessories[this.ID] != null)
			{
				this.TeacherAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TeacherHair))
		{
			if (this.TeacherHair[this.ID] != null)
			{
				this.TeacherHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FemaleHair))
		{
			if (this.FemaleHair[this.ID] != null)
			{
				this.FemaleHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.MaleHair))
		{
			if (this.MaleHair[this.ID] != null)
			{
				this.MaleHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Eyewear))
		{
			if (this.Eyewear[this.ID] != null)
			{
				this.Eyewear[this.ID].active = false;
			}
			this.ID++;
		}
		if (this.StudentID == 1 && PlayerPrefs.GetInt("CustomSenpai") == 1)
		{
			if (PlayerPrefs.GetInt("SenpaiEyeWear") > 0)
			{
				this.Eyewear[PlayerPrefs.GetInt("SenpaiEyeWear")].active = true;
			}
			a = PlayerPrefs.GetString("SenpaiHairColor");
			this.EyeColor = PlayerPrefs.GetString("SenpaiEyeColor");
			this.Hairstyle = PlayerPrefs.GetInt("SenpaiHairStyle");
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				this.FemaleHair[this.Hairstyle].active = true;
				this.HairRenderer = this.FemaleHairRenderers[this.Hairstyle];
				this.SetFemaleUniform();
			}
			else
			{
				this.TeacherHair[this.Hairstyle].active = true;
				this.HairRenderer = this.TeacherHairRenderers[this.Hairstyle];
				if (this.Club == 100)
				{
					this.MyRenderer.materials[0].mainTexture = this.TeacherBodyTexture;
					this.MyRenderer.materials[1].mainTexture = this.DefaultFaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.TeacherBodyTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.CoachFaceTexture;
					this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
					this.MyRenderer.materials[2].mainTexture = this.CoachBodyTexture;
				}
			}
		}
		else
		{
			this.MaleHair[this.Hairstyle].active = true;
			this.HairRenderer = this.MaleHairRenderers[this.Hairstyle];
			this.SetMaleUniform();
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				if (this.FemaleAccessories[this.Accessory] != null)
				{
					this.FemaleAccessories[this.Accessory].active = true;
				}
			}
			else if (this.TeacherAccessories[this.Accessory] != null)
			{
				this.TeacherAccessories[this.Accessory].active = true;
			}
		}
		else if (this.MaleAccessories[this.Accessory] != null)
		{
			this.MaleAccessories[this.Accessory].active = true;
		}
		if (this.Club < 11 && this.ClubAccessories[this.Club] != null && PlayerPrefs.GetInt("Club_" + this.Club + "_Closed") == 0)
		{
			this.ClubAccessories[this.Club].active = true;
		}
		if (a == "White")
		{
			this.HairRenderer.material.color = new Color((float)1, (float)1, (float)1);
		}
		else if (a == "Black")
		{
			this.HairRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
		}
		else if (a == "Red")
		{
			this.HairRenderer.material.color = new Color((float)1, (float)0, (float)0);
		}
		else if (a == "Yellow")
		{
			this.HairRenderer.material.color = new Color((float)1, (float)1, (float)0);
		}
		else if (a == "Green")
		{
			this.HairRenderer.material.color = new Color((float)0, (float)1, (float)0);
		}
		else if (a == "Cyan")
		{
			this.HairRenderer.material.color = new Color((float)0, (float)1, (float)1);
		}
		else if (a == "Blue")
		{
			this.HairRenderer.material.color = new Color((float)0, (float)0, (float)1);
		}
		else if (a == "Purple")
		{
			this.HairRenderer.material.color = new Color((float)1, (float)0, (float)1);
		}
		else if (a == "Orange")
		{
			this.HairRenderer.material.color = new Color((float)1, 0.5f, (float)0);
		}
		else if (a == "Brown")
		{
			this.HairRenderer.material.color = new Color(0.5f, 0.25f, (float)0);
		}
		else
		{
			this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
			this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
			this.FaceTexture = this.HairRenderer.material.mainTexture;
			this.CustomHair = true;
		}
		if (!this.Teacher)
		{
			if (this.CustomHair)
			{
				if (!this.Male)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (PlayerPrefs.GetInt("MaleUniform") == 1)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (PlayerPrefs.GetInt("MaleUniform") < 4)
				{
					this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				}
			}
			else
			{
				this.RightEyeRenderer.material.color = this.HairRenderer.material.color;
				this.LeftEyeRenderer.material.color = this.HairRenderer.material.color;
			}
		}
		else if (this.Teacher && this.Club == 100)
		{
			this.HairRenderer.material.color = new Color(0.5f, 0.25f, (float)0, (float)1);
			this.RightEyeRenderer.material.color = this.HairRenderer.material.color;
			this.LeftEyeRenderer.material.color = this.HairRenderer.material.color;
		}
		if (this.Male)
		{
			if (this.Accessory == 2)
			{
				this.RightIrisLight.active = false;
				this.LeftIrisLight.active = false;
			}
			if (Application.loadedLevelName == "PortraitScene")
			{
				this.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
			}
		}
		if (this.EyeColor != string.Empty)
		{
			if (this.EyeColor == "White")
			{
				this.CorrectColor = new Color((float)1, (float)1, (float)1);
			}
			else if (this.EyeColor == "Black")
			{
				this.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
			}
			else if (this.EyeColor == "Red")
			{
				this.CorrectColor = new Color((float)1, (float)0, (float)0);
			}
			else if (this.EyeColor == "Yellow")
			{
				this.CorrectColor = new Color((float)1, (float)1, (float)0);
			}
			else if (this.EyeColor == "Green")
			{
				this.CorrectColor = new Color((float)0, (float)1, (float)0);
			}
			else if (this.EyeColor == "Cyan")
			{
				this.CorrectColor = new Color((float)0, (float)1, (float)1);
			}
			else if (this.EyeColor == "Blue")
			{
				this.CorrectColor = new Color((float)0, (float)0, (float)1);
			}
			else if (this.EyeColor == "Purple")
			{
				this.CorrectColor = new Color((float)1, (float)0, (float)1);
			}
			else if (this.EyeColor == "Orange")
			{
				this.CorrectColor = new Color((float)1, 0.5f, (float)0);
			}
			else if (this.EyeColor == "Brown")
			{
				this.CorrectColor = new Color(0.5f, 0.25f, (float)0);
			}
			this.RightEyeRenderer.material.color = this.CorrectColor;
			this.LeftEyeRenderer.material.color = this.CorrectColor;
		}
		if (this.StudentID == 20 && this.transform.position != new Vector3((float)0, (float)0, (float)0))
		{
			this.RightEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
			this.LeftEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
			((RainbowScript)this.RightEyeRenderer.gameObject.GetComponent(typeof(RainbowScript))).enabled = true;
			((RainbowScript)this.LeftEyeRenderer.gameObject.GetComponent(typeof(RainbowScript))).enabled = true;
		}
		if (this.Student != null && this.Student.AoT)
		{
			this.Student.AttackOnTitan();
		}
	}

	public virtual void SetMaleUniform()
	{
		int @int;
		if (this.StudentID == 1)
		{
			@int = PlayerPrefs.GetInt("SenpaiSkinColor");
			this.FaceTexture = this.FaceTextures[@int];
		}
		else if (this.CustomHair)
		{
			this.FaceTexture = this.HairRenderer.material.mainTexture;
		}
		else
		{
			this.FaceTexture = this.DefaultFaceTexture;
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[PlayerPrefs.GetInt("MaleUniform")];
		this.SchoolUniform = this.MaleUniforms[PlayerPrefs.GetInt("MaleUniform")];
		if (PlayerPrefs.GetInt("MaleUniform") == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.SkinTextures[@int];
			this.MyRenderer.materials[1].mainTexture = this.MaleUniformTextures[1];
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 2)
		{
			this.MyRenderer.materials[0].mainTexture = this.MaleUniformTextures[2];
			this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[2].mainTexture = this.SkinTextures[@int];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.MaleUniformTextures[3];
			this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[2].mainTexture = this.SkinTextures[@int];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 4)
		{
			this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.SkinTextures[@int];
			this.MyRenderer.materials[2].mainTexture = this.MaleUniformTextures[4];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 5)
		{
			this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.SkinTextures[@int];
			this.MyRenderer.materials[2].mainTexture = this.MaleUniformTextures[5];
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 6)
		{
			this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.SkinTextures[@int];
			this.MyRenderer.materials[2].mainTexture = this.MaleUniformTextures[6];
		}
	}

	public virtual void SetFemaleUniform()
	{
		this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.SchoolUniform = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
	}

	public virtual void Main()
	{
	}
}
