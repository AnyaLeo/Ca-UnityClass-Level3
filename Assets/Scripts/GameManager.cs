using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Transform endPoint;
    public Transform endPointNotStatic;

    private void Start()
    {
        endPoint = endPointNotStatic;
    }
}
