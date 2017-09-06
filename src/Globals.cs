using System;
using UnityEngine;

public static class Globals
{
	private const string Str_BasementTapeCollected = "BasementTapeCollected_";

	private const string Str_BasementTapeListened = "BasementTapeListened_";

	private const string Str_MangaCollected = "MangaCollected_";

	private const string Str_TapeCollected = "TapeCollected_";

	private const string Str_TapeListened = "TapeListened_";

	private const string Str_TopicDiscovered = "TopicDiscovered_";

	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";

	private const string Str_Affection = "Affection";

	private const string Str_AffectionLevel = "AffectionLevel";

	private const string Str_ComplimentGiven = "ComplimentGiven_";

	private const string Str_SuitorCheck = "SuitorCheck_";

	private const string Str_SuitorProgress = "SuitorProgress";

	private const string Str_SuitorTrait = "SuitorTrait_";

	private const string Str_TopicDiscussed = "TopicDiscussed_";

	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	private const string Str_BefriendConversation = "BefriendConversation";

	private const string Str_KidnapConversation = "KidnapConversation";

	private const string Str_Event1 = "Event1";

	private const string Str_Event2 = "Event2";

	private const string Str_LivingRoom = "LivingRoom";

	private const string Str_LoveSick = "LoveSick";

	private const string Str_MasksBanned = "MasksBanned";

	private const string Str_Paranormal = "Paranormal";

	private const string Str_LateForSchool = "LateForSchool";

	private const string Str_Night = "Night";

	private const string Str_StartInBasement = "StartInBasement";

	private const string Str_MissionCondition = "MissionCondition_";

	private const string Str_MissionDifficulty = "MissionDifficulty";

	private const string Str_MissionMode = "MissionMode";

	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	private const string Str_MissionTarget = "MissionTarget";

	private const string Str_MissionTargetName = "MissionTargetName";

	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	private const string Str_DisableBloom = "DisableBloom";

	private const string Str_DisableFarAnimations = "DisableFarAnimations";

	private const string Str_DisableOutlines = "DisableOutlines";

	private const string Str_DisablePostAliasing = "DisablePostAliasing";

	private const string Str_DisableShadows = "DisableShadows";

	private const string Str_DrawDistance = "DrawDistance";

	private const string Str_Fog = "Fog";

	private const string Str_HighPopulation = "HighPopulation";

	private const string Str_LowDetailStudents = "LowDetailStudents";

	private const string Str_ParticleCount = "ParticleCount";

	private const string Str_Alerts = "Alerts";

	private const string Str_Enlightenment = "Enlightenment";

	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	private const string Str_Headset = "Headset";

	private const string Str_Kills = "Kills";

	private const string Str_Numbness = "Numbness";

	private const string Str_NumbnessBonus = "NumbnessBonus";

	private const string Str_PantiesEquipped = "PantiesEquipped";

	private const string Str_PantyShots = "PantyShots";

	private const string Str_Photo = "Photo_";

	private const string Str_Reputation = "Reputation";

	private const string Str_Seduction = "Seduction";

	private const string Str_SeductionBonus = "SeductionBonus";

	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	private const string Str_SenpaiShots = "SenpaiShots";

	private const string Str_SocialBonus = "SocialBonus";

	private const string Str_SpeedBonus = "SpeedBonus";

	private const string Str_StealthBonus = "StealthBonus";

	private const string Str_StudentFriend = "StudentFriend_";

	private const string Str_StudentPantyShot = "StudentPantyShot_";

	private const string Str_PosePosition = "PosePosition";

	private const string Str_PoseRotation = "PoseRotation";

	private const string Str_PoseScale = "PoseScale";

	private const string Str_CurrentSaveFile = "CurrentSaveFile";

	private const string Str_CurrentScheme = "CurrentScheme";

	private const string Str_DarkSecret = "DarkSecret";

	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	private const string Str_SchemeStage = "SchemeStage_";

