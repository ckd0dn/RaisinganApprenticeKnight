using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BaseController : MonoBehaviour
{
    public ObjectType ObjectType { get; protected set; }

    bool init = false;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {

    }
}
