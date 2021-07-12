using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : Singleton<GameMgr>
{

    //
    //= inspector
    [Header("State Scene")]
    [SerializeField] private Menu menuScene;
    [SerializeField] private Map mapScene;
    [SerializeField] private Tutorial tutorialScene;
    [SerializeField] private InGame inGameScene;
    [SerializeField] private GameOver gameOverScene;
    [SerializeField] private Setting settingScene;


    //
    //= private 
    private StateScene currentScene;
    private Rarity currentRarity;


    //
    //= properties
    public bool IsInGameState { get => currentScene == inGameScene; }
    public bool IsTutorialState { get => currentScene == tutorialScene; }


    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
        Init();
    }

    // private void Update()
    // {
    // }
    #endregion


    private void Init()
    {
        LoadSceneMenu();
    }

    public void LoadSceneMenu()
    {
        SetStateScene(menuScene);
        SetActiveScene("Menu");
    }

    public void LoadSceneMap()
    {
        SetStateScene(mapScene);
        SetActiveScene("Map");
    }

    public void LoadSceneTutorial()
    {
        SetStateScene(tutorialScene);
        SetActiveScene("Tutorial");
    }

    public void LoadSceneInGame(Rarity rarity)
    {
        SetStateScene(inGameScene);
        SetActiveScene("InGame");


        currentRarity = rarity;
        MainGame.Instance.Init(rarity);
    }

    public void LoadSceneGameOver()
    {
        SetStateScene(gameOverScene);
        SetActiveScene("GameOver");
    }

    public void LoadSceneSetting()
    {
        SetStateScene(gameOverScene);
        SetActiveScene("Setting");
    }

    public void LoadReplayGame()
    {
        LoadSceneInGame(currentRarity);
    }

    private void SetStateScene(StateScene newScene)
    {
        if (currentScene != null)
            currentScene.EndState();

        currentScene = newScene;
        currentScene.StartState();
    }

    private void SetActiveScene(string nameScene)
    {
        menuScene.gameObject.SetActive(menuScene.name.Contains(nameScene));
        mapScene.gameObject.SetActive(mapScene.name.Contains(nameScene));
        tutorialScene.gameObject.SetActive(tutorialScene.name.Contains(nameScene));
        inGameScene.gameObject.SetActive(inGameScene.name.Contains(nameScene));
        gameOverScene.gameObject.SetActive(gameOverScene.name.Contains(nameScene));
        settingScene.gameObject.SetActive(settingScene.name.Contains(nameScene));
    }

    public void DelayEvent(Action callback, float timer)
    {
        StartCoroutine(Utils.DelayEvent(() => { callback(); }, timer));
    }


    private void CacheDefine()
    {
    }

    private void CacheComponent()
    {
    }

}




// God bless my code to be bug free 
//
//                       _oo0oo_
//                      o8888888o
//                      88" . "88
//                      (| -_- |)
//                      0\  =  /0
//                    ___/`---'\___
//                  .' \\|     |// '.
//                 / \\|||  :  |||// \
//                / _||||| -:- |||||- \
//               |   | \\\  -  /// |   |
//               | \_|  ''\---/''  |_/ |
//               \  .-\__  '-'  ___/-. /
//             ___'. .'  /--.--\  `. .'___
//          ."" '<  `.___\_<|>_/___.' >' "".
//         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//         \  \ `_.   \_ __\ /__ _/   .-` /  /
//     =====`-.____`.___ \_____/___.-`___.-'=====
//                       `=---='
//
//
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
//               佛祖保佑         永无BUG
//