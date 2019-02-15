using System;
using UnityEngine;

public class TrashCompactorScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JsonScript JSON;

	public UIPanel HUD;

	public GameObject Jukebox;

	public Transform TrashCompactorObject;

	public Transform Yandere;

	public float Speed;

	private void Start()
	{
		if (this.StudentManager.Students[10] != null || this.StudentManager.Students[11] != null)
		{
			this.CompactTrash();
		}
		else
		{
			for (int i = 1; i < 101; i++)
			{
				if (this.StudentManager.Students[i] != null && !this.StudentManager.Students[i].Male && (this.StudentManager.Students[i].Cosmetic.Hairstyle == 20 || this.StudentManager.Students[i].Cosmetic.Hairstyle == 21))
				{
					this.CompactTrash();
				}
			}
		}
	}

	private void Update()
	{
		if (this.TrashCompactorObject.gameObject.activeInHierarchy)
		{
			this.Speed += Time.deltaTime * 0.01f;
			this.TrashCompactorObject.position = Vector3.MoveTowards(this.TrashCompactorObject.position, this.Yandere.position, Time.deltaTime * this.Speed);
			this.TrashCompactorObject.LookAt(this.Yandere.position);
			if (Vector3.Distance(this.TrashCompactorObject.position, this.Yandere.position) < 0.5f)
			{
				Application.Quit();
			}
		}
	}

	private void CompactTrash()
	{
		if (!this.TrashCompactorObject.gameObject.activeInHierarchy)
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
			this.TrashCompactorObject.gameObject.SetActive(true);
			this.Jukebox.SetActive(false);
			this.HUD.enabled = false;
		}
	}
}
