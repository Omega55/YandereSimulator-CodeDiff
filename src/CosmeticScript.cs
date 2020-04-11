﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosmeticScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TextureManagerScript TextureManager;

	public SkinnedMeshUpdater SkinUpdater;

	public LoveManagerScript LoveManager;

	public Animation CharacterAnimation;

	public ModelSwapScript ModelSwap;

	public StudentScript Student;

	public JsonScript JSON;

	public GameObject[] TeacherAccessories;

	public GameObject[] FemaleAccessories;

	public GameObject[] MaleAccessories;

	public GameObject[] ClubAccessories;

	public GameObject[] PunkAccessories;

	public GameObject[] RightStockings;

	public GameObject[] LeftStockings;

	public GameObject[] PhoneCharms;

	public GameObject[] TeacherHair;

	public GameObject[] FacialHair;

	public GameObject[] FemaleHair;

	public GameObject[] MusicNotes;

	public GameObject[] Kerchiefs;

	public GameObject[] CatGifts;

	public GameObject[] MaleHair;

	public GameObject[] RedCloth;

	public GameObject[] Scanners;

	public GameObject[] Eyewear;

	public GameObject[] Goggles;

	public GameObject[] Flowers;

	public GameObject[] Roses;

	public Renderer[] TeacherHairRenderers;

	public Renderer[] FacialHairRenderers;

	public Renderer[] FemaleHairRenderers;

	public Renderer[] MaleHairRenderers;

	public Renderer[] Fingernails;

	public Texture[] GanguroSwimsuitTextures;

	public Texture[] GanguroUniformTextures;

	public Texture[] GanguroCasualTextures;

	public Texture[] GanguroSocksTextures;

	public Texture[] ObstacleUniformTextures;

	public Texture[] ObstacleCasualTextures;

	public Texture[] ObstacleSocksTextures;

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

	public Texture[] ApronTextures;

	public Texture[] CanTextures;

	public Texture[] Trunks;

	public Texture[] MusicStockings;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Mesh[] Berets;

	public Color[] BullyColor;

	public SkinnedMeshRenderer CardiganRenderer;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer FacialHairRenderer;

	public Renderer RightEyeRenderer;

	public Renderer LeftEyeRenderer;

	public Renderer HoodieRenderer;

	public Renderer ScarfRenderer;

	public Renderer HairRenderer;

	public Renderer CanRenderer;

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

	public Texture GrayFace;

	public Texture DelinquentUniformTexture;

	public Texture DelinquentCasualTexture;

	public Texture DelinquentSocksTexture;

	public Texture OsanaSwimsuitTexture;

	public Texture ObstacleSwimsuitTexture;

	public Texture ObstacleTowelTexture;

	public Texture ObstacleGymTexture;

	public Texture TanSwimsuitTexture;

	public Texture TanTowelTexture;

	public Texture TanGymTexture;

	public GameObject RightIrisLight;

	public GameObject LeftIrisLight;

	public GameObject RightWristband;

	public GameObject LeftWristband;

	public GameObject Cardigan;

	public GameObject Bookbag;

	public GameObject ThickBrows;

	public GameObject Character;

	public GameObject RightShoe;

	public GameObject LeftShoe;

	public GameObject SadBrows;

	public GameObject Armband;

	public GameObject Hoodie;

	public GameObject Tongue;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform RightTemple;

	public Transform LeftTemple;

	public Transform Head;

	public Transform Neck;

	public Color CorrectColor;

	public Color ColorValue;

	public Mesh TeacherMesh;

	public Mesh CoachMesh;

	public Mesh NurseMesh;

	public bool MysteriousObstacle;

	public bool DoNotChangeFace;

	public bool TakingPortrait;

	public bool Initialized;

	public bool CustomEyes;

	public bool CustomHair;

	public bool LookCamera;

	public bool HomeScene;

	public bool Kidnapped;

	public bool Randomize;

	public bool Cutscene;

	public bool Modified;

	public bool TurnedOn;

	public bool Teacher;

	public bool Yandere;

	public bool Empty;

	public bool Male;

	public float BreastSize;

	public string OriginalStockings = string.Empty;

	public string HairColor = string.Empty;

	public string Stockings = string.Empty;

	public string EyeColor = string.Empty;

	public string EyeType = string.Empty;

	public string Name = string.Empty;

	public int FacialHairstyle;

	public int Accessory;

	public int Direction;

	public int Hairstyle;

	public int SkinColor;

	public int StudentID;

	public int EyewearID;

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
		bool kidnapped = this.Kidnapped;
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
		string name = string.Empty;
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
			this.Name = this.JSON.Students[this.StudentID].Name;
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
		if (this.StudentID == 36)
		{
			if (TaskGlobals.GetTaskStatus(36) < 3)
			{
				this.FacialHairstyle = 12;
				this.EyewearID = 8;
			}
			else
			{
				this.FacialHairstyle = 0;
				this.EyewearID = 9;
				this.Hairstyle = 49;
				this.Accessory = 0;
			}
		}
		if (this.StudentID == 51 && ClubGlobals.GetClubClosed(ClubType.LightMusic))
		{
			this.Hairstyle = 51;
		}
		if (GameGlobals.EmptyDemon && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
		{
			if (!this.Male)
			{
				this.Hairstyle = 52;
			}
			else
			{
				this.Hairstyle = 53;
			}
			this.FacialHairstyle = 0;
			this.EyewearID = 0;
			this.Accessory = 0;
			this.Stockings = "";
			this.BreastSize = 1f;
			this.Empty = true;
		}
		if (this.Name == "Random")
		{
			this.Randomize = true;
			if (!this.Male)
			{
				name = this.StudentManager.FirstNames[Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.Students[this.StudentID].Name = name;
				this.Student.Name = name;
			}
			else
			{
				name = this.StudentManager.MaleNames[Random.Range(0, this.StudentManager.MaleNames.Length)] + " " + this.StudentManager.LastNames[Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.Students[this.StudentID].Name = name;
				this.Student.Name = name;
			}
			if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == this.StudentID)
			{
				this.JSON.Students[this.StudentID].Name = MissionModeGlobals.MissionTargetName;
				this.Student.Name = MissionModeGlobals.MissionTargetName;
				name = MissionModeGlobals.MissionTargetName;
			}
		}
		if (this.Randomize)
		{
			this.Teacher = false;
			this.BreastSize = Random.Range(0.5f, 2f);
			this.Accessory = 0;
			this.Club = ClubType.None;
			if (!this.Male)
			{
				this.Hairstyle = 1;
				while (this.Hairstyle == 1 || this.Hairstyle == 20 || this.Hairstyle == 21)
				{
					this.Hairstyle = Random.Range(1, this.FemaleHair.Length);
				}
			}
			else
			{
				this.SkinColor = Random.Range(0, this.SkinTextures.Length);
				this.Hairstyle = Random.Range(1, this.MaleHair.Length);
			}
		}
		if (!this.Male)
		{
			if (this.Hairstyle == 20 || this.Hairstyle == 21)
			{
				if (this.Direction == 1)
				{
					this.Hairstyle = 22;
				}
				else
				{
					this.Hairstyle = 19;
				}
			}
			this.ThickBrows.SetActive(false);
			if (!this.TakingPortrait)
			{
				this.Tongue.SetActive(false);
			}
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
			if (this.StudentID == 51)
			{
				this.RightTemple.name = "RENAMED";
				this.LeftTemple.name = "RENAMED";
				this.RightTemple.localScale = new Vector3(0f, 1f, 1f);
				this.LeftTemple.localScale = new Vector3(0f, 1f, 1f);
				if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
				{
					this.SadBrows.SetActive(true);
				}
				else
				{
					this.ThickBrows.SetActive(true);
				}
			}
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
				if (this.PhoneCharms.Length != 0)
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
				this.Student.GymTexture = this.TanGymTexture;
				this.Student.TowelTexture = this.TanTowelTexture;
			}
			else
			{
				for (int k = 0; k < 10; k++)
				{
					this.Fingernails[k].gameObject.SetActive(false);
				}
				if (this.Club == ClubType.Gardening && !this.TakingPortrait && !this.Kidnapped)
				{
					this.CanRenderer.material.mainTexture = this.CanTextures[this.StudentID];
				}
			}
			if (!this.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
			{
				if (this.StudentID == 2)
				{
					this.CharacterAnimation.Play("succubus_a_idle_twins_01");
					base.transform.position = new Vector3(0.094f, 0f, 0f);
					this.LookCamera = true;
					this.CharacterAnimation["f02_smile_00"].layer = 1;
					this.CharacterAnimation.Play("f02_smile_00");
					this.CharacterAnimation["f02_smile_00"].weight = 1f;
				}
				else if (this.StudentID == 3)
				{
					this.CharacterAnimation.Play("succubus_b_idle_twins_01");
					base.transform.position = new Vector3(-0.332f, 0f, 0f);
					this.LookCamera = true;
					this.CharacterAnimation["f02_smile_00"].layer = 1;
					this.CharacterAnimation.Play("f02_smile_00");
					this.CharacterAnimation["f02_smile_00"].weight = 1f;
				}
				else if (this.StudentID == 4)
				{
					this.CharacterAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					this.LookCamera = true;
				}
				else if (this.StudentID == 5)
				{
					this.CharacterAnimation.Play("f02_shy_00");
					this.CharacterAnimation.Play("f02_shy_00");
					this.CharacterAnimation["f02_shy_00"].time = 1f;
				}
				else if (this.StudentID == 10)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
				}
				else if (this.StudentID == 24)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 1f;
				}
				else if (this.StudentID == 25)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
				}
				else if (this.StudentID == 30)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
				}
				else if (this.StudentID == 34)
				{
					this.CharacterAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					this.LookCamera = true;
				}
				else if (this.StudentID == 35)
				{
					this.CharacterAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					this.LookCamera = true;
				}
				else if (this.StudentID == 38)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
				}
				else if (this.StudentID == 39)
				{
					this.CharacterAnimation.Play("f02_socialCameraPose_00");
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
				}
				else if (this.StudentID == 40)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 1f;
				}
				else if (this.StudentID == 51)
				{
					this.CharacterAnimation.Play("f02_musicPose_00");
					this.Tongue.SetActive(true);
				}
				else if (this.StudentID == 59)
				{
					this.CharacterAnimation.Play("f02_sleuthPortrait_00");
				}
				else if (this.StudentID == 60)
				{
					this.CharacterAnimation.Play("f02_sleuthPortrait_01");
				}
				else if (this.StudentID == 64)
				{
					this.CharacterAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					this.LookCamera = true;
				}
				else if (this.StudentID == 65)
				{
					this.CharacterAnimation.Play("f02_idleShort_00");
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					this.LookCamera = true;
				}
				else if (this.StudentID == 71)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
				}
				else if (this.StudentID == 72)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 0.66666f;
				}
				else if (this.StudentID == 73)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 1.33332f;
				}
				else if (this.StudentID == 74)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 1.99998f;
				}
				else if (this.StudentID == 75)
				{
					this.CharacterAnimation.Play("f02_idleGirly_00");
					this.CharacterAnimation["f02_idleGirly_00"].time = 2.66664f;
				}
				else if (this.StudentID == 81)
				{
					this.CharacterAnimation.Play("f02_socialCameraPose_00");
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
				}
				else if (this.StudentID == 82 || this.StudentID == 52)
				{
					this.CharacterAnimation.Play("f02_galPose_01");
				}
				else if (this.StudentID == 83 || this.StudentID == 53)
				{
					this.CharacterAnimation.Play("f02_galPose_02");
				}
				else if (this.StudentID == 84 || this.StudentID == 54)
				{
					this.CharacterAnimation.Play("f02_galPose_03");
				}
				else if (this.StudentID == 85 || this.StudentID == 55)
				{
					this.CharacterAnimation.Play("f02_galPose_04");
				}
				else if (this.Club != ClubType.Council)
				{
					this.CharacterAnimation.Play("f02_idleShort_01");
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					this.LookCamera = true;
				}
			}
		}
		else
		{
			this.ThickBrows.SetActive(false);
			GameObject[] array = this.GaloAccessories;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(false);
			}
			if (this.Club == ClubType.Occult)
			{
				this.CharacterAnimation["sadFace_00"].layer = 1;
				this.CharacterAnimation.Play("sadFace_00");
				this.CharacterAnimation["sadFace_00"].weight = 1f;
			}
			bool flag = false;
			if (this.StudentID == 28)
			{
				flag = true;
			}
			if (flag && StudentGlobals.CustomSuitor)
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
						transform.localScale = new Vector3(1.066666f, 1f, 1f);
						transform.localPosition = new Vector3(0f, -1.525f, 0.0066666f);
					}
				}
				if (StudentGlobals.CustomSuitorBlack)
				{
					this.HairColor = "SolidBlack";
				}
				if (StudentGlobals.CustomSuitorJewelry > 0)
				{
					array = this.GaloAccessories;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SetActive(true);
					}
				}
			}
			if (this.StudentID == 36 || this.StudentID == 66)
			{
				this.CharacterAnimation["toughFace_00"].layer = 1;
				this.CharacterAnimation.Play("toughFace_00");
				this.CharacterAnimation["toughFace_00"].weight = 1f;
				if (this.StudentID == 66)
				{
					this.ThickBrows.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "PortraitScene")
			{
				if (this.StudentID == 26)
				{
					this.CharacterAnimation.Play("idleHaughty_00");
				}
				else if (this.StudentID == 36)
				{
					this.CharacterAnimation.Play("slouchIdle_00");
				}
				else if (this.StudentID == 56)
				{
					this.CharacterAnimation.Play("idleConfident_00");
				}
				else if (this.StudentID == 57)
				{
					this.CharacterAnimation.Play("sleuthPortrait_00");
				}
				else if (this.StudentID == 58)
				{
					this.CharacterAnimation.Play("sleuthPortrait_01");
				}
				else if (this.StudentID == 61)
				{
					this.CharacterAnimation.Play("scienceMad_00");
					base.transform.position = new Vector3(0f, 0.1f, 0f);
				}
				else if (this.StudentID == 62)
				{
					this.CharacterAnimation.Play("idleFrown_00");
				}
				else if (this.StudentID == 69)
				{
					this.CharacterAnimation.Play("idleFrown_00");
				}
				else if (this.StudentID == 76)
				{
					this.CharacterAnimation.Play("delinquentPoseB");
				}
				else if (this.StudentID == 77)
				{
					this.CharacterAnimation.Play("delinquentPoseA");
				}
				else if (this.StudentID == 78)
				{
					this.CharacterAnimation.Play("delinquentPoseC");
				}
				else if (this.StudentID == 79)
				{
					this.CharacterAnimation.Play("delinquentPoseD");
				}
				else if (this.StudentID == 80)
				{
					this.CharacterAnimation.Play("delinquentPoseE");
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
				this.CharacterAnimation["f02_smile_00"].layer = 1;
				this.CharacterAnimation.Play("f02_smile_00");
				this.CharacterAnimation["f02_smile_00"].weight = 1f;
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
			string str = "";
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
			this.CharacterAnimation["f02_faceCouncil" + str + "_00"].layer = 1;
			this.CharacterAnimation.Play("f02_faceCouncil" + str + "_00");
			this.CharacterAnimation["f02_idleCouncil" + str + "_00"].time = 1f;
			this.CharacterAnimation.Play("f02_idleCouncil" + str + "_00");
		}
		if (!ClubGlobals.GetClubClosed(this.Club) && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
		{
			this.Armband.SetActive(true);
			Renderer component = this.Armband.GetComponent<Renderer>();
			if (this.StudentID == 21)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(-0.63f, -0.22f));
			}
			else if (this.StudentID == 26)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.22f));
			}
			else if (this.StudentID == 31)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, 0.01f));
			}
			else if (this.StudentID == 36)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(-0.633333f, -0.44f));
			}
			else if (this.StudentID == 41)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(-0.62f, -0.66666f));
			}
			else if (this.StudentID == 46)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.66666f));
			}
			else if (this.StudentID == 51)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, 0.5566666f));
			}
			else if (this.StudentID == 56)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0.5533333f));
			}
			else if (this.StudentID == 61)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
			}
			else if (this.StudentID == 66)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, -0.22f));
			}
			else if (this.StudentID == 71)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.69f, 0.335f));
			}
		}
		foreach (GameObject gameObject2 in this.FemaleAccessories)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		foreach (GameObject gameObject3 in this.MaleAccessories)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
		}
		foreach (GameObject gameObject4 in this.ClubAccessories)
		{
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
		}
		foreach (GameObject gameObject5 in this.TeacherAccessories)
		{
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
		}
		foreach (GameObject gameObject6 in this.TeacherHair)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		foreach (GameObject gameObject7 in this.FemaleHair)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		foreach (GameObject gameObject8 in this.MaleHair)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		foreach (GameObject gameObject9 in this.FacialHair)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		foreach (GameObject gameObject10 in this.Eyewear)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		foreach (GameObject gameObject11 in this.RightStockings)
		{
			if (gameObject11 != null)
			{
				gameObject11.SetActive(false);
			}
		}
		foreach (GameObject gameObject12 in this.LeftStockings)
		{
			if (gameObject12 != null)
			{
				gameObject12.SetActive(false);
			}
		}
		foreach (GameObject gameObject13 in this.Scanners)
		{
			if (gameObject13 != null)
			{
				gameObject13.SetActive(false);
			}
		}
		foreach (GameObject gameObject14 in this.Flowers)
		{
			if (gameObject14 != null)
			{
				gameObject14.SetActive(false);
			}
		}
		foreach (GameObject gameObject15 in this.Roses)
		{
			if (gameObject15 != null)
			{
				gameObject15.SetActive(false);
			}
		}
		foreach (GameObject gameObject16 in this.Goggles)
		{
			if (gameObject16 != null)
			{
				gameObject16.SetActive(false);
			}
		}
		foreach (GameObject gameObject17 in this.RedCloth)
		{
			if (gameObject17 != null)
			{
				gameObject17.SetActive(false);
			}
		}
		foreach (GameObject gameObject18 in this.Kerchiefs)
		{
			if (gameObject18 != null)
			{
				gameObject18.SetActive(false);
			}
		}
		foreach (GameObject gameObject19 in this.CatGifts)
		{
			if (gameObject19 != null)
			{
				gameObject19.SetActive(false);
			}
		}
		foreach (GameObject gameObject20 in this.PunkAccessories)
		{
			if (gameObject20 != null)
			{
				gameObject20.SetActive(false);
			}
		}
		foreach (GameObject gameObject21 in this.MusicNotes)
		{
			if (gameObject21 != null)
			{
				gameObject21.SetActive(false);
			}
		}
		bool flag2 = false;
		if (this.StudentID == 28)
		{
			flag2 = true;
		}
		if (flag2 && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
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
					this.MyRenderer.materials[1].mainTexture = this.TeacherBodyTexture;
					this.MyRenderer.materials[2].mainTexture = this.DefaultFaceTexture;
					this.MyRenderer.materials[0].mainTexture = this.TeacherBodyTexture;
				}
				else if (this.Club == ClubType.GymTeacher)
				{
					if (StudentGlobals.GetStudentReplaced(this.StudentID))
					{
						this.MyRenderer.materials[2].mainTexture = this.DefaultFaceTexture;
						this.MyRenderer.materials[0].mainTexture = this.CoachPaleBodyTexture;
						this.MyRenderer.materials[1].mainTexture = this.CoachPaleBodyTexture;
					}
					else
					{
						this.MyRenderer.materials[2].mainTexture = this.CoachFaceTexture;
						this.MyRenderer.materials[0].mainTexture = this.CoachBodyTexture;
						this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
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
			if (this.EyewearID > 0)
			{
				this.Eyewear[this.EyewearID].SetActive(true);
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
		if (!this.Empty)
		{
			if (this.Club < ClubType.Gaming && this.ClubAccessories[(int)this.Club] != null && !ClubGlobals.GetClubClosed(this.Club) && this.StudentID != 26)
			{
				this.ClubAccessories[(int)this.Club].SetActive(true);
			}
			if (this.StudentID == 36)
			{
				this.ClubAccessories[(int)this.Club].SetActive(true);
			}
			if (this.Club == ClubType.Cooking)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.Kerchiefs[this.StudentID];
				if (!ClubGlobals.GetClubClosed(this.Club))
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
			else if (this.Club == ClubType.Drama)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.Roses[this.StudentID];
				if (!ClubGlobals.GetClubClosed(this.Club))
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
			else if (this.Club == ClubType.Art)
			{
				this.ClubAccessories[(int)this.Club].GetComponent<MeshFilter>().sharedMesh = this.Berets[this.StudentID];
			}
			else if (this.Club == ClubType.Science)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.Scanners[this.StudentID];
				if (!ClubGlobals.GetClubClosed(this.Club))
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
			else if (this.Club == ClubType.LightMusic)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.MusicNotes[this.StudentID - 50];
				if (!ClubGlobals.GetClubClosed(this.Club))
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
			else if (this.Club == ClubType.Sports)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.Goggles[this.StudentID];
				if (!ClubGlobals.GetClubClosed(this.Club))
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
			else if (this.Club == ClubType.Gardening)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.Flowers[this.StudentID];
				if (!ClubGlobals.GetClubClosed(this.Club))
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
			else if (this.Club == ClubType.Gaming)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
				this.ClubAccessories[(int)this.Club] = this.RedCloth[this.StudentID];
				if (!ClubGlobals.GetClubClosed(this.Club) && this.ClubAccessories[(int)this.Club] != null)
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
			}
		}
		if (this.StudentID == 36 && TaskGlobals.GetTaskStatus(36) == 3)
		{
			this.ClubAccessories[(int)this.Club].SetActive(false);
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
				if (this.StudentID > 90 && this.StudentID < 97)
				{
					this.CorrectColor.r = this.CorrectColor.r * 0.5f;
					this.CorrectColor.g = this.CorrectColor.g * 0.5f;
					this.CorrectColor.b = this.CorrectColor.b * 0.5f;
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
			float r = Random.Range(0f, 1f);
			float g = Random.Range(0f, 1f);
			float b = Random.Range(0f, 1f);
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
			else if (this.HairColor == "SolidBlack")
			{
				this.ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
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
				this.RightIrisLight.SetActive(false);
				this.LeftIrisLight.SetActive(false);
			}
			if (this.StudentID > 90 && this.StudentID < 97)
			{
				this.ColorValue.r = this.ColorValue.r * 0.5f;
				this.ColorValue.g = this.ColorValue.g * 0.5f;
				this.ColorValue.b = this.ColorValue.b * 0.5f;
			}
			if (this.ColorValue == new Color(0f, 0f, 0f))
			{
				this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				if (!this.DoNotChangeFace)
				{
					this.FaceTexture = this.HairRenderer.material.mainTexture;
				}
				if (this.Empty)
				{
					this.FaceTexture = this.GrayFace;
				}
				this.CustomHair = true;
			}
			if (!this.CustomHair)
			{
				if (this.Hairstyle > 0)
				{
					if (GameGlobals.LoveSick)
					{
						this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
						if (this.HairRenderer.materials.Length > 1)
						{
							this.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
						}
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
				if (this.HairRenderer.materials.Length > 1)
				{
					this.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
				}
			}
			if (!this.Male)
			{
				if (this.StudentID == 25)
				{
					this.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
				}
				else if (this.StudentID == 30)
				{
					this.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
				}
			}
		}
		else
		{
			this.HairRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
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
		int studentID = this.StudentID;
		if (this.StudentID == 25 || this.StudentID == 30)
		{
			this.FemaleAccessories[6].SetActive(true);
			if ((float)StudentGlobals.GetStudentReputation(this.StudentID) < -33.33333f)
			{
				this.FemaleAccessories[6].SetActive(false);
			}
		}
		if (this.StudentID == 2)
		{
			if (SchemeGlobals.GetSchemeStage(2) == 2 || SchemeGlobals.GetSchemeStage(2) == 100)
			{
				this.FemaleAccessories[3].SetActive(false);
			}
		}
		else if (this.StudentID == 40)
		{
			if (base.transform.position != Vector3.zero)
			{
				this.RightEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
				this.LeftEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
				this.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
				this.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
			}
		}
		else if (this.StudentID == 41)
		{
			this.CharacterAnimation["moodyEyes_00"].layer = 1;
			this.CharacterAnimation.Play("moodyEyes_00");
			this.CharacterAnimation["moodyEyes_00"].weight = 1f;
			this.CharacterAnimation.Play("moodyEyes_00");
		}
		else if (this.StudentID == 51)
		{
			if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
			{
				this.PunkAccessories[1].SetActive(true);
				this.PunkAccessories[2].SetActive(true);
				this.PunkAccessories[3].SetActive(true);
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
		if (!this.Male)
		{
			this.EyeTypeCheck();
		}
		if (this.Kidnapped)
		{
			this.WearIndoorShoes();
		}
		if (!this.Male && (this.Hairstyle == 20 || this.Hairstyle == 21))
		{
			Object.Destroy(base.gameObject);
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
			this.FaceTexture = (this.CustomHair ? this.HairRenderer.material.mainTexture : this.FaceTextures[this.SkinColor]);
			bool flag = false;
			if (this.StudentID == 28)
			{
				flag = true;
			}
			if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorTan)
			{
				this.SkinColor = 6;
				this.DoNotChangeFace = true;
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
		if (this.StudentID == 10)
		{
			this.Student.GymTexture = this.ObstacleGymTexture;
			this.Student.TowelTexture = this.ObstacleTowelTexture;
			this.Student.SwimsuitTexture = this.ObstacleSwimsuitTexture;
		}
		if (this.StudentID == 11)
		{
			this.Student.SwimsuitTexture = this.OsanaSwimsuitTexture;
		}
		if (this.StudentID == 58)
		{
			this.SkinColor = 8;
			this.Student.TowelTexture = this.TanTowelTexture;
			this.Student.SwimsuitTexture = this.TanSwimsuitTexture;
		}
		if (this.Empty)
		{
			this.UniformTexture = this.MaleUniformTextures[7];
			this.CasualTexture = this.MaleCasualTextures[7];
			this.SocksTexture = this.MaleSocksTextures[7];
			this.FaceTexture = this.GrayFace;
			this.SkinColor = 7;
		}
		if (!this.Student.Indoors)
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
			return;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
		this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
	}

	public void SetFemaleUniform()
	{
		if (this.Club != ClubType.Council)
		{
			this.MyRenderer.sharedMesh = this.FemaleUniforms[StudentGlobals.FemaleUniform];
			this.SchoolUniform = this.FemaleUniforms[StudentGlobals.FemaleUniform];
			if (this.Club == ClubType.Bully)
			{
				this.UniformTexture = this.GanguroUniformTextures[StudentGlobals.FemaleUniform];
				this.CasualTexture = this.GanguroCasualTextures[StudentGlobals.FemaleUniform];
				this.SocksTexture = this.GanguroSocksTextures[StudentGlobals.FemaleUniform];
			}
			else if (this.StudentID == 10)
			{
				this.UniformTexture = this.ObstacleUniformTextures[StudentGlobals.FemaleUniform];
				this.CasualTexture = this.ObstacleCasualTextures[StudentGlobals.FemaleUniform];
				this.SocksTexture = this.ObstacleSocksTextures[StudentGlobals.FemaleUniform];
			}
			else if (this.StudentID > 11 && this.StudentID < 21)
			{
				this.MysteriousObstacle = true;
				this.UniformTexture = this.BlackBody;
				this.CasualTexture = this.BlackBody;
				this.SocksTexture = this.BlackBody;
				this.HairRenderer.enabled = false;
				this.RightEyeRenderer.enabled = false;
				this.LeftEyeRenderer.enabled = false;
				this.RightIrisLight.SetActive(false);
				this.LeftIrisLight.SetActive(false);
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
		if (this.Empty)
		{
			this.UniformTexture = this.FemaleUniformTextures[8];
			this.CasualTexture = this.FemaleCasualTextures[8];
			this.SocksTexture = this.FemaleSocksTextures[8];
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
		ClubType club = this.Club;
		if (this.MysteriousObstacle)
		{
			this.FaceTexture = this.BlackBody;
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
			return;
		}
		this.RemoveCensor();
	}

	public void RemoveCensor()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
	}

	private void TaskCheck()
	{
		if (this.StudentID == 37)
		{
			if (TaskGlobals.GetTaskStatus(37) < 3)
			{
				if (!this.TakingPortrait)
				{
					this.MaleAccessories[1].SetActive(false);
					return;
				}
				this.MaleAccessories[1].SetActive(true);
				return;
			}
		}
		else if (this.StudentID == 11 && this.PhoneCharms.Length != 0)
		{
			if (TaskGlobals.GetTaskStatus(11) < 3)
			{
				this.PhoneCharms[11].SetActive(false);
				return;
			}
			this.PhoneCharms[11].SetActive(true);
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
			else if (this.Hairstyle == 30)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if ((this.Accessory > 1 && this.Accessory < 5) || this.Accessory == 13)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if (this.Student.Persona == PersonaType.TeachersPet)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if (this.EyewearID > 0)
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
				Object.Destroy(gameObject);
			}
		}
		foreach (GameObject gameObject2 in this.MaleAccessories)
		{
			if (gameObject2 != null && !gameObject2.activeInHierarchy)
			{
				Object.Destroy(gameObject2);
			}
		}
		foreach (GameObject gameObject3 in this.ClubAccessories)
		{
			if (gameObject3 != null && !gameObject3.activeInHierarchy)
			{
				Object.Destroy(gameObject3);
			}
		}
		foreach (GameObject gameObject4 in this.TeacherAccessories)
		{
			if (gameObject4 != null && !gameObject4.activeInHierarchy)
			{
				Object.Destroy(gameObject4);
			}
		}
		foreach (GameObject gameObject5 in this.TeacherHair)
		{
			if (gameObject5 != null && !gameObject5.activeInHierarchy)
			{
				Object.Destroy(gameObject5);
			}
		}
		foreach (GameObject gameObject6 in this.FemaleHair)
		{
			if (gameObject6 != null && !gameObject6.activeInHierarchy)
			{
				Object.Destroy(gameObject6);
			}
		}
		foreach (GameObject gameObject7 in this.MaleHair)
		{
			if (gameObject7 != null && !gameObject7.activeInHierarchy)
			{
				Object.Destroy(gameObject7);
			}
		}
		foreach (GameObject gameObject8 in this.FacialHair)
		{
			if (gameObject8 != null && !gameObject8.activeInHierarchy)
			{
				Object.Destroy(gameObject8);
			}
		}
		foreach (GameObject gameObject9 in this.Eyewear)
		{
			if (gameObject9 != null && !gameObject9.activeInHierarchy)
			{
				Object.Destroy(gameObject9);
			}
		}
		foreach (GameObject gameObject10 in this.RightStockings)
		{
			if (gameObject10 != null && !gameObject10.activeInHierarchy)
			{
				Object.Destroy(gameObject10);
			}
		}
		foreach (GameObject gameObject11 in this.LeftStockings)
		{
			if (gameObject11 != null && !gameObject11.activeInHierarchy)
			{
				Object.Destroy(gameObject11);
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
		else if (this.Stockings == "Music1")
		{
			if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
			{
				this.MyStockings = this.MusicStockings[1];
			}
		}
		else if (this.Stockings == "Music2")
		{
			this.MyStockings = this.MusicStockings[2];
		}
		else if (this.Stockings == "Music3")
		{
			this.MyStockings = this.MusicStockings[3];
		}
		else if (this.Stockings == "Music4")
		{
			this.MyStockings = this.MusicStockings[4];
		}
		else if (this.Stockings == "Music5")
		{
			this.MyStockings = this.MusicStockings[5];
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
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom2")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings2.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[2] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[2];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom3")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings3.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[3] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[3];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom4")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings4.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[4] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[4];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom5")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings5.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[5] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[5];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom6")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings6.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[6] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[6];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom7")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings7.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[7] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[7];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom8")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings8.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[8] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[8];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom9")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings9.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[9] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[9];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom10")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings10.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[10] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[10];
			NewCustomStockings = null;
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
			return;
		}
		this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
	}

	public void WearOutdoorShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
			return;
		}
		this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
	}

	public void EyeTypeCheck()
	{
		int num = 0;
		if (this.EyeType == "Thin")
		{
			this.MyRenderer.SetBlendShapeWeight(8, 100f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Thins++;
			num = this.StudentManager.Thins;
		}
		else if (this.EyeType == "Serious")
		{
			this.MyRenderer.SetBlendShapeWeight(5, 50f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Seriouses++;
			num = this.StudentManager.Seriouses;
		}
		else if (this.EyeType == "Round")
		{
			this.MyRenderer.SetBlendShapeWeight(5, 15f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Rounds++;
			num = this.StudentManager.Rounds;
		}
		else if (this.EyeType == "Sad")
		{
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 15f);
			this.MyRenderer.SetBlendShapeWeight(6, 50f);
			this.MyRenderer.SetBlendShapeWeight(8, 50f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Sads++;
			num = this.StudentManager.Sads;
		}
		else if (this.EyeType == "Mean")
		{
			this.MyRenderer.SetBlendShapeWeight(10, 100f);
			this.StudentManager.Means++;
			num = this.StudentManager.Means;
		}
		else if (this.EyeType == "Smug")
		{
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 25f);
			this.StudentManager.Smugs++;
			num = this.StudentManager.Smugs;
		}
		else if (this.EyeType == "Gentle")
		{
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.StudentManager.Gentles++;
			num = this.StudentManager.Gentles;
		}
		else if (this.EyeType == "MO")
		{
			this.MyRenderer.SetBlendShapeWeight(8, 50f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.StudentManager.Gentles++;
			num = this.StudentManager.Gentles;
		}
		else if (this.EyeType == "Rival1")
		{
			this.MyRenderer.SetBlendShapeWeight(8, 5f);
			this.MyRenderer.SetBlendShapeWeight(9, 20f);
			this.MyRenderer.SetBlendShapeWeight(10, 50f);
			this.MyRenderer.SetBlendShapeWeight(11, 50f);
			this.MyRenderer.SetBlendShapeWeight(12, 10f);
			this.StudentManager.Rival1s++;
			num = this.StudentManager.Rival1s;
		}
		if (!this.Modified)
		{
			if ((this.EyeType == "Thin" && this.StudentManager.Thins > 1) || (this.EyeType == "Serious" && this.StudentManager.Seriouses > 1) || (this.EyeType == "Round" && this.StudentManager.Rounds > 1) || (this.EyeType == "Sad" && this.StudentManager.Sads > 1) || (this.EyeType == "Mean" && this.StudentManager.Means > 1) || (this.EyeType == "Smug" && this.StudentManager.Smugs > 1) || (this.EyeType == "Gentle" && this.StudentManager.Gentles > 1))
			{
				this.MyRenderer.SetBlendShapeWeight(8, this.MyRenderer.GetBlendShapeWeight(8) + (float)num);
				this.MyRenderer.SetBlendShapeWeight(9, this.MyRenderer.GetBlendShapeWeight(9) + (float)num);
				this.MyRenderer.SetBlendShapeWeight(10, this.MyRenderer.GetBlendShapeWeight(10) + (float)num);
				this.MyRenderer.SetBlendShapeWeight(12, this.MyRenderer.GetBlendShapeWeight(12) + (float)num);
			}
			this.Modified = true;
		}
	}

	public void DeactivateBullyAccessories()
	{
		if (StudentGlobals.FemaleUniform < 2 || StudentGlobals.FemaleUniform == 3)
		{
			this.RightWristband.SetActive(false);
			this.LeftWristband.SetActive(false);
		}
		this.Bookbag.SetActive(false);
		this.Hoodie.SetActive(false);
	}

	public void ActivateBullyAccessories()
	{
		if (StudentGlobals.FemaleUniform < 2 || StudentGlobals.FemaleUniform == 3)
		{
			this.RightWristband.SetActive(true);
			this.LeftWristband.SetActive(true);
		}
		this.Bookbag.SetActive(true);
		this.Hoodie.SetActive(true);
	}

	public void LoadCosmeticSheet(StudentCosmeticSheet mySheet)
	{
		if (this.Male != mySheet.Male)
		{
			return;
		}
		this.Accessory = mySheet.Accessory;
		this.Hairstyle = mySheet.Hairstyle;
		this.Stockings = mySheet.Stockings;
		this.BreastSize = mySheet.BreastSize;
		this.Start();
		this.ColorValue = mySheet.HairColor;
		this.HairRenderer.material.color = this.ColorValue;
		if (mySheet.CustomHair)
		{
			this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
			this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
			this.FaceTexture = this.HairRenderer.material.mainTexture;
			this.LeftIrisLight.SetActive(false);
			this.RightIrisLight.SetActive(false);
			this.CustomHair = true;
		}
		this.CorrectColor = mySheet.EyeColor;
		this.RightEyeRenderer.material.color = this.CorrectColor;
		this.LeftEyeRenderer.material.color = this.CorrectColor;
		this.Student.Schoolwear = mySheet.Schoolwear;
		this.Student.ChangeSchoolwear();
		if (mySheet.Bloody)
		{
			this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
			this.Student.LiquidProjector.enabled = true;
		}
		if (!this.Male)
		{
			this.Stockings = mySheet.Stockings;
			base.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
			for (int i = 0; i < this.MyRenderer.sharedMesh.blendShapeCount; i++)
			{
				this.MyRenderer.SetBlendShapeWeight(i, mySheet.Blendshapes[i]);
			}
		}
	}

	public StudentCosmeticSheet CosmeticSheet()
	{
		StudentCosmeticSheet studentCosmeticSheet = default(StudentCosmeticSheet);
		studentCosmeticSheet.Blendshapes = new List<float>();
		studentCosmeticSheet.Male = this.Male;
		studentCosmeticSheet.CustomHair = this.CustomHair;
		studentCosmeticSheet.Accessory = this.Accessory;
		studentCosmeticSheet.Hairstyle = this.Hairstyle;
		studentCosmeticSheet.Stockings = this.Stockings;
		studentCosmeticSheet.BreastSize = this.BreastSize;
		studentCosmeticSheet.CustomHair = this.CustomHair;
		studentCosmeticSheet.Schoolwear = this.Student.Schoolwear;
		studentCosmeticSheet.Bloody = (this.Student.LiquidProjector.enabled && this.Student.LiquidProjector.material.mainTexture == this.Student.BloodTexture);
		studentCosmeticSheet.HairColor = this.HairRenderer.material.color;
		studentCosmeticSheet.EyeColor = this.RightEyeRenderer.material.color;
		if (!this.Male)
		{
			for (int i = 0; i < this.MyRenderer.sharedMesh.blendShapeCount; i++)
			{
				studentCosmeticSheet.Blendshapes.Add(this.MyRenderer.GetBlendShapeWeight(i));
			}
		}
		return studentCosmeticSheet;
	}
}
