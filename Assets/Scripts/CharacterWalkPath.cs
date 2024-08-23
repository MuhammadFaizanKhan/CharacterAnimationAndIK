using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Attach this script to parent object of walk path points.
/// </summary>
public class CharacterWalkPath : MonoBehaviour
{

    public List<Vector3> pathPositions;
    public Animator walkingCharacter;
     float walkingSpeed = 2.5f;
    public int pathIndex = 0;

    public bool isShowTestingLog = false;
    int i = 1;



    void Reset()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            pathPositions.Add(this.transform.GetChild(i).position);//Add Path positions.
        }

    }


    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(pathPositions[pathIndex], walkingCharacter.transform.position) > 0.5f && walkingCharacter.GetBool("StartWalk"))
        {
            Vector3 newPosition = (pathPositions[pathIndex] - walkingCharacter.transform.position).normalized;
              
            walkingCharacter.transform.position += newPosition * Time.deltaTime * walkingSpeed;
            walkingCharacter.transform.rotation = Quaternion.LookRotation(newPosition);
            //walkingCharacter.transform.position = Vector3.MoveTowards(walkingCharacter.transform.position, pathPositions[0], Time.deltaTime * 2);
            if (isShowTestingLog)
            {
                GameObject newGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newGo.transform.position = newPosition;
                newGo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                newGo.name = i.ToString();
                i++;
            }
        }
        else if(walkingCharacter.GetBool("StartWalk"))
        {
            pathIndex++;
           // SetIdleStaringNail();
        }


    }

    void SetStateIdleStaringNail()
    {
        DeactiveAllStates(false);
        walkingCharacter.SetBool("Idle", true);
    }

    void SetStateWalk()
    {
        DeactiveAllStates(false);
        walkingCharacter.SetBool("StartWalk", true);
    }

    void DeactiveAllStates(bool isActive)
    {
        walkingCharacter.SetBool("Idle", isActive);
        walkingCharacter.SetBool("StartWalk", isActive);
    }

    void OnGUI() {
        if (GUI.Button(new Rect(0, 0, 100, 100), "walk on path")) {
            SetStateWalk();
        }
    }
}
