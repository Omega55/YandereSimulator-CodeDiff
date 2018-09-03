using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPMMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public AudioSource Jukebox;

	public AudioClip MiyukiPain;

	public AudioClip MiyukiDeath;

	public bool WindowDisplaying;

	public Transform Highlight;

	public Transform Background;

	public GameObject Controls;

	public GameObject Credits;

	public Renderer Black;

	public AudioClip BGM;

	public float Rotation;

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
				if (this.ID == 1)
				{
					SceneManager.LoadScene("MiyukiGameplayScene");
				}
				else
				{
					SceneManager.LoadScene("HomeScene");
				}
			}
		}
		if (!this.FadeOut && !this.FadeIn)
		{
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
					if (this.ID == 1 || this.ID == 4)
					{
						this.FadeOut = true;
					}
					else if (this.ID == 2)
					{
						this.Highlight.gameObject.SetActive(false);
						this.Controls.SetActive(true);
						this.WindowDisplaying = true;
					}
					else if (this.ID == 3)
					{
						this.Highlight.gameObject.SetActive(false);
						this.Credits.SetActive(true);
						this.WindowDisplaying = true;
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
		if (this.ID == 0)
		{
			this.ID = 4;
		}
		else if (this.ID == 5)
		{
			this.ID = 1;
		}
		this.Highlight.transform.position = new Vector3(0f, -0.2f * (float)this.ID, this.Highlight.transform.position.z);
	}
}
