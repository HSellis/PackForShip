using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTextureOpen;
    [SerializeField] private Texture2D cursorTextureClosed;

    private Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(cursorTextureOpen.width / 2, cursorTextureOpen.height / 2);
        Cursor.SetCursor(cursorTextureOpen, cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorTextureClosed, cursorHotspot, CursorMode.Auto);

        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorTextureOpen, cursorHotspot, CursorMode.Auto);
        }

    }

}
