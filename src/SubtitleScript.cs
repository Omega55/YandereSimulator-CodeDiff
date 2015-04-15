using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SubtitleScript : MonoBehaviour
{
	public UILabel Label;

	public string[] WeaponBloodInsanityReactions;

	public string[] WeaponBloodReactions;

	public string[] WeaponInsanityReactions;

	public string[] BloodInsanityReactions;

	public string[] BloodReactions;

	public string[] InsanityReactions;

	public string[] MurderReactions;

	public string[] CowardReactions;

	public string[] RepeatReactions;

	public string[] KnifeReactions;

	public string[] SyringeReactions;

	public string[] KatanaReactions;

	public string[] WeaponBloodApologies;

	public string[] WeaponApologies;

	public string[] BloodApologies;

	public string[] InsanityApologies;

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

	public string[] SenpaiStalkingReactions;

	public string[] SenpaiMurderReactions;

	public string[] YandereWhimpers;

	public int RandomID;

	public float Timer;

	public AudioClip[] SenpaiInsanityReactionClips;

	public AudioClip[] SenpaiWeaponReactionClips;

	public AudioClip[] SenpaiBloodReactionClips;

	public AudioClip[] SenpaiStalkingReactionClips;

	public AudioClip[] SenpaiMurderReactionClips;

	public AudioClip[] YandereWhimperClips;

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
		else if (ReactionType == "Murder Reaction")
		{
			this.Label.text = this.MurderReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.MurderReactions))];
		}
		else if (ReactionType == "Coward Reaction")
		{
			this.Label.text = this.CowardReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.CowardReactions))];
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
		else if (ReactionType == "Yandere Whimper")
		{
			this.RandomID = UnityEngine.Random.Range(0, Extensions.get_length(this.YandereWhimpers));
			this.Label.text = this.YandereWhimpers[this.RandomID];
			this.PlayVoice(ReactionType, this.RandomID);
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
				this.Label.text = string.Empty;
				this.Timer = (float)0;
			}
		}
	}

	public virtual void PlayVoice(string ReactionType, int ID)
	{
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
	}

	public virtual void Main()
	{
	}
}
