using System;
using UnityEngine;

public class SniperScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 10f)
		{
			if (this.StudentManager.Students[10] != null)
			{
				this.StudentManager.Students[10].BecomeRagdoll();
			}
			if (this.StudentManager.Students[11] != null)
			{
				this.StudentManager.Students[11].BecomeRagdoll();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
