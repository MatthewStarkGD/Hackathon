using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortOrderRendering : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.sortingOrder = (int)(-transform.position.y + 8);
    }
}
