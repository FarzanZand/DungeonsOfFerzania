using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySortingLayerOrder : Enemy
{

    private SpriteRenderer spriteRenderer;

    protected override void Start() {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChangeOrderInLayer(); 
    }


    private void ChangeOrderInLayer()
    {
        if(GetDistanceFromPlayerY() > 0)
        {
            spriteRenderer.sortingOrder = 7; 
        }
        else
            spriteRenderer.sortingOrder = 5;
    }
}
