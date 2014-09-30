using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentManagerScript : MonoBehaviour
{
	public GameObject[] Students;

	public YandereScript YandereChan;

	public GameObject GhostChan;

	public virtual void Start()
	{
		this.Students = GameObject.FindGameObjectsWithTag("Student");
		this.GhostChan = GameObject.Find("GhostChan");
		if (this.GhostChan != null)
		{
			this.GhostChan.active = false;
		}
	}

	public virtual void ActivateYandereVision()
	{
		for (int i = 0; i < Extensions.get_length(this.Students); i++)
		{
			if (this.Students[i] != null)
			{
				((StudentScript)this.Students[i].GetComponent(typeof(StudentScript))).YandereVision();
			}
		}
	}

	public virtual void DeactivateYandereVision()
	{
		for (int i = 0; i < Extensions.get_length(this.Students); i++)
		{
			if (this.Students[i] != null)
			{
				((StudentScript)this.Students[i].GetComponent(typeof(StudentScript))).NormalVision();
			}
		}
	}

	public virtual void Main()
	{
	}
}
