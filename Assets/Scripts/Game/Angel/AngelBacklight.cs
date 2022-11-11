using UnityEngine;

public class AngelBacklight : MonoBehaviour
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
