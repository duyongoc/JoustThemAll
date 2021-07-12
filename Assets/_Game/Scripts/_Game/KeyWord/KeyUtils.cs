
using System.Collections.Generic;
using UnityEngine;

public static class KeyUtils
{

    public static string RandomCode()
    {
        var rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0: return "W";
            case 1: return "A";
            case 2: return "S";
            case 3: return "D";
        }
        return null;
    }

    public static string GetReverseCode(string key)
    {
        string reverse = "";
        switch (key)
        {
            case "W": reverse = "S"; break;
            case "S": reverse = "W"; break;
            case "A": reverse = "D"; break;
            case "D": reverse = "A"; break;
        }
        return reverse;
    }


    public static string RandomStringKey(int lenght)
    {
        string value = "";
        for (int i = 0; i < lenght; i++)
        {
            value += RandomCode();
        }

        return value;
    }

    public static List<string> GetRandomStringHidden(int lenght)
    {
        List<string> list = new List<string>(lenght);
        for (int i = 0; i < lenght; i++)
        {
            var str = RandomCode();
            list.Add(str);
        }

        return list;
    }

    // create list basic symbol 
    public static List<Code> GetRandomSymbolKeyCode(int lenght)
    {
        List<Code> codeSymbol = new List<Code>(lenght);
        for (int i = 0; i < lenght; i++)
        {
            Code code = new Code();
            code.key = RandomCode();
            code.keyReserve = GetReverseCode(code.key);
            codeSymbol.Add(code);
        }
        return codeSymbol;
    }

    // create list basic and reverse symbol 
    public static List<Code> GetRandomSymbolKeyCodeReverse(int lenght)
    {
        List<Code> codeSymbol = new List<Code>(lenght);
        for (int i = 0; i < lenght; i++)
        {
            Code code = new Code();
            code.key = RandomCode();
            codeSymbol.Add(code);


            // code.keyReserve = new KeyReserve();
            // code.keyReserve.Key(GetReverseCode(code.key));
            
        }
        return codeSymbol;
    }

    // create list symbol exist a hidden key
    // public static List<Code> RandomSymbolKeyCodeHidden(int lenght, int indHidden, int hiddenValue)
    // {
    //     List<Code> codeSymbol = new List<Code>(lenght);
    //     for (int i = 0; i < lenght; i++)
    //     {
    //         codeSymbol[i].key = RandomCode();
    //         // codeSymbol[i].keyReserve.Key(GetReverseCode(codeSymbol[i].key));

    //         if (i == indHidden)
    //         {
    //             Debug.Log(lenght);
                
    //         }
    //     }

    //     return codeSymbol;
    // }


}
