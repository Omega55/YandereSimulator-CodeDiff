using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPMMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public AudioSource Jukebox;

	public AudioClip HardModeClip;

	public bool WindowDisplaying;

	public Transform Highlight;

	public Transform Background;

	public GameObject Controls;

	public GameObject Credits;

	public GameObject DifficultySelect;

	public GameObject MainMenu;

	public Renderer Black;

	public Renderer Logo;

	public Renderer BG;

	public Texture BloodyLogo;

	public AudioClip BGM;

	public float Rotation;

	public float Vibrate;

	public bool HardMode;

	public bool FadeOut;

	public bool FadeIn;

	public int ID;

	private void Start()
	{
		this.Black.material.color = new Color(0f, 0f, 0f, 1f);
		Time.timeScale = 1f;
	}

	private void Update()
	{
		this.Rotation -= Time.deltaTime * 3f;
		this.Background.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		if (this.FadeIn)
		{
			this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 0f, Time.deltaTime));
			if (this.Black.material.color.a == 0f)
			{
				this.Jukebox.Play();
				this.FadeIn = false;
			}
		}
		if (this.FadeOut)
		{
			this.Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.material.color.a, 1f, Time.deltaTime));
			this.Jukebox.volume = 1f - this.Black.material.color.a;
			if (this.Black.material.color.a == 1f)
			{
				if (this.ID == 4)
				{
					SceneManager.LoadScene("HomeScene");
				}
				else
				{
					GameGlobals.HardMode = this.HardMode;
					SceneManager.LoadScene("MiyukiGameplayScene");
				}
			}
		}
		if (!this.FadeOut && !this.FadeIn)
		{
			if (!this.HardMode && Input.GetKeyDown("h"))
			{
				AudioSource.PlayClipAtPoint(this.HardModeClip, base.transform.position);
				this.Logo.material.mainTexture = this.BloodyLogo;
				this.HardMode = true;
				this.Vibrate = 0.1f;
			}
			if (this.HardMode)
			{
				this.Jukebox.pitch = Mathf.MoveTowards(this.Jukebox.pitch, 0.1f, Time.deltaTime);
				this.BG.material.color = new Color(Mathf.MoveTowards(this.BG.material.color.r, 0.5f, Time.deltaTime * 0.5f), Mathf.MoveTowards(this.BG.material.color.g, 0f, Time.deltaTime), Mathf.MoveTowards(this.BG.material.color.b, 0f, Time.deltaTime), 1f);
				this.Logo.transform.localPosition = new Vector3(0f, 0.5f, 2f) + new Vector3(UnityEngine.Random.Range(this.Vibrate * -1f, this.Vibrate), UnityEngine.Random.Range(this.Vibrate * -1f, this.Vibrate), 0f);
				this.Vibrate = Mathf.MoveTowards(this.Vibrate, 0f, Time.deltaTime * 0.1f);
			}
			if (this.Jukebox.clip != this.BGM && !this.Jukebox.isPlaying)
			{
				this.Jukebox.loop = true;
				this.Jukebox.clip = this.BGM;
				this.Jukebox.Play();
			}
			if (!this.WindowDisplaying)
			{
				if (this.InputManager.TappedDown)
				{
					this.ID++;
					this.UpdateHighlight();
				}
				if (this.InputManager.TappedUp)
				{
					this.ID--;
					this.UpdateHighlight();
				}
				if (Input.GetButtonDown("A") || Input.GetKeyDown("z") || (Input.GetKeyDown("return") | Input.GetKeyDown("space")))
				{
					if (!this.MainMenu.activeInHierarchy)
					{
						if (this.ID == 2)
						{
							GameGlobals.EasyMode = false;
						}
						else
						{
							GameGlobals.EasyMode = true;
						}
						this.FadeOut = true;
						return;
					}
					if (this.ID == 1)
					{
						this.DifficultySelect.SetActive(true);
						this.MainMenu.SetActive(false);
						this.ID = 2;
						this.UpdateHighlight();
						return;
					}
					if (this.ID == 2)
					{
						this.Highlight.gameObject.SetActive(false);
						this.Controls.SetActive(true);
						this.WindowDisplaying = true;
						return;
					}
					if (this.ID == 3)
					{
						this.Highlight.gameObject.SetActive(false);
						this.Credits.SetActive(true);
						this.WindowDisplaying = true;
						return;
					}
					if (this.ID == 4)
					{
						this.FadeOut = true;
						return;
					}
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				this.Highlight.gameObject.SetActive(true);
				this.Controls.SetActive(false);
				this.Credits.SetActive(false);
				this.WindowDisplaying = false;
			}
		}
	}

	private void UpdateHighlight()
	{
		if (this.MainMenu.activeInHierarchy)
		{
			if (this.ID == 0)
			{
				this.ID = 4;
			}
			else if (this.ID == 5)
			{
				this.ID = 1;
			}
		}
		else if (this.ID == 1)
		{
			this.ID = 3;
		}
		else if (this.ID == 4)
		{
			this.ID = 2;
		}
		this.Highlight.transform.position = new Vector3(0f, -0.2f * (float)this.ID, this.Highlight.transform.position.z);
	}
}
