using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FaceType", fileName = "New FaceTypeSO")]
public class FaceTypeSO : ScriptableObject
{
    public FacePieceRandomizeSettings leftEyeSettings;
    public FacePieceRandomizeSettings rightEyeSettings;
    public FacePieceRandomizeSettings noseSettings;
    public FacePieceRandomizeSettings mouthSettings;
    public FacePieceRandomizeSettings leftEarSettings;
    public FacePieceRandomizeSettings rightEarSettings;
    public FacePieceRandomizeSettings leftEyebrowSettings;
    public FacePieceRandomizeSettings rightEyebrowSettings;

    public GameObject[] headArray;
    public GameObject[] eyeArray;
    public GameObject[] noseArray;
    public GameObject[] mouthArray;
    public GameObject[] earArray;
    public GameObject[] eyebrowArray;
}

[System.Serializable]
public struct FacePieceRandomizeSettings
{
    public Vector2 minPositionChangeAmount;
    public Vector2 maxPositionChangeAmount;

    public Vector2 minScaleChangeAmount;
    public Vector2 maxScaleChangeAmount;

    public float minRotationChangeAmount;
    public float maxRotationChangeAmount;
}

[System.Serializable]
public struct FacePieceSavedSettings
{
    public float randomPosX;
    public float randomPosY;

    public float randomScaleX;
    public float randomScaleY;

    public float randomRotation;
}

[System.Serializable]
public struct SavedFace
{
    public GameObject head;
    public GameObject leftEye;
    public GameObject rightEye;
    public GameObject nose;
    public GameObject mouth;
    public GameObject leftEar;
    public GameObject rightEar;
    public GameObject leftEyebrow;
    public GameObject rightEyebrow;
}

public enum FacePieceType
{
    LEFTEYE,
    RIGHTEYE,
    NOSE,
    MOUTH,
    LEFTEAR,
    RIGHTEAR,
    LEFTEYEBROW,
    RIGHTEYEBROW
}