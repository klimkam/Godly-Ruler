using UnityEngine;

[CreateAssetMenu(fileName ="New Human Home", menuName = "Buildings/Human")]
public class VillageHouseData : ScriptableObject
{
    [SerializeField]private Sprite[] _normalHumanHouse;
    [SerializeField] private Sprite[] _purifiedHumanHouse;
    [SerializeField] private Sprite[] _possessedHumanHouse;

    public Sprite[] HumanHouse { get { return _normalHumanHouse; } }
    public Sprite[] HumanHousePurified { get { return _purifiedHumanHouse; } }
    public Sprite[] HumanHousePossessed { get { return _possessedHumanHouse; } }
}
