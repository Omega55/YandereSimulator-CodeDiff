using System;
using UnityEngine;

public class CombatMinigameScript : MonoBehaviour
{
	public GameObject HitEffect;

	public StudentScript Delinquent;

	public YandereScript Yandere;

	public Transform CombatTarget;

	public Transform MainCamera;

	public Transform Midpoint;

	public UISprite Prompt;

	public int Phase;

	public int Path;

	private void StartCombat()
	{
		this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatA");
		this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
		this.Prompt.enabled = false;
		this.Phase = 1;
	}

	private void Update()
	{
		this.Midpoint.position = (this.Delinquent.Hips.position - this.Yandere.Hips.position) * 0.5f + this.Yandere.Hips.position;
		this.Midpoint.position += new Vector3(0f, 0.25f, 0f);
		this.MainCamera.LookAt(this.Midpoint.position);
		if (Input.GetKeyDown("space"))
		{
			this.StartCombat();
		}
		if (this.Path == 1)
		{
			if (this.Phase == 1)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.2f)
				{
					this.Prompt.enabled = true;
					Time.timeScale = 0.25f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.7f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.LeftArmRoll.position, Quaternion.identity);
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.Phase++;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.Delinquent.CharacterAnimation["Delinquent_CombatB"].time = this.Delinquent.CharacterAnimation["Delinquent_CombatA"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatB"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.Delinquent.CharacterAnimation.Play("Delinquent_CombatB");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatB");
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.Path = 2;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 2f)
				{
					this.Prompt.enabled = true;
					Time.timeScale = 0.25f;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 2.5f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightArmRoll.position, Quaternion.identity);
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.Phase++;
				}
			}
			else if (this.Phase == 5 && this.Yandere.CharacterAnimation["Yandere_CombatA"].time > this.Yandere.CharacterAnimation["Yandere_CombatA"].length)
			{
				this.Delinquent.CharacterAnimation["Delinquent_CombatA"].time = 0f;
				this.Yandere.CharacterAnimation["Yandere_CombatA"].time = 0f;
				this.Phase = 1;
			}
		}
		else if (this.Path == 2)
		{
			if (this.Phase == 3)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2f)
				{
					this.Prompt.enabled = true;
					Time.timeScale = 0.25f;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if ((double)this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.25)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightHand.position, Quaternion.identity);
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.5f)
				{
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 3f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightKnee.position, Quaternion.identity);
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				if ((double)this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 3.5)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightFoot.position, Quaternion.identity);
					this.Phase++;
				}
			}
			else if (this.Phase == 8 && this.Yandere.CharacterAnimation["Yandere_CombatB"].time > this.Yandere.CharacterAnimation["Yandere_CombatB"].length)
			{
				this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatA");
				this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
				this.Phase = 1;
				this.Path = 1;
			}
		}
	}
}
