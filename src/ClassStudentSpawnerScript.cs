using System;
using UnityEngine;

[Serializable]
public class ClassStudentSpawnerScript : MonoBehaviour
{
	public GameObject ClassroomChan;

	public int Students;

	public int Column;

	public int Row;

	public ClassStudentSpawnerScript()
	{
		this.Students = 36;
	}

	public virtual void Start()
	{
		int i = 0;
		while (i < this.Students)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.ClassroomChan, this.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.transform;
			gameObject.transform.localScale = new Vector3(1.818182f, 1.818182f, 1.818182f);
			if (i < 6)
			{
				this.Row = 0;
			}
			else if (i < 12)
			{
				this.Row = 1;
			}
			else if (i < 18)
			{
				this.Row = 2;
			}
			else if (i < 24)
			{
				this.Row = 3;
			}
			else if (i < 30)
			{
				this.Row = 4;
			}
			float z = (float)6 - 2.4f * (float)this.Column;
			Vector3 localPosition = gameObject.transform.localPosition;
			float num = localPosition.z = z;
			Vector3 vector = gameObject.transform.localPosition = localPosition;
			float x = 4.2f - (float)(2 * this.Row);
			Vector3 localPosition2 = gameObject.transform.localPosition;
			float num2 = localPosition2.x = x;
			Vector3 vector2 = gameObject.transform.localPosition = localPosition2;
			this.Column++;
			if (this.Column > 5)
			{
				this.Column = 0;
			}
			i++;
			if (i == this.Students)
			{
				((ClassStudentScript)gameObject.GetComponent(typeof(ClassStudentScript))).YandereChan = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
