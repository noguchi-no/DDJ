using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMove : MonoBehaviour
{
    public float aniStartTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.isGameStart){
            //DOVirtual.DelayedCall (0.3f, ()=> {処理});  
            //this.transform.DOMoveY(5, 0.5f).From();
        }
        
    }
}
