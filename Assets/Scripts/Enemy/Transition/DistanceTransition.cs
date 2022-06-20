using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _detectRange;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _detectRange)
            NeedTransit = true;
    }
}
