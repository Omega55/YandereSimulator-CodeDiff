using System;
using UnityEngine;

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

	private void Start()
	{
		Vector3 localScale = base.transform.localScale;
		localScale.x *= 2f - SchoolGlobals.SchoolAtmosphere;
		localScale.z = localScale.x;
		base.transform.localScale = localScale;
	}

	private void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (!this.NoScream)
		{
			if (!this.Long)
			{
				if (!this.Male)
				{
					this.PlayClip(this.FemaleScreams[UnityEngine.Random.Range(0, this.FemaleScreams.Length)], base.transform.position);
				}
				else
				{
					this.PlayClip(this.MaleScreams[UnityEngine.Random.Range(0, this.MaleScreams.Length)], base.transform.position);
				}
			}
			else if (!this.Male)
			{
				this.PlayClip(this.LongFemaleScreams[UnityEngine.Random.Range(0, this.LongFemaleScreams.Length)], base.transform.position);
			}
			else
			{
				this.PlayClip(this.LongMaleScreams[UnityEngine.Random.Range(0, this.LongMaleScreams.Length)], base.transform.position);
			}
		}
		this.Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student != null)
			{
				if (!this.Radio)
				{
					if (this.Student != this.Originator && !this.Student.TurnOffRadio && this.Student.Alive && !this.Student.Pushed && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.CheckingNote && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse)
					{
						if (this.Student.Male)
						{
						}
						this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.LeanAnim);
						if (this.Originator != null)
						{
							if (this.Originator.WitnessedMurder)
							{
								this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.Yandere.transform.position.y, base.transform.position.z);
							}
							else if (this.Originator.Corpse == null)
							{
								this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
							}
							else
							{
								this.Student.DistractionSpot = new Vector3(this.Originator.Corpse.transform.position.x, this.Student.transform.position.y, this.Originator.Corpse.transform.position.z);
							}
						}
						else
						{
							this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
						}
						this.Student.DiscCheck = true;
						if (this.Shocking)
						{
							this.Student.Hesitation = 0.5f;
						}
						this.Student.Alarm = 200f;
					}
				}
				else if (!this.Student.Nemesis && this.Student.Alive && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.InEvent && !this.Student.Following && !this.Student.Distracting && !this.Student.GoAway && this.Student.Routine && !this.Student.CheckingNote && this.Student.CharacterAnimation != null && this.SourceRadio.Victim == null)
				{
					this.Student.CharacterAnimation.CrossFade(this.Student.LeanAnim);
					this.Student.Pathfinding.canSearch = false;
					this.Student.Pathfinding.canMove = false;
					this.Student.Radio = this.SourceRadio;
					this.Student.TurnOffRadio = true;
					this.Student.Routine = false;
					this.Student.GoAway = false;
					this.Student.OccultBook.SetActive(false);
					this.Student.Pen.SetActive(false);
					this.Student.SpeechLines.Stop();
					this.Student.RadioTimer = 0f;
					this.Student.ReadPhase = 0;
					this.SourceRadio.Victim = this.Student;
				}
			}
		}
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		audioSource.volume = 0.5f;
		if (this.Student != null)
		{
			this.Student.DeathScream = gameObject;
		}
	}
}
