using System;
using UnityEngine;

[Serializable]
public class TallLockerScript : MonoBehaviour
{
	public GameObject[] Schoolwear;

	public GameObject SteamCloud;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform Hinge;

	public bool SteamCountdown;

	public bool YandereLocker;

	public bool Open;

	public float Rotation;

	public float Timer;

	public int Phase;

	public TallLockerScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.UpdateSchoolwear();
		this.Prompt.HideButton[1] = true;
		this.Prompt.HideButton[2] = true;
		this.Prompt.HideButton[3] = true;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.Open = true;
				this.Prompt.HideButton[1] = false;
				this.Prompt.HideButton[2] = false;
				this.Prompt.HideButton[3] = false;
				this.UpdateSchoolwear();
				this.Prompt.Label[0].text = "     " + "Close";
			}
			else
			{
				this.Open = false;
				this.Prompt.HideButton[1] = true;
				this.Prompt.HideButton[2] = true;
				this.Prompt.HideButton[3] = true;
				this.Prompt.Label[0].text = "     " + "Open";
			}
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.HideButton[3] = true;
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)-180, Time.deltaTime * (float)10);
			if (this.Prompt.Circle[1].fillAmount <= (float)0)
			{
				if (this.Yandere.Schoolwear == 1)
				{
					this.Yandere.Schoolwear = 0;
				}
				else
				{
					this.Yandere.Schoolwear = 1;
				}
				this.SpawnSteam();
			}
			else if (this.Prompt.Circle[2].fillAmount <= (float)0)
			{
				if (this.Yandere.Schoolwear == 2)
				{
					this.Yandere.Schoolwear = 0;
				}
				else
				{
					this.Yandere.Schoolwear = 2;
				}
				this.SpawnSteam();
			}
			else if (this.Prompt.Circle[3].fillAmount <= (float)0)
			{
				if (this.Yandere.Schoolwear == 3)
				{
					this.Yandere.Schoolwear = 0;
				}
				else
				{
					this.Yandere.Schoolwear = 3;
				}
				this.SpawnSteam();
			}
		}
		this.Hinge.localEulerAngles = new Vector3((float)0, this.Rotation, (float)0);
		if (this.SteamCountdown)
		{
			this.Timer += Time.deltaTime;
			if (this.Phase == 1)
			{
				if (this.Timer > 1.5f)
				{
					if (this.YandereLocker)
					{
						this.Yandere.ChangeSchoolwear();
					}
					else
					{
						this.Student.ChangeSchoolwear();
					}
					this.UpdateSchoolwear();
					this.Phase++;
				}
			}
			else if (this.Timer > (float)3)
			{
				if (this.YandereLocker)
				{
					this.Yandere.CanMove = true;
				}
				else
				{
					this.Student.BathePhase = this.Student.BathePhase + 1;
				}
				this.SteamCountdown = false;
				this.Phase = 1;
				this.Timer = (float)0;
			}
		}
	}

	public virtual void SpawnSteam()
	{
		this.SteamCountdown = true;
		if (this.YandereLocker)
		{
			UnityEngine.Object.Instantiate(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Yandere.Character.animation.CrossFade("f02_stripping_00");
			this.Yandere.CanMove = false;
		}
		else
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.SteamCloud, this.Student.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			gameObject.transform.parent = this.Student.transform;
			this.Student.Character.animation.CrossFade(this.Student.StripAnim);
			this.Student.Pathfinding.canSearch = false;
			this.Student.Pathfinding.canMove = false;
		}
	}

	public virtual void UpdateSchoolwear()
	{
		this.Schoolwear[1].active = true;
		this.Schoolwear[2].active = true;
		this.Schoolwear[3].active = true;
		this.Prompt.Label[1].text = "     " + "School Uniform";
		this.Prompt.Label[2].text = "     " + "School Swimsuit";
		this.Prompt.Label[3].text = "     " + "Gym Uniform";
		if (this.YandereLocker)
		{
			if (this.Yandere.Schoolwear > 0)
			{
				this.Prompt.Label[this.Yandere.Schoolwear].text = "     " + "Nude";
				this.Schoolwear[this.Yandere.Schoolwear].active = false;
			}
		}
		else if (this.Student != null && this.Student.Schoolwear > 0)
		{
			this.Prompt.HideButton[this.Student.Schoolwear] = true;
			this.Schoolwear[this.Student.Schoolwear].active = false;
		}
	}

	public virtual void Main()
	{
	}
}
