using System;
using UnityEngine;

public class ARMiyukiScript : MonoBehaviour
{
	public Transform BulletSpawnPoint;

	public StudentScript MyStudent;

	public YandereScript Yandere;

	public GameObject Bullet;

	public Transform Enemy;

	public bool Student;

	private void Start()
	{
		if (this.Enemy == null)
		{
			this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
		}
	}

	private void Update()
	{
		if (!this.Student && this.Yandere.AR)
		{
			base.transform.LookAt(this.Enemy.position);
			if (Input.GetButtonDown("X"))
			{
				this.Shoot();
			}
		}
	}

	public void Shoot()
	{
		base.transform.LookAt(this.Enemy.position);
		UnityEngine.Object.Instantiate<GameObject>(this.Bullet, this.BulletSpawnPoint.position, base.transform.rotation);
	}
}
