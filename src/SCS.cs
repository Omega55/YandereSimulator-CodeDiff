using System;
using UnityEngine;

[Serializable]
public class SCS : MonoBehaviour
{
	public Transform Player;

	public float CloudsSpeed;

	private float distance;

	private int height;

	private int heightDamping;

	private int rotationDamping;

	public SCS()
	{
		this.distance = 10f;
	}

	public virtual void Update()
	{
		this.transform.Rotate((float)0, Time.deltaTime * this.CloudsSpeed, (float)0);
	}

	public virtual void LateUpdate()
	{
		if (this.Player)
		{
			float to = this.Player.position.y + (float)this.height;
			float num = this.transform.position.y;
			num = Mathf.Lerp(num, to, (float)this.heightDamping * Time.deltaTime);
			this.transform.position = this.Player.position;
			float y = num;
			Vector3 position = this.transform.position;
			float num2 = position.y = y;
			Vector3 vector = this.transform.position = position;
		}
	}

	public virtual void Main()
	{
	}
}
