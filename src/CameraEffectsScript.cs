using System;
using UnityEngine;

[Serializable]
public class CameraEffectsScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Vignetting Vignette;

	public UITexture Streaks;

	public Bloom AlarmBloom;

	public float EffectStrength;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.Streaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Streaks.color = color;
	}

	public virtual void Update()
	{
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
	}

	public virtual void Main()
	{
	}
}
