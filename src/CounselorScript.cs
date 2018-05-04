using System;
using UnityEngine;

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

	public readonly string CounselorFarewellText = "Don't misbehave.";

	public AudioClip CounselorBusyClip;

	public readonly string CounselorBusyText = "I'm sorry, I've got my hands full for the rest of today. I won't be available until tomorrow.";

	public readonly string[] CounselorGreetingText = new string[]
	{
		string.Empty,
		"What can I help you with?",
		"Can I help you?"
	};

	public readonly string[] CounselorLectureText = new string[]
	{
		string.Empty,
		"Your \"after-school activities\" are completely unacceptable. You should not be conducting yourself in such a manner. This kind of behavior could cause a scandal! You could run the school's reputation into the ground!",
		"May I take a look inside your bag? ...this doesn't belong to you, does it?! What are you doing with someone else's property?",
		"I need to take a look in your bag. ...cigarettes?! You have absolutely no excuse to be carrying something like this around!",
		"May I see your phone for a moment? ...what is THIS?! Would you care to explain why something like this is on your phone?",
		"Obviously, we need to have a long talk about the kind of behavior that will not tolerated at this school!",
		"That's it! I've given you enough second chances. You have repeatedly broken school rules and ignored every warning that I have given you. You have left me with no choice but to permanently expel you!"
	};

	public readonly string[] CounselorReportText = new string[]
	{
		string.Empty,
		"This is...! Thank you for bringing this to my attention. This kind of conduct will definitely harm the school's reputation. I'll have to have a word with her later today.",
		"Is that true? I'd hate to think we have a thief here at school. Don't worry - I'll get to the bottom of this.",
		"That's a clear violation of school rules, not to mention completely illegal. If what you're saying is true, she will face serious consequences. I'll confront her about this.",
		"That's a very serious accusation. I hope you're not lying to me. Hopefully, it's just a misunderstanding. I'll investigate the matter.",
		"That's a bold claim. Are you certain? I'll investigate the matter. If she is cheating, I'll catch her in the act."
	};

	public readonly string[] LectureIntro = new string[]
	{
		string.Empty,
		"The guidance counselor asks Kokona to visit her office after school ends...",
		"The guidance counselor asks Kokona to visit her office after school ends...",
		"The guidance counselor asks Kokona to visit her office after school ends...",
		"The guidance counselor asks Kokona to visit her office after school ends...",
		"The guidance counselor asks Kokona to visit her office after school ends..."
	};

	public readonly string[] RivalText = new string[]
	{
		string.Empty,
		"It...it's not what you think...I was just...um...",
		"No! I'm not the one who did this! I would never steal from anyone!",
		"Huh? I don't smoke! I don't know why something like this was in my bag!",
		"What?! I've never taken any pictures like that! How did this get on my phone?!",
		"I'm telling the truth! I didn't steal the answer sheet! I don't know why it was in my desk!",
		"No! Please! Don't do this!"
	};

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

	public int Selected = 1;

	public int LecturePhase = 1;

	public int LectureID = 5;

	public float Anger;

	public float ExpelTimer;

	public float ChinTimer;

	public float Timer;

	public Vector3 LookAtTarget;

	public bool LookAtPlayer;

	public Transform Default;

	public Transform Head;

	private void Start()
	{
		this.CounselorWindow.localScale = Vector3.zero;
		this.CounselorWindow.gameObject.SetActive(false);
		this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, 0f);
	}

	private void Update()
	{
		if (this.Yandere.transform.position.x < base.transform.position.x)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
		}
		Animation component = base.GetComponent<Animation>();
		AudioSource component2 = base.GetComponent<AudioSource>();
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased)
			{
				if (!this.Busy)
				{
					component.CrossFade("CounselorComputerAttention", 1f);
					this.ChinTimer = 0f;
					this.Yandere.TargetStudent = this.Student;
					int num = UnityEngine.Random.Range(1, 3);
					this.CounselorSubtitle.text = this.CounselorGreetingText[num];
					component2.clip = this.CounselorGreetingClips[num];
					component2.Play();
					this.StudentManager.DisablePrompts();
					this.CounselorWindow.gameObject.SetActive(true);
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
				else
				{
					this.CounselorSubtitle.text = this.CounselorBusyText;
					component2.clip = this.CounselorBusyClip;
					component2.Play();
				}
			}
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
						component.CrossFade("CounselorComputerLoop", 1f);
						this.Yandere.ShoulderCamera.OverShoulder = false;
						this.StudentManager.EnablePrompts();
						this.Yandere.TargetStudent = null;
						this.LookAtPlayer = false;
						this.ShowWindow = false;
						this.CounselorSubtitle.text = this.CounselorFarewellText;
						component2.clip = this.CounselorFarewellClip;
						component2.Play();
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
					}
					else if (this.Labels[this.Selected].color.a == 1f)
					{
						if (this.Selected == 1)
						{
							SchemeGlobals.SetSchemeStage(1, 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 2)
						{
							SchemeGlobals.SetSchemeStage(2, 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 3)
						{
							SchemeGlobals.SetSchemeStage(3, 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 4)
						{
							SchemeGlobals.SetSchemeStage(4, 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 5)
						{
							SchemeGlobals.SetSchemeStage(5, 7);
							this.Schemes.UpdateInstructions();
						}
						this.CounselorSubtitle.text = this.CounselorReportText[this.Selected];
						component2.clip = this.CounselorReportClips[this.Selected];
						component2.Play();
						this.ShowWindow = false;
						this.Angry = true;
						this.LectureID = this.Selected;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Busy = true;
					}
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					component2.Stop();
				}
				if (!component2.isPlaying)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 0.5f)
					{
						component.CrossFade("CounselorComputerLoop", 1f);
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
		else
		{
			this.ChinTimer += Time.deltaTime;
			if (this.ChinTimer > 10f)
			{
				component.CrossFade("CounselorComputerChin");
				if (component["CounselorComputerChin"].time > component["CounselorComputerChin"].length)
				{
					component.CrossFade("CounselorComputerLoop");
					this.ChinTimer = 0f;
				}
			}
		}
		if (this.ShowWindow)
		{
			this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else if (this.CounselorWindow.localScale.x > 0.1f)
		{
			this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else
		{
			this.CounselorWindow.localScale = Vector3.zero;
			this.CounselorWindow.gameObject.SetActive(false);
		}
		if (this.Lecturing)
		{
			this.Chibi.localPosition = new Vector3(this.Chibi.localPosition.x, Mathf.Lerp(this.Chibi.localPosition.y, 250f + (float)StudentGlobals.ExpelProgress * -100f, Time.deltaTime * 2f), this.Chibi.localPosition.z);
			if (this.LecturePhase == 1)
			{
				this.LectureLabel.text = this.LectureIntro[this.LectureID];
				this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0f, Time.deltaTime));
				if (this.EndOfDayDarkness.color.a == 0f)
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
				this.LectureLabel.color = new Color(this.LectureLabel.color.r, this.LectureLabel.color.g, this.LectureLabel.color.b, Mathf.MoveTowards(this.LectureLabel.color.a, 0f, Time.deltaTime));
				if (this.LectureLabel.color.a == 0f)
				{
					this.LectureSubtitle.text = this.CounselorLectureText[this.LectureID];
					component2.clip = this.CounselorLectureClips[this.LectureID];
					component2.Play();
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 3)
			{
				if (!component2.isPlaying || Input.GetButtonDown("A"))
				{
					this.LectureSubtitle.text = this.RivalText[this.LectureID];
					component2.clip = this.RivalClips[this.LectureID];
					component2.Play();
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 4)
			{
				if (!component2.isPlaying || Input.GetButtonDown("A"))
				{
					this.LectureSubtitle.text = string.Empty;
					if (StudentGlobals.ExpelProgress < 5)
					{
						this.LecturePhase++;
					}
					else
					{
						this.LecturePhase = 7;
						this.ExpelTimer = 11f;
					}
				}
			}
			else if (this.LecturePhase == 5)
			{
				this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, Mathf.MoveTowards(this.ExpelProgress.color.a, 1f, Time.deltaTime));
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > 2f)
				{
					StudentGlobals.ExpelProgress++;
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 6)
			{
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > 4f)
				{
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 7)
			{
				this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, Mathf.MoveTowards(this.ExpelProgress.color.a, 0f, Time.deltaTime));
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > 6f)
				{
					if (StudentGlobals.ExpelProgress == 5 && !StudentGlobals.GetStudentExpelled(7))
					{
						StudentGlobals.SetStudentExpelled(7, true);
						this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 0f);
						this.LectureLabel.color = new Color(this.LectureLabel.color.r, this.LectureLabel.color.g, this.LectureLabel.color.b, 0f);
						this.LecturePhase = 2;
						this.ExpelTimer = 0f;
						this.LectureID = 6;
					}
					else if (this.LectureID < 6)
					{
						this.EndOfDay.enabled = true;
						this.EndOfDay.Phase++;
						this.EndOfDay.UpdateScene();
						base.enabled = false;
					}
					else
					{
						this.EndOfDay.gameObject.SetActive(false);
						this.EndOfDay.Phase = 1;
						this.CutsceneManager.Phase++;
						this.Lecturing = false;
						this.LectureID = 0;
					}
				}
			}
		}
		if (!component2.isPlaying)
		{
			this.CounselorSubtitle.text = string.Empty;
		}
	}

	private void UpdateList()
	{
		for (int i = 1; i < this.Labels.Length; i++)
		{
			UILabel uilabel = this.Labels[i];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
		if (this.StudentManager.Students[7] != null)
		{
			if (SchemeGlobals.GetSchemeStage(1) == 2)
			{
				UILabel uilabel2 = this.Labels[1];
				uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(2) == 3)
			{
				UILabel uilabel3 = this.Labels[2];
				uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(3) == 4)
			{
				UILabel uilabel4 = this.Labels[3];
				uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(4) == 5)
			{
				UILabel uilabel5 = this.Labels[4];
				uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 1f);
			}
			if (SchemeGlobals.GetSchemeStage(5) == 6)
			{
				UILabel uilabel6 = this.Labels[5];
				uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 1f);
			}
		}
	}

	private void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 7;
		}
		else if (this.Selected > 7)
		{
			this.Selected = 1;
		}
		this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 200f - 50f * (float)this.Selected, this.Highlight.transform.localPosition.z);
	}

	private void LateUpdate()
	{
		if (this.Angry)
		{
			this.Anger = Mathf.Lerp(this.Anger, 100f, Time.deltaTime);
			this.Face.SetBlendShapeWeight(1, this.Anger);
			this.Face.SetBlendShapeWeight(5, this.Anger);
			this.Face.SetBlendShapeWeight(9, this.Anger);
		}
		else
		{
			this.Anger = Mathf.Lerp(this.Anger, 0f, Time.deltaTime);
			this.Face.SetBlendShapeWeight(1, this.Anger);
			this.Face.SetBlendShapeWeight(5, this.Anger);
			this.Face.SetBlendShapeWeight(9, this.Anger);
		}
		this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, (!this.LookAtPlayer) ? this.Default.position : this.Yandere.Head.position, Time.deltaTime * 2f);
		this.Head.LookAt(this.LookAtTarget);
	}
}
