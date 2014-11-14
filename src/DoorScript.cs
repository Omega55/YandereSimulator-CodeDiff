using System;
using UnityEngine;

[Serializable]
public class DoorScript : MonoBehaviour
{
	public DoorBoxScript DoorBox;

	public Transform Player;

	public string Name;

	public virtual void Start()
	{
		this.DoorBox = (DoorBoxScript)GameObject.Find("DoorBox").GetComponent(typeof(DoorBoxScript));
		this.Player = GameObject.Find("SimpleYandereChan").transform;
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.transform.position, this.Player.position) < (float)1)
		{
			this.DoorBox.Label.text = this.Name;
			this.DoorBox.Show = true;
		}
	}

	public virtual void Main()
	{
	}
}
