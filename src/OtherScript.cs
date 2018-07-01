using System;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JsonScript JSON;

	public UIPanel HUD;

	public GameObject Jukebox;

	public Transform Yandere;

	public Transform Other;

	public float Speed;

	private void Start()
	{
		if (this.JSON.Students[33].Name != "Reserved")
		{
			Application.Quit();
			this.Wow();
		}
		else
		{
			for (int i = 1; i < 101; i++)
			{
				if (this.JSON.Students[i].Gender == 0 && this.JSON.Students[i].Hairstyle == "20" && this.StudentManager.Students[i] != null)
				{
					this.StudentManager.Students[i].gameObject.SetActive(false);
				}
			}
		}
	}

	private void Update()
	{
		if (this.Other.gameObject.activeInHierarchy)
		{
			this.Speed += Time.deltaTime * 0.01f;
			this.Other.position = Vector3.MoveTowards(this.Other.position, this.Yandere.position, Time.deltaTime * this.Speed);
			this.Other.LookAt(this.Yandere.position);
			if (Vector3.Distance(this.Other.position, this.Yandere.position) < 0.5f)
			{
				Application.Quit();
			}
		}
	}

	private void Wow()
	{
		if (!this.Other.gameObject.activeInHierarchy)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
			this.StudentManager.SetAtmosphere();
			foreach (StudentScript studentScript in this.StudentManager.Students)
			{
				if (studentScript != null)
				{
					studentScript.gameObject.SetActive(false);
				}
			}
			this.Yandere.gameObject.GetComponent<YandereScript>().NoDebug = true;
			this.Other.gameObject.SetActive(true);
			this.Jukebox.SetActive(false);
			this.HUD.enabled = false;
		}
	}
}
