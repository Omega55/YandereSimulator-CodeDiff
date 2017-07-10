using System;
using UnityEngine;

public class SubtitleScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public Transform Yandere;

	public UILabel Label;

	public string[] WeaponBloodInsanityReactions;

	public string[] WeaponBloodReactions;

	public string[] WeaponInsanityReactions;

	public string[] BloodInsanityReactions;

	public string[] BloodReactions;

	public string[] WetBloodReactions;

	public string[] InsanityReactions;

	public string[] LewdReactions;

	public string[] MurderReactions;

	public string[] CowardMurderReactions;

	public string[] EvilMurderReactions;

	public string[] PetMurderReports;

	public string[] PetMurderReactions;

	public string[] PetCorpseReports;

	public string[] PetCorpseReactions;

	public string[] HeroMurderReactions;

	public string[] LonerMurderReactions;

	public string[] LonerCorpseReactions;

	public string[] SocialDeathReactions;

	public string[] SocialReports;

	public string[] SocialFears;

	public string[] SocialTerrors;

	public string[] RepeatReactions;

	public string[] CorpseReactions;

	public string[] PrankReactions;

	public string[] InterruptReactions;

	public string[] NoteReactions;

	public string[] FoodAccepts;

	public string[] FoodRejects;

	public string[] EavesdropReactions;

	public string[] PickpocketReactions;

	public string[] DrownReactions;

	public string[] KnifeReactions;

	public string[] SyringeReactions;

	public string[] KatanaReactions;

	public string[] SawReactions;

	public string[] RitualReactions;

	public string[] BatReactions;

	public string[] ShovelReactions;

	public string[] DumbbellReactions;

	public string[] AxeReactions;

	public string[] WeaponBloodApologies;

	public string[] WeaponApologies;

	public string[] BloodApologies;

	public string[] InsanityApologies;

	public string[] LewdApologies;

	public string[] EventApologies;

	public string[] ClassApologies;

	public string[] AccidentApologies;

	public string[] Greetings;

	public string[] PlayerFarewells;

	public string[] StudentFarewells;

	public string[] Forgivings;

	public string[] AccidentForgivings;

	public string[] InsanityForgivings;

	public string[] PlayerCompliments;

	public string[] StudentCompliments;

	public string[] PlayerGossip;

	public string[] StudentGossip;

	public string[] PlayerFollows;

	public string[] StudentFollows;

	public string[] PlayerLeaves;

	public string[] StudentLeaves;

	public string[] StudentStays;

	public string[] PlayerDistracts;

	public string[] StudentDistracts;

	public string[] StudentDistractRefuses;

	public string[] StopFollowApologies;

	public string[] GrudgeWarnings;

	public string[] GrudgeRefusals;

	public string[] CowardGrudges;

	public string[] EvilGrudges;

	public string[] PlayerLove;

	public string[] SuitorLove;

	public string[] RivalLove;

	public string[] Impatiences;

	public string[] ImpatientFarewells;

	public string[] Deaths;

	public string[] SenpaiInsanityReactions;

	public string[] SenpaiWeaponReactions;

	public string[] SenpaiBloodReactions;

	public string[] SenpaiLewdReactions;

	public string[] SenpaiStalkingReactions;

	public string[] SenpaiMurderReactions;

	public string[] SenpaiCorpseReactions;

	public string[] TeacherInsanityReactions;

	public string[] TeacherWeaponReactions;

	public string[] TeacherBloodReactions;

	public string[] TeacherInsanityHostiles;

	public string[] TeacherWeaponHostiles;

	public string[] TeacherBloodHostiles;

	public string[] TeacherLewdReactions;

	public string[] TeacherTrespassReactions;

	public string[] TeacherLateReactions;

	public string[] TeacherReportReactions;

	public string[] TeacherCorpseReactions;

	public string[] TeacherCorpseInspections;

	public string[] TeacherPoliceReports;

	public string[] TeacherAttackReactions;

	public string[] TeacherMurderReactions;

	public string[] TeacherPrankReactions;

	public string[] TeacherTheftReactions;

	public string[] StudentMurderReports;

	public string[] YandereWhimpers;

	public string[] SplashReactions;

	public string[] LightSwitchReactions;

	public string[] Task6Lines;

	public string[] Task7Lines;

	public string[] Task13Lines;

	public string[] Task14Lines;

	public string[] Task15Lines;

	public string[] Task32Lines;

	public string[] Task33Lines;

	public string[] Task34Lines;

	public string[] Club3Info;

	public string[] Club6Info;

	public string[] ClubGreetings;

	public string[] ClubUnwelcomes;

	public string[] ClubKicks;

	public string[] ClubJoins;

	public string[] ClubAccepts;

	public string[] ClubRefuses;

	public string[] ClubRejoins;

	public string[] ClubExclusives;

	public string[] ClubGrudges;

	public string[] ClubQuits;

	public string[] ClubConfirms;

	public string[] ClubDenies;

	public string[] ClubFarewells;

	public string[] ClubActivities;

	public string[] ClubEarlies;

	public string[] ClubLates;

	public string[] ClubYeses;

	public string[] ClubNoes;

	public string InfoNotice;

	public int RandomID;

	public float Timer;

	public AudioClip[] NoteReactionClips;

	public AudioClip[] GrudgeWarningClips;

	public AudioClip[] SenpaiInsanityReactionClips;

	public AudioClip[] SenpaiWeaponReactionClips;

	public AudioClip[] SenpaiBloodReactionClips;

	public AudioClip[] SenpaiLewdReactionClips;

	public AudioClip[] SenpaiStalkingReactionClips;

	public AudioClip[] SenpaiMurderReactionClips;

	public AudioClip[] YandereWhimperClips;

	public AudioClip[] TeacherWeaponClips;

	public AudioClip[] TeacherBloodClips;

	public AudioClip[] TeacherInsanityClips;

	public AudioClip[] TeacherWeaponHostileClips;

	public AudioClip[] TeacherBloodHostileClips;

	public AudioClip[] TeacherInsanityHostileClips;

	public AudioClip[] TeacherLewdClips;

	public AudioClip[] TeacherTrespassClips;

	public AudioClip[] TeacherLateClips;

	public AudioClip[] TeacherReportClips;

	public AudioClip[] TeacherCorpseClips;

	public AudioClip[] TeacherInspectClips;

	public AudioClip[] TeacherPoliceClips;

	public AudioClip[] TeacherAttackClips;

	public AudioClip[] TeacherMurderClips;

	public AudioClip[] TeacherPrankClips;

	public AudioClip[] TeacherTheftClips;

	public AudioClip[] PickpocketReactionClips;

	public AudioClip[] SplashReactionClips;

	public AudioClip[] DrownReactionClips;

	public AudioClip[] LightSwitchClips;

	public AudioClip[] Task6Clips;

	public AudioClip[] Task7Clips;

	public AudioClip[] Task13Clips;

	public AudioClip[] Task14Clips;

	public AudioClip[] Task15Clips;

	public AudioClip[] Task32Clips;

	public AudioClip[] Task33Clips;

	public AudioClip[] Task34Clips;

	public AudioClip[] Club3Clips;

	public AudioClip[] Club6Clips;

	public AudioClip[] ClubGreetingClips;

	public AudioClip[] ClubUnwelcomeClips;

	public AudioClip[] ClubKickClips;

	public AudioClip[] ClubJoinClips;

	public AudioClip[] ClubAcceptClips;

	public AudioClip[] ClubRefuseClips;

	public AudioClip[] ClubRejoinClips;

	public AudioClip[] ClubExclusiveClips;

	public AudioClip[] ClubGrudgeClips;

	public AudioClip[] ClubQuitClips;

	public AudioClip[] ClubConfirmClips;

	public AudioClip[] ClubDenyClips;

	public AudioClip[] ClubFarewellClips;

	public AudioClip[] ClubActivityClips;

	public AudioClip[] ClubEarlyClips;

	public AudioClip[] ClubLateClips;

	public AudioClip[] ClubYesClips;

	public AudioClip[] ClubNoClips;

	public AudioClip[] RivalEavesdropClips;

	public GameObject CurrentClip;

	private void Start()
	{
		this.Label.text = string.Empty;
	}

	public void UpdateLabel(string ReactionType, int ID, float Duration)
	{
		if (ReactionType == "Weapon and Blood and Insanity Reaction")
		{
			this.Label.text = this.WeaponBloodInsanityReactions[UnityEngine.Random.Range(0, this.WeaponBloodInsanityReactions.Length)];
		}
		else if (ReactionType == "Weapon and Blood Reaction")
		{
			this.Label.text = this.WeaponBloodReactions[UnityEngine.Random.Range(0, this.WeaponBloodReactions.Length)];
		}
		else if (ReactionType == "Weapon and Insanity Reaction")
		{
			this.Label.text = this.WeaponInsanityReactions[UnityEngine.Random.Range(0, this.WeaponInsanityReactions.Length)];
		}
		else if (ReactionType == "Blood and Insanity Reaction")
		{
			this.Label.text = this.BloodInsanityReactions[UnityEngine.Random.Range(0, this.BloodInsanityReactions.Length)];
		}
		else if (ReactionType == "Weapon Reaction")
		{
			if (ID == 1)
			{
				this.Label.text = this.KnifeReactions[UnityEngine.Random.Range(0, this.KnifeReactions.Length)];
			}
			else if (ID == 2)
			{
				this.Label.text = this.KatanaReactions[UnityEngine.Random.Range(0, this.KatanaReactions.Length)];
			}
			else if (ID == 3)
			{
				this.Label.text = this.SyringeReactions[UnityEngine.Random.Range(0, this.SyringeReactions.Length)];
			}
			else if (ID == 7)
			{
				this.Label.text = this.SawReactions[UnityEngine.Random.Range(0, this.SawReactions.Length)];
			}
			else if (ID == 8)
			{
				this.Label.text = this.RitualReactions[UnityEngine.Random.Range(0, this.RitualReactions.Length)];
			}
			else if (ID == 9)
			{
				this.Label.text = this.BatReactions[UnityEngine.Random.Range(0, this.BatReactions.Length)];
			}
			else if (ID == 10)
			{
				this.Label.text = this.ShovelReactions[UnityEngine.Random.Range(0, this.ShovelReactions.Length)];
			}
			else if (ID == 12)
			{
				this.Label.text = this.DumbbellReactions[UnityEngine.Random.Range(0, this.DumbbellReactions.Length)];
			}
			else if (ID == 13)
			{
				this.Label.text = this.AxeReactions[UnityEngine.Random.Range(0, this.AxeReactions.Length)];
			}
		}
		else if (ReactionType == "Blood Reaction")
		{
			this.Label.text = this.BloodReactions[UnityEngine.Random.Range(0, this.BloodReactions.Length)];
		}
		else if (ReactionType == "Wet Blood Reaction")
		{
			this.Label.text = this.WetBloodReactions[UnityEngine.Random.Range(0, this.WetBloodReactions.Length)];
		}
		else if (ReactionType == "Insanity Reaction")
		{
			this.Label.text = this.InsanityReactions[UnityEngine.Random.Range(0, this.InsanityReactions.Length)];
		}
		else if (ReactionType == "Lewd Reaction")
		{
			this.Label.text = this.LewdReactions[UnityEngine.Random.Range(0, this.LewdReactions.Length)];
		}
		else if (ReactionType == "Prank Reaction")
		{
			this.Label.text = this.PrankReactions[UnityEngine.Random.Range(0, this.PrankReactions.Length)];
		}
		else if (ReactionType == "Interruption Reaction")
		{
			this.Label.text = this.InterruptReactions[UnityEngine.Random.Range(0, this.InterruptReactions.Length)];
		}
		else if (ReactionType == "Note Reaction")
		{
			this.Label.text = this.NoteReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Accept Food")
		{
			this.Label.text = this.FoodAccepts[UnityEngine.Random.Range(0, this.FoodAccepts.Length)];
		}
		else if (ReactionType == "Reject Food")
		{
			this.Label.text = this.FoodRejects[UnityEngine.Random.Range(0, this.FoodRejects.Length)];
		}
		else if (ReactionType == "Eavesdrop Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EavesdropReactions.Length);
			this.Label.text = this.EavesdropReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Pickpocket Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PickpocketReactions.Length);
			this.Label.text = this.PickpocketReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Drown Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DrownReactions.Length);
			this.Label.text = this.DrownReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Weapon Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponReactions.Length);
			this.Label.text = this.TeacherWeaponReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Blood Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodReactions.Length);
			this.Label.text = this.TeacherBloodReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Insanity Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityReactions.Length);
			this.Label.text = this.TeacherInsanityReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Weapon Hostile")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponHostiles.Length);
			this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Blood Hostile")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodHostiles.Length);
			this.Label.text = this.TeacherBloodHostiles[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Insanity Hostile")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityHostiles.Length);
			this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Lewd Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLewdReactions.Length);
			this.Label.text = this.TeacherLewdReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Trespassing Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTrespassReactions.Length);
			this.Label.text = this.TeacherTrespassReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Late Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLateReactions.Length);
			this.Label.text = this.TeacherLateReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Report Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherReportReactions.Length);
			this.Label.text = this.TeacherReportReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Corpse Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherCorpseReactions.Length);
			this.Label.text = this.TeacherCorpseReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Corpse Inspection")
		{
			this.Label.text = this.TeacherCorpseInspections[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Police Report")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPoliceReports.Length);
			this.Label.text = this.TeacherPoliceReports[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Attack Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherAttackReactions.Length);
			this.Label.text = this.TeacherAttackReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Murder Reaction")
		{
			this.Label.text = this.TeacherMurderReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Prank Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPrankReactions.Length);
			this.Label.text = this.TeacherPrankReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Theft Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTheftReactions.Length);
			this.Label.text = this.TeacherTheftReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Murder Reaction")
		{
			this.Label.text = this.MurderReactions[UnityEngine.Random.Range(0, this.MurderReactions.Length)];
		}
		else if (ReactionType == "Corpse Reaction")
		{
			this.Label.text = this.CorpseReactions[UnityEngine.Random.Range(0, this.CorpseReactions.Length)];
		}
		else if (ReactionType == "Loner Murder Reaction")
		{
			this.Label.text = this.LonerMurderReactions[UnityEngine.Random.Range(0, this.LonerMurderReactions.Length)];
		}
		else if (ReactionType == "Loner Corpse Reaction")
		{
			this.Label.text = this.LonerCorpseReactions[UnityEngine.Random.Range(0, this.LonerCorpseReactions.Length)];
		}
		else if (ReactionType == "Pet Murder Report")
		{
			this.Label.text = this.PetMurderReports[ID];
		}
		else if (ReactionType == "Pet Murder Reaction")
		{
			this.Label.text = this.PetMurderReactions[UnityEngine.Random.Range(0, this.PetMurderReactions.Length)];
		}
		else if (ReactionType == "Pet Corpse Report")
		{
			this.Label.text = this.PetCorpseReports[ID];
		}
		else if (ReactionType == "Pet Corpse Reaction")
		{
			this.Label.text = this.PetCorpseReactions[UnityEngine.Random.Range(0, this.PetCorpseReactions.Length)];
		}
		else if (ReactionType == "Hero Murder Reaction")
		{
			this.Label.text = this.HeroMurderReactions[UnityEngine.Random.Range(0, this.HeroMurderReactions.Length)];
		}
		else if (ReactionType == "Coward Murder Reaction")
		{
			this.Label.text = this.CowardMurderReactions[UnityEngine.Random.Range(0, this.CowardMurderReactions.Length)];
		}
		else if (ReactionType == "Evil Murder Reaction")
		{
			this.Label.text = this.EvilMurderReactions[UnityEngine.Random.Range(0, this.EvilMurderReactions.Length)];
		}
		else if (ReactionType == "Social Death Reaction")
		{
			this.Label.text = this.SocialDeathReactions[UnityEngine.Random.Range(0, this.SocialDeathReactions.Length)];
		}
		else if (ReactionType == "Social Report")
		{
			this.Label.text = this.SocialReports[UnityEngine.Random.Range(0, this.SocialReports.Length)];
		}
		else if (ReactionType == "Social Fear")
		{
			this.Label.text = this.SocialFears[UnityEngine.Random.Range(0, this.SocialFears.Length)];
		}
		else if (ReactionType == "Social Terror")
		{
			this.Label.text = this.SocialTerrors[UnityEngine.Random.Range(0, this.SocialTerrors.Length)];
		}
		else if (ReactionType == "Repeat Reaction")
		{
			this.Label.text = this.RepeatReactions[UnityEngine.Random.Range(0, this.RepeatReactions.Length)];
		}
		else if (ReactionType == "Greeting")
		{
			this.Label.text = this.Greetings[UnityEngine.Random.Range(0, this.Greetings.Length)];
		}
		else if (ReactionType == "Player Farewell")
		{
			this.Label.text = this.PlayerFarewells[UnityEngine.Random.Range(0, this.PlayerFarewells.Length)];
		}
		else if (ReactionType == "Student Farewell")
		{
			this.Label.text = this.StudentFarewells[UnityEngine.Random.Range(0, this.StudentFarewells.Length)];
		}
		else if (ReactionType == "Insanity Apology")
		{
			this.Label.text = this.InsanityApologies[UnityEngine.Random.Range(0, this.InsanityApologies.Length)];
		}
		else if (ReactionType == "Weapon and Blood Apology")
		{
			this.Label.text = this.WeaponBloodApologies[UnityEngine.Random.Range(0, this.WeaponBloodApologies.Length)];
		}
		else if (ReactionType == "Weapon Apology")
		{
			this.Label.text = this.WeaponApologies[UnityEngine.Random.Range(0, this.WeaponApologies.Length)];
		}
		else if (ReactionType == "Blood Apology")
		{
			this.Label.text = this.BloodApologies[UnityEngine.Random.Range(0, this.BloodApologies.Length)];
		}
		else if (ReactionType == "Lewd Apology")
		{
			this.Label.text = this.LewdApologies[UnityEngine.Random.Range(0, this.LewdApologies.Length)];
		}
		else if (ReactionType == "Event Apology")
		{
			this.Label.text = this.EventApologies[UnityEngine.Random.Range(0, this.EventApologies.Length)];
		}
		else if (ReactionType == "Class Apology")
		{
			this.Label.text = this.ClassApologies[UnityEngine.Random.Range(0, this.ClassApologies.Length)];
		}
		else if (ReactionType == "Accident Apology")
		{
			this.Label.text = this.AccidentApologies[UnityEngine.Random.Range(0, this.AccidentApologies.Length)];
		}
		else if (ReactionType == "Forgiving")
		{
			this.Label.text = this.Forgivings[UnityEngine.Random.Range(0, this.Forgivings.Length)];
		}
		else if (ReactionType == "Forgiving Accident")
		{
			this.Label.text = this.AccidentForgivings[UnityEngine.Random.Range(0, this.AccidentForgivings.Length)];
		}
		else if (ReactionType == "Forgiving Insanity")
		{
			this.Label.text = this.InsanityForgivings[UnityEngine.Random.Range(0, this.InsanityForgivings.Length)];
		}
		else if (ReactionType == "Impatience")
		{
			if (ID == 1)
			{
				this.Label.text = this.Impatiences[UnityEngine.Random.Range(0, this.Impatiences.Length)];
			}
			else
			{
				this.Label.text = this.ImpatientFarewells[UnityEngine.Random.Range(0, this.ImpatientFarewells.Length)];
			}
		}
		else if (ReactionType == "Player Compliment")
		{
			this.Label.text = this.PlayerCompliments[UnityEngine.Random.Range(0, this.PlayerCompliments.Length)];
		}
		else if (ReactionType == "Student Compliment")
		{
			this.Label.text = this.StudentCompliments[UnityEngine.Random.Range(0, this.StudentCompliments.Length)];
		}
		else if (ReactionType == "Player Gossip")
		{
			this.Label.text = this.PlayerGossip[UnityEngine.Random.Range(0, this.PlayerGossip.Length)];
		}
		else if (ReactionType == "Student Gossip")
		{
			this.Label.text = this.StudentGossip[UnityEngine.Random.Range(0, this.PlayerGossip.Length)];
		}
		else if (ReactionType == "Player Follow")
		{
			this.Label.text = this.PlayerFollows[UnityEngine.Random.Range(0, this.PlayerFollows.Length)];
		}
		else if (ReactionType == "Student Follow")
		{
			this.Label.text = this.StudentFollows[UnityEngine.Random.Range(0, this.StudentFollows.Length)];
		}
		else if (ReactionType == "Player Leave")
		{
			this.Label.text = this.PlayerLeaves[UnityEngine.Random.Range(0, this.PlayerLeaves.Length)];
		}
		else if (ReactionType == "Student Leave")
		{
			this.Label.text = this.StudentLeaves[UnityEngine.Random.Range(0, this.StudentLeaves.Length)];
		}
		else if (ReactionType == "Student Stay")
		{
			this.Label.text = this.StudentStays[UnityEngine.Random.Range(0, this.StudentStays.Length)];
		}
		else if (ReactionType == "Player Distract")
		{
			this.Label.text = this.PlayerDistracts[UnityEngine.Random.Range(0, this.PlayerDistracts.Length)];
		}
		else if (ReactionType == "Student Distract")
		{
			this.Label.text = this.StudentDistracts[UnityEngine.Random.Range(0, this.StudentDistracts.Length)];
		}
		else if (ReactionType == "Student Distract Refuse")
		{
			this.Label.text = this.StudentDistractRefuses[UnityEngine.Random.Range(0, this.StudentDistractRefuses.Length)];
		}
		else if (ReactionType == "Stop Follow Apology")
		{
			this.Label.text = this.StopFollowApologies[UnityEngine.Random.Range(0, this.StopFollowApologies.Length)];
		}
		else if (ReactionType == "Grudge Warning")
		{
			this.Label.text = this.GrudgeWarnings[UnityEngine.Random.Range(0, this.GrudgeWarnings.Length)];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Grudge Refusal")
		{
			this.Label.text = this.GrudgeRefusals[UnityEngine.Random.Range(0, this.GrudgeRefusals.Length)];
		}
		else if (ReactionType == "Coward Grudge")
		{
			this.Label.text = this.CowardGrudges[UnityEngine.Random.Range(0, this.CowardGrudges.Length)];
		}
		else if (ReactionType == "Evil Grudge")
		{
			this.Label.text = this.EvilGrudges[UnityEngine.Random.Range(0, this.EvilGrudges.Length)];
		}
		else if (ReactionType == "Player Love")
		{
			this.Label.text = this.PlayerLove[ID];
		}
		else if (ReactionType == "Suitor Love")
		{
			this.Label.text = this.SuitorLove[ID];
		}
		else if (ReactionType == "Rival Love")
		{
			this.Label.text = this.RivalLove[ID];
		}
		else if (ReactionType == "Dying")
		{
			this.Label.text = this.Deaths[UnityEngine.Random.Range(0, this.Deaths.Length)];
		}
		else if (ReactionType == "Senpai Insanity Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiInsanityReactions.Length);
			this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Weapon Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiWeaponReactions.Length);
			this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Blood Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiBloodReactions.Length);
			this.Label.text = this.SenpaiBloodReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Lewd Reaction")
		{
			this.Label.text = this.SenpaiLewdReactions[UnityEngine.Random.Range(0, this.SenpaiLewdReactions.Length)];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Stalking Reaction")
		{
			this.Label.text = this.SenpaiStalkingReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Senpai Murder Reaction")
		{
			this.Label.text = this.SenpaiMurderReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Senpai Corpse Reaction")
		{
			this.Label.text = this.SenpaiCorpseReactions[UnityEngine.Random.Range(0, this.SenpaiCorpseReactions.Length)];
		}
		else if (ReactionType == "Yandere Whimper")
		{
			this.RandomID = UnityEngine.Random.Range(0, this.YandereWhimpers.Length);
			this.Label.text = this.YandereWhimpers[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Student Murder Report")
		{
			this.Label.text = this.StudentMurderReports[ID];
		}
		else if (ReactionType == "Social Report")
		{
			this.Label.text = this.SocialReports[ID];
		}
		else if (ReactionType == "Splash Reaction")
		{
			this.Label.text = this.SplashReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Light Switch Reaction")
		{
			this.Label.text = this.LightSwitchReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 6 Line")
		{
			this.Label.text = this.Task6Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 7 Line")
		{
			this.Label.text = this.Task7Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 13 Line")
		{
			this.Label.text = this.Task13Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 14 Line")
		{
			this.Label.text = this.Task14Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 15 Line")
		{
			this.Label.text = this.Task15Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 32 Line")
		{
			this.Label.text = this.Task32Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 33 Line")
		{
			this.Label.text = this.Task33Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Task 34 Line")
		{
			this.Label.text = this.Task34Lines[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Greeting")
		{
			this.Label.text = this.ClubGreetings[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Unwelcome")
		{
			this.Label.text = this.ClubUnwelcomes[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Kick")
		{
			this.Label.text = this.ClubKicks[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club 3 Info")
		{
			this.Label.text = this.Club3Info[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club 6 Info")
		{
			this.Label.text = this.Club6Info[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Join")
		{
			this.Label.text = this.ClubJoins[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Accept")
		{
			this.Label.text = this.ClubAccepts[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Refuse")
		{
			this.Label.text = this.ClubRefuses[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Rejoin")
		{
			this.Label.text = this.ClubRejoins[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Exclusive")
		{
			this.Label.text = this.ClubExclusives[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Grudge")
		{
			this.Label.text = this.ClubGrudges[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Quit")
		{
			this.Label.text = this.ClubQuits[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Confirm")
		{
			this.Label.text = this.ClubConfirms[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Deny")
		{
			this.Label.text = this.ClubDenies[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Farewell")
		{
			this.Label.text = this.ClubFarewells[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Activity")
		{
			this.Label.text = this.ClubActivities[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Early")
		{
			this.Label.text = this.ClubEarlies[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Late")
		{
			this.Label.text = this.ClubLates[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club Yes")
		{
			this.Label.text = this.ClubYeses[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Club No")
		{
			this.Label.text = this.ClubNoes[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Info Notice")
		{
			this.Label.text = this.InfoNotice;
		}
		this.Timer = Duration;
	}

	private void Update()
	{
		if (this.Timer > 0f)
		{
			this.Timer -= Time.deltaTime;
			if (this.Timer <= 0f)
			{
				this.Jukebox.Dip = 1f;
				this.Label.text = string.Empty;
				this.Timer = 0f;
			}
		}
	}

	private void PlayVoice(string ReactionType, int ID)
	{
		if (this.CurrentClip != null)
		{
			UnityEngine.Object.Destroy(this.CurrentClip);
		}
		this.Jukebox.Dip = 0.5f;
		if (ReactionType == "Note Reaction")
		{
			this.PlayClip(this.NoteReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Grudge Warning")
		{
			this.PlayClip(this.GrudgeWarningClips[ID], base.transform.position);
		}
		else if (ReactionType == "Senpai Insanity Reaction")
		{
			this.PlayClip(this.SenpaiInsanityReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Senpai Weapon Reaction")
		{
			this.PlayClip(this.SenpaiWeaponReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Senpai Blood Reaction")
		{
			this.PlayClip(this.SenpaiBloodReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Senpai Lewd Reaction")
		{
			this.PlayClip(this.SenpaiLewdReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Senpai Stalking Reaction")
		{
			this.PlayClip(this.SenpaiStalkingReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Senpai Murder Reaction")
		{
			this.PlayClip(this.SenpaiMurderReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Yandere Whimper")
		{
			this.PlayClip(this.YandereWhimperClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Weapon Reaction")
		{
			this.PlayClip(this.TeacherWeaponClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Blood Reaction")
		{
			this.PlayClip(this.TeacherBloodClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Insanity Reaction")
		{
			this.PlayClip(this.TeacherInsanityClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Weapon Hostile")
		{
			this.PlayClip(this.TeacherWeaponHostileClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Blood Hostile")
		{
			this.PlayClip(this.TeacherBloodHostileClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Insanity Hostile")
		{
			this.PlayClip(this.TeacherInsanityHostileClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Lewd Reaction")
		{
			this.PlayClip(this.TeacherLewdClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Trespassing Reaction")
		{
			this.PlayClip(this.TeacherTrespassClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Late Reaction")
		{
			this.PlayClip(this.TeacherLateClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Report Reaction")
		{
			this.PlayClip(this.TeacherReportClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Corpse Reaction")
		{
			this.PlayClip(this.TeacherCorpseClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Corpse Inspection")
		{
			this.PlayClip(this.TeacherInspectClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Police Report")
		{
			this.PlayClip(this.TeacherPoliceClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Attack Reaction")
		{
			this.PlayClip(this.TeacherAttackClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Murder Reaction")
		{
			this.PlayClip(this.TeacherMurderClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Prank Reaction")
		{
			this.PlayClip(this.TeacherPrankClips[ID], base.transform.position);
		}
		else if (ReactionType == "Teacher Theft Reaction")
		{
			this.PlayClip(this.TeacherTheftClips[ID], base.transform.position);
		}
		else if (ReactionType == "Pickpocket Reaction")
		{
			this.PlayClip(this.PickpocketReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Splash Reaction")
		{
			this.PlayClip(this.SplashReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Drown Reaction")
		{
			this.PlayClip(this.DrownReactionClips[ID], base.transform.position);
		}
		else if (ReactionType == "Light Switch Reaction")
		{
			this.PlayClip(this.LightSwitchClips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 6 Line")
		{
			this.PlayClip(this.Task6Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 7 Line")
		{
			this.PlayClip(this.Task7Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 13 Line")
		{
			this.PlayClip(this.Task13Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 14 Line")
		{
			this.PlayClip(this.Task14Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 15 Line")
		{
			this.PlayClip(this.Task15Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 32 Line")
		{
			this.PlayClip(this.Task32Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 33 Line")
		{
			this.PlayClip(this.Task33Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Task 34 Line")
		{
			this.PlayClip(this.Task34Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Greeting")
		{
			this.PlayClip(this.ClubGreetingClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Unwelcome")
		{
			this.PlayClip(this.ClubUnwelcomeClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Kick")
		{
			this.PlayClip(this.ClubKickClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Join")
		{
			this.PlayClip(this.ClubJoinClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Accept")
		{
			this.PlayClip(this.ClubAcceptClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Refuse")
		{
			this.PlayClip(this.ClubRefuseClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Exclusive")
		{
			this.PlayClip(this.ClubExclusiveClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Grudge")
		{
			this.PlayClip(this.ClubGrudgeClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Rejoin")
		{
			this.PlayClip(this.ClubRejoinClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Quit")
		{
			this.PlayClip(this.ClubQuitClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Confirm")
		{
			this.PlayClip(this.ClubConfirmClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Deny")
		{
			this.PlayClip(this.ClubDenyClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Farewell")
		{
			this.PlayClip(this.ClubFarewellClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Activity")
		{
			this.PlayClip(this.ClubActivityClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Early")
		{
			this.PlayClip(this.ClubEarlyClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Late")
		{
			this.PlayClip(this.ClubLateClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club Yes")
		{
			this.PlayClip(this.ClubYesClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club No")
		{
			this.PlayClip(this.ClubNoClips[ID], base.transform.position);
		}
		else if (ReactionType == "Club 3 Info")
		{
			this.PlayClip(this.Club3Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Club 6 Info")
		{
			this.PlayClip(this.Club6Clips[ID], base.transform.position);
		}
		else if (ReactionType == "Eavesdrop Reaction")
		{
			this.PlayClip(this.RivalEavesdropClips[ID], base.transform.position);
		}
	}

	public float GetClipLength(int StudentID, int TaskPhase)
	{
		if (StudentID == 6)
		{
			return this.Task6Clips[TaskPhase].length;
		}
		if (StudentID == 7)
		{
			return this.Task7Clips[TaskPhase].length;
		}
		if (StudentID == 13)
		{
			return this.Task13Clips[TaskPhase].length;
		}
		if (StudentID == 14)
		{
			return this.Task14Clips[TaskPhase].length;
		}
		if (StudentID == 15)
		{
			return this.Task15Clips[TaskPhase].length;
		}
		if (StudentID == 32)
		{
			return this.Task32Clips[TaskPhase].length;
		}
		if (StudentID == 33)
		{
			return this.Task33Clips[TaskPhase].length;
		}
		if (StudentID == 34)
		{
			return this.Task34Clips[TaskPhase].length;
		}
		return 0f;
	}

	public float GetClubClipLength(int Club, int ClubPhase)
	{
		if (Club == 3)
		{
			return this.Club3Clips[ClubPhase].length;
		}
		if (Club == 6)
		{
			return this.Club6Clips[ClubPhase].length;
		}
		return 0f;
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		if (clip != null)
		{
			GameObject gameObject = new GameObject("TempAudio");
			gameObject.transform.position = this.Yandere.transform.position + base.transform.up;
			gameObject.transform.parent = this.Yandere.transform;
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.Play();
			UnityEngine.Object.Destroy(gameObject, clip.length);
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.minDistance = 5f;
			audioSource.maxDistance = 10f;
			this.CurrentClip = gameObject;
			audioSource.volume = ((this.Yandere.position.y >= gameObject.transform.position.y - 2f) ? 1f : 0f);
		}
	}
}
