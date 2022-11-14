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
    public float CurrentTime { get => _currentTime; set => _currentTime = value; }

    public void SetReloadTime( Action action)
    {
        OnSetTime = action;
    }
    private void Update()
    {
        if (IsCoolDown)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= _reloadTime)
            {
                CurrentTime = 0;
                IsCoolDown = false;
                OnSetTime?.Invoke();
            }
        }
    }
    public void ResetTimer()
    {
        CurrentTime = 0;
        IsCoolDown = true;
    }
}
