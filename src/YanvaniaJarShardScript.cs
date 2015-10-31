using System;
using UnityEngine;

[Serializable]
public class YanvaniaJarShardScript : MonoBehaviour
{
	public float MyRotation;

	public float Rotation;

	public virtual void Start()
	{
		this.Rotation = (float)NGUITools.RandomRange((int)-360f, (int)360f);
		this.rigidbody.AddForce(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range((float)0, 100f), UnityEngine.Random.Range(-100f, 100f));
	}

	public virtual void Update()
	{
		this.MyRotation += this.Rotation;
		float myRotation = this.MyRotation;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num = eulerAngles.x = myRotation;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
		float myRotation2 = this.MyRotation;
		Vector3 eulerAngles2 = this.transform.eulerAngles;
		float num2 = eulerAngles2.y = myRotation2;
		Vector3 vector2 = this.transform.eulerAngles = eulerAngles2;
		float myRotation3 = this.MyRotation;
		Vector3 eulerAngles3 = this.transform.eulerAngles;
		float num3 = eulerAngles3.z = myRotation3;
		Vector3 vector3 = this.transform.eulerAngles = eulerAngles3;
		if (this.transform.position.y < 6.5f)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
