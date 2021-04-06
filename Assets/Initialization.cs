using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    [SerializeField]
    private settings Settings;
    // Start is called before the first frame update
    void Start()
    {
        Settings.InitializeSettings();
        
    }
}
