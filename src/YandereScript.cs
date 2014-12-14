using System;
using UnityEngine;

[Serializable]
public class YandereScript : MonoBehaviour
{
	private GameObject NewTrail;

	public ColorCorrectionCurves ColorCorrection;

	public DepthOfField34 DepthOfField;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform Homeroom;

	public Transform Senpai;

	public AudioSource HeartBeat;

	public AudioSource Jukebox;

	public GameObject Character;

	public GameObject Eyepatch;

	public GameObject Trail;

	public float BreastSize;

	public float WalkSpeed;

	public float RunSpeed;

	public float Tint;

	public Quaternion targetRotation;

	private int ID;

	public YandereScript()
	{
		this.BreastSize = 1f;
	}

	public virtual void Start()
	{
		this.ResetEffects();
	}

	public virtual void LateUpdate()
	{
		Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
		a.y = (float)0;
		a = a.normalized;
		Vector3 a2 = new Vector3(a.z, (float)0, -a.x);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = axis2 * a2 + axis * a;
		if (vector != Vector3.zero)
		{
			this.targetRotation = Quaternion.LookRotation(vector);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.targetRotation, Time.deltaTime * (float)10);
		}
		else
		{
			this.targetRotation = new Quaternion((float)0, (float)0, (float)0, (float)0);
		}
		if (axis != (float)0 || axis2 != (float)0)
		{
			if (Input.GetButton("LB") && Vector3.Distance(this.transform.position, this.Senpai.position) > (float)2)
			{
				this.Character.animation.CrossFade("f02_sprint_00");
				this.transform.Translate(Vector3.forward * this.RunSpeed * Time.deltaTime);
			}
			else
			{
				this.Character.animation.CrossFade("f02_walk_00");
				this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
			}
		}
		else
		{
			this.Character.animation.CrossFade("f02_idleShort_00");
		}
		if (Input.GetButtonDown("LS") || Input.GetKeyDown("t"))
		{
			if (this.NewTrail != null)
			{
				UnityEngine.Object.Destroy(this.NewTrail);
			}
			this.NewTrail = (GameObject)UnityEngine.Object.Instantiate(this.Trail, this.transform.position + Vector3.fwd * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
			((AIPath)this.NewTrail.GetComponent(typeof(AIPath))).target = this.Homeroom;
		}
		if (Vector3.Distance(this.transform.position, this.Senpai.position) < (float)2)
		{
			this.ColorCorrection.enabled = true;
			this.DepthOfField.enabled = true;
			this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, (float)0, Time.deltaTime * (float)10);
			this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, (float)20, Time.deltaTime * (float)10);
			this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, (float)20, Time.deltaTime * (float)10);
			this.Tint = (float)1 - this.DepthOfField.focalSize / (float)150;
			this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.Tint * 0.5f));
			this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.Tint * 0.5f));
			this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.Tint * 0.5f));
			this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.UpdateTextures();
			this.Character.animation["f02_shy_00"].weight = this.Tint;
			this.HeartBeat.volume = this.Tint;
		}
		else if (this.DepthOfField.focalSize < (float)149)
		{
			this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, (float)150, Time.deltaTime * (float)10);
			this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, (float)0, Time.deltaTime * (float)10);
			this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, (float)0, Time.deltaTime * (float)10);
			this.Tint = this.DepthOfField.focalSize / (float)150;
			this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.Tint * 0.5f));
			this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.Tint * 0.5f));
			this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, (float)1 - this.Tint * 0.5f));
			this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
			this.ColorCorrection.UpdateTextures();
			this.Character.animation["f02_shy_00"].weight = (float)1 - this.Tint;
			this.HeartBeat.volume = (float)1 - this.Tint;
		}
		else
		{
			this.ResetEffects();
		}
		if (this.transform.position.y < (float)-1 || Input.GetKeyDown("r"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown("p"))
		{
			if (!this.Eyepatch.active)
			{
				this.Eyepatch.active = true;
			}
			else
			{
				this.Eyepatch.active = false;
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)1;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)1;
		}
		if (Input.GetKey("."))
		{
			this.BreastSize += Time.deltaTime;
			if (this.BreastSize > (float)2)
			{
				this.BreastSize = (float)2;
			}
		}
		if (Input.GetKey(","))
		{
			this.BreastSize -= Time.deltaTime;
			if (this.BreastSize < (float)0)
			{
				this.BreastSize = (float)0;
			}
		}
		if (this.transform.position.z < (float)-50)
		{
			int num = -50;
			Vector3 position = this.transform.position;
			float num2 = position.z = (float)num;
			Vector3 vector2 = this.transform.position = position;
		}
		this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
	}

	public virtual void ResetEffects()
	{
		this.DepthOfField.focalSize = (float)150;
		this.DepthOfField.focalZStartCurve = (float)0;
		this.DepthOfField.focalZEndCurve = (float)0;
		this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
		this.ColorCorrection.redChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.greenChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.blueChannel.SmoothTangents(1, (float)0);
		this.ColorCorrection.UpdateTextures();
		this.ColorCorrection.enabled = false;
		this.DepthOfField.enabled = false;
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.HeartBeat.volume = (float)0;
	}

	public virtual void Main()
	{
		this.Character.animation["f02_shy_00"].layer = 1;
		this.Character.animation["f02_shy_00"].weight = (float)0;
		this.Character.animation.Play("f02_shy_00");
	}
}
