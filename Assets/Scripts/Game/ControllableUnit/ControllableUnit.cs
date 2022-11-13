using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableUnit : Target
{
    [SerializeField] private ControllableUnitBacklight _controllableUnitBacklight;
    public ControllableUnitBacklight ControllableUnitBacklight { get => _controllableUnitBacklight; private set => _controllableUnitBacklight = value; }
    public abstract void OnClick(Vector3 target);
}
