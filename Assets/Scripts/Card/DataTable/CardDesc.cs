using System;
using UnityEngine;

[Serializable]
public class CardDesc {
    [field: SerializeField]
    public Int32 Number { get; private set; }
    [field: SerializeField]
    public String Name { get; private set; }
    [field: SerializeField]
    public Card.Rarity Rarity { get; private set; }
    [field: SerializeField]
    public String Desc { get; private set; }
    [field: SerializeField]
    public String Level1Desc { get; private set; }
    [field: SerializeField]
    public String Level2Desc { get; private set; }
};