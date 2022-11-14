using System;
using UnityEngine;

public class HumanVillage : MonoBehaviour
{
    public event Action OnVillagePurification;
    public event Action OnVillagePossession;
    public event Action OnVillageNormalization;

    public event Action OnAngelEnteringTheVillage;
    public event Action OnDemonEnteringTheVillage;
    public event Action OnVillagePossessionBegin;
    public event Action OnVillagePurificationBegin;

    public event Action OnAngelAndDemonsNumberChange;
    [SerializeField] private float _degreeOfVillage = 0; 
    private int _numberOfAngels = 0;
    private int _numberOfDevils = 0;
    private int _sanityChangeRante = 0;
    [SerializeField]
    private float _sanityLevel = 0;

    public int NumberOfAngels
    {
        get { return _numberOfAngels; }
        private set
        {
            _numberOfAngels = IsIntegerAPositiveNumber(value) ? value : 0;
            OnAngelAndDemonsNumberChange?.Invoke();
        }
    }

    public int NumberOfDevils
    {
        get { return _numberOfDevils; }
        private set
        {
            _numberOfDevils = IsIntegerAPositiveNumber(value) ? value : 0;
            OnAngelAndDemonsNumberChange?.Invoke();
        }
    }

    public float SanityLevel {
        get { return _sanityLevel; }
        private set {
            if (_sanityLevel <= 50 && _sanityLevel >= -50) {
                _sanityLevel = value;
            }
            if (_sanityLevel == 0) {
                OnVillageNormalization?.Invoke();
            }
            if (_sanityLevel >= 50) {
                _sanityLevel = 50;
                OnVillagePurification?.Invoke();
            }
            if (_sanityLevel <= -50)
            {
                _sanityLevel = -50;
                OnVillagePossession?.Invoke();
            }
        }
    }

    public int SanityChangeRante { get => _sanityChangeRante; private set => _sanityChangeRante = value; }

    private void Awake()
    {
        OnAngelAndDemonsNumberChange += ActionOnAngelAndDemonsNumberChange;
        _sanityLevel = _degreeOfVillage;
    }

    private void ActionOnAngelAndDemonsNumberChange() {
        SanityChangeRante = (_numberOfAngels > _numberOfDevils) ? (1) : (-1);
        if (_numberOfAngels == _numberOfDevils) {
            SanityChangeRante = 0;
        }
    }

    private void Update()
    {
        if (SanityChangeRante == 0) {
            return;
        }

        if (_numberOfAngels != 0 && SanityLevel == 0) {
            OnVillagePurificationBegin?.Invoke();
        }

        if (_numberOfDevils != 0 && SanityLevel == 0)
        {
            OnVillagePossessionBegin?.Invoke();
        }

        SanityLevel += SanityChangeRante * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AngelHealth>() != null)
        {
            NumberOfAngels += 1;
            OnAngelEnteringTheVillage?.Invoke();
        }

        if (collision.gameObject.GetComponent<DemonHealth>() != null)
        {
            NumberOfDevils += 1;
            OnDemonEnteringTheVillage?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AngelHealth>() != null)
        {
            NumberOfAngels -= 1;
            OnAngelEnteringTheVillage?.Invoke();
        }

        if (collision.gameObject.GetComponent<DemonHealth>() != null)
        {
            NumberOfDevils -= 1;
            OnDemonEnteringTheVillage?.Invoke();
        }
    }

    private bool IsIntegerAPositiveNumber(int value)
    {
        if (value < 0) return false;
        return true;
    }
}
