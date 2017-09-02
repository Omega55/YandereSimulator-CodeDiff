using System;
using UnityEngine;

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

	public ClubType ClubID;

	public int Phase;

	private void Start()
	{
		this.CheckYandereClub();
	}

	private void Update()
	{
		if (!this.Occupied && this.Prompt.Circle[0].fillAmount == 0f)
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
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.OccupyTimer == 0f)
			{
				if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
				{
					component.clip = this.CurtainSound;
					component.Play();
				}
			}
			else if (this.OccupyTimer > 1f && this.Phase == 0)
			{
				if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
				{
					component.clip = this.ClothSound;
					component.Play();
				}
				this.Phase++;
			}
			this.OccupyTimer += Time.deltaTime;
			if (this.YandereChanging)
			{
				if (this.OccupyTimer < 2f)
				{
					this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					this.Yandere.MoveTowardsTarget(base.transform.position);
				}
				else if (this.OccupyTimer < 3f)
				{
					this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					if (this.Phase < 2)
					{
						component.clip = this.CurtainSound;
						component.Play();
						if (!this.Yandere.ClubAttire)
						{
							this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
						}
						this.Yandere.ChangeClubwear();
						this.Phase++;
					}
					this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, base.transform.rotation, 10f * Time.deltaTime);
					this.Yandere.MoveTowardsTarget(this.ExitSpot.position);
				}
				else
				{
					this.YandereChanging = false;
					this.Yandere.CanMove = true;
					this.Prompt.enabled = true;
					this.Occupied = false;
					this.OccupyTimer = 0f;
					this.Phase = 0;
				}
			}
			else if (this.OccupyTimer < 2f)
			{
				this.Weight = Mathf.Lerp(this.Weight, 0f, Time.deltaTime * 10f);
				this.Curtains.SetBlendShapeWeight(0, this.Weight);
			}
			else if (this.OccupyTimer < 3f)
			{
				this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
				this.Curtains.SetBlendShapeWeight(0, this.Weight);
				if (this.Phase < 2)
				{
					if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
					{
						component.clip = this.CurtainSound;
						component.Play();
					}
					this.Student.ChangeClubwear();
					this.Phase++;
				}
			}
			else
			{
				this.Occupied = false;
				this.OccupyTimer = 0f;
				this.Student = null;
				this.Phase = 0;
				this.CheckYandereClub();
			}
		}
	}

	public void CheckYandereClub()
	{
		if (this.Yandere.Bloodiness == 0f && !this.CannotChange && this.Yandere.Schoolwear > 0)
		{
			if (!this.Occupied)
			{
				if (Globals.Club != this.ClubID)
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
}
