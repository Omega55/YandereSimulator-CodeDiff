using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CounselorScript : MonoBehaviour
{
	public CutsceneManagerScript CutsceneManager;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public EndOfDayScript EndOfDay;

	public SubtitleScript Subtitle;

	public SchemesScript Schemes;

	public StudentScript Student;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public AudioClip[] CounselorGreetingClips;

	public AudioClip[] CounselorLectureClips;

	public AudioClip[] CounselorReportClips;

	public AudioClip[] RivalClips;

	public AudioClip CounselorFarewellClip;

	public string CounselorFarewellText;

	public string[] CounselorGreetingText;

	public string[] CounselorLectureText;

	public string[] CounselorReportText;

	public string[] LectureIntro;

	public string[] RivalText;

	public UILabel[] Labels;

	public Transform CounselorWindow;

	public Transform Highlight;

	public Transform Chibi;

	public SkinnedMeshRenderer Face;

	public UILabel CounselorSubtitle;

	public UISprite EndOfDayDarkness;

	public UILabel LectureSubtitle;

	public UISprite ExpelProgress;

	public UILabel LectureLabel;

	public bool ShowWindow;

	public bool Lecturing;

	public bool Angry;

	public bool Busy;

	public int Selected;

	public int LecturePhase;

	public int LectureID;

	public float Anger;

	public float ExpelTimer;

	public float Timer;

	public Vector3 LookAtTarget;

	public bool LookAtPlayer;

	public Transform Default;

	public Transform Head;

	public CounselorScript()
	{
		this.Selected = 1;
		this.LecturePhase = 1;
		this.LectureID = 5;
	}

	public virtual void Start()
	{
		this.CounselorWindow.localScale = new Vector3((float)0, (float)0, (float)0);
		int num = 0;
		Color color = this.ExpelProgress.color;
		float num2 = color.a = (float)num;
		Color color2 = this.ExpelProgress.color = color;
	}

	public virtual void Update()
	{
		if (this.Yandere.transform.position.x < this.transform.position.x)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else if (!this.Busy)
		{
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.TargetStudent = this.Student;
			int num = UnityEngine.Random.Range(1, 3);
			this.CounselorSubtitle.text = this.CounselorGreetingText[num];
			this.audio.clip = this.CounselorGreetingClips[num];
			this.audio.Play();
			this.StudentManager.DisablePrompts();
			this.LookAtPlayer = true;
			this.ShowWindow = true;
			this.Yandere.ShoulderCamera.OverShoulder = true;
			this.Yandere.WeaponMenu.KeyboardShow = false;
			this.Yandere.Obscurance.enabled = false;
			this.Yandere.WeaponMenu.Show = false;
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = true;
			this.UpdateList();
		}
		if (this.LookAtPlayer)
		{
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected == 6)
				{
					this.Selected = 5;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected == 6)
				{
					this.Selected = 7;
				}
				this.UpdateHighlight();
			}
			if (this.ShowWindow)
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 7)
					{
						this.Yandere.ShoulderCamera.OverShoulder = false;
						this.StudentManager.EnablePrompts();
						this.Yandere.TargetStudent = null;
						this.LookAtPlayer = false;
						this.ShowWindow = false;
						this.CounselorSubtitle.text = this.CounselorFarewellText;
						this.audio.clip = this.CounselorFarewellClip;
						this.audio.Play();
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
					}
					else if (this.Labels[this.Selected].color.a == (float)1)
					{
						if (this.Selected == 1)
						{
							PlayerPrefs.SetInt("Scheme_1_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 2)
						{
							PlayerPrefs.SetInt("Scheme_2_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 3)
						{
							PlayerPrefs.SetInt("Scheme_3_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 4)
						{
							PlayerPrefs.SetInt("Scheme_4_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 5)
						{
							PlayerPrefs.SetInt("Scheme_5_Stage", 7);
							this.Schemes.UpdateInstructions();
						}
						this.CounselorSubtitle.text = this.CounselorReportText[this.Selected];
						this.audio.clip = this.CounselorReportClips[this.Selected];
						this.audio.Play();
						this.ShowWindow = false;
						this.Angry = true;
						this.LectureID = this.Selected;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.Busy = true;
					}
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					this.audio.Stop();
				}
				if (!this.audio.isPlaying)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 0.5f)
					{
						this.Yandere.ShoulderCamera.OverShoulder = false;
						this.StudentManager.EnablePrompts();
						this.Yandere.TargetStudent = null;
						this.LookAtPlayer = false;
						this.Angry = false;
						this.UpdateList();
					}
				}
			}
		}
		if (this.ShowWindow)
		{
			this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else
		{
			this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		if (this.Lecturing)
		{
			float y = Mathf.Lerp(this.Chibi.localPosition.y, (float)(250 + PlayerPrefs.GetInt("ExpelProgress") * -100), Time.deltaTime * (float)2);
			Vector3 localPosition = this.Chibi.localPosition;
			float num2 = localPosition.y = y;
			Vector3 vector = this.Chibi.localPosition = localPosition;
			if (this.LecturePhase == 1)
			{
				this.LectureLabel.text = this.LectureIntro[this.LectureID];
				float a = Mathf.MoveTowards(this.EndOfDayDarkness.color.a, (float)0, Time.deltaTime);
				Color color = this.EndOfDayDarkness.color;
				float num3 = color.a = a;
				Color color2 = this.EndOfDayDarkness.color = color;
				if (this.EndOfDayDarkness.color.a == (float)0)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Continue";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					if (Input.GetButtonDown("A"))
					{
						this.LecturePhase++;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
					}
				}
			}
			else if (this.LecturePhase == 2)
			{
				float a2 = Mathf.MoveTowards(this.LectureLabel.color.a, (float)0, Time.deltaTime);
				Color color3 = this.LectureLabel.color;
				float num4 = color3.a = a2;
				Color color4 = this.LectureLabel.color = color3;
				if (this.LectureLabel.color.a == (float)0)
				{
					this.LectureSubtitle.text = this.CounselorLectureText[this.LectureID];
					this.audio.clip = this.CounselorLectureClips[this.LectureID];
					this.audio.Play();
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 3)
			{
				if (!this.audio.isPlaying || Input.GetButtonDown("A"))
				{
					this.LectureSubtitle.text = this.RivalText[this.LectureID];
					this.audio.clip = this.RivalClips[this.LectureID];
					this.audio.Play();
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 4)
			{
				if (!this.audio.isPlaying || Input.GetButtonDown("A"))
				{
					this.LectureSubtitle.text = string.Empty;
					if (PlayerPrefs.GetInt("ExpelProgress") < 5)
					{
						this.LecturePhase++;
					}
					else
					{
						this.LecturePhase = 7;
						this.ExpelTimer = (float)11;
					}
				}
			}
			else if (this.LecturePhase == 5)
			{
				float a3 = Mathf.MoveTowards(this.ExpelProgress.color.a, (float)1, Time.deltaTime);
				Color color5 = this.ExpelProgress.color;
				float num5 = color5.a = a3;
				Color color6 = this.ExpelProgress.color = color5;
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > (float)2)
				{
					PlayerPrefs.SetInt("ExpelProgress", PlayerPrefs.GetInt("ExpelProgress") + 1);
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 6)
			{
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > (float)4)
				{
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 7)
			{
				float a4 = Mathf.MoveTowards(this.ExpelProgress.color.a, (float)0, Time.deltaTime);
				Color color7 = this.ExpelProgress.color;
				float num6 = color7.a = a4;
				Color color8 = this.ExpelProgress.color = color7;
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > (float)6)
				{
					if (PlayerPrefs.GetInt("ExpelProgress") == 5 && PlayerPrefs.GetInt("Student_7_Expelled") == 0)
					{
						PlayerPrefs.SetInt("Student_7_Expelled", 1);
						int num7 = 0;
						Color color9 = this.EndOfDayDarkness.color;
						float num8 = color9.a = (float)num7;
						Color color10 = this.EndOfDayDarkness.color = color9;
						int num9 = 0;
						Color color11 = this.LectureLabel.color;
						float num10 = color11.a = (float)num9;
						Color color12 = this.LectureLabel.color = color11;
						this.LecturePhase = 2;
						this.ExpelTimer = (float)0;
						this.LectureID = 6;
					}
					else if (this.LectureID < 6)
					{
						this.EndOfDay.enabled = true;
						this.EndOfDay.Phase = this.EndOfDay.Phase + 1;
						this.EndOfDay.UpdateScene();
					}
					else
					{
						this.EndOfDay.active = false;
						this.EndOfDay.Phase = 1;
						this.CutsceneManager.Phase = this.CutsceneManager.Phase + 1;
						this.Lecturing = false;
						this.LectureID = 0;
					}
				}
			}
		}
		if (!this.audio.isPlaying)
		{
			this.CounselorSubtitle.text = string.Empty;
		}
	}

	public virtual void UpdateList()
	{
		for (int i = 1; i < Extensions.get_length(this.Labels); i++)
		{
			float a = 0.5f;
			Color color = this.Labels[i].color;
			float num = color.a = a;
			Color color2 = this.Labels[i].color = color;
		}
		if (PlayerPrefs.GetInt("Scheme_1_Stage") == 2)
		{
			int num2 = 1;
			Color color3 = this.Labels[1].color;
			float num3 = color3.a = (float)num2;
			Color color4 = this.Labels[1].color = color3;
		}
		if (PlayerPrefs.GetInt("Scheme_2_Stage") == 3)
		{
			int num4 = 1;
			Color color5 = this.Labels[2].color;
			float num5 = color5.a = (float)num4;
			Color color6 = this.Labels[2].color = color5;
		}
		if (PlayerPrefs.GetInt("Scheme_3_Stage") == 4)
		{
			int num6 = 1;
			Color color7 = this.Labels[3].color;
			float num7 = color7.a = (float)num6;
			Color color8 = this.Labels[3].color = color7;
		}
		if (PlayerPrefs.GetInt("Scheme_4_Stage") == 5)
		{
			int num8 = 1;
			Color color9 = this.Labels[4].color;
			float num9 = color9.a = (float)num8;
			Color color10 = this.Labels[4].color = color9;
		}
		if (PlayerPrefs.GetInt("Scheme_5_Stage") == 6)
		{
			int num10 = 1;
			Color color11 = this.Labels[5].color;
			float num11 = color11.a = (float)num10;
			Color color12 = this.Labels[5].color = color11;
		}
	}

	public virtual void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 7;
		}
		else if (this.Selected > 7)
		{
			this.Selected = 1;
		}
		int num = 200 - 50 * this.Selected;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	public virtual void LateUpdate()
	{
		if (this.Angry)
		{
			this.Anger = Mathf.Lerp(this.Anger, (float)100, Time.deltaTime);
			this.Face.SetBlendShapeWeight(1, this.Anger);
			this.Face.SetBlendShapeWeight(5, this.Anger);
			this.Face.SetBlendShapeWeight(9, this.Anger);
		}
		else
		{
			this.Anger = Mathf.Lerp(this.Anger, (float)0, Time.deltaTime);
			this.Face.SetBlendShapeWeight(1, this.Anger);
			this.Face.SetBlendShapeWeight(5, this.Anger);
			this.Face.SetBlendShapeWeight(9, this.Anger);
		}
		if (!this.LookAtPlayer)
		{
			this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.Default.position, Time.deltaTime * (float)2);
		}
		else
		{
			this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.Yandere.Head.position, Time.deltaTime * (float)2);
		}
		this.Head.LookAt(this.LookAtTarget);
	}

	public virtual void Main()
	{
	}
}
