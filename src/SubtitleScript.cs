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

	public string[] SuspiciousReactions;

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

	public string[] RivalPickpocketReactions;

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

	public string[] SuspiciousApologies;

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

	public string[] StudentHighCompliments;

	public string[] StudentMidCompliments;

	public string[] StudentLowCompliments;

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

	public AudioClip[] RivalPickpocketReactionClips;

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

	private ReactionTypeAndAudioClipArrayDictionary ReactionClipArrays;

	public GameObject CurrentClip;

	private void Awake()
	{
		this.ReactionClipArrays = new ReactionTypeAndAudioClipArrayDictionary
		{
			{
				ReactionType.ClubAccept,
				new AudioClipArrayWrapper(this.ClubAcceptClips)
			},
			{
				ReactionType.ClubActivity,
				new AudioClipArrayWrapper(this.ClubActivityClips)
			},
			{
				ReactionType.ClubConfirm,
				new AudioClipArrayWrapper(this.ClubConfirmClips)
			},
			{
				ReactionType.ClubDeny,
				new AudioClipArrayWrapper(this.ClubDenyClips)
			},
			{
				ReactionType.ClubEarly,
				new AudioClipArrayWrapper(this.ClubEarlyClips)
			},
			{
				ReactionType.ClubExclusive,
				new AudioClipArrayWrapper(this.ClubExclusiveClips)
			},
			{
				ReactionType.ClubFarewell,
				new AudioClipArrayWrapper(this.ClubFarewellClips)
			},
			{
				ReactionType.ClubGreeting,
				new AudioClipArrayWrapper(this.ClubGreetingClips)
			},
			{
				ReactionType.ClubGrudge,
				new AudioClipArrayWrapper(this.ClubGrudgeClips)
			},
			{
				ReactionType.ClubJoin,
				new AudioClipArrayWrapper(this.ClubJoinClips)
			},
			{
				ReactionType.ClubKick,
				new AudioClipArrayWrapper(this.ClubKickClips)
			},
			{
				ReactionType.ClubLate,
				new AudioClipArrayWrapper(this.ClubLateClips)
			},
			{
				ReactionType.ClubMartialArtsInfo,
				new AudioClipArrayWrapper(this.Club6Clips)
			},
			{
				ReactionType.ClubNo,
				new AudioClipArrayWrapper(this.ClubNoClips)
			},
			{
				ReactionType.ClubOccultInfo,
				new AudioClipArrayWrapper(this.Club3Clips)
			},
			{
				ReactionType.ClubQuit,
				new AudioClipArrayWrapper(this.ClubQuitClips)
			},
			{
				ReactionType.ClubRefuse,
				new AudioClipArrayWrapper(this.ClubRefuseClips)
			},
			{
				ReactionType.ClubRejoin,
				new AudioClipArrayWrapper(this.ClubRejoinClips)
			},
			{
				ReactionType.ClubUnwelcome,
				new AudioClipArrayWrapper(this.ClubUnwelcomeClips)
			},
			{
				ReactionType.ClubYes,
				new AudioClipArrayWrapper(this.ClubYesClips)
			},
			{
				ReactionType.DrownReaction,
				new AudioClipArrayWrapper(this.DrownReactionClips)
			},
			{
				ReactionType.EavesdropReaction,
				new AudioClipArrayWrapper(this.RivalEavesdropClips)
			},
			{
				ReactionType.GrudgeWarning,
				new AudioClipArrayWrapper(this.GrudgeWarningClips)
			},
			{
				ReactionType.LightSwitchReaction,
				new AudioClipArrayWrapper(this.LightSwitchClips)
			},
			{
				ReactionType.LostPhone,
				new AudioClipArrayWrapper(this.LostPhoneClips)
			},
			{
				ReactionType.NoteReaction,
				new AudioClipArrayWrapper(this.NoteReactionClips)
			},
			{
				ReactionType.PickpocketReaction,
				new AudioClipArrayWrapper(this.PickpocketReactionClips)
			},
			{
				ReactionType.RivalLostPhone,
				new AudioClipArrayWrapper(this.RivalLostPhoneClips)
			},
			{
				ReactionType.RivalPickpocketReaction,
				new AudioClipArrayWrapper(this.RivalPickpocketReactionClips)
			},
			{
				ReactionType.RivalSplashReaction,
				new AudioClipArrayWrapper(this.RivalSplashReactionClips)
			},
			{
				ReactionType.SenpaiBloodReaction,
				new AudioClipArrayWrapper(this.SenpaiBloodReactionClips)
			},
			{
				ReactionType.SenpaiInsanityReaction,
				new AudioClipArrayWrapper(this.SenpaiInsanityReactionClips)
			},
			{
				ReactionType.SenpaiLewdReaction,
				new AudioClipArrayWrapper(this.SenpaiLewdReactionClips)
			},
			{
				ReactionType.SenpaiMurderReaction,
				new AudioClipArrayWrapper(this.SenpaiMurderReactionClips)
			},
			{
				ReactionType.SenpaiStalkingReaction,
				new AudioClipArrayWrapper(this.SenpaiStalkingReactionClips)
			},
			{
				ReactionType.SenpaiWeaponReaction,
				new AudioClipArrayWrapper(this.SenpaiWeaponReactionClips)
			},
			{
				ReactionType.SplashReaction,
				new AudioClipArrayWrapper(this.SplashReactionClips)
			},
			{
				ReactionType.Task6Line,
				new AudioClipArrayWrapper(this.Task6Clips)
			},
			{
				ReactionType.Task7Line,
				new AudioClipArrayWrapper(this.Task7Clips)
			},
			{
				ReactionType.Task13Line,
				new AudioClipArrayWrapper(this.Task13Clips)
			},
			{
				ReactionType.Task14Line,
				new AudioClipArrayWrapper(this.Task14Clips)
			},
			{
				ReactionType.Task15Line,
				new AudioClipArrayWrapper(this.Task15Clips)
			},
			{
				ReactionType.Task32Line,
				new AudioClipArrayWrapper(this.Task32Clips)
			},
			{
				ReactionType.Task33Line,
				new AudioClipArrayWrapper(this.Task33Clips)
			},
			{
				ReactionType.Task34Line,
				new AudioClipArrayWrapper(this.Task34Clips)
			},
			{
				ReactionType.TeacherAttackReaction,
				new AudioClipArrayWrapper(this.TeacherAttackClips)
			},
			{
				ReactionType.TeacherBloodHostile,
				new AudioClipArrayWrapper(this.TeacherBloodHostileClips)
			},
			{
				ReactionType.TeacherBloodReaction,
				new AudioClipArrayWrapper(this.TeacherBloodClips)
			},
			{
				ReactionType.TeacherCorpseInspection,
				new AudioClipArrayWrapper(this.TeacherInspectClips)
			},
			{
				ReactionType.TeacherCorpseReaction,
				new AudioClipArrayWrapper(this.TeacherCorpseClips)
			},
			{
				ReactionType.TeacherInsanityHostile,
				new AudioClipArrayWrapper(this.TeacherInsanityHostileClips)
			},
			{
				ReactionType.TeacherInsanityReaction,
				new AudioClipArrayWrapper(this.TeacherInsanityClips)
			},
			{
				ReactionType.TeacherLateReaction,
				new AudioClipArrayWrapper(this.TeacherLateClips)
			},
			{
				ReactionType.TeacherLewdReaction,
				new AudioClipArrayWrapper(this.TeacherLewdClips)
			},
			{
				ReactionType.TeacherMurderReaction,
				new AudioClipArrayWrapper(this.TeacherMurderClips)
			},
			{
				ReactionType.TeacherPoliceReport,
				new AudioClipArrayWrapper(this.TeacherPoliceClips)
			},
			{
				ReactionType.TeacherPrankReaction,
				new AudioClipArrayWrapper(this.TeacherPrankClips)
			},
			{
				ReactionType.TeacherReportReaction,
				new AudioClipArrayWrapper(this.TeacherReportClips)
			},
			{
				ReactionType.TeacherTheftReaction,
				new AudioClipArrayWrapper(this.TeacherTheftClips)
			},
			{
				ReactionType.TeacherTrespassingReaction,
				new AudioClipArrayWrapper(this.TeacherTrespassClips)
			},
			{
				ReactionType.TeacherWeaponHostile,
				new AudioClipArrayWrapper(this.TeacherWeaponHostileClips)
			},
			{
				ReactionType.TeacherWeaponReaction,
				new AudioClipArrayWrapper(this.TeacherWeaponClips)
			},
			{
				ReactionType.YandereWhimper,
				new AudioClipArrayWrapper(this.YandereWhimperClips)
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

	public void UpdateLabel(ReactionType reactionType, int ID, float Duration)
	{
		if (reactionType == ReactionType.WeaponAndBloodAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodInsanityReactions);
		}
		else if (reactionType == ReactionType.WeaponAndBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodReactions);
		}
		else if (reactionType == ReactionType.WeaponAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponInsanityReactions);
		}
		else if (reactionType == ReactionType.BloodAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.BloodInsanityReactions);
		}
		else if (reactionType == ReactionType.WeaponReaction)
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
		else if (reactionType == ReactionType.BloodReaction)
		{
			this.Label.text = this.GetRandomString(this.BloodReactions);
		}
		else if (reactionType == ReactionType.WetBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.WetBloodReactions);
		}
		else if (reactionType == ReactionType.InsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.InsanityReactions);
		}
		else if (reactionType == ReactionType.LewdReaction)
		{
			this.Label.text = this.GetRandomString(this.LewdReactions);
		}
		else if (reactionType == ReactionType.SuspiciousReaction)
		{
			this.Label.text = this.GetRandomString(this.SuspiciousReactions);
		}
		else if (reactionType == ReactionType.PrankReaction)
		{
			this.Label.text = this.GetRandomString(this.PrankReactions);
		}
		else if (reactionType == ReactionType.InterruptionReaction)
		{
			this.Label.text = this.GetRandomString(this.InterruptReactions);
		}
		else if (reactionType == ReactionType.NoteReaction)
		{
			this.Label.text = this.NoteReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.AcceptFood)
		{
			this.Label.text = this.GetRandomString(this.FoodAccepts);
		}
		else if (reactionType == ReactionType.RejectFood)
		{
			this.Label.text = this.GetRandomString(this.FoodRejects);
		}
		else if (reactionType == ReactionType.EavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EavesdropReactions.Length);
			this.Label.text = this.EavesdropReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.PickpocketReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PickpocketReactions.Length);
			this.Label.text = this.PickpocketReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.RivalPickpocketReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.RivalPickpocketReactions.Length);
			this.Label.text = this.RivalPickpocketReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.DrownReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DrownReactions.Length);
			this.Label.text = this.DrownReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponReactions.Length);
			this.Label.text = this.TeacherWeaponReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherBloodReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodReactions.Length);
			this.Label.text = this.TeacherBloodReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherInsanityReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityReactions.Length);
			this.Label.text = this.TeacherInsanityReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherWeaponHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponHostiles.Length);
			this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherBloodHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodHostiles.Length);
			this.Label.text = this.TeacherBloodHostiles[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherInsanityHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityHostiles.Length);
			this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherLewdReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLewdReactions.Length);
			this.Label.text = this.TeacherLewdReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherTrespassingReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTrespassReactions.Length);
			this.Label.text = this.TeacherTrespassReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.TeacherLateReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLateReactions.Length);
			this.Label.text = this.TeacherLateReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.TeacherReportReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherReportReactions.Length);
			this.Label.text = this.TeacherReportReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherCorpseReactions.Length);
			this.Label.text = this.TeacherCorpseReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherCorpseInspection)
		{
			this.Label.text = this.TeacherCorpseInspections[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.TeacherPoliceReport)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPoliceReports.Length);
			this.Label.text = this.TeacherPoliceReports[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherAttackReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherAttackReactions.Length);
			this.Label.text = this.TeacherAttackReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherMurderReaction)
		{
			this.Label.text = this.TeacherMurderReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.TeacherPrankReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPrankReactions.Length);
			this.Label.text = this.TeacherPrankReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.TeacherTheftReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTheftReactions.Length);
			this.Label.text = this.TeacherTheftReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.LostPhone)
		{
			this.Label.text = this.LostPhones[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.RivalLostPhone)
		{
			this.Label.text = this.RivalLostPhones[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.MurderReaction)
		{
			this.Label.text = this.GetRandomString(this.MurderReactions);
		}
		else if (reactionType == ReactionType.CorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.CorpseReactions);
		}
		else if (reactionType == ReactionType.LonerMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.LonerMurderReactions);
		}
		else if (reactionType == ReactionType.LonerCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.LonerCorpseReactions);
		}
		else if (reactionType == ReactionType.PetMurderReport)
		{
			this.Label.text = this.PetMurderReports[ID];
		}
		else if (reactionType == ReactionType.PetMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.PetMurderReactions);
		}
		else if (reactionType == ReactionType.PetCorpseReport)
		{
			this.Label.text = this.PetCorpseReports[ID];
		}
		else if (reactionType == ReactionType.PetCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.PetCorpseReactions);
		}
		else if (reactionType == ReactionType.EvilCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.EvilCorpseReactions);
		}
		else if (reactionType == ReactionType.HeroMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.HeroMurderReactions);
		}
		else if (reactionType == ReactionType.CowardMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.CowardMurderReactions);
		}
		else if (reactionType == ReactionType.EvilMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.EvilMurderReactions);
		}
		else if (reactionType == ReactionType.SocialDeathReaction)
		{
			this.Label.text = this.GetRandomString(this.SocialDeathReactions);
		}
		else if (reactionType == ReactionType.SocialReport)
		{
			this.Label.text = this.GetRandomString(this.SocialReports);
		}
		else if (reactionType == ReactionType.SocialFear)
		{
			this.Label.text = this.GetRandomString(this.SocialFears);
		}
		else if (reactionType == ReactionType.SocialTerror)
		{
			this.Label.text = this.GetRandomString(this.SocialTerrors);
		}
		else if (reactionType == ReactionType.RepeatReaction)
		{
			this.Label.text = this.GetRandomString(this.RepeatReactions);
		}
		else if (reactionType == ReactionType.Greeting)
		{
			this.Label.text = this.GetRandomString(this.Greetings);
		}
		else if (reactionType == ReactionType.PlayerFarewell)
		{
			this.Label.text = this.GetRandomString(this.PlayerFarewells);
		}
		else if (reactionType == ReactionType.StudentFarewell)
		{
			this.Label.text = this.GetRandomString(this.StudentFarewells);
		}
		else if (reactionType == ReactionType.InsanityApology)
		{
			this.Label.text = this.GetRandomString(this.InsanityApologies);
		}
		else if (reactionType == ReactionType.WeaponAndBloodApology)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodApologies);
		}
		else if (reactionType == ReactionType.WeaponApology)
		{
			this.Label.text = this.GetRandomString(this.WeaponApologies);
		}
		else if (reactionType == ReactionType.BloodApology)
		{
			this.Label.text = this.GetRandomString(this.BloodApologies);
		}
		else if (reactionType == ReactionType.LewdApology)
		{
			this.Label.text = this.GetRandomString(this.LewdApologies);
		}
		else if (reactionType == ReactionType.SuspiciousApology)
		{
			this.Label.text = this.GetRandomString(this.SuspiciousApologies);
		}
		else if (reactionType == ReactionType.EventApology)
		{
			this.Label.text = this.GetRandomString(this.EventApologies);
		}
		else if (reactionType == ReactionType.ClassApology)
		{
			this.Label.text = this.GetRandomString(this.ClassApologies);
		}
		else if (reactionType == ReactionType.AccidentApology)
		{
			this.Label.text = this.GetRandomString(this.AccidentApologies);
		}
		else if (reactionType == ReactionType.Forgiving)
		{
			this.Label.text = this.GetRandomString(this.Forgivings);
		}
		else if (reactionType == ReactionType.ForgivingAccident)
		{
			this.Label.text = this.GetRandomString(this.AccidentForgivings);
		}
		else if (reactionType == ReactionType.ForgivingInsanity)
		{
			this.Label.text = this.GetRandomString(this.InsanityForgivings);
		}
		else if (reactionType == ReactionType.Impatience)
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
		else if (reactionType == ReactionType.PlayerCompliment)
		{
			this.Label.text = this.GetRandomString(this.PlayerCompliments);
		}
		else if (reactionType == ReactionType.StudentHighCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentHighCompliments);
		}
		else if (reactionType == ReactionType.StudentMidCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentMidCompliments);
		}
		else if (reactionType == ReactionType.StudentLowCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentLowCompliments);
		}
		else if (reactionType == ReactionType.PlayerGossip)
		{
			this.Label.text = this.GetRandomString(this.PlayerGossip);
		}
		else if (reactionType == ReactionType.StudentGossip)
		{
			this.Label.text = this.GetRandomString(this.StudentGossip);
		}
		else if (reactionType == ReactionType.PlayerFollow)
		{
			this.Label.text = this.GetRandomString(this.PlayerFollows);
		}
		else if (reactionType == ReactionType.StudentFollow)
		{
			this.Label.text = this.GetRandomString(this.StudentFollows);
		}
		else if (reactionType == ReactionType.PlayerLeave)
		{
			this.Label.text = this.GetRandomString(this.PlayerLeaves);
		}
		else if (reactionType == ReactionType.StudentLeave)
		{
			this.Label.text = this.GetRandomString(this.StudentLeaves);
		}
		else if (reactionType == ReactionType.StudentStay)
		{
			this.Label.text = this.GetRandomString(this.StudentStays);
		}
		else if (reactionType == ReactionType.PlayerDistract)
		{
			this.Label.text = this.GetRandomString(this.PlayerDistracts);
		}
		else if (reactionType == ReactionType.StudentDistract)
		{
			this.Label.text = this.GetRandomString(this.StudentDistracts);
		}
		else if (reactionType == ReactionType.StudentDistractRefuse)
		{
			this.Label.text = this.GetRandomString(this.StudentDistractRefuses);
		}
		else if (reactionType == ReactionType.StopFollowApology)
		{
			this.Label.text = this.GetRandomString(this.StopFollowApologies);
		}
		else if (reactionType == ReactionType.GrudgeWarning)
		{
			this.Label.text = this.GetRandomString(this.GrudgeWarnings);
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.GrudgeRefusal)
		{
			this.Label.text = this.GetRandomString(this.GrudgeRefusals);
		}
		else if (reactionType == ReactionType.CowardGrudge)
		{
			this.Label.text = this.GetRandomString(this.CowardGrudges);
		}
		else if (reactionType == ReactionType.EvilGrudge)
		{
			this.Label.text = this.GetRandomString(this.EvilGrudges);
		}
		else if (reactionType == ReactionType.PlayerLove)
		{
			this.Label.text = this.PlayerLove[ID];
		}
		else if (reactionType == ReactionType.SuitorLove)
		{
			this.Label.text = this.SuitorLove[ID];
		}
		else if (reactionType == ReactionType.RivalLove)
		{
			this.Label.text = this.RivalLove[ID];
		}
		else if (reactionType == ReactionType.Dying)
		{
			this.Label.text = this.GetRandomString(this.Deaths);
		}
		else if (reactionType == ReactionType.SenpaiInsanityReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiInsanityReactions.Length);
			this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.SenpaiWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiWeaponReactions.Length);
			this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.SenpaiBloodReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiBloodReactions.Length);
			this.Label.text = this.SenpaiBloodReactions[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.SenpaiLewdReaction)
		{
			this.Label.text = this.GetRandomString(this.SenpaiLewdReactions);
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.SenpaiStalkingReaction)
		{
			this.Label.text = this.SenpaiStalkingReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.SenpaiMurderReaction)
		{
			this.Label.text = this.SenpaiMurderReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.SenpaiCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.SenpaiCorpseReactions);
		}
		else if (reactionType == ReactionType.YandereWhimper)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.YandereWhimpers.Length);
			this.Label.text = this.YandereWhimpers[this.RandomID];
			this.PlayVoice(reactionType, this.RandomID);
		}
		else if (reactionType == ReactionType.StudentMurderReport)
		{
			this.Label.text = this.StudentMurderReports[ID];
		}
		else if (reactionType == ReactionType.SplashReaction)
		{
			this.Label.text = this.SplashReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.RivalSplashReaction)
		{
			this.Label.text = this.RivalSplashReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.LightSwitchReaction)
		{
			this.Label.text = this.LightSwitchReactions[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task6Line)
		{
			this.Label.text = this.Task6Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task7Line)
		{
			this.Label.text = this.Task7Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task13Line)
		{
			this.Label.text = this.Task13Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task14Line)
		{
			this.Label.text = this.Task14Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task15Line)
		{
			this.Label.text = this.Task15Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task32Line)
		{
			this.Label.text = this.Task32Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task33Line)
		{
			this.Label.text = this.Task33Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.Task34Line)
		{
			this.Label.text = this.Task34Lines[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubGreeting)
		{
			this.Label.text = this.ClubGreetings[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubUnwelcome)
		{
			this.Label.text = this.ClubUnwelcomes[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubKick)
		{
			this.Label.text = this.ClubKicks[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubOccultInfo)
		{
			this.Label.text = this.Club3Info[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubMartialArtsInfo)
		{
			this.Label.text = this.Club6Info[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubJoin)
		{
			this.Label.text = this.ClubJoins[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubAccept)
		{
			this.Label.text = this.ClubAccepts[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubRefuse)
		{
			this.Label.text = this.ClubRefuses[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubRejoin)
		{
			this.Label.text = this.ClubRejoins[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubExclusive)
		{
			this.Label.text = this.ClubExclusives[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubGrudge)
		{
			this.Label.text = this.ClubGrudges[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubQuit)
		{
			this.Label.text = this.ClubQuits[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubConfirm)
		{
			this.Label.text = this.ClubConfirms[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubDeny)
		{
			this.Label.text = this.ClubDenies[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubFarewell)
		{
			this.Label.text = this.ClubFarewells[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubActivity)
		{
			this.Label.text = this.ClubActivities[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubEarly)
		{
			this.Label.text = this.ClubEarlies[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubLate)
		{
			this.Label.text = this.ClubLates[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubYes)
		{
			this.Label.text = this.ClubYeses[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.ClubNo)
		{
			this.Label.text = this.ClubNoes[ID];
			this.PlayVoice(reactionType, ID);
		}
		else if (reactionType == ReactionType.InfoNotice)
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

	private void PlayVoice(ReactionType reactionType, int ID)
	{
		if (this.CurrentClip != null)
		{
			UnityEngine.Object.Destroy(this.CurrentClip);
		}
		this.Jukebox.Dip = 0.5f;
		AudioClipArrayWrapper audioClipArrayWrapper;
		bool flag = this.ReactionClipArrays.TryGetValue(reactionType, out audioClipArrayWrapper);
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

	public float GetClubClipLength(ClubType Club, int ClubPhase)
	{
		if (Club == ClubType.Occult)
		{
			return this.Club3Clips[ClubPhase].length;
		}
		if (Club == ClubType.MartialArts)
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
