using System;
using UnityEngine;

[Serializable]
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

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		this.Focus.position = this.Target.position;
		this.transform.position = this.Destination.position;
		if (PlayerPrefs.GetInt("Night") == 1)
		{
			this.CeilingLight.active = true;
			this.NightLight.active = true;
			this.DayLight.active = false;
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
			this.ComputerScreen.active = false;
			this.Triggers[2].Disable();
			this.Triggers[3].Disable();
			this.Triggers[5].Disable();
			this.Triggers[9].Disable();
		}
		if (PlayerPrefs.GetInt("KidnapVictim") == 0)
		{
			this.RopeGroup.active = false;
			this.Tripod.active = false;
			this.Victim.active = false;
			this.Triggers[10].Disable();
		}
		else
		{
			int @int = PlayerPrefs.GetInt("KidnapVictim");
			if (PlayerPrefs.GetInt("Student_" + @int + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + @int + "_Dead") == 1)
			{
				this.RopeGroup.active = false;
				this.Victim.active = false;
				this.Triggers[10].Disable();
			}
		}
		Time.timeScale = (float)1;
	}

	public virtual void LateUpdate()
	{
		if (this.HomeYandere.transform.position.y > (float)-5)
		{
			float x = this.HomeYandere.transform.position.x * (float)-1;
			Vector3 position = this.Destinations[0].position;
			float num = position.x = x;
			Vector3 vector = this.Destinations[0].position = position;
		}
		this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * (float)10);
		this.transform.position = Vector3.Lerp(this.transform.position, this.Destination.position, Time.deltaTime * (float)10);
		this.transform.LookAt(this.Focus.position);
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
				this.CorkboardLabel.active = false;
				this.HomeCorkboard.enabled = true;
				this.LoadingScreen.active = true;
				this.HomeYandere.active = false;
			}
			else if (this.ID == 5)
			{
				this.HomeYandere.enabled = false;
				this.Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, (float)0);
				this.HomeYandere.transform.position = new Vector3((float)1, (float)0, (float)0);
				this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)90, (float)0);
				this.HomeYandere.Character.animation.Play("f02_gaming_00");
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
				this.HomeYandere.active = false;
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
				this.HomeYandere.active = false;
			}
		}
		if (this.Destination == this.Destinations[0])
		{
			if (this.HomeYandere.transform.position.y > (float)-1)
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)1, Time.deltaTime);
			}
			else
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)5, Time.deltaTime * (float)5);
			}
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, (float)1, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, (float)1, Time.deltaTime);
		}
		else
		{
			if (this.HomeYandere.transform.position.y > (float)-1)
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)0, Time.deltaTime);
			}
			else
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)0, Time.deltaTime * (float)5);
			}
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, (float)0, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, (float)0, Time.deltaTime);
		}
		if (this.ID > 0 && this.HomeYandere.CanMove)
		{
			float a = Mathf.MoveTowards(this.Button.color.a, (float)1, Time.deltaTime * (float)10);
			Color color = this.Button.color;
			float num2 = color.a = a;
			Color color2 = this.Button.color = color;
		}
		else
		{
			float a2 = Mathf.MoveTowards(this.Button.color.a, (float)0, Time.deltaTime * (float)10);
			Color color3 = this.Button.color;
			float num3 = color3.a = a2;
			Color color4 = this.Button.color = color3;
		}
		if (this.HomeDarkness.FadeOut)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, (float)0, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, (float)0, Time.deltaTime);
		}
		else if (this.HomeYandere.transform.position.y > (float)-1)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, (float)0, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, (float)1, Time.deltaTime);
		}
		else if (!this.Torturing)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, (float)1, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, (float)0, Time.deltaTime);
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
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale = (float)100;
		}
	}

	public virtual void PlayMusic()
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

	public virtual void Main()
	{
	}
}
