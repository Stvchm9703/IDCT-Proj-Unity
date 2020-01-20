using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using PlayCli.ProtoModv2;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scriptGameVS : MonoBehaviour {
    // Background image from "board.png" asset
    public Texture2D background;
    // Cell image from "cell.png" asset
    public GameObject ImgBackground;

    public Texture2D cell;
    // List of sprites used in "cells" and other controls
    public Sprite[] sprites;
    // Control to output the "Indicator" state
    public Image imageIndicator;
    // Control to output the text near the "Indicator" image
    public Text textIndicator;

    // Swaps between 1 and -1 on each turn. -1 means "o" turn, 1 means "x" turn
    private int turn;
    // End of game flag. If true, winner contains result of the game
    public bool isGameOver;
    private int winner;
    // Winner of game,  1 for "x", -1 for "o", 0 - draw. Valid only if isGameOver and not isDraw
    private ArrayList winnerCells;
    // Array of cells that take line or diagonal or both. Can be used for special effects, like stroke or blinking.
    public int[] cells; // Board cells. 1 for "x", -1 for "o", by default is Zero, means empty
    private int[] sums; // 3 Horizontal, 3 vertical and 2 diagonal sums to find best move or detect winning.
    // --------------------------------------------------------------------------
    // PlayCli implement 
    //  -1 == Host
    //  1 == Dueler
    private DuelConnObjv2 DuelConn;
    public bool IsConnected = false;
    public CancellationTokenSource close_tkn;
    public int player_sign = 1;

    // public DuelConnObjv2 
    // --------------------------------------------------------------------------
    // Initialization
    void Start () {
        //                           0 1 2
        // Cell array for the board: 3 4 5
        //                           6 7 8
        cells = new int[9];
        sums = new int[8]; // 3 Horizontal, 3 vertical and 2 diagonal
        winnerCells = new ArrayList ();
        ImgBackground.SetActive (false);
        gameReset ();
        GUIRenderCell ();
        if (close_tkn == null) {
            close_tkn = new CancellationTokenSource ();
            Debug.Log ("close_tkn: " + close_tkn.IsCancellationRequested);
        }
        Debug.Log ("room key:" + this.DuelConn.current_room);
        player_sign = this.DuelConn.IsHost ? 1 : -1;
    }
    void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag ("Connector");
        if (objs.Length == 1) {
            DuelConn = objs[0].GetComponent<DuelConnObjv2> ();
            IsConnected = true;
        }
    }
    // void Start()

    // --------------------------------------------------------------------------
    // Update everything
    async void Update () {
        if (IsConnected) {
            using (var t = DuelConn.StartGStream ()) {
                Debug.Log ("is stream?");
                Debug.Log ("close token" + close_tkn.IsCancellationRequested);
                while (await t.ResponseStream.MoveNext (close_tkn.Token)) {
                    Debug.Log ("called");
                    Debug.Log (t.ResponseStream.Current);
                }
            }
        }
        if (isGameOver) {
            return;
        }
        // if (turn == -1) {
        //     // turnByAI (turn);
        // }
        gameUpdateIndicator ();
    }

    // IEnumerator SearchDuelConn () {
    //     yield return new WaitForSeconds (1);
    //     var t = GameObject.Find ("DuelConnObj");
    //     Debug.Log (t);
    //     if (t != null) {
    //         DuelConn = t.GetComponent<DuelConnObjv2> ();
    //         IsConnected = true;
    //         yield return true;
    //     } else {
    //         yield return new WaitForSeconds (1);
    //     }
    // }
    void GUIRenderCell () {
        for (int i = 0; i < cells.Length; i++) {
            Sprite sprite = sprites[0];
            if (cells[i] == 1)
                sprite = sprites[1];
            if (cells[i] == -1)
                sprite = sprites[2];
            GameObject.Find ("CellRendBox/cell" + i.ToString ()).GetComponent<Image> ().sprite = sprite;
        }
    }
    public void PlayerCellClick (int cell_num) {
        Debug.Log (cell_num);
        if (cells[cell_num] == 0 && !isGameOver && this.DuelConn.able_update) {
            cellSetValue (cell_num, player_sign);
            DuelConn.UpdateTurn (new CellStatus {
                Key = this.DuelConn.current_room.Key,
                    Turn = player_sign,
                    CellNum = cell_num + 1,
            });
            GUIRenderCell ();
            onTurnComplete (1);
        }
    }

    // @OK 
    public void backToMenu () {
        // GiveUp
        SceneManager.LoadScene ("RoomSearch", LoadSceneMode.Single);
    }

    public async void giveUp () {
        Debug.Log ("give up on click");
        await DuelConn.ExitRoom ();
        backToMenu ();
    }
    // ==============================================================================
    // Game and states control
    // ==============================================================================

    // --------------------------------------------------------------------------
    // Resets cells and set all variables to defaults. Used in Start() and buttonResetGame.onClick.
    public void gameReset () {
        int i;
        for (i = 0; i < cells.Length; i++) {
            cells[i] = 0; // Fill with zeros
        }
        for (i = 0; i < sums.Length; i++) {
            sums[i] = 0; // Fill with zeros
        }
        winnerCells.Clear ();
        turn = 1; // "x" turn by default
        isGameOver = false; // Gaming is allowed
        winner = 0; // Draw by default
    }

    // --------------------------------------------------------------------------
    // Called when there is no turn, some player wins, or critical error occurs
    void gameStop (int theTurn) {
        if (Math.Abs (theTurn) == 1)
            turn = theTurn;
        // Override global value if parameter is set

        isGameOver = true; // Gaming is disabled
        gameUpdateGameOver ();
        gameUpdateIndicator ();

        if (Debug.isDebugBuild) {
            Debug.Log (string.Format ("Call of gameStop({0}) complete", theTurn));
        }
    }

    // --------------------------------------------------------------------------
    // Updates image of turn/winner and text near it
    void gameUpdateIndicator () { // Output "Indicator" text
        if (textIndicator) {
            if (!isGameOver) {
                textIndicator.text = "Next turn";
            } else if (winner == 0) {
                textIndicator.text = "It's a draw";
            } else {
                textIndicator.text = "Winner is";
            }
        }

        // Draw "Indicator" image
        if (imageIndicator) {
            if (!isGameOver) {
                if (turn == 1) {
                    imageIndicator.sprite = sprites[1];
                } else if (turn == -1) {
                    imageIndicator.sprite = sprites[2];
                } else {
                    imageIndicator.sprite = sprites[0];
                }
            } else {
                if (winner == 1) {
                    imageIndicator.sprite = sprites[1];
                } else if (winner == -1) {
                    imageIndicator.sprite = sprites[2];
                } else {
                    imageIndicator.sprite = sprites[0];
                }
            }

        }

    }
    // void gameUpdateIndicator()

    // --------------------------------------------------------------------------
    // Returns true if there is some winning line

    bool gameIsThereWinner () {
        cellSumsUpdate ();
        foreach (int i in sums) {
            if (Math.Abs (i) >= 3) {
                return true;
            }
        }
        return false;
    }

    // --------------------------------------------------------------------------
    // Called when game is over to get winner and winning lines

    void gameUpdateGameOver () {
        if (!isGameOver)
            return;

        // Verify is there winner. Get list of winning cells to blink, mark or something
        winner = 0;
        winnerCells.Clear ();
        for (int i = 0; i < sums.Length; i++) {
            if (Math.Abs (sums[i]) >= 3) {
                int a, b, c;
                if (cellBySum (i, out a, out b, out c)) {
                    winnerCells.Add (a);
                    winnerCells.Add (b);
                    winnerCells.Add (c);
                }
                // There is some winner
                if (sums[i] > 0) {
                    winner = 1;
                } else {
                    winner = -1;
                }
            }
        }

    }

    // --------------------------------------------------------------------------
    // Event is called at the end of every turn.
    void onTurnComplete (int theTurn = 0) {
        if (Math.Abs (theTurn) == 1) {
            turn = theTurn;
        }
        // Override global value if parameter is set

        cellSumsUpdate ();

        if (cellEmptyCount () < 1) {
            gameStop (turn);
            return; // Stop game right there, there is no cells to make turn. Todo: Verify is it Draw?
        }

        if (gameIsThereWinner ()) {
            gameStop (turn);
            return; // Stop game right there, somebody wins
        }

        turn = turn * -1; // Set turn to opposite value
    }

    // ==========================================================================
    // Cells and board
    // ==========================================================================

    static int[, ] mapCellToSum = new int[8, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 6, 4, 2 }
    };

    // --------------------------------------------------------------------------
    // Sets value into calls[] array by index. Any changes of cells during the game process should be made using this method!
    bool cellSetValue (int index, int value = 0) {
        if (index < 0 || index >= cells.Length) {
            Debug.Log (string.Format ("Invalid index parameter for setCellValue({0}, {1})", index, value));
            return false;
        }

        if (Math.Abs (value) > 1) {
            Debug.Log (string.Format ("Invalid value parameter for setCellValue({0}, {1})", index, value));
            return false;
        }

        cells[index] = value;
        return true;
    }

    // --------------------------------------------------------------------------
    // Returns number of empty cells
    int cellEmptyCount () {
        int count = 0;
        foreach (int i in cells) {
            if (i == 0) {
                count++;
            }
        }
        return count;
    }

    // --------------------------------------------------------------------------
    // Calculates sum of 3 cells by its' indexes. Used to verify winning cells and to make good turn. Indexes must be valid!
    int cellSumOf3 (int a, int b, int c) {
        return cells[a] + cells[b] + cells[c];
    }

    int cellSumOf3 (int[] values) {
        return values[0] + values[1] + values[2];
    }

    // --------------------------------------------------------------------------
    // Updates sum scores for horizontal, vertical and diagonal lines
    void cellSumsUpdate () {
        for (int i = 0; i < mapCellToSum.GetLength (0); i++) {
            sums[i] = cellSumOf3 (mapCellToSum[i, 0], mapCellToSum[i, 1], mapCellToSum[i, 2]);
        }
    }

    // --------------------------------------------------------------------------
    // Maps index of sums[] to index of cells[]

    bool cellBySum (int index, out int a, out int b, out int c) {
        if (index < 0 || index >= mapCellToSum.GetLength (0)) {
            a = -1;
            b = -1;
            c = -1;
            return false;
        }

        a = mapCellToSum[index, 0];
        b = mapCellToSum[index, 1];
        c = mapCellToSum[index, 2];
        return true;
    }

}