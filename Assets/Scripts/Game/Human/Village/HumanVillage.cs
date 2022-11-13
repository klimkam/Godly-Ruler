using System;
using UnityEngine;

public class HumanVillage : MonoBehaviour
{
    public event Action OnVillagePurification;
    public event Action OnVillagePossession;
    public event Action OnVillageNormalization;


    //???????? ????? ?? ?????? ???????, 
    //???????? ??????? ??????? ?? ?????????? ??????? ??? ???????
    //???? ?????????? ??????????, ?? ?????? ????? ?? ?????

/*    private int _numberOfAngels;
    private int _numberOfDevils;

    public int NumberOfAngels{ 
        get { return _numberOfAngels; } 
        private set {
            _numberOfAngels = IsIntegerAPositiveNumber(value) ? value : 0;
        } 
    }
    
    public int NumberOfDevils{ 
        get { return _numberOfDevils; } 
        private set {
            _numberOfDevils = IsIntegerAPositiveNumber(value) ? value : 0;
        } 
    }*/

    private VillageHouseSprite[] _allHousesInVillage;

    private void Awake()
    {
        _allHousesInVillage = gameObject.GetComponentsInChildren<VillageHouseSprite>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AngelHealth>() != null)
        {
            OnVillagePurification.Invoke();
        }

        if (collision.gameObject.GetComponent<DemonHealth>() != null)
        {
            OnVillagePossession.Invoke();
        }
    }

    private bool IsIntegerAPositiveNumber(int value)
    {
        if (value < 0) return false;
        return true;
    }
}
