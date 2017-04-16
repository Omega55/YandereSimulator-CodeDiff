using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DelinquentManagerScript : MonoBehaviour
{
	public GameObject Delinquents;

	public GameObject RapBeat;

	public GameObject Panel;

	public float[] NextTime;

	public DelinquentScript Attacker;

	public MirrorScript Mirror;

	public UILabel TimeLabel;

	public ClockScript Clock;

	public UISprite Circle;

	public float SpeechTimer;

	public float TimerMax;

	public float Timer;

	public bool Aggro;

	public int Phase;

	public DelinquentManagerScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.Delinquents.active = false;
		this.TimerMax = (float)15;
		this.Timer = (float)15;
		this.Phase++;
	}

	public virtual void Update()
	{
		this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, (float)0, Time.deltaTime);
		if (this.Attacker != null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro)
		{
			this.audio.clip = this.Attacker.AggroClips[UnityEngine.Random.Range(0, Extensions.get_length(this.Attacker.AggroClips))];
			this.audio.Play();
			this.Aggro = true;
		}
		if (this.Panel.active && this.Clock.HourTime > this.NextTime[this.Phase])
		{
			if (this.Phase == 3 && this.Clock.HourTime > 7.25f)
			{
				this.TimerMax = (float)75;
				this.Timer = (float)75;
				this.Phase++;
			}
			else if (this.Phase == 5 && this.Clock.HourTime > 8.5f)
			{
				this.TimerMax = (float)285;
				this.Timer = (float)285;
				this.Phase++;
			}
			else if (this.Phase == 7 && this.Clock.HourTime > 13.25f)
			{
				this.TimerMax = (float)15;
				this.Timer = (float)15;
				this.Phase++;
			}
			else if (this.Phase == 9 && this.Clock.HourTime > 13.5f)
			{
				this.TimerMax = (float)135;
				this.Timer = (float)135;
				this.Phase++;
			}
			this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / (float)60);
			this.Circle.fillAmount = (float)1 - this.Timer / this.TimerMax;
			if (this.Timer <= (float)0)
			{
				if (this.Delinquents.active)
				{
					this.Delinquents.active = false;
				}
				else
				{
					this.Delinquents.active = true;
				}
				if (this.Phase < 8)
				{
					this.Phase++;
				}
				else
				{
					this.Delinquents.active = false;
					this.Panel.active = false;
				}
			}
		}
	}

	public virtual void CheckTime()
	{
		if (this.Clock.HourTime < (float)13)
		{
			this.Delinquents.active = false;
			this.TimerMax = (float)15;
			this.Timer = (float)15;
			this.Phase = 6;
		}
		else if (this.Clock.HourTime < 15.5f)
		{
			this.Delinquents.active = false;
			this.TimerMax = (float)15;
			this.Timer = (float)15;
			this.Phase = 8;
		}
	}

	public virtual void EasterEgg()
	{
		this.RapBeat.active = true;
		this.Mirror.Limit = this.Mirror.Limit + 1;
	}

	public virtual void Main()
	{
	}
}
