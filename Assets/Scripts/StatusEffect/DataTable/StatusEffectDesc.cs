using System;
using UnityEngine;

[Serializable]
public class StatusEffectDesc {
    [field: SerializeField]
    public Int32 Number { get; private set; }
    [field: SerializeField]
    public String Name { get; private set; }
    [field: SerializeField]
    public String Desc { get; private set; }
}