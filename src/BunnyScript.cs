using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BunnyScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JsonScript JSON;

	public UIPanel HUD;

	public GameObject Jukebox;

	public Transform Yandere;

	public Transform Fun;

	public bool InEditor;

	public float Speed;

	public virtual void Start()
	{
		if (!this.InEditor)
		{
			if (this.JSON.StudentNames[33] != "Reserved")
			{
				this.BakeCookies();
			}
			for (int i = 1; i < 102; i++)
			{
				if (RuntimeServices.EqualityOperator(this.JSON.StudentHairstyles[i], 20))
				{
					this.BakeCookies();
				}
			}
		}
		else
		{
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Fun.active)
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

	public virtual void BakeCookies()
	{
		if (!this.Fun.gameObject.active)
		{
			PlayerPrefs.SetInt("SchoolAtmosphereSet", 1);
			PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
			this.StudentManager.SetAtmosphere();
			for (int i = 0; i < 101; i++)
			{
				if (this.StudentManager.Students[i] != null)
				{
					this.StudentManager.Students[i].active = false;
				}
			}
			((YandereScript)this.Yandere.gameObject.GetComponent(typeof(YandereScript))).NoDebug = true;
			this.Fun.gameObject.active = true;
			this.Jukebox.active = false;
			this.HUD.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
