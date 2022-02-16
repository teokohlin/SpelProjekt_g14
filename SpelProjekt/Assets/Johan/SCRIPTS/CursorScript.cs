using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{

    public Texture2D standardCursor;
    public Texture2D interactableCursor;

    void Start()
    {
        Cursor.SetCursor(standardCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeToStandardCursor()
    {
        Cursor.SetCursor(standardCursor, Vector2.zero, CursorMode.Auto);
    }
    public void ChangeToInteractableCursor()
    {
        Cursor.SetCursor(interactableCursor, Vector2.zero, CursorMode.Auto);
    }
}
