using System;
using UnityEngine;

[Serializable]
public class GoToSchoolScript : MonoBehaviour
{
	public GameObject ControlsWindow;

	public Transform ButtonParent;

	public Transform Yandere;

	public UILabel TimerLabel;

	public UISprite Button;

	public Bloom Bloom;

	public bool FadeOut;

	public float Timer;

	public virtual void Start()
	{
		this.ControlsWindow.active = false;
		this.Bloom.bloomIntensity = (float)10;
	}

	public virtual void Update()
	{
		this.ButtonParent.transform.LookAt(Camera.main.transform.position);
		if (Input.GetKeyDown("c"))
		{
			if (this.ControlsWindow.active)
			{
				this.ControlsWindow.active = false;
			}
			else
			{
				this.ControlsWindow.active = true;
			}
		}
		if (Vector3.Distance(this.Yandere.position, this.transform.position) < (float)1)
		{
			this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
			if (Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				this.TimerLabel.color = new Color((float)1, (float)0, (float)0, (float)1);
			}
		}
		else if (Vector3.Distance(this.Yandere.position, this.transform.position) < (float)5)
		{
			this.Button.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
		}
		else
		{
			int num = 0;
			Color color = this.Button.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Button.color = color;
		}
		if (!this.FadeOut)
		{
			this.Bloom.bloomIntensity = Mathf.MoveTowards(this.Bloom.bloomIntensity, 0.1f, Time.deltaTime * (float)10);
			this.Timer += Time.deltaTime;
			this.TimerLabel.text = "Time taken to get to school: " + this.Timer.ToString("F2");
		}
		else
		{
			this.Bloom.bloomIntensity = Mathf.MoveTowards(this.Bloom.bloomIntensity, (float)10, Time.deltaTime * (float)10);
			if (this.Bloom.bloomIntensity == (float)10)
			{
				Application.LoadLevel("SchoolScene");
			}
		}
	}

	public virtual void Main()
	{
	}
}
