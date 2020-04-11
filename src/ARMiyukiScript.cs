using System;
using UnityEngine;

public class ARMiyukiScript : MonoBehaviour
{
	public Transform BulletSpawnPoint;

	public StudentScript MyStudent;

	public YandereScript Yandere;

	public GameObject Bullet;

	public Transform Enemy;

	public GameObject MagicalGirl;

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
		if (this.Enemy == null)
		{
			this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
		}
		base.transform.LookAt(this.Enemy.position);
		Object.Instantiate<GameObject>(this.Bullet, this.BulletSpawnPoint.position, base.transform.rotation);
	}
}
