using System;
using UnityEngine;

[Serializable]
public class StruggleBarScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public PromptSwapScript ButtonPrompt;

	public UISprite[] ButtonPrompts;

	public YandereScript Yandere;

	public StudentScript Student;

	public Transform Spikes;

	public string CurrentButton;

	public bool Struggling;

	public bool Invincible;

	public float ButtonTimer;

	public float Intensity;

	public float Strength;

	public float Struggle;

	public float Victory;

	public int ButtonID;

	public StruggleBarScript()
	{
		this.CurrentButton = string.Empty;
		this.Strength = 1f;
	}

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.ChooseButton();
	}

	public virtual void Update()
	{
		if (this.Struggling)
		{
			this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			float z = this.Spikes.localEulerAngles.z - Time.deltaTime * (float)360;
			Vector3 localEulerAngles = this.Spikes.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.Spikes.localEulerAngles = localEulerAngles;
			this.Victory -= Time.deltaTime * (float)20 * this.Strength * this.Intensity;
			if (PlayerPrefs.GetInt("Club") == 6)
			{
				this.Victory = (float)100;
			}
			if (Input.GetButtonDown(this.CurrentButton))
			{
				if (this.Invincible)
				{
					this.Victory += (float)100;
				}
				this.Victory += Time.deltaTime * (float)(500 + (PlayerPrefs.GetInt("PhysicalGrade") + PlayerPrefs.GetInt("PhysicalBonus")) * 150) * this.Intensity;
			}
			if (this.Victory >= (float)100)
			{
				this.Victory = (float)100;
			}
			if (this.Victory <= (float)-100)
			{
				this.Victory = (float)-100;
			}
			float x = Mathf.Lerp(this.ButtonPrompts[this.ButtonID].transform.localPosition.x, this.Victory * 6.5f, Time.deltaTime * (float)10);
			Vector3 localPosition = this.ButtonPrompts[this.ButtonID].transform.localPosition;
			float num2 = localPosition.x = x;
			Vector3 vector2 = this.ButtonPrompts[this.ButtonID].transform.localPosition = localPosition;
			float x2 = this.ButtonPrompts[this.ButtonID].transform.localPosition.x;
			Vector3 localPosition2 = this.Spikes.localPosition;
			float num3 = localPosition2.x = x2;
			Vector3 vector3 = this.Spikes.localPosition = localPosition2;
			if (this.Victory == (float)100)
			{
				this.Yandere.Won = true;
				this.Student.Lost = true;
				this.Struggling = false;
				this.Victory = (float)0;
			}
			else if (this.Victory == (float)-100)
			{
				if (!this.Invincible)
				{
					this.HeroWins();
				}
			}
			else
			{
				this.ButtonTimer += Time.deltaTime;
				if (this.ButtonTimer >= (float)1)
				{
					this.ChooseButton();
					this.ButtonTimer = (float)0;
				}
			}
		}
		else if (this.transform.localScale.x > 0.1f)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
			this.active = false;
		}
	}

	public virtual void HeroWins()
	{
		if (this.Yandere.Armed)
		{
			this.Yandere.Weapon[this.Yandere.Equipped].Drop();
		}
		this.Yandere.Lost = true;
		this.Student.Won = true;
		this.Struggling = false;
		this.Victory = (float)0;
	}

	public virtual void ChooseButton()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		int buttonID = this.ButtonID;
		while (this.ButtonID == buttonID)
		{
			this.ButtonID = UnityEngine.Random.Range(1, 5);
		}
		if (this.ButtonID == 1)
		{
			this.CurrentButton = "A";
		}
		else if (this.ButtonID == 2)
		{
			this.CurrentButton = "B";
		}
		else if (this.ButtonID == 3)
		{
			this.CurrentButton = "X";
		}
		else if (this.ButtonID == 4)
		{
			this.CurrentButton = "Y";
		}
		this.ButtonPrompts[this.ButtonID].enabled = true;
	}

	public virtual void Main()
	{
	}
}
