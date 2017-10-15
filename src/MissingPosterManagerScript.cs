using System;
using UnityEngine;

public class MissingPosterManagerScript : MonoBehaviour
{
	public GameObject MissingPoster;

	public int RandomID;

	public int ID;

	private void Start()
	{
		while (this.ID < 101)
		{
			if (StudentGlobals.GetStudentMissing(this.ID))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MissingPoster, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.eulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(-15f, 15f));
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits/Student_",
					this.ID.ToString(),
					".png"
				});
				WWW www = new WWW(url);
				gameObject.GetComponent<UITexture>().mainTexture = www.texture;
				this.RandomID = UnityEngine.Random.Range(1, 3);
				gameObject.transform.localPosition = new Vector3(-17000f + (float)(this.ID * 500), UnityEngine.Random.Range(1300f, 2000f), 0f);
				if (gameObject.transform.localPosition.x > -4000f)
				{
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 8000f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
				}
			}
			this.ID++;
		}
	}
}
