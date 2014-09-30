using System;
using UnityEngine;

[Serializable]
public class LimbScript : MonoBehaviour
{
	public GameObject Target;

	public bool Dragging;

	public virtual void Update()
	{
		if (this.Target == null)
		{
			this.Target = GameObject.Find("ItemParent");
		}
		else if (this.Dragging)
		{
			this.rigidbody.AddForce((this.Target.transform.position - this.transform.position) * (float)20000);
		}
	}

	public virtual void Main()
	{
	}
}
