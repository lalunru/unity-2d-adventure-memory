using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public PuzzlePieceController[] puzzlePieces;

    public void CheckAllPieces()
    {
        foreach (var piece in puzzlePieces)
        {
            if (!piece.IsPlaced())
                return;
        }

        Debug.Log("ÆÛÁñ ¿Ï¼º!");
        SceneManager.LoadScene("2.1. Quarrel");
    }
}