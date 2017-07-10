using System;
using UnityEngine;

public class LowPolyStudentScript : MonoBehaviour
{
	public StudentScript Student;

	public SkinnedMeshRenderer CharacterMesh;

	public Renderer TeacherMesh;

	public Renderer MyMesh;

	private void Update()
	{
		if ((float)this.Student.StudentManager.LowDetailThreshold > 0f)
		{
			float num = Vector3.Distance(this.Student.Yandere.MainCamera.transform.position, base.transform.position);
			if (num > (float)this.Student.StudentManager.LowDetailThreshold)
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
}
