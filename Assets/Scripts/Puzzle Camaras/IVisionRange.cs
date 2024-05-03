using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisionRange 
{
    public void DistanceTarget(Vector3 target);
    public void DetectedPlayer();
    public void OutOfRange();
}
