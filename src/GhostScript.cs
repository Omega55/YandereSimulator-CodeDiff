using System;
using UnityEngine;

[Serializable]
public class GhostScript : MonoBehaviour
{
	public Transform Neck;

	public Transform RightFoot;

	public Transform LeftFoot;

	public GameObject Yandere;

	public virtual void Start()
	{
		this.Yandere = GameObject.Find("YandereChan");
	}

	public virtual void LateUpdate()
	{
		this.Neck.LookAt(this.Yandere.transform.position + Vector3.up * 1.45f);
		float x = this.RightFoot.transform.localEulerAngles.x + (float)45;
		Vector3 localEulerAngles = this.RightFoot.transform.localEulerAngles;
		float num = localEulerAngles.x = x;
		Vector3 vector = this.RightFoot.transform.localEulerAngles = localEulerAngles;
		float x2 = this.LeftFoot.transform.localEulerAngles.x + (float)45;
		Vector3 localEulerAngles2 = this.LeftFoot.transform.localEulerAngles;
		float num2 = localEulerAngles2.x = x2;
		Vector3 vector2 = this.LeftFoot.transform.localEulerAngles = localEulerAngles2;
	}

	public virtual void Main()
	{
	}
}
