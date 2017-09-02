using System;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
	private static class GlobalsHelper
	{
		public static bool GetBool(string key)
		{
			return PlayerPrefs.GetInt(key) == 1;
		}

		public static void SetBool(string key, bool value)
		{
			PlayerPrefs.SetInt(key, (!value) ? 0 : 1);
		}

		public static T GetEnum<T>(string key) where T : struct, IConvertible
		{
			return (T)((object)PlayerPrefs.GetInt(key));
		}

		public static void SetEnum<T>(string key, T value) where T : struct, IConvertible
		{
			PlayerPrefs.SetInt(key, (int)((object)value));
		}

		public static Vector3 GetVector3(string key)
		{
			float @float = PlayerPrefs.GetFloat(key + "_X");
			float float2 = PlayerPrefs.GetFloat(key + "_Y");
			float float3 = PlayerPrefs.GetFloat(key + "_Z");
			return new Vector3(@float, float2, float3);
		}

		public static void SetVector3(string key, Vector3 value)
		{
			PlayerPrefs.SetFloat(key + "_X", value.x);
			PlayerPrefs.SetFloat(key + "_Y", value.y);
			PlayerPrefs.SetFloat(key + "_Z", value.z);
		}

		public static Color GetColor(string key)
		{
			float @float = PlayerPrefs.GetFloat(key + "_R");
			float float2 = PlayerPrefs.GetFloat(key + "_G");
			float float3 = PlayerPrefs.GetFloat(key + "_B");
			float float4 = PlayerPrefs.GetFloat(key + "_A");
			return new Color(@float, float2, float3, float4);
		}

		public static void SetColor(string key, Color value)
		{
			PlayerPrefs.SetFloat(key + "_R", value.r);
			PlayerPrefs.SetFloat(key + "_G", value.g);
			PlayerPrefs.SetFloat(key + "_B", value.b);
			PlayerPrefs.SetFloat(key + "_A", value.a);
		}
	}

	private static class KeysHelper
	{
		private const string KeyListPrefix = "Keys";

		private const char KeyListSeparator = '|';

		public const char PairSeparator = '^';

		public static T[] GetKeys<T>(string key) where T : struct
		{
			string keyList = Globals.KeysHelper.GetKeyList(Globals.KeysHelper.GetKeyListKey(key));
			string[] array = Globals.KeysHelper.Split(keyList);
			return Array.ConvertAll<string, T>(array, (string str) => (T)((object)int.Parse(str)));
		}

		public static string[] GetKeys(string key)
		{
			string keyList = Globals.KeysHelper.GetKeyList(Globals.KeysHelper.GetKeyListKey(key));
			return Globals.KeysHelper.Split(keyList);
		}

		public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct
		{
			string keyList = Globals.KeysHelper.GetKeyList(Globals.KeysHelper.GetKeyListKey(key));
			string[] array = Globals.KeysHelper.Split(keyList);
			KeyValuePair<T, U>[] array2 = new KeyValuePair<T, U>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				string[] array3 = array[i].Split(new char[]
				{
					'^'
				});
				array2[i] = new KeyValuePair<T, U>((T)((object)int.Parse(array3[0])), (U)((object)int.Parse(array3[1])));
			}
			return array2;
		}

		public static void AddIfMissing(string key, string id)
		{
			string keyListKey = Globals.KeysHelper.GetKeyListKey(key);
			string keyList = Globals.KeysHelper.GetKeyList(keyListKey);
			string[] keyListStrings = Globals.KeysHelper.Split(keyList);
			if (!Globals.KeysHelper.HasKey(keyListStrings, id))
			{
				Globals.KeysHelper.AppendKey(keyListKey, keyList, id);
			}
		}

		private static string GetKeyListKey(string key)
		{
			return key + "Keys";
		}

		private static string GetKeyList(string keyListKey)
		{
			if (!PlayerPrefs.HasKey(keyListKey))
			{
				PlayerPrefs.SetString(keyListKey, string.Empty);
			}
			return PlayerPrefs.GetString(keyListKey);
		}

		private static string[] Split(string keyList)
		{
			return keyList.Split(new char[]
			{
				'|'
			});
		}

		private static int FindKey(string[] keyListStrings, string key)
		{
			return Array.IndexOf<string>(keyListStrings, key);
		}

		private static bool HasKey(string[] keyListStrings, string key)
		{
			return Globals.KeysHelper.FindKey(keyListStrings, key) > -1;
		}

		private static void AppendKey(string keyListKey, string keyList, string key)
		{
			string value = (keyList.Length != 0) ? (keyList + '|' + key) : (keyList + key);
			PlayerPrefs.SetString(keyListKey, value);
		}
	}

	private const string Str_VersionNumber = "VersionNumber";

	private const string Str_Biology = "Biology";

	private const string Str_BiologyBonus = "BiologyBonus";

	private const string Str_BiologyGrade = "BiologyGrade";

	private const string Str_Chemistry = "Chemistry";

	private const string Str_ChemistryBonus = "ChemistryBonus";

	private const string Str_ChemistryGrade = "ChemistryGrade";

	private const string Str_Language = "Language";

	private const string Str_LanguageBonus = "LanguageBonus";

	private const string Str_LanguageGrade = "LanguageGrade";

	private const string Str_Physical = "Physical";

	private const string Str_PhysicalBonus = "PhysicalBonus";

	private const string Str_PhysicalGrade = "PhysicalGrade";

	private const string Str_Psychology = "Psychology";

	private const string Str_PsychologyBonus = "PsychologyBonus";

	private const string Str_PsychologyGrade = "PsychologyGrade";

	private const string Str_Club = "Club";

	private const string Str_ClubClosed = "ClubClosed_";

	private const string Str_ClubKicked = "ClubKicked_";

	private const string Str_QuitClub = "QuitClub_";

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

	public static void Save()
	{
		PlayerPrefs.Save();
	}

	public static float VersionNumber
	{
		get
		{
			return PlayerPrefs.GetFloat("VersionNumber");
		}
		set
		{
			PlayerPrefs.SetFloat("VersionNumber", value);
		}
	}

	public static int Biology
	{
		get
		{
			return PlayerPrefs.GetInt("Biology");
		}
		set
		{
			PlayerPrefs.SetInt("Biology", value);
		}
	}

	public static int BiologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("BiologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("BiologyBonus", value);
		}
	}

	public static int BiologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("BiologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("BiologyGrade", value);
		}
	}

	public static int Chemistry
	{
		get
		{
			return PlayerPrefs.GetInt("Chemistry");
		}
		set
		{
			PlayerPrefs.SetInt("Chemistry", value);
		}
	}

	public static int ChemistryBonus
	{
		get
		{
			return PlayerPrefs.GetInt("ChemistryBonus");
		}
		set
		{
			PlayerPrefs.SetInt("ChemistryBonus", value);
		}
	}

	public static int ChemistryGrade
	{
		get
		{
			return PlayerPrefs.GetInt("ChemistryGrade");
		}
		set
		{
			PlayerPrefs.SetInt("ChemistryGrade", value);
		}
	}

	public static int Language
	{
		get
		{
			return PlayerPrefs.GetInt("Language");
		}
		set
		{
			PlayerPrefs.SetInt("Language", value);
		}
	}

	public static int LanguageBonus
	{
		get
		{
			return PlayerPrefs.GetInt("LanguageBonus");
		}
		set
		{
			PlayerPrefs.SetInt("LanguageBonus", value);
		}
	}

	public static int LanguageGrade
	{
		get
		{
			return PlayerPrefs.GetInt("LanguageGrade");
		}
		set
		{
			PlayerPrefs.SetInt("LanguageGrade", value);
		}
	}

	public static int Physical
	{
		get
		{
			return PlayerPrefs.GetInt("Physical");
		}
		set
		{
			PlayerPrefs.SetInt("Physical", value);
		}
	}

	public static int PhysicalBonus
	{
		get
		{
			return PlayerPrefs.GetInt("PhysicalBonus");
		}
		set
		{
			PlayerPrefs.SetInt("PhysicalBonus", value);
		}
	}

	public static int PhysicalGrade
	{
		get
		{
			return PlayerPrefs.GetInt("PhysicalGrade");
		}
		set
		{
			PlayerPrefs.SetInt("PhysicalGrade", value);
		}
	}

	public static int Psychology
	{
		get
		{
			return PlayerPrefs.GetInt("Psychology");
		}
		set
		{
			PlayerPrefs.SetInt("Psychology", value);
		}
	}

	public static int PsychologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("PsychologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("PsychologyBonus", value);
		}
	}

	public static int PsychologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("PsychologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("PsychologyGrade", value);
		}
	}

	public static ClubType Club
	{
		get
		{
			return Globals.GlobalsHelper.GetEnum<ClubType>("Club");
		}
		set
		{
			Globals.GlobalsHelper.SetEnum<ClubType>("Club", value);
		}
	}

	public static bool GetClubClosed(ClubType clubID)
	{
		string str = "ClubClosed_";
		int num = (int)clubID;
		return Globals.GlobalsHelper.GetBool(str + num.ToString());
	}

	public static void SetClubClosed(ClubType clubID, bool value)
	{
		int num = (int)clubID;
		string text = num.ToString();
		Globals.KeysHelper.AddIfMissing("ClubClosed_", text);
		Globals.GlobalsHelper.SetBool("ClubClosed_" + text, value);
	}

	public static ClubType[] KeysOfClubClosed()
	{
		return Globals.KeysHelper.GetKeys<ClubType>("ClubClosed_");
	}

	public static bool GetClubKicked(ClubType clubID)
	{
		string str = "ClubKicked_";
		int num = (int)clubID;
		return Globals.GlobalsHelper.GetBool(str + num.ToString());
	}

	public static void SetClubKicked(ClubType clubID, bool value)
	{
		string str = "ClubKicked_";
		int num = (int)clubID;
		Globals.GlobalsHelper.SetBool(str + num.ToString(), value);
	}

	public static bool GetQuitClub(ClubType clubID)
	{
		string str = "QuitClub_";
		int num = (int)clubID;
		return Globals.GlobalsHelper.GetBool(str + num.ToString());
	}

	public static void SetQuitClub(ClubType clubID, bool value)
	{
		string str = "QuitClub_";
		int num = (int)clubID;
		Globals.GlobalsHelper.SetBool(str + num.ToString(), value);
	}

	public static bool GetBasementTapeCollected(int tapeID)
	{
		return Globals.GlobalsHelper.GetBool("BasementTapeCollected_" + tapeID.ToString());
	}

	public static void SetBasementTapeCollected(int tapeID, bool value)
	{
		Globals.GlobalsHelper.SetBool("BasementTapeCollected_" + tapeID.ToString(), value);
	}

	public static bool GetBasementTapeListened(int tapeID)
	{
		return Globals.GlobalsHelper.GetBool("BasementTapeListened_" + tapeID.ToString());
	}

	public static void SetBasementTapeListened(int tapeID, bool value)
	{
		Globals.GlobalsHelper.SetBool("BasementTapeListened_" + tapeID.ToString(), value);
	}

	public static bool GetMangaCollected(int mangaID)
	{
		return Globals.GlobalsHelper.GetBool("MangaCollected_" + mangaID.ToString());
	}

	public static void SetMangaCollected(int mangaID, bool value)
	{
		Globals.GlobalsHelper.SetBool("MangaCollected_" + mangaID.ToString(), value);
	}

	public static bool GetTapeCollected(int tapeID)
	{
		return Globals.GlobalsHelper.GetBool("TapeCollected_" + tapeID.ToString());
	}

	public static void SetTapeCollected(int tapeID, bool value)
	{
		Globals.GlobalsHelper.SetBool("TapeCollected_" + tapeID.ToString(), value);
	}

	public static bool GetTapeListened(int tapeID)
	{
		return Globals.GlobalsHelper.GetBool("TapeListened_" + tapeID.ToString());
	}

	public static void SetTapeListened(int tapeID, bool value)
	{
		Globals.GlobalsHelper.SetBool("TapeListened_" + tapeID.ToString(), value);
	}

	public static bool GetTopicDiscovered(int topicID)
	{
		return Globals.GlobalsHelper.GetBool("TopicDiscovered_" + topicID.ToString());
	}

	public static void SetTopicDiscovered(int topicID, bool value)
	{
		Globals.GlobalsHelper.SetBool("TopicDiscovered_" + topicID.ToString(), value);
	}

	public static bool GetTopicLearnedByStudent(int topicID, int studentID)
	{
		return Globals.GlobalsHelper.GetBool("TopicLearnedByStudent_" + topicID.ToString() + "_" + studentID.ToString());
	}

	public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("TopicLearnedByStudent_" + topicID.ToString() + "_" + studentID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("ComplimentGiven_" + complimentID.ToString());
	}

	public static void SetComplimentGiven(int complimentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("ComplimentGiven_" + complimentID.ToString(), value);
	}

	public static bool GetSuitorCheck(int checkID)
	{
		return Globals.GlobalsHelper.GetBool("SuitorCheck_" + checkID.ToString());
	}

	public static void SetSuitorCheck(int checkID, bool value)
	{
		Globals.GlobalsHelper.SetBool("SuitorCheck_" + checkID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("TopicDiscussed_" + topicID.ToString());
	}

	public static void SetTopicDiscussed(int topicID, bool value)
	{
		Globals.GlobalsHelper.SetBool("TopicDiscussed_" + topicID.ToString(), value);
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
			return Globals.GlobalsHelper.GetBool("BefriendConversation");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("BefriendConversation", value);
		}
	}

	public static bool KidnapConversation
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("KidnapConversation");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("KidnapConversation", value);
		}
	}

	public static bool Event1
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("Event1");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("Event1", value);
		}
	}

	public static bool Event2
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("Event2");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("Event2", value);
		}
	}

	public static bool LivingRoom
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("LivingRoom");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("LivingRoom", value);
		}
	}

	public static bool LoveSick
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("LoveSick");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("LoveSick", value);
		}
	}

	public static bool MasksBanned
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("MasksBanned");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("MasksBanned", value);
		}
	}

	public static bool Paranormal
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("Paranormal");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("Paranormal", value);
		}
	}

	public static bool LateForSchool
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("LateForSchool");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("LateForSchool", value);
		}
	}

	public static bool Night
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("Night");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("Night", value);
		}
	}

	public static bool StartInBasement
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("StartInBasement");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("StartInBasement", value);
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
			return Globals.GlobalsHelper.GetBool("MissionMode");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("MissionMode", value);
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
			return Globals.GlobalsHelper.GetBool("DisableBloom");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DisableBloom", value);
		}
	}

	public static bool DisableFarAnimations
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("DisableFarAnimations");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DisableFarAnimations", value);
		}
	}

	public static bool DisableOutlines
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("DisableOutlines");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DisableOutlines", value);
		}
	}

	public static bool DisablePostAliasing
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("DisablePostAliasing");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DisablePostAliasing", value);
		}
	}

	public static bool DisableShadows
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("DisableShadows");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DisableShadows", value);
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
			return Globals.GlobalsHelper.GetBool("Fog");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("Fog", value);
		}
	}

	public static bool HighPopulation
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("HighPopulation");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("HighPopulation", value);
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
			return Globals.GlobalsHelper.GetBool("Headset");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("Headset", value);
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
		return Globals.GlobalsHelper.GetBool("Photo_" + photoID.ToString());
	}

	public static void SetPhoto(int photoID, bool value)
	{
		Globals.GlobalsHelper.SetBool("Photo_" + photoID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("SenpaiPhoto_" + photoID.ToString());
	}

	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		Globals.GlobalsHelper.SetBool("SenpaiPhoto_" + photoID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("StudentFriend_" + studentID.ToString());
	}

	public static void SetStudentFriend(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentFriend_" + studentID.ToString(), value);
	}

	public static bool GetStudentPantyShot(string studentName)
	{
		return Globals.GlobalsHelper.GetBool("StudentPantyShot_" + studentName);
	}

	public static void SetStudentPantyShot(string studentName, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentPantyShot_" + studentName, value);
	}

	public static Vector3 PosePosition
	{
		get
		{
			return Globals.GlobalsHelper.GetVector3("PosePosition");
		}
		set
		{
			Globals.GlobalsHelper.SetVector3("PosePosition", value);
		}
	}

	public static Vector3 PoseRotation
	{
		get
		{
			return Globals.GlobalsHelper.GetVector3("PoseRotation");
		}
		set
		{
			Globals.GlobalsHelper.SetVector3("PoseRotation", value);
		}
	}

	public static Vector3 PoseScale
	{
		get
		{
			return Globals.GlobalsHelper.GetVector3("PoseScale");
		}
		set
		{
			Globals.GlobalsHelper.SetVector3("PoseScale", value);
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
			return Globals.GlobalsHelper.GetBool("DarkSecret");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DarkSecret", value);
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
		return Globals.GlobalsHelper.GetBool("SchemeStatus_" + schemeID.ToString());
	}

	public static void SetSchemeStatus(int schemeID, bool value)
	{
		Globals.GlobalsHelper.SetBool("SchemeStatus_" + schemeID.ToString(), value);
	}

	public static bool GetSchemeUnlocked(int schemeID)
	{
		return Globals.GlobalsHelper.GetBool("SchemeUnlocked_" + schemeID.ToString());
	}

	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		Globals.GlobalsHelper.SetBool("SchemeUnlocked_" + schemeID.ToString(), value);
	}

	public static bool GetServicePurchased(int serviceID)
	{
		return Globals.GlobalsHelper.GetBool("ServicePurchased_" + serviceID.ToString());
	}

	public static void SetServicePurchased(int serviceID, bool value)
	{
		Globals.GlobalsHelper.SetBool("ServicePurchased_" + serviceID.ToString(), value);
	}

	public static bool GetDemonActive(int demonID)
	{
		return Globals.GlobalsHelper.GetBool("DemonActive_" + demonID.ToString());
	}

	public static void SetDemonActive(int demonID, bool value)
	{
		Globals.GlobalsHelper.SetBool("DemonActive_" + demonID.ToString(), value);
	}

	public static bool GetGardenGraveOccupied(int graveID)
	{
		return Globals.GlobalsHelper.GetBool("GardenGraveOccupied_" + graveID.ToString());
	}

	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		Globals.GlobalsHelper.SetBool("GardenGraveOccupied_" + graveID.ToString(), value);
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
			return Globals.GlobalsHelper.GetBool("RoofFence");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("RoofFence", value);
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
			return Globals.GlobalsHelper.GetBool("SchoolAtmosphereSet");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("SchoolAtmosphereSet", value);
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
			return Globals.GlobalsHelper.GetBool("SCP");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("SCP", value);
		}
	}

	public static bool CustomSenpai
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("CustomSenpai");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("CustomSenpai", value);
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
			return Globals.GlobalsHelper.GetBool("CustomSuitor");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("CustomSuitor", value);
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
			return Globals.GlobalsHelper.GetBool("CustomSuitorTan");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("CustomSuitorTan", value);
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
		return Globals.GlobalsHelper.GetBool("StudentArrested_" + studentID.ToString());
	}

	public static void SetStudentArrested(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentArrested_" + studentID.ToString(), value);
	}

	public static bool GetStudentBroken(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentBroken_" + studentID.ToString());
	}

	public static void SetStudentBroken(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentBroken_" + studentID.ToString(), value);
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
		return Globals.GlobalsHelper.GetColor("StudentColor_" + studentID.ToString());
	}

	public static void SetStudentColor(int studentID, Color value)
	{
		Globals.GlobalsHelper.SetColor("StudentColor_" + studentID.ToString(), value);
	}

	public static bool GetStudentDead(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentDead_" + studentID.ToString());
	}

	public static void SetStudentDead(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentDead_" + studentID.ToString(), value);
	}

	public static bool GetStudentDying(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentDying_" + studentID.ToString());
	}

	public static void SetStudentDying(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentDying_" + studentID.ToString(), value);
	}

	public static bool GetStudentExpelled(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentExpelled_" + studentID.ToString());
	}

	public static void SetStudentExpelled(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentExpelled_" + studentID.ToString(), value);
	}

	public static bool GetStudentExposed(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentExposed_" + studentID.ToString());
	}

	public static void SetStudentExposed(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentExposed_" + studentID.ToString(), value);
	}

	public static Color GetStudentEyeColor(int studentID)
	{
		return Globals.GlobalsHelper.GetColor("StudentEyeColor_" + studentID.ToString());
	}

	public static void SetStudentEyeColor(int studentID, Color value)
	{
		Globals.GlobalsHelper.SetColor("StudentEyeColor_" + studentID.ToString(), value);
	}

	public static bool GetStudentGrudge(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentGrudge_" + studentID.ToString());
	}

	public static void SetStudentGrudge(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentGrudge_" + studentID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("StudentKidnapped_" + studentID.ToString());
	}

	public static void SetStudentKidnapped(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentKidnapped_" + studentID.ToString(), value);
	}

	public static bool GetStudentMissing(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentMissing_" + studentID.ToString());
	}

	public static void SetStudentMissing(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentMissing_" + studentID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("StudentPhotographed_" + studentID.ToString());
	}

	public static void SetStudentPhotographed(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentPhotographed_" + studentID.ToString(), value);
	}

	public static bool GetStudentReplaced(int studentID)
	{
		return Globals.GlobalsHelper.GetBool("StudentReplaced_" + studentID.ToString());
	}

	public static void SetStudentReplaced(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentReplaced_" + studentID.ToString(), value);
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
		return Globals.GlobalsHelper.GetBool("StudentSlave_" + studentID.ToString());
	}

	public static void SetStudentSlave(int studentID, bool value)
	{
		Globals.GlobalsHelper.SetBool("StudentSlave_" + studentID.ToString(), value);
	}

	public static bool GetKittenPhoto(int photoID)
	{
		return Globals.GlobalsHelper.GetBool("KittenPhoto_" + photoID.ToString());
	}

	public static void SetKittenPhoto(int photoID, bool value)
	{
		Globals.GlobalsHelper.SetBool("KittenPhoto_" + photoID.ToString(), value);
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
			return Globals.GlobalsHelper.GetBool("DraculaDefeated");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("DraculaDefeated", value);
		}
	}

	public static bool MidoriEasterEgg
	{
		get
		{
			return Globals.GlobalsHelper.GetBool("MidoriEasterEgg");
		}
		set
		{
			Globals.GlobalsHelper.SetBool("MidoriEasterEgg", value);
		}
	}
}
