using System;
using UnityEngine;

[Serializable]
public class CameraEffectsScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Vignetting Vignette;

	public UITexture MurderStreaks;

	public UITexture Streaks;

	public Bloom AlarmBloom;

	public float EffectStrength;

	public Bloom QualityBloom;

	public Vignetting QualityVignetting;

	public AntialiasingAsPostEffect QualityAntialiasingAsPostEffect;

	public bool OneCamera;

	public AudioClip MurderNoticed;

	public AudioClip SenpaiNoticed;

	public AudioClip Noticed;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.MurderStreaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.MurderStreaks.color = color;
		int num3 = 0;
		Color color3 = this.Streaks.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Streaks.color = color3;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("0"))
		{
			if (this.QualityBloom.enabled)
			{
				this.QualityBloom.enabled = false;
				this.QualityVignetting.enabled = false;
				this.QualityAntialiasingAsPostEffect.enabled = false;
			}
			else
			{
				this.QualityBloom.enabled = true;
				this.QualityVignetting.enabled = true;
				this.QualityAntialiasingAsPostEffect.enabled = true;
			}
		}
		if (Input.GetKeyDown("9"))
		{
			if (!this.OneCamera)
			{
				this.OneCamera = true;
				if (this.Yandere.Aiming)
				{
					this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
					this.Yandere.MainCamera.farClipPlane = 0.02f;
				}
			}
			else
			{
				this.OneCamera = false;
				if (this.Yandere.Aiming)
				{
					this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
					this.Yandere.MainCamera.farClipPlane = 200f;
				}
			}
		}
		if (this.Streaks.color.a > (float)0)
		{
			this.AlarmBloom.bloomIntensity = this.AlarmBloom.bloomIntensity - Time.deltaTime;
			float a = this.Streaks.color.a - Time.deltaTime;
			Color color = this.Streaks.color;
			float num = color.a = a;
			Color color2 = this.Streaks.color = color;
			if (this.Streaks.color.a <= (float)0)
			{
				this.AlarmBloom.enabled = false;
			}
		}
		if (this.MurderStreaks.color.a > (float)0)
		{
			float a2 = this.MurderStreaks.color.a - Time.deltaTime;
			Color color3 = this.MurderStreaks.color;
			float num2 = color3.a = a2;
			Color color4 = this.MurderStreaks.color = color3;
		}
		this.EffectStrength = (float)1 - this.Yandere.Sanity * 0.01f;
		this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.EffectStrength * (float)5, Time.deltaTime);
		this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.EffectStrength, Time.deltaTime);
		this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.EffectStrength * (float)5, Time.deltaTime);
	}

	public virtual void Alarm()
	{
		this.AlarmBloom.bloomIntensity = (float)1;
		int num = 1;
		Color color = this.Streaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Streaks.color = color;
		this.AlarmBloom.enabled = true;
		this.Yandere.Jukebox.SFX.PlayOneShot(this.Noticed);
	}

	public virtual void MurderWitnessed()
	{
		int num = 1;
		Color color = this.MurderStreaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.MurderStreaks.color = color;
		if (!this.Yandere.Noticed)
		{
			this.Yandere.Jukebox.SFX.PlayOneShot(this.MurderNoticed);
		}
		else
		{
			this.Yandere.Jukebox.SFX.PlayOneShot(this.SenpaiNoticed);
		}
	}

	public virtual void Main()
	{
	}
}
