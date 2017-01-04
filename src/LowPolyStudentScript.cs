using System;
using UnityEngine;

[Serializable]
public class LowPolyStudentScript : MonoBehaviour
{
	public StudentScript Student;

	public SkinnedMeshRenderer CharacterMesh;

	public Renderer TeacherMesh;

	public Renderer MyMesh;

	public virtual void Update()
	{
		if (this.Student.StudentManager.LowDetailThreshold > 0)
		{
			if (Vector3.Distance(this.Student.Yandere.MainCamera.transform.position, this.transform.position) > (float)this.Student.StudentManager.LowDetailThreshold)
			{
				if (!this.MyMesh.enabled)
				{
					this.CharacterMesh.enabled = false;
					this.MyMesh.enabled = true;
				}
			}
			else if (this.MyMesh.enabled)
			{
				this.CharacterMesh.enabled = true;
				this.MyMesh.enabled = false;
			}
		}
		else if (this.MyMesh.enabled)
		{
			this.CharacterMesh.enabled = true;
			this.MyMesh.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
