using System;
using UnityEngine;

[Serializable]
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

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Task_7_Status") > 2)
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (PlayerPrefs.GetInt("Task_7_Status") == 1)
		{
			if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Clothing && !this.Yandere.PickUp.Evidence && ((FoldedUniformScript)this.Yandere.PickUp.gameObject.GetComponent(typeof(FoldedUniformScript))).Type == 1)
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
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Character.animation.CrossFade("f02_sewing_00");
			this.Yandere.MyController.radius = 0.1f;
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.Yandere.CanMove = false;
			this.Chair.enabled = false;
			this.Sewing = true;
			this.audio.Play();
			this.Uniform = this.Yandere.PickUp.gameObject;
			this.Yandere.EmptyHands();
		}
		if (this.Sewing)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < (float)5)
			{
				this.Uniform.transform.position = this.Yandere.RightHand.position;
				this.targetRotation = Quaternion.LookRotation(this.transform.parent.transform.parent.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
				this.Yandere.MoveTowardsTarget(this.Chair.transform.position);
			}
			else if (!this.MoveAway)
			{
				this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.Inventory.ModifiedUniform = true;
				this.StudentManager.Students[7].TaskPhase = 5;
				PlayerPrefs.SetInt("Task_7_Status", 2);
				UnityEngine.Object.Destroy(this.Uniform);
				this.MoveAway = true;
			}
			else
			{
				this.Yandere.MoveTowardsTarget(this.Chair.gameObject.transform.position + new Vector3(-0.5f, (float)0, (float)0));
				if (this.Timer > (float)6)
				{
					this.Yandere.MyController.radius = 0.2f;
					this.Yandere.CanMove = true;
					this.Chair.enabled = true;
					this.enabled = false;
					this.Sewing = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
