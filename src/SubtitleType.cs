﻿using System;

public enum SubtitleType
{
	AcceptFood,
	AccidentApology,
	AskForHelp,
	BloodApology,
	BloodReaction,
	BloodAndInsanityReaction,
	BloodPoolReaction,
	BloodyWeaponReaction,
	ClassApology,
	ClubAccept,
	ClubActivity,
	ClubConfirm,
	ClubDeny,
	ClubEarly,
	ClubExclusive,
	ClubFarewell,
	ClubGreeting,
	ClubGrudge,
	ClubJoin,
	ClubKick,
	ClubLate,
	ClubCookingInfo,
	ClubDramaInfo,
	ClubOccultInfo,
	ClubArtInfo,
	ClubLightMusicInfo,
	ClubMartialArtsInfo,
	ClubPlaceholderInfo,
	ClubPhotoInfoLight,
	ClubPhotoInfoDark,
	ClubScienceInfo,
	ClubSportsInfo,
	ClubGardenInfo,
	ClubGamingInfo,
	ClubDelinquentInfo,
	ClubNo,
	ClubQuit,
	ClubRefuse,
	ClubRejoin,
	ClubUnwelcome,
	ClubYes,
	ClubPractice,
	ClubPracticeYes,
	ClubPracticeNo,
	CleaningApology,
	CorpseReaction,
	CowardGrudge,
	CowardMurderReaction,
	DelinquentAnnoy,
	DelinquentCase,
	DelinquentShove,
	DelinquentReaction,
	DelinquentWeaponReaction,
	DelinquentTaunt,
	DelinquentThreatened,
	DelinquentCalm,
	DelinquentFight,
	DelinquentAvenge,
	DelinquentWin,
	DelinquentSurrender,
	DelinquentNoSurrender,
	DelinquentMurderReaction,
	DelinquentCorpseReaction,
	DelinquentFriendCorpseReaction,
	DelinquentResume,
	DelinquentFlee,
	DelinquentEnemyFlee,
	DelinquentFriendFlee,
	DelinquentInjuredFlee,
	DelinquentCheer,
	DelinquentHmm,
	DelinquentGrudge,
	Dismissive,
	DrownReaction,
	Dying,
	EavesdropReaction,
	EventEavesdropReaction,
	EavesdropApology,
	Eulogy,
	EventApology,
	EvilCorpseReaction,
	EvilDelinquentCorpseReaction,
	EvilGrudge,
	EvilMurderReaction,
	Forgiving,
	ForgivingAccident,
	ForgivingInsanity,
	GiveHelp,
	Greeting,
	GrudgeRefusal,
	GrudgeWarning,
	HeroMurderReaction,
	HmmReaction,
	HoldingBloodyClothingApology,
	HoldingBloodyClothingReaction,
	Impatience,
	InfoNotice,
	InsanityApology,
	InsanityReaction,
	InterruptionReaction,
	IntrusionReaction,
	KilledMood,
	LewdApology,
	LewdReaction,
	LightSwitchReaction,
	LimbReaction,
	LonerCorpseReaction,
	LonerMurderReaction,
	LostPhone,
	LovestruckCorpseReport,
	LovestruckDeathReaction,
	LovestruckMurderReport,
	MurderReaction,
	NoteReaction,
	NoteReactionMale,
	ObstacleMurderReaction,
	ObstaclePoisonReaction,
	OfferSnack,
	ParanoidReaction,
	PetBloodReaction,
	PetBloodReport,
	PetCorpseReaction,
	PetCorpseReport,
	PetLimbReaction,
	PetLimbReport,
	PetMurderReaction,
	PetMurderReport,
	PetWeaponReaction,
	PetWeaponReport,
	PetBloodyWeaponReaction,
	PetBloodyWeaponReport,
	PhotoAnnoyance,
	PickpocketReaction,
	PickpocketApology,
	PlayerCompliment,
	PlayerDistract,
	PlayerFarewell,
	PlayerFollow,
	PlayerGossip,
	PlayerLeave,
	PlayerLove,
	PoisonApology,
	PoisonReaction,
	PrankReaction,
	RaibaruRivalDeathReaction,
	RejectFood,
	RejectHelp,
	RepeatReaction,
	RequestMedicine,
	ReturningWeapon,
	RivalEavesdropReaction,
	RivalLostPhone,
	RivalLove,
	RivalPickpocketReaction,
	RivalSplashReaction,
	SadApology,
	SendToLocker,
	SenpaiBloodReaction,
	SenpaiCorpseReaction,
	SenpaiInsanityReaction,
	SenpaiLewdReaction,
	SenpaiMurderReaction,
	SenpaiStalkingReaction,
	SenpaiViolenceReaction,
	SenpaiWeaponReaction,
	SenpaiRivalDeathReaction,
	SocialDeathReaction,
	SocialFear,
	SocialReport,
	SocialTerror,
	SplashReaction,
	SplashReactionMale,
	SuitorLove,
	SuspiciousApology,
	SuspiciousReaction,
	StopFollowApology,
	StudentDistract,
	StudentDistractRefuse,
	StudentDistractBullyRefuse,
	StudentFarewell,
	StudentFollow,
	StudentGossip,
	StudentHighCompliment,
	StudentLeave,
	StudentLowCompliment,
	StudentMidCompliment,
	StudentMurderReport,
	StudentStay,
	Task6Line,
	Task7Line,
	Task8Line,
	Task11Line,
	Task13Line,
	Task14Line,
	Task15Line,
	Task25Line,
	Task28Line,
	Task30Line,
	Task32Line,
	Task33Line,
	Task34Line,
	Task36Line,
	Task37Line,
	Task38Line,
	Task52Line,
	Task76Line,
	Task77Line,
	Task78Line,
	Task79Line,
	Task80Line,
	Task81Line,
	TaskGenericLine,
	TaskGenericLineMale,
	TaskGenericLineFemale,
	TaskInquiry,
	TeacherAttackReaction,
	TeacherBloodHostile,
	TeacherBloodReaction,
	TeacherCorpseInspection,
	TeacherCorpseReaction,
	TeacherCoverUpHostile,
	TeacherInsanityHostile,
	TeacherInsanityReaction,
	TeacherLateReaction,
	TeacherLewdReaction,
	TeacherMurderReaction,
	TeacherPoliceReport,
	TeacherPrankReaction,
	TeacherReportReaction,
	TeacherTheftReaction,
	TeacherTrespassingReaction,
	TeacherWeaponHostile,
	TeacherWeaponReaction,
	TheftApology,
	TheftReaction,
	ViolenceApology,
	ViolenceReaction,
	WeaponApology,
	WeaponReaction,
	WeaponAndBloodApology,
	WeaponAndBloodReaction,
	WeaponAndInsanityReaction,
	WeaponAndBloodAndInsanityReaction,
	WetBloodReaction,
	YandereWhimper,
	StrictReaction,
	CasualReaction,
	GraceReaction,
	EdgyReaction,
	Spraying,
	Shoving,
	Chasing,
	CouncilCorpseReaction,
	CouncilToCounselor
}
