using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _healthBar;
    [SerializeField] private CanvasGroup _canvasGroup;
    private void Start()
    {
        _health.OnChangeHealth += DivideImageOfHealthBar;
        TryTurnOffCanvas();
    }
    private void TryTurnOffCanvas()
    {
        if (_health.MaxHealth == _health.CurrentHealth && _canvasGroup.blocksRaycasts)
        {
            _canvasGroup.ChangeStateOfCanvasGroup(false);
            return;
        }
        if (_canvasGroup.blocksRaycasts == false)
        {
            _canvasGroup.ChangeStateOfCanvasGroup(true);
        }
        }
        private void DivideImageOfHealthBar()
    {
        _healthBar.DivideImageBar(_health.MaxHealth, _health.CurrentHealth);
        TryTurnOffCanvas();
    }
    private void OnDisable()
    {
        _health.OnChangeHealth -= DivideImageOfHealthBar;
    }
}
