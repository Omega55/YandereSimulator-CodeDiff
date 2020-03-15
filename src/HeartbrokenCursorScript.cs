using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartbrokenCursorScript : MonoBehaviour
{
	public SnappedYandereScript SnappedYandere;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public HeartbrokenScript Heartbroken;

	public VibrateScript[] Vibrations;

	public UISprite CursorSprite;

	public UISprite Darkness;

	public AudioClip SelectSound;

	public AudioClip MoveSound;

	public AudioSource MyAudio;

	public UILabel Continue;

	public UILabel MyLabel;

	public GameObject FPS;

	public bool LoveSick;

	public bool FadeOut;

	public bool Nudge;

	public int CracksSpawned;

	public int Selected = 1;

	public int Options = 4;

	public int LastRandomCrack;

	public int RandomCrack;

	private void Start()
	{
		this.Darkness.transform.localPosition = new Vector3(this.Darkness.transform.localPosition.x, this.Darkness.transform.localPosition.y, -989f);
		this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, 0f);
		this.StudentManager.Yandere.Jukebox.gameObject.SetActive(false);
	}

	private void Update()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 255f - (float)this.Selected * 50f, Time.deltaTime * 10f), base.transform.localPosition.z);
		if (!this.FadeOut)
		{
			if (this.MyLabel.color.a >= 1f)
			{
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > this.Options)
					{
						this.Selected = 1;
					}
					this.MyAudio.clip = this.MoveSound;
					this.MyAudio.Play();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = this.Options;
					}
					this.MyAudio.clip = this.MoveSound;
					this.MyAudio.Play();
				}
				this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, (this.Selected == 4) ? 0f : 1f);
				if (Input.GetButtonDown("A"))
				{
					this.Nudge = true;
					if (this.Selected != 4)
					{
						this.MyAudio.clip = this.SelectSound;
						this.MyAudio.Play();
						this.FadeOut = true;
					}
				}
			}
		}
		else
		{
			this.Heartbroken.GetComponent<AudioSource>().volume -= Time.deltaTime;
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				if (this.Selected == 1)
				{
					for (int i = 0; i < this.StudentManager.NPCsTotal; i++)
					{
						if (StudentGlobals.GetStudentDying(i))
						{
							StudentGlobals.SetStudentDying(i, false);
						}
					}
					SceneManager.LoadScene("LoadingScene");
				}
				else if (this.Selected == 2)
				{
					this.LoveSick = GameGlobals.LoveSick;
					Globals.DeleteAll();
					GameGlobals.LoveSick = this.LoveSick;
					SceneManager.LoadScene("CalendarScene");
				}
				else if (this.Selected == 3)
				{
					SceneManager.LoadScene("TitleScene");
				}
			}
		}
		if (this.Nudge)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
			if (base.transform.localPosition.x > -225f)
			{
				base.transform.localPosition = new Vector3(-225f, base.transform.localPosition.y, base.transform.localPosition.z);
				this.Nudge = false;
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x - Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
			if (base.transform.localPosition.x < -250f)
			{
				base.transform.localPosition = new Vector3(-250f, base.transform.localPosition.y, base.transform.localPosition.z);
			}
		}
	}
}
