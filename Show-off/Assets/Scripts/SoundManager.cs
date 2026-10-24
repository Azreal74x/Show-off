using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundManager : MonoBehaviour {

  private AudioSource audioSource;

  //general sounds
  [SerializeField] private AudioClip clickSound;
  [SerializeField] private AudioClip changeObjectSound;

  //minigames ui sounds
  [SerializeField] private AudioClip gameEndSound;
  [SerializeField] private AudioClip tryAgainSound;
  [SerializeField] private AudioClip highscoreSound;

  //minigames sounds
  [SerializeField] private AudioClip F_hittingHoopSound;
  [SerializeField] private AudioClip F_flyThroughHoopSound;

  [SerializeField] private AudioClip J_goodCandyCatchSound;
  [SerializeField] private AudioClip J_badCandyCatchSound;

  [SerializeField] private AudioClip T_goodCandySound;
  [SerializeField] private AudioClip T_badCandySound;
  [SerializeField] private AudioClip T_beamSound;

  //petting sounds
  [SerializeField] private List<AudioClip> F_pettingSounds; //a list of different sounds
  [SerializeField] private List<AudioClip> J_pettingSounds; //a list of different sounds
  [SerializeField] private List<AudioClip> T_pettingSounds; //a list of different sounds

  //munching sounds
  [SerializeField] private AudioClip F_goodMunchingSound;
  [SerializeField] private AudioClip J_goodMunchingSound;
  [SerializeField] private AudioClip T_goodMunchingSound;

  [SerializeField] private AudioClip F_badMunchingSound;
  [SerializeField] private AudioClip J_badMunchingSound;
  [SerializeField] private AudioClip T_badMunchingSound;

  //extra sounds
  [SerializeField] private AudioClip J_yummyCandySound; //extra

  private void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  private void Update() {

  }

  //general sounds

  public void PlayClickSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = clickSound;
      audioSource.Play();
      //Debug.Log("PlayClickSound");
    }
  }

  public void PlayChangeObjectSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = changeObjectSound;
      audioSource.Play();
      //Debug.Log("PlayChangeObjectSound");
    }
  }

  //minigames ui sounds

  public void PlayGameEndSound() {
   if (!audioSource.isPlaying) {
      //audioSource.loop = false;
      audioSource.clip = gameEndSound;
      audioSource.Play();
      //Debug.Log("PlayGameEndSound");
    }
  }

  public void PlayTryAgainSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = tryAgainSound;
      audioSource.Play();
      //Debug.Log("PlayTryAgainSound");
    }
  }

  public void PlayHighscoreSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = highscoreSound;
      audioSource.Play();
      //Debug.Log("PlayHighscoreSound");
    }
  }

  //minigames sounds

  public void PlayF_HittingHoopSound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = F_hittingHoopSound;
    audioSource.Play();
    //Debug.Log("PlayF_HittingHoopSound");
    //}
  }

  public void PlayF_FlyThroughHoopSound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = F_flyThroughHoopSound;
    audioSource.Play();
    //Debug.Log("PlayF_FlyThroughHoopSound");
    //}
  }

  public void PlayJ_GoodCandyCatchSound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = J_goodCandyCatchSound;
    audioSource.Play();
    //Debug.Log("PlayJ_GoodCandyCatchSound");
    //}
  }

  public void PlayJ_BadCandyCatchSound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = J_badCandyCatchSound;
    audioSource.Play();
    //Debug.Log("PlayJ_BadCandyCatchSound");
    //}
  }

  public void PlayT_BeamSound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = T_beamSound;
    audioSource.Play();
    //Debug.Log("PlayT_BeamSound");
    //}
  }

  public void PlayT_GoodCandySound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = T_goodCandySound;
    audioSource.Play();
    //Debug.Log("PlayT_GoodCandySound");
    //}
  }

  public void PlayT_BadCandySound() {
    //if (!audioSource.isPlaying) {
    audioSource.clip = T_badCandySound;
    audioSource.Play();
    //Debug.Log("PlayT_BadCandySound");
    //}
  }

  //petting sounds 

  public void PlayF_PettingSound() {
    if (!audioSource.isPlaying) {
      int randomSound = Random.Range(0, F_pettingSounds.Count); //pick a random sound from list
      audioSource.clip = F_pettingSounds[randomSound]; //assign random sound
      audioSource.Play(); //play random sound
      //Debug.Log("PlayF_PettingSound " + randomSound);
    }
  }

  public void PlayJ_PettingSound() {
    if (!audioSource.isPlaying) {
      int randomSound = Random.Range(0, J_pettingSounds.Count); //pick a random sound from list
      audioSource.clip = J_pettingSounds[randomSound]; //assign random sound
      audioSource.Play(); //play random sound
      //Debug.Log("PlayJ_PettingSound " + randomSound);
    }
  }

  public void PlayT_PettingSound() {
    if (!audioSource.isPlaying) {
      int randomSound = Random.Range(0, T_pettingSounds.Count); //pick a random sound from list
      audioSource.clip = T_pettingSounds[randomSound]; //assign random sound
      audioSource.Play(); //play random sound
      //Debug.Log("PlayT_PettingSound " + randomSound);
    }
  }

  //munching sounds

  public void PlayF_GoodMunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = F_goodMunchingSound;
      audioSource.Play();
      //Debug.Log("PlayF_GoodMunchingSound");
    }
  }

  public void PlayJ_GoodMunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = J_goodMunchingSound;
      audioSource.Play();
      //Debug.Log("PlayJ_GoodMunchingSound");
    }
  }

  public void PlayT_GoodMunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = T_goodMunchingSound;
      audioSource.Play();
      //Debug.Log("PlayT_GoodMunchingSound");
    }
  }

  public void PlayF_BadMunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = F_badMunchingSound;
      audioSource.Play();
      //Debug.Log("PlayF_BadMunchingSound");
    }
  }

  public void PlayJ_BadMunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = J_badMunchingSound;
      audioSource.Play();
      //Debug.Log("PlayJ_BadMunchingSound");
    }
  }

  public void PlayT_BadMunchingSound() {
    if (!audioSource.isPlaying) {
      audioSource.clip = T_badMunchingSound;
      audioSource.Play();
      //Debug.Log("PlayT_BadMunchingSound");
    }
  }
}
