using System;
using UnityEngine;

[Serializable]
public class MetalDetectorScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public virtual void OnTriggerStay(Collider other)
	{
		if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13 && (this.Yandere.Weapon[1] != null || this.Yandere.Weapon[2] != null || this.Yandere.Weapon[3] != null))
		{
			this.MissionMode.GameOverID = 16;
			this.MissionMode.GameOver();
			this.MissionMode.Phase = 4;
			this.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
