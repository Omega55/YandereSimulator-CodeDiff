using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	[Serializable]
	public class SoundEmitter
	{
		public SFXController.Sounds sound;

		public bool interupt;

		[Reorderable]
		public AudioSources sources;

		[Reorderable]
		public AudioClips clips;

		public AudioSource GetSource()
		{
			for (int i = 0; i < this.sources.Count; i++)
			{
				if (!this.sources[i].isPlaying)
				{
					return this.sources[i];
				}
			}
			return this.sources[0];
		}
	}
}
