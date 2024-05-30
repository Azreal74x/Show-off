using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class BoolSO : ScriptableObject {

  [SerializeField] private bool _value = false;

  public bool Value {
    get { return _value; }
    set { _value = value; }
  }

}