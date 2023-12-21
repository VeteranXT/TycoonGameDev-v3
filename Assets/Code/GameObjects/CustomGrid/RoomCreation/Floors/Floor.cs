using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
public class Floor : MonoBehaviour
{
    public bool isFloor = false;

    public bool IsFloor { get { return isFloor; }  set { isFloor = value; } }
}

