using System;
using UnityEngine;

[Serializable]
public class ShoulderCameraScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public Transform Smartphone;

	public Transform ShoulderFocus;

	public Transform ShoulderPOV;

	public Transform CameraFocus;

	public Transform CameraPOV;

	public Vector3 LastPosition;

	public bool AimingCamera;

	public bool OverShoulder;

	public float Height;

	public float Timer;

	public virtual void LateUpdate()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.OverShoulder)
			{
				if (this.RPGCamera.enabled)
				{
					this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
					this.LastPosition = this.transform.position;
					this.RPGCamera.enabled = false;
				}
				this.transform.position = Vector3.Lerp(this.transform.position, this.ShoulderPOV.position, Time.deltaTime * (float)10);
				this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * (float)10);
				this.transform.LookAt(this.ShoulderFocus);
			}
			else if (this.AimingCamera)
			{
				this.transform.position = this.CameraPOV.position;
				this.transform.LookAt(this.CameraFocus);
			}
			else if (this.Yandere.Talking && !this.RPGCamera.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer < 0.5f)
				{
					this.transform.position = Vector3.Lerp(this.transform.position, this.LastPosition, Time.deltaTime * (float)10);
					this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * (float)10);
					this.transform.LookAt(this.ShoulderFocus);
				}
				else
				{
					this.RPGCamera.enabled = true;
					this.Yandere.Talking = false;
					this.Yandere.CanMove = true;
					this.Timer = (float)0;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
