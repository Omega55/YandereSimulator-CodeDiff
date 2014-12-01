using System;
using UnityEngine;

[Serializable]
public class SimpleYandereScript : MonoBehaviour
{
	public GameObject PointLight;

	public GameObject Character;

	public GameObject Jukebox;

	public GameObject Minimap;

	public Transform RightBreast;

	public Transform LeftBreast;

	public float BreastSize;

	public float WalkSpeed;

	public float RunSpeed;

	public Quaternion targetRotation;

	private int ID;

	public SimpleYandereScript()
	{
		this.BreastSize = 1f;
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
			if (Input.GetButton("LB"))
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
			this.Character.animation.CrossFade("student_idle");
		}
		if (this.transform.position.y < (float)-1 || Input.GetKeyDown("r"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown("m"))
		{
			if (!this.Jukebox.active)
			{
				this.Jukebox.active = true;
			}
			else
			{
				this.Jukebox.active = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
