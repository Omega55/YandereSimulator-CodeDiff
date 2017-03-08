using System;
using UnityEngine;

[Serializable]
public class YandereKunScript : MonoBehaviour
{
	public Transform ChanHips;

	public Transform ChanSpine;

	public Transform ChanSpine1;

	public Transform ChanSpine2;

	public Transform ChanSpine3;

	public Transform ChanNeck;

	public Transform ChanHead;

	public Transform ChanRightUpLeg;

	public Transform ChanRightLeg;

	public Transform ChanRightFoot;

	public Transform ChanRightToes;

	public Transform ChanLeftUpLeg;

	public Transform ChanLeftLeg;

	public Transform ChanLeftFoot;

	public Transform ChanLeftToes;

	public Transform ChanRightShoulder;

	public Transform ChanRightArm;

	public Transform ChanRightArmRoll;

	public Transform ChanRightForeArm;

	public Transform ChanRightForeArmRoll;

	public Transform ChanRightHand;

	public Transform ChanLeftShoulder;

	public Transform ChanLeftArm;

	public Transform ChanLeftArmRoll;

	public Transform ChanLeftForeArm;

	public Transform ChanLeftForeArmRoll;

	public Transform ChanLeftHand;

	public Transform ChanLeftHandPinky1;

	public Transform ChanLeftHandPinky2;

	public Transform ChanLeftHandPinky3;

	public Transform ChanLeftHandRing1;

	public Transform ChanLeftHandRing2;

	public Transform ChanLeftHandRing3;

	public Transform ChanLeftHandMiddle1;

	public Transform ChanLeftHandMiddle2;

	public Transform ChanLeftHandMiddle3;

	public Transform ChanLeftHandIndex1;

	public Transform ChanLeftHandIndex2;

	public Transform ChanLeftHandIndex3;

	public Transform ChanLeftHandThumb1;

	public Transform ChanLeftHandThumb2;

	public Transform ChanLeftHandThumb3;

	public Transform ChanRightHandPinky1;

	public Transform ChanRightHandPinky2;

	public Transform ChanRightHandPinky3;

	public Transform ChanRightHandRing1;

	public Transform ChanRightHandRing2;

	public Transform ChanRightHandRing3;

	public Transform ChanRightHandMiddle1;

	public Transform ChanRightHandMiddle2;

	public Transform ChanRightHandMiddle3;

	public Transform ChanRightHandIndex1;

	public Transform ChanRightHandIndex2;

	public Transform ChanRightHandIndex3;

	public Transform ChanRightHandThumb1;

	public Transform ChanRightHandThumb2;

	public Transform ChanRightHandThumb3;

	public Transform KunHips;

	public Transform KunSpine;

	public Transform KunSpine1;

	public Transform KunSpine2;

	public Transform KunSpine3;

	public Transform KunNeck;

	public Transform KunHead;

	public Transform KunRightUpLeg;

	public Transform KunRightLeg;

	public Transform KunRightFoot;

	public Transform KunRightToes;

	public Transform KunLeftUpLeg;

	public Transform KunLeftLeg;

	public Transform KunLeftFoot;

	public Transform KunLeftToes;

	public Transform KunRightShoulder;

	public Transform KunRightArm;

	public Transform KunRightArmRoll;

	public Transform KunRightForeArm;

	public Transform KunRightForeArmRoll;

	public Transform KunRightHand;

	public Transform KunLeftShoulder;

	public Transform KunLeftArm;

	public Transform KunLeftArmRoll;

	public Transform KunLeftForeArm;

	public Transform KunLeftForeArmRoll;

	public Transform KunLeftHand;

	public Transform KunLeftHandPinky1;

	public Transform KunLeftHandPinky2;

	public Transform KunLeftHandPinky3;

	public Transform KunLeftHandRing1;

	public Transform KunLeftHandRing2;

	public Transform KunLeftHandRing3;

	public Transform KunLeftHandMiddle1;

	public Transform KunLeftHandMiddle2;

	public Transform KunLeftHandMiddle3;

	public Transform KunLeftHandIndex1;

	public Transform KunLeftHandIndex2;

	public Transform KunLeftHandIndex3;

	public Transform KunLeftHandThumb1;

	public Transform KunLeftHandThumb2;

	public Transform KunLeftHandThumb3;

	public Transform KunRightHandPinky1;

	public Transform KunRightHandPinky2;

	public Transform KunRightHandPinky3;

	public Transform KunRightHandRing1;

	public Transform KunRightHandRing2;

	public Transform KunRightHandRing3;

	public Transform KunRightHandMiddle1;

	public Transform KunRightHandMiddle2;

	public Transform KunRightHandMiddle3;

	public Transform KunRightHandIndex1;

