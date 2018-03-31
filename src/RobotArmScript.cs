using System;
using UnityEngine;

public class RobotArmScript : MonoBehaviour
{
	public SkinnedMeshRenderer RobotArms;

	public AudioSource MyAudio;

	public PromptScript Prompt;

	public bool UpdateArms;

	public bool On;

	public AudioClip ArmsOff;

	public AudioClip ArmsOn;

	public float ArmValue;

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.UpdateArms = true;
			this.On = !this.On;
			if (this.On)
			{
				this.MyAudio.clip = this.ArmsOn;
			}
			else
			{
				this.MyAudio.clip = this.ArmsOff;
			}
			this.MyAudio.Play();
		}
		if (this.UpdateArms)
		{
			if (this.On)
			{
				this.ArmValue = Mathf.Lerp(this.ArmValue, 0f, Time.deltaTime * 5f);
				this.RobotArms.SetBlendShapeWeight(0, this.ArmValue);
				if (this.ArmValue < 1f)
				{
					this.RobotArms.SetBlendShapeWeight(0, 0f);
					this.UpdateArms = false;
					this.ArmValue = 1f;
				}
			}
			else
			{
				this.ArmValue = Mathf.Lerp(this.ArmValue, 100f, Time.deltaTime * 5f);
				this.RobotArms.SetBlendShapeWeight(0, this.ArmValue);
				if (this.ArmValue > 99f)
				{
					this.RobotArms.SetBlendShapeWeight(0, 100f);
					this.UpdateArms = false;
					this.ArmValue = 100f;
				}
			}
		}
	}
}
