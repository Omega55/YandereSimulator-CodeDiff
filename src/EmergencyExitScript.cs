using System;
using UnityEngine;

public class EmergencyExitScript : MonoBehaviour
{
	public StudentScript Student;

	public Transform Pivot;

	public bool Open;

	public float Timer;

	private void Update()
	{
		if (!this.Open)
		{
			this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 0f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
		}
		else
		{
			this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 90f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
			this.Timer -= Time.deltaTime;
			if (this.Timer <= 0f)
			{
				this.Student = null;
				this.Open = false;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null && this.Student.Fleeing)
		{
			this.Open = true;
			this.Timer = 1f;
		}
	}
}
