using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AlarmDiscScript : MonoBehaviour
{
	public AudioClip[] FemaleScreams;

	public AudioClip[] MaleScreams;

	public StudentScript Student;

	public bool NoScream;

	public bool Male;

	public int Frame;

	public virtual void Start()
	{
		float x = (float)500 * ((float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
		Vector3 localScale = this.transform.localScale;
		float num = localScale.x = x;
		Vector3 vector = this.transform.localScale = localScale;
		float x2 = this.transform.localScale.x;
		Vector3 localScale2 = this.transform.localScale;
		float num2 = localScale2.z = x2;
		Vector3 vector2 = this.transform.localScale = localScale2;
	}

	public virtual void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		else if (!this.NoScream)
		{
			if (!this.Male)
			{
				this.PlayClip(this.FemaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.FemaleScreams))], this.transform.position);
			}
			else
			{
				this.PlayClip(this.MaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.MaleScreams))], this.transform.position);
			}
		}
		this.Frame++;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null && !this.Student.Alarmed)
			{
				this.Student.DiscCheck = true;
				this.Student.Alarm = (float)200;
			}
		}
	}

	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
		audioSource.volume = 0.5f;
		if (this.Student != null)
		{
			this.Student.DeathScream = gameObject;
		}
	}

	public virtual void Main()
	{
	}
}
