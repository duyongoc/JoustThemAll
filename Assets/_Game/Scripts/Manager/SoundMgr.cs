using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : Singleton<SoundMgr>
{

    //
    //= inspector
    [SerializeField] private SoundConfigSO soundConfig;


    //define
    private static AudioSource audioSource;
    [HideInInspector] public AudioClip sfx_backgound;
    [HideInInspector] public AudioClip sfx_button_click;
    [HideInInspector] public AudioClip sfx_game_start;
    [HideInInspector] public AudioClip sfx_clash;
    [HideInInspector] public AudioClip sfx_correct;
    [HideInInspector] public AudioClip sfx_wrong;
    [HideInInspector] public AudioClip sfx_sequence_complete;
    [HideInInspector] public AudioClip sfx_running;
    [HideInInspector] public AudioClip sfx_whoosh;
    [HideInInspector] public AudioClip sfx_joust;
    [HideInInspector] public AudioClip sfx_fast_paced;
    [HideInInspector] public AudioClip sfx_crowd;
    [HideInInspector] public AudioClip sfx_character_lost;
    [HideInInspector] public AudioClip sfx_character_won;
    [HideInInspector] public AudioClip sfx_Victory;
    [HideInInspector] public AudioClip sfx_Crow;


    #region UNITY
    private void Start()
    {
        CacheComponent();
        CacheDefine();
    }

    // private void Update()
    // {
    // }
    #endregion

    public static void PlaySound(AudioClip audi)
    {
        audioSource.Stop();

        audioSource.clip = audi;
        audioSource.Play();
        audioSource.loop = true;
    }

    public static void StopSound()
    {
        audioSource.Stop();
    }

    public static void PlaySoundOneShot(AudioClip audi)
    {
        StopSound();
        audioSource.PlayOneShot(audi);
    }

    public bool IsPlaying(AudioClip audi)
    {
        return audioSource.clip == audi && audioSource.isPlaying;
    }


    private void CacheDefine()
    {
        sfx_backgound = soundConfig.sfx_backgound;
        sfx_button_click = soundConfig.sfx_button_click;
        sfx_game_start = soundConfig.sfx_game_start;
        sfx_clash = soundConfig.sfx_clash;
        sfx_correct = soundConfig.sfx_correct;
        sfx_wrong = soundConfig.sfx_wrong;
        sfx_sequence_complete = soundConfig.sfx_sequence_complete;
        sfx_running = soundConfig.sfx_running;
        sfx_whoosh = soundConfig.sfx_whoosh;
        sfx_joust = soundConfig.sfx_joust;
        sfx_fast_paced = soundConfig.sfx_fast_paced;
        sfx_crowd = soundConfig.sfx_crowd;
        sfx_character_lost = soundConfig.sfx_character_lost;
        sfx_character_won = soundConfig.sfx_character_won;
        sfx_Victory = soundConfig.sfx_Victory;
        sfx_Crow = soundConfig.sfx_Crow;
    }

    private void CacheComponent()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