	private const string Str_SchemeStatus = "SchemeStatus_";

	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	private const string Str_ServicePurchased = "ServicePurchased_";

	private const string Str_DemonActive = "DemonActive_";

	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	private const string Str_KidnapVictim = "KidnapVictim";

	private const string Str_Population = "Population";

	private const string Str_RoofFence = "RoofFence";

	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	private const string Str_SCP = "SCP";

	private const string Str_CustomSenpai = "CustomSenpai";

	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";

	private const string Str_CustomSuitor = "CustomSuitor";

	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	private const string Str_ExpelProgress = "ExpelProgress";

	private const string Str_FemaleUniform = "FemaleUniform";

	private const string Str_MaleUniform = "MaleUniform";

	private const string Str_StudentAccessory = "StudentAccessory_";

	private const string Str_StudentArrested = "StudentArrested_";

	private const string Str_StudentBroken = "StudentBroken_";

	private const string Str_StudentBustSize = "StudentBustSize_";

	private const string Str_StudentColor = "StudentColor_";

	private const string Str_StudentDead = "StudentDead_";

	private const string Str_StudentDying = "StudentDying_";

	private const string Str_StudentExpelled = "StudentExpelled_";

	private const string Str_StudentExposed = "StudentExposed_";

	private const string Str_StudentEyeColor = "StudentEyeColor_";

	private const string Str_StudentGrudge = "StudentGrudge_";

	private const string Str_StudentHairstyle = "StudentHairstyle_";

	private const string Str_StudentKidnapped = "StudentKidnapped_";

	private const string Str_StudentMissing = "StudentMissing_";

	private const string Str_StudentName = "StudentName_";

	private const string Str_StudentPhotographed = "StudentPhotographed_";

	private const string Str_StudentReplaced = "StudentReplaced_";

	private const string Str_StudentReputation = "StudentReputation_";

	private const string Str_StudentSanity = "StudentSanity_";

	private const string Str_StudentSlave = "StudentSlave_";

	private const string Str_KittenPhoto = "KittenPhoto_";

	private const string Str_TaskStatus = "TaskStatus_";

	private const string Str_Weekday = "Weekday";

	private const string Str_DraculaDefeated = "DraculaDefeated";

	private const string Str_MidoriEasterEgg = "MidoriEasterEgg";

