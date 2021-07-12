using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSymbol : MonoBehaviour
{

    //
    //= inspector
    [Header("CONFIG")]
    [SerializeField] private Easy_level easy_Level;
    [SerializeField] private Medium_level medium_Level;
    [SerializeField] private Hard_level hard_Level;


    //
    //= public 
    [Space(20)]
    public List<Symbol> easy_Symbols;
    public List<Symbol> medium_Symbols;
    public List<Symbol> hard_Symbols;


    #region UNITY
    // private void Start()
    // {
    // }

    // private void Update()
    // {
    // }
    #endregion


    public void LoadData()
    {
        LoadDataEasyLevel();
        LoadDataMediumLevel();
        LoadDataHardLevel();
    }


    public Symbol GetRandom_Easy_Symbol()
    {
        var rand = Random.Range(0, easy_Symbols.Count);
        return easy_Symbols[rand];
    }

    public Symbol GetRandom_Medium_Symbol()
    {
        var rand = Random.Range(0, medium_Symbols.Count);
        return medium_Symbols[rand];
    }

    public Symbol GetRandom_Hard_Symbol()
    {
        var rand = Random.Range(0, hard_Symbols.Count);
        return hard_Symbols[rand];
    }


    public void LoadDataEasyLevel()
    {
        int countSymbol = int.Parse(easy_Level.dataArray[0].Length);
        int min_lenght = int.Parse(easy_Level.dataArray[0].Minvalue);
        int max_lenght = int.Parse(easy_Level.dataArray[0].Maxvalue);
        int numReverse = int.Parse(easy_Level.dataArray[1].Number);
        int numHidden = int.Parse(easy_Level.dataArray[2].Number);
        int hiddenCount = int.Parse(easy_Level.dataArray[2].Hidden);

        easy_Symbols = new List<Symbol>(countSymbol);
        for (int i = 0; i < countSymbol; i++)
        {
            Symbol value = new Symbol(min_lenght, max_lenght, numReverse, numHidden, hiddenCount);
            easy_Symbols.Add(value);
        }
    }

    public void LoadDataMediumLevel()
    {
        int countSymbol = int.Parse(medium_Level.dataArray[0].Length);
        int min_lenght = int.Parse(medium_Level.dataArray[0].Minvalue);
        int max_lenght = int.Parse(medium_Level.dataArray[0].Maxvalue);
        int numReverse = int.Parse(medium_Level.dataArray[1].Number);
        int numHidden = int.Parse(medium_Level.dataArray[2].Number);
        int hiddenCount = int.Parse(medium_Level.dataArray[2].Hidden);

        medium_Symbols = new List<Symbol>(countSymbol);
        for (int i = 0; i < countSymbol; i++)
        {
            Symbol value = new Symbol(min_lenght, max_lenght, numReverse, numHidden, hiddenCount);
            medium_Symbols.Add(value);
        }
    }

    public void LoadDataHardLevel()
    {
        int countSymbol = int.Parse(hard_Level.dataArray[0].Length);
        int min_lenght = int.Parse(hard_Level.dataArray[0].Minvalue);
        int max_lenght = int.Parse(hard_Level.dataArray[0].Maxvalue);
        int numReverse = int.Parse(hard_Level.dataArray[1].Number);
        int numHidden = int.Parse(hard_Level.dataArray[2].Number);
        int hiddenCount = int.Parse(hard_Level.dataArray[2].Hidden);

        hard_Symbols = new List<Symbol>(countSymbol);
        for (int i = 0; i < countSymbol; i++)
        {
            Symbol value = new Symbol(min_lenght, max_lenght, numReverse, numHidden, hiddenCount);
            hard_Symbols.Add(value);
        }
    }


}
