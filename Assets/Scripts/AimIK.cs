using UnityEngine;

/// <summary>
/// Use IK for particular Bone
/// </summary>
public class AimIK : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    Animator anim;
    Transform boneTransform;

    public HumanBodyBones boneForIK;

	void Start () {
        anim = GetComponent<Animator>();
        //chest = anim.GetBoneTransform(HumanBodyBones.Chest);
        boneTransform = anim.GetBoneTransform(boneForIK);

    }
	
	
	void LateUpdate () {
        boneTransform.LookAt(target.position);
        boneTransform.rotation = boneTransform.rotation * Quaternion.Euler(offset);
	
	}
}
