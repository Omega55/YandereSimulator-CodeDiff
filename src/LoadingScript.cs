using System;
using UnityEngine;

[Serializable]
public class LoadingScript : MonoBehaviour
{
	public virtual void Start()
	{
		Application.LoadLevel("SchoolScene");
	}

	public virtual void Main()
	{
	}
}
