using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class YanvaniaDraculaScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $ApplyScreenshot$2779 : GenericGenerator<WWW>
	{
		internal YanvaniaDraculaScript $self_$2783;

		public $ApplyScreenshot$2779(YanvaniaDraculaScript self_)
		{
			this.$self_$2783 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new YanvaniaDraculaScript.$ApplyScreenshot$2779.$(this.$self_$2783);
		}
	}

	public YanvaniaCameraScript YanvaniaCamera;

	public YanvaniaYanmontScript Yanmont;

	public UITexture HealthBarParent;

	public UITexture Photograph;

	public AudioClip DeathScream;

	public AudioClip FinalLine;

	public GameObject NewTeleportEffect;

	public GameObject NewAttack;

	public GameObject DoubleFireball;

	public GameObject TripleFireball;

	public GameObject MainCamera;

	public GameObject EndCamera;

	public GameObject TeleportEffect;

	public GameObject Explosion;

	public GameObject Character;

	public Transform HealthBar;

	public Transform RightHand;

	public Renderer MyRenderer;

	public AudioClip[] Injuries;

	public float ExplosionTimer;

	public float TeleportTimer;

	public float FinalTimer;

	public float DeathTimer;

	public float FlashTimer;

	public float Distance;

	public float MaxHealth;

	public float Health;

	public bool FinalLineSpoken;

	public bool PhotoTaken;

	public bool Screamed;

	public bool Injured;

	public bool Shrink;

	public bool Grow;

	public bool Red;

	public int AttackID;

	public int Frames;

	public int Frame;

	public YanvaniaDraculaScript()
	{
		this.TeleportTimer = 10f;
		this.MaxHealth = 100f;
		this.Health = 100f;
	}

	public virtual void Update()
	{
		if (this.Yanmont.Health > (float)0)
		{
			if (this.Health > (float)0)
			{
				if (this.transform.position.z == (float)0)
				{
					if (this.Yanmont.transform.position.x > this.transform.position.x)
					{
						int num = -90;
						Vector3 localEulerAngles = this.transform.localEulerAngles;
						float num2 = localEulerAngles.y = (float)num;
						Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
					}
					else
					{
						int num3 = 90;
						Vector3 localEulerAngles2 = this.transform.localEulerAngles;
						float num4 = localEulerAngles2.y = (float)num3;
						Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
					}
				}
				if (this.NewTeleportEffect == null)
				{
					if (this.transform.position.y > (float)0)
					{
						this.Distance = Mathf.Abs(this.Yanmont.transform.position.x) - Mathf.Abs(this.transform.position.x);
						if (Mathf.Abs(this.Distance) < 0.61f && this.Yanmont.FlashTimer == (float)0)
						{
							this.Yanmont.TakeDamage(5);
						}
						if (this.AttackID == 0)
						{
							this.AttackID = UnityEngine.Random.Range(1, 3);
							this.TeleportTimer = (float)5;
							if (this.AttackID == 1)
							{
								this.Character.animation["succubus_a_charm_02"].time = (float)0;
								this.Character.animation.CrossFade("succubus_a_charm_02");
							}
							else
							{
								this.Character.animation["succubus_a_charm_03"].time = (float)0;
								this.Character.animation.CrossFade("succubus_a_charm_03");
							}
						}
						else
						{
							if (this.AttackID == 1)
							{
								if (this.Character.animation["succubus_a_charm_02"].time > (float)4 && this.NewAttack == null)
								{
									this.NewAttack = (GameObject)UnityEngine.Object.Instantiate(this.TripleFireball, this.RightHand.position, Quaternion.identity);
									((YanvaniaTripleFireballScript)this.NewAttack.GetComponent(typeof(YanvaniaTripleFireballScript))).Dracula = this.transform;
								}
								if (this.Character.animation["succubus_a_charm_02"].time >= this.Character.animation["succubus_a_charm_02"].length)
								{
									this.Character.animation.CrossFade("succubus_a_idle_01");
								}
							}
							else
							{
								if (this.Character.animation["succubus_a_charm_03"].time > (float)4 && this.NewAttack == null)
								{
									this.NewAttack = (GameObject)UnityEngine.Object.Instantiate(this.DoubleFireball, this.RightHand.position, Quaternion.identity);
									((YanvaniaDoubleFireballScript)this.NewAttack.GetComponent(typeof(YanvaniaDoubleFireballScript))).Dracula = this.transform;
								}
								if (this.Character.animation["succubus_a_charm_03"].time >= this.Character.animation["succubus_a_charm_03"].length)
								{
									this.Character.animation.CrossFade("succubus_a_idle_01");
								}
							}
							this.TeleportTimer -= Time.deltaTime;
						}
					}
					else
					{
						this.TeleportTimer -= Time.deltaTime;
					}
					if (this.TeleportTimer < (float)0)
					{
						if (this.transform.position.y < (float)0)
						{
							float x = UnityEngine.Random.Range(-38.5f, (float)-31);
							Vector3 position = this.transform.position;
							float num5 = position.x = x;
							Vector3 vector3 = this.transform.position = position;
						}
						this.SpawnTeleportEffect();
					}
				}
				else
				{
					if (this.Shrink)
					{
						this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3((float)0, (float)2, (float)0), Time.deltaTime * 0.5f);
						if (this.transform.localScale.x == (float)0)
						{
							this.NewTeleportEffect = null;
							this.Shrink = false;
							this.Teleport();
						}
					}
					if (this.Grow)
					{
						this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), Time.deltaTime * 1.5f);
						if (this.transform.localScale.x > 1.49f)
						{
							this.NewTeleportEffect = null;
							this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
							this.Grow = false;
						}
					}
				}
				if (this.FlashTimer > (float)0)
				{
					this.FlashTimer -= Time.deltaTime;
					int i = 0;
					if (!this.Red)
					{
						while (i < Extensions.get_length(this.MyRenderer.materials))
						{
							this.MyRenderer.materials[i].color = new Color((float)1, (float)0, (float)0, (float)1);
							i++;
						}
						this.Frames++;
						if (this.Frames == 5)
						{
							this.Frames = 0;
							this.Red = true;
						}
					}
					else
					{
						while (i < Extensions.get_length(this.MyRenderer.materials))
						{
							this.MyRenderer.materials[i].color = new Color((float)1, (float)1, (float)1, (float)1);
							i++;
						}
						this.Frames++;
						if (this.Frames == 5)
						{
							this.Frames = 0;
							this.Red = false;
						}
					}
				}
				else if (this.MyRenderer.materials[0].color != new Color((float)1, (float)1, (float)1, (float)1))
				{
					for (int i = 0; i < Extensions.get_length(this.MyRenderer.materials); i++)
					{
						this.MyRenderer.materials[i].color = new Color((float)1, (float)1, (float)1, (float)1);
					}
				}
			}
			else
			{
				float y = this.HealthBarParent.transform.localPosition.y - Time.deltaTime * 0.2f;
				Vector3 localPosition = this.HealthBarParent.transform.localPosition;
				float num6 = localPosition.y = y;
				Vector3 vector4 = this.HealthBarParent.transform.localPosition = localPosition;
				float y2 = this.HealthBarParent.transform.localScale.y + Time.deltaTime * 0.2f;
				Vector3 localScale = this.HealthBarParent.transform.localScale;
				float num7 = localScale.y = y2;
				Vector3 vector5 = this.HealthBarParent.transform.localScale = localScale;
				float a = this.HealthBarParent.color.a - Time.deltaTime * 0.2f;
				Color color = this.HealthBarParent.color;
				float num8 = color.a = a;
				Color color2 = this.HealthBarParent.color = color;
				this.Character.animation.Play("succubus_a_damage_l");
				this.ExplosionTimer += Time.deltaTime;
				this.DeathTimer += Time.deltaTime;
				if (this.DeathTimer < (float)5)
				{
					if (this.DeathTimer > (float)1 && !this.FinalLineSpoken)
					{
						this.FinalLineSpoken = true;
						this.audio.clip = this.FinalLine;
						this.audio.Play();
					}
					if (this.ExplosionTimer > 0.1f)
					{
						UnityEngine.Object.Instantiate(this.Explosion, this.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range((float)0, 2.5f), UnityEngine.Random.Range(-1f, 1f)), Quaternion.identity);
						this.ExplosionTimer = (float)0;
					}
				}
				else
				{
					if (!this.Screamed)
					{
						this.Screamed = true;
						this.audio.clip = this.DeathScream;
						this.audio.Play();
					}
					if (this.DeathTimer > (float)5)
					{
						if (!this.PhotoTaken)
						{
							Time.timeScale = Mathf.MoveTowards(Time.timeScale, (float)0, 0.0166666f);
							if (Time.timeScale == (float)0)
							{
								Application.CaptureScreenshot(Application.streamingAssetsPath + "/Dracula" + ".png");
								if (this.Frame > 0)
								{
									this.StartCoroutine_Auto(this.ApplyScreenshot());
								}
								this.Frame++;
							}
						}
						else if (this.Photograph.mainTexture != null)
						{
							float x2 = this.Photograph.transform.localEulerAngles.x + Time.deltaTime * 3.6f;
							Vector3 localEulerAngles3 = this.Photograph.transform.localEulerAngles;
							float num9 = localEulerAngles3.x = x2;
							Vector3 vector6 = this.Photograph.transform.localEulerAngles = localEulerAngles3;
							float z = this.Photograph.transform.localEulerAngles.z - Time.deltaTime * 3.6f;
							Vector3 localEulerAngles4 = this.Photograph.transform.localEulerAngles;
							float num10 = localEulerAngles4.z = z;
							Vector3 vector7 = this.Photograph.transform.localEulerAngles = localEulerAngles4;
							this.Photograph.transform.localScale = Vector3.MoveTowards(this.Photograph.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * 0.2f);
							float g = this.Photograph.color.g - Time.deltaTime * 0.2f;
							Color color3 = this.Photograph.color;
							float num11 = color3.g = g;
							Color color4 = this.Photograph.color = color3;
							float b = this.Photograph.color.b - Time.deltaTime * 0.2f;
							Color color5 = this.Photograph.color;
							float num12 = color5.b = b;
							Color color6 = this.Photograph.color = color5;
							if (this.Photograph.transform.localScale == new Vector3((float)0, (float)0, (float)0))
							{
								this.FinalTimer += Time.deltaTime;
								if (this.FinalTimer > (float)1)
								{
									PlayerPrefs.SetInt("DraculaDefeated", 1);
									Application.LoadLevel("YanvaniaTitleScene");
								}
							}
						}
					}
				}
			}
		}
		else
		{
			this.Character.animation.CrossFade("succubus_a_talk_01");
		}
		float x3 = Mathf.Lerp(this.HealthBar.parent.transform.localPosition.x, (float)1025, Time.deltaTime * (float)10);
		Vector3 localPosition2 = this.HealthBar.parent.transform.localPosition;
		float num13 = localPosition2.x = x3;
		Vector3 vector8 = this.HealthBar.parent.transform.localPosition = localPosition2;
		float y3 = Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * (float)10);
		Vector3 localScale2 = this.HealthBar.localScale;
		float num14 = localScale2.y = y3;
		Vector3 vector9 = this.HealthBar.localScale = localScale2;
		if (Input.GetKeyDown("4"))
		{
			float y4 = 6.5f;
			Vector3 position2 = this.transform.position;
			float num15 = position2.y = y4;
			Vector3 vector10 = this.transform.position = position2;
			int num16 = 0;
			Vector3 position3 = this.transform.position;
			float num17 = position3.z = (float)num16;
			Vector3 vector11 = this.transform.position = position3;
			this.Health = (float)1;
			this.TakeDamage();
		}
	}

	public virtual void SpawnTeleportEffect()
	{
		if (this.transform.position.y > (float)0)
		{
			this.NewTeleportEffect = (GameObject)UnityEngine.Object.Instantiate(this.TeleportEffect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			this.Character.animation["DraculaTeleport"].time = this.Character.animation["DraculaTeleport"].length;
			this.Character.animation["DraculaTeleport"].speed = (float)-1;
			this.Character.animation.Play("DraculaTeleport");
			this.Shrink = true;
		}
		else
		{
			this.Teleport();
			this.NewTeleportEffect = (GameObject)UnityEngine.Object.Instantiate(this.TeleportEffect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			this.Character.animation["DraculaTeleport"].speed = 0.85f;
			this.Character.animation["DraculaTeleport"].time = (float)0;
			this.Character.animation.Play("DraculaTeleport");
			this.Grow = true;
		}
		((YanvaniaTeleportEffectScript)this.NewTeleportEffect.GetComponent(typeof(YanvaniaTeleportEffectScript))).Dracula = this;
		this.TeleportTimer = 1f;
		this.AttackID = 0;
	}

	public virtual void Teleport()
	{
		if (this.transform.position.y > (float)0)
		{
			int num = -10;
			Vector3 position = this.transform.position;
			float num2 = position.y = (float)num;
			Vector3 vector = this.transform.position = position;
		}
		else
		{
			float y = 6.5f;
			Vector3 position2 = this.transform.position;
			float num3 = position2.y = y;
			Vector3 vector2 = this.transform.position = position2;
		}
		int num4 = 0;
		Vector3 position3 = this.transform.position;
		float num5 = position3.z = (float)num4;
		Vector3 vector3 = this.transform.position = position3;
	}

	public virtual void TakeDamage()
	{
		this.Health -= (float)(5 + (this.Yanmont.Level * 5 - 5));
		if (this.Health <= (float)0)
		{
			this.YanvaniaCamera.StopMusic = true;
			this.Health = (float)0;
		}
		else
		{
			this.FlashTimer = (float)1;
			this.Injured = true;
			this.audio.clip = this.Injuries[UnityEngine.Random.Range(0, Extensions.get_length(this.Injuries))];
			this.audio.Play();
		}
	}

	public virtual IEnumerator ApplyScreenshot()
	{
		return new YanvaniaDraculaScript.$ApplyScreenshot$2779(this).GetEnumerator();
	}

	public virtual void Main()
	{
		this.Character.animation["succubus_a_damage_l"].speed = 0.1f;
		this.Character.animation["succubus_a_charm_02"].speed = 2.4f;
		this.Character.animation["succubus_a_charm_03"].speed = 4.66666f;
	}
}
