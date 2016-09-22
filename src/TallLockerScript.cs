using System;
using UnityEngine;

[Serializable]
public class TallLockerScript : MonoBehaviour
{
	public GameObject[] BloodyClubUniform;

	public GameObject[] BloodyUniform;

	public GameObject[] Schoolwear;

	public bool[] Removed;

	public bool[] Bloody;

	public GameObject CleanUniform;

	public GameObject SteamCloud;

	public StudentManagerScript StudentManager;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform Hinge;

	public bool RemovingClubAttire;

	public bool DropCleanUniform;

	public bool SteamCountdown;

	public bool YandereLocker;

	public bool Swapping;

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
				if (this.YandereLocker)
				{
					if (!this.Yandere.ClubAttire || (this.Yandere.ClubAttire && this.Yandere.Bloodiness > (float)0))
					{
						if (this.Yandere.Bloodiness == (float)0)
						{
							if (!this.Bloody[1])
							{
								this.Prompt.HideButton[1] = false;
							}
							if (!this.Bloody[2])
							{
								this.Prompt.HideButton[2] = false;
							}
							if (!this.Bloody[3])
							{
								this.Prompt.HideButton[3] = false;
							}
						}
						else if (this.Yandere.Schoolwear > 0)
						{
							this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
						}
					}
					else
					{
						this.Prompt.HideButton[1] = true;
						this.Prompt.HideButton[2] = true;
						this.Prompt.HideButton[3] = true;
					}
				}
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
				this.Yandere.EmptyHands();
				if (this.Yandere.ClubAttire)
				{
					this.RemovingClubAttire = true;
				}
				this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
				if (this.Yandere.Schoolwear == 1)
				{
					this.Yandere.Schoolwear = 0;
					if (!this.Removed[1])
					{
						if (this.Yandere.Bloodiness == (float)0)
						{
							this.DropCleanUniform = true;
						}
					}
					else
					{
						this.Removed[1] = false;
					}
				}
				else
				{
					this.Yandere.Schoolwear = 1;
					this.Removed[1] = true;
				}
				this.SpawnSteam();
			}
			else if (this.Prompt.Circle[2].fillAmount <= (float)0)
			{
				this.Yandere.EmptyHands();
				if (this.Yandere.ClubAttire)
				{
					this.RemovingClubAttire = true;
				}
				this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
				if (this.Yandere.Schoolwear == 1 && !this.Removed[1])
				{
					this.DropCleanUniform = true;
				}
				if (this.Yandere.Schoolwear == 2)
				{
					this.Yandere.Schoolwear = 0;
					this.Removed[2] = false;
				}
				else
				{
					this.Yandere.Schoolwear = 2;
					this.Removed[2] = true;
				}
				this.SpawnSteam();
			}
			else if (this.Prompt.Circle[3].fillAmount <= (float)0)
			{
				this.Yandere.EmptyHands();
				if (this.Yandere.ClubAttire)
				{
					this.RemovingClubAttire = true;
				}
				this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
				if (this.Yandere.Schoolwear == 1 && !this.Removed[1])
				{
					this.DropCleanUniform = true;
				}
				if (this.Yandere.Schoolwear == 3)
				{
					this.Yandere.Schoolwear = 0;
					this.Removed[3] = false;
				}
				else
				{
					this.Yandere.Schoolwear = 3;
					this.Removed[3] = true;
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
						if (this.Yandere.Gloved)
						{
							this.Yandere.Gloves.transform.localPosition = new Vector3((float)0, (float)1, (float)-1);
							this.Yandere.Gloves.transform.parent = null;
							this.Yandere.Gloves.active = true;
							this.Yandere.Gloved = false;
							this.Yandere.Gloves = null;
						}
						this.Yandere.ChangeSchoolwear();
						if (this.Yandere.Bloodiness > (float)0)
						{
							if (this.RemovingClubAttire)
							{
								UnityEngine.Object.Instantiate(this.BloodyClubUniform[PlayerPrefs.GetInt("Club")], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up * (float)1, Quaternion.identity);
								this.StudentManager.ChangingBooths[PlayerPrefs.GetInt("Club")].CannotChange = true;
								this.StudentManager.ChangingBooths[PlayerPrefs.GetInt("Club")].CheckYandereClub();
								this.Prompt.HideButton[1] = true;
								this.Prompt.HideButton[2] = true;
								this.Prompt.HideButton[3] = true;
								this.RemovingClubAttire = false;
							}
							else
							{
								UnityEngine.Object.Instantiate(this.BloodyUniform[this.Yandere.PreviousSchoolwear], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up * (float)1, Quaternion.identity);
								this.Prompt.HideButton[this.Yandere.PreviousSchoolwear] = true;
								this.Bloody[this.Yandere.PreviousSchoolwear] = true;
							}
						}
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
				if (!this.YandereLocker)
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
			this.Yandere.Stripping = true;
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
		if (this.DropCleanUniform)
		{
			UnityEngine.Object.Instantiate(this.CleanUniform, this.Yandere.transform.position + Vector3.forward * -0.5f + Vector3.up * (float)1, Quaternion.identity);
			this.DropCleanUniform = false;
		}
		if (!this.Bloody[1])
		{
			this.Schoolwear[1].active = true;
		}
		if (!this.Bloody[2])
		{
			this.Schoolwear[2].active = true;
		}
		if (!this.Bloody[3])
		{
			this.Schoolwear[3].active = true;
		}
		this.Prompt.Label[1].text = "     " + "School Uniform";
		this.Prompt.Label[2].text = "     " + "School Swimsuit";
		this.Prompt.Label[3].text = "     " + "Gym Uniform";
		if (this.YandereLocker)
		{
			if (this.Yandere.Schoolwear > 0)
			{
				this.Prompt.Label[this.Yandere.Schoolwear].text = "     " + "Nude";
				if (this.Removed[this.Yandere.Schoolwear])
				{
					this.Schoolwear[this.Yandere.Schoolwear].active = false;
				}
			}
		}
		else if (this.Student != null && this.Student.Schoolwear > 0)
		{
			this.Prompt.HideButton[this.Student.Schoolwear] = true;
			this.Schoolwear[this.Student.Schoolwear].active = false;
			this.Student.Indoors = true;
			Debug.Log("Possibility 6.");
		}
	}

	public virtual void UpdateButtons()
	{
		if (!this.Yandere.ClubAttire || (this.Yandere.ClubAttire && this.Yandere.Bloodiness > (float)0))
		{
			if (this.Open)
			{
				if (this.Yandere.Bloodiness > (float)0)
				{
					this.Prompt.HideButton[1] = true;
					this.Prompt.HideButton[2] = true;
					this.Prompt.HideButton[3] = true;
					if (this.Yandere.Schoolwear > 0)
					{
						this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
					}
				}
				else
				{
					if (!this.Bloody[1])
					{
						this.Prompt.HideButton[1] = false;
					}
					if (!this.Bloody[2])
					{
						this.Prompt.HideButton[2] = false;
					}
					if (!this.Bloody[3])
					{
						this.Prompt.HideButton[3] = false;
					}
				}
			}
		}
		else
		{
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.HideButton[3] = true;
		}
	}

	public virtual void Main()
	{
	}
}
