﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosmeticScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TextureManagerScript TextureManager;

	public SkinnedMeshUpdater SkinUpdater;

	public LoveManagerScript LoveManager;

	public ModelSwapScript ModelSwap;

	public StudentScript Student;

	public JsonScript JSON;

	public GameObject[] TeacherAccessories;

	public GameObject[] FemaleAccessories;

	public GameObject[] MaleAccessories;

	public GameObject[] ClubAccessories;

	public GameObject[] RightStockings;

	public GameObject[] LeftStockings;

	public GameObject[] PhoneCharms;

	public GameObject[] TeacherHair;

	public GameObject[] FacialHair;

	public GameObject[] FemaleHair;

	public GameObject[] MaleHair;

	public GameObject[] Eyewear;

	public Renderer[] TeacherHairRenderers;

	public Renderer[] FacialHairRenderers;

	public Renderer[] FemaleHairRenderers;

	public Renderer[] MaleHairRenderers;

	public Renderer[] Fingernails;

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

	public Texture[] SmartphoneTextures;

	public Texture[] HoodieTextures;

	public Texture[] FaceTextures;

	public Texture[] SkinTextures;

	public Texture[] WristwearTextures;

	public Texture[] CardiganTextures;

	public Texture[] BookbagTextures;

	public Texture[] EyeTextures;

	public Texture[] CheekTextures;

	public Texture[] ForeheadTextures;

	public Texture[] MouthTextures;

	public Texture[] NoseTextures;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Color[] BullyColor;

	public SkinnedMeshRenderer CardiganRenderer;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer FacialHairRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Renderer HoodieRenderer;

	public Renderer HairRenderer;

	public Mesh DelinquentMesh;

	public Mesh SchoolUniform;

	public Texture DefaultFaceTexture;

	public Texture TeacherBodyTexture;

	public Texture CoachPaleBodyTexture;

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

	public Texture BlackKneeSocks;

	public Texture GreenSocks;

	public Texture KizanaStockings;

	public Texture OsanaStockings;

	public Texture TurtleStockings;

	public Texture TigerStockings;

	public Texture BirdStockings;

	public Texture DragonStockings;

	public Texture[] CustomStockings;

	public Texture MyStockings;

	public Texture BlackBody;

	public Texture BlackFace;

	public Texture DelinquentUniformTexture;

	public Texture DelinquentCasualTexture;

	public Texture DelinquentSocksTexture;

	public GameObject RightIrisLight;

	public GameObject LeftIrisLight;

	public GameObject RightWristband;

	public GameObject LeftWristband;

	public GameObject Cardigan;

	public GameObject Bookbag;

	public GameObject Character;

	public GameObject RightShoe;

	public GameObject LeftShoe;

	public GameObject Armband;

	public GameObject Hoodie;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Color CorrectColor;

	public Color ColorValue;

	public Mesh TeacherMesh;

	public Mesh CoachMesh;

	public Mesh NurseMesh;

	public bool TakingPortrait;

	public bool Initialized;

	public bool CustomEyes;

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

	public string EyeType = string.Empty;

	public int FacialHairstyle;

	public int Accessory;

	public int Hairstyle;

	public int SkinColor;

	public int StudentID;

	public ClubType Club;

	public int ID;

	public GameObject[] GaloAccessories;

	public Material[] NurseMaterials;

	public GameObject CardiganPrefab;

	public int FaceID;

	public int SkinID;

	public int UniformID;

	public void Start()
	{
		if (this.StudentID == 34)
		{
			this.StudentID = 35;
		}
		if (this.Kidnapped)
		{
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
			this.Accessory = int.Parse(this.JSON.Students[this.StudentID].Accessory);
			this.Hairstyle = int.Parse(this.JSON.Students[this.StudentID].Hairstyle);
			this.Stockings = this.JSON.Students[this.StudentID].Stockings;
			this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
			this.EyeType = this.JSON.Students[this.StudentID].EyeType;
			this.HairColor = this.JSON.Students[this.StudentID].Color;
			this.EyeColor = this.JSON.Students[this.StudentID].Eyes;
			this.Club = this.JSON.Students[this.StudentID].Club;
			text = this.JSON.Students[this.StudentID].Name;
			if (this.Yandere)
			{
				this.Accessory = 0;
				this.Hairstyle = 1;
				this.Stockings = "Black";
				this.BreastSize = 1f;
				this.HairColor = "White";
				this.EyeColor = "Black";
				this.Club = ClubType.None;
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
				this.JSON.Students[this.StudentID].Name = text;
				this.Student.Name = text;
			}
			else
			{
				text = this.StudentManager.MaleNames[UnityEngine.Random.Range(0, this.StudentManager.MaleNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.Students[this.StudentID].Name = text;
				this.Student.Name = text;
			}
			if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == this.StudentID)
			{
				this.JSON.Students[this.StudentID].Name = MissionModeGlobals.MissionTargetName;
				this.Student.Name = MissionModeGlobals.MissionTargetName;
				text = MissionModeGlobals.MissionTargetName;
			}
		}
		if (this.Randomize)
		{
			this.Teacher = false;
			this.BreastSize = UnityEngine.Random.Range(0.5f, 2f);
			this.Accessory = 0;
			this.Club = ClubType.None;
			if (!this.Male)
			{
				this.Hairstyle = 1;
				while (this.Hairstyle == 1 || this.Hairstyle == 20 || this.Hairstyle == 21)
				{
					this.Hairstyle = UnityEngine.Random.Range(1, this.FemaleHair.Length);
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
			foreach (GameObject gameObject in this.PhoneCharms)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.RightWristband.SetActive(false);
			this.LeftWristband.SetActive(false);
			if (this.Club == ClubType.Bully)
			{
				if (!this.Kidnapped)
				{
					this.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.SmartphoneTextures[this.StudentID];
					this.Student.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
					this.Student.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
				}
				this.RightWristband.GetComponent<Renderer>().material.mainTexture = this.WristwearTextures[this.StudentID];
				this.LeftWristband.GetComponent<Renderer>().material.mainTexture = this.WristwearTextures[this.StudentID];
				this.Bookbag.GetComponent<Renderer>().material.mainTexture = this.BookbagTextures[this.StudentID];
				this.HoodieRenderer.material.mainTexture = this.HoodieTextures[this.StudentID];
				if (this.PhoneCharms.Length > 0)
				{
					this.PhoneCharms[this.StudentID].SetActive(true);
				}
				if (StudentGlobals.FemaleUniform < 2 || StudentGlobals.FemaleUniform == 3)
				{
					this.RightWristband.SetActive(true);
					this.LeftWristband.SetActive(true);
				}
				this.Bookbag.SetActive(true);
				this.Hoodie.SetActive(true);
				for (int j = 0; j < 10; j++)
				{
					this.Fingernails[j].material.color = this.BullyColor[this.StudentID];
				}
			}
			else
			{
				for (int k = 0; k < 10; k++)
				{
					this.Fingernails[k].gameObject.SetActive(false);
				}
			}
			if (!this.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
			{
				if (this.StudentID == 32)
				{
					this.Character.GetComponent<Animation>().Play("f02_shy_00");
					this.Character.GetComponent<Animation>().Play("f02_shy_00");
					this.Character.GetComponent<Animation>()["f02_shy_00"].time = 1f;
				}
				else if (this.StudentID == 59)
				{
					this.Character.GetComponent<Animation>().Play("f02_idleGraceful_00");
				}
				else if (this.StudentID == 60)
				{
					this.Character.GetComponent<Animation>().Play("f02_idleScholarly_00");
				}
				else if (this.StudentID == 81)
				{
					this.Character.GetComponent<Animation>().Play("f02_socialCameraPose_00");
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
				}
				else if (this.StudentID == 82)
				{
					this.Character.GetComponent<Animation>().Play("f02_galPose_01");
				}
				else if (this.StudentID == 83)
				{
					this.Character.GetComponent<Animation>().Play("f02_galPose_02");
				}
				else if (this.StudentID == 84)
				{
					this.Character.GetComponent<Animation>().Play("f02_galPose_03");
				}
				else if (this.StudentID == 85)
				{
					this.Character.GetComponent<Animation>().Play("f02_galPose_04");
				}
			}
		}
		else
		{
			foreach (GameObject gameObject2 in this.GaloAccessories)
			{
				gameObject2.SetActive(false);
			}
			if (this.Club == ClubType.Occult)
			{
				this.Character.GetComponent<Animation>()["sadFace_00"].layer = 1;
				this.Character.GetComponent<Animation>().Play("sadFace_00");
				this.Character.GetComponent<Animation>()["sadFace_00"].weight = 1f;
			}
			if (this.StudentID == 13 && StudentGlobals.CustomSuitor)
			{
				if (StudentGlobals.CustomSuitorHair > 0)
				{
					this.Hairstyle = StudentGlobals.CustomSuitorHair;
				}
				if (StudentGlobals.CustomSuitorAccessory > 0)
				{
					this.Accessory = StudentGlobals.CustomSuitorAccessory;
					if (this.Accessory == 1)
					{
						Transform transform = this.MaleAccessories[1].transform;
						transform.localScale = new Vector3(1.02f, transform.localScale.y, 1.062f);
					}
				}
				if (StudentGlobals.CustomSuitorBlonde > 0)
				{
					this.HairColor = "Yellow";
				}
				if (StudentGlobals.CustomSuitorJewelry > 0)
				{
					foreach (GameObject gameObject3 in this.GaloAccessories)
					{
						gameObject3.SetActive(true);
					}
				}
			}
			if (SceneManager.GetActiveScene().name == "PortraitScene")
			{
				if (this.StudentID == 56)
				{
					this.Character.GetComponent<Animation>().Play("idleConfident_00");
				}
				else if (this.StudentID == 57)
				{
					this.Character.GetComponent<Animation>().Play("idleChill_01");
				}
				else if (this.StudentID == 58)
				{
					this.Character.GetComponent<Animation>().Play("idleChill_00");
				}
				else if (this.StudentID == 76)
				{
					this.Character.GetComponent<Animation>().Play("delinquentPoseB");
				}
				else if (this.StudentID == 77)
				{
					this.Character.GetComponent<Animation>().Play("delinquentPoseA");
				}
				else if (this.StudentID == 78)
				{
					this.Character.GetComponent<Animation>().Play("delinquentPoseC");
				}
				else if (this.StudentID == 79)
				{
					this.Character.GetComponent<Animation>().Play("delinquentPoseD");
				}
				else if (this.StudentID == 80)
				{
					this.Character.GetComponent<Animation>().Play("delinquentPoseE");
				}
			}
		}
		if (this.Club == ClubType.Teacher)
		{
			this.MyRenderer.sharedMesh = this.TeacherMesh;
			this.Teacher = true;
		}
		else if (this.Club == ClubType.GymTeacher)
		{
			if (!StudentGlobals.GetStudentReplaced(this.StudentID))
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
		else if (this.Club == ClubType.Nurse)
		{
			this.MyRenderer.sharedMesh = this.NurseMesh;
			this.Teacher = true;
		}
		else if (this.Club == ClubType.Council)
		{
			this.Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-0.64375f, 0f));
			this.Armband.SetActive(true);
			string str = string.Empty;
			if (this.StudentID == 86)
			{
				str = "Strict";
			}
			if (this.StudentID == 87)
			{
				str = "Casual";
			}
			if (this.StudentID == 88)
			{
				str = "Grace";
			}
			if (this.StudentID == 89)
			{
				str = "Edgy";
			}
			this.Character.GetComponent<Animation>()["f02_faceCouncil" + str + "_00"].layer = 1;
			this.Character.GetComponent<Animation>().Play("f02_faceCouncil" + str + "_00");
			this.Character.GetComponent<Animation>()["f02_idleCouncil" + str + "_00"].time = 1f;
			this.Character.GetComponent<Animation>().Play("f02_idleCouncil" + str + "_00");
		}
		if (this.TakingPortrait && (this.StudentID == 21 || this.StudentID == 26))
		{
			this.Armband.SetActive(true);
		}
		foreach (GameObject gameObject4 in this.FemaleAccessories)
		{
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
		}
		foreach (GameObject gameObject5 in this.MaleAccessories)
		{
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
		}
		foreach (GameObject gameObject6 in this.ClubAccessories)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		foreach (GameObject gameObject7 in this.TeacherAccessories)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		foreach (GameObject gameObject8 in this.TeacherHair)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		foreach (GameObject gameObject9 in this.FemaleHair)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		foreach (GameObject gameObject10 in this.MaleHair)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		foreach (GameObject gameObject11 in this.FacialHair)
		{
			if (gameObject11 != null)
			{
				gameObject11.SetActive(false);
			}
		}
		foreach (GameObject gameObject12 in this.Eyewear)
		{
			if (gameObject12 != null)
			{
				gameObject12.SetActive(false);
			}
		}
		foreach (GameObject gameObject13 in this.RightStockings)
		{
			if (gameObject13 != null)
			{
				gameObject13.SetActive(false);
			}
		}
		foreach (GameObject gameObject14 in this.LeftStockings)
		{
			if (gameObject14 != null)
			{
				gameObject14.SetActive(false);
			}
		}
		if (this.StudentID == 13 && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
		{
			this.Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(true);
		}
		if (this.StudentID == 1 && SenpaiGlobals.CustomSenpai)
		{
			if (SenpaiGlobals.SenpaiEyeWear > 0)
			{
				this.Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(true);
			}
			this.FacialHairstyle = SenpaiGlobals.SenpaiFacialHair;
			this.HairColor = SenpaiGlobals.SenpaiHairColor;
			this.EyeColor = SenpaiGlobals.SenpaiEyeColor;
			this.Hairstyle = SenpaiGlobals.SenpaiHairStyle;
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
				if (this.Club == ClubType.Teacher)
				{
					this.MyRenderer.materials[0].mainTexture = this.TeacherBodyTexture;
					this.MyRenderer.materials[1].mainTexture = this.DefaultFaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.TeacherBodyTexture;
				}
				else if (this.Club == ClubType.GymTeacher)
				{
					if (StudentGlobals.GetStudentReplaced(this.StudentID))
					{
						this.MyRenderer.materials[0].mainTexture = this.DefaultFaceTexture;
						this.MyRenderer.materials[1].mainTexture = this.CoachPaleBodyTexture;
						this.MyRenderer.materials[2].mainTexture = this.CoachPaleBodyTexture;
					}
					else
					{
						this.MyRenderer.materials[0].mainTexture = this.CoachFaceTexture;
						this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
						this.MyRenderer.materials[2].mainTexture = this.CoachBodyTexture;
					}
				}
				else if (this.Club == ClubType.Nurse)
				{
					this.MyRenderer.materials = this.NurseMaterials;
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
		if (this.Club < ClubType.Gaming && this.ClubAccessories[(int)this.Club] != null && !ClubGlobals.GetClubClosed(this.Club) && this.StudentID != 26)
		{
			this.ClubAccessories[(int)this.Club].SetActive(true);
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
			if (!this.CustomHair)
			{
				if (this.Hairstyle > 0)
				{
					if (GameGlobals.LoveSick)
					{
						this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
					}
					else
					{
						this.HairRenderer.material.color = this.ColorValue;
					}
				}
			}
			else if (GameGlobals.LoveSick)
			{
				this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
			}
			if (!this.Male)
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
				else if (StudentGlobals.MaleUniform == 1)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (StudentGlobals.MaleUniform < 4)
				{
					this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				}
			}
		}
		else if (this.Teacher && StudentGlobals.GetStudentReplaced(this.StudentID))
		{
			Color studentColor = StudentGlobals.GetStudentColor(this.StudentID);
			Color studentEyeColor = StudentGlobals.GetStudentEyeColor(this.StudentID);
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
		if (this.StudentID > 1 && this.StudentID < 8)
		{
			this.FemaleAccessories[6].SetActive(true);
			if ((float)StudentGlobals.GetStudentReputation(this.StudentID) < -33.33333f)
			{
				this.FemaleAccessories[6].SetActive(false);
			}
		}
		if (this.StudentID == 17)
		{
			if (SchemeGlobals.GetSchemeStage(2) == 2)
			{
				this.FemaleAccessories[3].SetActive(false);
			}
		}
		else if (this.StudentID == 20)
		{
			if (base.transform.position != Vector3.zero)
			{
				this.RightEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
				this.LeftEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
				this.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
				this.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
			}
		}
		else if (this.StudentID == 59)
		{
			this.ClubAccessories[7].transform.localPosition = new Vector3(0f, -1.04f, 0.5f);
			this.ClubAccessories[7].transform.localEulerAngles = new Vector3(-22.5f, 0f, 0f);
		}
		else if (this.StudentID == 60)
		{
			this.FemaleAccessories[13].SetActive(true);
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
		this.EyeTypeCheck();
		if (this.Kidnapped)
		{
			this.WearIndoorShoes();
		}
	}

	public void SetMaleUniform()
	{
		if (this.StudentID == 1)
		{
			this.SkinColor = SenpaiGlobals.SenpaiSkinColor;
			this.FaceTexture = this.FaceTextures[this.SkinColor];
		}
		else
		{
			this.FaceTexture = ((!this.CustomHair) ? this.FaceTextures[this.SkinColor] : this.HairRenderer.material.mainTexture);
			if (this.StudentID == 13 && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorTan)
			{
				this.SkinColor = 6;
				this.FaceTexture = this.FaceTextures[6];
			}
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[StudentGlobals.MaleUniform];
		this.SchoolUniform = this.MaleUniforms[StudentGlobals.MaleUniform];
		this.UniformTexture = this.MaleUniformTextures[StudentGlobals.MaleUniform];
		this.CasualTexture = this.MaleCasualTextures[StudentGlobals.MaleUniform];
		this.SocksTexture = this.MaleSocksTextures[StudentGlobals.MaleUniform];
		if (StudentGlobals.MaleUniform == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (StudentGlobals.MaleUniform == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (StudentGlobals.MaleUniform == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (StudentGlobals.MaleUniform == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (StudentGlobals.MaleUniform == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (StudentGlobals.MaleUniform == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		if (StudentGlobals.MaleUniform < 2 && this.Club == ClubType.Delinquent)
		{
			this.MyRenderer.sharedMesh = this.DelinquentMesh;
			if (this.StudentID == 76)
			{
				this.UniformTexture = this.EyeTextures[0];
				this.CasualTexture = this.EyeTextures[1];
				this.SocksTexture = this.EyeTextures[2];
			}
			else if (this.StudentID == 77)
			{
				this.UniformTexture = this.CheekTextures[0];
				this.CasualTexture = this.CheekTextures[1];
				this.SocksTexture = this.CheekTextures[2];
			}
			else if (this.StudentID == 78)
			{
				this.UniformTexture = this.ForeheadTextures[0];
				this.CasualTexture = this.ForeheadTextures[1];
				this.SocksTexture = this.ForeheadTextures[2];
			}
			else if (this.StudentID == 79)
			{
				this.UniformTexture = this.MouthTextures[0];
				this.CasualTexture = this.MouthTextures[1];
				this.SocksTexture = this.MouthTextures[2];
			}
			else if (this.StudentID == 80)
			{
				this.UniformTexture = this.NoseTextures[0];
				this.CasualTexture = this.NoseTextures[1];
				this.SocksTexture = this.NoseTextures[2];
			}
		}
		if (this.StudentID == 58)
		{
			this.SkinColor = 4;
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
		if (this.Club != ClubType.Council)
		{
			this.MyRenderer.sharedMesh = this.FemaleUniforms[StudentGlobals.FemaleUniform];
			this.SchoolUniform = this.FemaleUniforms[StudentGlobals.FemaleUniform];
			if (this.StudentID == 26)
			{
				this.UniformTexture = this.OccultUniformTextures[StudentGlobals.FemaleUniform];
				this.CasualTexture = this.OccultCasualTextures[StudentGlobals.FemaleUniform];
				this.SocksTexture = this.OccultSocksTextures[StudentGlobals.FemaleUniform];
			}
			else if (this.Club == ClubType.Bully)
			{
				this.UniformTexture = this.GanguroUniformTextures[StudentGlobals.FemaleUniform];
				this.CasualTexture = this.GanguroCasualTextures[StudentGlobals.FemaleUniform];
				this.SocksTexture = this.GanguroSocksTextures[StudentGlobals.FemaleUniform];
			}
			else if (this.StudentID == 35)
			{
				this.UniformTexture = this.BlackBody;
				this.CasualTexture = this.BlackBody;
				this.SocksTexture = this.BlackBody;
			}
			else
			{
				this.UniformTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
				this.CasualTexture = this.FemaleCasualTextures[StudentGlobals.FemaleUniform];
				this.SocksTexture = this.FemaleSocksTextures[StudentGlobals.FemaleUniform];
			}
		}
		else
		{
			this.RightIrisLight.SetActive(false);
			this.LeftIrisLight.SetActive(false);
			this.MyRenderer.sharedMesh = this.FemaleUniforms[4];
			this.SchoolUniform = this.FemaleUniforms[4];
			this.UniformTexture = this.FemaleUniformTextures[7];
			this.CasualTexture = this.FemaleCasualTextures[7];
			this.SocksTexture = this.FemaleSocksTextures[7];
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
			this.UniformTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
			this.FaceTexture = this.DefaultFaceTexture;
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
		}
		if (this.Club == ClubType.Bully)
		{
		}
		if (this.StudentID == 35)
		{
			this.FaceTexture = this.BlackFace;
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
			if (TaskGlobals.GetTaskStatus(15) < 3)
			{
				if (!this.TakingPortrait)
				{
					this.MaleAccessories[1].SetActive(false);
				}
				else
				{
					this.MaleAccessories[1].SetActive(true);
				}
			}
		}
		else if (this.StudentID == 33 && this.PhoneCharms.Length > 0)
		{
			if (TaskGlobals.GetTaskStatus(33) < 3)
			{
				this.PhoneCharms[33].SetActive(false);
			}
			else
			{
				this.PhoneCharms[33].SetActive(true);
			}
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
			if (this.Hairstyle == 28)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			if (this.Accessory > 1)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			if (this.Student.Persona == PersonaType.TeachersPet)
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
		else if (this.Stockings == "ShortGreen")
		{
			this.MyStockings = this.GreenSocks;
		}
		else if (this.Stockings == "ShortBlack")
		{
			this.MyStockings = this.BlackKneeSocks;
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
		else if (this.Stockings == "Council1")
		{
			this.MyStockings = this.TurtleStockings;
		}
		else if (this.Stockings == "Council2")
		{
			this.MyStockings = this.TigerStockings;
		}
		else if (this.Stockings == "Council3")
		{
			this.MyStockings = this.BirdStockings;
		}
		else if (this.Stockings == "Council4")
		{
			this.MyStockings = this.DragonStockings;
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
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
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

	public void WearIndoorShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
			this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
		}
		else
		{
			this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
		}
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

	public void EyeTypeCheck()
	{
		if (StudentGlobals.FemaleUniform != 1 || this.EyeType == "Gentle")
		{
		}
	}
}
