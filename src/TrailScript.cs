using System;
using UnityEngine;

[Serializable]
public class TrailScript : MonoBehaviour
{
	public virtual void Start()
	{
		GameObject gameObject = GameObject.Find("YandereChan");
		Physics.IgnoreCollision(gameObject.collider, this.collider);
		UnityEngine.Object.Destroy(this);
	}

	public virtual void Main()
	{
	}
}
