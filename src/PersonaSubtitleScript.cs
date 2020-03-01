using System;
using UnityEngine;

public class PersonaSubtitleScript : MonoBehaviour
{
	public SubtitleScript Subtitle;

	public string[] LonerReactions;

	public string[] TeachersPetReactions;

	public string[] HeroicReactions;

	public string[] CowardReactions;

	public string[] EvilReactions;

	public string[] SocialButterflyReactions;

	public string[] LovestruckReactions;

	public string[] DangerousReactions;

	public string[] StrictReactions;

	public string[] PhoneAddictReactions;

	public string[] FragileReactions;

	public string[] SpitefulReactions;

	public string[] SleuthReactions;

	public string[] VengefulReactions;

	public string[] ProtectiveReactions;

	public string[] ViolentReactions;

	public string[] NemesisReactions;

	public string[] SubtitleArray;

	public void UpdateLabel(PersonaType Persona, float Reputation, float Duration)
	{
		switch (Persona)
		{
		case PersonaType.Loner:
			this.SubtitleArray = this.LonerReactions;
			break;
		case PersonaType.TeachersPet:
			this.SubtitleArray = this.TeachersPetReactions;
			break;
		case PersonaType.Heroic:
			this.SubtitleArray = this.HeroicReactions;
			break;
		case PersonaType.Coward:
			this.SubtitleArray = this.CowardReactions;
			break;
		case PersonaType.Evil:
			this.SubtitleArray = this.EvilReactions;
			break;
		case PersonaType.SocialButterfly:
			this.SubtitleArray = this.SocialButterflyReactions;
			break;
		case PersonaType.Lovestruck:
			this.SubtitleArray = this.LovestruckReactions;
			break;
		case PersonaType.Dangerous:
			this.SubtitleArray = this.DangerousReactions;
			break;
		case PersonaType.Strict:
			this.SubtitleArray = this.StrictReactions;
			break;
		case PersonaType.PhoneAddict:
			this.SubtitleArray = this.PhoneAddictReactions;
			break;
		case PersonaType.Fragile:
			this.SubtitleArray = this.FragileReactions;
			break;
		case PersonaType.Spiteful:
			this.SubtitleArray = this.SpitefulReactions;
			break;
		case PersonaType.Sleuth:
			this.SubtitleArray = this.SleuthReactions;
			break;
		case PersonaType.Vengeful:
			this.SubtitleArray = this.VengefulReactions;
			break;
		case PersonaType.Protective:
			this.SubtitleArray = this.ProtectiveReactions;
			break;
		case PersonaType.Violent:
			this.SubtitleArray = this.ViolentReactions;
			break;
		default:
			if (Persona == PersonaType.Nemesis)
			{
				this.SubtitleArray = this.NemesisReactions;
			}
			break;
		}
		if (Reputation < -0.333333343f)
		{
			this.Subtitle.Label.text = this.SubtitleArray[1];
		}
		else if (Reputation > 0.333333343f)
		{
			this.Subtitle.Label.text = this.SubtitleArray[3];
		}
		else
		{
			this.Subtitle.Label.text = this.SubtitleArray[2];
		}
		this.Subtitle.Timer = Duration;
	}
}
