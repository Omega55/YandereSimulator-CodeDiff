using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SubtitleScript : MonoBehaviour
{
	public UILabel Label;

	public string[] KnifeReactions;

	public string[] BloodReactions;

	public string[] WeaponAndBloodReactions;

	public string[] WeaponApologies;

	public string[] BloodApologies;

	public string[] WeaponAndBloodApologies;

	public string[] Greetings;

	public string[] PlayerFarewells;

	public string[] StudentFarewells;

	public string[] Forgivings;

	public string[] Impatiences;

	public string[] ImpatientFarewells;

	public string[] Deaths;

	public float Timer;

	public virtual void Start()
	{
		this.Label.text = string.Empty;
	}

	public virtual void UpdateLabel(string ReactionType, int ID, float Duration)
	{
		if (ReactionType == "Weapon Reaction")
		{
			if (ID == 1)
			{
				this.Label.text = this.KnifeReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.KnifeReactions))];
			}
		}
		else if (ReactionType == "Blood Reaction")
		{
			this.Label.text = this.BloodReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.BloodReactions))];
		}
		else if (ReactionType == "Weapon and Blood Reaction")
		{
			this.Label.text = this.WeaponAndBloodReactions[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponAndBloodReactions))];
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
		else if (ReactionType == "Weapon Apology")
		{
			this.Label.text = this.WeaponApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponApologies))];
		}
		else if (ReactionType == "Blood Apology")
		{
			this.Label.text = this.BloodApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.BloodApologies))];
		}
		else if (ReactionType == "Weapon and Blood Apology")
		{
			this.Label.text = this.WeaponAndBloodApologies[UnityEngine.Random.Range(0, Extensions.get_length(this.WeaponAndBloodApologies))];
		}
		else if (ReactionType == "Forgiving")
		{
			this.Label.text = this.Forgivings[UnityEngine.Random.Range(0, Extensions.get_length(this.Forgivings))];
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
		else if (ReactionType == "Dying")
		{
			this.Label.text = this.Deaths[UnityEngine.Random.Range(0, Extensions.get_length(this.Deaths))];
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

	public virtual void Main()
	{
	}
}
