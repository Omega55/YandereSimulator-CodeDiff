using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public string[] CowardCorpseReactions;

	public string[] PetMurderReports;

	public string[] PetMurderReactions;

	public string[] PetCorpseReports;

	public string[] PetCorpseReactions;

	public string[] HeroMurderReactions;

	public string[] RepeatReactions;

	public string[] CorpseReactions;

	public string[] PrankReactions;

	public string[] InterruptReactions;

	public string[] NoteReactions;

	public string[] KnifeReactions;

	public string[] SyringeReactions;

	public string[] KatanaReactions;

	public string[] WeaponBloodApologies;

	public string[] WeaponApologies;

	public string[] BloodApologies;

	public string[] InsanityApologies;

	public string[] LewdApologies;

	public string[] EventApologies;

	public string[] Greetings;

	public string[] PlayerFarewells;

	public string[] StudentFarewells;

	public string[] Forgivings;

	public string[] InsanityForgivings;

	public string[] PlayerCompliments;

	public string[] StudentCompliments;

	public string[] PlayerGossip;

	public string[] StudentGossip;

	public string[] PlayerFollows;

	public string[] StudentFollows;

	public string[] PlayerLeaves;

	public string[] StudentLeaves;

	public string[] PlayerDistracts;

	public string[] StudentDistracts;

	public string[] StudentDistractRefuses;

	public string[] StopFollowApologies;

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

	public string[] StudentMurderReports;

	public string[] YandereWhimpers;

	public string[] SplashReactions;

	public string[] LightSwitchReactions;

	public string[] Task6Lines;

	public int RandomID;

	public float Timer;

	public AudioClip[] NoteReactionClips;

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

	public AudioClip[] SplashReactionClips;

	public AudioClip[] LightSwitchClips;

	public AudioClip[] Task6Clips;

	public GameObject CurrentClip;

	public virtual void Start()
	{
		this.Label.text = string.Empty;
	}

	public virtual void UpdateLabel(string ReactionType, int ID, float Duration)
	{
		if (ReactionType == "Weapon and Blood and Insanity Reaction")
		{
			this.Label.text = this.WeaponBloodInsanityReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponBloodInsanityReactions))];
		}
		else if (ReactionType == "Weapon and Blood Reaction")
		{
			this.Label.text = this.WeaponBloodReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponBloodReactions))];
		}
		else if (ReactionType == "Weapon and Insanity Reaction")
		{
			this.Label.text = this.WeaponInsanityReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponInsanityReactions))];
		}
		else if (ReactionType == "Blood and Insanity Reaction")
		{
			this.Label.text = this.BloodInsanityReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.BloodInsanityReactions))];
		}
		else if (ReactionType == "Weapon Reaction")
		{
			if (ID == 1)
			{
				this.Label.text = this.KnifeReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.KnifeReactions))];
			}
			else if (ID == 2)
			{
				this.Label.text = this.KatanaReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.KatanaReactions))];
			}
			else if (ID == 3)
			{
				this.Label.text = this.SyringeReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.SyringeReactions))];
			}
		}
		else if (ReactionType == "Blood Reaction")
		{
			this.Label.text = this.BloodReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.BloodReactions))];
		}
		else if (ReactionType == "Wet Blood Reaction")
		{
			this.Label.text = this.WetBloodReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.WetBloodReactions))];
		}
		else if (ReactionType == "Insanity Reaction")
		{
			this.Label.text = this.InsanityReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.InsanityReactions))];
		}
		else if (ReactionType == "Lewd Reaction")
		{
			this.Label.text = this.LewdReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.LewdReactions))];
		}
		else if (ReactionType == "Prank Reaction")
		{
			this.Label.text = this.PrankReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.LewdReactions))];
		}
		else if (ReactionType == "Interruption Reaction")
		{
			this.Label.text = this.InterruptReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.InterruptReactions))];
		}
		else if (ReactionType == "Note Reaction")
		{
			this.Label.text = this.NoteReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Weapon Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherWeaponReactions));
			this.Label.text = this.TeacherWeaponReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Blood Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherBloodReactions));
			this.Label.text = this.TeacherBloodReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Insanity Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherInsanityReactions));
			this.Label.text = this.TeacherInsanityReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Weapon Hostile")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherWeaponHostiles));
			this.Label.text = this.TeacherWeaponHostiles[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Blood Hostile")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherBloodHostiles));
			this.Label.text = this.TeacherBloodHostiles[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Insanity Hostile")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherInsanityHostiles));
			this.Label.text = this.TeacherInsanityHostiles[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Lewd Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherLewdReactions));
			this.Label.text = this.TeacherLewdReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Trespassing Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherTrespassReactions));
			this.Label.text = this.TeacherTrespassReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Late Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherLateReactions));
			this.Label.text = this.TeacherLateReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Teacher Report Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherReportReactions));
			this.Label.text = this.TeacherReportReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Corpse Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherCorpseReactions));
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
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherPoliceReports));
			this.Label.text = this.TeacherPoliceReports[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Teacher Attack Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherAttackReactions));
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
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherPrankReactions));
			this.Label.text = this.TeacherPrankReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Murder Reaction")
		{
			this.Label.text = this.MurderReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.MurderReactions))];
		}
		else if (ReactionType == "Coward Murder Reaction")
		{
			this.Label.text = this.CowardMurderReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.CowardMurderReactions))];
		}
		else if (ReactionType == "Corpse Reaction")
		{
			this.Label.text = this.CorpseReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.CorpseReactions))];
		}
		else if (ReactionType == "Coward Corpse Reaction")
		{
			this.Label.text = this.CowardCorpseReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.CowardCorpseReactions))];
		}
		else if (ReactionType == "Pet Murder Report")
		{
			this.Label.text = this.PetMurderReports[ID];
		}
		else if (ReactionType == "Pet Murder Reaction")
		{
			this.Label.text = this.PetMurderReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.PetMurderReactions))];
		}
		else if (ReactionType == "Pet Corpse Report")
		{
			this.Label.text = this.PetCorpseReports[ID];
		}
		else if (ReactionType == "Pet Corpse Reaction")
		{
			this.Label.text = this.PetCorpseReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.PetCorpseReactions))];
		}
		else if (ReactionType == "Hero Murder Reaction")
		{
			this.Label.text = this.HeroMurderReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.HeroMurderReactions))];
		}
		else if (ReactionType == "Repeat Reaction")
		{
			this.Label.text = this.RepeatReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.RepeatReactions))];
		}
		else if (ReactionType == "Greeting")
		{
			this.Label.text = this.Greetings[UnityEngine.Random.Range(0, Extensions.get_length(this.Greetings))];
		}
		else if (ReactionType == "Player Farewell")
		{
			this.Label.text = this.PlayerFarewells[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerFarewells))];
		}
		else if (ReactionType == "Student Farewell")
		{
			this.Label.text = this.StudentFarewells[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentFarewells))];
		}
		else if (ReactionType == "Insanity Apology")
		{
			this.Label.text = this.InsanityApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.InsanityApologies))];
		}
		else if (ReactionType == "Weapon and Blood Apology")
		{
			this.Label.text = this.WeaponBloodApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponBloodApologies))];
		}
		else if (ReactionType == "Weapon Apology")
		{
			this.Label.text = this.WeaponApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponApologies))];
		}
		else if (ReactionType == "Blood Apology")
		{
			this.Label.text = this.BloodApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.BloodApologies))];
		}
		else if (ReactionType == "Lewd Apology")
		{
			this.Label.text = this.LewdApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.LewdApologies))];
		}
		else if (ReactionType == "Event Apology")
		{
			this.Label.text = this.EventApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.EventApologies))];
		}
		else if (ReactionType == "Forgiving")
		{
			this.Label.text = this.Forgivings[UnityEngine.Random.Range(0, Extensions.get_length(this.Forgivings))];
		}
		else if (ReactionType == "Forgiving Insanity")
		{
			this.Label.text = this.InsanityForgivings[UnityEngine.Random.Range(0, Extensions.get_length(this.InsanityForgivings))];
		}
		else if (ReactionType == "Impatience")
		{
			if (ID == 1)
			{
				this.Label.text = this.Impatiences[UnityEngine.Random.Range(0, Extensions.get_length(this.Impatiences))];
			}
			else
			{
				this.Label.text = this.ImpatientFarewells[UnityEngine.Random.Range(0, Extensions.get_length(this.ImpatientFarewells))];
			}
		}
		else if (ReactionType == "Player Compliment")
		{
			this.Label.text = this.PlayerCompliments[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerCompliments))];
		}
		else if (ReactionType == "Student Compliment")
		{
			this.Label.text = this.StudentCompliments[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentCompliments))];
		}
		else if (ReactionType == "Player Gossip")
		{
			this.Label.text = this.PlayerGossip[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerGossip))];
		}
		else if (ReactionType == "Student Gossip")
		{
			this.Label.text = this.StudentGossip[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerGossip))];
		}
		else if (ReactionType == "Player Follow")
		{
			this.Label.text = this.PlayerFollows[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerFollows))];
		}
		else if (ReactionType == "Student Follow")
		{
			this.Label.text = this.StudentFollows[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentFollows))];
		}
		else if (ReactionType == "Player Leave")
		{
			this.Label.text = this.PlayerLeaves[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerLeaves))];
		}
		else if (ReactionType == "Student Leave")
		{
			this.Label.text = this.StudentLeaves[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentLeaves))];
		}
		else if (ReactionType == "Player Distract")
		{
			this.Label.text = this.PlayerDistracts[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerDistracts))];
		}
		else if (ReactionType == "Student Distract")
		{
			this.Label.text = this.StudentDistracts[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentDistracts))];
		}
		else if (ReactionType == "Student Distract Refuse")
		{
			this.Label.text = this.StudentDistractRefuses[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentDistractRefuses))];
		}
		else if (ReactionType == "Stop Follow Apology")
		{
			this.Label.text = this.StopFollowApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.StopFollowApologies))];
		}
		else if (ReactionType == "Dying")
		{
			this.Label.text = this.Deaths[UnityEngine.Random.Range(0, Extensions.get_length(this.Deaths))];
		}
		else if (ReactionType == "Senpai Insanity Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.SenpaiInsanityReactions));
			this.Label.text = this.SenpaiInsanityReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Weapon Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.SenpaiWeaponReactions));
			this.Label.text = this.SenpaiWeaponReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Blood Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.SenpaiBloodReactions));
			this.Label.text = this.SenpaiBloodReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Lewd Reaction")
		{
			this.Label.text = this.SenpaiLewdReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.SenpaiLewdReactions))];
		}
		else if (ReactionType == "Senpai Stalking Reaction")
		{
			this.Label.text = this.SenpaiStalkingReactions[ID];
			this.PlayVoice(ReactionType, ID);
		}
		else if (ReactionType == "Senpai Murder Reaction")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.SenpaiMurderReactions));
			this.Label.text = this.SenpaiMurderReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Senpai Corpse Reaction")
		{
			this.Label.text = this.SenpaiCorpseReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.SenpaiCorpseReactions))];
		}
		else if (ReactionType == "Yandere Whimper")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.YandereWhimpers));
			this.Label.text = this.YandereWhimpers[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
		}
		else if (ReactionType == "Student Murder Report")
		{
			this.Label.text = this.StudentMurderReports[ID];
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
		this.Timer = Duration;
	}

	public virtual void Update()
	{
		if (this.Timer > (float)0)
		{
			this.Timer -= Time.deltaTime;
			if (this.Timer <= (float)0)
			{
				this.Jukebox.Dip = (float)1;
				this.Label.text = string.Empty;
				this.Timer = (float)0;
			}
		}
	}

	public virtual void PlayVoice(string ReactionType, int ID)
	{
		this.Jukebox.Dip = 0.5f;
		if (ReactionType == "Note Reaction")
		{
			this.PlayClip(this.NoteReactionClips[ID], this.transform.position);
		}
		if (ReactionType == "Senpai Insanity Reaction")
		{
			this.PlayClip(this.SenpaiInsanityReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Senpai Weapon Reaction")
		{
			this.PlayClip(this.SenpaiWeaponReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Senpai Blood Reaction")
		{
			this.PlayClip(this.SenpaiBloodReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Senpai Lewd Reaction")
		{
			this.PlayClip(this.SenpaiLewdReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Senpai Stalking Reaction")
		{
			this.PlayClip(this.SenpaiStalkingReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Senpai Murder Reaction")
		{
			this.PlayClip(this.SenpaiMurderReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Yandere Whimper")
		{
			this.PlayClip(this.YandereWhimperClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Weapon Reaction")
		{
			this.PlayClip(this.TeacherWeaponClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Blood Reaction")
		{
			this.PlayClip(this.TeacherBloodClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Insanity Reaction")
		{
			this.PlayClip(this.TeacherInsanityClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Weapon Hostile")
		{
			this.PlayClip(this.TeacherWeaponHostileClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Blood Hostile")
		{
			this.PlayClip(this.TeacherBloodHostileClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Insanity Hostile")
		{
			this.PlayClip(this.TeacherInsanityHostileClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Lewd Reaction")
		{
			this.PlayClip(this.TeacherLewdClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Trespassing Reaction")
		{
			this.PlayClip(this.TeacherTrespassClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Late Reaction")
		{
			this.PlayClip(this.TeacherLateClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Report Reaction")
		{
			this.PlayClip(this.TeacherReportClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Corpse Reaction")
		{
			this.PlayClip(this.TeacherCorpseClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Corpse Inspection")
		{
			this.PlayClip(this.TeacherInspectClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Police Report")
		{
			this.PlayClip(this.TeacherPoliceClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Attack Reaction")
		{
			this.PlayClip(this.TeacherAttackClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Murder Reaction")
		{
			this.PlayClip(this.TeacherMurderClips[ID], this.transform.position);
		}
		else if (ReactionType == "Teacher Prank Reaction")
		{
			this.PlayClip(this.TeacherPrankClips[ID], this.transform.position);
		}
		else if (ReactionType == "Splash Reaction")
		{
			this.PlayClip(this.SplashReactionClips[ID], this.transform.position);
		}
		else if (ReactionType == "Light Switch Reaction")
		{
			this.PlayClip(this.LightSwitchClips[ID], this.transform.position);
		}
		else if (ReactionType == "Task 6 Line")
		{
			this.PlayClip(this.Task6Clips[ID], this.transform.position);
		}
	}

	public virtual float GetClipLength(int StudentID, int TaskPhase)
	{
		return (StudentID != 6) ? ((float)0) : this.Task6Clips[TaskPhase].length;
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
		this.CurrentClip = gameObject;
		if (this.Yandere.position.y < gameObject.transform.position.y - (float)2)
		{
			audioSource.volume = (float)0;
		}
		else
		{
			audioSource.volume = (float)1;
		}
	}

	public virtual void Main()
	{
	}
}
