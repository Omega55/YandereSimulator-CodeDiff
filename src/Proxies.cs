using System;
using UnityEngine;

public class Proxies : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.Destroy(base.GetComponent<MeshRenderer>());
		UnityEngine.Object.Destroy(base.GetComponent<MeshFilter>());
		UnityEngine.Object.Destroy(this);
	}
}
