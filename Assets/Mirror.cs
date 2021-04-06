using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : MonoBehaviour
{
    [SerializeField]
    private RectTransform mainTextInputTransform;
    [SerializeField]
    private RectTransform teleprompterPlayText;

    public void MirrorText()
    {
        Debug.Log("mirroring text");
        mainTextInputTransform.localScale = new Vector3(mainTextInputTransform.localScale.x*-1, 1,1);
        teleprompterPlayText.localScale = mainTextInputTransform.localScale;
    }
}
