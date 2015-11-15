using System;
using UnityEngine;

[Serializable]
public class StruggleBarScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public PromptSwapScript ButtonPrompt;

	public YandereScript Yandere;

	public StudentScript Student;

	public Transform Spikes;

	public string CurrentButton;

	public bool Struggling;

	public float ButtonTimer;

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
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			float z = this.Spikes.localEulerAngles.z - Time.deltaTime * (float)360;
			Vector3 localEulerAngles = this.Spikes.localEulerAngles;
			float num = localEulerAngles.z = z;
			Vector3 vector = this.Spikes.localEulerAngles = localEulerAngles;
			this.Victory -= Time.deltaTime * (float)20 * this.Strength;
			if (Input.GetButtonDown(this.CurrentButton))
			{
				this.Victory += Time.deltaTime * (float)(500 + PlayerPrefs.GetInt("PhysicalGrade") * 100);
			}
			if (this.Victory >= (float)100)
			{
				this.Victory = (float)100;
			}
			if (this.Victory <= (float)-100)
			{
				this.Victory = (float)-100;
			}
			float x = Mathf.Lerp(this.ButtonPrompt.transform.localPosition.x, this.Victory * 6.5f, Time.deltaTime * (float)10);
			Vector3 localPosition = this.ButtonPrompt.transform.localPosition;
			float num2 = localPosition.x = x;
			Vector3 vector2 = this.ButtonPrompt.transform.localPosition = localPosition;
			float x2 = this.ButtonPrompt.transform.localPosition.x;
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
				this.HeroWins();
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
		else
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
	}

	public virtual void HeroWins()
	{
		this.Yandere.Lost = true;
		this.Student.Won = true;
		this.Struggling = false;
		this.Victory = (float)0;
	}

	public virtual void ChooseButton()
	{
		int buttonID = this.ButtonID;
		while (this.ButtonID == buttonID)
		{
			this.ButtonID = UnityEngine.Random.Range(1, 5);
		}
		if (this.ButtonID == 1)
		{
			this.CurrentButton = "A";
			this.ButtonPrompt.GamepadName = "A";
			this.ButtonPrompt.KeyboardName = "E_Key";
		}
		else if (this.ButtonID == 2)
		{
			this.CurrentButton = "B";
			this.ButtonPrompt.GamepadName = "B";
			this.ButtonPrompt.KeyboardName = "Q_Key";
		}
		else if (this.ButtonID == 3)
		{
			this.CurrentButton = "X";
			this.ButtonPrompt.GamepadName = "X";
			this.ButtonPrompt.KeyboardName = "F_Key";
		}
		else if (this.ButtonID == 4)
		{
			this.CurrentButton = "Y";
			this.ButtonPrompt.GamepadName = "Y";
			this.ButtonPrompt.KeyboardName = "R_Key";
		}
	}

	public virtual void Main()
	{
	}
}
