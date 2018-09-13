using System;
using UnityEngine;

public class MGPMEnemyScript : MonoBehaviour
{
	public MGPMManagerScript GameplayManager;

	public MGPMMiyukiScript Miyuki;

	public AudioSource MyAudio;

	public GameObject FinalBossExplosion;

	public GameObject Projectile;

	public GameObject Explosion;

	public GameObject Impact;

	public Renderer ExtraRenderer;

	public Renderer MyRenderer;

	public Collider MyCollider;

	public Transform HealthBar;

	public Texture[] Sprite;

	public int Pattern;

	public int Health;

	public int Frame;

	public int Phase;

	public int Side;

	public float AttackFrequency;

	public float ExplosionTimer;

	public float AttackTimer;

	public float DeathTimer;

	public float PhaseTimer;

	public float FlashWhite;

	public float Rotation;

	public float Speed;

	public float Timer;

	public float Spin;

	public float FPS;

	public float PositionX;

	public float PositionY;

	public bool ShootEverywhere;

	public bool QuintupleAttack;

	public bool SextupleAttack;

	public bool DoubleAttack;

	public bool TripleAttack;

	public bool Homing;

	private void Start()
	{
		if (this.Pattern != 10 && GameGlobals.HardMode)
		{
			this.Health += 6;
		}
		if (base.transform.localPosition.x < 0f)
		{
			this.Side = 1;
		}
		else
		{
			this.Side = -1;
		}
		if (this.Pattern == 11)
		{
			this.MyCollider.enabled = false;
		}
		if (this.GameplayManager.GameOver)
		{
			this.MyAudio.volume = 0f;
			this.AttackFrequency = 0f;
		}
	}

