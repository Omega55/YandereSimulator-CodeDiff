using System;
using System.Collections;
using UnityEngine;

public class ModelSwapScript : MonoBehaviour
{
	public Transform PelvisRoot;

	public GameObject Attachment;

	public void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.Attach(this.Attachment, true);
		}
	}

	public void Attach(GameObject Attachment, bool Inactives)
	{
		base.StartCoroutine(this.Attach_Threat(this.PelvisRoot, Attachment, Inactives));
	}

	public IEnumerator Attach_Threat(Transform PelvisRoot, GameObject Attachment, bool Inactives)
	{
		Attachment.transform.SetParent(PelvisRoot);
		PelvisRoot.localEulerAngles = Vector3.zero;
		PelvisRoot.localPosition = Vector3.zero;
		Transform[] StudentBones = PelvisRoot.GetComponentsInChildren<Transform>(Inactives);
		Transform[] Bones = Attachment.GetComponentsInChildren<Transform>(Inactives);
		foreach (Transform transform in Bones)
		{
			foreach (Transform transform2 in StudentBones)
			{
				if (transform.name == transform2.name)
				{
					transform.SetParent(transform2);
					transform.localEulerAngles = Vector3.zero;
					transform.localPosition = Vector3.zero;
				}
			}
		}
		yield return null;
		yield break;
	}
}
