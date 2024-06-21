using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour {

  private AudioSource audioSource;

  [SerializeField] private AudioClip buttonClickSound;
  [SerializeField] private AudioClip houseClickSound;
  [SerializeField] private AudioClip sadMonsterRainSound;

  [SerializeField] private AudioClip F_WooshSound;
  [SerializeField] private AudioClip J_candyCatchSound;
  [SerializeField] private AudioClip T_BeamSound;

  [SerializeField] private AudioClip F_PettingSound;
  [SerializeField] private AudioClip J_PettingSound;
  [SerializeField] private List<AudioClip> T_PettingSounds; //a list of different sounds

  [SerializeField] private AudioClip F_MunchingSound;
  [SerializeField] private AudioClip J_MunchingSound;
  [SerializeField] private AudioClip T_MunchingSound;

  [SerializeField] private AudioClip J_YummyCandySound; //extra

  private void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  private void Update() {

  }

  public void PlayButtonClickSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = buttonClickSound;
      audioSource.Play();
    }
  }

  public void PlayHouseClickSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = houseClickSound;
      audioSource.Play();
    }
  }


  public void PlaySadMonsterRainSound() {
    if (!audioSource.isPlaying) {
      //audioSource.loop = true;
      audioSource.clip = sadMonsterRainSound;
      //audioSource.Play(); //stop it for now cuz i think its buggy
    }
  }

  public void StopSadMonsterRainSound() {
    if (audioSource.clip == sadMonsterRainSound) {
      audioSource.Stop();
    }
    //audioSource.loop = false;
  }
  public void PlayF_WooshSound() {
    //if (!audioSource.isPlaying) {
      audioSource.clip = F_WooshSound;
      audioSource.Play();
    //}
  }

  public void PlayJ_CandyCatchSound() {
    //if (!audioSource.isPlaying) {
      audioSource.clip = J_candyCatchSound;
      audioSource.Play();
    //}
  }

  public void PlayT_BeamSound() {
    //if (!audioSource.isPlaying) {
      audioSource.clip = T_BeamSound;
      audioSource.Play();
    //}
  }

  public void PlayF_PettingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = F_PettingSound;
      audioSource.Play();
    }
  }

  public void PlayJ_PettingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = J_PettingSound;
      audioSource.Play();
    }
  }

  public void PlayT_PettingSound() {
    if (!audioSource.isPlaying) {
      int randomSound = Random.Range(0, T_PettingSounds.Count); //pick a random sound from list
      audioSource.clip = T_PettingSounds[randomSound]; //assign random sound
      audioSource.Play(); //play random sound
    }
  }

  public void PlayF_MunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = F_MunchingSound;
      audioSource.Play();
    }
  }

  public void PlayJ_MunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = J_MunchingSound;
      audioSource.Play();
    }
  }

  public void PlayT_MunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = T_MunchingSound;
      audioSource.Play();
    }
  }
}
