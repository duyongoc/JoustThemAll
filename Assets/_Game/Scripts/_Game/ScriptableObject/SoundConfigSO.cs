using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CONFIG_Sound", menuName = "CONFIG/CONFIG_Sound")]
public class SoundConfigSO : ScriptableObject
{
    
    [Header("Game")]
    public AudioClip sfx_backgound;
    public AudioClip sfx_button_click;

    [Header("AP Start")]
    public AudioClip sfx_game_start;
    public AudioClip sfx_clash;

    [Header("AP")]
    public AudioClip sfx_correct;
    public AudioClip sfx_wrong;
    public AudioClip sfx_sequence_complete;
    public AudioClip sfx_running;
    public AudioClip sfx_whoosh;
    public AudioClip sfx_joust;

    [Header("Tie Breaker")]
    public AudioClip sfx_fast_paced;

    [Header("Ambience")]
    public AudioClip sfx_crowd;

    [Header("Character talking")]
    public AudioClip sfx_character_lost;
    public AudioClip sfx_character_won;

    [Header("Victory")]
    public AudioClip sfx_Victory;
    public AudioClip sfx_Crow;

    



}
