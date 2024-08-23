using UnityEngine;
using System.Collections;

public class IKHand : MonoBehaviour
{
    #region Vars
    public GameObject handPointerObj;
    public Transform hand;
    Animator anim;
    #endregion

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        hand = anim.GetBoneTransform(HumanBodyBones.RightHand);

	
	}
	
	// Update is called once per frame
	void Update () {
        hand.transform.position = handPointerObj.transform.position;
	}
}