	private void Update()
	{
		if (this.Health > 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.FPS)
			{
				this.Timer = 0f;
				this.Frame++;
				if (this.Frame == this.Sprite.Length)
				{
					this.Frame = 0;
				}
				this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
				if (this.ExtraRenderer != null)
				{
					this.ExtraRenderer.material.mainTexture = this.Sprite[this.Frame];
				}
			}
			switch (this.Pattern)
			{
			case 0:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.Speed * Time.deltaTime, 0f);
				this.Speed = Mathf.Lerp(this.Speed, 0f, Time.deltaTime);
				break;
			case 1:
				if (this.Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, this.Miyuki.transform.localPosition, this.Speed * Time.deltaTime);
					this.Speed = Mathf.Lerp(this.Speed, 0f, Time.deltaTime);
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 2f)
					{
						this.AttackTimer = -100f;
						this.Phase++;
					}
				}
				else
				{
					this.Rotation = Mathf.Lerp(this.Rotation, (float)(90 * this.Side), this.Speed * Time.deltaTime);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
					base.transform.Translate(base.transform.up * -1f * this.Speed * Time.deltaTime);
					this.Speed += Time.deltaTime;
					if (base.transform.localPosition.y > 288f)
					{
						UnityEngine.Object.Destroy(base.gameObject);
					}
				}
				break;
			case 2:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + this.Speed * Time.deltaTime, base.transform.localPosition.y - 100f * Time.deltaTime, base.transform.localPosition.z);
				if (this.Phase == 1)
				{
					this.Speed -= Time.deltaTime * 200f;
					if (this.Speed < -200f)
					{
						this.Phase++;
					}
				}
				else
				{
					this.Speed += Time.deltaTime * 200f;
					if (this.Speed > 200f)
					{
						this.Phase--;
					}
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 3:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.Speed * Time.deltaTime, 0f);
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 4:
				base.transform.LookAt(this.Miyuki.transform.position);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.Speed * Time.deltaTime, 0f);
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 5:
				if (this.Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 1f)
					{
						this.Speed = 1f;
						this.Phase++;
					}
				}
				else
				{
					this.Speed += this.Speed * Time.deltaTime * 2.5f;
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.Speed * -1f, base.transform.localPosition.z);
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 6:
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 135f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
				break;
			case 7:
				base.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x - this.Speed * Time.deltaTime, base.transform.localPosition.y - this.Speed * 0.25f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x < -160f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 8:
				base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + this.Speed * Time.deltaTime, base.transform.localPosition.y - this.Speed * 0.25f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x > 160f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 9:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + this.Speed * Time.deltaTime, base.transform.localPosition.y - 20f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x > 60f)
				{
					base.transform.localPosition = new Vector3(60f, base.transform.localPosition.y, base.transform.localPosition.z);
				}
				else if (base.transform.localPosition.x < -60f)
				{
					base.transform.localPosition = new Vector3(-60f, base.transform.localPosition.y, base.transform.localPosition.z);
				}
				if (this.Phase == 1)
				{
					this.Speed -= Time.deltaTime * 120f;
					if (this.Speed < -120f)
					{
						this.Phase++;
					}
				}
				else
				{
					this.Speed += Time.deltaTime * 120f;
					if (this.Speed > 120f)
					{
						this.Phase--;
					}
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 10:
				if (this.Phase == 1)
				{
					base.transform.LookAt(this.Miyuki.transform);
					this.Phase++;
				}
				else
				{
					base.transform.Translate(Vector3.forward * this.Speed * Time.deltaTime, Space.Self);
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 11:
				if (this.Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 150f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 5f)
					{
						this.MyCollider.enabled = true;
						this.AttackFrequency = 0.5f;
						this.PhaseTimer = 0f;
						this.Speed = 0f;
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 10f)
					{
						this.QuintupleAttack = false;
						this.SextupleAttack = false;
						this.ShootEverywhere = true;
						this.AttackFrequency = 0.1f;
						this.PhaseTimer = 0f;
						this.Speed = 0.1f;
						this.Spin = 45f;
						this.Phase++;
					}
				}
				else if (this.Phase == 3)
				{
					this.PhaseTimer += Time.deltaTime;
					this.Speed += this.Speed * Time.deltaTime;
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, -214f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					if (this.PhaseTimer > 5f)
					{
						this.PhaseTimer = 0f;
						this.Speed = 0.1f;
						this.Phase++;
					}
				}
				else if (this.Phase == 4)
				{
					this.PhaseTimer += Time.deltaTime;
					this.Speed += this.Speed * Time.deltaTime;
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 150f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					if (this.PhaseTimer > 5f)
					{
						this.QuintupleAttack = true;
						this.SextupleAttack = true;
						this.ShootEverywhere = false;
						this.AttackFrequency = 0.5f;
						this.PhaseTimer = 0f;
						this.Phase = 2;
					}
				}
				break;
			}
			if (this.AttackFrequency > 0f)
			{
				this.AttackTimer += Time.deltaTime;
				if (this.AttackTimer > this.AttackFrequency)
				{
					if (this.ShootEverywhere)
					{
						this.Attack(5f, this.Spin);
						this.Spin += 5f;
					}
					else if (this.SextupleAttack)
					{
						this.Attack(5f, 115f);
						this.Attack(5f, 105f);
						this.Attack(5f, 95f);
						this.Attack(5f, 85f);
						this.Attack(5f, 75f);
						this.Attack(5f, 65f);
						this.QuintupleAttack = true;
						this.SextupleAttack = false;
					}
					else if (this.QuintupleAttack)
					{
						this.Attack(5f, 105f);
						this.Attack(5f, 97.5f);
						this.Attack(5f, 90f);
						this.Attack(5f, 82.5f);
						this.Attack(5f, 75f);
						this.QuintupleAttack = false;
						this.SextupleAttack = true;
					}
					else if (this.TripleAttack)
					{
						this.Attack(5f, 90f);
						this.Attack(5f, 75f);
						this.Attack(5f, 105f);
					}
					else if (this.DoubleAttack)
					{
						this.Attack(2.5f, 90f);
						this.Attack(5f, 90f);
					}
					else
					{
						this.Attack(5f, 90f);
					}
					this.AttackTimer = 0f;
				}
			}
		}
		else if (this.Pattern < 11)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			if (this.Pattern == 6 || this.Pattern == 9 || this.Pattern == 12)
			{
				gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
			}
			else
			{
				gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
			}
			this.GameplayManager.Score += 100;
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			this.GameplayManager.Jukebox.volume -= Time.deltaTime * 0.1f;
			this.AttackFrequency = 0f;
			this.Pattern = 100;
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer < 5f)
			{
				if (this.ExplosionTimer == 0f)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
					gameObject2.transform.parent = base.transform.parent;
					gameObject2.transform.localPosition += new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-50f, 50f), 0f);
					gameObject2.transform.localScale = new Vector3(128f, 128f, 1f);
					this.GameplayManager.Score += 100;
					this.ExplosionTimer = 0.1f;
				}
				else
				{
					this.ExplosionTimer = Mathf.MoveTowards(this.ExplosionTimer, 0f, Time.deltaTime);
				}
			}
			else
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.FinalBossExplosion, base.transform.position, Quaternion.identity);
				gameObject3.transform.parent = base.transform.parent;
				gameObject3.transform.localScale = new Vector3(256f, 256f, 1f);
				this.GameplayManager.StageClear = true;
				this.GameplayManager.Score += 1000;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (this.FlashWhite > 0f)
		{
			this.FlashWhite = Mathf.MoveTowards(this.FlashWhite, 0f, Time.deltaTime);
			if (this.FlashWhite == 0f)
			{
				this.MyRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
				if (this.ExtraRenderer != null)
				{
					this.ExtraRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
				}
			}
		}
	}

	private void Attack(float AttackSpeed, float AttackRotation)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, base.transform.position, Quaternion.identity);
		gameObject.transform.parent = base.transform.parent;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
		if (this.Homing)
		{
			gameObject.transform.LookAt(this.Miyuki.transform);
		}
		else
		{
			gameObject.transform.localEulerAngles = new Vector3(AttackRotation, 90f, 0f);
		}
		gameObject.GetComponent<MGPMProjectileScript>().Speed = AttackSpeed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 8)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Impact, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			gameObject.transform.localScale = new Vector3(32f, 32f, 32f);
			gameObject.transform.localPosition = new Vector3(collision.gameObject.transform.localPosition.x, collision.gameObject.transform.localPosition.y, 1f);
			this.MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
			if (this.ExtraRenderer != null)
			{
				this.ExtraRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
			}
			UnityEngine.Object.Destroy(collision.gameObject);
			this.FlashWhite = 0.05f;
			this.Health--;
			if (this.HealthBar != null)
			{
				this.HealthBar.localScale = new Vector3((float)this.Health / 500f, 1f, 1f);
			}
		}
	}
}
