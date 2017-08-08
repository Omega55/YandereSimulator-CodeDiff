using System;
using UnityEngine;

public class HappyScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JsonScript JSON;

	public UIPanel HUD;

	public GameObject Jukebox;

	public Transform Yandere;

	public Transform Fun;

	public bool InEditor;

	public float Speed;

	private void Start()
	{
		if (!this.InEditor)
		{
			if (this.JSON.StudentNames[33] != "Reserved")
			{
				this.BakeCookies();
			}
			else
			{
				for (int i = 1; i < 101; i++)
				{
					if (this.JSON.StudentGenders[i] == 0 && this.JSON.StudentHairstyles[i] == "20" && this.StudentManager.Students[i] != null)
					{
						this.StudentManager.Students[i].gameObject.SetActive(false);
					}
				}
			}
		}
		else
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (this.Fun.gameObject.activeInHierarchy)
		{
			this.Speed += Time.deltaTime * 0.01f;
			this.Fun.position = Vector3.MoveTowards(this.Fun.position, this.Yandere.position, Time.deltaTime * this.Speed);
			this.Fun.LookAt(this.Yandere.position);
			if (Vector3.Distance(this.Fun.position, this.Yandere.position) < 0.5f)
			{
				Application.Quit();
			}
		}
	}

	private void BakeCookies()
	{
		if (!this.Fun.gameObject.activeInHierarchy)
		{
			PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
			PlayerPrefs.SetFloat("SchoolAtmosphere", 0f);
			this.StudentManager.SetAtmosphere();
			foreach (StudentScript studentScript in this.StudentManager.Students)
			{
				if (studentScript != null)
				{
					studentScript.gameObject.SetActive(false);
				}
			}
			this.Yandere.gameObject.GetComponent<YandereScript>().NoDebug = true;
			this.Fun.gameObject.SetActive(true);
			this.Jukebox.SetActive(false);
			this.HUD.enabled = false;
		}
	}
}
