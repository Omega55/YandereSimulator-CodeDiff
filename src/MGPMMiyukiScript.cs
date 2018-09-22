using System;
using UnityEngine;

public class MGPMMiyukiScript : MonoBehaviour
{
	public MGPMManagerScript GameplayManager;

	public InputManagerScript InputManager;

	public AudioClip DamageSound;

	public AudioClip PickUpSound;

	public AudioClip DeathSound;

	public GameObject Projectile;

	public GameObject DeathExplosion;

	public GameObject Explosion;

	public Transform SpawnPoint;

	public Transform MagicBar;

	public Renderer MyRenderer;

	public Texture[] ForwardSprite;

	public Texture[] ReverseRightSprite;

	public Texture[] TurnRightSprite;

	public Texture[] RightSprite;

	public Texture[] ReverseLeftSprite;

	public Texture[] TurnLeftSprite;

	public Texture[] LeftSprite;

	public GameObject[] Hearts;

	public int MagicLevel;

	public int Frame;

	public int RightPhase;

	public int LeftPhase;

	public int Health;

	public float Invincibility;

	public float ShootTimer;

	public float Magic;

	public float Speed;

	public float Timer;

	public float FPS;

	public float PositionX;

	public float PositionY;

	public bool Gameplay;

	private void Start()
	{
		Time.timeScale = 1f;
		if (!GameGlobals.EasyMode)
		{
			this.MagicBar.parent.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.Timer = 0f;
			this.Frame++;
			if (this.Frame == 3)
			{
				this.Frame = 0;
				if (this.RightPhase == 1)
				{
					this.RightPhase = 2;
				}
				else if (this.RightPhase == 3)
				{
					this.RightPhase = 0;
				}
				if (this.LeftPhase == 1)
				{
					this.LeftPhase = 2;
				}
				else if (this.LeftPhase == 3)
				{
					this.LeftPhase = 0;
				}
			}
			if (this.RightPhase == 0 && this.LeftPhase == 0)
			{
				this.MyRenderer.material.mainTexture = this.ForwardSprite[this.Frame];
			}
			else if (this.RightPhase == 1)
			{
				this.MyRenderer.material.mainTexture = this.TurnRightSprite[this.Frame];
			}
			else if (this.RightPhase == 2)
			{
				this.MyRenderer.material.mainTexture = this.RightSprite[this.Frame];
			}
			else if (this.RightPhase == 3)
			{
				this.MyRenderer.material.mainTexture = this.ReverseRightSprite[this.Frame];
			}
			else if (this.LeftPhase == 1)
			{
				this.MyRenderer.material.mainTexture = this.TurnLeftSprite[this.Frame];
			}
			else if (this.LeftPhase == 2)
			{
				this.MyRenderer.material.mainTexture = this.LeftSprite[this.Frame];
			}
			else if (this.LeftPhase == 3)
			{
				this.MyRenderer.material.mainTexture = this.ReverseLeftSprite[this.Frame];
			}
		}
		float num;
		if (Input.GetButton("LB"))
		{
			num = this.Speed * 0.5f;
		}
		else
		{
			num = this.Speed;
		}
		if (this.Gameplay)
		{
			if (Input.GetKey("right") || this.InputManager.DPadRight || Input.GetAxis("Horizontal") > 0.5f)
			{
				if (this.RightPhase < 1)
				{
					this.RightPhase = 1;
					this.LeftPhase = 0;
					this.Frame = 0;
				}
				this.PositionX += num * Time.deltaTime;
			}
			else if (this.RightPhase == 1 || this.RightPhase == 2)
			{
				this.RightPhase = 3;
				this.Frame = 0;
			}
			if (Input.GetKey("left") || this.InputManager.DPadLeft || Input.GetAxis("Horizontal") < -0.5f)
			{
				if (this.LeftPhase < 1)
				{
					this.RightPhase = 0;
					this.LeftPhase = 1;
					this.Frame = 0;
				}
				this.PositionX -= num * Time.deltaTime;
			}
			else if (this.LeftPhase == 1 || this.LeftPhase == 2)
			{
				this.LeftPhase = 3;
				this.Frame = 0;
			}
			if (Input.GetKey("up") || this.InputManager.DPadUp || Input.GetAxis("Vertical") > 0.5f)
			{
				this.PositionY += num * Time.deltaTime;
			}
			if (Input.GetKey("down") || this.InputManager.DPadDown || Input.GetAxis("Vertical") < -0.5f)
			{
				this.PositionY -= num * Time.deltaTime;
			}
			if (this.PositionX > 108f)
			{
				this.PositionX = 108f;
			}
			if (this.PositionX < -110f)
			{
				this.PositionX = -110f;
			}
			if (this.PositionY > 224f)
			{
				this.PositionY = 224f;
			}
			if (this.PositionY < -224f)
			{
				this.PositionY = -224f;
			}
			base.transform.localPosition = new Vector3(this.PositionX, this.PositionY, 0f);
			if (Input.GetKey("z") || Input.GetKey("y") || Input.GetButton("A"))
			{
				if (this.ShootTimer == 0f)
				{
					if (this.MagicLevel == 0)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else if (this.MagicLevel == 1)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.1f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.1f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else if (this.MagicLevel == 2)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					}
					else
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(0.4f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject.GetComponent<MGPMProjectileScript>().Angle = 1;
						gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position + new Vector3(-0.4f, 0f, 0f), Quaternion.identity);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
						gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
						gameObject.GetComponent<MGPMProjectileScript>().Angle = -1;
					}
					this.ShootTimer = 0f;
				}
				this.ShootTimer += Time.deltaTime;
				if (this.ShootTimer >= 0.075f)
				{
					this.ShootTimer = 0f;
				}
			}
			if (Input.GetKeyUp("z") || Input.GetKeyUp("y") || Input.GetButtonUp("A"))
			{
				this.ShootTimer = 0f;
			}
			if (Input.GetKeyDown("r"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if (this.Invincibility > 0f)
		{
			this.Invincibility = Mathf.MoveTowards(this.Invincibility, 0f, Time.deltaTime);
			if (this.Invincibility == 0f)
			{
				this.MyRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			if (this.Invincibility == 0f)
			{
				this.Health--;
				if (GameGlobals.EasyMode)
				{
					this.MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
					this.Invincibility = 1f;
				}
				if (this.Health > 0)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
					gameObject.transform.parent = base.transform.parent;
					gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
					AudioSource.PlayClipAtPoint(this.DamageSound, base.transform.position);
				}
				else
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.DeathExplosion, base.transform.position, Quaternion.identity);
					gameObject.transform.parent = base.transform.parent;
					gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
					AudioSource.PlayClipAtPoint(this.DeathSound, base.transform.position);
					this.GameplayManager.BeginGameOver();
					base.gameObject.SetActive(false);
				}
			}
			this.UpdateHearts();
		}
		else if (collision.gameObject.layer == 15)
		{
			AudioSource.PlayClipAtPoint(this.PickUpSound, base.transform.position);
			this.GameplayManager.Score += 10;
			this.Magic += 1f;
			if (this.Magic == 20f)
			{
				this.MagicLevel++;
				if (this.MagicLevel > 3 && this.Health < 3)
				{
					this.Health++;
					this.UpdateHearts();
				}
				this.Magic = 0f;
			}
			this.MagicBar.localScale = new Vector3(this.Magic / 20f, 1f, 1f);
			UnityEngine.Object.Destroy(collision.gameObject);
		}
	}

	private void UpdateHearts()
	{
		this.Hearts[1].SetActive(false);
		this.Hearts[2].SetActive(false);
		this.Hearts[3].SetActive(false);
		for (int i = 1; i < this.Health + 1; i++)
		{
			this.Hearts[i].SetActive(true);
		}
	}
}
