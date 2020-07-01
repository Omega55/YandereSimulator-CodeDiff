using System;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
	public float StartingMotion;

	public float DecliningSpeed;

	public float Motion;

	public float PositionX;

	public float Speed;

	public Transform MyCamera;

	public bool Go;

	private void Start()
	{
		this.StartingMotion += UnityEngine.Random.Range(-0.001f, 0.001f);
		this.DecliningSpeed += UnityEngine.Random.Range(-0.001f, 0.001f);
	}

	private void Update()
	{
		base.transform.position += new Vector3(0f, this.Motion, 0f);
		this.Motion -= Time.deltaTime * this.DecliningSpeed;
		if (base.transform.position.y < 0.5f)
		{
			this.Motion = this.StartingMotion;
		}
		if (this.MyCamera != null && this.Go)
		{
			this.Speed += Time.deltaTime;
			this.PositionX = Mathf.Lerp(this.PositionX, -0.999f, Time.deltaTime * this.Speed);
			this.MyCamera.position = new Vector3(this.PositionX, 1f, -10f);
		}
	}
}
