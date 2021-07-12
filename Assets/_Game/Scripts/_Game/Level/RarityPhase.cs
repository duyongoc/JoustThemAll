using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RarityPhase : MonoBehaviour
{
    public int number_of_round;
    public int roundTime;
    public int mEasy = 0;
    public int mMedium = 0;
    public int mHard = 0;

    public List<Symbol> _symbol_in_phase;


    #region UNITY
    // private void Start()
    // {
    // }

    // private void Update()
    // {
    // }
    #endregion


    public void InitRarity(int round, int easy, int medium, int hard)
    {
        number_of_round = round;
        mEasy = easy;
        mMedium = medium;
        mHard = hard;
    }

    public List<Symbol> GetRandomSymbolRarity_Easy(List<Symbol> sym_Easy, List<Symbol> sym_Medium, List<Symbol> sym_Hard)
    {
        _symbol_in_phase = new List<Symbol>(number_of_round);

        for (int i = 0; i < number_of_round; i++)
        {
            if (i < mEasy)
            {
                var rand = Random.Range(0, sym_Easy.Count);
                _symbol_in_phase.Add(sym_Easy[rand]);
            }
            else if (i < mEasy + mMedium)
            {
                var rand = Random.Range(0, sym_Medium.Count);
                _symbol_in_phase.Add(sym_Medium[rand]);
            }
            else if (i < mEasy + mMedium + mHard)
            {
                var rand = Random.Range(0, sym_Hard.Count);
                _symbol_in_phase.Add(sym_Hard[rand]);
            }
            else
            {
                var rand = Random.Range(0, sym_Easy.Count);
                _symbol_in_phase.Add(sym_Easy[rand]);
            }
        }

        return _symbol_in_phase;
    }

    public List<Symbol> GetRandomSymbolRarity_Medium(List<Symbol> sym_Easy, List<Symbol> sym_Medium, List<Symbol> sym_Hard)
    {
        _symbol_in_phase = new List<Symbol>(number_of_round);

        for (int i = 0; i < number_of_round; i++)
        {
            if (i < mEasy)
            {
                var rand = Random.Range(0, sym_Easy.Count);
                _symbol_in_phase.Add(sym_Easy[rand]);
            }
            else if (i < mEasy + mMedium)
            {
                var rand = Random.Range(0, sym_Medium.Count);
                _symbol_in_phase.Add(sym_Medium[rand]);
            }
            else if (i < mEasy + mMedium + mHard)
            {
                var rand = Random.Range(0, sym_Hard.Count);
                _symbol_in_phase.Add(sym_Hard[rand]);
            }
            else 
            {
                var rand = Random.Range(0, sym_Medium.Count);
                _symbol_in_phase.Add(sym_Medium[rand]);
            }
        }

        return _symbol_in_phase;
    }

    public List<Symbol> GetRandomSymbolRarity_Hard(List<Symbol> sym_Easy, List<Symbol> sym_Medium, List<Symbol> sym_Hard)
    {
        _symbol_in_phase = new List<Symbol>(number_of_round);

        for (int i = 0; i < number_of_round; i++)
        {
            if (i < mEasy)
            {
                var rand = Random.Range(0, sym_Easy.Count);
                _symbol_in_phase.Add(sym_Easy[rand]);
            }
            else if (i < mEasy + mMedium)
            {
                var rand = Random.Range(0, sym_Medium.Count);
                _symbol_in_phase.Add(sym_Medium[rand]);
            }
            else if (i < mEasy + mMedium + mHard)
            {
                var rand = Random.Range(0, sym_Hard.Count);
                _symbol_in_phase.Add(sym_Hard[rand]);
            }
            else
            {
                var rand = Random.Range(0, sym_Hard.Count);
                _symbol_in_phase.Add(sym_Hard[rand]);
            }
        }

        return _symbol_in_phase;
    }



}
