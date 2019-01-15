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

	public string[] EvilDelinquentCorpseReactions;

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

	public string[] IntrusionReactions;

	public string[] NoteReactions;

	public string[] FoodAccepts;

	public string[] FoodRejects;

	public string[] EavesdropReactions;

	public string[] ViolenceReactions;

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

	public string[] PropReactions;

	public string[] DelinkWeaponReactions;

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

	public string[] ViolenceApologies;

	public string[] PickpocketApologies;

	public string[] CleaningApologies;

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

	public string[] StudentDistractBullyRefuses;

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

	public string[] SenpaiViolenceReactions;

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

	public string[] DelinquentAnnoys;

	public string[] DelinquentCases;

	public string[] DelinquentShoves;

	public string[] DelinquentReactions;

	public string[] DelinquentWeaponReactions;

	public string[] DelinquentThreateneds;

	public string[] DelinquentTaunts;

	public string[] DelinquentCalms;

	public string[] DelinquentFights;

	public string[] DelinquentAvenges;

	public string[] DelinquentWins;

	public string[] DelinquentSurrenders;

	public string[] DelinquentNoSurrenders;

	public string[] DelinquentMurderReactions;

	public string[] DelinquentCorpseReactions;

	public string[] DelinquentFriendCorpseReactions;

	public string[] DelinquentResumes;

	public string[] DelinquentFlees;

	public string[] DelinquentEnemyFlees;

	public string[] DelinquentFriendFlees;

	public string[] DelinquentInjuredFlees;

	public string[] DelinquentCheers;

	public string[] DelinquentHmms;

	public string[] DelinquentGrudges;

	public string[] Dismissives;

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

	public string[] Task8Lines;

	public string[] Task11Lines;

	public string[] Task13Lines;

	public string[] Task14Lines;

	public string[] Task15Lines;

	public string[] Task25Lines;

	public string[] Task28Lines;

	public string[] Task30Lines;

	public string[] Task32Lines;

	public string[] Task33Lines;

	public string[] Task34Lines;

	public string[] Task36Lines;

	public string[] Task37Lines;

	public string[] Task38Lines;

	public string[] Task52Lines;

	public string[] Task81Lines;

	public string[] TaskInquiries;

	public string[] Club0Info;

	public string[] Club1Info;

	public string[] Club2Info;

	public string[] Club3Info;

	public string[] Club4Info;

	public string[] Club5Info;

	public string[] Club6Info;

	public string[] Club7InfoLight;

	public string[] Club7InfoDark;

	public string[] Club8Info;

	public string[] Club9Info;

	public string[] Club10Info;

	public string[] Club11Info;

	public string[] SubClub3Info;

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

	public string[] ClubPractices;

	public string[] ClubPracticeYeses;

	public string[] ClubPracticeNoes;

	public string[] StrictReaction;

	public string[] CasualReaction;

	public string[] GraceReaction;

	public string[] EdgyReaction;

	public string[] Spraying;

	public string[] Shoving;

	public string[] Chasing;

	public string[] CouncilCorpseReactions;

	public string[] HmmReactions;

	public string[] Eulogies;

	public string InfoNotice;

	public int RandomID;

	public float Timer;

	public int StudentID;

	public AudioClip[] NoteReactionClips;

	public AudioClip[] GrudgeWarningClips;

	public AudioClip[] SenpaiInsanityReactionClips;

	public AudioClip[] SenpaiWeaponReactionClips;

	public AudioClip[] SenpaiBloodReactionClips;

	public AudioClip[] SenpaiLewdReactionClips;

	public AudioClip[] SenpaiStalkingReactionClips;

	public AudioClip[] SenpaiMurderReactionClips;

	public AudioClip[] SenpaiViolenceReactionClips;

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

	public AudioClip[] Task8Clips;

	public AudioClip[] Task11Clips;

	public AudioClip[] Task13Clips;

	public AudioClip[] Task14Clips;

	public AudioClip[] Task15Clips;

	public AudioClip[] Task25Clips;

	public AudioClip[] Task28Clips;

	public AudioClip[] Task30Clips;

	public AudioClip[] Task32Clips;

	public AudioClip[] Task33Clips;

	public AudioClip[] Task34Clips;

	public AudioClip[] Task36Clips;

	public AudioClip[] Task37Clips;

	public AudioClip[] Task38Clips;

	public AudioClip[] Task52Clips;

	public AudioClip[] Task81Clips;

	public AudioClip[] TaskInquiryClips;

	public AudioClip[] Club0Clips;

	public AudioClip[] Club1Clips;

	public AudioClip[] Club2Clips;

	public AudioClip[] Club3Clips;

	public AudioClip[] Club4Clips;

	public AudioClip[] Club5Clips;

	public AudioClip[] Club6Clips;

	public AudioClip[] Club7ClipsLight;

	public AudioClip[] Club7ClipsDark;

	public AudioClip[] Club8Clips;

	public AudioClip[] Club9Clips;

	public AudioClip[] Club10Clips;

	public AudioClip[] Club11Clips;

	public AudioClip[] SubClub3Clips;

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

	public AudioClip[] ClubPracticeClips;

	public AudioClip[] ClubPracticeYesClips;

	public AudioClip[] ClubPracticeNoClips;

	public AudioClip[] EavesdropClips;

	public AudioClip[] FoodRejectionClips;

	public AudioClip[] ViolenceClips;

	public AudioClip[] EventEavesdropClips;

	public AudioClip[] RivalEavesdropClips;

	public AudioClip[] DelinquentAnnoyClips;

	public AudioClip[] DelinquentCaseClips;

	public AudioClip[] DelinquentShoveClips;

	public AudioClip[] DelinquentReactionClips;

	public AudioClip[] DelinquentWeaponReactionClips;

	public AudioClip[] DelinquentThreatenedClips;

	public AudioClip[] DelinquentTauntClips;

	public AudioClip[] DelinquentCalmClips;

	public AudioClip[] DelinquentFightClips;

	public AudioClip[] DelinquentAvengeClips;

	public AudioClip[] DelinquentWinClips;

	public AudioClip[] DelinquentSurrenderClips;

	public AudioClip[] DelinquentNoSurrenderClips;

	public AudioClip[] DelinquentMurderReactionClips;

	public AudioClip[] DelinquentCorpseReactionClips;

	public AudioClip[] DelinquentFriendCorpseReactionClips;

	public AudioClip[] DelinquentResumeClips;

	public AudioClip[] DelinquentFleeClips;

	public AudioClip[] DelinquentEnemyFleeClips;

	public AudioClip[] DelinquentFriendFleeClips;

	public AudioClip[] DelinquentInjuredFleeClips;

	public AudioClip[] DelinquentCheerClips;

	public AudioClip[] DelinquentHmmClips;

	public AudioClip[] DelinquentGrudgeClips;

	public AudioClip[] DismissiveClips;

	public AudioClip[] EvilDelinquentCorpseReactionClips;

	public AudioClip[] EulogyClips;

	private SubtitleTypeAndAudioClipArrayDictionary SubtitleClipArrays;

	public GameObject CurrentClip;

	private void Awake()
	{
		this.Club3Info = this.SubClub3Info;
		this.ClubGreetings[3] = this.ClubGreetings[13];
		this.ClubUnwelcomes[3] = this.ClubUnwelcomes[13];
		this.ClubKicks[3] = this.ClubKicks[13];
		this.ClubJoins[3] = this.ClubJoins[13];
		this.ClubAccepts[3] = this.ClubAccepts[13];
		this.ClubRefuses[3] = this.ClubRefuses[13];
		this.ClubRejoins[3] = this.ClubRejoins[13];
		this.ClubExclusives[3] = this.ClubExclusives[13];
		this.ClubGrudges[3] = this.ClubGrudges[13];
		this.ClubQuits[3] = this.ClubQuits[13];
		this.ClubConfirms[3] = this.ClubConfirms[13];
		this.ClubDenies[3] = this.ClubDenies[13];
		this.ClubFarewells[3] = this.ClubFarewells[13];
		this.ClubActivities[3] = this.ClubActivities[13];
		this.ClubEarlies[3] = this.ClubEarlies[13];
		this.ClubLates[3] = this.ClubLates[13];
		this.ClubYeses[3] = this.ClubYeses[13];
		this.ClubNoes[3] = this.ClubNoes[13];
		this.Club3Clips = this.SubClub3Clips;
		this.ClubGreetingClips[3] = this.ClubGreetingClips[13];
		this.ClubUnwelcomeClips[3] = this.ClubUnwelcomeClips[13];
		this.ClubKickClips[3] = this.ClubKickClips[13];
		this.ClubJoinClips[3] = this.ClubJoinClips[13];
		this.ClubAcceptClips[3] = this.ClubAcceptClips[13];
		this.ClubRefuseClips[3] = this.ClubRefuseClips[13];
		this.ClubRejoinClips[3] = this.ClubRejoinClips[13];
		this.ClubExclusiveClips[3] = this.ClubExclusiveClips[13];
		this.ClubGrudgeClips[3] = this.ClubGrudgeClips[13];
		this.ClubQuitClips[3] = this.ClubQuitClips[13];
		this.ClubConfirmClips[3] = this.ClubConfirmClips[13];
		this.ClubDenyClips[3] = this.ClubDenyClips[13];
		this.ClubFarewellClips[3] = this.ClubFarewellClips[13];
		this.ClubActivityClips[3] = this.ClubActivityClips[13];
		this.ClubEarlyClips[3] = this.ClubEarlyClips[13];
		this.ClubLateClips[3] = this.ClubLateClips[13];
		this.ClubYesClips[3] = this.ClubYesClips[13];
		this.ClubNoClips[3] = this.ClubNoClips[13];
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
				SubtitleType.ClubNo,
				new AudioClipArrayWrapper(this.ClubNoClips)
			},
			{
				SubtitleType.ClubPlaceholderInfo,
				new AudioClipArrayWrapper(this.Club0Clips)
			},
			{
				SubtitleType.ClubCookingInfo,
				new AudioClipArrayWrapper(this.Club1Clips)
			},
			{
				SubtitleType.ClubDramaInfo,
				new AudioClipArrayWrapper(this.Club2Clips)
			},
			{
				SubtitleType.ClubOccultInfo,
				new AudioClipArrayWrapper(this.Club3Clips)
			},
			{
				SubtitleType.ClubArtInfo,
				new AudioClipArrayWrapper(this.Club4Clips)
			},
			{
				SubtitleType.ClubLightMusicInfo,
				new AudioClipArrayWrapper(this.Club5Clips)
			},
			{
				SubtitleType.ClubMartialArtsInfo,
				new AudioClipArrayWrapper(this.Club6Clips)
			},
			{
				SubtitleType.ClubPhotoInfoLight,
				new AudioClipArrayWrapper(this.Club7ClipsLight)
			},
			{
				SubtitleType.ClubPhotoInfoDark,
				new AudioClipArrayWrapper(this.Club7ClipsDark)
			},
			{
				SubtitleType.ClubScienceInfo,
				new AudioClipArrayWrapper(this.Club8Clips)
			},
			{
				SubtitleType.ClubSportsInfo,
				new AudioClipArrayWrapper(this.Club9Clips)
			},
			{
				SubtitleType.ClubGardenInfo,
				new AudioClipArrayWrapper(this.Club10Clips)
			},
			{
				SubtitleType.ClubGamingInfo,
				new AudioClipArrayWrapper(this.Club11Clips)
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
				SubtitleType.ClubPractice,
				new AudioClipArrayWrapper(this.ClubPracticeClips)
			},
			{
				SubtitleType.ClubPracticeYes,
				new AudioClipArrayWrapper(this.ClubPracticeYesClips)
			},
			{
				SubtitleType.ClubPracticeNo,
				new AudioClipArrayWrapper(this.ClubPracticeNoClips)
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
				SubtitleType.RejectFood,
				new AudioClipArrayWrapper(this.FoodRejectionClips)
			},
			{
				SubtitleType.ViolenceReaction,
				new AudioClipArrayWrapper(this.ViolenceClips)
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
				SubtitleType.SenpaiViolenceReaction,
				new AudioClipArrayWrapper(this.SenpaiViolenceReactionClips)
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
				SubtitleType.Task8Line,
				new AudioClipArrayWrapper(this.Task8Clips)
			},
			{
				SubtitleType.Task11Line,
				new AudioClipArrayWrapper(this.Task11Clips)
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
				SubtitleType.Task25Line,
				new AudioClipArrayWrapper(this.Task25Clips)
			},
			{
				SubtitleType.Task28Line,
				new AudioClipArrayWrapper(this.Task28Clips)
			},
			{
				SubtitleType.Task30Line,
				new AudioClipArrayWrapper(this.Task30Clips)
			},
			{
				SubtitleType.Task34Line,
				new AudioClipArrayWrapper(this.Task34Clips)
			},
			{
				SubtitleType.Task36Line,
				new AudioClipArrayWrapper(this.Task36Clips)
			},
			{
				SubtitleType.Task37Line,
				new AudioClipArrayWrapper(this.Task37Clips)
			},
			{
				SubtitleType.Task38Line,
				new AudioClipArrayWrapper(this.Task38Clips)
			},
			{
				SubtitleType.Task52Line,
				new AudioClipArrayWrapper(this.Task52Clips)
			},
			{
				SubtitleType.Task81Line,
				new AudioClipArrayWrapper(this.Task81Clips)
			},
			{
				SubtitleType.TaskInquiry,
				new AudioClipArrayWrapper(this.TaskInquiryClips)
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
			},
			{
				SubtitleType.DelinquentAnnoy,
				new AudioClipArrayWrapper(this.DelinquentAnnoyClips)
			},
			{
				SubtitleType.DelinquentCase,
				new AudioClipArrayWrapper(this.DelinquentCaseClips)
			},
			{
				SubtitleType.DelinquentShove,
				new AudioClipArrayWrapper(this.DelinquentShoveClips)
			},
			{
				SubtitleType.DelinquentReaction,
				new AudioClipArrayWrapper(this.DelinquentReactionClips)
			},
			{
				SubtitleType.DelinquentWeaponReaction,
				new AudioClipArrayWrapper(this.DelinquentWeaponReactionClips)
			},
			{
				SubtitleType.DelinquentThreatened,
				new AudioClipArrayWrapper(this.DelinquentThreatenedClips)
			},
			{
				SubtitleType.DelinquentTaunt,
				new AudioClipArrayWrapper(this.DelinquentTauntClips)
			},
			{
				SubtitleType.DelinquentCalm,
				new AudioClipArrayWrapper(this.DelinquentCalmClips)
			},
			{
				SubtitleType.DelinquentFight,
				new AudioClipArrayWrapper(this.DelinquentFightClips)
			},
			{
				SubtitleType.DelinquentAvenge,
				new AudioClipArrayWrapper(this.DelinquentAvengeClips)
			},
			{
				SubtitleType.DelinquentWin,
				new AudioClipArrayWrapper(this.DelinquentWinClips)
			},
			{
				SubtitleType.DelinquentSurrender,
				new AudioClipArrayWrapper(this.DelinquentSurrenderClips)
			},
			{
				SubtitleType.DelinquentNoSurrender,
				new AudioClipArrayWrapper(this.DelinquentNoSurrenderClips)
			},
			{
				SubtitleType.DelinquentMurderReaction,
				new AudioClipArrayWrapper(this.DelinquentMurderReactionClips)
			},
			{
				SubtitleType.DelinquentCorpseReaction,
				new AudioClipArrayWrapper(this.DelinquentCorpseReactionClips)
			},
			{
				SubtitleType.DelinquentFriendCorpseReaction,
				new AudioClipArrayWrapper(this.DelinquentFriendCorpseReactionClips)
			},
			{
				SubtitleType.DelinquentResume,
				new AudioClipArrayWrapper(this.DelinquentResumeClips)
			},
			{
				SubtitleType.DelinquentFlee,
				new AudioClipArrayWrapper(this.DelinquentFleeClips)
			},
			{
				SubtitleType.DelinquentEnemyFlee,
				new AudioClipArrayWrapper(this.DelinquentEnemyFleeClips)
			},
			{
				SubtitleType.DelinquentFriendFlee,
				new AudioClipArrayWrapper(this.DelinquentFriendFleeClips)
			},
			{
				SubtitleType.DelinquentInjuredFlee,
				new AudioClipArrayWrapper(this.DelinquentInjuredFleeClips)
			},
			{
				SubtitleType.DelinquentCheer,
				new AudioClipArrayWrapper(this.DelinquentCheerClips)
			},
			{
				SubtitleType.DelinquentHmm,
				new AudioClipArrayWrapper(this.DelinquentHmmClips)
			},
			{
				SubtitleType.DelinquentGrudge,
				new AudioClipArrayWrapper(this.DelinquentGrudgeClips)
			},
			{
				SubtitleType.Dismissive,
				new AudioClipArrayWrapper(this.DismissiveClips)
			},
			{
				SubtitleType.EvilDelinquentCorpseReaction,
				new AudioClipArrayWrapper(this.EvilDelinquentCorpseReactionClips)
			},
			{
				SubtitleType.Eulogy,
				new AudioClipArrayWrapper(this.EulogyClips)
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
				if (this.StudentID < 31 || this.StudentID > 35)
				{
					this.Label.text = this.RitualReactions[0];
				}
				else
				{
					this.Label.text = this.RitualReactions[1];
				}
			}
			else if (ID == 9)
			{
				this.Label.text = this.GetRandomString(this.BatReactions);
			}
			else if (ID == 10)
			{
				this.Label.text = this.GetRandomString(this.ShovelReactions);
			}
			else if (ID == 11 || ID == 14 || ID == 16 || ID == 17 || ID == 22)
			{
				this.Label.text = this.GetRandomString(this.PropReactions);
			}
			else if (ID == 12)
			{
				this.Label.text = this.GetRandomString(this.DumbbellReactions);
			}
			else if (ID == 13 || ID == 15)
			{
				this.Label.text = this.GetRandomString(this.AxeReactions);
			}
			else if (ID > 17 && ID < 22)
			{
				this.Label.text = this.GetRandomString(this.DelinkWeaponReactions);
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
			this.Label.text = this.SuspiciousReactions[ID];
		}
		else if (subtitleType == SubtitleType.PrankReaction)
		{
			this.Label.text = this.GetRandomString(this.PrankReactions);
		}
		else if (subtitleType == SubtitleType.InterruptionReaction)
		{
			this.Label.text = this.GetRandomString(this.InterruptReactions);
		}
		else if (subtitleType == SubtitleType.IntrusionReaction)
		{
			this.Label.text = this.GetRandomString(this.IntrusionReactions);
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
			this.Label.text = this.FoodRejects[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.EavesdropReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EavesdropReactions.Length);
			this.Label.text = this.EavesdropReactions[this.RandomID];
		}
		else if (subtitleType == SubtitleType.ViolenceReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.ViolenceReactions.Length);
			this.Label.text = this.ViolenceReactions[this.RandomID];
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
		else if (subtitleType == SubtitleType.PickpocketApology)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.PickpocketApologies.Length);
			this.Label.text = this.PickpocketApologies[this.RandomID];
		}
		else if (subtitleType == SubtitleType.CleaningApology)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.CleaningApologies.Length);
			this.Label.text = this.CleaningApologies[this.RandomID];
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
			if (this.Label.text == string.Empty)
			{
				this.RandomID = UnityEngine.Random.Range(0, this.HmmReactions.Length);
				this.Label.text = this.HmmReactions[this.RandomID];
			}
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
		else if (subtitleType == SubtitleType.DelinquentAnnoy)
		{
			this.Label.text = this.DelinquentAnnoys[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.DelinquentCase)
		{
			this.Label.text = this.DelinquentCases[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.DelinquentShove)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentShoves.Length);
			this.Label.text = this.DelinquentShoves[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentReactions.Length);
			this.Label.text = this.DelinquentReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentWeaponReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentWeaponReactions.Length);
			this.Label.text = this.DelinquentWeaponReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentThreatened)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentThreateneds.Length);
			this.Label.text = this.DelinquentThreateneds[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentTaunt)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentTaunts.Length);
			this.Label.text = this.DelinquentTaunts[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentCalm)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentCalms.Length);
			this.Label.text = this.DelinquentCalms[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFight)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFights.Length);
			this.Label.text = this.DelinquentFights[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentAvenge)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentAvenges.Length);
			this.Label.text = this.DelinquentAvenges[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentWin)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentWins.Length);
			this.Label.text = this.DelinquentWins[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentSurrender)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentSurrenders.Length);
			this.Label.text = this.DelinquentSurrenders[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentNoSurrender)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentNoSurrenders.Length);
			this.Label.text = this.DelinquentNoSurrenders[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentMurderReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentMurderReactions.Length);
			this.Label.text = this.DelinquentMurderReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentCorpseReactions.Length);
			this.Label.text = this.DelinquentCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFriendCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFriendCorpseReactions.Length);
			this.Label.text = this.DelinquentFriendCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentResume)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentResumes.Length);
			this.Label.text = this.DelinquentResumes[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFlees.Length);
			this.Label.text = this.DelinquentFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentEnemyFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentEnemyFlees.Length);
			this.Label.text = this.DelinquentEnemyFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentFriendFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentFriendFlees.Length);
			this.Label.text = this.DelinquentFriendFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentInjuredFlee)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentInjuredFlees.Length);
			this.Label.text = this.DelinquentInjuredFlees[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentCheer)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentCheers.Length);
			this.Label.text = this.DelinquentCheers[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.DelinquentHmm)
		{
			if (this.Label.text == string.Empty)
			{
				this.RandomID = UnityEngine.Random.Range(0, this.DelinquentHmms.Length);
				this.Label.text = this.DelinquentHmms[this.RandomID];
				this.PlayVoice(subtitleType, this.RandomID);
			}
		}
		else if (subtitleType == SubtitleType.DelinquentGrudge)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.DelinquentGrudges.Length);
			this.Label.text = this.DelinquentGrudges[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
		}
		else if (subtitleType == SubtitleType.Dismissive)
		{
			this.Label.text = this.Dismissives[ID];
			this.PlayVoice(subtitleType, ID);
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
		else if (subtitleType == SubtitleType.EvilDelinquentCorpseReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.EvilDelinquentCorpseReactions.Length);
			this.Label.text = this.EvilDelinquentCorpseReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
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
		else if (subtitleType == SubtitleType.ViolenceApology)
		{
			this.Label.text = this.GetRandomString(this.ViolenceApologies);
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
		else if (subtitleType == SubtitleType.Dismissive)
		{
			this.Label.text = this.Dismissives[ID];
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
			this.Label.text = this.StudentStays[ID];
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
		else if (subtitleType == SubtitleType.StudentDistractBullyRefuse)
		{
			this.Label.text = this.GetRandomString(this.StudentDistractBullyRefuses);
		}
		else if (subtitleType == SubtitleType.StopFollowApology)
		{
			this.Label.text = this.StopFollowApologies[ID];
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
		else if (subtitleType == SubtitleType.SenpaiViolenceReaction)
		{
			this.RandomID = UnityEngine.Random.Range(0, this.SenpaiViolenceReactions.Length);
			this.Label.text = this.SenpaiViolenceReactions[this.RandomID];
			this.PlayVoice(subtitleType, this.RandomID);
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
		else if (subtitleType == SubtitleType.Task8Line)
		{
			this.Label.text = this.Task8Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task11Line)
		{
			this.Label.text = this.Task11Lines[ID];
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
		else if (subtitleType == SubtitleType.Task25Line)
		{
			this.Label.text = this.Task25Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task28Line)
		{
			this.Label.text = this.Task28Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task30Line)
		{
			this.Label.text = this.Task30Lines[ID];
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
		else if (subtitleType == SubtitleType.Task36Line)
		{
			this.Label.text = this.Task36Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task37Line)
		{
			this.Label.text = this.Task37Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task38Line)
		{
			this.Label.text = this.Task38Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task52Line)
		{
			this.Label.text = this.Task52Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.Task81Line)
		{
			this.Label.text = this.Task81Lines[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.TaskInquiry)
		{
			this.Label.text = this.TaskInquiries[ID];
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
		else if (subtitleType == SubtitleType.ClubPractice)
		{
			this.Label.text = this.ClubPractices[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubPracticeYes)
		{
			this.Label.text = this.ClubPracticeYeses[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubPracticeNo)
		{
			this.Label.text = this.ClubPracticeNoes[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubPlaceholderInfo)
		{
			this.Label.text = this.Club0Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubCookingInfo)
		{
			this.Label.text = this.Club1Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubDramaInfo)
		{
			this.Label.text = this.Club2Info[ID];
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
		else if (subtitleType == SubtitleType.ClubLightMusicInfo)
		{
			this.Label.text = this.Club5Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubMartialArtsInfo)
		{
			this.Label.text = this.Club6Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubPhotoInfoLight)
		{
			this.Label.text = this.Club7InfoLight[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubPhotoInfoDark)
		{
			this.Label.text = this.Club7InfoDark[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubScienceInfo)
		{
			this.Label.text = this.Club8Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubSportsInfo)
		{
			this.Label.text = this.Club9Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubGardenInfo)
		{
			this.Label.text = this.Club10Info[ID];
			this.PlayVoice(subtitleType, ID);
		}
		else if (subtitleType == SubtitleType.ClubGamingInfo)
		{
			this.Label.text = this.Club11Info[ID];
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
		else if (subtitleType == SubtitleType.Eulogy)
		{
			this.Label.text = this.Eulogies[ID];
			this.PlayVoice(subtitleType, ID);
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
		if (StudentID == 8)
		{
			return this.Task8Clips[TaskPhase].length;
		}
		if (StudentID == 11)
		{
			return this.Task11Clips[TaskPhase].length;
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
		if (StudentID == 25)
		{
			return this.Task25Clips[TaskPhase].length;
		}
		if (StudentID == 28)
		{
			return this.Task28Clips[TaskPhase].length;
		}
		if (StudentID == 30)
		{
			return this.Task30Clips[TaskPhase].length;
		}
		if (StudentID == 33)
		{
			return this.Task33Clips[TaskPhase].length;
		}
		if (StudentID == 34)
		{
			return this.Task34Clips[TaskPhase].length;
		}
		if (StudentID == 36)
		{
			return this.Task36Clips[TaskPhase].length;
		}
		if (StudentID == 37)
		{
			return this.Task37Clips[TaskPhase].length;
		}
		if (StudentID == 38)
		{
			return this.Task38Clips[TaskPhase].length;
		}
		if (StudentID == 52)
		{
			return this.Task52Clips[TaskPhase].length;
		}
		if (StudentID == 81)
		{
			return this.Task81Clips[TaskPhase].length;
		}
		return 0f;
	}

	public float GetClubClipLength(ClubType Club, int ClubPhase)
	{
		if (Club == ClubType.Cooking)
		{
			return this.Club1Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Drama)
		{
			return this.Club2Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Occult)
		{
			return this.Club3Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Art)
		{
			return this.Club4Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.LightMusic)
		{
			return this.Club5Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.MartialArts)
		{
			return this.Club6Clips[ClubPhase].length + 0.5f;
		}
		if (Club == ClubType.Photography)
		{
			if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
			{
				return this.Club7ClipsDark[ClubPhase].length + 0.5f;
			}
			return this.Club7ClipsLight[ClubPhase].length + 0.5f;
		}
		else
		{
			if (Club == ClubType.Science)
			{
				return this.Club8Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Sports)
			{
				return this.Club9Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Gardening)
			{
				return this.Club10Clips[ClubPhase].length + 0.5f;
			}
			if (Club == ClubType.Gaming)
			{
				return this.Club11Clips[ClubPhase].length + 0.5f;
			}
			return 0f;
		}
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
