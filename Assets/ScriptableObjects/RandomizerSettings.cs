using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RandomizerSettings", fileName = "New RandomizerSettings")]
public class RandomizerSettings : ScriptableObject
{
    public FacePieceRandomizeSettings leftEyeSettings;
    public FacePieceRandomizeSettings rightEyeSettings;
    public FacePieceRandomizeSettings noseSettings;
    public FacePieceRandomizeSettings mouthSettings;
    public FacePieceRandomizeSettings leftEarSettings;
    public FacePieceRandomizeSettings rightEarSettings;
    public FacePieceRandomizeSettings leftEyebrowSettings;
    public FacePieceRandomizeSettings rightEyebrowSettings;
}