	public static bool KeyExists(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	public static void Delete(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}

	public static bool GetBasementTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("BasementTapeCollected_" + tapeID.ToString());
	}

	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		GlobalsHelper.SetBool("BasementTapeCollected_" + tapeID.ToString(), value);
	}

	public static bool GetBasementTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("BasementTapeListened_" + tapeID.ToString());
	}

	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		GlobalsHelper.SetBool("BasementTapeListened_" + tapeID.ToString(), value);
	}

	public static bool GetMangaCollected(int mangaID)
	{
		return GlobalsHelper.GetBool("MangaCollected_" + mangaID.ToString());
	}

	public static void SetMangaCollected(int mangaID, bool value)
	{
		GlobalsHelper.SetBool("MangaCollected_" + mangaID.ToString(), value);
	}

	public static bool GetTapeCollected(int tapeID)
	{
		return GlobalsHelper.GetBool("TapeCollected_" + tapeID.ToString());
	}

	public static void SetTapeCollected(int tapeID, bool value)
	{
		GlobalsHelper.SetBool("TapeCollected_" + tapeID.ToString(), value);
	}

	public static bool GetTapeListened(int tapeID)
	{
		return GlobalsHelper.GetBool("TapeListened_" + tapeID.ToString());
	}

	public static void SetTapeListened(int tapeID, bool value)
	{
		GlobalsHelper.SetBool("TapeListened_" + tapeID.ToString(), value);
	}

	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("TopicDiscovered_" + topicID.ToString());
	}

	public static void SetTopicDiscovered(int topicID, bool value)
	{
		GlobalsHelper.SetBool("TopicDiscovered_" + topicID.ToString(), value);
	}

	public static bool GetTopicLearnedByStudent(int topicID, int studentID)
	{
		return GlobalsHelper.GetBool("TopicLearnedByStudent_" + topicID.ToString() + "_" + studentID.ToString());
	}

	public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value)
	{
		GlobalsHelper.SetBool("TopicLearnedByStudent_" + topicID.ToString() + "_" + studentID.ToString(), value);
	}

	public static float Affection
	{
		get
		{
			return PlayerPrefs.GetFloat("Affection");
		}
		set
		{
			PlayerPrefs.SetFloat("Affection", value);
		}
	}

	public static float AffectionLevel
	{
		get
		{
			return PlayerPrefs.GetFloat("AffectionLevel");
		}
		set
		{
			PlayerPrefs.SetFloat("AffectionLevel", value);
		}
	}

	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("ComplimentGiven_" + complimentID.ToString());
	}

	public static void SetComplimentGiven(int complimentID, bool value)
	{
		GlobalsHelper.SetBool("ComplimentGiven_" + complimentID.ToString(), value);
	}

	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("SuitorCheck_" + checkID.ToString());
	}

	public static void SetSuitorCheck(int checkID, bool value)
	{
		GlobalsHelper.SetBool("SuitorCheck_" + checkID.ToString(), value);
	}

	public static int SuitorProgress
	{
		get
		{
			return PlayerPrefs.GetInt("SuitorProgress");
		}
		set
		{
			PlayerPrefs.SetInt("SuitorProgress", value);
		}
	}

	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("SuitorTrait_" + traitID.ToString());
	}

	public static void SetSuitorTrait(int traitID, int value)
	{
		PlayerPrefs.SetInt("SuitorTrait_" + traitID.ToString(), value);
	}

	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("TopicDiscussed_" + topicID.ToString());
	}

	public static void SetTopicDiscussed(int topicID, bool value)
	{
		GlobalsHelper.SetBool("TopicDiscussed_" + topicID.ToString(), value);
	}

	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("TraitDemonstrated_" + traitID.ToString());
	}

	public static void SetTraitDemonstrated(int traitID, int value)
	{
		PlayerPrefs.SetInt("TraitDemonstrated_" + traitID.ToString(), value);
	}

	public static bool BefriendConversation
	{
		get
		{
			return GlobalsHelper.GetBool("BefriendConversation");
		}
		set
		{
			GlobalsHelper.SetBool("BefriendConversation", value);
		}
	}

	public static bool KidnapConversation
	{
		get
		{
			return GlobalsHelper.GetBool("KidnapConversation");
		}
		set
		{
			GlobalsHelper.SetBool("KidnapConversation", value);
		}
	}

	public static bool Event1
	{
		get
		{
			return GlobalsHelper.GetBool("Event1");
		}
		set
		{
			GlobalsHelper.SetBool("Event1", value);
		}
	}

	public static bool Event2
	{
		get
		{
			return GlobalsHelper.GetBool("Event2");
		}
		set
		{
			GlobalsHelper.SetBool("Event2", value);
		}
	}

	public static bool LivingRoom
	{
		get
		{
			return GlobalsHelper.GetBool("LivingRoom");
		}
		set
		{
			GlobalsHelper.SetBool("LivingRoom", value);
		}
	}

	public static bool LoveSick
	{
		get
		{
			return GlobalsHelper.GetBool("LoveSick");
		}
		set
		{
			GlobalsHelper.SetBool("LoveSick", value);
		}
	}

	public static bool MasksBanned
	{
		get
		{
			return GlobalsHelper.GetBool("MasksBanned");
		}
		set
		{
			GlobalsHelper.SetBool("MasksBanned", value);
		}
	}

	public static bool Paranormal
	{
		get
		{
			return GlobalsHelper.GetBool("Paranormal");
		}
		set
		{
			GlobalsHelper.SetBool("Paranormal", value);
		}
	}

	public static bool LateForSchool
	{
		get
		{
			return GlobalsHelper.GetBool("LateForSchool");
		}
		set
		{
			GlobalsHelper.SetBool("LateForSchool", value);
		}
	}

	public static bool Night
	{
		get
		{
			return GlobalsHelper.GetBool("Night");
		}
		set
		{
			GlobalsHelper.SetBool("Night", value);
		}
	}

	public static bool StartInBasement
	{
		get
		{
			return GlobalsHelper.GetBool("StartInBasement");
		}
		set
		{
			GlobalsHelper.SetBool("StartInBasement", value);
		}
	}

	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	public static void SetMissionCondition(int id, int value)
	{
		PlayerPrefs.SetInt("MissionCondition_" + id.ToString(), value);
	}

	public static int MissionDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("MissionDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("MissionDifficulty", value);
		}
	}

	public static bool MissionMode
	{
		get
		{
			return GlobalsHelper.GetBool("MissionMode");
		}
		set
		{
			GlobalsHelper.SetBool("MissionMode", value);
		}
	}

	public static int MissionRequiredClothing
	{
		get
		{
			return PlayerPrefs.GetInt("MissionRequiredClothing");
		}
		set
		{
			PlayerPrefs.SetInt("MissionRequiredClothing", value);
		}
	}

	public static int MissionRequiredDisposal
	{
		get
		{
			return PlayerPrefs.GetInt("MissionRequiredDisposal");
		}
		set
		{
			PlayerPrefs.SetInt("MissionRequiredDisposal", value);
		}
	}

	public static int MissionRequiredWeapon
	{
		get
		{
			return PlayerPrefs.GetInt("MissionRequiredWeapon");
		}
		set
		{
			PlayerPrefs.SetInt("MissionRequiredWeapon", value);
		}
	}

	public static int MissionTarget
	{
		get
		{
			return PlayerPrefs.GetInt("MissionTarget");
		}
		set
		{
			PlayerPrefs.SetInt("MissionTarget", value);
		}
	}

	public static string MissionTargetName
	{
		get
		{
			return PlayerPrefs.GetString("MissionTargetName");
		}
		set
		{
			PlayerPrefs.SetString("MissionTargetName", value);
		}
	}

	public static int NemesisDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("NemesisDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("NemesisDifficulty", value);
		}
	}

	public static bool DisableBloom
	{
		get
		{
			return GlobalsHelper.GetBool("DisableBloom");
		}
		set
		{
			GlobalsHelper.SetBool("DisableBloom", value);
		}
	}

	public static bool DisableFarAnimations
	{
		get
		{
			return GlobalsHelper.GetBool("DisableFarAnimations");
		}
		set
		{
			GlobalsHelper.SetBool("DisableFarAnimations", value);
		}
	}

	public static bool DisableOutlines
	{
		get
		{
			return GlobalsHelper.GetBool("DisableOutlines");
		}
		set
		{
			GlobalsHelper.SetBool("DisableOutlines", value);
		}
	}

	public static bool DisablePostAliasing
	{
		get
		{
			return GlobalsHelper.GetBool("DisablePostAliasing");
		}
		set
		{
			GlobalsHelper.SetBool("DisablePostAliasing", value);
		}
	}

	public static bool DisableShadows
	{
		get
		{
			return GlobalsHelper.GetBool("DisableShadows");
		}
		set
		{
			GlobalsHelper.SetBool("DisableShadows", value);
		}
	}

	public static int DrawDistance
	{
		get
		{
			return PlayerPrefs.GetInt("DrawDistance");
		}
		set
		{
			PlayerPrefs.SetInt("DrawDistance", value);
		}
	}

	public static bool Fog
	{
		get
		{
			return GlobalsHelper.GetBool("Fog");
		}
		set
		{
			GlobalsHelper.SetBool("Fog", value);
		}
	}

	public static bool HighPopulation
	{
		get
		{
			return GlobalsHelper.GetBool("HighPopulation");
		}
		set
		{
			GlobalsHelper.SetBool("HighPopulation", value);
		}
	}

	public static int LowDetailStudents
	{
		get
		{
			return PlayerPrefs.GetInt("LowDetailStudents");
		}
		set
		{
			PlayerPrefs.SetInt("LowDetailStudents", value);
		}
	}

	public static int ParticleCount
	{
		get
		{
			return PlayerPrefs.GetInt("ParticleCount");
		}
		set
		{
			PlayerPrefs.SetInt("ParticleCount", value);
		}
	}

	public static int Alerts
	{
		get
		{
			return PlayerPrefs.GetInt("Alerts");
		}
		set
		{
			PlayerPrefs.SetInt("Alerts", value);
		}
	}

	public static int Enlightenment
	{
		get
		{
			return PlayerPrefs.GetInt("Enlightenment");
		}
		set
		{
			PlayerPrefs.SetInt("Enlightenment", value);
		}
	}

	public static int EnlightenmentBonus
	{
		get
		{
			return PlayerPrefs.GetInt("EnlightenmentBonus");
		}
		set
		{
			PlayerPrefs.SetInt("EnlightenmentBonus", value);
		}
	}

	public static bool Headset
	{
		get
		{
			return GlobalsHelper.GetBool("Headset");
		}
		set
		{
			GlobalsHelper.SetBool("Headset", value);
		}
	}

	public static int Kills
	{
		get
		{
			return PlayerPrefs.GetInt("Kills");
		}
		set
		{
			PlayerPrefs.SetInt("Kills", value);
		}
	}

	public static int Numbness
	{
		get
		{
			return PlayerPrefs.GetInt("Numbness");
		}
		set
		{
			PlayerPrefs.SetInt("Numbness", value);
		}
	}

	public static int NumbnessBonus
	{
		get
		{
			return PlayerPrefs.GetInt("NumbnessBonus");
		}
		set
		{
			PlayerPrefs.SetInt("NumbnessBonus", value);
		}
	}

	public static int PantiesEquipped
	{
		get
		{
			return PlayerPrefs.GetInt("PantiesEquipped");
		}
		set
		{
			PlayerPrefs.SetInt("PantiesEquipped", value);
		}
	}

	public static int PantyShots
	{
		get
		{
			return PlayerPrefs.GetInt("PantyShots");
		}
		set
		{
			PlayerPrefs.SetInt("PantyShots", value);
		}
	}

	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Photo_" + photoID.ToString());
	}

	public static void SetPhoto(int photoID, bool value)
	{
		GlobalsHelper.SetBool("Photo_" + photoID.ToString(), value);
	}

	public static float Reputation
	{
		get
		{
			return PlayerPrefs.GetFloat("Reputation");
		}
		set
		{
			PlayerPrefs.SetFloat("Reputation", value);
		}
	}

	public static int Seduction
	{
		get
		{
			return PlayerPrefs.GetInt("Seduction");
		}
		set
		{
			PlayerPrefs.SetInt("Seduction", value);
		}
	}

	public static int SeductionBonus
	{
		get
		{
			return PlayerPrefs.GetInt("SeductionBonus");
		}
		set
		{
			PlayerPrefs.SetInt("SeductionBonus", value);
		}
	}

	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("SenpaiPhoto_" + photoID.ToString());
	}

	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		GlobalsHelper.SetBool("SenpaiPhoto_" + photoID.ToString(), value);
	}

	public static int SenpaiShots
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiShots");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiShots", value);
		}
	}

	public static int SocialBonus
	{
		get
		{
			return PlayerPrefs.GetInt("SocialBonus");
		}
		set
		{
			PlayerPrefs.SetInt("SocialBonus", value);
		}
	}

	public static int SpeedBonus
	{
		get
		{
			return PlayerPrefs.GetInt("SpeedBonus");
		}
		set
		{
			PlayerPrefs.SetInt("SpeedBonus", value);
		}
	}

	public static int StealthBonus
	{
		get
		{
			return PlayerPrefs.GetInt("StealthBonus");
		}
		set
		{
			PlayerPrefs.SetInt("StealthBonus", value);
		}
	}

	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("StudentFriend_" + studentID.ToString());
	}

	public static void SetStudentFriend(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentFriend_" + studentID.ToString(), value);
	}

	public static bool GetStudentPantyShot(string studentName)
	{
		return GlobalsHelper.GetBool("StudentPantyShot_" + studentName);
	}

	public static void SetStudentPantyShot(string studentName, bool value)
	{
		GlobalsHelper.SetBool("StudentPantyShot_" + studentName, value);
	}

	public static Vector3 PosePosition
	{
		get
		{
			return GlobalsHelper.GetVector3("PosePosition");
		}
		set
		{
			GlobalsHelper.SetVector3("PosePosition", value);
		}
	}

	public static Vector3 PoseRotation
	{
		get
		{
			return GlobalsHelper.GetVector3("PoseRotation");
		}
		set
		{
			GlobalsHelper.SetVector3("PoseRotation", value);
		}
	}

	public static Vector3 PoseScale
	{
		get
		{
			return GlobalsHelper.GetVector3("PoseScale");
		}
		set
		{
			GlobalsHelper.SetVector3("PoseScale", value);
		}
	}

	public static int CurrentSaveFile
	{
		get
		{
			return PlayerPrefs.GetInt("CurrentSaveFile");
		}
		set
		{
			PlayerPrefs.SetInt("CurrentSaveFile", value);
		}
	}

	public static int CurrentScheme
	{
		get
		{
			return PlayerPrefs.GetInt("CurrentScheme");
		}
		set
		{
			PlayerPrefs.SetInt("CurrentScheme", value);
		}
	}

	public static bool DarkSecret
	{
		get
		{
			return GlobalsHelper.GetBool("DarkSecret");
		}
		set
		{
			GlobalsHelper.SetBool("DarkSecret", value);
		}
	}

	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("SchemePreviousStage_" + schemeID.ToString());
	}

	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		PlayerPrefs.SetInt("SchemePreviousStage_" + schemeID.ToString(), value);
	}

	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("SchemeStage_" + schemeID.ToString());
	}

	public static void SetSchemeStage(int schemeID, int value)
	{
		PlayerPrefs.SetInt("SchemeStage_" + schemeID.ToString(), value);
	}

	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("SchemeStatus_" + schemeID.ToString());
	}

	public static void SetSchemeStatus(int schemeID, bool value)
	{
		GlobalsHelper.SetBool("SchemeStatus_" + schemeID.ToString(), value);
	}

	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("SchemeUnlocked_" + schemeID.ToString());
	}

	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		GlobalsHelper.SetBool("SchemeUnlocked_" + schemeID.ToString(), value);
	}

	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("ServicePurchased_" + serviceID.ToString());
	}

	public static void SetServicePurchased(int serviceID, bool value)
	{
		GlobalsHelper.SetBool("ServicePurchased_" + serviceID.ToString(), value);
	}

	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("DemonActive_" + demonID.ToString());
	}

	public static void SetDemonActive(int demonID, bool value)
	{
		GlobalsHelper.SetBool("DemonActive_" + demonID.ToString(), value);
	}

	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("GardenGraveOccupied_" + graveID.ToString());
	}

	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		GlobalsHelper.SetBool("GardenGraveOccupied_" + graveID.ToString(), value);
	}

	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("KidnapVictim", value);
		}
	}

	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Population");
		}
		set
		{
			PlayerPrefs.SetInt("Population", value);
		}
	}

	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("RoofFence", value);
		}
	}

	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("SchoolAtmosphere", value);
		}
	}

	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("SchoolAtmosphereSet", value);
		}
	}

	public static SchoolAtmosphereType SchoolAtmosphereType
	{
		get
		{
			float num = Globals.SchoolAtmosphere / 100f;
			if (num > 0.6666667f)
			{
				return SchoolAtmosphereType.High;
			}
			if (num > 0.333333343f)
			{
				return SchoolAtmosphereType.Medium;
			}
			return SchoolAtmosphereType.Low;
		}
	}

	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("SCP");
		}
		set
		{
			GlobalsHelper.SetBool("SCP", value);
		}
	}

	public static bool CustomSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("CustomSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("CustomSenpai", value);
		}
	}

	public static string SenpaiEyeColor
	{
		get
		{
			return PlayerPrefs.GetString("SenpaiEyeColor");
		}
		set
		{
			PlayerPrefs.SetString("SenpaiEyeColor", value);
		}
	}

	public static int SenpaiEyeWear
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiEyeWear");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiEyeWear", value);
		}
	}

	public static int SenpaiFacialHair
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiFacialHair");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiFacialHair", value);
		}
	}

	public static string SenpaiHairColor
	{
		get
		{
			return PlayerPrefs.GetString("SenpaiHairColor");
		}
		set
		{
			PlayerPrefs.SetString("SenpaiHairColor", value);
		}
	}

	public static int SenpaiHairStyle
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiHairStyle");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiHairStyle", value);
		}
	}

	public static int SenpaiSkinColor
	{
		get
		{
			return PlayerPrefs.GetInt("SenpaiSkinColor");
		}
		set
		{
			PlayerPrefs.SetInt("SenpaiSkinColor", value);
		}
	}

	public static bool CustomSuitor
	{
		get
		{
			return GlobalsHelper.GetBool("CustomSuitor");
		}
		set
		{
			GlobalsHelper.SetBool("CustomSuitor", value);
		}
	}

	public static int CustomSuitorAccessory
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorAccessory");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorAccessory", value);
		}
	}

	public static int CustomSuitorBlonde
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorBlonde");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorBlonde", value);
		}
	}

	public static int CustomSuitorEyewear
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorEyewear");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorEyewear", value);
		}
	}

	public static int CustomSuitorHair
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorHair");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorHair", value);
		}
	}

	public static int CustomSuitorJewelry
	{
		get
		{
			return PlayerPrefs.GetInt("CustomSuitorJewelry");
		}
		set
		{
			PlayerPrefs.SetInt("CustomSuitorJewelry", value);
		}
	}

	public static bool CustomSuitorTan
	{
		get
		{
			return GlobalsHelper.GetBool("CustomSuitorTan");
		}
		set
		{
			GlobalsHelper.SetBool("CustomSuitorTan", value);
		}
	}

	public static int ExpelProgress
	{
		get
		{
			return PlayerPrefs.GetInt("ExpelProgress");
		}
		set
		{
			PlayerPrefs.SetInt("ExpelProgress", value);
		}
	}

	public static int FemaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("FemaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("FemaleUniform", value);
		}
	}

	public static int MaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("MaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("MaleUniform", value);
		}
	}

	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("StudentAccessory_" + studentID.ToString());
	}

	public static void SetStudentAccessory(int studentID, string value)
	{
		PlayerPrefs.SetString("StudentAccessory_" + studentID.ToString(), value);
	}

	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("StudentArrested_" + studentID.ToString());
	}

	public static void SetStudentArrested(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentArrested_" + studentID.ToString(), value);
	}

	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("StudentBroken_" + studentID.ToString());
	}

	public static void SetStudentBroken(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentBroken_" + studentID.ToString(), value);
	}

	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("StudentBustSize_" + studentID.ToString());
	}

	public static void SetStudentBustSize(int studentID, float value)
	{
		PlayerPrefs.SetFloat("StudentBustSize_" + studentID.ToString(), value);
	}

	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("StudentColor_" + studentID.ToString());
	}

	public static void SetStudentColor(int studentID, Color value)
	{
		GlobalsHelper.SetColor("StudentColor_" + studentID.ToString(), value);
	}

	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("StudentDead_" + studentID.ToString());
	}

	public static void SetStudentDead(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentDead_" + studentID.ToString(), value);
	}

	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("StudentDying_" + studentID.ToString());
	}

	public static void SetStudentDying(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentDying_" + studentID.ToString(), value);
	}

	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("StudentExpelled_" + studentID.ToString());
	}

	public static void SetStudentExpelled(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentExpelled_" + studentID.ToString(), value);
	}

	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("StudentExposed_" + studentID.ToString());
	}

	public static void SetStudentExposed(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentExposed_" + studentID.ToString(), value);
	}

	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("StudentEyeColor_" + studentID.ToString());
	}

	public static void SetStudentEyeColor(int studentID, Color value)
	{
		GlobalsHelper.SetColor("StudentEyeColor_" + studentID.ToString(), value);
	}

	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("StudentGrudge_" + studentID.ToString());
	}

	public static void SetStudentGrudge(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentGrudge_" + studentID.ToString(), value);
	}

	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("StudentHairstyle_" + studentID.ToString());
	}

	public static void SetStudentHairstyle(int studentID, string value)
	{
		PlayerPrefs.SetString("StudentHairstyle_" + studentID.ToString(), value);
	}

	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("StudentKidnapped_" + studentID.ToString());
	}

	public static void SetStudentKidnapped(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentKidnapped_" + studentID.ToString(), value);
	}

	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("StudentMissing_" + studentID.ToString());
	}

	public static void SetStudentMissing(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentMissing_" + studentID.ToString(), value);
	}

	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("StudentName_" + studentID.ToString());
	}

	public static void SetStudentName(int studentID, string value)
	{
		PlayerPrefs.SetString("StudentName_" + studentID.ToString(), value);
	}

	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("StudentPhotographed_" + studentID.ToString());
	}

	public static void SetStudentPhotographed(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentPhotographed_" + studentID.ToString(), value);
	}

	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("StudentReplaced_" + studentID.ToString());
	}

	public static void SetStudentReplaced(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentReplaced_" + studentID.ToString(), value);
	}

	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("StudentReputation_" + studentID.ToString());
	}

	public static void SetStudentReputation(int studentID, int value)
	{
		PlayerPrefs.SetInt("StudentReputation_" + studentID.ToString(), value);
	}

	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("StudentSanity_" + studentID.ToString());
	}

	public static void SetStudentSanity(int studentID, float value)
	{
		PlayerPrefs.SetFloat("StudentSanity_" + studentID.ToString(), value);
	}

	public static bool GetStudentSlave(int studentID)
	{
		return GlobalsHelper.GetBool("StudentSlave_" + studentID.ToString());
	}

	public static void SetStudentSlave(int studentID, bool value)
	{
		GlobalsHelper.SetBool("StudentSlave_" + studentID.ToString(), value);
	}

	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("KittenPhoto_" + photoID.ToString());
	}

	public static void SetKittenPhoto(int photoID, bool value)
	{
		GlobalsHelper.SetBool("KittenPhoto_" + photoID.ToString(), value);
	}

	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("TaskStatus_" + taskID.ToString());
	}

	public static void SetTaskStatus(int taskID, int value)
	{
		PlayerPrefs.SetInt("TaskStatus_" + taskID.ToString(), value);
	}

	public static int Weekday
	{
		get
		{
			return PlayerPrefs.GetInt("Weekday");
		}
		set
		{
			PlayerPrefs.SetInt("Weekday", value);
		}
	}

	public static bool DraculaDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("DraculaDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("DraculaDefeated", value);
		}
	}

	public static bool MidoriEasterEgg
	{
		get
		{
			return GlobalsHelper.GetBool("MidoriEasterEgg");
		}
		set
		{
			GlobalsHelper.SetBool("MidoriEasterEgg", value);
		}
	}
}
