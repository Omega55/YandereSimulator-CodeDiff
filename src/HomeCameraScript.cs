using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeCameraScript : MonoBehaviour
{
	public HomeWindowScript[] HomeWindows;

	public HomeTriggerScript[] Triggers;

	public HomePantyChangerScript HomePantyChanger;

	public HomeSenpaiShrineScript HomeSenpaiShrine;

	public HomeVideoGamesScript HomeVideoGames;

	public HomeCorkboardScript HomeCorkboard;

	public HomeDarknessScript HomeDarkness;

	public HomeInternetScript HomeInternet;

	public HomePrisonerScript HomePrisoner;

	public HomeYandereScript HomeYandere;

	public HomeMangaScript HomeManga;

	public HomeSleepScript HomeSleep;

	public HomeExitScript HomeExit;

	public PromptBarScript PromptBar;

	public Vignetting Vignette;

	public UILabel PantiesMangaLabel;

	public UISprite Button;

	public GameObject ComputerScreen;

	public GameObject CorkboardLabel;

	public GameObject LoadingScreen;

	public GameObject CeilingLight;

	public GameObject Controller;

	public GameObject NightLight;

	public GameObject RopeGroup;

	public GameObject DayLight;

	public GameObject Tripod;

	public GameObject Victim;

	public Transform Destination;

	public Transform Target;

	public Transform Focus;

	public Transform[] Destinations;

	public Transform[] Targets;

	public int ID;

	public AudioSource BasementJukebox;

	public AudioSource RoomJukebox;

	public AudioClip NightBasement;

	public AudioClip NightRoom;

	public bool Torturing;

	private void Start()
	{
		this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, 0f);
		this.Focus.position = this.Target.position;
		base.transform.position = this.Destination.position;
		if (PlayerPrefs.GetInt("Night") == 1)
		{
			this.CeilingLight.SetActive(true);
			this.NightLight.SetActive(true);
			this.DayLight.SetActive(false);
			this.Triggers[7].Disable();
			this.BasementJukebox.clip = this.NightBasement;
			this.RoomJukebox.clip = this.NightRoom;
			this.PlayMusic();
			this.PantiesMangaLabel.text = "Read Manga";
		}
		else
		{
			this.BasementJukebox.Play();
			this.RoomJukebox.Play();
			this.ComputerScreen.SetActive(false);
			this.Triggers[2].Disable();
			this.Triggers[3].Disable();
			this.Triggers[5].Disable();
			this.Triggers[9].Disable();
		}
		if (PlayerPrefs.GetInt("KidnapVictim") == 0)
		{
			this.RopeGroup.SetActive(false);
			this.Tripod.SetActive(false);
			this.Victim.SetActive(false);
			this.Triggers[10].Disable();
		}
		else
		{
			int @int = PlayerPrefs.GetInt("KidnapVictim");
			if (PlayerPrefs.GetInt("Student_" + @int.ToString() + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + @int.ToString() + "_Dead") == 1)
			{
				this.RopeGroup.SetActive(false);
				this.Victim.SetActive(false);
				this.Triggers[10].Disable();
			}
		}
		Time.timeScale = 1f;
	}

	private void LateUpdate()
	{
		if (this.HomeYandere.transform.position.y > -5f)
		{
			Transform transform = this.Destinations[0];
			transform.position = new Vector3(-this.HomeYandere.transform.position.x, transform.position.y, transform.position.z);
		}
		this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * 10f);
		base.transform.position = Vector3.Lerp(base.transform.position, this.Destination.position, Time.deltaTime * 10f);
		base.transform.LookAt(this.Focus.position);
		if (this.ID < 11 && Input.GetButtonDown("A") && this.HomeYandere.CanMove && this.ID != 0)
		{
			this.Destination = this.Destinations[this.ID];
			this.Target = this.Targets[this.ID];
			this.HomeWindows[this.ID].Show = true;
			this.HomeYandere.CanMove = false;
			if (this.ID == 1 || this.ID == 8)
			{
				this.HomeExit.enabled = true;
			}
			else if (this.ID == 2)
			{
				this.HomeSleep.enabled = true;
			}
			else if (this.ID == 3)
			{
				this.HomeInternet.enabled = true;
			}
			else if (this.ID == 4)
			{
				this.CorkboardLabel.SetActive(false);
				this.HomeCorkboard.enabled = true;
				this.LoadingScreen.SetActive(true);
				this.HomeYandere.gameObject.SetActive(false);
			}
			else if (this.ID == 5)
			{
				this.HomeYandere.enabled = false;
				this.Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, 0f);
				this.HomeYandere.transform.position = new Vector3(1f, 0f, 0f);
				this.HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				this.HomeYandere.Character.GetComponent<Animation>().Play("f02_gaming_00");
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Play";
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.Label[4].text = "Select";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
			else if (this.ID == 6)
			{
				this.HomeSenpaiShrine.enabled = true;
				this.HomeYandere.gameObject.SetActive(false);
			}
			else if (this.ID == 7)
			{
				this.HomePantyChanger.enabled = true;
			}
			else if (this.ID == 9)
			{
				this.HomeManga.enabled = true;
			}
			else if (this.ID == 10)
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.HomePrisoner.UpdateDesc();
				this.HomeYandere.gameObject.SetActive(false);
			}
		}
		if (this.Destination == this.Destinations[0])
		{
			this.Vignette.intensity = ((this.HomeYandere.transform.position.y <= -1f) ? Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 5f) : Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime));
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 1f, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 1f, Time.deltaTime);
		}
		else
		{
			this.Vignette.intensity = ((this.HomeYandere.transform.position.y <= -1f) ? Mathf.MoveTowards(this.Vignette.intensity, 0f, Time.deltaTime * 5f) : Mathf.MoveTowards(this.Vignette.intensity, 0f, Time.deltaTime));
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 0f, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 0f, Time.deltaTime);
		}
		this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, (this.ID <= 0 || !this.HomeYandere.CanMove) ? 0f : 1f, Time.deltaTime * 10f));
		if (this.HomeDarkness.FadeOut)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0f, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0f, Time.deltaTime);
		}
		else if (this.HomeYandere.transform.position.y > -1f)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0f, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 1f, Time.deltaTime);
		}
		else if (!this.Torturing)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 1f, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0f, Time.deltaTime);
		}
		if (Input.GetKeyDown("y"))
		{
			PlayerPrefs.SetInt("Task_14_Status", 1);
		}
		if (Input.GetKeyDown("`"))
		{
			if (PlayerPrefs.GetInt("Night") == 0)
			{
				PlayerPrefs.SetInt("Night", 1);
			}
			else
			{
				PlayerPrefs.SetInt("Night", 0);
			}
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale = 100f;
		}
	}

	public void PlayMusic()
	{
		if (PlayerPrefs.GetInt("DraculaDefeated") == 0)
		{
			if (!this.BasementJukebox.isPlaying)
			{
				this.BasementJukebox.Play();
			}
			if (!this.RoomJukebox.isPlaying)
			{
				this.RoomJukebox.Play();
			}
		}
	}
}
