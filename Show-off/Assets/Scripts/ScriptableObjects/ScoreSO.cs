using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSO : ScriptableObject {

  [SerializeField] private float _highScoreValue;
  [SerializeField] private float _currentScoreValue;

  public float HighScoreValue {
    get { return _highScoreValue; }
    set { _highScoreValue = value; }
  }
  public float CurrentScoreValue {
    get { return _currentScoreValue; }
    set { _currentScoreValue = value; }
  }

}
