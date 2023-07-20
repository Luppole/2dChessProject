using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEditor;
using Unity.VisualScripting;

public class FitBackground : MonoBehaviour
{
    public bool isAspectRatio;
    private void Start()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        var worldSpaceWidth = topRightCorner.x * 2;
        var worldSpaceHeight = topRightCorner.y * 2;

        var spriteSize = GetComponent<SpriteRenderer>().bounds.size;

        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scalefactorY = worldSpaceHeight / spriteSize.y;
        if(isAspectRatio)
        {
            if (scaleFactorX > scalefactorY)
                scalefactorY = scaleFactorX;
            else
                scaleFactorX = scalefactorY;
            
        }

        transform.localScale = new Vector3((float)scaleFactorX ,(float) -scalefactorY, 1);
        //transform.position = new Vector3(topRightCorner.x / 2, topRightCorner.x / 2, 1);

    }


}
