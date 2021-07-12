using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Symbol
{

    //
    //= public
    public List<Code> codes;
    public int countReverse;
    public int countHidden;


    //
    //private 
    private int index = 0;


    public Symbol(int min, int max, int numReverse, int numHidden, int hiddenCount)
    {
        var lenghtCode = Random.Range(min, max + 1);
        codes = new List<Code>(lenghtCode);
        codes = KeyUtils.GetRandomSymbolKeyCode(lenghtCode);

        SetSpecialKeyInSymbol(numReverse, numHidden, hiddenCount);
    }

    ///
    /// = Init The symbol
    ///
    private void SetSpecialKeyInSymbol(int reverse, int hidden, int hiddenCount)
    {
        countReverse = reverse;
        countHidden = hidden;
        SetHiddenKey(hiddenCount);
        SetReverseKey();
    }

    private void SetReverseKey()
    {
        int rand;
        for (int i = 0; i < countReverse; i++)
        {
            do
            {
                rand = Random.Range(0, codes.Count);
            } while (codes[rand].isKeyReverse || codes[rand].isKeyHidden);

            codes[rand].isKeyReverse = true;
        }
    }

    private void SetHiddenKey(int hiddenCount)
    {
        int index = codes.Count - 1;
        for (int i = 0; i < countHidden; i++)
        {
            do
            {
                codes[index].isKeyHidden = true;
                codes[index].keyHidden = new KeyHidden(hiddenCount);
                index--;

            } while (codes[index].isKeyReverse || codes[index].isKeyHidden);
        }
    }


    ///
    /// = Compare the key The symbol
    ///
    public Result CompareCode(string key, List<CodeKey> currentCodeKey)
    {
        Result result = Result.None;

        if (CompareNormal(key))
        {
            result = Result.CodeCorrect;
            currentCodeKey[index].ChangeCorrectKeyShape();
        }
        else if (CompareKeyReverse(key))
        {
            result = Result.CodeCorrect;
            currentCodeKey[index].ChangeCorrectKeyRevert();
        }
        //hidden key doesnt change index symbol
        else if (CompareKeyHidden(key))
        {
            CheckKeyHidden(currentCodeKey);
            if (codes[index].keyHidden.correct)
                return Result.SequenceCorrect;
            else
                return Result.CodeCorrect;
        }
        else
        {
            currentCodeKey[index].ChangeWrongKeyShape();
            return Result.CodeWrong;
        }

        if (index == codes.Count - 1)
            return Result.SequenceCorrect;

        index++;
        return result;
    }

    private bool CompareNormal(string key)
    {
        if (codes[index].isKeyReverse || codes[index].isKeyHidden)
            return false;
            
        return codes[index].key.Equals(key); ;
    }

    private bool CompareKeyReverse(string key)
    {
        if (!codes[index].isKeyReverse)
            return false;

        return codes[index].keyReserve.Equals(key);
    }

    private bool CompareKeyHidden(string key)
    {
        if (!codes[index].isKeyHidden)
            return false;

        return codes[index].keyHidden.CompareCodeHidden(key);
    }

    private void CheckKeyHidden(List<CodeKey> currentCodeKey)
    {
        switch (codes[index].keyHidden.correct)
        {
            case true:
                currentCodeKey[index].ChangeCorrectKeyShape();
                break;
            case false:
                currentCodeKey[index].CheckCorrectHiddenKey();
                break;
        }
    }


    //= other
    public void ResetCompare(List<CodeKey> currentCodeKey)
    {
        index = 0;
        foreach (CodeKey code in currentCodeKey)
            code.ResetDefaultKeyShape();
    }


}
