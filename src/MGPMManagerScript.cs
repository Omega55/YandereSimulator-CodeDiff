using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MGPMManagerScript : MonoBehaviour
{
	public MGPMSpawnerScript[] EnemySpawner;

	public MGPMMiyukiScript Miyuki;

	public GameObject StageClearGraphic;

	public GameObject GameOverGraphic;

	public GameObject StartGraphic;

	public AudioClip GameOverMusic;

	public AudioClip VictoryMusic;

	public AudioSource Jukebox;

	public AudioClip FinalBoss;

	public AudioClip BGM;

	public Renderer Black;

	public Text ScoreLabel;

	public bool StageClear;

	public bool GameOver;

	public bool FadeOut;

	public bool FadeIn;

	public bool Intro;

	public float GameOverTimer;

	public float Timer;

	public int Score;

	public int ID;

	private void Start()
	{
		this.Miyuki.transform.localPosition = new Vector3(0f, -300f, 0f);
		this.Black.material.color = new Color(0f, 0f, 0f, 1f);
		this.StartGraphic.SetActive(false);
		this.Miyuki.Gameplay = false;
		this.ID = 1;
		while (this.ID < this.EnemySpawner.Length)
		{
			this.EnemySpawner[this.ID].enabled = false;
			this.ID++;
		}
		Time.timeScale = 1f;
	}

	private void Update()
	{
		this.ScoreLabel.text = "Score: " + this.Score * this.Miyuki.Health;
		if (this.StageClear)
		{
			this.GameOverTimer += Time.deltaTime;
			if (this.GameOverTimer > 1f)
			{
				this.Miyuki.transform.localPosition = new Vector3(this.Miyuki.transform.localPosition.x, this.Miyuki.transform.localPosition.y + Time.deltaTime * 10f, this.Miyuki.transform.localPosition.z);
				if (!this.StageClearGraphic.activeInHierarchy)
				{
					this.StageClearGraphic.SetActive(true);
					this.Jukebox.clip = this.VictoryMusic;
					this.Jukebox.loop = false;
					this.Jukebox.volume = 1f;
					this.Jukebox.Play();
				}
				if (this.GameOverTimer > 9f)
				{
					this.FadeOut = true;
				}
			}
			if (this.FadeOut)
			{
				this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
				this.Jukebox.volume = 1f - this.Black.material.color.a;
				if (this.Black.material.color.a == 1f)
				{
					SceneManager.LoadScene("MiyukiThanksScene");
				}
			}
		}
		else if (!this.GameOver)
		{
			if (this.Intro)
			{
				if (this.FadeIn)
				{
					this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 0f, Time.deltaTime));
					if (this.Black.material.color.a == 0f)
					{
						this.Jukebox.Play();
						this.FadeIn = false;
					}
				}
				else
				{
					this.Miyuki.transform.localPosition = new Vector3(0f, Mathf.MoveTowards(this.Miyuki.transform.localPosition.y, -120f, Time.deltaTime * 60f), 0f);
					if (this.Miyuki.transform.localPosition.y == -120f)
					{
						if (!this.Jukebox.isPlaying)
						{
							this.Jukebox.loop = true;
							this.Jukebox.clip = this.BGM;
							this.Jukebox.Play();
						}
						this.StartGraphic.SetActive(true);
						this.Timer += Time.deltaTime;
						if ((double)this.Timer > 3.5)
						{
							this.StartGraphic.SetActive(false);
							this.ID = 1;
							while (this.ID < this.EnemySpawner.Length)
							{
								this.EnemySpawner[this.ID].enabled = true;
								this.ID++;
							}
							this.Miyuki.Gameplay = true;
							this.Intro = false;
						}
					}
				}
				if (Input.GetKeyDown("space"))
				{
					this.StartGraphic.SetActive(false);
					this.ID = 1;
					while (this.ID < this.EnemySpawner.Length)
					{
						this.EnemySpawner[this.ID].enabled = true;
						this.ID++;
					}
					this.Black.material.color = new Color(0f, 0f, 0f, 0f);
					this.Miyuki.Gameplay = true;
					this.Intro = false;
					this.Jukebox.loop = true;
					this.Jukebox.clip = this.BGM;
					this.Jukebox.Play();
				}
			}
		}
		else
		{
			this.GameOverTimer += Time.deltaTime;
			if (this.GameOverTimer > 3f)
			{
				if (!this.GameOverGraphic.activeInHierarchy)
				{
					this.GameOverGraphic.SetActive(true);
					this.Jukebox.clip = this.GameOverMusic;
					this.Jukebox.loop = false;
					this.Jukebox.Play();
				}
				else if (Input.anyKeyDown)
				{
					this.FadeOut = true;
				}
			}
			if (this.FadeOut)
			{
				this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
				this.Jukebox.volume = 1f - this.Black.material.color.a;
				if (this.Black.material.color.a == 1f)
				{
					SceneManager.LoadScene("MiyukiTitleScene");
				}
			}
		}
	}

	public void BeginGameOver()
	{
		this.Jukebox.Stop();
		this.GameOver = true;
		this.Miyuki.enabled = false;
	}
}
