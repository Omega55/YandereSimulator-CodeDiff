using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CosmeticScript : MonoBehaviour
{
	public TextureManagerScript TextureManager;

	public SkinnedMeshUpdater SkinUpdater;

	public StudentScript Student;

	public JsonScript JSON;

	public GameObject[] TeacherAccessories;

	public GameObject[] FemaleAccessories;

	public GameObject[] MaleAccessories;

	public GameObject[] ClubAccessories;

	public GameObject[] RightStockings;

	public GameObject[] LeftStockings;

	public GameObject[] TeacherHair;

	public GameObject[] FacialHair;

	public GameObject[] FemaleHair;

	public GameObject[] MaleHair;

	public GameObject[] Eyewear;

	public Renderer[] TeacherHairRenderers;

	public Renderer[] FacialHairRenderers;

	public Renderer[] FemaleHairRenderers;

	public Renderer[] MaleHairRenderers;

	public Texture[] GanguroUniformTextures;

	public Texture[] GanguroCasualTextures;

	public Texture[] GanguroSocksTextures;

	public Texture[] OccultUniformTextures;

	public Texture[] OccultCasualTextures;

	public Texture[] OccultSocksTextures;

	public Texture[] FemaleUniformTextures;

	public Texture[] FemaleCasualTextures;

	public Texture[] FemaleSocksTextures;

	public Texture[] MaleUniformTextures;

	public Texture[] MaleCasualTextures;

	public Texture[] MaleSocksTextures;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer FacialHairRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Renderer HairRenderer;

	public Mesh SchoolUniform;

	public Texture DefaultFaceTexture;

	public Texture TeacherBodyTexture;

	public Texture CoachBodyTexture;

	public Texture CoachFaceTexture;

	public Texture UniformTexture;

	public Texture CasualTexture;

	public Texture SocksTexture;

	public Texture FaceTexture;

	public GameObject RightIrisLight;

	public GameObject LeftIrisLight;

	public GameObject Character;

	public GameObject RightShoe;

	public GameObject LeftShoe;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Color CorrectColor;

	public Color ColorValue;

	public Mesh TeacherMesh;

	public Mesh CoachMesh;

	public bool CustomHair;

	public bool Kidnapped;

	public bool Randomize;

	public bool Cutscene;

	public bool Teacher;

	public bool Male;

	public float BreastSize;

	public string Stockings;

	public string EyeColor;

	public int FacialHairstyle;

	public int Accessory;

	public int Hairstyle;

	public int StudentID;

	public int Club;

	public int ID;

	public int FaceID;

	public int SkinID;

	public int UniformID;

	public CosmeticScript()
	{
		this.Stockings = string.Empty;
		this.EyeColor = string.Empty;
	}

	public virtual void Start()
	{
		if (this.Kidnapped)
		{
			this.GanguroCasualTextures = this.GanguroUniformTextures;
			this.GanguroSocksTextures = this.GanguroUniformTextures;
			this.OccultCasualTextures = this.OccultUniformTextures;
			this.OccultSocksTextures = this.OccultUniformTextures;
			this.FemaleCasualTextures = this.FemaleUniformTextures;
			this.FemaleSocksTextures = this.FemaleUniformTextures;
		}
		if (this.RightShoe != null)
		{
			this.RightShoe.active = false;
			this.LeftShoe.active = false;
		}
		this.ColorValue = new Color((float)1, (float)1, (float)1, (float)1);
		if (this.JSON == null)
		{
			this.JSON = this.Student.JSON;
		}
		this.Accessory = UnityBuiltins.parseInt(this.JSON.StudentAccessories[this.StudentID]);
		this.Hairstyle = UnityBuiltins.parseInt(this.JSON.StudentHairstyles[this.StudentID]);
		this.Stockings = this.JSON.StudentStockings[this.StudentID];
		this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
		string a = this.JSON.StudentColors[this.StudentID];
		this.Club = this.JSON.StudentClubs[this.StudentID];
		if (this.Randomize)
		{
			this.Teacher = false;
			this.BreastSize = (float)1;
			this.Accessory = 0;
			this.Club = 0;
			if (!this.Male)
			{
				this.Hairstyle = UnityEngine.Random.Range(1, Extensions.get_length(this.FemaleHair));
			}
			else
			{
				this.Hairstyle = UnityEngine.Random.Range(1, Extensions.get_length(this.MaleHair));
			}
		}
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			if (this.StudentID == 32 && !this.Kidnapped && Application.loadedLevelName == "PortraitScene")
			{
				this.Character.animation.Play("f02_socialCameraPose_00");
			}
		}
		else if (this.Club == 3)
		{
			this.Character.animation["sadFace_00"].layer = 1;
			this.Character.animation.Play("sadFace_00");
			this.Character.animation["sadFace_00"].weight = (float)1;
		}
		if (this.Club == 100)
		{
			this.SkinUpdater.UpdateSkin();
			this.SkinUpdater.UpdateSkin();
			this.Teacher = true;
		}
		else if (this.Club == 101)
		{
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Replaced") == 0)
			{
				this.Character.animation["f02_smile_00"].layer = 1;
				this.Character.animation.Play("f02_smile_00");
				this.Character.animation["f02_smile_00"].weight = (float)1;
				this.RightEyeRenderer.gameObject.active = false;
				this.LeftEyeRenderer.gameObject.active = false;
			}
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
		while (this.ID < Extensions.get_length(this.FacialHair))
		{
			if (this.FacialHair[this.ID] != null)
			{
				this.FacialHair[this.ID].active = false;
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
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.RightStockings))
		{
			if (this.RightStockings[this.ID] != null)
			{
				this.RightStockings[this.ID].active = false;
			}
			if (this.LeftStockings[this.ID] != null)
			{
				this.LeftStockings[this.ID].active = false;
			}
			this.ID++;
		}
		if (this.StudentID == 1 && PlayerPrefs.GetInt("CustomSenpai") == 1)
		{
			if (PlayerPrefs.GetInt("SenpaiEyeWear") > 0)
			{
				this.Eyewear[PlayerPrefs.GetInt("SenpaiEyeWear")].active = true;
			}
			this.FacialHairstyle = PlayerPrefs.GetInt("SenpaiFacialHair");
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
			if (this.Hairstyle > 0)
			{
				this.MaleHair[this.Hairstyle].active = true;
				this.HairRenderer = this.MaleHairRenderers[this.Hairstyle];
			}
			if (this.FacialHairstyle > 0)
			{
				this.FacialHair[this.FacialHairstyle].active = true;
				this.FacialHairRenderer = this.FacialHairRenderers[this.FacialHairstyle];
			}
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
		if (this.Stockings == "Loose")
		{
			this.RightStockings[0].active = true;
			this.LeftStockings[0].active = true;
		}
		if (!this.Randomize)
		{
			if (a == "White")
			{
				this.ColorValue = new Color((float)1, (float)1, (float)1);
			}
			else if (a == "Black")
			{
				this.ColorValue = new Color(0.5f, 0.5f, 0.5f);
			}
			else if (a == "Red")
			{
				this.ColorValue = new Color((float)1, (float)0, (float)0);
			}
			else if (a == "Yellow")
			{
				this.ColorValue = new Color((float)1, (float)1, (float)0);
			}
			else if (a == "Green")
			{
				this.ColorValue = new Color((float)0, (float)1, (float)0);
			}
			else if (a == "Cyan")
			{
				this.ColorValue = new Color((float)0, (float)1, (float)1);
			}
			else if (a == "Blue")
			{
				this.ColorValue = new Color((float)0, (float)0, (float)1);
			}
			else if (a == "Purple")
			{
				this.ColorValue = new Color((float)1, (float)0, (float)1);
			}
			else if (a == "Orange")
			{
				this.ColorValue = new Color((float)1, 0.5f, (float)0);
			}
			else if (a == "Brown")
			{
				this.ColorValue = new Color(0.5f, 0.25f, (float)0);
			}
			else
			{
				this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.FaceTexture = this.HairRenderer.material.mainTexture;
				this.CustomHair = true;
			}
			if (this.Hairstyle > 0)
			{
				this.HairRenderer.material.color = this.ColorValue;
			}
		}
		else
		{
			float r = UnityEngine.Random.Range((float)0, 1f);
			Color color = this.HairRenderer.material.color;
			float num = color.r = r;
			Color color2 = this.HairRenderer.material.color = color;
			float g = UnityEngine.Random.Range((float)0, 1f);
			Color color3 = this.HairRenderer.material.color;
			float num2 = color3.g = g;
			Color color4 = this.HairRenderer.material.color = color3;
			float b = UnityEngine.Random.Range((float)0, 1f);
			Color color5 = this.HairRenderer.material.color;
			float num3 = color5.b = b;
			Color color6 = this.HairRenderer.material.color = color5;
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
				this.RightEyeRenderer.material.color = this.ColorValue;
				this.LeftEyeRenderer.material.color = this.ColorValue;
			}
		}
		else if (this.Teacher)
		{
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Replaced") == 1)
			{
				float @float = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_ColorR");
				float float2 = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_ColorG");
				float float3 = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_ColorB");
				this.HairRenderer.material.color = new Color(@float, float2, float3);
			}
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
			if (this.FacialHairRenderer != null)
			{
				this.FacialHairRenderer.material.color = this.ColorValue;
				if (Extensions.get_length(this.FacialHairRenderer.materials) > 1)
				{
					this.FacialHairRenderer.materials[1].color = this.ColorValue;
				}
			}
		}
		if (!this.Randomize)
		{
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
		}
		else
		{
			float num4 = UnityEngine.Random.Range((float)0, 1f);
			float num5 = UnityEngine.Random.Range((float)0, 1f);
			float num6 = UnityEngine.Random.Range((float)0, 1f);
			float r2 = num4;
			Color color7 = this.RightEyeRenderer.material.color;
			float num7 = color7.r = r2;
			Color color8 = this.RightEyeRenderer.material.color = color7;
			float g2 = num5;
			Color color9 = this.RightEyeRenderer.material.color;
			float num8 = color9.g = g2;
			Color color10 = this.RightEyeRenderer.material.color = color9;
			float b2 = num6;
			Color color11 = this.RightEyeRenderer.material.color;
			float num9 = color11.b = b2;
			Color color12 = this.RightEyeRenderer.material.color = color11;
			float r3 = num4;
			Color color13 = this.LeftEyeRenderer.material.color;
			float num10 = color13.r = r3;
			Color color14 = this.LeftEyeRenderer.material.color = color13;
			float g3 = num5;
			Color color15 = this.LeftEyeRenderer.material.color;
			float num11 = color15.g = g3;
			Color color16 = this.LeftEyeRenderer.material.color = color15;
			float b3 = num6;
			Color color17 = this.LeftEyeRenderer.material.color;
			float num12 = color17.b = b3;
			Color color18 = this.LeftEyeRenderer.material.color = color17;
		}
		if (this.StudentID == 17)
		{
			if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2)
			{
				this.FemaleAccessories[3].active = false;
			}
		}
		else if (this.StudentID == 20 && this.transform.position != new Vector3((float)0, (float)0, (float)0))
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
		this.UniformTexture = this.MaleUniformTextures[PlayerPrefs.GetInt("MaleUniform")];
		this.CasualTexture = this.MaleCasualTextures[PlayerPrefs.GetInt("MaleUniform")];
		this.SocksTexture = this.MaleSocksTextures[PlayerPrefs.GetInt("MaleUniform")];
		if (PlayerPrefs.GetInt("MaleUniform") == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		if (!this.Student.Indoors)
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[@int];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
		}
		else
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[@int];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
		}
	}

	public virtual void SetFemaleUniform()
	{
		this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.SchoolUniform = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		if (this.StudentID == 26)
		{
			this.UniformTexture = this.OccultUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.CasualTexture = this.OccultCasualTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.SocksTexture = this.OccultSocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (this.StudentID == 32)
		{
			this.UniformTexture = this.GanguroUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.CasualTexture = this.GanguroCasualTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.SocksTexture = this.GanguroSocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else
		{
			this.UniformTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.CasualTexture = this.FemaleCasualTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.SocksTexture = this.FemaleSocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
			if (this.StudentID == 16)
			{
				if (this.TextureManager.UniformTextures[this.StudentID] == null)
				{
					this.TextureManager.Base2D = (this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")] as Texture2D);
					this.TextureManager.UniformTextures[this.StudentID] = this.TextureManager.MergeTextures(this.TextureManager.Base2D, this.TextureManager.GreenStockings);
					this.TextureManager.Base2D = (this.FemaleCasualTextures[PlayerPrefs.GetInt("FemaleUniform")] as Texture2D);
					this.TextureManager.CasualTextures[this.StudentID] = this.TextureManager.MergeTextures(this.TextureManager.Base2D, this.TextureManager.GreenStockings);
					this.TextureManager.Base2D = (this.FemaleSocksTextures[PlayerPrefs.GetInt("FemaleUniform")] as Texture2D);
					this.TextureManager.SocksTextures[this.StudentID] = this.TextureManager.MergeTextures(this.TextureManager.Base2D, this.TextureManager.GreenStockings);
				}
				this.UniformTexture = this.TextureManager.UniformTextures[this.StudentID];
				this.CasualTexture = this.TextureManager.CasualTextures[this.StudentID];
				this.SocksTexture = this.TextureManager.SocksTextures[this.StudentID];
			}
		}
		if (!this.Cutscene)
		{
			if (!this.Kidnapped)
			{
				if (!this.Student.Indoors)
				{
					this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
					this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
					this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
				}
			}
			else
			{
				this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
			}
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
		}
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
	}

	public virtual void Main()
	{
	}
}
