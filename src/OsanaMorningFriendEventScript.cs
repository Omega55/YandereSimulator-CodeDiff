using System;
using UnityEngine;

public class OsanaMorningFriendEventScript : MonoBehaviour
{
	public RivalMorningEventManagerScript OtherEvent;

	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript CurrentSpeaker;

	public StudentScript Friend;

	public StudentScript Rival;

	public Transform Epicenter;

	public Transform[] Location;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public string[] EventAnim;

	public int[] Speaker;

	public AudioClip InterruptedClip;

	public string[] InterruptedSpeech;

	public float[] InterruptedTime;

	public string[] InterruptedAnim;

	public int[] InterruptedSpeaker;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public Quaternion targetRotation;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int SpeechPhase = 1;

	public int FriendID = 6;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;
}
