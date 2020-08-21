using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _metalSource;
    [SerializeField] private AudioSource[] _plasticSource;
    [SerializeField] private AudioSource[] _paperSource;
    [SerializeField] private AudioSource[] _glassSource;
    [SerializeField] private AudioSource[] _organicSource;

    
    [SerializeField] private AudioSource _correctSource;
    [SerializeField] private AudioSource _wrongSource;

}
