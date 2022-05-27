using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MainGameManager
{
    // Start is called before the first frame update
    void Start()
    {
        MainGameManager.instance.AdjustScore(-1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
