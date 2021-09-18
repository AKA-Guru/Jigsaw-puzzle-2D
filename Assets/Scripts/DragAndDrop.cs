using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private GameObject selectedpiece;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitPiece =
                Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
           if (hitPiece.transform.CompareTag("Puzzle Piece"))
            {
                if (!hitPiece.transform.GetComponent<OnPiecesScript>().isCorrect)
                {
                    selectedpiece = hitPiece.transform.gameObject;
                    hitPiece.transform.GetComponent<OnPiecesScript>().isSelected = true;
                }
                
            }

        
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedpiece.transform.GetComponent<OnPiecesScript>().isSelected = true;
            selectedpiece = null;
        }

        if (selectedpiece != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedpiece.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
        
    }
}
