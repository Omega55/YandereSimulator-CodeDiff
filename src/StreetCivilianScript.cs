using System;
using Pathfinding;
using UnityEngine;

public class StreetCivilianScript : MonoBehaviour
{
	public CharacterController MyController;

	public Animation MyAnimation;

	public AIPath Pathfinding;

	public Transform[] Destinations;

	public float Timer;

	public int ID;

	private void Start()
	{
		this.Pathfinding.target = this.Destinations[0];
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Destinations[this.ID].position) < 0.55f)
		{
			this.MoveTowardsTarget(this.Destinations[this.ID].position);
			this.MyAnimation.CrossFade("f02_idle_00");
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Timer += Time.deltaTime;
			if (this.Timer > 13.5f)
			{
				this.MyAnimation.CrossFade("f02_newWalk_00");
				this.ID++;
				if (this.ID == this.Destinations.Length)
				{
					this.ID = 0;
				}
				this.Pathfinding.target = this.Destinations[this.ID];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Timer = 0f;
			}
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		float sqrMagnitude = a.sqrMagnitude;
		if (sqrMagnitude > 1E-06f)
		{
			this.MyController.Move(a * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
	}
}
