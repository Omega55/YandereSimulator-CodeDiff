using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ActivateOsuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public OsuScript[] OsuScripts;

	public StudentScript Student;

	public ClockScript Clock;

	public GameObject Music;

	public Transform Mouse;

	public GameObject Osu;

	public int PlayerID;

	public Vector3 OriginalMousePosition;

	public Vector3 OriginalMouseRotation;

	public virtual void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	public virtual void Update()
	{
		if (this.Student == null)
		{
			this.Student = this.StudentManager.Students[this.PlayerID];
		}
		else if (!this.Osu.active)
		{
			if (Vector3.Distance(this.transform.position, this.Student.transform.position) < 0.1f && this.Student.Routine && this.Student.Actions[this.Student.Phase] == 2)
			{
				this.ActivateOsu();
			}
		}
		else
		{
			this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
			if (!this.Student.Routine)
			{
				this.DeactivateOsu();
			}
			else if (this.Student.Actions[this.Student.Phase] != 2)
			{
				this.DeactivateOsu();
			}
		}
	}

	public virtual void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.active = true;
		this.Music.active = true;
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void DeactivateOsu()
	{
		this.Osu.transform.parent.gameObject.active = false;
		this.Music.active = false;
		for (int i = 0; i < Extensions.get_length(this.OsuScripts); i++)
		{
			this.OsuScripts[i].Timer = (float)0;
		}
		this.Mouse.parent = this.transform.parent;
		this.Mouse.transform.position = this.OriginalMousePosition;
	}

	public virtual void Main()
	{
	}
}
