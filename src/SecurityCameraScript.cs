using System;
using UnityEngine;

[Serializable]
public class SecurityCameraScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public float Rotation;

	public int Direction;

	public SecurityCameraScript()
	{
		this.Direction = 1;
	}

	public virtual void Update()
	{
		this.Rotation += (float)(this.Direction * 36) * Time.deltaTime;
		float rotation = this.Rotation;
		Vector3 localEulerAngles = this.transform.parent.localEulerAngles;
		float num = localEulerAngles.y = rotation;
		Vector3 vector = this.transform.parent.localEulerAngles = localEulerAngles;
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

	public virtual void OnTriggerStay(Collider other)
	{
		if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13 && ((this.Yandere.Armed && this.Yandere.Weapon[this.Yandere.Equipped].Suspicious) || (this.Yandere.Bloodiness > (float)0 && !this.Yandere.Paint) || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Dragging || this.Yandere.Carrying || (this.Yandere.Laughing && this.Yandere.LaughIntensity > (float)15)))
		{
			this.MissionMode.GameOverID = 15;
			this.MissionMode.GameOver();
			this.MissionMode.Phase = 4;
			this.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
