using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityChess;

public class BoardHighlights : MonoBehaviour
{

    public static BoardHighlights Instance { set; get; }

    public GameObject highlightPrefab;
    private List<GameObject> highlights;

    private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
    }

    private GameObject GetHighLightObject()
    {
        GameObject go = highlights.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
        }

        return go;
    }

    public void HighLightAllowedMoves(Piece piece)
    {

        string debMsg = $"# of valid moves: {piece.LegalMoves.Count}\n";
        foreach (Movement validMove in piece.LegalMoves)
        {
            GameObject go = GetHighLightObject();
            go.SetActive(true);
            go.transform.position = new Vector3(2f, 0.0003f, 0.9f);

            //TODO NEED TO DISSECT THE TREE OF MOVEMENT -> START/END -> SQUARE -> FILE/RANK
            debMsg += "Start = " + $"{validMove.Start}\n";
        }
        Debug.LogWarning(debMsg);
        //GameObject go = GetHighLightObject();
        //go.SetActive(true);
        //go.transform.position = new Vector3(i + 0.5f, 0.0001f, j + 0.5f);


        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        if (moves[i, j])
        //        {
        //            GameObject go = GetHighLightObject();
        //            go.SetActive(true);
        //            go.transform.position = new Vector3(i + 0.5f, 0.0001f, j + 0.5f);
        //        }
        //    }

    }

    public void HideHighlights()
    {
        foreach (GameObject go in highlights)
            go.SetActive(false);
    }
}
