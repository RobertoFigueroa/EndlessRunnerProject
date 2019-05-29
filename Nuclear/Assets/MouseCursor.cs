using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    private void Start()
    {
        //vuelve invisible al cursor que Windows trae por deefecto
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //obtengo la posición del mouse y actualizo la posicion del sprite
        Vector2 cursorPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = cursorPosition;

    }
}
