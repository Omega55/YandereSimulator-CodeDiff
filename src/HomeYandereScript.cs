using System;
using UnityEngine;

[Serializable]
public class HomeYandereScript : MonoBehaviour
{
	public HomeTriggerScript CurrentTrigger;

	public Transform MainCamera;

	public GameObject Character;

	public float WalkSpeed;

	public float RunSpeed;

	public bool CanMove;

	public virtual void Update()
	{
		float num = Input.GetAxisRaw("Vertical") * Time.timeScale;
		float num2 = Input.GetAxisRaw("Horizontal") * Time.timeScale;
		if (this.CanMove)
		{
			if (num > 0.1f || num < -0.1f || num2 > 0.1f || num2 < -0.1f)
			{
				if (Input.GetButton("LB"))
				{
					this.transform.Translate(Vector3.forward * this.RunSpeed * Time.deltaTime);
					this.Character.animation.CrossFade("f02_run_00");
				}
				else
				{
					this.transform.Translate(Vector3.forward * this.WalkSpeed * Time.deltaTime);
					this.Character.animation.CrossFade("f02_walk_00");
				}
			}
			else
			{
				this.Character.animation.CrossFade("f02_idle_00");
			}
			Vector3 a = this.MainCamera.TransformDirection(Vector3.forward);
			a.y = (float)0;
			a = a.normalized;
			Vector3 a2 = new Vector3(a.z, (float)0, -a.x);
			Vector3 vector = num2 * a2 + num * a;
			if (vector != Vector3.zero)
			{
				this.transform.rotation = Quaternion.LookRotation(vector);
			}
		}
		else
		{
			this.Character.animation.CrossFade("f02_idle_00");
		}
		this.rigidbody.velocity = new Vector3((float)0, (float)0, (float)0);
		int num3 = 0;
		Vector3 position = this.transform.position;
		float num4 = position.y = (float)num3;
		Vector3 vector2 = this.transform.position = position;
		if (Input.GetKeyDown("r"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public virtual void Main()
	{
	}
}
