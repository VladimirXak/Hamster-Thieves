using System;
using UnityEngine;

public abstract class AbstractDataValue : MonoBehaviour
{
    public abstract event Action<object> OnChangeData;
}
