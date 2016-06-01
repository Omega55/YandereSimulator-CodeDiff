using System;
using UnityEngine;

[Serializable]
public class ObstacleDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject ControllerX;

	public GameObject KeyboardX;

	public Collider[] ObstacleArray;

	public int Obstacles;

	public bool Add;

	public int ID;

	public virtual void Start()
	{
		this.ControllerX.active = false;
		this.KeyboardX.active = false;
	}

	public virtual void Main()
	{
	}
}
