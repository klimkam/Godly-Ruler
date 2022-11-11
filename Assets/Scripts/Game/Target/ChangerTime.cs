using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerTime : MonoBehaviour
{
    private bool _isCoolDown;
    private float _currentTime;
   [SerializeField]  private float _reloadTime = 5;
    private Action OnSetTime;

    public bool IsCoolDown { get => _isCoolDown; set => _isCoolDown = value; }

    public void SetReloadTime( Action action)
    {
        OnSetTime = action;
    }
    private void Update()
    {
        if (IsCoolDown)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _reloadTime)
            {
                _currentTime = 0;
                IsCoolDown = false;
                OnSetTime?.Invoke();
            }
        }
    }
}
