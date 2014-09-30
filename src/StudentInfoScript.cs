using System;
using UnityEngine;

[Serializable]
public class StudentInfoScript : MonoBehaviour
{
	public FirstPersonYandereScript FirstPersonYandere;

	public UILabel NameLabel;

	public UILabel ClubLabel;

	public UILabel CrushLabel;

	public UILabel PersonalityLabel;

	public UISprite PortraitSprite;

	public virtual void UpdateInfo()
	{
		this.NameLabel.text = string.Empty + this.FirstPersonYandere.TargetStudent.StudentName;
		this.CrushLabel.text = string.Empty + this.FirstPersonYandere.TargetStudent.StudentCrush;
		this.PortraitSprite.spriteName = string.Empty + this.FirstPersonYandere.TargetStudent.StudentPortrait;
		this.GetClubName();
		this.GetPersonalityName();
	}

	public virtual void GetClubName()
	{
		if (this.FirstPersonYandere.TargetStudent.StudentClub == 1)
		{
			this.ClubLabel.text = "Martial Arts Club";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 2)
		{
			this.ClubLabel.text = "Sports Club";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 3)
		{
			this.ClubLabel.text = "Gardening Club";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 4)
		{
			this.ClubLabel.text = "Sewing Club";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 5)
		{
			this.ClubLabel.text = "Photography Club";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 6)
		{
			this.ClubLabel.text = "Light Music";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 7)
		{
			this.ClubLabel.text = "Drama";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentClub == 8)
		{
			this.ClubLabel.text = "Computer";
		}
	}

	public virtual void GetPersonalityName()
	{
		if (this.FirstPersonYandere.TargetStudent.StudentPersonality == 1)
		{
			this.PersonalityLabel.text = "Coward";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentPersonality == 2)
		{
			this.PersonalityLabel.text = "Teacher's Pet";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentPersonality == 3)
		{
			this.PersonalityLabel.text = "Social Butterfly";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentPersonality == 4)
		{
			this.PersonalityLabel.text = "Hero Complex";
		}
		else if (this.FirstPersonYandere.TargetStudent.StudentPersonality == 5)
		{
			this.PersonalityLabel.text = "Sadistic";
		}
	}

	public virtual void Main()
	{
	}
}
