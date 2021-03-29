using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridControl : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public CanvasScaler canvasScaler; //defined to take the width of the game. 
                                        //If you wish, you can enter the size manually.

    private void Start()
    {
      
        CalculateGridHeight();
    }
    private void CalculateGridHeight()
    {
        RectTransform recTransform;
        float distanceOfRow,heightThisRect;
        int column, row;
        
        column = (int)(canvasScaler.referenceResolution.x
            /((gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x)
            -(gridLayoutGroup.padding.left+gridLayoutGroup.padding.right)
            ));
        row = 1 + transform.childCount / column;

        distanceOfRow = gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y;
        heightThisRect = distanceOfRow * row;
        if (heightThisRect <= 500)
            return;
        Vector2 recScale;
        recTransform = GetComponent<RectTransform>();
        recScale = recTransform.sizeDelta;
        recScale.y = heightThisRect;
        recTransform.sizeDelta = recScale;
    }
    
}
