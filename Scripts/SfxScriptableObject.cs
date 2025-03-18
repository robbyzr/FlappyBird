using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Audio", menuName = "ScriptableObjects/Audio", order =1)]
public class SfxScriptableObject : ScriptableObject
{
   

    public AudioClip gameOverSfx;
    public AudioClip pointSfx;
    public AudioClip clickSfx;
}
