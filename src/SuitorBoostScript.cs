using System;
using UnityEngine;

[Serializable]
public class SuitorBoostScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UISprite Darkness;

	public Transform YandereSitSpot;

	public Transform SuitorSitSpot;

	public Transform YandereChair;

	public Transform SuitorChair;

	public Transform YandereSpot;

	public Transform SuitorSpot;

	public Transform LookTarget;

	public Transform TextBox;

	public bool Boosting;

	public bool FadeOut;

	public float Timer;

	public int Phase;

	public SuitorBoostScript()
	{
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (this.Yandere.Followers > 0)
		{
			if (this.Yandere.Follower.StudentID == 13)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.Follower.Pathfinding.enabled = false;
			this.Yandere.Follower.enabled = false;
			this.Yandere.RPGCamera.enabled = false;
			this.Darkness.enabled = true;
			this.Yandere.CanMove = false;
			this.Boosting = true;
			this.FadeOut = true;
		}
		if (this.Boosting)
		{
			if (this.FadeOut)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a == (float)1)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > (float)1)
					{
						if (this.Phase == 1)
						{
							Camera.main.transform.position = new Vector3((float)-26, 5.3f, 17.5f);
							Camera.main.transform.eulerAngles = new Vector3((float)15, (float)180, (float)0);
							this.Yandere.Follower.Character.transform.localScale = new Vector3((float)1, (float)1, (float)1);
							float z = -0.6f;
							Vector3 localPosition = this.YandereChair.transform.localPosition;
							float num2 = localPosition.z = z;
							Vector3 vector = this.YandereChair.transform.localPosition = localPosition;
							float z2 = -0.6f;
							Vector3 localPosition2 = this.SuitorChair.transform.localPosition;
							float num3 = localPosition2.z = z2;
							Vector3 vector2 = this.SuitorChair.transform.localPosition = localPosition2;
							this.Yandere.Character.animation.Play("f02_sit_01");
							this.Yandere.Follower.Character.animation.Play("sit_01");
							this.Yandere.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
							this.Yandere.Follower.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
							this.Yandere.transform.position = this.YandereSitSpot.position;
							this.Yandere.Follower.transform.position = this.SuitorSitSpot.position;
						}
						else
						{
							this.Yandere.FixCamera();
							this.Yandere.Follower.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
							float z3 = -0.33333f;
							Vector3 localPosition3 = this.YandereChair.transform.localPosition;
							float num4 = localPosition3.z = z3;
							Vector3 vector3 = this.YandereChair.transform.localPosition = localPosition3;
							float z4 = -0.33333f;
							Vector3 localPosition4 = this.SuitorChair.transform.localPosition;
							float num5 = localPosition4.z = z4;
							Vector3 vector4 = this.SuitorChair.transform.localPosition = localPosition4;
							this.Yandere.Character.animation.Play(this.Yandere.IdleAnim);
							this.Yandere.Follower.Character.animation.Play(this.Yandere.Follower.IdleAnim);
							this.Yandere.transform.position = this.YandereSpot.position;
							this.Yandere.Follower.transform.position = this.SuitorSpot.position;
						}
						this.PromptBar.ClearButtons();
						this.FadeOut = false;
						this.Phase++;
					}
				}
			}
			else
			{
				float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color3 = this.Darkness.color;
				float num6 = color3.a = a2;
				Color color4 = this.Darkness.color = color3;
				if (this.Darkness.color.a == (float)0)
				{
					if (this.Phase == 2)
					{
						this.TextBox.active = true;
						this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
						if (this.TextBox.localScale.x > 0.9f)
						{
							if (!this.PromptBar.Show)
							{
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Continue";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
							}
							if (Input.GetButtonDown("A"))
							{
								this.PromptBar.Show = false;
								this.Phase++;
							}
						}
					}
					else if (this.Phase == 3)
					{
						if (this.TextBox.localScale.x > 0.1f)
						{
							this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
						}
						else
						{
							this.TextBox.active = false;
							this.FadeOut = true;
							this.Phase++;
						}
					}
					else if (this.Phase == 5)
					{
						PlayerPrefs.SetInt("SuitorTrait2", PlayerPrefs.GetInt("SuitorTrait2") + 1);
						this.Yandere.RPGCamera.enabled = true;
						this.Darkness.enabled = false;
						this.Yandere.CanMove = true;
						this.Boosting = false;
						this.Yandere.Follower.Pathfinding.enabled = true;
						this.Yandere.Follower.enabled = true;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.enabled = false;
					}
				}
			}
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Boosting && this.Phase > 1 && this.Phase < 5)
		{
			this.Yandere.Head.LookAt(this.LookTarget);
			this.Yandere.Follower.Head.LookAt(this.LookTarget);
		}
	}

	public virtual void Main()
	{
	}
}
