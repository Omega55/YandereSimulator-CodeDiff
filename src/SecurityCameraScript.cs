using System;
using UnityEngine;

public class SecurityCameraScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public float Rotation;

	public int Direction = 1;

	private void Update()
	{
		this.Rotation += (float)this.Direction * 36f * Time.deltaTime;
		base.transform.parent.localEulerAngles = new Vector3(base.transform.parent.localEulerAngles.x, this.Rotation, base.transform.parent.localEulerAngles.z);
		if (this.Direction > 0)
		{
			if (this.Rotation > 86.5f)
			{
				this.Direction = -1;
			}
		}
		else if (this.Rotation < -86.5f)
		{
			this.Direction = 1;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13 && ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Dragging || this.Yandere.Carrying || (this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f)))
		{
			this.MissionMode.GameOverID = 15;
			this.MissionMode.GameOver();
			this.MissionMode.Phase = 4;
			base.enabled = false;
		}
	}
}
