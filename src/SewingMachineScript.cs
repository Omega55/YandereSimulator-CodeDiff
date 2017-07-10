using System;
using UnityEngine;

public class SewingMachineScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public GameObject Uniform;

	public Collider Chair;

	public bool MoveAway;

	public bool Sewing;

	public float Timer;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Task_7_Status") > 2)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("Task_7_Status") == 1)
		{
			if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Clothing && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Clean && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Type == 1 && this.Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>().Type == 1)
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
		if (this.Prompt.Circle[0].fillAmount <= 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_sewing_00");
			this.Yandere.MyController.radius = 0.1f;
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Yandere.CanMove = false;
			this.Chair.enabled = false;
			this.Sewing = true;
			base.GetComponent<AudioSource>().Play();
			this.Uniform = this.Yandere.PickUp.gameObject;
			this.Yandere.EmptyHands();
		}
		if (this.Sewing)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < 5f)
			{
				this.Uniform.transform.position = this.Yandere.RightHand.position;
				this.targetRotation = Quaternion.LookRotation(base.transform.parent.transform.parent.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.Yandere.MoveTowardsTarget(this.Chair.transform.position);
			}
			else if (!this.MoveAway)
			{
				this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
				this.Yandere.Inventory.ModifiedUniform = true;
				this.StudentManager.Students[7].TaskPhase = 5;
				PlayerPrefs.SetInt("Task_7_Status", 2);
				UnityEngine.Object.Destroy(this.Uniform);
				this.MoveAway = true;
			}
			else
			{
				this.Yandere.MoveTowardsTarget(this.Chair.gameObject.transform.position + new Vector3(-0.5f, 0f, 0f));
				if (this.Timer > 6f)
				{
					this.Yandere.MyController.radius = 0.2f;
					this.Yandere.CanMove = true;
					this.Chair.enabled = true;
					base.enabled = false;
					this.Sewing = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
		}
	}
}
