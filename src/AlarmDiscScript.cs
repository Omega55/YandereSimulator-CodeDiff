using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AlarmDiscScript : MonoBehaviour
{
	public AudioClip[] LongFemaleScreams;

	public AudioClip[] LongMaleScreams;

	public AudioClip[] FemaleScreams;

	public AudioClip[] MaleScreams;

	public StudentScript Originator;

	public RadioScript SourceRadio;

	public StudentScript Student;

	public bool NoScream;

	public bool Shocking;

	public bool Radio;

	public bool Male;

	public bool Long;

	public int Frame;

	public virtual void Start()
	{
		float x = this.transform.localScale.x * ((float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
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
			if (!this.Long)
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
			else if (!this.Male)
			{
				this.PlayClip(this.LongFemaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.LongFemaleScreams))], this.transform.position);
			}
			else
			{
				this.PlayClip(this.LongMaleScreams[UnityEngine.Random.Range(0, Extensions.get_length(this.LongMaleScreams))], this.transform.position);
			}
		}
		this.Frame++;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null)
			{
				if (!this.Radio)
				{
					if (this.Student != this.Originator && !this.Student.TurnOffRadio && !this.Student.Dead && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse)
					{
						if (this.Student.Male)
						{
						}
						this.Student.Character.animation.CrossFade(this.Student.LeanAnim);
						if (this.Originator != null)
						{
							if (this.Originator.WitnessedMurder)
							{
								this.Student.DistractionSpot = new Vector3(this.transform.position.x, this.Student.Yandere.transform.position.y, this.transform.position.z);
							}
							else if (this.Originator.Corpse == null)
							{
								this.Student.DistractionSpot = new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z);
							}
							else
							{
								this.Student.DistractionSpot = new Vector3(this.Originator.Corpse.transform.position.x, this.Student.transform.position.y, this.Originator.Corpse.transform.position.z);
							}
						}
						else
						{
							this.Student.DistractionSpot = new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z);
						}
						this.Student.DiscCheck = true;
						if (this.Shocking)
						{
							this.Student.Hesitation = 0.5f;
						}
						this.Student.Alarm = (float)200;
					}
				}
				else if (!this.Student.Male && !this.Student.Dead && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.InEvent && this.Student.CharacterAnimation != null && this.SourceRadio.Victim == null)
				{
					this.Student.CharacterAnimation.CrossFade(this.Student.LeanAnim);
					this.Student.Pathfinding.canSearch = false;
					this.Student.Pathfinding.canMove = false;
					this.Student.Radio = this.SourceRadio;
					this.Student.TurnOffRadio = true;
					this.Student.Routine = false;
					this.SourceRadio.Victim = this.Student;
				}
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
