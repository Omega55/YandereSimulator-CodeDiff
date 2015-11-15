using System;
using UnityEngine;

[Serializable]
public class LowPolyStudentScript : MonoBehaviour
{
	public SkinnedMeshRenderer CharacterMesh;

	public Renderer MyMesh;

	public Transform Yandere;

	public virtual void Start()
	{
		UnityEngine.Object.Destroy(this);
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.transform.position) > (float)20)
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

	public virtual void Main()
	{
	}
}
