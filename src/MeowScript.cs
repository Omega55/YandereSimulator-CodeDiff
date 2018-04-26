using System;
using UnityEngine;

public class MeowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JsonScript JSON;

	public UIPanel HUD;

	public GameObject Jukebox;

	public Transform Yandere;

	public Transform Fuck;

	public float Speed;

	private void Start()
	{
		if (this.JSON.Students[33].Name != "Reserved")
		{
			this.PetKittens();
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
		if (this.Fuck.gameObject.activeInHierarchy)
		{
			this.Speed += Time.deltaTime * 0.01f;
			this.Fuck.position = Vector3.MoveTowards(this.Fuck.position, this.Yandere.position, Time.deltaTime * this.Speed);
			this.Fuck.LookAt(this.Yandere.position);
			if (Vector3.Distance(this.Fuck.position, this.Yandere.position) < 0.5f)
			{
				Application.Quit();
			}
		}
	}

	private void PetKittens()
	{
		if (!this.Fuck.gameObject.activeInHierarchy)
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
			this.Fuck.gameObject.SetActive(true);
			this.Jukebox.SetActive(false);
			this.HUD.enabled = false;
		}
	}
}
