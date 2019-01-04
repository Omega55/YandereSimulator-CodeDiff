﻿using System;
using UnityEngine;

public class MemorialSceneScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public GameObject[] Canvases;

	public UITexture[] Portraits;

	public GameObject CanvasGroup;

	public GameObject Headmaster;

	public GameObject Counselor;

	public float Speed;

	public bool Eulogized;

	public bool FadeOut;

	private void Start()
	{
		if (StudentGlobals.MemorialStudents % 2 == 0)
		{
			this.CanvasGroup.transform.localPosition = new Vector3(-0.5f, 0f, -2f);
		}
		int num = 0;
		int i;
		for (i = 1; i < 10; i++)
		{
			this.Canvases[i].SetActive(false);
		}
		i = 0;
		while (StudentGlobals.MemorialStudents > 0)
		{
			i++;
			this.Canvases[i].SetActive(true);
			if (StudentGlobals.MemorialStudents == 1)
			{
				num = StudentGlobals.MemorialStudent1;
			}
			else if (StudentGlobals.MemorialStudents == 2)
			{
				num = StudentGlobals.MemorialStudent2;
			}
			else if (StudentGlobals.MemorialStudents == 3)
			{
				num = StudentGlobals.MemorialStudent3;
			}
			else if (StudentGlobals.MemorialStudents == 4)
			{
				num = StudentGlobals.MemorialStudent4;
			}
			else if (StudentGlobals.MemorialStudents == 5)
			{
				num = StudentGlobals.MemorialStudent5;
			}
			else if (StudentGlobals.MemorialStudents == 6)
			{
				num = StudentGlobals.MemorialStudent6;
			}
			else if (StudentGlobals.MemorialStudents == 7)
			{
				num = StudentGlobals.MemorialStudent7;
			}
			else if (StudentGlobals.MemorialStudents == 8)
			{
				num = StudentGlobals.MemorialStudent8;
			}
			else if (StudentGlobals.MemorialStudents == 9)
			{
				num = StudentGlobals.MemorialStudent9;
			}
			string url = string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				num.ToString(),
				".png"
			});
			WWW www = new WWW(url);
			this.Portraits[i].mainTexture = www.texture;
			StudentGlobals.MemorialStudents--;
		}
	}

	private void Update()
	{
		this.Speed += Time.deltaTime;
		if (this.Speed > 1f)
		{
			if (!this.Eulogized)
			{
				this.StudentManager.Yandere.Subtitle.UpdateLabel(SubtitleType.Eulogy, 0, 8f);
				this.StudentManager.Yandere.PromptBar.Label[0].text = "Continue";
				this.StudentManager.Yandere.PromptBar.UpdateButtons();
				this.StudentManager.Yandere.PromptBar.Show = true;
				this.Eulogized = true;
			}
			this.StudentManager.MainCamera.position = Vector3.Lerp(this.StudentManager.MainCamera.position, new Vector3(38f, 4.125f, 68.825f), (this.Speed - 1f) * Time.deltaTime * 0.15f);
			if (Input.GetButtonDown("A"))
			{
				this.StudentManager.Yandere.PromptBar.Show = false;
				this.FadeOut = true;
			}
		}
		if (this.FadeOut)
		{
			this.StudentManager.Clock.BloomEffect.bloomIntensity += Time.deltaTime * 10f;
			if (this.StudentManager.Clock.BloomEffect.bloomIntensity > 10f)
			{
				this.StudentManager.Yandere.Casual = !this.StudentManager.Yandere.Casual;
				this.StudentManager.Yandere.ChangeSchoolwear();
				this.StudentManager.Yandere.transform.position = new Vector3(12f, 0f, 72f);
				this.StudentManager.Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				this.StudentManager.Yandere.HeartCamera.enabled = true;
				this.StudentManager.Yandere.RPGCamera.enabled = true;
				this.StudentManager.Yandere.CanMove = true;
				this.StudentManager.Yandere.HUD.alpha = 1f;
				this.StudentManager.Clock.UpdateBloom = true;
				this.StudentManager.Clock.StopTime = false;
				this.StudentManager.Clock.PresentTime = 450f;
				this.StudentManager.Clock.HourTime = 7.5f;
				this.StudentManager.Unstop();
				this.StudentManager.SkipTo8();
				this.Headmaster.SetActive(false);
				this.Counselor.SetActive(false);
				base.enabled = false;
			}
		}
	}
}