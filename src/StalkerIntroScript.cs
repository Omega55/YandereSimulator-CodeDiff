using System;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StalkerIntroScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public StalkerYandereScript Yandere;

	public RPG_Camera RPGCamera;

	public Transform CameraFocus;

	public Transform Moon;

	public Renderer Darkness;

	public float Alpha;

	public float Speed;

	public float Timer;

	public float DOF;

	public int Phase;

	public GameObject[] Neighborhood;

	private void Start()
	{
		RenderSettings.ambientIntensity = 4f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		base.transform.position = new Vector3(12.5f, 5f, 13f);
		base.transform.LookAt(this.Moon);
		this.CameraFocus.parent = base.transform;
		this.CameraFocus.localPosition = new Vector3(0f, 0f, 100f);
		this.CameraFocus.parent = null;
		this.UpdateDOF(3f);
		this.DOF = 4f;
		this.Alpha = 1f;
	}

	private void Update()
	{
		this.Moon.LookAt(base.transform);
		if (this.Phase == 0)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Timer = 2f;
				this.Alpha = 0f;
			}
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Darkness.material.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 2f)
				{
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 1)
		{
			if (this.Speed == 0f)
			{
				this.Yandere.MyAnimation.Play();
			}
			if (Input.GetKeyDown("space") && this.Yandere.MyAnimation["f02_jumpOverWall_00"].time < 12f)
			{
				this.Yandere.MyAnimation["f02_jumpOverWall_00"].time = 12f;
				this.Speed = 100f;
			}
			this.Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(11.5f, 1f, 13f), Time.deltaTime * this.Speed);
			this.CameraFocus.position = Vector3.Lerp(this.CameraFocus.position, new Vector3(13.62132f, 1f, 15.12132f), Time.deltaTime * this.Speed);
			this.DOF = Mathf.Lerp(this.DOF, 2f, Time.deltaTime * this.Speed);
			this.UpdateDOF(this.DOF);
			base.transform.LookAt(this.CameraFocus);
			if (this.Yandere.MyAnimation["f02_jumpOverWall_00"].time > 13f)
			{
				this.Yandere.transform.position = new Vector3(13.15f, 0f, 13f);
				base.transform.position = new Vector3(12.9f, 1.35f, 12.5f);
				base.transform.eulerAngles = new Vector3(0f, 45f, 0f);
				this.UpdateDOF(0.3f);
				this.Speed = -1f;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Speed = 100f;
			}
			this.Speed += Time.deltaTime;
			if (this.Speed > 0f)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(13.15f, 1.51515f, 14.92272f), Time.deltaTime * this.Speed);
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(15f, 180f, 0f), Time.deltaTime * this.Speed);
				this.DOF = Mathf.Lerp(this.DOF, 2f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DOF);
				if (this.Speed > 4f)
				{
					this.RPGCamera.enabled = true;
					this.Yandere.enabled = true;
					this.Phase++;
				}
			}
		}
		if (Input.GetKeyDown("space"))
		{
			if (this.Neighborhood[0].activeInHierarchy)
			{
				this.Neighborhood[0].SetActive(false);
				this.Neighborhood[1].SetActive(true);
				return;
			}
			this.Neighborhood[0].SetActive(true);
			this.Neighborhood[1].SetActive(false);
		}
	}

	private void UpdateDOF(float Value)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Value;
		settings.aperture = 5.6f;
		this.Profile.depthOfField.settings = settings;
	}
}
