using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClash : GameState
{

    //
    //= inspector
    [SerializeField] private PowerClashPanel powerClashPanel;


    //
    //= private 
    private MainGame mainGame;
    private Character character;
    private Enemy enemy;
    private float clashTimer = 3f;
    private bool tieEnd = false;


    #region UNITY
    private void Start()
    {
        CacheComponent();
    }

    // private void Update()
    // {
    // }
    #endregion


    #region STATE
    public override void StartState()
    {
        base.EndState();

        InitClash();
        SoundMgr.PlaySoundOneShot(SoundMgr.Instance.sfx_fast_paced);
        mainGame.GetInGameScene.ShowPowerClashPanel(true);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (tieEnd) return;

        clashTimer -= Time.deltaTime;
        powerClashPanel.ChangeSliderValue(clashTimer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.characterTAP++;
            powerClashPanel.ChangeTextCharacterTap("Character TAP: " + character.characterTAP.ToString());
        }

        if (clashTimer <= 0)
        {
            ShowFinishRound();
            tieEnd = true;
        }
    }

    public override void EndState()
    {
        base.EndState();

        FinishRound();
        mainGame.GetInGameScene.ShowPowerClashPanel(false);
    }
    #endregion


    private void InitClash()
    {
        tieEnd = false;
        clashTimer = mainGame.clashTimer;
        character.characterTAP = 0;
        StartCoroutine(CountEnemyTAP(4f));

        powerClashPanel.ChangeSliderMaxValue(clashTimer);
        powerClashPanel.ChangeTextCharacterTap("Character TAP: " + character.characterTAP.ToString());
        powerClashPanel.ChangeTextEnemyTap("Enemy TAP: " + 0);
    }

    private void ShowFinishRound()
    {
        switch (character.characterTAP > enemy.enemyTAP)
        {
            case true: powerClashPanel.ShowResult("You win this round!", true); break;
            case false: powerClashPanel.ShowResult("You lose this round!", true); break;
        }

        GameMgr.Instance.DelayEvent(() => { mainGame.SetStateNone(); }, 1.5f);
    }

    private void FinishRound()
    {
        if(character.characterTAP > enemy.enemyTAP)
        {
            CharacterWin();
        }
        else if(character.characterTAP < enemy.enemyTAP)
        {
            EnemyWin();
        }   
        else if(character.characterTAP == enemy.enemyTAP)
        {
            mainGame.OnBothMissingHit();
        }
    }

    IEnumerator CountEnemyTAP(float seconds)
    {
        int counter = 0;
        float totalTime = seconds;
        float timer = seconds / enemy.GetEnemyTAP();
        while (totalTime >= 0)
        {
            yield return new WaitForSeconds(timer);
            powerClashPanel.ChangeTextEnemyTap("Enemy TAP: " + counter.ToString());
            totalTime -= timer;
            counter++;
        }
    }

    public void CharacterWin()
    {
        mainGame.OnCharacterAttack();
    }

    public void EnemyWin()
    {
        mainGame.OnEnemyAttack();
    }


    private void CacheComponent()
    {
        mainGame = MainGame.Instance;
        character = Character.Instance;
        enemy = Enemy.Instance;
    }
}
