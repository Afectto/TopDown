using System;
using UnityEngine;

[Serializable]
public class PickupData
{
    [SerializeField] private Sprite skin;
    [SerializeField] private string name;

    public Sprite Skin => skin;
    public string Name => name;
}