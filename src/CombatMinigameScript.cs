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

	public Vector3 CameraTarget;

	public Vector3 CameraStart;

	public UITexture RedVignette;

	public UISprite Prompt;

	public UILabel Label;

	public bool KnockedOut;

	public float SlowdownFactor;

	public float ShakeFactor;

	public float Shake;

	public int Strike;

	public int Phase;

	public int Path;

	public AudioSource MyVocals;

	public AudioSource MyAudio;

	public AudioClip[] CombatSFX;

	public AudioClip[] Vocals;

	private void StartCombat()
	{
		this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatA");
		this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
		this.RedVignette.color = new Color(1f, 1f, 1f, 0f);
		this.CameraStart = this.MainCamera.localPosition;
		this.Label.text = "State: A";
		this.Prompt.enabled = false;
		this.Yandere.Health = 10;
		this.Phase = 1;
		this.Path = 1;
		this.MyAudio.clip = this.CombatSFX[this.Phase];
		this.MyAudio.Play();
		this.MyVocals.clip = this.Vocals[this.Phase];
		this.MyVocals.Play();
	}

	private void Update()
	{
		this.MainCamera.position += new Vector3(this.Shake * UnityEngine.Random.Range(-1f, 1f), this.Shake * UnityEngine.Random.Range(-1f, 1f), this.Shake * UnityEngine.Random.Range(-1f, 1f));
		this.Shake = Mathf.Lerp(this.Shake, 0f, Time.deltaTime * 10f);
		if (!this.KnockedOut)
		{
			this.Midpoint.position = (this.Delinquent.Hips.position - this.Yandere.Hips.position) * 0.5f + this.Yandere.Hips.position;
			this.Midpoint.position += new Vector3(0f, 0.25f, 0f);
		}
		else
		{
			this.Midpoint.position = Vector3.Lerp(this.Midpoint.position, this.Yandere.Hips.position, Time.deltaTime);
		}
		this.MainCamera.LookAt(this.Midpoint.position);
		if (Input.GetKeyDown("z"))
		{
			this.Yandere.Health = 0;
		}
		if (Input.GetKeyDown("space"))
		{
			this.StartCombat();
		}
		if (this.Path == 1)
		{
			this.MainCamera.localPosition = Vector3.Lerp(this.MainCamera.localPosition, this.CameraStart, Time.deltaTime);
			if (this.Phase == 1)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1f)
				{
					this.Prompt.enabled = true;
					this.Slowdown();
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.33333f)
				{
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.Phase++;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.Delinquent.CharacterAnimation["Delinquent_CombatB"].time = this.Delinquent.CharacterAnimation["Delinquent_CombatA"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatB"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.Delinquent.CharacterAnimation.Play("Delinquent_CombatB");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatB");
					this.Label.text = "State: B";
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.MyAudio.pitch = 1f;
					this.Strike = 0;
					this.Path = 2;
					this.Phase++;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time + 0.5f;
					this.MyVocals.Play();
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Strike < 1)
				{
					if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 1.66666f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.LeftArmRoll.position, Quaternion.identity);
						this.Shake += this.ShakeFactor;
						this.Strike++;
						this.Yandere.Health--;
						Debug.Log(this.Yandere.Health);
						this.RedVignette.color = new Color(1f, 1f, 1f, 1f - (float)this.Yandere.Health * 1f / 10f);
					}
				}
				else if (this.Strike < 2 && this.Yandere.CharacterAnimation["Yandere_CombatA"].time > 2.5f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightArmRoll.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
					this.Yandere.Health--;
					Debug.Log(this.Yandere.Health);
					this.RedVignette.color = new Color(1f, 1f, 1f, 1f - (float)this.Yandere.Health * 1f / 10f);
					if (this.Yandere.Health < 1)
					{
						this.Delinquent.CharacterAnimation["Delinquent_CombatE"].time = this.Delinquent.CharacterAnimation["Delinquent_CombatA"].time;
						this.Yandere.CharacterAnimation["Yandere_CombatE"].time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
						this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatE");
						this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatE");
						this.CameraTarget = this.MainCamera.position + new Vector3(0f, 1f, 0f);
						this.MainCamera.parent = null;
						this.Shake += this.ShakeFactor;
						this.KnockedOut = true;
						this.Label.text = "State: E";
						this.Prompt.enabled = false;
						Time.timeScale = 1f;
						this.MyVocals.pitch = 1f;
						this.MyAudio.pitch = 1f;
						this.Path = 5;
						this.Phase++;
						this.MyAudio.clip = this.CombatSFX[this.Path];
						this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatE"].time;
						this.MyAudio.Play();
						this.MyVocals.clip = this.Vocals[this.Path];
						this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatE"].time;
						this.MyVocals.Play();
					}
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatA"].time > this.Yandere.CharacterAnimation["Yandere_CombatA"].length)
				{
					this.Delinquent.CharacterAnimation["Delinquent_CombatA"].time = 0f;
					this.Yandere.CharacterAnimation["Yandere_CombatA"].time = 0f;
					this.Label.text = "State: A";
					this.Strike = 0;
					this.Phase = 1;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyVocals.Play();
				}
			}
		}
		else if (this.Path == 2)
		{
			if (this.Phase == 3)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 1.833333f)
				{
					this.Prompt.enabled = true;
					this.Slowdown();
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.166666f)
				{
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.Phase++;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.Delinquent.CharacterAnimation["Delinquent_CombatC"].time = this.Delinquent.CharacterAnimation["Delinquent_CombatB"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatC"].time = this.Yandere.CharacterAnimation["Yandere_CombatB"].time;
					this.Delinquent.CharacterAnimation.Play("Delinquent_CombatC");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatC");
					this.Label.text = "State: C";
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.Strike = 0;
					this.Path = 3;
					this.Phase++;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
					this.MyVocals.Play();
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Strike < 1 && this.Yandere.CharacterAnimation["Yandere_CombatB"].time > 2.66666f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Delinquent.LeftHand.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatB"].time > this.Yandere.CharacterAnimation["Yandere_CombatB"].length)
				{
					this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatA");
					this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
					this.Label.text = "State: A";
					this.Strike = 0;
					this.Phase = 1;
					this.Path = 1;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyVocals.Play();
				}
			}
		}
		else if (this.Path == 3)
		{
			if (this.Phase == 5)
			{
				if (this.Strike < 1 && this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 2.5f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightHand.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.155555f)
				{
					this.Prompt.enabled = true;
					this.Slowdown();
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				if (this.Yandere.CharacterAnimation["Yandere_CombatC"].time > 3.5f)
				{
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.Phase++;
				}
				else if (Input.GetButtonDown("A"))
				{
					this.Delinquent.CharacterAnimation["Delinquent_CombatD"].time = this.Delinquent.CharacterAnimation["Delinquent_CombatC"].time;
					this.Yandere.CharacterAnimation["Yandere_CombatD"].time = this.Yandere.CharacterAnimation["Yandere_CombatC"].time;
					this.Delinquent.CharacterAnimation.Play("Delinquent_CombatD");
					this.Yandere.CharacterAnimation.Play("Yandere_CombatD");
					this.Label.text = "State: D";
					this.Prompt.enabled = false;
					Time.timeScale = 1f;
					this.MyVocals.pitch = 1f;
					this.MyAudio.pitch = 1f;
					this.Strike = 0;
					this.Path = 4;
					this.Phase++;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatD"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatD"].time;
					this.MyVocals.Play();
				}
			}
			else if (this.Phase == 7 && this.Yandere.CharacterAnimation["Yandere_CombatC"].time > this.Yandere.CharacterAnimation["Yandere_CombatC"].length)
			{
				this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatA");
				this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
				this.Label.text = "State: A";
				this.Strike = 0;
				this.Phase = 1;
				this.Path = 1;
				this.MyAudio.clip = this.CombatSFX[this.Path];
				this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
				this.MyAudio.Play();
				this.MyVocals.clip = this.Vocals[this.Path];
				this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
				this.MyVocals.Play();
			}
		}
		else if (this.Path == 4)
		{
			if (this.Phase == 7)
			{
				if (this.Strike < 1 && this.Yandere.CharacterAnimation["Yandere_CombatD"].time > 4f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, this.Yandere.RightKnee.position, Quaternion.identity);
					this.Shake += this.ShakeFactor;
					this.Strike++;
				}
				if (this.Yandere.CharacterAnimation["Yandere_CombatD"].time > this.Yandere.CharacterAnimation["Yandere_CombatD"].length)
				{
					Debug.Log("Player won.");
					this.Delinquent.CharacterAnimation.CrossFade("Delinquent_CombatA");
					this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatA");
					this.Label.text = "State: A";
					this.Strike = 0;
					this.Phase = 1;
					this.Path = 1;
					this.MyAudio.clip = this.CombatSFX[this.Path];
					this.MyAudio.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyAudio.Play();
					this.MyVocals.clip = this.Vocals[this.Path];
					this.MyVocals.time = this.Yandere.CharacterAnimation["Yandere_CombatA"].time;
					this.MyVocals.Play();
				}
			}
		}
		else if (this.Path == 5 && this.Phase == 4)
		{
			this.MainCamera.position = Vector3.Lerp(this.MainCamera.position, this.CameraTarget, Time.deltaTime);
			if (this.Yandere.CharacterAnimation["Yandere_CombatE"].time > this.Yandere.CharacterAnimation["Yandere_CombatE"].length)
			{
				Debug.Log("Player lost.");
			}
		}
	}

	private void Slowdown()
	{
		Time.timeScale = this.SlowdownFactor;
		this.MyVocals.pitch = this.SlowdownFactor;
		this.MyAudio.pitch = this.SlowdownFactor;
	}
}
