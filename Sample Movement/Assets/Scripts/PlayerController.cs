using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum LANE{ Left, Mid, Right}
public class PlayerController : MonoBehaviour
{
    public LANE mLane = LANE.Mid;
    public float newXPos = 0f;
    public bool goRight;
    public bool goLeft;
    public float xPosition;
    private CharacterController charControl;
    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        goRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        goLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        if (goRight)
        {
            if (mLane == LANE.Mid)
            {
                newXPos = xPosition;
                mLane = LANE.Right;
            }
            else if (mLane == LANE.Left)
            {
                newXPos = 0;
                mLane = LANE.Mid;
            }
        }
        else if (goLeft)
        {
            if (mLane == LANE.Mid)
            {
                newXPos = -xPosition;
                mLane = LANE.Left;
            }
            else if (mLane == LANE.Right)
            {
                newXPos = 0;
                mLane = LANE.Mid;
            }
        }
        charControl.Move((newXPos - transform.position.x) * Vector3.right);
    }
}
