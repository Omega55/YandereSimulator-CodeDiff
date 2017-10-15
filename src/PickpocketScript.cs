using System;
using UnityEngine;

public class PickpocketScript : MonoBehaviour
{
	public PickpocketMinigameScript PickpocketMinigame;

	public StudentScript Student;

	public PromptScript Prompt;

	public UIPanel PickpocketPanel;

	public UISprite TimeBar;

	public Transform PickpocketSpot;

	public GameObject AlarmDisc;

	public GameObject Key;

	public float Timer;

	public int ID = 1;

	private void Start()
	{
		if (this.Student.StudentID != 93)
		{
			this.Prompt.transform.parent.gameObject.SetActive(false);
			base.enabled = false;
		}
		else
		{
			this.PickpocketMinigame = this.Student.StudentManager.PickpocketMinigame;
			this.ID = 2;
		}
	}

	private void Update()
	{
		if (this.Student.Routine && this.Student.DistanceToDestination > 0.5f)
		{
			if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.PickpocketPanel.enabled = false;
			}
		}
		else
		{
			this.PickpocketPanel.enabled = true;
			if (this.Student.Yandere.PickUp == null && this.Student.Yandere.Pursuer == null)
			{
				this.Prompt.enabled = true;
			}
			else
			{
				this.Prompt.enabled = false;
				this.Prompt.Hide();
			}
			this.Timer += Time.deltaTime;
			this.TimeBar.fillAmount = 1f - this.Timer / this.Student.CharacterAnimation[this.Student.PatrolAnim].length;
			if (this.Timer > this.Student.CharacterAnimation[this.Student.PatrolAnim].length)
			{
				if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
				{
					this.PickpocketMinigame.End();
					this.Punish();
				}
				this.Timer = 0f;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
			this.PickpocketMinigame.Show = true;
			this.PickpocketMinigame.ID = this.ID;
			this.Student.Yandere.CharacterAnimation.CrossFade("f02_pickpocketing_00");
			this.Student.Yandere.Pickpocketing = true;
			this.Student.Yandere.EmptyHands();
			this.Student.Yandere.CanMove = false;
		}
		if (this.PickpocketMinigame != null && this.PickpocketMinigame.ID == this.ID)
		{
			if (this.PickpocketMinigame.Success)
			{
				this.PickpocketMinigame.Success = false;
				this.PickpocketMinigame.ID = 0;
				if (this.ID == 1)
				{
					this.Student.StudentManager.ShedDoor.Prompt.Label[0].text = "     Open";
					this.Student.StudentManager.ShedDoor.Locked = false;
					this.Student.Yandere.Inventory.ShedKey = true;
				}
				else
				{
					this.Student.StudentManager.CabinetDoor.Prompt.Label[0].text = "     Open";
					this.Student.StudentManager.CabinetDoor.Locked = false;
					this.Student.Yandere.Inventory.CabinetKey = true;
				}
				this.Prompt.gameObject.SetActive(false);
				this.Key.SetActive(false);
			}
			if (this.PickpocketMinigame.Failure)
			{
				this.PickpocketMinigame.Failure = false;
				this.PickpocketMinigame.ID = 0;
				this.Punish();
			}
		}
	}

	private void Punish()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Student.Yandere.transform.position + Vector3.up, Quaternion.identity);
		gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
		this.Student.Witnessed = "Theft";
		this.Student.Concern = 5;
		this.Student.SenpaiNoticed();
		this.Student.CameraEffects.MurderWitnessed();
		this.Timer = 0f;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.PickpocketPanel.enabled = false;
	}
}
