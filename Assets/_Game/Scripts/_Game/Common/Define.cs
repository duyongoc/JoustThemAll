using System.Collections.Generic;


public enum Rarity
{
    Low,
    Medium,
    High
}

// symbol difficulty
public enum Difficult
{
    Easy,
    Medium,
    Hard
}

public enum Result
{
    CodeCorrect,
    CodeWrong,
    SequenceCorrect,
    SequenceWrong,
    YouWin,
    YouLose,
    Finish,
    Clash,
    None
}


[System.Serializable]
public class Code
{
    public string key = "";
    public string keyReserve = "";
    public KeyHidden keyHidden;

    public bool isKeyReverse = false;
    public bool isKeyHidden = false;
}


[System.Serializable]
public class KeyHidden
{
    public int count = 0;
    public bool correct = false;
    public List<string> listHidden;

    private int index = 0;
    // private int currentIndex = 0;

    public KeyHidden(int count)
    {
        this.count = count;
        listHidden = KeyUtils.GetRandomStringHidden(count);
    }

    public string GetCurrentKey()
    {
        if (index == listHidden.Count)
            return null;

        return listHidden[index];
    }

    public bool CompareCodeHidden(string key)
    {
        if (index == listHidden.Count - 1)
        {
            correct = true;
            return true;
        }

        return listHidden[index++].Equals(key);
    }

}
