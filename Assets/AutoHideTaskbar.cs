using UnityEngine;

public class AutoHideTaskbar : MonoBehaviour
{
    public GameObject taskbar;

    void Update()
    {
        if ((Input.touchCount != 0) || ((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)))
        {
            taskbar.SetActive(true);
            CancelInvoke("HideUISystem");
        }

        else
        {
            Invoke("HideUISystem", 1f);
        }
    }

    void HideUISystem()
    {
        taskbar.SetActive(false);
    }
}
