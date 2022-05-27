using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainGameManager.instance.AdjustScore(+2500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
