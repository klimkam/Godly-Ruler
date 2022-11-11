using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum DirectionForCamera
{
    X,
    Y
}
public enum PositivityOfCameraMovement
{
    Positivity = 1,
    Negativity = -1
}

[Serializable]
public class TupleOfKey
{
    [SerializeField] private PositivityOfCameraMovement _positivityOfCameraMovement = PositivityOfCameraMovement.Positivity;
    [SerializeField] private DirectionForCamera _directionForCamera;
    [SerializeField] private List<KeyCode> _keyCodesForMovingCamera = new List<KeyCode>();
    public DirectionForCamera DirectionForCamera { get => _directionForCamera; private set => _directionForCamera = value; }
    public List<KeyCode> KeyCodesForMovingCamera { get => _keyCodesForMovingCamera; private set => _keyCodesForMovingCamera = value; }
    public PositivityOfCameraMovement PositivityOfCameraMovement { get => _positivityOfCameraMovement; private set => _positivityOfCameraMovement = value; }
}
