using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SubtitleScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public UILabel Label;

	public string[] WeaponBloodInsanityReactions;

	public string[] WeaponBloodReactions;

	public string[] WeaponInsanityReactions;

	public string[] BloodInsanityReactions;

	public string[] BloodReactions;

	public string[] InsanityReactions;

	public string[] LewdReactions;

	public string[] MurderReactions;

	public string[] CowardMurderReactions;

	public string[] CowardCorpseReactions;

	public string[] PetMurderReports;

	public string[] PetMurderReactions;

	public string[] PetCorpseReports;

	public string[] PetCorpseReactions;

	public string[] RepeatReactions;

	public string[] CorpseReactions;

	public string[] PrankReactions;

	public string[] NoteReactions;

	public string[] KnifeReactions;

	public string[] SyringeReactions;

	public string[] KatanaReactions;

	public string[] WeaponBloodApologies;

	public string[] WeaponApologies;

	public string[] BloodApologies;

	public string[] InsanityApologies;

	public string[] LewdApologies;

	public string[] Greetings;

	public string[] PlayerFarewells;

	public string[] StudentFarewells;

	public string[] Forgivings;

	public string[] InsanityForgivings;

	public string[] PlayerCompliments;

	public string[] StudentCompliments;

	public string[] PlayerFollows;

	public string[] StudentFollows;

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
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherCorpseInspections));
			this.Label.text = this.TeacherCorpseInspections[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
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
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.TeacherMurderReactions));
			this.Label.text = this.TeacherMurderReactions[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
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
		else if (ReactionType == "Player Follow")
		{
			this.Label.text = this.PlayerFollows[UnityEngine.Random.Range(0, Extensions.get_length(this.PlayerFollows))];
		}
		else if (ReactionType == "Student Follow")
		{
			this.Label.text = this.StudentFollows[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentFollows))];
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
			this.audio.PlayOneShot(this.NoteReactionClips[ID]);
		}
		if (ReactionType == "Senpai Insanity Reaction")
		{
			this.audio.PlayOneShot(this.SenpaiInsanityReactionClips[ID]);
		}
		else if (ReactionType == "Senpai Weapon Reaction")
		{
			this.audio.PlayOneShot(this.SenpaiWeaponReactionClips[ID]);
		}
		else if (ReactionType == "Senpai Blood Reaction")
		{
			this.audio.PlayOneShot(this.SenpaiBloodReactionClips[ID]);
		}
		else if (ReactionType == "Senpai Lewd Reaction")
		{
			this.audio.PlayOneShot(this.SenpaiLewdReactionClips[ID]);
		}
		else if (ReactionType == "Senpai Stalking Reaction")
		{
			this.audio.PlayOneShot(this.SenpaiStalkingReactionClips[ID]);
		}
		else if (ReactionType == "Senpai Murder Reaction")
		{
			this.audio.PlayOneShot(this.SenpaiMurderReactionClips[ID]);
		}
		else if (ReactionType == "Yandere Whimper")
		{
			this.audio.PlayOneShot(this.YandereWhimperClips[ID]);
		}
		else if (ReactionType == "Teacher Weapon Reaction")
		{
			this.audio.PlayOneShot(this.TeacherWeaponClips[ID]);
		}
		else if (ReactionType == "Teacher Blood Reaction")
		{
			this.audio.PlayOneShot(this.TeacherBloodClips[ID]);
		}
		else if (ReactionType == "Teacher Insanity Reaction")
		{
			this.audio.PlayOneShot(this.TeacherInsanityClips[ID]);
		}
		else if (ReactionType == "Teacher Weapon Hostile")
		{
			this.audio.PlayOneShot(this.TeacherWeaponHostileClips[ID]);
		}
		else if (ReactionType == "Teacher Blood Hostile")
		{
			this.audio.PlayOneShot(this.TeacherBloodHostileClips[ID]);
		}
		else if (ReactionType == "Teacher Insanity Hostile")
		{
			this.audio.PlayOneShot(this.TeacherInsanityHostileClips[ID]);
		}
		else if (ReactionType == "Teacher Lewd Reaction")
		{
			this.audio.PlayOneShot(this.TeacherLewdClips[ID]);
		}
		else if (ReactionType == "Teacher Trespassing Reaction")
		{
			this.audio.PlayOneShot(this.TeacherTrespassClips[ID]);
		}
		else if (ReactionType == "Teacher Late Reaction")
		{
			this.audio.PlayOneShot(this.TeacherLateClips[ID]);
		}
		else if (ReactionType == "Teacher Report Reaction")
		{
			this.audio.PlayOneShot(this.TeacherReportClips[ID]);
		}
		else if (ReactionType == "Teacher Corpse Reaction")
		{
			this.audio.PlayOneShot(this.TeacherCorpseClips[ID]);
		}
		else if (ReactionType == "Teacher Corpse Inspection")
		{
			this.audio.PlayOneShot(this.TeacherInspectClips[ID]);
		}
		else if (ReactionType == "Teacher Police Report")
		{
			this.audio.PlayOneShot(this.TeacherPoliceClips[ID]);
		}
		else if (ReactionType == "Teacher Attack Reaction")
		{
			this.audio.PlayOneShot(this.TeacherAttackClips[ID]);
		}
		else if (ReactionType == "Teacher Murder Reaction")
		{
			this.audio.PlayOneShot(this.TeacherMurderClips[ID]);
		}
		else if (ReactionType == "Teacher Prank Reaction")
		{
			this.audio.PlayOneShot(this.TeacherPrankClips[ID]);
		}
	}

	public virtual void Main()
	{
	}
}
