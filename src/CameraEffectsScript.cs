using System;
using UnityEngine;
using XInputDotNetPure;

public class CameraEffectsScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Vignetting Vignette;

	public UITexture MurderStreaks;

	public UITexture Streaks;

	public Bloom AlarmBloom;

	public float EffectStrength;

	public float VibrationTimer;

	public Bloom QualityBloom;

	public Vignetting QualityVignetting;

	public AntialiasingAsPostEffect QualityAntialiasingAsPostEffect;

	public bool VibrationCheck;

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
		if (this.VibrationCheck)
		{
			this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0f, Time.deltaTime);
			if (this.VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				this.VibrationCheck = false;
			}
		}
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
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		this.VibrationCheck = true;
		this.VibrationTimer = 0.1f;
		this.AlarmBloom.bloomIntensity = 1f;
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 1f);
		this.AlarmBloom.enabled = true;
		this.Yandere.Jukebox.SFX.PlayOneShot(this.Noticed);
	}

	public void MurderWitnessed()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		this.VibrationCheck = true;
		this.VibrationTimer = 0.1f;
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 1f);
		this.Yandere.Jukebox.SFX.PlayOneShot((!this.Yandere.Noticed) ? this.MurderNoticed : this.SenpaiNoticed);
	}

	public void DisableCamera()
	{
		if (!this.OneCamera)
		{
			this.OneCamera = true;
		}
		else
		{
			this.OneCamera = false;
		}
	}
}
