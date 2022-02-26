using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoButtonSelect : MonoBehaviour
{
    public Button button;

    void OnEnable()
    {
        StartCoroutine(ButtonSelectAfterDelay());
    }

    public IEnumerator ButtonSelectAfterDelay()
    {
        yield return new WaitForSecondsRealtime(.1f);

        EventSystem eventSystem = EventSystem.current;

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(button.gameObject);
    }
}
