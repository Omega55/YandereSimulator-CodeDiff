using System;
using UnityEngine;

[Serializable]
public class RandomPatrolScript : MonoBehaviour
{
	public Transform[] PatrolPoints;

	public int[] Height;

	public virtual void Start()
	{
		for (int i = 1; i < 5; i++)
		{
			this.Height[i] = UnityEngine.Random.Range(1, 5);
			if (this.Height[i] == 1)
			{
				this.Height[i] = 0;
			}
			else if (this.Height[i] == 2)
			{
				this.Height[i] = 4;
			}
			else if (this.Height[i] == 3)
			{
				this.Height[i] = 8;
			}
			else if (this.Height[i] == 4)
			{
				this.Height[i] = 12;
			}
		}
		this.PatrolPoints[1].position = new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height[1], UnityEngine.Random.Range(21f, 19f));
		this.PatrolPoints[2].position = new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height[2], UnityEngine.Random.Range(29f, -37f));
		this.PatrolPoints[3].position = new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height[3], UnityEngine.Random.Range(-21f, -19f));
		this.PatrolPoints[4].position = new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height[4], UnityEngine.Random.Range(29f, -37f));
		float y = UnityEngine.Random.Range((float)0, 360f);
		Vector3 localEulerAngles = this.PatrolPoints[1].localEulerAngles;
		float num = localEulerAngles.y = y;
		Vector3 vector = this.PatrolPoints[1].localEulerAngles = localEulerAngles;
		float y2 = UnityEngine.Random.Range((float)0, 360f);
		Vector3 localEulerAngles2 = this.PatrolPoints[2].localEulerAngles;
		float num2 = localEulerAngles2.y = y2;
		Vector3 vector2 = this.PatrolPoints[2].localEulerAngles = localEulerAngles2;
		float y3 = UnityEngine.Random.Range((float)0, 360f);
		Vector3 localEulerAngles3 = this.PatrolPoints[3].localEulerAngles;
		float num3 = localEulerAngles3.y = y3;
		Vector3 vector3 = this.PatrolPoints[3].localEulerAngles = localEulerAngles3;
		float y4 = UnityEngine.Random.Range((float)0, 360f);
		Vector3 localEulerAngles4 = this.PatrolPoints[4].localEulerAngles;
		float num4 = localEulerAngles4.y = y4;
		Vector3 vector4 = this.PatrolPoints[4].localEulerAngles = localEulerAngles4;
	}

	public virtual void Main()
	{
	}
}
