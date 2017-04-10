using System;
using UnityEngine;

[Serializable]
public class ChangingBoothScript : MonoBehaviour
{
	public YandereScript Yandere;

	public StudentScript Student;

	public PromptScript Prompt;

	public SkinnedMeshRenderer Curtains;

	public Transform ExitSpot;

	public Transform[] WaitSpots;

	public bool YandereChanging;

	public bool CannotChange;

	public bool Occupied;

	public AudioClip CurtainSound;

	public AudioClip ClothSound;

	public float OccupyTimer;

	public float Weight;

	public int ClubID;

	public int Phase;

	public virtual void Start()
	{
		this.CheckYandereClub();
	}

	public virtual void Update()
	{
		if (!this.Occupied && this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
			this.YandereChanging = true;
			this.Occupied = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Occupied)
		{
			if (this.OccupyTimer == (float)0)
			{
				if (this.Yandere.transform.position.y > this.transform.position.y - (float)1 && this.Yandere.transform.position.y < this.transform.position.y + (float)1)
				{
					this.audio.clip = this.CurtainSound;
					this.audio.Play();
				}
			}
			else if (this.OccupyTimer > (float)1 && this.Phase == 0)
			{
				if (this.Yandere.transform.position.y > this.transform.position.y - (float)1 && this.Yandere.transform.position.y < this.transform.position.y + (float)1)
				{
					this.audio.clip = this.ClothSound;
					this.audio.Play();
				}
				this.Phase++;
			}
			this.OccupyTimer += Time.deltaTime;
			if (this.YandereChanging)
			{
				if (this.OccupyTimer < (float)2)
				{
					this.Weight = Mathf.Lerp(this.Weight, (float)0, Time.deltaTime * (float)10);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					this.Yandere.MoveTowardsTarget(this.transform.position);
				}
				else if (this.OccupyTimer < (float)3)
				{
					this.Weight = Mathf.Lerp(this.Weight, (float)100, Time.deltaTime * (float)10);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					if (this.Phase < 2)
					{
						this.audio.clip = this.CurtainSound;
						this.audio.Play();
						if (!this.Yandere.ClubAttire)
						{
							this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
						}
						this.Yandere.ChangeClubwear();
						this.Phase++;
					}
					this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.transform.rotation, (float)10 * Time.deltaTime);
					this.Yandere.MoveTowardsTarget(this.ExitSpot.position);
				}
				else
				{
					this.YandereChanging = false;
					this.Yandere.CanMove = true;
					this.Prompt.enabled = true;
					this.Occupied = false;
					this.OccupyTimer = (float)0;
					this.Phase = 0;
				}
			}
			else if (this.OccupyTimer < (float)2)
			{
				this.Weight = Mathf.Lerp(this.Weight, (float)0, Time.deltaTime * (float)10);
				this.Curtains.SetBlendShapeWeight(0, this.Weight);
			}
			else if (this.OccupyTimer < (float)3)
			{
				this.Weight = Mathf.Lerp(this.Weight, (float)100, Time.deltaTime * (float)10);
				this.Curtains.SetBlendShapeWeight(0, this.Weight);
				if (this.Phase < 2)
				{
					if (this.Yandere.transform.position.y > this.transform.position.y - (float)1 && this.Yandere.transform.position.y < this.transform.position.y + (float)1)
					{
						this.audio.clip = this.CurtainSound;
						this.audio.Play();
					}
					this.Student.ChangeClubwear();
					this.Phase++;
				}
			}
			else
			{
				this.Occupied = false;
				this.OccupyTimer = (float)0;
				this.Student = null;
				this.Phase = 0;
				this.CheckYandereClub();
			}
		}
	}

	public virtual void CheckYandereClub()
	{
		if (this.Yandere.Bloodiness == (float)0 && !this.CannotChange && this.Yandere.Schoolwear > 0)
		{
			if (!this.Occupied)
			{
				if (PlayerPrefs.GetInt("Club") != this.ClubID)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				else
				{
					this.Prompt.enabled = true;
				}
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
