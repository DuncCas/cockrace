using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract string GetID();

    public abstract State RunBehaviour();
}
