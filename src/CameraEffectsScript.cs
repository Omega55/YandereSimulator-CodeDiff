using System;
using UnityEngine;

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

	private void Start()
	{
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 0f);
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 0f);
	}

	private void Update()
	{
		if (this.Streaks.color.a > 0f)
		{
			this.AlarmBloom.bloomIntensity -= Time.deltaTime;
			this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, this.Streaks.color.a - Time.deltaTime);
			if (this.Streaks.color.a <= 0f)
			{
				this.AlarmBloom.enabled = false;
			}
		}
		if (this.MurderStreaks.color.a > 0f)
		{
			this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, this.MurderStreaks.color.a - Time.deltaTime);
		}
		this.EffectStrength = 1f - this.Yandere.Sanity * 0.01f;
		this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.EffectStrength * 5f, Time.deltaTime);
		this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.EffectStrength, Time.deltaTime);
		this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.EffectStrength * 5f, Time.deltaTime);
	}

	public void Alarm()
	{
		this.AlarmBloom.bloomIntensity = 1f;
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 1f);
		this.AlarmBloom.enabled = true;
		this.Yandere.Jukebox.SFX.PlayOneShot(this.Noticed);
	}

	public void MurderWitnessed()
	{
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 1f);
		this.Yandere.Jukebox.SFX.PlayOneShot((!this.Yandere.Noticed) ? this.MurderNoticed : this.SenpaiNoticed);
	}

	public void DisableCamera()
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
				this.Yandere.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
			}
		}
	}
}
