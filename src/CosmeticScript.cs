using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosmeticScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TextureManagerScript TextureManager;

	public SkinnedMeshUpdater SkinUpdater;

	public LoveManagerScript LoveManager;

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

	public Texture PurpleStockings;

	public Texture YellowStockings;

	public Texture BlackStockings;

	public Texture GreenStockings;

	public Texture BlueStockings;

	public Texture CyanStockings;

	public Texture RedStockings;

	public Texture KizanaStockings;

	public Texture OsanaStockings;

	public Texture[] CustomStockings;

	public Texture MyStockings;

	public GameObject RightIrisLight;

	public GameObject LeftIrisLight;

	public GameObject Character;

	public GameObject RightShoe;

	public GameObject LeftShoe;

	public GameObject Charm;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Color CorrectColor;

	public Color ColorValue;

	public Mesh TeacherMesh;

	public Mesh CoachMesh;

	public bool TakingPortrait;

	public bool Initialized;

	public bool CustomHair;

	public bool HomeScene;

	public bool Kidnapped;

	public bool Randomize;

	public bool Cutscene;

	public bool TurnedOn;

	public bool Teacher;

	public bool Yandere;

	public bool Male;

	public float BreastSize;

	public string OriginalStockings = string.Empty;

	public string HairColor = string.Empty;

	public string Stockings = string.Empty;

	public string EyeColor = string.Empty;

	public int FacialHairstyle;

	public int Accessory;

	public int Hairstyle;

	public int SkinColor;

	public int StudentID;

	public int Club;

	public int ID;

	public GameObject[] GaloAccessories;

	public int FaceID;

	public int SkinID;

	public int UniformID;

	public void Start()
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
			this.RightShoe.SetActive(false);
			this.LeftShoe.SetActive(false);
		}
		this.ColorValue = new Color(1f, 1f, 1f, 1f);
		if (this.JSON == null)
		{
			this.JSON = this.Student.JSON;
		}
		string text = string.Empty;
		if (!this.Initialized)
		{
			this.Accessory = int.Parse(this.JSON.StudentAccessories[this.StudentID]);
			this.Hairstyle = int.Parse(this.JSON.StudentHairstyles[this.StudentID]);
			this.Stockings = this.JSON.StudentStockings[this.StudentID];
			this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
			this.HairColor = this.JSON.StudentColors[this.StudentID];
			this.EyeColor = this.JSON.StudentEyes[this.StudentID];
			this.Club = this.JSON.StudentClubs[this.StudentID];
			text = this.JSON.StudentNames[this.StudentID];
			if (this.Yandere)
			{
				this.Accessory = 0;
				this.Hairstyle = 1;
				this.Stockings = "Black";
				this.BreastSize = 1f;
				this.HairColor = "White";
				this.EyeColor = "Black";
				this.Club = 0;
			}
			this.OriginalStockings = this.Stockings;
			this.Initialized = true;
		}
		if (text == "Random")
		{
			this.Randomize = true;
			if (!this.Male)
			{
				text = this.StudentManager.FirstNames[UnityEngine.Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.StudentNames[this.StudentID] = text;
				this.Student.Name = text;
			}
			else
			{
				text = this.StudentManager.MaleNames[UnityEngine.Random.Range(0, this.StudentManager.MaleNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.StudentNames[this.StudentID] = text;
				this.Student.Name = text;
			}
			if (Globals.MissionMode && Globals.MissionTarget == this.StudentID)
			{
				this.JSON.StudentNames[this.StudentID] = Globals.MissionTargetName;
				this.Student.Name = Globals.MissionTargetName;
				text = Globals.MissionTargetName;
			}
		}
		if (this.Randomize)
		{
			this.Teacher = false;
			this.BreastSize = UnityEngine.Random.Range(0.5f, 2f);
			this.Accessory = 0;
			this.Club = 0;
			if (!this.Male)
			{
				this.Hairstyle = 99;
				while (this.Hairstyle > 19)
				{
					this.Hairstyle = UnityEngine.Random.Range(1, this.FemaleHair.Length - 1);
				}
			}
			else
			{
				this.SkinColor = UnityEngine.Random.Range(0, this.SkinTextures.Length);
				this.Hairstyle = UnityEngine.Random.Range(1, this.MaleHair.Length);
			}
		}
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			if (this.StudentID == 32 && !this.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
			{
				this.Character.GetComponent<Animation>().Play("f02_socialCameraPose_00");
			}
		}
		else
		{
			foreach (GameObject gameObject in this.GaloAccessories)
			{
				gameObject.SetActive(false);
			}
			if (this.Club == 3)
			{
				this.Character.GetComponent<Animation>()["sadFace_00"].layer = 1;
				this.Character.GetComponent<Animation>().Play("sadFace_00");
				this.Character.GetComponent<Animation>()["sadFace_00"].weight = 1f;
			}
			if (this.StudentID == 13 && Globals.CustomSuitor)
			{
				if (Globals.CustomSuitorHair > 0)
				{
					this.Hairstyle = Globals.CustomSuitorHair;
				}
				if (Globals.CustomSuitorAccessory > 0)
				{
					this.Accessory = Globals.CustomSuitorAccessory;
					if (this.Accessory == 1)
					{
						Transform transform = this.MaleAccessories[1].transform;
						transform.localScale = new Vector3(1.02f, transform.localScale.y, 1.062f);
					}
				}
				if (Globals.CustomSuitorBlonde > 0)
				{
					this.HairColor = "Yellow";
				}
				if (Globals.CustomSuitorJewelry > 0)
				{
					foreach (GameObject gameObject2 in this.GaloAccessories)
					{
						gameObject2.SetActive(true);
					}
				}
			}
		}
		if (this.Club == 100)
		{
			this.MyRenderer.sharedMesh = this.TeacherMesh;
			this.Teacher = true;
		}
		else if (this.Club == 101)
		{
			if (!Globals.GetStudentReplaced(this.StudentID))
			{
				this.Character.GetComponent<Animation>()["f02_smile_00"].layer = 1;
				this.Character.GetComponent<Animation>().Play("f02_smile_00");
				this.Character.GetComponent<Animation>()["f02_smile_00"].weight = 1f;
				this.RightEyeRenderer.gameObject.SetActive(false);
				this.LeftEyeRenderer.gameObject.SetActive(false);
			}
			this.MyRenderer.sharedMesh = this.CoachMesh;
			this.Teacher = true;
		}
		foreach (GameObject gameObject3 in this.FemaleAccessories)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
		}
		foreach (GameObject gameObject4 in this.MaleAccessories)
		{
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
		}
		foreach (GameObject gameObject5 in this.ClubAccessories)
		{
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
		}
		foreach (GameObject gameObject6 in this.TeacherAccessories)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		foreach (GameObject gameObject7 in this.TeacherHair)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		foreach (GameObject gameObject8 in this.FemaleHair)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		foreach (GameObject gameObject9 in this.MaleHair)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		foreach (GameObject gameObject10 in this.FacialHair)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		foreach (GameObject gameObject11 in this.Eyewear)
		{
			if (gameObject11 != null)
			{
				gameObject11.SetActive(false);
			}
		}
		foreach (GameObject gameObject12 in this.RightStockings)
		{
			if (gameObject12 != null)
			{
				gameObject12.SetActive(false);
			}
		}
		foreach (GameObject gameObject13 in this.LeftStockings)
		{
			if (gameObject13 != null)
			{
				gameObject13.SetActive(false);
			}
		}
		if (this.StudentID == 13 && Globals.CustomSuitor && Globals.CustomSuitorEyewear > 0)
		{
			this.Eyewear[Globals.CustomSuitorEyewear].SetActive(true);
		}
		if (this.StudentID == 1 && Globals.CustomSenpai)
		{
			if (Globals.SenpaiEyeWear > 0)
			{
				this.Eyewear[Globals.SenpaiEyeWear].SetActive(true);
			}
			this.FacialHairstyle = Globals.SenpaiFacialHair;
			this.HairColor = Globals.SenpaiHairColor;
			this.EyeColor = Globals.SenpaiEyeColor;
			this.Hairstyle = Globals.SenpaiHairStyle;
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				this.FemaleHair[this.Hairstyle].SetActive(true);
				this.HairRenderer = this.FemaleHairRenderers[this.Hairstyle];
				this.SetFemaleUniform();
			}
			else
			{
				this.TeacherHair[this.Hairstyle].SetActive(true);
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
				this.MaleHair[this.Hairstyle].SetActive(true);
				this.HairRenderer = this.MaleHairRenderers[this.Hairstyle];
			}
			if (this.FacialHairstyle > 0)
			{
				this.FacialHair[this.FacialHairstyle].SetActive(true);
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
					this.FemaleAccessories[this.Accessory].SetActive(true);
				}
			}
			else if (this.TeacherAccessories[this.Accessory] != null)
			{
				this.TeacherAccessories[this.Accessory].SetActive(true);
			}
		}
		else if (this.MaleAccessories[this.Accessory] != null)
		{
			this.MaleAccessories[this.Accessory].SetActive(true);
		}
		if (this.Club < 11 && this.ClubAccessories[this.Club] != null && !Globals.GetClubClosed(this.Club) && this.StudentID != 26)
		{
			this.ClubAccessories[this.Club].SetActive(true);
		}
		if (!this.Male)
		{
			base.StartCoroutine(this.PutOnStockings());
		}
		if (!this.Randomize)
		{
			if (this.EyeColor != string.Empty)
			{
				if (this.EyeColor == "White")
				{
					this.CorrectColor = new Color(1f, 1f, 1f);
				}
				else if (this.EyeColor == "Black")
				{
					this.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (this.EyeColor == "Red")
				{
					this.CorrectColor = new Color(1f, 0f, 0f);
				}
				else if (this.EyeColor == "Yellow")
				{
					this.CorrectColor = new Color(1f, 1f, 0f);
				}
				else if (this.EyeColor == "Green")
				{
					this.CorrectColor = new Color(0f, 1f, 0f);
				}
				else if (this.EyeColor == "Cyan")
				{
					this.CorrectColor = new Color(0f, 1f, 1f);
				}
				else if (this.EyeColor == "Blue")
				{
					this.CorrectColor = new Color(0f, 0f, 1f);
				}
				else if (this.EyeColor == "Purple")
				{
					this.CorrectColor = new Color(1f, 0f, 1f);
				}
				else if (this.EyeColor == "Orange")
				{
					this.CorrectColor = new Color(1f, 0.5f, 0f);
				}
				else if (this.EyeColor == "Brown")
				{
					this.CorrectColor = new Color(0.5f, 0.25f, 0f);
				}
				else
				{
					this.CorrectColor = new Color(0f, 0f, 0f);
				}
				if (this.CorrectColor != new Color(0f, 0f, 0f))
				{
					this.RightEyeRenderer.material.color = this.CorrectColor;
					this.LeftEyeRenderer.material.color = this.CorrectColor;
				}
			}
		}
		else
		{
			float r = UnityEngine.Random.Range(0f, 1f);
			float g = UnityEngine.Random.Range(0f, 1f);
			float b = UnityEngine.Random.Range(0f, 1f);
			this.RightEyeRenderer.material.color = new Color(r, g, b);
			this.LeftEyeRenderer.material.color = new Color(r, g, b);
		}
		if (!this.Randomize)
		{
			if (this.HairColor == "White")
			{
				this.ColorValue = new Color(1f, 1f, 1f);
			}
			else if (this.HairColor == "Black")
			{
				this.ColorValue = new Color(0.5f, 0.5f, 0.5f);
			}
			else if (this.HairColor == "Red")
			{
				this.ColorValue = new Color(1f, 0f, 0f);
			}
			else if (this.HairColor == "Yellow")
			{
				this.ColorValue = new Color(1f, 1f, 0f);
			}
			else if (this.HairColor == "Green")
			{
				this.ColorValue = new Color(0f, 1f, 0f);
			}
			else if (this.HairColor == "Cyan")
			{
				this.ColorValue = new Color(0f, 1f, 1f);
			}
			else if (this.HairColor == "Blue")
			{
				this.ColorValue = new Color(0f, 0f, 1f);
			}
			else if (this.HairColor == "Purple")
			{
				this.ColorValue = new Color(1f, 0f, 1f);
			}
			else if (this.HairColor == "Orange")
			{
				this.ColorValue = new Color(1f, 0.5f, 0f);
			}
			else if (this.HairColor == "Brown")
			{
				this.ColorValue = new Color(0.5f, 0.25f, 0f);
			}
			else
			{
				this.ColorValue = new Color(0f, 0f, 0f);
			}
			if (this.ColorValue == new Color(0f, 0f, 0f))
			{
				this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.FaceTexture = this.HairRenderer.material.mainTexture;
				this.CustomHair = true;
			}
			if (!this.CustomHair && this.Hairstyle > 0)
			{
				this.HairRenderer.material.color = this.ColorValue;
			}
			if (!this.Male && this.Accessory == 6)
			{
				this.FemaleAccessories[6].GetComponent<Renderer>().material.color = this.ColorValue;
			}
		}
		else
		{
			this.HairRenderer.material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
		if (!this.Teacher)
		{
			if (this.CustomHair)
			{
				if (!this.Male)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (Globals.MaleUniform == 1)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (Globals.MaleUniform < 4)
				{
					this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				}
			}
		}
		else if (this.Teacher && Globals.GetStudentReplaced(this.StudentID))
		{
			Color studentColor = Globals.GetStudentColor(this.StudentID);
			Color studentEyeColor = Globals.GetStudentEyeColor(this.StudentID);
			this.HairRenderer.material.color = studentColor;
			this.RightEyeRenderer.material.color = studentEyeColor;
			this.LeftEyeRenderer.material.color = studentEyeColor;
		}
		if (this.Male)
		{
			if (this.Accessory == 2)
			{
				this.RightIrisLight.SetActive(false);
				this.LeftIrisLight.SetActive(false);
			}
			if (SceneManager.GetActiveScene().name == "PortraitScene")
			{
				this.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
			}
			if (this.FacialHairRenderer != null)
			{
				this.FacialHairRenderer.material.color = this.ColorValue;
				if (this.FacialHairRenderer.materials.Length > 1)
				{
					this.FacialHairRenderer.materials[1].color = this.ColorValue;
				}
			}
		}
		if (this.StudentID == 17)
		{
			if (Globals.GetSchemeStage(2) == 2)
			{
				this.FemaleAccessories[3].SetActive(false);
			}
		}
		else if (this.StudentID == 20 && base.transform.position != Vector3.zero)
		{
			this.RightEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
			this.LeftEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
			this.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
			this.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
		}
		if (this.Student != null && this.Student.AoT)
		{
			this.Student.AttackOnTitan();
		}
		if (this.HomeScene)
		{
			this.Student.CharacterAnimation["idle_00"].time = 9f;
			this.Student.CharacterAnimation["idle_00"].speed = 0f;
		}
		this.TaskCheck();
		this.TurnOnCheck();
	}

	public void SetMaleUniform()
	{
		if (this.StudentID == 1)
		{
			this.SkinColor = Globals.SenpaiSkinColor;
			this.FaceTexture = this.FaceTextures[this.SkinColor];
		}
		else
		{
			this.FaceTexture = ((!this.CustomHair) ? this.FaceTextures[this.SkinColor] : this.HairRenderer.material.mainTexture);
			if (this.StudentID == 13 && Globals.CustomSuitor && Globals.CustomSuitorTan)
			{
				this.SkinColor = 6;
				this.FaceTexture = this.FaceTextures[6];
			}
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[Globals.MaleUniform];
		this.SchoolUniform = this.MaleUniforms[Globals.MaleUniform];
		this.UniformTexture = this.MaleUniformTextures[Globals.MaleUniform];
		this.CasualTexture = this.MaleCasualTextures[Globals.MaleUniform];
		this.SocksTexture = this.MaleSocksTextures[Globals.MaleUniform];
		if (Globals.MaleUniform == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (Globals.MaleUniform == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (Globals.MaleUniform == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (Globals.MaleUniform == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (Globals.MaleUniform == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (Globals.MaleUniform == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		if (!this.Student.Indoors)
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
		}
		else
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
		}
	}

	public void SetFemaleUniform()
	{
		this.MyRenderer.sharedMesh = this.FemaleUniforms[Globals.FemaleUniform];
		this.SchoolUniform = this.FemaleUniforms[Globals.FemaleUniform];
		if (this.StudentID == 26)
		{
			this.UniformTexture = this.OccultUniformTextures[Globals.FemaleUniform];
			this.CasualTexture = this.OccultCasualTextures[Globals.FemaleUniform];
			this.SocksTexture = this.OccultSocksTextures[Globals.FemaleUniform];
		}
		else if (this.StudentID == 32)
		{
			this.UniformTexture = this.GanguroUniformTextures[Globals.FemaleUniform];
			this.CasualTexture = this.GanguroCasualTextures[Globals.FemaleUniform];
			this.SocksTexture = this.GanguroSocksTextures[Globals.FemaleUniform];
		}
		else
		{
			this.UniformTexture = this.FemaleUniformTextures[Globals.FemaleUniform];
			this.CasualTexture = this.FemaleCasualTextures[Globals.FemaleUniform];
			this.SocksTexture = this.FemaleSocksTextures[Globals.FemaleUniform];
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
		if (!this.TakingPortrait && this.Student != null && this.Student.StudentManager != null && this.Student.StudentManager.Censor)
		{
			this.CensorPanties();
		}
		if (this.MyStockings != null)
		{
			base.StartCoroutine(this.PutOnStockings());
		}
	}

	public void CensorPanties()
	{
		if (!this.Student.ClubAttire && this.Student.Schoolwear == 1)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
		}
		else
		{
			this.RemoveCensor();
		}
	}

	public void RemoveCensor()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
	}

	private void TaskCheck()
	{
		if (this.StudentID == 15)
		{
			if (Globals.GetTaskStatus(15) < 3 && !this.TakingPortrait)
			{
				this.MaleAccessories[1].SetActive(false);
			}
		}
		else if (this.StudentID == 33 && Globals.GetTaskStatus(33) < 3 && this.Charm != null)
		{
			this.Charm.SetActive(true);
		}
	}

	private void TurnOnCheck()
	{
		if (!this.TurnedOn && !this.TakingPortrait && this.Male)
		{
			if (this.HairColor == "Purple")
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			if (this.MaleAccessories[2].activeInHierarchy)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			if (this.MaleAccessories[3].activeInHierarchy)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
		}
		this.TurnedOn = true;
	}

	private void DestroyUnneccessaryObjects()
	{
		foreach (GameObject gameObject in this.FemaleAccessories)
		{
			if (gameObject != null && !gameObject.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		foreach (GameObject gameObject2 in this.MaleAccessories)
		{
			if (gameObject2 != null && !gameObject2.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject2);
			}
		}
		foreach (GameObject gameObject3 in this.ClubAccessories)
		{
			if (gameObject3 != null && !gameObject3.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject3);
			}
		}
		foreach (GameObject gameObject4 in this.TeacherAccessories)
		{
			if (gameObject4 != null && !gameObject4.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject4);
			}
		}
		foreach (GameObject gameObject5 in this.TeacherHair)
		{
			if (gameObject5 != null && !gameObject5.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject5);
			}
		}
		foreach (GameObject gameObject6 in this.FemaleHair)
		{
			if (gameObject6 != null && !gameObject6.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject6);
			}
		}
		foreach (GameObject gameObject7 in this.MaleHair)
		{
			if (gameObject7 != null && !gameObject7.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject7);
			}
		}
		foreach (GameObject gameObject8 in this.FacialHair)
		{
			if (gameObject8 != null && !gameObject8.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject8);
			}
		}
		foreach (GameObject gameObject9 in this.Eyewear)
		{
			if (gameObject9 != null && !gameObject9.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject9);
			}
		}
		foreach (GameObject gameObject10 in this.RightStockings)
		{
			if (gameObject10 != null && !gameObject10.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject10);
			}
		}
		foreach (GameObject gameObject11 in this.LeftStockings)
		{
			if (gameObject11 != null && !gameObject11.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject11);
			}
		}
	}

	public IEnumerator PutOnStockings()
	{
		this.RightStockings[0].SetActive(false);
		this.LeftStockings[0].SetActive(false);
		if (this.Stockings == string.Empty)
		{
			this.MyStockings = null;
		}
		else if (this.Stockings == "Red")
		{
			this.MyStockings = this.RedStockings;
		}
		else if (this.Stockings == "Yellow")
		{
			this.MyStockings = this.YellowStockings;
		}
		else if (this.Stockings == "Green")
		{
			this.MyStockings = this.GreenStockings;
		}
		else if (this.Stockings == "Cyan")
		{
			this.MyStockings = this.CyanStockings;
		}
		else if (this.Stockings == "Blue")
		{
			this.MyStockings = this.BlueStockings;
		}
		else if (this.Stockings == "Purple")
		{
			this.MyStockings = this.PurpleStockings;
		}
		else if (this.Stockings == "Black")
		{
			this.MyStockings = this.BlackStockings;
		}
		else if (this.Stockings == "Osana")
		{
			this.MyStockings = this.OsanaStockings;
		}
		else if (this.Stockings == "Kizana")
		{
			this.MyStockings = this.KizanaStockings;
		}
		else if (this.Stockings == "Custom1")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings1.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[1] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[1];
		}
		else if (this.Stockings == "Custom2")
		{
			WWW NewCustomStockings2 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings2.png");
			yield return NewCustomStockings2;
			if (NewCustomStockings2.error == null)
			{
				this.CustomStockings[2] = NewCustomStockings2.texture;
			}
			this.MyStockings = this.CustomStockings[2];
		}
		else if (this.Stockings == "Custom3")
		{
			WWW NewCustomStockings3 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings3.png");
			yield return NewCustomStockings3;
			if (NewCustomStockings3.error == null)
			{
				this.CustomStockings[3] = NewCustomStockings3.texture;
			}
			this.MyStockings = this.CustomStockings[3];
		}
		else if (this.Stockings == "Custom4")
		{
			WWW NewCustomStockings4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings4.png");
			yield return NewCustomStockings4;
			if (NewCustomStockings4.error == null)
			{
				this.CustomStockings[4] = NewCustomStockings4.texture;
			}
			this.MyStockings = this.CustomStockings[4];
		}
		else if (this.Stockings == "Custom5")
		{
			WWW NewCustomStockings5 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings5.png");
			yield return NewCustomStockings5;
			if (NewCustomStockings5.error == null)
			{
				this.CustomStockings[5] = NewCustomStockings5.texture;
			}
			this.MyStockings = this.CustomStockings[5];
		}
		else if (this.Stockings == "Custom6")
		{
			WWW NewCustomStockings6 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings6.png");
			yield return NewCustomStockings6;
			if (NewCustomStockings6.error == null)
			{
				this.CustomStockings[6] = NewCustomStockings6.texture;
			}
			this.MyStockings = this.CustomStockings[6];
		}
		else if (this.Stockings == "Custom7")
		{
			WWW NewCustomStockings7 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings7.png");
			yield return NewCustomStockings7;
			if (NewCustomStockings7.error == null)
			{
				this.CustomStockings[7] = NewCustomStockings7.texture;
			}
			this.MyStockings = this.CustomStockings[7];
		}
		else if (this.Stockings == "Custom8")
		{
			WWW NewCustomStockings8 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings8.png");
			yield return NewCustomStockings8;
			if (NewCustomStockings8.error == null)
			{
				this.CustomStockings[8] = NewCustomStockings8.texture;
			}
			this.MyStockings = this.CustomStockings[8];
		}
		else if (this.Stockings == "Custom9")
		{
			WWW NewCustomStockings9 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings9.png");
			yield return NewCustomStockings9;
			if (NewCustomStockings9.error == null)
			{
				this.CustomStockings[9] = NewCustomStockings9.texture;
			}
			this.MyStockings = this.CustomStockings[9];
		}
		else if (this.Stockings == "Custom10")
		{
			WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings10.png");
			yield return NewCustomStockings10;
			if (NewCustomStockings10.error == null)
			{
				this.CustomStockings[10] = NewCustomStockings10.texture;
			}
			this.MyStockings = this.CustomStockings[10];
		}
		else if (this.Stockings == "Loose")
		{
			this.MyStockings = null;
			this.RightStockings[0].SetActive(true);
			this.LeftStockings[0].SetActive(true);
		}
		if (this.MyStockings != null)
		{
			this.MyRenderer.materials[0].SetTexture("_OverlayTex", this.MyStockings);
			this.MyRenderer.materials[1].SetTexture("_OverlayTex", this.MyStockings);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			this.MyRenderer.materials[0].SetTexture("_OverlayTex", null);
			this.MyRenderer.materials[1].SetTexture("_OverlayTex", null);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		yield break;
	}

	public void WearOutdoorShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
		}
		else
		{
			this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
		}
	}
}
