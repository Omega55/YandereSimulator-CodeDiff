using System;
using UnityEngine;

[Serializable]
public class DebugMenuScript : MonoBehaviour
{
	public GameObject Window;

	public virtual void Start()
	{
		this.Window.active = false;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backslash))
		{
			if (!this.Window.active)
			{
				this.Window.active = true;
			}
			else
			{
				this.Window.active = false;
			}
		}
		if (this.Window.active)
		{
			if (Input.GetKeyDown("1"))
			{
				PlayerPrefs.SetInt("Weekday", 1);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("2"))
			{
				PlayerPrefs.SetInt("Weekday", 2);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("3"))
			{
				PlayerPrefs.SetInt("Weekday", 3);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("4"))
			{
				PlayerPrefs.SetInt("Weekday", 4);
				Application.LoadLevel(Application.loadedLevel);
			}
			else if (Input.GetKeyDown("5"))
			{
				PlayerPrefs.SetInt("Weekday", 5);
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	public virtual void Main()
	{
	}
}
