using System;
using UnityEngine;

[Serializable]
public class ScheduleManagerScript : MonoBehaviour
{
	public ClassMarkerScript ClassMarker;

	public YandereScript YandereChan;

	public RPG_Camera YandereCamera;

	public ClockScript Clock;

	public GameObject MainCamera;

	public GameObject Classroom;

	public GameObject Lights;

	public UILabel ObjectiveLabel;

	public UILabel TimeUpGraphic;

	public UISprite Black;

	public Transform BeforeClassSpawn;

	public Transform LunchtimeSpawn;

	public float Timer;

	public int Phase;

	public bool ChangingTime;

	public bool FadeOut;

	public bool FadeIn;

	public bool TimeUp;

	public ScheduleManagerScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.TimeUpGraphic.active = false;
		int num = 1;
		Color color = this.Black.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Black.color = color;
		this.FadeIn = true;
	}

	public virtual void Update()
	{
		if (!this.ChangingTime)
		{
			if (this.Phase == 1)
			{
				if (this.Clock.Hour / (float)5 > 8.5f)
				{
					this.OutOfTime();
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Clock.Hour / (float)5 > 1.5f)
				{
					this.OutOfTime();
				}
			}
			else if (this.Phase == 3 && this.Clock.Hour / (float)5 > (float)6)
			{
				this.OutOfTime();
			}
		}
		if (this.TimeUp)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.TimeUp = false;
				this.FadeOut = true;
				this.Timer = (float)0;
			}
		}
		if (this.FadeOut)
		{
			float a = this.Black.color.a + Time.deltaTime;
			Color color = this.Black.color;
			float num = color.a = a;
			Color color2 = this.Black.color = color;
			if (this.Black.color.a >= (float)1)
			{
				this.Phase++;
				if (this.Phase < 4)
				{
					this.GoToClass();
				}
				else
				{
					this.UpdateTime();
				}
				this.TimeUpGraphic.active = false;
				this.FadeOut = false;
			}
		}
		if (this.FadeIn)
		{
			float a2 = this.Black.color.a - Time.deltaTime;
			Color color3 = this.Black.color;
			float num2 = color3.a = a2;
			Color color4 = this.Black.color = color3;
			if (this.Black.color.a <= (float)0)
			{
				int num3 = 0;
				Color color5 = this.Black.color;
				float num4 = color5.a = (float)num3;
				Color color6 = this.Black.color = color5;
				this.YandereChan.AcceptingInput = true;
				this.FadeIn = false;
			}
		}
	}

	public virtual void GoToClass()
	{
		this.MainCamera.active = false;
		this.Classroom.active = true;
		this.Lights.active = false;
	}

	public virtual void UpdateTime()
	{
		this.MainCamera.active = true;
		this.Classroom.active = false;
		this.Lights.active = true;
		this.FadeIn = true;
		if (this.Phase == 2)
		{
			this.Clock.Hour = (float)5;
			this.Clock.Minute = (float)0;
			this.Clock.AMPM = "PM";
			this.Clock.TimeOfDayLabel.text = "Lunch Time";
			this.ObjectiveLabel.text = "Return to class by 1:30 PM";
		}
		else if (this.Phase == 3)
		{
			this.Clock.Hour = 17.5f;
			this.Clock.Minute = (float)150;
			this.Clock.TimeOfDayLabel.text = "After School";
			this.ObjectiveLabel.text = "Leave school by 6:00 PM";
			this.ClassMarker.transform.position = this.BeforeClassSpawn.position;
			this.ClassMarker.Label.text = "     " + "Go Home";
		}
		if (this.Phase < 4)
		{
			this.YandereChan.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
			this.YandereChan.transform.position = this.LunchtimeSpawn.position;
			this.YandereCamera.UpdateRotation();
		}
		else
		{
			Application.LoadLevel("HomeScene");
		}
		this.Clock.StopTime = false;
	}

	public virtual void OutOfTime()
	{
		this.YandereChan.AcceptingInput = false;
		this.TimeUpGraphic.active = true;
		this.Clock.StopTime = true;
		this.ChangingTime = true;
		this.TimeUp = true;
	}

	public virtual void ChangeTime()
	{
		this.YandereChan.AcceptingInput = false;
		this.Clock.StopTime = true;
		this.ChangingTime = true;
		this.FadeOut = true;
	}

	public virtual void Main()
	{
	}
}
