using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StudentScript : MonoBehaviour
{
	public AIPath Pathfinding;

	public ClockScript Clock;

	public Transform CurrentDestination;

	public Transform[] Destinations;

	public Transform[] Focuses;

	public float[] PhaseTimes;

	public GameObject Character;

	public float Distance;

	public int Phase;

	public virtual void Update()
	{
		if (this.Phase < Extensions.get_length(this.PhaseTimes) - 1 && this.Clock.PresentTime / (float)60 >= this.PhaseTimes[this.Phase])
		{
			this.Phase++;
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
		}
		this.Distance = Vector3.Distance(this.transform.position, this.CurrentDestination.position);
		if (this.Distance > 0.5f)
		{
			this.Character.animation.CrossFade("f02_walk_00");
			this.Character.animation["f02_walk_00"].speed = this.Pathfinding.currentSpeed;
		}
		else
		{
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.Character.animation.CrossFade("f02_idleShort_00");
			this.transform.position = Vector3.Lerp(this.transform.position, this.CurrentDestination.position, Time.deltaTime * (float)10);
			Quaternion to = Quaternion.LookRotation(this.Focuses[this.Phase].position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, (float)10 * Time.deltaTime);
		}
	}

	public virtual void Main()
	{
	}
}
