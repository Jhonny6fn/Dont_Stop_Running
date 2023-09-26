using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{

    public static float leftSide = 2f;
    public static float rightSide = 48f;
    public float internalLeft;
    public float internalRight;

    public static float frontSide = -50f;
    public float internalFront;
    public static float backSide = -97f;
    public float internalBack;


    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
        internalFront = frontSide;
        internalBack = backSide;
    }
}
