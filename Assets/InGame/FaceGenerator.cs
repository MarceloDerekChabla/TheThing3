using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceGenerator : MonoBehaviour
{
    [SerializeField] Transform[] positionArray;
    [SerializeField] Transform middle;

    [SerializeField] FacePieceSavedSettings savedLeftEyeSettings;
    [SerializeField] FacePieceSavedSettings savedRightEyeSettings;
    [SerializeField] FacePieceSavedSettings savedNoseSettings;
    [SerializeField] FacePieceSavedSettings savedMouthSettings;
    [SerializeField] FacePieceSavedSettings savedLeftEarSettings;
    [SerializeField] FacePieceSavedSettings savedRightEarSettings;
    [SerializeField] FacePieceSavedSettings savedLeftEyebrowSettings;
    [SerializeField] FacePieceSavedSettings savedRightEyebrowSettings;

    public RandomizerSettings randomSettings;
    public SavedFace savedFace;

    FacePieceType facePieceType;

    GameObject createdHead;
    public FaceTypeSO faceType;
    public int correctAnswer {get; private set;}

    public void GenerateRandomFace()
    {
        GenerateRandomFace(middle.position);
    }

    public void DestroyRandomHead()
    {
        Destroy(createdHead);
    }

    public void GenerateSavedFaces()
    {
        int randomPlacement = Random.Range(0, positionArray.Length);

        for (int i = 0; i < positionArray.Length; i++)
        {
            if (i == randomPlacement)
            {
                GenerateSavedFace(positionArray[i].position, false);
                correctAnswer = i;
            }
            else
            {
                GenerateSavedFace(positionArray[i].position, true);
            }
        }
        DestroyRandomHead();
    }

    public void GenerateRandomFace(Vector3 position)
    {
        //Head
        int randomHeadChoice = Random.Range(0, faceType.headArray.Length);

        GameObject newHead = Instantiate(faceType.headArray[randomHeadChoice], position, Quaternion.identity);
        FaceSpotInfo faceSpots = newHead.GetComponent<FaceSpotInfo>();
        savedFace.head = Instantiate(newHead, position, Quaternion.identity);;
        createdHead = newHead;
        //Eyes
        facePieceType = FacePieceType.LEFTEYE;
        GameObject leftEye = GenerateRandomFacePiece(faceSpots.leftEyeSpot, faceType.eyeArray, faceType.leftEyeSettings);
        savedFace.leftEye = leftEye;

        facePieceType = FacePieceType.RIGHTEYE;
        GameObject rightEye = GenerateSavedFacePiece(faceSpots.rightEyeSpot, savedFace.leftEye, faceType.rightEyeSettings, true);
        FlipFacePiece(rightEye);
        savedFace.rightEye = rightEye;

        leftEye.transform.SetParent(createdHead.transform);
        rightEye.transform.SetParent(createdHead.transform);
        //Nose
        facePieceType = FacePieceType.NOSE;
        GameObject nose = GenerateRandomFacePiece(faceSpots.noseSpot, faceType.noseArray, faceType.noseSettings);
        savedFace.nose = nose;
        nose.transform.SetParent(createdHead.transform);
        //Mouth
        facePieceType = FacePieceType.MOUTH;
        GameObject mouth = GenerateRandomFacePiece(faceSpots.mouthSpot, faceType.mouthArray, faceType.mouthSettings);
        savedFace.mouth = mouth;
        mouth.transform.SetParent(createdHead.transform);
        //Ears
        facePieceType = FacePieceType.LEFTEAR;
        GameObject leftEar = GenerateRandomFacePiece(faceSpots.leftEarSpot, faceType.earArray, faceType.leftEarSettings);
        savedFace.leftEar = leftEar;

        facePieceType = FacePieceType.RIGHTEAR;
        GameObject rightEar = GenerateSavedFacePiece(faceSpots.rightEarSpot, savedFace.leftEar, faceType.rightEarSettings, true);
        FlipFacePiece(rightEar);
        savedFace.rightEar = rightEar;

        leftEar.transform.SetParent(createdHead.transform);
        rightEar.transform.SetParent(createdHead.transform);
        //Eyebrows
        facePieceType = FacePieceType.LEFTEYEBROW;
        GameObject leftEyebrow = GenerateRandomFacePiece(faceSpots.leftEyebrowSpot, faceType.eyebrowArray,
        faceType.leftEyebrowSettings);
        savedFace.leftEyebrow = leftEyebrow;

        facePieceType = FacePieceType.RIGHTEYEBROW;
        GameObject rightEyebrow = GenerateSavedFacePiece(faceSpots.rightEyebrowSpot, savedFace.leftEyebrow,
        faceType.rightEyebrowSettings, true);
        FlipFacePiece(rightEyebrow);
        savedFace.rightEyebrow = rightEyebrow;

        leftEyebrow.transform.SetParent(createdHead.transform);
        rightEyebrow.transform.SetParent(createdHead.transform);
    }

    public void GenerateSavedFace(Vector3 position, bool randomize)
    {
        //Head
        GameObject newHead = Instantiate(savedFace.head, position, Quaternion.identity);
        FaceSpotInfo faceSpots = newHead.GetComponent<FaceSpotInfo>();
        //Eyes
        facePieceType = FacePieceType.LEFTEYE;
        GenerateSavedFacePiece(faceSpots.leftEyeSpot, savedFace.leftEye, randomSettings.leftEyeSettings, randomize);
        facePieceType = FacePieceType.RIGHTEYE;
        GenerateSavedFacePiece(faceSpots.rightEyeSpot, savedFace.rightEye, randomSettings.rightEyeSettings, randomize);
        //Nose
        facePieceType = FacePieceType.NOSE;
        GenerateSavedFacePiece(faceSpots.noseSpot, savedFace.nose, randomSettings.noseSettings, randomize);
        //Mouth
        facePieceType = FacePieceType.MOUTH;
        GenerateSavedFacePiece(faceSpots.mouthSpot, savedFace.mouth, randomSettings.mouthSettings, randomize);
        //Ears
        facePieceType = FacePieceType.LEFTEAR;
        GenerateSavedFacePiece(faceSpots.leftEarSpot, savedFace.leftEar, randomSettings.leftEarSettings, randomize);
        facePieceType = FacePieceType.RIGHTEAR;
        GenerateSavedFacePiece(faceSpots.rightEarSpot, savedFace.rightEar, randomSettings.rightEarSettings, randomize);
        //Eyebrows
        facePieceType = FacePieceType.LEFTEYEBROW;
        GenerateSavedFacePiece(faceSpots.leftEyebrowSpot, savedFace.leftEyebrow, randomSettings.leftEyebrowSettings, randomize);
        facePieceType = FacePieceType.RIGHTEYEBROW;
        GenerateSavedFacePiece(faceSpots.rightEyebrowSpot, savedFace.rightEyebrow, randomSettings.rightEyebrowSettings, randomize);
    }

    GameObject GenerateRandomFacePiece(Transform spot, GameObject[] facePieceArray, FacePieceRandomizeSettings facePieceSettings)
    {
        int randomChoice = Random.Range(0, facePieceArray.Length);
        //Debug.Log(randomChoice);

        GameObject newFacePiece = Instantiate(facePieceArray[randomChoice], spot.position, Quaternion.identity);
        RandomizeFacePiece(newFacePiece.transform, facePieceSettings, facePieceType, true);
        return newFacePiece;
    }

    GameObject GenerateSavedFacePiece(Transform spot, GameObject facePiece, FacePieceRandomizeSettings facePieceSettings, bool randomize)
    {
        GameObject newFacePiece = Instantiate(facePiece, spot.position, facePiece.transform.rotation);
        newFacePiece.transform.localScale = facePiece.transform.lossyScale;

        if (!randomize)
        {
            AddToFacePieceSettingSwitcher(facePieceType, newFacePiece.transform);
            return newFacePiece;
        }
        
        RandomizeFacePiece(newFacePiece.transform, facePieceSettings, facePieceType, false);
        return newFacePiece;
    }

    void RandomizeFacePiece(Transform facePieceTransform, FacePieceRandomizeSettings facePieceSettings, FacePieceType facePieceType,
                            bool saveFace)
    {
        //Changes Face Piece Position
        float randomPosX = Random.Range(facePieceSettings.minPositionChangeAmount.x, facePieceSettings.maxPositionChangeAmount.x);
        float randomPosY = Random.Range(facePieceSettings.minPositionChangeAmount.y, facePieceSettings.maxPositionChangeAmount.y);

        Vector3 randomnessToPosition = new Vector3(randomPosX, randomPosY, 0f);
        facePieceTransform.position += randomnessToPosition;

        //Changes Face Piece Scale
        float randomScaleX = Random.Range(facePieceSettings.minScaleChangeAmount.x, facePieceSettings.maxScaleChangeAmount.x);
        float randomScaleY = Random.Range(facePieceSettings.minScaleChangeAmount.y, facePieceSettings.maxScaleChangeAmount.y);

        Vector3 randomnessToScale = new Vector3(randomScaleX, randomScaleY, 0f);
        facePieceTransform.localScale += randomnessToScale;

        //Changes Face Piece Rotation
        float randomRotation = Random.Range(facePieceSettings.minRotationChangeAmount, facePieceSettings.maxRotationChangeAmount);

        Quaternion newFaceRotation = Quaternion.Euler(facePieceTransform.rotation.eulerAngles
        + new Vector3(0f, 0f, randomRotation));
        facePieceTransform.rotation = newFaceRotation;

        if (saveFace)
            SaveToFacePieceSettingSwitcher(facePieceType, randomPosX, randomPosY, randomScaleX, randomScaleY, randomRotation);
    }

    void SaveToFacePieceSettingSwitcher(FacePieceType facePieceType, float ranPosX,float ranPosY,
                                        float ranScaleX, float ranScaleY, float ranRot)
    {
        //Debug.Log("Firing");
        switch (facePieceType)
        {
            case FacePieceType.LEFTEYE:
                savedLeftEyeSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.RIGHTEYE:
                savedRightEyeSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.NOSE:
                savedNoseSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.MOUTH:
                savedMouthSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.LEFTEAR:
                savedLeftEarSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.RIGHTEAR:
                savedRightEarSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.LEFTEYEBROW:
                savedLeftEyebrowSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
            case FacePieceType.RIGHTEYEBROW:
                savedRightEyebrowSettings = SaveToFacePieceSettings(ranPosX, ranPosY, ranScaleX, ranScaleY, ranRot);
                break;
        }
    }

    FacePieceSavedSettings SaveToFacePieceSettings(float ranPosX,float ranPosY,
                                 float ranScaleX, float ranScaleY, float ranRot)
    {
        FacePieceSavedSettings savedSettings = new FacePieceSavedSettings
        {
            randomPosX = ranPosX,
            randomPosY = ranPosY,
            randomScaleX = ranScaleX,
            randomScaleY = ranScaleY,
            randomRotation = ranRot
        };
        return savedSettings;
    }

    void AddToFacePieceSettingSwitcher(FacePieceType facePieceType, Transform facePieceTransform)
    {
        switch (facePieceType)
        {
            case FacePieceType.LEFTEYE:
                AddSavedSettingsToFacePiece(facePieceTransform, savedLeftEyeSettings);
                break;
            case FacePieceType.RIGHTEYE:
                AddSavedSettingsToFacePiece(facePieceTransform, savedRightEyeSettings);
                break;
            case FacePieceType.NOSE:
                AddSavedSettingsToFacePiece(facePieceTransform, savedNoseSettings);
                break;
            case FacePieceType.MOUTH:
                AddSavedSettingsToFacePiece(facePieceTransform, savedMouthSettings);
                break;
            case FacePieceType.LEFTEAR:
                AddSavedSettingsToFacePiece(facePieceTransform, savedLeftEarSettings);
                break;
            case FacePieceType.RIGHTEAR:
                AddSavedSettingsToFacePiece(facePieceTransform, savedRightEarSettings);
                break;
            case FacePieceType.LEFTEYEBROW:
                AddSavedSettingsToFacePiece(facePieceTransform, savedLeftEyebrowSettings);
                break;
            case FacePieceType.RIGHTEYEBROW:
                AddSavedSettingsToFacePiece(facePieceTransform, savedRightEyebrowSettings);
                break;
        }
    }

    void AddSavedSettingsToFacePiece(Transform facePieceTransform, FacePieceSavedSettings savedSettings)
    {
        Vector3 randomnessToPosition = new Vector3(savedSettings.randomPosX, savedSettings.randomPosY, 0f);
        facePieceTransform.position += randomnessToPosition;

        // Vector3 randomnessToScale = new Vector3(savedSettings.randomScaleX, savedSettings.randomScaleY, 0f);
        // facePieceTransform.localScale += randomnessToScale;

        //Changes Face Piece Rotation
        // Quaternion newFaceRotation = Quaternion.Euler(facePieceTransform.rotation.eulerAngles
        // + new Vector3(0f, 0f, savedSettings.randomRotation));
        // facePieceTransform.rotation = newFaceRotation;
    }

    void FlipFacePiece(GameObject facePiece)
    {
        facePiece.transform.localScale = new Vector3(-facePiece.transform.localScale.x, facePiece.transform.localScale.y,
                                         facePiece.transform.localScale.z);
    }
}