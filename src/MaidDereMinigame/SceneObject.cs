using System;
using UnityEngine;

namespace MaidDereMinigame
{
	[CreateAssetMenu(fileName = "New Scene Object", menuName = "Scenes/New Scene Object")]
	[Serializable]
	public class SceneObject : ScriptableObject
	{
		public int sceneBuildNumber = -1;
	}
}
