using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;
    public string[] staticDirections = { "Static N", "Static W", "Static S", "Static E"};
    public string[] runDirections = { "Run N", "Run W", "Run S", "Run E"};
    int lastDirection;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1" + result1);

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        Debug.Log("R2" + result2);

        float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
        Debug.Log("R3" + result3);
    }

    public void SetDirection(Vector2 _direction)
    {
        string[] directionArray = null;
        if (_direction.magnitude < 0.02)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(_direction);
        }
        anim.Play(directionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 _direction)
    {

        Vector2 norDir = _direction.normalized;
        float step = 360 / 4;
        float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
