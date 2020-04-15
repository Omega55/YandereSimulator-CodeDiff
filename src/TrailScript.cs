using System;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<Collider>(), base.GetComponent<Collider>());
		UnityEngine.Object.Destroy(this);
	}
}
