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

	public string[] EvilCorpseReactions;

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

	public string[] LostPhones;

	public string[] RivalLostPhones;

	public string[] StudentMurderReports;

	public string[] YandereWhimpers;

	public string[] SplashReactions;

	public string[] RivalSplashReactions;

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

	public AudioClip[] LostPhoneClips;

	public AudioClip[] RivalLostPhoneClips;

	public AudioClip[] PickpocketReactionClips;

	public AudioClip[] SplashReactionClips;

	public AudioClip[] RivalSplashReactionClips;

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

	private StringAndAudioClipArrayDictionary ReactionClipArrays;

	public GameObject CurrentClip;

	private void Awake()
	{
		this.ReactionClipArrays = new StringAndAudioClipArrayDictionary
		{
			{
				"Note Reaction",
				new AudioClipArrayWrapper(this.NoteReactionClips)
			},
			{
				"Grudge Warning",
				new AudioClipArrayWrapper(this.GrudgeWarningClips)
			},
			{
				"Senpai Insanity Reaction",
				new AudioClipArrayWrapper(this.SenpaiInsanityReactionClips)
			},
			{
				"Senpai Weapon Reaction",
				new AudioClipArrayWrapper(this.SenpaiWeaponReactionClips)
			},
			{
				"Senpai Blood Reaction",
				new AudioClipArrayWrapper(this.SenpaiBloodReactionClips)
			},
			{
				"Senpai Lewd Reaction",
				new AudioClipArrayWrapper(this.SenpaiLewdReactionClips)
			},
			{
				"Senpai Stalking Reaction",
				new AudioClipArrayWrapper(this.SenpaiStalkingReactionClips)
			},
			{
				"Senpai Murder Reaction",
				new AudioClipArrayWrapper(this.SenpaiMurderReactionClips)
			},
			{
				"Yandere Whimper",
				new AudioClipArrayWrapper(this.YandereWhimperClips)
			},
			{
				"Teacher Weapon Reaction",
				new AudioClipArrayWrapper(this.TeacherWeaponClips)
			},
			{
				"Teacher Blood Reaction",
				new AudioClipArrayWrapper(this.TeacherBloodClips)
			},
			{
				"Teacher Insanity Reaction",
				new AudioClipArrayWrapper(this.TeacherInsanityClips)
			},
			{
				"Teacher Weapon Hostile",
				new AudioClipArrayWrapper(this.TeacherWeaponHostileClips)
			},
			{
				"Teacher Blood Hostile",
				new AudioClipArrayWrapper(this.TeacherBloodHostileClips)
			},
			{
				"Teacher Insanity Hostile",
				new AudioClipArrayWrapper(this.TeacherInsanityHostileClips)
			},
			{
				"Teacher Lewd Reaction",
				new AudioClipArrayWrapper(this.TeacherLewdClips)
			},
			{
				"Teacher Trespassing Reaction",
				new AudioClipArrayWrapper(this.TeacherTrespassClips)
			},
			{
				"Teacher Late Reaction",
				new AudioClipArrayWrapper(this.TeacherLateClips)
			},
			{
				"Teacher Report Reaction",
				new AudioClipArrayWrapper(this.TeacherReportClips)
			},
			{
				"Teacher Corpse Reaction",
				new AudioClipArrayWrapper(this.TeacherCorpseClips)
			},
			{
				"Teacher Corpse Inspection",
				new AudioClipArrayWrapper(this.TeacherInspectClips)
			},
			{
				"Teacher Police Report",
				new AudioClipArrayWrapper(this.TeacherPoliceClips)
			},
			{
				"Teacher Attack Reaction",
				new AudioClipArrayWrapper(this.TeacherAttackClips)
			},
			{
				"Teacher Murder Reaction",
				new AudioClipArrayWrapper(this.TeacherMurderClips)
			},
			{
				"Teacher Prank Reaction",
				new AudioClipArrayWrapper(this.TeacherPrankClips)
			},
			{
				"Teacher Theft Reaction",
				new AudioClipArrayWrapper(this.TeacherTheftClips)
			},
			{
				"Lost Phone",
				new AudioClipArrayWrapper(this.LostPhoneClips)
			},
			{
				"Rival Lost Phone",
				new AudioClipArrayWrapper(this.RivalLostPhoneClips)
			},
			{
				"Pickpocket Reaction",
				new AudioClipArrayWrapper(this.PickpocketReactionClips)
			},
			{
				"Splash Reaction",
				new AudioClipArrayWrapper(this.SplashReactionClips)
			},
			{
				"Rival Splash Reaction",
				new AudioClipArrayWrapper(this.RivalSplashReactionClips)
			},
			{
				"Drown Reaction",
				new AudioClipArrayWrapper(this.DrownReactionClips)
			},
			{
				"Light Switch Reaction",
				new AudioClipArrayWrapper(this.LightSwitchClips)
			},
			{
				"Task 6 Line",
				new AudioClipArrayWrapper(this.Task6Clips)
			},
			{
				"Task 7 Line",
				new AudioClipArrayWrapper(this.Task7Clips)
			},
			{
				"Task 13 Line",
				new AudioClipArrayWrapper(this.Task13Clips)
			},
			{
				"Task 14 Line",
				new AudioClipArrayWrapper(this.Task14Clips)
			},
			{
				"Task 15 Line",
				new AudioClipArrayWrapper(this.Task15Clips)
			},
			{
				"Task 32 Line",
				new AudioClipArrayWrapper(this.Task32Clips)
			},
			{
				"Task 33 Line",
				new AudioClipArrayWrapper(this.Task33Clips)
			},
			{
				"Task 34 Line",
				new AudioClipArrayWrapper(this.Task34Clips)
			},
			{
				"Club Greeting",
				new AudioClipArrayWrapper(this.ClubGreetingClips)
			},
			{
				"Club Unwelcome",
				new AudioClipArrayWrapper(this.ClubUnwelcomeClips)
			},
			{
				"Club Kick",
				new AudioClipArrayWrapper(this.ClubKickClips)
			},
			{
				"Club Join",
				new AudioClipArrayWrapper(this.ClubJoinClips)
			},
			{
				"Club Accept",
				new AudioClipArrayWrapper(this.ClubAcceptClips)
			},
			{
				"Club Refuse",
				new AudioClipArrayWrapper(this.ClubRefuseClips)
			},
			{
				"Club Exclusive",
				new AudioClipArrayWrapper(this.ClubExclusiveClips)
			},
			{
				"Club Grudge",
				new AudioClipArrayWrapper(this.ClubGrudgeClips)
			},
			{
				"Club Rejoin",
				new AudioClipArrayWrapper(this.ClubRejoinClips)
			},
			{
				"Club Quit",
				new AudioClipArrayWrapper(this.ClubQuitClips)
			},
			{
				"Club Confirm",
				new AudioClipArrayWrapper(this.ClubConfirmClips)
			},
			{
				"Club Deny",
				new AudioClipArrayWrapper(this.ClubDenyClips)
			},
			{
				"Club Farewell",
				new AudioClipArrayWrapper(this.ClubFarewellClips)
			},
			{
				"Club Activity",
				new AudioClipArrayWrapper(this.ClubActivityClips)
			},
			{
				"Club Early",
				new AudioClipArrayWrapper(this.ClubEarlyClips)
			},
			{
				"Club Late",
				new AudioClipArrayWrapper(this.ClubLateClips)
			},
			{
				"Club Yes",
				new AudioClipArrayWrapper(this.ClubYesClips)
			},
			{
				"Club No",
				new AudioClipArrayWrapper(this.ClubNoClips)
			},
			{
				"Club 3 Info",
				new AudioClipArrayWrapper(this.Club3Clips)
			},
			{
				"Club 6 Info",
				new AudioClipArrayWrapper(this.Club6Clips)
			},
			{
				"Eavesdrop Reaction",
				new AudioClipArrayWrapper(this.RivalEavesdropClips)
			}
		};
	}

	private void Start()
	{
		this.Label.text = string.Empty;
	}

	private string GetRandomString(string[] strings)
	{
		return strings[UnityEngine.Random.Range(0, strings.Length)];
	}

	public void UpdateLabel(string ReactionType, int ID, float Duration)
	{
		if (ReactionType == "Weapon and Blood and Insanity Reaction")
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodInsanityReactions);
		}
		else if (ReactionType == "Weapon and Blood Reaction")
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodReactions);
		}
		else if (ReactionType == "Weapon and Insanity Reaction")
		{
			this.Label.text = this.GetRandomString(this.WeaponInsanityReactions);
		}
		else if (ReactionType == "Blood and Insanity Reaction")
		{
			this.Label.text = this.GetRandomString(this.BloodInsanityReactions);
		}
		else if (ReactionType == "Weapon Reaction")
		{
			if (ID == 1)
			{
				this.Label.text = this.GetRandomString(this.KnifeReactions);
			}
			else if (ID == 2)
			{
				this.Label.text = this.GetRandomString(this.KatanaReactions);
			}
			else if (ID == 3)
			{
				this.Label.text = this.GetRandomString(this.SyringeReactions);
			}
			else if (ID == 7)
			{
				this.Label.text = this.GetRandomString(this.SawReactions);
			}
			else if (ID == 8)
			{
				this.Label.text = this.GetRandomString(this.RitualReactions);
			}
			else if (ID == 9)
			{
				this.Label.text = this.GetRandomString(this.BatReactions);
			}
			else if (ID == 10)
			{
				this.Label.text = this.GetRandomString(this.ShovelReactions);
			}
			else if (ID == 12)
			{
				this.Label.text = this.GetRandomString(this.DumbbellReactions);
			}
			else if (ID == 13)
			{
				this.Label.text = this.GetRandomString(this.AxeReactions);
			}
		}
		else if (ReactionType == "Blood Reaction")
		{
			this.Label.text = this.GetRandomString(this.BloodReactions);
		}
		else if (ReactionType == "Wet Blood Reaction")
		{
			this.Label.text = this.GetRandomString(this.WetBloodReactions);
		}
		else if (ReactionType == "Insanity Reaction")
		{
			this.Label.text = this.GetRandomString(this.InsanityReactions);
		}
		else if (ReactionType == "Lewd Reaction")
		{
			this.Label.text = this.GetRandomString(this.LewdReactions);
		}
		else if (ReactionType == "Prank Reaction")
		{
			this.Label.text = this.GetRandomString(this.PrankReactions);
		}
		else if (ReactionType == "Interruption Reaction")
		{
			this.Label.text = this.GetRandomString(this.InterruptReactions);
		}
		else if (ReactionType == "Note Reaction")
		{
			this.Label.text = this.NoteReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Accept Food")
		{
			this.Label.text = this.GetRandomString(this.FoodAccepts);
		}
		else if (ReactionType == "Reject Food")
		{
			this.Label.text = this.GetRandomString(this.FoodRejects);
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
		else if (ReactionType == "Lost Phone")
		{
			this.Label.text = this.LostPhones[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Rival Lost Phone")
		{
			this.Label.text = this.RivalLostPhones[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Murder Reaction")
		{
			this.Label.text = this.GetRandomString(this.MurderReactions);
		}
		else if (ReactionType == "Corpse Reaction")
		{
			this.Label.text = this.GetRandomString(this.CorpseReactions);
		}
		else if (ReactionType == "Loner Murder Reaction")
		{
			this.Label.text = this.GetRandomString(this.LonerMurderReactions);
		}
		else if (ReactionType == "Loner Corpse Reaction")
		{
			this.Label.text = this.GetRandomString(this.LonerCorpseReactions);
		}
		else if (ReactionType == "Pet Murder Report")
		{
			this.Label.text = this.PetMurderReports[ID];
		}
		else if (ReactionType == "Pet Murder Reaction")
		{
			this.Label.text = this.GetRandomString(this.PetMurderReactions);
		}
		else if (ReactionType == "Pet Corpse Report")
		{
			this.Label.text = this.PetCorpseReports[ID];
		}
		else if (ReactionType == "Pet Corpse Reaction")
		{
			this.Label.text = this.GetRandomString(this.PetCorpseReactions);
		}
		else if (ReactionType == "Evil Corpse Reaction")
		{
			this.Label.text = this.GetRandomString(this.EvilCorpseReactions);
		}
		else if (ReactionType == "Hero Murder Reaction")
		{
			this.Label.text = this.GetRandomString(this.HeroMurderReactions);
		}
		else if (ReactionType == "Coward Murder Reaction")
		{
			this.Label.text = this.GetRandomString(this.CowardMurderReactions);
		}
		else if (ReactionType == "Evil Murder Reaction")
		{
			this.Label.text = this.GetRandomString(this.EvilMurderReactions);
		}
		else if (ReactionType == "Social Death Reaction")
		{
			this.Label.text = this.GetRandomString(this.SocialDeathReactions);
		}
		else if (ReactionType == "Social Report")
		{
			this.Label.text = this.GetRandomString(this.SocialReports);
		}
		else if (ReactionType == "Social Fear")
		{
			this.Label.text = this.GetRandomString(this.SocialFears);
		}
		else if (ReactionType == "Social Terror")
		{
			this.Label.text = this.GetRandomString(this.SocialTerrors);
		}
		else if (ReactionType == "Repeat Reaction")
		{
			this.Label.text = this.GetRandomString(this.RepeatReactions);
		}
		else if (ReactionType == "Greeting")
		{
			this.Label.text = this.GetRandomString(this.Greetings);
		}
		else if (ReactionType == "Player Farewell")
		{
			this.Label.text = this.GetRandomString(this.PlayerFarewells);
		}
		else if (ReactionType == "Student Farewell")
		{
			this.Label.text = this.GetRandomString(this.StudentFarewells);
		}
		else if (ReactionType == "Insanity Apology")
		{
			this.Label.text = this.GetRandomString(this.InsanityApologies);
		}
		else if (ReactionType == "Weapon and Blood Apology")
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodApologies);
		}
		else if (ReactionType == "Weapon Apology")
		{
			this.Label.text = this.GetRandomString(this.WeaponApologies);
		}
		else if (ReactionType == "Blood Apology")
		{
			this.Label.text = this.GetRandomString(this.BloodApologies);
		}
		else if (ReactionType == "Lewd Apology")
		{
			this.Label.text = this.GetRandomString(this.LewdApologies);
		}
		else if (ReactionType == "Event Apology")
		{
			this.Label.text = this.GetRandomString(this.EventApologies);
		}
		else if (ReactionType == "Class Apology")
		{
			this.Label.text = this.GetRandomString(this.ClassApologies);
		}
		else if (ReactionType == "Accident Apology")
		{
			this.Label.text = this.GetRandomString(this.AccidentApologies);
		}
		else if (ReactionType == "Forgiving")
		{
			this.Label.text = this.GetRandomString(this.Forgivings);
		}
		else if (ReactionType == "Forgiving Accident")
		{
			this.Label.text = this.GetRandomString(this.AccidentForgivings);
		}
		else if (ReactionType == "Forgiving Insanity")
		{
			this.Label.text = this.GetRandomString(this.InsanityForgivings);
		}
		else if (ReactionType == "Impatience")
		{
			if (ID == 1)
			{
				this.Label.text = this.GetRandomString(this.Impatiences);
			}
			else
			{
				this.Label.text = this.GetRandomString(this.ImpatientFarewells);
			}
		}
		else if (ReactionType == "Player Compliment")
		{
			this.Label.text = this.GetRandomString(this.PlayerCompliments);
		}
		else if (ReactionType == "Student Compliment")
		{
			this.Label.text = this.GetRandomString(this.StudentCompliments);
		}
		else if (ReactionType == "Player Gossip")
		{
			this.Label.text = this.GetRandomString(this.PlayerGossip);
		}
		else if (ReactionType == "Student Gossip")
		{
			this.Label.text = this.GetRandomString(this.StudentGossip);
		}
		else if (ReactionType == "Player Follow")
		{
			this.Label.text = this.GetRandomString(this.PlayerFollows);
		}
		else if (ReactionType == "Student Follow")
		{
			this.Label.text = this.GetRandomString(this.StudentFollows);
		}
		else if (ReactionType == "Player Leave")
		{
			this.Label.text = this.GetRandomString(this.PlayerLeaves);
		}
		else if (ReactionType == "Student Leave")
		{
			this.Label.text = this.GetRandomString(this.StudentLeaves);
		}
		else if (ReactionType == "Student Stay")
		{
			this.Label.text = this.GetRandomString(this.StudentStays);
		}
		else if (ReactionType == "Player Distract")
		{
			this.Label.text = this.GetRandomString(this.PlayerDistracts);
		}
		else if (ReactionType == "Student Distract")
		{
			this.Label.text = this.GetRandomString(this.StudentDistracts);
		}
		else if (ReactionType == "Student Distract Refuse")
		{
			this.Label.text = this.GetRandomString(this.StudentDistractRefuses);
		}
		else if (ReactionType == "Stop Follow Apology")
		{
			this.Label.text = this.GetRandomString(this.StopFollowApologies);
		}
		else if (ReactionType == "Grudge Warning")
		{
			this.Label.text = this.GetRandomString(this.GrudgeWarnings);
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Grudge Refusal")
		{
			this.Label.text = this.GetRandomString(this.GrudgeRefusals);
		}
		else if (ReactionType == "Coward Grudge")
		{
			this.Label.text = this.GetRandomString(this.CowardGrudges);
		}
		else if (ReactionType == "Evil Grudge")
		{
			this.Label.text = this.GetRandomString(this.EvilGrudges);
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
			this.Label.text = this.GetRandomString(this.Deaths);
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
			this.Label.text = this.GetRandomString(this.SenpaiLewdReactions);
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
			this.Label.text = this.GetRandomString(this.SenpaiCorpseReactions);
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
		else if (ReactionType == "Rival Splash Reaction")
		{
			this.Label.text = this.RivalSplashReactions[ID];
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
		AudioClipArrayWrapper audioClipArrayWrapper;
		bool flag = this.ReactionClipArrays.TryGetValue(ReactionType, out audioClipArrayWrapper);
		this.PlayClip(audioClipArrayWrapper[ID], base.transform.position);
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