	public Transform KunRightHandIndex2;

	public Transform KunRightHandIndex3;

	public Transform KunRightHandThumb1;

	public Transform KunRightHandThumb2;

	public Transform KunRightHandThumb3;

	public SkinnedMeshRenderer MyRenderer;

	public virtual void Start()
	{
		this.KunHips.parent = this.ChanHips;
		this.KunSpine.parent = this.ChanSpine;
		this.KunSpine1.parent = this.ChanSpine1;
		this.KunSpine2.parent = this.ChanSpine2;
		this.KunSpine3.parent = this.ChanSpine3;
		this.KunNeck.parent = this.ChanNeck;
		this.KunHead.parent = this.ChanHead;
		this.KunRightUpLeg.parent = this.ChanRightUpLeg;
		this.KunRightLeg.parent = this.ChanRightLeg;
		this.KunRightFoot.parent = this.ChanRightFoot;
		this.KunRightToes.parent = this.ChanRightToes;
		this.KunLeftUpLeg.parent = this.ChanLeftUpLeg;
		this.KunLeftLeg.parent = this.ChanLeftLeg;
		this.KunLeftFoot.parent = this.ChanLeftFoot;
		this.KunLeftToes.parent = this.ChanLeftToes;
		this.KunRightShoulder.parent = this.ChanRightShoulder;
		this.KunRightArm.parent = this.ChanRightArm;
		this.KunRightArmRoll.parent = this.ChanRightArmRoll;
		this.KunRightForeArm.parent = this.ChanRightForeArm;
		this.KunRightForeArmRoll.parent = this.ChanRightForeArmRoll;
		this.KunRightHand.parent = this.ChanRightHand;
		this.KunLeftShoulder.parent = this.ChanLeftShoulder;
		this.KunLeftArm.parent = this.ChanLeftArm;
		this.KunLeftArmRoll.parent = this.ChanLeftArmRoll;
		this.KunLeftForeArmRoll.parent = this.ChanLeftForeArmRoll;
		this.KunLeftForeArm.parent = this.ChanLeftForeArm;
		this.KunLeftHand.parent = this.ChanLeftHand;
		this.KunLeftHandPinky1.parent = this.ChanLeftHandPinky1;
		this.KunLeftHandPinky2.parent = this.ChanLeftHandPinky2;
		this.KunLeftHandPinky3.parent = this.ChanLeftHandPinky3;
		this.KunLeftHandRing1.parent = this.ChanLeftHandRing1;
		this.KunLeftHandRing2.parent = this.ChanLeftHandRing2;
		this.KunLeftHandRing3.parent = this.ChanLeftHandRing3;
		this.KunLeftHandMiddle1.parent = this.ChanLeftHandMiddle1;
		this.KunLeftHandMiddle2.parent = this.ChanLeftHandMiddle2;
		this.KunLeftHandMiddle3.parent = this.ChanLeftHandMiddle3;
		this.KunLeftHandIndex1.parent = this.ChanLeftHandIndex1;
		this.KunLeftHandIndex2.parent = this.ChanLeftHandIndex2;
		this.KunLeftHandIndex3.parent = this.ChanLeftHandIndex3;
		this.KunLeftHandThumb1.parent = this.ChanLeftHandThumb1;
		this.KunLeftHandThumb2.parent = this.ChanLeftHandThumb2;
		this.KunLeftHandThumb3.parent = this.ChanLeftHandThumb3;
		this.KunRightHandPinky1.parent = this.ChanRightHandPinky1;
		this.KunRightHandPinky2.parent = this.ChanRightHandPinky2;
		this.KunRightHandPinky3.parent = this.ChanRightHandPinky3;
		this.KunRightHandRing1.parent = this.ChanRightHandRing1;
		this.KunRightHandRing2.parent = this.ChanRightHandRing2;
		this.KunRightHandRing3.parent = this.ChanRightHandRing3;
		this.KunRightHandMiddle1.parent = this.ChanRightHandMiddle1;
		this.KunRightHandMiddle2.parent = this.ChanRightHandMiddle2;
		this.KunRightHandMiddle3.parent = this.ChanRightHandMiddle3;
		this.KunRightHandIndex1.parent = this.ChanRightHandIndex1;
		this.KunRightHandIndex2.parent = this.ChanRightHandIndex2;
		this.KunRightHandIndex3.parent = this.ChanRightHandIndex3;
		this.KunRightHandThumb1.parent = this.ChanRightHandThumb1;
		this.KunRightHandThumb2.parent = this.ChanRightHandThumb2;
		this.KunRightHandThumb3.parent = this.ChanRightHandThumb3;
		this.MyRenderer.enabled = true;
		this.active = false;
	}

	public virtual void Main()
	{
	}
}
