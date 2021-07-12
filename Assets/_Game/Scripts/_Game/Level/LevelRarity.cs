using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRarity : MonoBehaviour
{

    //
    //= inspector
    [Header("CONFIG")]
    [SerializeField] private DataSymbol dataSymbol;
    [SerializeField] private Low_rarity low_Rarity;
    [SerializeField] private Medium_rarity medium_Rarity;
    [SerializeField] private High_rarity high_Rarity;


    //
    //= public 
    [Space(20)]
    public RarityPhase low_phase;
    public RarityPhase medium_phase;
    public RarityPhase high_phase;

    #region UNITY
    // private void Start()
    // {
    // }

    // private void Update()
    // {
    // }
    #endregion

    public void LoadData(int round)
    {
        LoadData_Low_Rarity(round);
        LoadData_Medium_Rarity(round);
        LoadData_High_Rarity(round);
    }

    public List<Symbol> GetRandom_Low_Rarity()
    {
        return low_phase.GetRandomSymbolRarity_Easy(dataSymbol.easy_Symbols, dataSymbol.medium_Symbols, dataSymbol.hard_Symbols);
    }

    public List<Symbol> GetRandom_Medium_Rarity()
    {
        return medium_phase.GetRandomSymbolRarity_Medium(dataSymbol.easy_Symbols, dataSymbol.medium_Symbols, dataSymbol.hard_Symbols);
    }

    public List<Symbol> GetRandom_High_Rarity()
    {
        return high_phase.GetRandomSymbolRarity_Hard(dataSymbol.easy_Symbols, dataSymbol.medium_Symbols, dataSymbol.hard_Symbols);
    }
    

    public void LoadData_Low_Rarity(int round)
    {
        int easy = int.Parse(low_Rarity.dataArray[0].Value);   // easy value
        int medium = int.Parse(low_Rarity.dataArray[1].Value);   // medium value
        int hard = int.Parse(low_Rarity.dataArray[2].Value);   // hard value
        low_phase.InitRarity(round, easy, medium, hard);
    }

    public void LoadData_Medium_Rarity(int round)
    {
        int easy = int.Parse(medium_Rarity.dataArray[0].Value);   // easy value
        int medium = int.Parse(medium_Rarity.dataArray[1].Value);   // medium value
        int hard = int.Parse(medium_Rarity.dataArray[2].Value);   // hard value
        medium_phase.InitRarity(round, easy, medium, hard);
    }

    public void LoadData_High_Rarity(int round)
    {
        int easy = int.Parse(high_Rarity.dataArray[0].Value);   // easy value
        int medium = int.Parse(high_Rarity.dataArray[1].Value);   // medium value
        int hard = int.Parse(high_Rarity.dataArray[2].Value);   // hard value
        high_phase.InitRarity(round, easy, medium, hard);
    }


}
