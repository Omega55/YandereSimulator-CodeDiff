using System;
using UnityEngine;

[Serializable]
public class HomeMangaBookScript : MonoBehaviour
{
	public HomeMangaScript Manga;

	public float RotationSpeed;

	public int ID;

	public virtual void Start()
	{
		int num = 90;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.x = (float)num;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
	}

	public virtual void Update()
	{
		if (this.Manga.Selected == this.ID)
		{
			float y = this.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed;
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = this.transform.eulerAngles = eulerAngles;
		}
		else
		{
			int num2 = 0;
			Vector3 eulerAngles2 = this.transform.eulerAngles;
			float num3 = eulerAngles2.y = (float)num2;
			Vector3 vector2 = this.transform.eulerAngles = eulerAngles2;
		}
	}

	public virtual void Main()
	{
	}
}
