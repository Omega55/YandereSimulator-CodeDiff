using System;
using UnityEngine;

[Serializable]
public class YanvaniaZombieScript : MonoBehaviour
{
	public GameObject ZombieEffect;

	public GameObject BloodEffect;

	public GameObject DeathEffect;

	public GameObject HitEffect;

	public GameObject Character;

	public YanvaniaYanmontScript Yanmont;

	public int HP;

	public float WalkSpeed1;

	public float WalkSpeed2;

	public float Damage;

	public float HitReactTimer;

	public float DeathTimer;

	public float WalkTimer;

	public float Timer;

	public int HitReactState;

	public int WalkType;

	public float LeftBoundary;

	public float RightBoundary;

	public bool EffectSpawned;

	public bool Dying;

	public bool Sink;

	public bool Walk;

	public Texture[] Textures;

	public Renderer MyRenderer;

	public Collider MyCollider;

	public AudioClip DeathSound;

	public AudioClip HitSound;

	public AudioClip RisingSound;

	public AudioClip SinkingSound;

	public virtual void Start()
	{
		if (this.Yanmont.transform.position.x > this.transform.position.x)
		{
			int num = 90;
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num2 = eulerAngles.y = (float)num;
			Vector3 vector = this.transform.eulerAngles = eulerAngles;
		}
		else
		{
			int num3 = -90;
			Vector3 eulerAngles2 = this.transform.eulerAngles;
			float num4 = eulerAngles2.y = (float)num3;
			Vector3 vector2 = this.transform.eulerAngles = eulerAngles2;
		}
		UnityEngine.Object.Instantiate(this.ZombieEffect, this.transform.position, Quaternion.identity);
		float y = -0.63f;
		Vector3 position = this.transform.position;
		float num5 = position.y = y;
		Vector3 vector3 = this.transform.position = position;
		this.Character.animation["getup1"].speed = (float)2;
		this.Character.animation.Play("getup1");
		this.audio.PlayOneShot(this.RisingSound);
		this.MyRenderer.material.mainTexture = this.Textures[UnityEngine.Random.Range(0, 22)];
		this.MyCollider.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Dying)
		{
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer > (float)1)
			{
				if (!this.EffectSpawned)
				{
					UnityEngine.Object.Instantiate(this.ZombieEffect, this.transform.position, Quaternion.identity);
					this.audio.PlayOneShot(this.SinkingSound);
					this.EffectSpawned = true;
				}
				float y = this.transform.position.y - Time.deltaTime;
				Vector3 position = this.transform.position;
				float num = position.y = y;
				Vector3 vector = this.transform.position = position;
				if (this.transform.position.y < -0.4f)
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
		else
		{
			if (this.Sink)
			{
				float y2 = this.transform.position.y - Time.deltaTime * 0.74f;
				Vector3 position2 = this.transform.position;
				float num2 = position2.y = y2;
				Vector3 vector2 = this.transform.position = position2;
				if (this.transform.position.y < -0.63f)
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
			else if (this.Walk)
			{
				this.WalkTimer += Time.deltaTime;
				if (this.WalkType == 1)
				{
					this.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed1);
					this.Character.animation.CrossFade("walk1");
				}
				else
				{
					this.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed2);
					this.Character.animation.CrossFade("walk2");
				}
				if (this.WalkTimer > (float)10)
				{
					this.SinkNow();
				}
			}
			else
			{
				this.Timer += Time.deltaTime;
				if (this.transform.position.y < (float)0)
				{
					float y3 = this.transform.position.y + Time.deltaTime * 0.74f;
					Vector3 position3 = this.transform.position;
					float num3 = position3.y = y3;
					Vector3 vector3 = this.transform.position = position3;
					if (this.transform.position.y > (float)0)
					{
						int num4 = 0;
						Vector3 position4 = this.transform.position;
						float num5 = position4.y = (float)num4;
						Vector3 vector4 = this.transform.position = position4;
					}
				}
				if (this.Timer > 0.85f)
				{
					this.Walk = true;
					this.MyCollider.enabled = true;
					this.WalkType = UnityEngine.Random.Range(1, 3);
				}
			}
			if (this.transform.position.x < this.LeftBoundary)
			{
				float leftBoundary = this.LeftBoundary;
				Vector3 position5 = this.transform.position;
				float num6 = position5.x = leftBoundary;
				Vector3 vector5 = this.transform.position = position5;
				this.SinkNow();
			}
			if (this.transform.position.x > this.RightBoundary)
			{
				float rightBoundary = this.RightBoundary;
				Vector3 position6 = this.transform.position;
				float num7 = position6.x = rightBoundary;
				Vector3 vector6 = this.transform.position = position6;
				this.SinkNow();
			}
			if (this.HP <= 0)
			{
				UnityEngine.Object.Instantiate(this.DeathEffect, new Vector3(this.transform.position.x, this.transform.position.y + (float)1, this.transform.position.z), Quaternion.identity);
				this.Character.animation.Play("die");
				this.audio.PlayOneShot(this.DeathSound);
				this.MyCollider.enabled = false;
				this.Yanmont.EXP = this.Yanmont.EXP + (float)10;
				this.Dying = true;
			}
		}
		if (this.HitReactTimer < (float)1)
		{
			this.MyRenderer.material.color = new Color((float)1, this.HitReactTimer, this.HitReactTimer, (float)1);
			this.HitReactTimer += Time.deltaTime * (float)10;
			if (this.HitReactTimer >= (float)1)
			{
				this.MyRenderer.material.color = new Color((float)1, (float)1, (float)1, (float)1);
			}
		}
	}

	public virtual void SinkNow()
	{
		this.Character.animation["getup1"].time = this.Character.animation["getup1"].length;
		this.Character.animation["getup1"].speed = (float)-2;
		this.Character.animation.Play("getup1");
		this.audio.PlayOneShot(this.SinkingSound);
		UnityEngine.Object.Instantiate(this.ZombieEffect, this.transform.position, Quaternion.identity);
		this.MyCollider.enabled = false;
		this.Sink = true;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (!this.Dying)
		{
			if (other.gameObject.tag == "Player")
			{
				this.Yanmont.TakeDamage(5);
			}
			if (other.gameObject.name == "Heart" && this.HitReactTimer >= (float)1)
			{
				UnityEngine.Object.Instantiate(this.HitEffect, other.transform.position, Quaternion.identity);
				this.audio.PlayOneShot(this.HitSound);
				this.HitReactTimer = (float)0;
				this.HP -= 20 + (this.Yanmont.Level * 5 - 5);
			}
		}
	}

	public virtual void Main()
	{
	}
}
