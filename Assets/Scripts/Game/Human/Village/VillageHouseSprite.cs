using System;
using UnityEngine;
using UnityEngine.UI;

public class VillageHouseSprite : MonoBehaviour
{
    [SerializeField] private int _houseType = 0;
    [SerializeField] private VillageHouseData _villageHouseData;

    private Sprite[] _villageHouseSprites;
    private Sprite _currentSprite;
    private SpriteRenderer _spriteRenderer;

    private HumanVillage _humanVillage;

    private Sprite CurrentSprite {
        get { return _currentSprite; } 
        set {
            OnHouseSpriteChange.Invoke();
            _currentSprite = value; 
        }
    }

    private Action OnHouseSpriteChange;

    private enum _currentHomeState { 
        normalHouse = 0,
        purifiedHouse = 1,
        possessedHouse = 2
    }

    private void Awake()
    {
        SetupHouseSpritesArray();
    }

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _humanVillage = gameObject.GetComponentInParent<HumanVillage>();
        OnHouseSpriteChange += DrawNewHouseSprite;
        _humanVillage.OnVillagePurification += ChangeHouseSpriteToPurifiedHouse;
        _humanVillage.OnVillagePossession += ChangeHouseSpriteToPossessedHouse;
        _humanVillage.OnVillageNormalization += ChangeHouseSpriteToNormalHouse;
    }

    private void SetupHouseSpritesArray() {
        _villageHouseSprites = new Sprite[3];
        _villageHouseSprites[(int)_currentHomeState.normalHouse] = _villageHouseData.HumanHouse[_houseType];
        _villageHouseSprites[(int)_currentHomeState.purifiedHouse] = _villageHouseData.HumanHousePurified[_houseType];
        _villageHouseSprites[(int)_currentHomeState.possessedHouse] = _villageHouseData.HumanHousePossessed[_houseType];
    }

    private void ChangeHouseSpriteToNormalHouse() {
        CurrentSprite = _villageHouseSprites[(int)_currentHomeState.normalHouse];
    }
    
    private void ChangeHouseSpriteToPossessedHouse() {
        CurrentSprite = _villageHouseSprites[(int)_currentHomeState.possessedHouse];
    }
    
    private void ChangeHouseSpriteToPurifiedHouse() {
        CurrentSprite = _villageHouseSprites[(int)_currentHomeState.purifiedHouse];
    }

    private void DrawNewHouseSprite() {
        _spriteRenderer.sprite = CurrentSprite;
    }
}
