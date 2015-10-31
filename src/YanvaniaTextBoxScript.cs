using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class YanvaniaTextBoxScript : MonoBehaviour
{
	private TypewriterEffect NewTypewriter;

	private UILabel NewLabelScript;

	private GameObject NewLabel;

	public YanvaniaJukeboxScript Jukebox;

	public YanvaniaDraculaScript Dracula;

	public YanvaniaYanmontScript Yanmont;

	public Transform NewLabelSpawnPoint;

	public GameObject Glass;

	public GameObject Label;

	public UILabel SpeakerLabel;

	public UITexture BloodWipe;

	public UITexture Portrait;

	public UITexture Border;

	public UITexture BG;

	public bool UpdatePortrait;

	public bool Display;

	public bool Leave;

	public bool Grow;

	public string[] SpeakerNames;

	public Texture[] Portraits;

	public AudioClip[] Voices;

	public string[] Lines;

	public int PortraitID;

	public int LineID;

	public float NewLineTimer;

	public float AnimTimer;

	public float Timer;

	public YanvaniaTextBoxScript()
	{
		this.PortraitID = 1;
	}

	public virtual void Start()
	{
		Application.targetFrameRate = 60;
		this.Portrait.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		int num = 0;
		Vector3 localScale = this.BloodWipe.transform.localScale;
		float num2 = localScale.x = (float)num;
		Vector3 vector = this.BloodWipe.transform.localScale = localScale;
		this.SpeakerLabel.text = string.Empty;
		int num3 = 0;
		Color color = this.Border.color;
		float num4 = color.a = (float)num3;
		Color color2 = this.Border.color = color;
		int num5 = 0;
		Color color3 = this.BG.color;
		float num6 = color3.a = (float)num5;
		Color color4 = this.BG.color = color3;
		this.active = false;
	}

	public virtual void Update()
	{
		if (!this.Leave)
		{
			if (this.BloodWipe.transform.localScale.x == (float)0)
			{
				float x = this.BloodWipe.transform.localScale.x + Time.deltaTime;
				Vector3 localScale = this.BloodWipe.transform.localScale;
				float num = localScale.x = x;
				Vector3 vector = this.BloodWipe.transform.localScale = localScale;
			}
			if (this.BloodWipe.transform.localScale.x > (float)50)
			{
				float a = this.BloodWipe.color.a - Time.deltaTime;
				Color color = this.BloodWipe.color;
				float num2 = color.a = a;
				Color color2 = this.BloodWipe.color = color;
				float a2 = this.Border.color.a + Time.deltaTime;
				Color color3 = this.Border.color;
				float num3 = color3.a = a2;
				Color color4 = this.Border.color = color3;
				float a3 = 0.5f;
				Color color5 = this.BG.color;
				float num4 = color5.a = a3;
				Color color6 = this.BG.color = color5;
			}
			else
			{
				float x2 = this.BloodWipe.transform.localScale.x + this.BloodWipe.transform.localScale.x * 0.1f;
				Vector3 localScale2 = this.BloodWipe.transform.localScale;
				float num5 = localScale2.x = x2;
				Vector3 vector2 = this.BloodWipe.transform.localScale = localScale2;
			}
			if (this.BloodWipe.color.a <= (float)0)
			{
				if (!this.Display)
				{
					if (this.LineID < Extensions.get_length(this.Lines) - 1)
					{
						if (this.NewLabel != null)
						{
							UnityEngine.Object.Destroy(this.NewLabel);
						}
						this.UpdatePortrait = true;
						this.Display = true;
						if (this.PortraitID == 1)
						{
							this.SpeakerLabel.text = string.Empty;
							this.PortraitID = 2;
						}
						else
						{
							this.SpeakerLabel.text = string.Empty;
							this.PortraitID = 1;
						}
					}
				}
				else if (this.NewLabelScript != null)
				{
					if (!this.NewLabelScript.enabled)
					{
						this.NewLabelScript.enabled = true;
						this.audio.clip = this.Voices[this.LineID];
						this.NewLineTimer = (float)0;
						this.audio.Play();
					}
					else
					{
						this.NewLineTimer += Time.deltaTime;
						if (this.NewLineTimer > this.audio.clip.length + 0.5f || Input.GetButtonDown("A"))
						{
							this.Display = false;
						}
					}
				}
			}
			if (this.UpdatePortrait)
			{
				if (!this.Grow)
				{
					this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
					if (this.Portrait.transform.localScale.x == (float)0)
					{
						this.Portrait.mainTexture = this.Portraits[this.PortraitID];
						this.Grow = true;
					}
				}
				else
				{
					this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
					if (this.Portrait.transform.localScale.x == (float)1)
					{
						this.SpeakerLabel.text = this.SpeakerNames[this.PortraitID];
						this.UpdatePortrait = false;
						this.AnimTimer = (float)0;
						this.Grow = false;
						this.LineID++;
						this.SpawnLabel();
					}
				}
			}
			this.AnimTimer += Time.deltaTime;
			if (this.LineID == 2)
			{
				this.NewTypewriter.charsPerSecond = 15;
				this.NewTypewriter.delayOnPeriod = 1.5f;
				if (this.AnimTimer < 0.5f)
				{
					this.NewTypewriter.delayOnComma = true;
				}
			}
			if (this.LineID == 3)
			{
				this.NewTypewriter.delayOnComma = true;
				this.NewTypewriter.delayOnPeriod = 0.75f;
				if (this.AnimTimer < (float)1)
				{
					this.Yanmont.Character.animation.CrossFade("f02_yanvaniaCutsceneAction1_00");
				}
				if (this.Yanmont.Character.animation["f02_yanvaniaCutsceneAction1_00"].time >= this.Yanmont.Character.animation["f02_yanvaniaCutsceneAction1_00"].length)
				{
					this.Yanmont.Character.animation.CrossFade("f02_yanvaniaDramaticIdle_00");
				}
			}
			if (this.LineID == 5)
			{
				this.NewTypewriter.charsPerSecond = 15;
				this.Yanmont.Character.animation.CrossFade("f02_yanvaniaCutsceneAction2_00");
				if (this.Yanmont.Character.animation["f02_yanvaniaCutsceneAction2_00"].time >= this.Yanmont.Character.animation["f02_yanvaniaCutsceneAction2_00"].length)
				{
					this.Yanmont.Character.animation.CrossFade("f02_yanvaniaDramaticIdle_00");
				}
				if (this.AnimTimer > (float)4)
				{
					this.Dracula.Character.animation.CrossFade("DraculaDrink");
				}
				if (this.AnimTimer > 4.5f)
				{
					this.Glass.renderer.materials[0].color = new Color((float)1, (float)1, (float)1, 0.5f);
				}
				if (this.AnimTimer > (float)5 && this.Dracula.Character.animation["DraculaDrink"].time >= this.Dracula.Character.animation["DraculaDrink"].length)
				{
					this.Dracula.Character.animation.CrossFade("DraculaIdle");
				}
			}
			if (this.LineID == 6)
			{
				this.Yanmont.Character.animation.CrossFade("f02_yanvaniaDramaticIdle_00");
				if (this.AnimTimer < (float)1)
				{
					this.NewTypewriter.delayOnPeriod = 2.25f;
				}
				if (this.AnimTimer > (float)1 && this.AnimTimer < (float)2)
				{
					this.Dracula.Character.animation.CrossFade("DraculaToss");
				}
				if (this.Glass != null && this.AnimTimer > 1.4f && !this.Glass.rigidbody.useGravity)
				{
					this.Glass.rigidbody.useGravity = true;
					this.Glass.transform.parent = null;
					this.Glass.rigidbody.AddForce((float)-100, (float)100, (float)-200);
				}
				if (this.AnimTimer > (float)2 + this.Dracula.Character.animation["DraculaToss"].length && this.AnimTimer < (float)6)
				{
					this.Dracula.Character.animation.CrossFade("DraculaIdle");
				}
				if (this.AnimTimer > (float)4)
				{
					this.NewTypewriter.delayOnPeriod = (float)1;
					this.NewTypewriter.charsPerSecond = 15;
				}
				if (this.AnimTimer > (float)6 && this.AnimTimer < 9.5f)
				{
					this.Dracula.transform.position = Vector3.Lerp(this.Dracula.transform.position, new Vector3(-34.675f, 7.5f, 2.8f), Time.deltaTime * (float)10);
					this.Dracula.Character.animation.CrossFade("succubus_a_idle_01");
				}
				if (this.AnimTimer > 9.5f)
				{
					this.NewLabelScript.text = string.Empty;
					this.SpeakerLabel.text = string.Empty;
					this.Dracula.SpawnTeleportEffect();
					this.Dracula.enabled = true;
					this.Jukebox.BossBattle();
					this.Leave = true;
				}
			}
			if (Input.GetKeyDown("3"))
			{
				if (this.NewLabel != null)
				{
					UnityEngine.Object.Destroy(this.NewLabel);
				}
				if (this.NewLabelScript != null)
				{
					this.NewLabelScript.text = string.Empty;
				}
				this.SpeakerLabel.text = string.Empty;
				this.Dracula.SpawnTeleportEffect();
				this.Dracula.enabled = true;
				this.Jukebox.BossBattle();
				UnityEngine.Object.Destroy(this.BloodWipe);
				UnityEngine.Object.Destroy(this.Glass);
				this.Leave = true;
			}
		}
		else
		{
			this.Portrait.transform.localScale = Vector3.MoveTowards(this.Portrait.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			if (this.Portrait.transform.localScale.x == (float)0)
			{
				float y = this.Border.transform.position.y + Time.deltaTime;
				Vector3 position = this.Border.transform.position;
				float num6 = position.y = y;
				Vector3 vector3 = this.Border.transform.position = position;
				float y2 = this.BG.transform.position.y + Time.deltaTime;
				Vector3 position2 = this.BG.transform.position;
				float num7 = position2.y = y2;
				Vector3 vector4 = this.BG.transform.position = position2;
				if (!this.Yanmont.enabled)
				{
					this.Yanmont.EnterCutscene = false;
					this.Yanmont.Cutscene = false;
					this.Yanmont.enabled = true;
				}
			}
		}
	}

	public virtual void SpawnLabel()
	{
		this.NewLabel = (GameObject)UnityEngine.Object.Instantiate(this.Label, this.transform.position, Quaternion.identity);
		this.NewLabel.transform.parent = this.NewLabelSpawnPoint;
		this.NewLabel.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.NewLabel.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
		this.NewLabel.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		this.NewTypewriter = (TypewriterEffect)this.NewLabel.GetComponent(typeof(TypewriterEffect));
		this.NewLabelScript = (UILabel)this.NewLabel.GetComponent(typeof(UILabel));
		this.NewLabelScript.text = this.Lines[this.LineID];
		this.NewLabelScript.enabled = false;
	}

	public virtual void Main()
	{
	}
}
