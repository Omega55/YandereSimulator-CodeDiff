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

	public string[] LovestruckDeathReactions;

	public string[] LovestruckMurderReports;

	public string[] LovestruckCorpseReports;

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

	public string[] EventEavesdropReactions;

	public string[] RivalEavesdropReactions;

	public string[] PickpocketReactions;

	public string[] RivalPickpocketReactions;

	public string[] DrownReactions;

	public string[] KilledMoods;

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

	public string[] SadApologies;

	public string[] EavesdropApologies;

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

	public string[] PhotoAnnoyances;

	public string[] Task6Lines;

	public string[] Task7Lines;

	public string[] Task13Lines;

	public string[] Task14Lines;

	public string[] Task15Lines;

	public string[] Task32Lines;

	public string[] Task33Lines;

	public string[] Task34Lines;

	public string[] Task81Lines;

	public string[] Club0Info;

	public string[] Club3Info;

	public string[] Club4Info;

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

	public string[] StrictReaction;

	public string[] CasualReaction;

	public string[] GraceReaction;

	public string[] EdgyReaction;

	public string[] Spraying;

	public string[] Shoving;

	public string[] Chasing;

	public string[] CouncilCorpseReactions;

	public string[] HmmReactions;

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

	public AudioClip[] Task81Clips;

	public AudioClip[] Club0Clips;

	public AudioClip[] Club3Clips;

	public AudioClip[] Club4Clips;

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

	public AudioClip[] EavesdropClips;

	public AudioClip[] EventEavesdropClips;

	public AudioClip[] RivalEavesdropClips;

	private SubtitleTypeAndAudioClipArrayDictionary SubtitleClipArrays;

	public GameObject CurrentClip;

	private void Awake()
	{
		this.SubtitleClipArrays = new SubtitleTypeAndAudioClipArrayDictionary
		{
			{
				SubtitleType.ClubAccept,
				new AudioClipArrayWrapper(this.ClubAcceptClips)
			},
			{
				SubtitleType.ClubActivity,
				new AudioClipArrayWrapper(this.ClubActivityClips)
			},
			{
				SubtitleType.ClubArtInfo,
				new AudioClipArrayWrapper(this.Club4Clips)
			},
			{
				SubtitleType.ClubConfirm,
				new AudioClipArrayWrapper(this.ClubConfirmClips)
			},
			{
				SubtitleType.ClubDeny,
				new AudioClipArrayWrapper(this.ClubDenyClips)
			},
			{
				SubtitleType.ClubEarly,
				new AudioClipArrayWrapper(this.ClubEarlyClips)
			},
			{
				SubtitleType.ClubExclusive,
				new AudioClipArrayWrapper(this.ClubExclusiveClips)
			},
			{
				SubtitleType.ClubFarewell,
				new AudioClipArrayWrapper(this.ClubFarewellClips)
			},
			{
				SubtitleType.ClubGreeting,
				new AudioClipArrayWrapper(this.ClubGreetingClips)
			},
			{
				SubtitleType.ClubGrudge,
				new AudioClipArrayWrapper(this.ClubGrudgeClips)
			},
			{
				SubtitleType.ClubJoin,
				new AudioClipArrayWrapper(this.ClubJoinClips)
			},
			{
				SubtitleType.ClubKick,
				new AudioClipArrayWrapper(this.ClubKickClips)
			},
			{
				SubtitleType.ClubLate,
				new AudioClipArrayWrapper(this.ClubLateClips)
			},
			{
				SubtitleType.ClubMartialArtsInfo,
				new AudioClipArrayWrapper(this.Club6Clips)
			},
			{
				SubtitleType.ClubNo,
				new AudioClipArrayWrapper(this.ClubNoClips)
			},
			{
				SubtitleType.ClubOccultInfo,
				new AudioClipArrayWrapper(this.Club3Clips)
			},
			{
				SubtitleType.ClubPlaceholderInfo,
				new AudioClipArrayWrapper(this.Club0Clips)
			},
			{
				SubtitleType.ClubQuit,
				new AudioClipArrayWrapper(this.ClubQuitClips)
			},
			{
				SubtitleType.ClubRefuse,
				new AudioClipArrayWrapper(this.ClubRefuseClips)
			},
			{
				SubtitleType.ClubRejoin,
				new AudioClipArrayWrapper(this.ClubRejoinClips)
			},
			{
				SubtitleType.ClubUnwelcome,
				new AudioClipArrayWrapper(this.ClubUnwelcomeClips)
			},
			{
				SubtitleType.ClubYes,
				new AudioClipArrayWrapper(this.ClubYesClips)
			},
			{
				SubtitleType.DrownReaction,
				new AudioClipArrayWrapper(this.DrownReactionClips)
			},
			{
				SubtitleType.EavesdropReaction,
				new AudioClipArrayWrapper(this.EavesdropClips)
			},
			{
				SubtitleType.EventEavesdropReaction,
				new AudioClipArrayWrapper(this.EventEavesdropClips)
			},
			{
				SubtitleType.RivalEavesdropReaction,
				new AudioClipArrayWrapper(this.RivalEavesdropClips)
			},
			{
				SubtitleType.GrudgeWarning,
				new AudioClipArrayWrapper(this.GrudgeWarningClips)
			},
			{
				SubtitleType.LightSwitchReaction,
				new AudioClipArrayWrapper(this.LightSwitchClips)
			},
			{
				SubtitleType.LostPhone,
				new AudioClipArrayWrapper(this.LostPhoneClips)
			},
			{
				SubtitleType.NoteReaction,
				new AudioClipArrayWrapper(this.NoteReactionClips)
			},
			{
				SubtitleType.PickpocketReaction,
				new AudioClipArrayWrapper(this.PickpocketReactionClips)
			},
			{
				SubtitleType.RivalLostPhone,
				new AudioClipArrayWrapper(this.RivalLostPhoneClips)
			},
			{
				SubtitleType.RivalPickpocketReaction,
				new AudioClipArrayWrapper(this.RivalPickpocketReactionClips)
			},
			{
				SubtitleType.RivalSplashReaction,
				new AudioClipArrayWrapper(this.RivalSplashReactionClips)
			},
			{
				SubtitleType.SenpaiBloodReaction,
				new AudioClipArrayWrapper(this.SenpaiBloodReactionClips)
			},
			{
				SubtitleType.SenpaiInsanityReaction,
				new AudioClipArrayWrapper(this.SenpaiInsanityReactionClips)
			},
			{
				SubtitleType.SenpaiLewdReaction,
				new AudioClipArrayWrapper(this.SenpaiLewdReactionClips)
			},
			{
				SubtitleType.SenpaiMurderReaction,
				new AudioClipArrayWrapper(this.SenpaiMurderReactionClips)
			},
			{
				SubtitleType.SenpaiStalkingReaction,
				new AudioClipArrayWrapper(this.SenpaiStalkingReactionClips)
			},
			{
				SubtitleType.SenpaiWeaponReaction,
				new AudioClipArrayWrapper(this.SenpaiWeaponReactionClips)
			},
			{
				SubtitleType.SplashReaction,
				new AudioClipArrayWrapper(this.SplashReactionClips)
			},
			{
				SubtitleType.Task6Line,
				new AudioClipArrayWrapper(this.Task6Clips)
			},
			{
				SubtitleType.Task7Line,
				new AudioClipArrayWrapper(this.Task7Clips)
			},
			{
				SubtitleType.Task13Line,
				new AudioClipArrayWrapper(this.Task13Clips)
			},
			{
				SubtitleType.Task14Line,
				new AudioClipArrayWrapper(this.Task14Clips)
			},
			{
				SubtitleType.Task15Line,
				new AudioClipArrayWrapper(this.Task15Clips)
			},
			{
				SubtitleType.Task32Line,
				new AudioClipArrayWrapper(this.Task32Clips)
			},
			{
				SubtitleType.Task33Line,
				new AudioClipArrayWrapper(this.Task33Clips)
			},
			{
				SubtitleType.Task34Line,
				new AudioClipArrayWrapper(this.Task34Clips)
			},
			{
				SubtitleType.Task81Line,
				new AudioClipArrayWrapper(this.Task81Clips)
			},
			{
				SubtitleType.TeacherAttackReaction,
				new AudioClipArrayWrapper(this.TeacherAttackClips)
			},
			{
				SubtitleType.TeacherBloodHostile,
				new AudioClipArrayWrapper(this.TeacherBloodHostileClips)
			},
			{
				SubtitleType.TeacherBloodReaction,
				new AudioClipArrayWrapper(this.TeacherBloodClips)
			},
			{
				SubtitleType.TeacherCorpseInspection,
				new AudioClipArrayWrapper(this.TeacherInspectClips)
			},
			{
				SubtitleType.TeacherCorpseReaction,
				new AudioClipArrayWrapper(this.TeacherCorpseClips)
			},
			{
				SubtitleType.TeacherInsanityHostile,
				new AudioClipArrayWrapper(this.TeacherInsanityHostileClips)
			},
			{
				SubtitleType.TeacherInsanityReaction,
				new AudioClipArrayWrapper(this.TeacherInsanityClips)
			},
			{
				SubtitleType.TeacherLateReaction,
				new AudioClipArrayWrapper(this.TeacherLateClips)
			},
			{
				SubtitleType.TeacherLewdReaction,
				new AudioClipArrayWrapper(this.TeacherLewdClips)
			},
			{
				SubtitleType.TeacherMurderReaction,
				new AudioClipArrayWrapper(this.TeacherMurderClips)
			},
			{
				SubtitleType.TeacherPoliceReport,
				new AudioClipArrayWrapper(this.TeacherPoliceClips)
			},
			{
				SubtitleType.TeacherPrankReaction,
				new AudioClipArrayWrapper(this.TeacherPrankClips)
			},
			{
				SubtitleType.TeacherReportReaction,
				new AudioClipArrayWrapper(this.TeacherReportClips)
			},
			{
				SubtitleType.TeacherTheftReaction,
				new AudioClipArrayWrapper(this.TeacherTheftClips)
			},
			{
				SubtitleType.TeacherTrespassingReaction,
				new AudioClipArrayWrapper(this.TeacherTrespassClips)
			},
			{
				SubtitleType.TeacherWeaponHostile,
				new AudioClipArrayWrapper(this.TeacherWeaponHostileClips)
			},
			{
				SubtitleType.TeacherWeaponReaction,
				new AudioClipArrayWrapper(this.TeacherWeaponClips)
			},
			{
				SubtitleType.YandereWhimper,
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

	public void UpdateLabel(SubtitleType subtitleType, int ID, float Duration)
	{
		if (subtitleType == SubtitleType.WeaponAndBloodAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodInsanityReactions);
		}
		else if (subtitleType == SubtitleType.WeaponAndBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodReactions);
		}
		else if (subtitleType == SubtitleType.WeaponAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.WeaponInsanityReactions);
		}
		else if (subtitleType == SubtitleType.BloodAndInsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.BloodInsanityReactions);
		}
		else if (subtitleType == SubtitleType.WeaponReaction)
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
		else if (subtitleType == SubtitleType.BloodReaction)
		{
			this.Label.text = this.GetRandomString(this.BloodReactions);
		}
		else if (subtitleType == SubtitleType.WetBloodReaction)
		{
			this.Label.text = this.GetRandomString(this.WetBloodReactions);
		}
		else if (subtitleType == SubtitleType.InsanityReaction)
		{
			this.Label.text = this.GetRandomString(this.InsanityReactions);
		}
		else if (subtitleType == SubtitleType.LewdReaction)
		{
			this.Label.text = this.GetRandomString(this.LewdReactions);
		}
		else if (subtitleType == SubtitleType.SuspiciousReaction)
		{
			this.Label.text = this.GetRandomString(this.SuspiciousReactions);
		}
		else if (subtitleType == SubtitleType.PrankReaction)
		{
			this.Label.text = this.GetRandomString(this.PrankReactions);
		}
		else if (subtitleType == SubtitleType.InterruptionReaction)
		{
			this.Label.text = this.GetRandomString(this.InterruptReactions);
		}
		else if (subtitleType == SubtitleType.KilledMood)
		{
			this.Label.text = this.GetRandomString(this.KilledMoods);
		}
		else if (subtitleType == SubtitleType.NoteReaction)
		{
			this.Label.text = this.NoteReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.AcceptFood)
		{
			this.Label.text = this.GetRandomString(this.FoodAccepts);
		}
		else if (subtitleType == SubtitleType.RejectFood)
		{
			this.Label.text = this.GetRandomString(this.FoodRejects);
		}
		else if (subtitleType == SubtitleType.EavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EavesdropReactions.Length);
			this.Label.text = this.EavesdropReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.EventEavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EventEavesdropReactions.Length);
			this.Label.text = this.EventEavesdropReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.RivalEavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.RivalEavesdropReactions.Length);
			this.Label.text = this.RivalEavesdropReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.PickpocketReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PickpocketReactions.Length);
			this.Label.text = this.PickpocketReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.RivalPickpocketReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.RivalPickpocketReactions.Length);
			this.Label.text = this.RivalPickpocketReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DrownReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DrownReactions.Length);
			this.Label.text = this.DrownReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.HmmReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.HmmReactions.Length);
			this.Label.text = this.HmmReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.TeacherWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponReactions.Length);
			this.Label.text = this.TeacherWeaponReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherBloodReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodReactions.Length);
			this.Label.text = this.TeacherBloodReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherInsanityReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityReactions.Length);
			this.Label.text = this.TeacherInsanityReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherWeaponHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherWeaponHostiles.Length);
			this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherBloodHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherBloodHostiles.Length);
			this.Label.text = this.TeacherBloodHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherInsanityHostile)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherInsanityHostiles.Length);
			this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherLewdReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLewdReactions.Length);
			this.Label.text = this.TeacherLewdReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherTrespassingReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTrespassReactions.Length);
			this.Label.text = this.TeacherTrespassReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.TeacherLateReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherLateReactions.Length);
			this.Label.text = this.TeacherLateReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.TeacherReportReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherReportReactions.Length);
			this.Label.text = this.TeacherReportReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherCorpseReactions.Length);
			this.Label.text = this.TeacherCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherCorpseInspection)
		{
			this.Label.text = this.TeacherCorpseInspections[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.TeacherPoliceReport)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPoliceReports.Length);
			this.Label.text = this.TeacherPoliceReports[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherAttackReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherAttackReactions.Length);
			this.Label.text = this.TeacherAttackReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherMurderReaction)
		{
			this.Label.text = this.TeacherMurderReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.TeacherPrankReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherPrankReactions.Length);
			this.Label.text = this.TeacherPrankReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.TeacherTheftReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.TeacherTheftReactions.Length);
			this.Label.text = this.TeacherTheftReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.LostPhone)
		{
			this.Label.text = this.LostPhones[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.RivalLostPhone)
		{
			this.Label.text = this.RivalLostPhones[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.MurderReaction)
		{
			this.Label.text = this.GetRandomString(this.MurderReactions);
		}
		else if (subtitleType == SubtitleType.CorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.CorpseReactions);
		}
		else if (subtitleType == SubtitleType.CouncilCorpseReaction)
		{
			this.Label.text = this.CouncilCorpseReactions[ID];
		}
		else if (subtitleType == SubtitleType.LonerMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.LonerMurderReactions);
		}
		else if (subtitleType == SubtitleType.LonerCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.LonerCorpseReactions);
		}
		else if (subtitleType == SubtitleType.PetMurderReport)
		{
			this.Label.text = this.PetMurderReports[ID];
		}
		else if (subtitleType == SubtitleType.PetMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.PetMurderReactions);
		}
		else if (subtitleType == SubtitleType.PetCorpseReport)
		{
			this.Label.text = this.PetCorpseReports[ID];
		}
		else if (subtitleType == SubtitleType.PetCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.PetCorpseReactions);
		}
		else if (subtitleType == SubtitleType.EvilCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.EvilCorpseReactions);
		}
		else if (subtitleType == SubtitleType.HeroMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.HeroMurderReactions);
		}
		else if (subtitleType == SubtitleType.CowardMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.CowardMurderReactions);
		}
		else if (subtitleType == SubtitleType.EvilMurderReaction)
		{
			this.Label.text = this.GetRandomString(this.EvilMurderReactions);
		}
		else if (subtitleType == SubtitleType.SocialDeathReaction)
		{
			this.Label.text = this.GetRandomString(this.SocialDeathReactions);
		}
		else if (subtitleType == SubtitleType.LovestruckDeathReaction)
		{
			this.Label.text = this.GetRandomString(this.LovestruckDeathReactions);
		}
		else if (subtitleType == SubtitleType.LovestruckMurderReport)
		{
			this.Label.text = this.GetRandomString(this.LovestruckMurderReports);
		}
		else if (subtitleType == SubtitleType.LovestruckCorpseReport)
		{
			this.Label.text = this.GetRandomString(this.LovestruckCorpseReports);
		}
		else if (subtitleType == SubtitleType.SocialReport)
		{
			this.Label.text = this.GetRandomString(this.SocialReports);
		}
		else if (subtitleType == SubtitleType.SocialFear)
		{
			this.Label.text = this.GetRandomString(this.SocialFears);
		}
		else if (subtitleType == SubtitleType.SocialTerror)
		{
			this.Label.text = this.GetRandomString(this.SocialTerrors);
		}
		else if (subtitleType == SubtitleType.RepeatReaction)
		{
			this.Label.text = this.GetRandomString(this.RepeatReactions);
		}
		else if (subtitleType == SubtitleType.Greeting)
		{
			this.Label.text = this.GetRandomString(this.Greetings);
		}
		else if (subtitleType == SubtitleType.PlayerFarewell)
		{
			this.Label.text = this.GetRandomString(this.PlayerFarewells);
		}
		else if (subtitleType == SubtitleType.StudentFarewell)
		{
			this.Label.text = this.GetRandomString(this.StudentFarewells);
		}
		else if (subtitleType == SubtitleType.InsanityApology)
		{
			this.Label.text = this.GetRandomString(this.InsanityApologies);
		}
		else if (subtitleType == SubtitleType.WeaponAndBloodApology)
		{
			this.Label.text = this.GetRandomString(this.WeaponBloodApologies);
		}
		else if (subtitleType == SubtitleType.WeaponApology)
		{
			this.Label.text = this.GetRandomString(this.WeaponApologies);
		}
		else if (subtitleType == SubtitleType.BloodApology)
		{
			this.Label.text = this.GetRandomString(this.BloodApologies);
		}
		else if (subtitleType == SubtitleType.LewdApology)
		{
			this.Label.text = this.GetRandomString(this.LewdApologies);
		}
		else if (subtitleType == SubtitleType.SuspiciousApology)
		{
			this.Label.text = this.GetRandomString(this.SuspiciousApologies);
		}
		else if (subtitleType == SubtitleType.EavesdropApology)
		{
			this.Label.text = this.GetRandomString(this.EavesdropApologies);
		}
		else if (subtitleType == SubtitleType.EventApology)
		{
			this.Label.text = this.GetRandomString(this.EventApologies);
		}
		else if (subtitleType == SubtitleType.ClassApology)
		{
			this.Label.text = this.GetRandomString(this.ClassApologies);
		}
		else if (subtitleType == SubtitleType.AccidentApology)
		{
			this.Label.text = this.GetRandomString(this.AccidentApologies);
		}
		else if (subtitleType == SubtitleType.SadApology)
		{
			this.Label.text = this.GetRandomString(this.SadApologies);
		}
		else if (subtitleType == SubtitleType.Forgiving)
		{
			this.Label.text = this.GetRandomString(this.Forgivings);
		}
		else if (subtitleType == SubtitleType.ForgivingAccident)
		{
			this.Label.text = this.GetRandomString(this.AccidentForgivings);
		}
		else if (subtitleType == SubtitleType.ForgivingInsanity)
		{
			this.Label.text = this.GetRandomString(this.InsanityForgivings);
		}
		else if (subtitleType == SubtitleType.Impatience)
		{
			this.Label.text = this.Impatiences[ID];
		}
		else if (subtitleType == SubtitleType.PlayerCompliment)
		{
			this.Label.text = this.GetRandomString(this.PlayerCompliments);
		}
		else if (subtitleType == SubtitleType.StudentHighCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentHighCompliments);
		}
		else if (subtitleType == SubtitleType.StudentMidCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentMidCompliments);
		}
		else if (subtitleType == SubtitleType.StudentLowCompliment)
		{
			this.Label.text = this.GetRandomString(this.StudentLowCompliments);
		}
		else if (subtitleType == SubtitleType.PlayerGossip)
		{
			this.Label.text = this.GetRandomString(this.PlayerGossip);
		}
		else if (subtitleType == SubtitleType.StudentGossip)
		{
			this.Label.text = this.GetRandomString(this.StudentGossip);
		}
		else if (subtitleType == SubtitleType.PlayerFollow)
		{
			this.Label.text = this.GetRandomString(this.PlayerFollows);
		}
		else if (subtitleType == SubtitleType.StudentFollow)
		{
			this.Label.text = this.GetRandomString(this.StudentFollows);
		}
		else if (subtitleType == SubtitleType.PlayerLeave)
		{
			this.Label.text = this.GetRandomString(this.PlayerLeaves);
		}
		else if (subtitleType == SubtitleType.StudentLeave)
		{
			this.Label.text = this.GetRandomString(this.StudentLeaves);
		}
		else if (subtitleType == SubtitleType.StudentStay)
		{
			this.Label.text = this.GetRandomString(this.StudentStays);
		}
		else if (subtitleType == SubtitleType.PlayerDistract)
		{
			this.Label.text = this.GetRandomString(this.PlayerDistracts);
		}
		else if (subtitleType == SubtitleType.StudentDistract)
		{
			this.Label.text = this.GetRandomString(this.StudentDistracts);
		}
		else if (subtitleType == SubtitleType.StudentDistractRefuse)
		{
			this.Label.text = this.GetRandomString(this.StudentDistractRefuses);
		}
		else if (subtitleType == SubtitleType.StopFollowApology)
		{
			this.Label.text = this.GetRandomString(this.StopFollowApologies);
		}
		else if (subtitleType == SubtitleType.GrudgeWarning)
		{
			this.Label.text = this.GetRandomString(this.GrudgeWarnings);
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.GrudgeRefusal)
		{
			this.Label.text = this.GetRandomString(this.GrudgeRefusals);
		}
		else if (subtitleType == SubtitleType.CowardGrudge)
		{
			this.Label.text = this.GetRandomString(this.CowardGrudges);
		}
		else if (subtitleType == SubtitleType.EvilGrudge)
		{
			this.Label.text = this.GetRandomString(this.EvilGrudges);
		}
		else if (subtitleType == SubtitleType.PlayerLove)
		{
			this.Label.text = this.PlayerLove[ID];
		}
		else if (subtitleType == SubtitleType.SuitorLove)
		{
			this.Label.text = this.SuitorLove[ID];
		}
		else if (subtitleType == SubtitleType.RivalLove)
		{
			this.Label.text = this.RivalLove[ID];
		}
		else if (subtitleType == SubtitleType.Dying)
		{
			this.Label.text = this.GetRandomString(this.Deaths);
		}
		else if (subtitleType == SubtitleType.SenpaiInsanityReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiInsanityReactions.Length);
			this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiWeaponReactions.Length);
			this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiBloodReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiBloodReactions.Length);
			this.Label.text = this.SenpaiBloodReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiLewdReaction)
		{
			this.Label.text = this.GetRandomString(this.SenpaiLewdReactions);
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.SenpaiStalkingReaction)
		{
			this.Label.text = this.SenpaiStalkingReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.SenpaiMurderReaction)
		{
			this.Label.text = this.SenpaiMurderReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.SenpaiCorpseReaction)
		{
			this.Label.text = this.GetRandomString(this.SenpaiCorpseReactions);
		}
		else if (subtitleType == SubtitleType.YandereWhimper)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.YandereWhimpers.Length);
			this.Label.text = this.YandereWhimpers[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.StudentMurderReport)
		{
			this.Label.text = this.StudentMurderReports[ID];
		}
		else if (subtitleType == SubtitleType.SplashReaction)
		{
			this.Label.text = this.SplashReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.RivalSplashReaction)
		{
			this.Label.text = this.RivalSplashReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.LightSwitchReaction)
		{
			this.Label.text = this.LightSwitchReactions[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.PhotoAnnoyance)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PhotoAnnoyances.Length);
			this.Label.text = this.PhotoAnnoyances[this.RandomID];
		}
		else if (subtitleType == SubtitleType.Task6Line)
		{
			this.Label.text = this.Task6Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task7Line)
		{
			this.Label.text = this.Task7Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task13Line)
		{
			this.Label.text = this.Task13Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task14Line)
		{
			this.Label.text = this.Task14Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task15Line)
		{
			this.Label.text = this.Task15Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task32Line)
		{
			this.Label.text = this.Task32Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task33Line)
		{
			this.Label.text = this.Task33Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task34Line)
		{
			this.Label.text = this.Task34Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task81Line)
		{
			this.Label.text = this.Task81Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubGreeting)
		{
			this.Label.text = this.ClubGreetings[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubUnwelcome)
		{
			this.Label.text = this.ClubUnwelcomes[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubKick)
		{
			this.Label.text = this.ClubKicks[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubPlaceholderInfo)
		{
			this.Label.text = this.Club0Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubOccultInfo)
		{
			this.Label.text = this.Club3Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubArtInfo)
		{
			this.Label.text = this.Club4Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubMartialArtsInfo)
		{
			this.Label.text = this.Club6Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubJoin)
		{
			this.Label.text = this.ClubJoins[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubAccept)
		{
			this.Label.text = this.ClubAccepts[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubRefuse)
		{
			this.Label.text = this.ClubRefuses[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubRejoin)
		{
			this.Label.text = this.ClubRejoins[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubExclusive)
		{
			this.Label.text = this.ClubExclusives[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubGrudge)
		{
			this.Label.text = this.ClubGrudges[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubQuit)
		{
			this.Label.text = this.ClubQuits[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubConfirm)
		{
			this.Label.text = this.ClubConfirms[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubDeny)
		{
			this.Label.text = this.ClubDenies[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubFarewell)
		{
			this.Label.text = this.ClubFarewells[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubActivity)
		{
			this.Label.text = this.ClubActivities[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubEarly)
		{
			this.Label.text = this.ClubEarlies[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubLate)
		{
			this.Label.text = this.ClubLates[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubYes)
		{
			this.Label.text = this.ClubYeses[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubNo)
		{
			this.Label.text = this.ClubNoes[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.InfoNotice)
		{
			this.Label.text = this.InfoNotice;
		}
		else if (subtitleType == SubtitleType.StrictReaction)
		{
			this.Label.text = this.StrictReaction[ID];
		}
		else if (subtitleType == SubtitleType.CasualReaction)
		{
			this.Label.text = this.CasualReaction[ID];
		}
		else if (subtitleType == SubtitleType.GraceReaction)
		{
			this.Label.text = this.GraceReaction[ID];
		}
		else if (subtitleType == SubtitleType.EdgyReaction)
		{
			this.Label.text = this.EdgyReaction[ID];
		}
		else if (subtitleType == SubtitleType.Shoving)
		{
			this.Label.text = this.Shoving[ID];
		}
		else if (subtitleType == SubtitleType.Spraying)
		{
			this.Label.text = this.Spraying[ID];
		}
		else if (subtitleType == SubtitleType.Chasing)
		{
			this.Label.text = this.Chasing[ID];
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

	private void PlayVoice(SubtitleType subtitleType, int ID)
	{
		if (this.CurrentClip != null)
		{
			UnityEngine.Object.Destroy(this.CurrentClip);
		}
		this.Jukebox.Dip = 0.5f;
		AudioClipArrayWrapper audioClipArrayWrapper;
		bool flag = this.SubtitleClipArrays.TryGetValue(subtitleType, out audioClipArrayWrapper);
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
		if (StudentID == 81)
		{
			return this.Task81Clips[TaskPhase].length;
		}
		return 0f;
	}

	public float GetClubClipLength(ClubType Club, int ClubPhase)
	{
		if (Club == ClubType.Occult)
		{
			return this.Club3Clips[ClubPhase].length;
		}
		if (Club == ClubType.Art)
		{
			return this.Club4Clips[ClubPhase].length;
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
