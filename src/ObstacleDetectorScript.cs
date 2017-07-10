using System;
using UnityEngine;

public class ObstacleDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject ControllerX;

	public GameObject KeyboardX;

	public Collider[] ObstacleArray;

	public int Obstacles;

	public bool Add;

	public int ID;

	private void Start()
	{
		this.ControllerX.SetActive(false);
		this.KeyboardX.SetActive(false);
	}
}
