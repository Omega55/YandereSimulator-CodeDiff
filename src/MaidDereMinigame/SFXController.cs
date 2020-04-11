using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	public class SFXController : MonoBehaviour
	{
		public enum Sounds
		{
			Countdown,
			MenuBack,
			MenuConfirm,
			ClockTick,
			DoorBell,
			GameFail,
			GameSuccess,
			Plate,
			PageTurn,
			MenuSelect,
			MaleCustomerGreet,
			MaleCustomerThank,
			MaleCustomerLeave,
			FemaleCustomerGreet,
			FemaleCustomerThank,
			FemaleCustomerLeave,
			MenuOpen
		}

		private static SFXController instance;

		[Reorderable]
		public SoundEmitters emitters;

		public static SFXController Instance
		{
			get
			{
				if (SFXController.instance == null)
				{
					SFXController.instance = Object.FindObjectOfType<SFXController>();
				}
				return SFXController.instance;
			}
		}

		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			Object.DontDestroyOnLoad(base.gameObject);
		}

		public static void PlaySound(SFXController.Sounds sound)
		{
			SoundEmitter emitter = SFXController.Instance.GetEmitter(sound);
			AudioSource source = emitter.GetSource();
			if (!source.isPlaying || emitter.interupt)
			{
				source.clip = SFXController.Instance.GetRandomClip(emitter);
				source.Play();
			}
		}

		private SoundEmitter GetEmitter(SFXController.Sounds sound)
		{
			foreach (SoundEmitter soundEmitter in this.emitters)
			{
				if (soundEmitter.sound == sound)
				{
					return soundEmitter;
				}
			}
			Debug.Log(string.Format("There is no sound emitter created for {0}", sound), this);
			return null;
		}

		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}
	}
}
