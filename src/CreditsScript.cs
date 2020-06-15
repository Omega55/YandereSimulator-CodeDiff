using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
	[SerializeField]
	private JsonScript JSON;

	[SerializeField]
	private Transform SpawnPoint;

	[SerializeField]
	private Transform Panel;

	[SerializeField]
	private GameObject SmallCreditsLabel;

	[SerializeField]
	private GameObject BigCreditsLabel;

	[SerializeField]
	private UILabel SkipLabel;

	[SerializeField]
	private UISprite Darkness;

	[SerializeField]
	private int ID;

	[SerializeField]
	private float SpeedUpFactor;

	[SerializeField]
	private float TimerLimit;

	[SerializeField]
	private float FadeTimer;

	[SerializeField]
	private float Speed = 1f;

	[SerializeField]
	private float Timer;

	[SerializeField]
	private bool FadeOut;

	[SerializeField]
	private bool Begin;

	[SerializeField]
	private bool Dark;

	private const int SmallTextSize = 1;

	private const int BigTextSize = 2;

	public AudioClip DarkCreditsMusic;

	public AudioSource Jukebox;

	public ParticleSystem Blossoms;

	private bool ShouldStopCredits
	{
		get
		{
			return this.ID == this.JSON.Credits.Length;
		}
	}

	private GameObject SpawnLabel(int size)
	{
		return UnityEngine.Object.Instantiate<GameObject>((size == 1) ? this.SmallCreditsLabel : this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
	}

	private void Start()
	{
		if (DateGlobals.Weekday == DayOfWeek.Sunday || GameGlobals.DarkEnding)
		{
			GameGlobals.DarkEnding = false;
			this.Jukebox.clip = this.DarkCreditsMusic;
			this.Darkness.color = new Color(0f, 0f, 0f, 0f);
			this.Speed = 1.1f;
			this.Blossoms.startColor = new Color(0.5f, 0f, 0f, 1f);
			this.SkipLabel.color = new Color(0.5f, 0f, 0f, 1f);
			this.Dark = true;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("d"))
		{
			GameGlobals.DarkEnding = true;
			Application.LoadLevel(Application.loadedLevel);
		}
		if (!this.Begin)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Begin = true;
				this.Jukebox.Play();
				this.Timer = 0f;
			}
		}
		else
		{
			if (!this.ShouldStopCredits)
			{
				if (this.Timer == 0f)
				{
					CreditJson creditJson = this.JSON.Credits[this.ID];
					GameObject gameObject = this.SpawnLabel(creditJson.Size);
					this.TimerLimit = (float)creditJson.Size * this.SpeedUpFactor;
					gameObject.transform.parent = this.Panel;
					gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject.GetComponent<UILabel>().text = creditJson.Name;
					if (this.Dark)
					{
						gameObject.GetComponent<UILabel>().color = new Color(0.5f, 0f, 0f, 1f);
					}
					this.ID++;
				}
				this.Timer += Time.deltaTime * this.Speed;
				if (this.Timer >= this.TimerLimit)
				{
					this.Timer = 0f;
				}
			}
			if (Input.GetButtonDown("B") || this.Jukebox.time >= this.Jukebox.clip.length)
			{
				this.FadeOut = true;
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			this.Jukebox.volume -= Time.deltaTime;
			if (this.Darkness.color.a == 1f)
			{
				if (this.Darkness.color.r == 1f)
				{
					SceneManager.LoadScene("TitleScene");
				}
				else
				{
					SceneManager.LoadScene("PostCreditsScene");
				}
			}
		}
		bool keyDown = Input.GetKeyDown(KeyCode.Minus);
		bool keyDown2 = Input.GetKeyDown(KeyCode.Equals);
		if (keyDown)
		{
			Time.timeScale -= 1f;
		}
		else if (keyDown2)
		{
			Time.timeScale += 1f;
		}
		if (keyDown || keyDown2)
		{
			this.Jukebox.pitch = Time.timeScale;
		}
	}
}
