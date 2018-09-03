using System;
using UnityEngine;

public class MGPMMiyukiScript : MonoBehaviour
{
	public MGPMManagerScript GameplayManager;

	public InputManagerScript InputManager;

	public AudioClip DamageSound;

	public AudioClip DeathSound;

	public GameObject Projectile;

	public GameObject DeathExplosion;

	public GameObject Explosion;

	public Transform SpawnPoint;

	public Renderer MyRenderer;

	public Texture[] ForwardSprite;

	public Texture[] ReverseRightSprite;

	public Texture[] TurnRightSprite;

	public Texture[] RightSprite;

	public Texture[] ReverseLeftSprite;

	public Texture[] TurnLeftSprite;

	public Texture[] LeftSprite;

	public GameObject[] Hearts;

	public int Frame;

	public int RightPhase;

	public int LeftPhase;

	public int Health;

	public float ShootTimer;

	public float Speed;

	public float Timer;

	public float FPS;

	public float PositionX;

	public float PositionY;

	public bool Gameplay;

	private void Start()
	{
		Time.timeScale = 1f;
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
			if (Input.GetKey("z") || Input.GetButton("A"))
			{
				if (this.ShootTimer == 0f)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, Quaternion.identity);
					gameObject.transform.parent = base.transform.parent;
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
					gameObject.transform.localScale = new Vector3(16f, 16f, 1f);
					this.ShootTimer = 0f;
				}
				this.ShootTimer += Time.deltaTime;
				if (this.ShootTimer >= 0.075f)
				{
					this.ShootTimer = 0f;
				}
			}
			if (Input.GetKeyUp("z") || Input.GetButtonUp("A"))
			{
				this.ShootTimer = 0f;
			}
			if (Input.GetKeyDown("r"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			this.Health--;
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
			this.Hearts[1].SetActive(false);
			this.Hearts[2].SetActive(false);
			this.Hearts[3].SetActive(false);
			for (int i = 1; i < this.Health + 1; i++)
			{
				this.Hearts[i].SetActive(true);
			}
		}
	}
}
