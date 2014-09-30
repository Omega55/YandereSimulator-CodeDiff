using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TitleScreenScript : MonoBehaviour
{
	public NoiseAndGrain NoiseAndGrainScript;

	public SSAOEffect SSAOEffectScript;

	public Vignetting VignettingScript;

	public UITexture SimulatorGraphic;

	public UITexture YandereGraphic;

	public AudioSource Jukebox;

	public Transform CharacterCamera;

	public Transform BloodEffects;

	public Transform RightBorder;

	public Transform LeftBorder;

	public Transform Buttons;

	public Transform English;

	public Transform Logo;

	public GameObject CuteYandereChan;

	public GameObject EvilYandereChan;

	public GameObject BlackBG;

	public GameObject Emitter;

	public GameObject Senpai;

	public UITexture[] LetterBGs;

	public UISprite[] ButtonBGs;

	public UILabel[] Letters;

	public UISprite White;

	public bool Evil;

	public float AudioStartTime;

	public float Timer;

	public Texture CuteSimulator;

	public Texture EvilSimulator;

	public Texture CuteYandere;

	public Texture EvilYandere;

	public virtual void Start()
	{
		this.EvilYandereChan.active = false;
		this.Senpai.active = false;
		this.Buttons.localScale = new Vector3((float)0, (float)0, (float)0);
		this.English.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Logo.localScale = new Vector3((float)0, (float)0, (float)0);
		float x = 2.75f;
		Vector3 position = this.CharacterCamera.position;
		float num = position.x = x;
		Vector3 vector = this.CharacterCamera.position = position;
		int num2 = 0;
		Vector3 localScale = this.RightBorder.localScale;
		float num3 = localScale.x = (float)num2;
		Vector3 vector2 = this.RightBorder.localScale = localScale;
		int num4 = 0;
		Vector3 localScale2 = this.LeftBorder.localScale;
		float num5 = localScale2.x = (float)num4;
		Vector3 vector3 = this.LeftBorder.localScale = localScale2;
		int num6 = 1;
		Color color = this.White.color;
		float num7 = color.a = (float)num6;
		Color color2 = this.White.color = color;
	}

	public virtual void Update()
	{
		if (this.Jukebox.audio.pitch < (float)1)
		{
			this.Jukebox.audio.pitch = this.Jukebox.audio.pitch + Time.deltaTime;
			if (this.Jukebox.audio.pitch > (float)1)
			{
				this.Jukebox.audio.pitch = (float)1;
			}
		}
		this.Timer += Time.deltaTime;
		float a = this.White.color.a - Time.deltaTime;
		Color color = this.White.color;
		float num = color.a = a;
		Color color2 = this.White.color = color;
		if (this.White.color.a <= (float)0)
		{
			float x = Mathf.Lerp(this.CharacterCamera.position.x, (float)0, Time.deltaTime * (float)10);
			Vector3 position = this.CharacterCamera.position;
			float num2 = position.x = x;
			Vector3 vector = this.CharacterCamera.position = position;
		}
		if (this.Timer > (float)2)
		{
			float x2 = Mathf.Lerp(this.RightBorder.localScale.x, 2.41f, Time.deltaTime * (float)10);
			Vector3 localScale = this.RightBorder.localScale;
			float num3 = localScale.x = x2;
			Vector3 vector2 = this.RightBorder.localScale = localScale;
			float x3 = Mathf.Lerp(this.LeftBorder.localScale.x, 2.41f, Time.deltaTime * (float)10);
			Vector3 localScale2 = this.LeftBorder.localScale;
			float num4 = localScale2.x = x3;
			Vector3 vector3 = this.LeftBorder.localScale = localScale2;
		}
		if (this.Timer > (float)3)
		{
			this.Logo.localScale = Vector3.Lerp(this.Logo.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		if (this.Timer > (float)4)
		{
			this.English.localScale = Vector3.Lerp(this.English.localScale, new Vector3(2.41f, 2.41f, 2.41f), Time.deltaTime * (float)10);
		}
		if (this.Timer > (float)5)
		{
			this.Buttons.localScale = Vector3.Lerp(this.Buttons.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		if (Input.GetMouseButtonDown(0))
		{
			this.English.localScale = new Vector3(2.41f, 2.41f, 2.41f);
			this.Buttons.localScale = new Vector3((float)1, (float)1, (float)1);
			this.Logo.localScale = new Vector3((float)1, (float)1, (float)1);
			float x4 = 2.41f;
			Vector3 localScale3 = this.RightBorder.localScale;
			float num5 = localScale3.x = x4;
			Vector3 vector4 = this.RightBorder.localScale = localScale3;
			float x5 = 2.41f;
			Vector3 localScale4 = this.LeftBorder.localScale;
			float num6 = localScale4.x = x5;
			Vector3 vector5 = this.LeftBorder.localScale = localScale4;
			int num7 = 0;
			Vector3 position2 = this.CharacterCamera.position;
			float num8 = position2.x = (float)num7;
			Vector3 vector6 = this.CharacterCamera.position = position2;
			int num9 = 0;
			Color color3 = this.White.color;
			float num10 = color3.a = (float)num9;
			Color color4 = this.White.color = color3;
			this.Timer = (float)6;
		}
		if (Input.GetKeyDown("space"))
		{
			this.Timer = (float)10;
		}
		if (this.Timer > (float)10)
		{
			this.ChangeGraphics();
		}
	}

	public virtual void ChangeGraphics()
	{
		if (!this.Evil)
		{
			this.Evil = true;
			this.Timer = (float)9;
			this.YandereGraphic.mainTexture = this.EvilYandere;
			this.SimulatorGraphic.mainTexture = this.EvilSimulator;
			this.CuteYandereChan.active = false;
			this.EvilYandereChan.active = true;
			((TitleEvilYandereScript)this.EvilYandereChan.GetComponent(typeof(TitleEvilYandereScript))).AnimationID = ((TitleEvilYandereScript)this.EvilYandereChan.GetComponent(typeof(TitleEvilYandereScript))).AnimationID + 1;
			((TitleEvilYandereScript)this.EvilYandereChan.GetComponent(typeof(TitleEvilYandereScript))).Start();
			this.RightBorder.active = false;
			this.LeftBorder.active = false;
			this.BlackBG.active = true;
			for (int i = 0; i < Extensions.get_length(this.LetterBGs); i++)
			{
				this.Letters[i].color = new Color((float)0, (float)0, (float)0);
				this.LetterBGs[i].color = new Color((float)1, (float)0, (float)0);
			}
			this.ButtonBGs[0].color = new Color((float)1, (float)0, (float)0);
			this.ButtonBGs[1].color = new Color((float)1, (float)0, (float)0);
			this.ButtonBGs[2].color = new Color((float)1, (float)0, (float)0);
			this.NoiseAndGrainScript.enabled = true;
			this.SSAOEffectScript.enabled = true;
			this.VignettingScript.enabled = true;
			this.AudioStartTime = this.Jukebox.audio.time;
			this.Jukebox.audio.Stop();
			this.audio.Play();
		}
		else
		{
			this.Evil = false;
			this.Timer = (float)5;
			this.YandereGraphic.mainTexture = this.CuteYandere;
			this.SimulatorGraphic.mainTexture = this.CuteSimulator;
			this.CuteYandereChan.active = true;
			this.EvilYandereChan.active = false;
			((TitleCuteYandereScript)this.CuteYandereChan.GetComponent(typeof(TitleCuteYandereScript))).Start();
			this.RightBorder.active = true;
			this.LeftBorder.active = true;
			this.BlackBG.active = false;
			this.Emitter.active = false;
			this.Senpai.active = false;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.BloodEffects);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				object obj3;
				object obj2 = obj3 = obj;
				if (!(obj2 is Transform))
				{
					obj3 = RuntimeServices.Coerce(obj2, typeof(Transform));
				}
				Transform transform = (Transform)obj3;
				UnityEngine.Object.Destroy(transform.gameObject);
				UnityRuntimeServices.Update(enumerator, transform);
			}
			for (int i = 0; i < Extensions.get_length(this.LetterBGs); i++)
			{
				this.Letters[i].color = new Color((float)1, (float)1, (float)1);
				this.LetterBGs[i].color = new Color((float)1, (float)1, (float)1);
			}
			this.ButtonBGs[0].color = new Color((float)1, (float)1, (float)1);
			this.ButtonBGs[1].color = new Color((float)1, (float)1, (float)1);
			this.ButtonBGs[2].color = new Color((float)1, (float)1, (float)1);
			this.NoiseAndGrainScript.enabled = false;
			this.SSAOEffectScript.enabled = false;
			this.VignettingScript.enabled = false;
			this.Jukebox.audio.Play();
			this.Jukebox.audio.time = this.AudioStartTime;
			this.Jukebox.audio.pitch = (float)0;
		}
	}

	public virtual void Main()
	{
	}
}
