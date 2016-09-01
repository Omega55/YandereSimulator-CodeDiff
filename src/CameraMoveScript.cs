using System;
using UnityEngine;

[Serializable]
public class CameraMoveScript : MonoBehaviour
{
	public Transform StartPos;

	public Transform EndPos;

	public Transform RightDoor;

	public Transform LeftDoor;

	public Transform Target;

	public bool OpenDoors;

	public bool Begin;

	public float Speed;

	public float Timer;

	public virtual void Start()
	{
		this.transform.position = this.StartPos.position;
		this.transform.rotation = this.StartPos.rotation;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Begin = true;
		}
		if (this.Begin)
		{
			this.Timer += Time.deltaTime * this.Speed;
			if (this.Timer > 0.1f)
			{
				this.OpenDoors = true;
				if (this.LeftDoor != null)
				{
					float x = Mathf.Lerp(this.LeftDoor.transform.localPosition.x, (float)1, Time.deltaTime);
					Vector3 localPosition = this.LeftDoor.transform.localPosition;
					float num = localPosition.x = x;
					Vector3 vector = this.LeftDoor.transform.localPosition = localPosition;
					float x2 = Mathf.Lerp(this.RightDoor.transform.localPosition.x, (float)-1, Time.deltaTime);
					Vector3 localPosition2 = this.RightDoor.transform.localPosition;
					float num2 = localPosition2.x = x2;
					Vector3 vector2 = this.RightDoor.transform.localPosition = localPosition2;
				}
			}
			this.transform.position = Vector3.Lerp(this.transform.position, this.EndPos.position, Time.deltaTime * this.Timer);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.EndPos.rotation, Time.deltaTime * this.Timer);
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Target != null)
		{
			this.transform.LookAt(this.Target);
		}
	}

	public virtual void Main()
	{
	}
}
