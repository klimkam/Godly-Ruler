using UnityEngine;

public class ControllableUnitBacklight : MonoBehaviour
{
    private void Awake()
    {
        Disappear();
    }
    public void Appear()
    {
        gameObject.SetActive(true);
    }
    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
