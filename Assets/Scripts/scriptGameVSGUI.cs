﻿using System;
using System.Collections;
using System.Collections.Generic;
//using System.Text;
//using System.Threading;
using Grpc.Core;
using PlayCli.ProtoMod;
//using SocketIOClient;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UIElements;
using UnityEngine.UI;
public class scriptGameVSGUI : MonoBehaviour {
    // Background image from "board.png" asset
    public Texture2D background;
    // Cell image from "cell.png" asset
    public GameObject ImgBackground;

    public Texture2D cell;
    // List of sprites used in "cells" and other controls
    public List<Sprite> sprites;
    public List<Texture2D> CellT2D;
    // Control to output the "Indicator" state
    public Image imageIndicator;
    // Control to output the text near the "Indicator" image
    public Text textIndicator;
    // Player Indicator 
    public Image plyimgIndicator;
    public Text plytxtIndicator;

    // Swaps between 1 and -1 on each turn. -1 means "o" turn, 1 means "x" turn
    private int turn;
    // End of game flag. If true, winner contains result of the game
    public bool isGameOver;
    private int winner;
    // Winner of game,  1 for "x", -1 for "o", 0 - draw. Valid only if isGameOver and not isDraw
    private ArrayList winnerCells;
    // Array of cells that take line or diagonal or both. Can be used for special effects, like stroke or blinking.
    public List<int> cells; // Board cells. 1 for "x", -1 for "o", by default is Zero, means empty
    private List<int> sums; // 3 Horizontal, 3 vertical and 2 diagonal sums to find best move or detect winning.

    private float cellWidth, cellSpace; // Space between cel
    public GameObject CellRendBox;
    // --------------------------------------------------------------------------
    // PlayCli implement 
    //  -1 == Host
    //  1 == Dueler
    private DuelConnObj DuelConn;
    public bool IsConnected = false;
    public int player_sign = 1;
    // --------------------------------------------------------------------------
    public GameAlertPanel AlertPanelObj;
    public GiveUpPanel GiveUpPanelObj;
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Connector");
        if (objs.Length == 1) {
            DuelConn = objs[0].GetComponent<DuelConnObj>();
            IsConnected = true;
            // } else if (objs.Length > 1) {
            //     foreach (var obj in objs) {
            //         if (obj.GetComponent<DuelConnObj>().conn != null)
            //             DuelConn = obj.GetComponent<DuelConnObj>();
            //         else Destroy(obj);
            //     }
            // IsConnected = true;
        }
    }

    // Initialization
    void Start() {
        EnvSetup();
        gameReset();
        // GUIRenderCell();
        Debug.Log("room key:" + this.DuelConn.current_room.Key);
        player_sign = this.DuelConn.IsHost ? 1 : -1;

        InitRoomStatus();
        OnConnectionInit();
    }
    // --------------------------------------------------------------------------
    // Update everything

    private void OnGUI() {
        if (!AlertPanelObj.IsOpen || !GiveUpPanelObj.IsOpen) {
            GUIRenderCell();
        }

        // Draw "Indicator" text and image
    }

    void Update() {
        gameUpdateIndicator();
    }

    void EnvSetup() {
        int ScreenHeight = Screen.height - 4;
        int ScreenWidth = Screen.width - 4;
        // float dwith = ImgBackground.GetComponent<RectTransform>().rect.width;
        float DefaultRatio = ImgBackground.GetComponent<RectTransform>().rect.width / ImgBackground.GetComponent<RectTransform>().rect.height;
        float ScreenRatio = ScreenWidth / ScreenHeight;
        float wid = 0;

        if (DefaultRatio < ScreenRatio) {
            wid = ScreenHeight * DefaultRatio;
        } else if (DefaultRatio > ScreenRatio) {
            wid = ScreenWidth;
        } else {
            wid = ScreenWidth;
        }
        //                           0 1 2
        // Cell array for the board: 3 4 5
        //                           6 7 8
        sums = new List<int>(8) { 0, 0, 0, 0, 0, 0, 0, 0 }; // 3 Horizontal, 3 vertical and 2 diagonal
        winnerCells = new ArrayList();

        // Pixel sizes for Cells
        cellWidth = (float)(wid / 3 * 0.9);

        cellSpace = (float)(wid / 3 * 0.1);
        if (Debug.isDebugBuild) {
            Debug.Log(string.Format("Cell size is {0}x{1} offsets are: {2}, {3}", cellWidth, cellWidth, cellSpace, cellSpace));
        }
        ImgBackground.SetActive(false);
        for (int i = 0; i < CellT2D.Count; i++) {
            var newD = ScaleTexture(CellT2D[i], (int)cellWidth, (int)cellWidth);
            CellT2D[i] = newD;
        }
    }

    void msgSystMsg(object caller, CellStatusResp msgPack) {
        Debug.Log(caller.ToString());
        if (msgPack.ResponseMsgCase == CellStatusResp.ResponseMsgOneofCase.CellStatus) {
            Debug.Log(msgPack.CellStatus);
            this.DuelConn.current_room.CellStatus.Add(msgPack.CellStatus);
            if (msgPack.CellStatus.Turn != this.player_sign &&
                msgPack.CellStatus.CellNum > -1
            ) {
                VsPlayerCellClick(msgPack.CellStatus.CellNum);
            }
            if (DuelConn.current_room.CellStatus.Count == 10) {
                Debug.Log("Game End?");
            }
        } else {
            ErrorMsgHandler(msgPack);
        }
        return;
    }

    async void OnConnectionInit() {
        Debug.Log("start to connect Broadcast");
        this.DuelConn.AddPendingEventFunc(
            (object caller, CellStatusResp msgpack) =>
            msgSystMsg(caller, msgpack)
        );
        await this.DuelConn.ConnectToBroadcast();
    }

    async void OnDestroy() {
        await this.DuelConn.ExitRoom();
    }

    async void ErrorMsgHandler(CellStatusResp em) {
        Debug.Log($"ErrorMsgHandler {em}");
        switch (em.ErrorMsg.MsgInfo) {
            case "ConnEnd": // DDP
                // if (em.UserId != DuelConn.conn.HostId) {
                //     if (em.UserId == DuelConn.current_room.HostId ||
                //         em.UserId == DuelConn.current_room.DuelerId) {
                //         Debug.Log("Player quit");
                //     } else if (em.UserId == "RmSvrMgr") {
                //         Debug.Log("RmSvrMgr");
                //         // show UI alert
                //     } else {
                //         Debug.Log("watcher!");
                //     }
                // } else {
                //     Debug.Log("self quit msg?");
                // }
                break;

            case "RoomPlayerQuit":
                Debug.Log($"Player Quit : {em.ErrorMsg.MsgInfo}");
                StartCoroutine(this.GameAlertOpen(em.ErrorMsg.MsgDesp));
                break;
                // case "": 
            case "RoomClose":
                // show UI RoomClose alert 
                StartCoroutine(this.GameAlertOpen("Room is going close"));
                Debug.Log("RoomClose");
                await this.DuelConn.ExitRoom();
                backToMenu();
                break;
        }
    }

    async void InitRoomStatus() {
        // if (this.DuelConn.current_room != null){
        var t = await this.DuelConn.RefreshRoomInfo();
        if (t != null) {
            if (t.CellStatus.Count > 0) {
                foreach (var cs in t.CellStatus) {
                    Debug.Log(cs);
                    if (cs.CellNum > -1)
                        cells[cs.CellNum] = cs.Turn;
                }
            }
        }
        if (plyimgIndicator != null) {
            if (this.player_sign == 1) {
                plyimgIndicator.sprite = sprites[1];
            } else if (this.player_sign == -1) {
                plyimgIndicator.sprite = sprites[2];
            }
        }
        if (plytxtIndicator != null) {
            if (!this.DuelConn.able_update) {
                plytxtIndicator.text = "Watch only";
            }
        }
        return;
        // }
    }

    void GUIRenderCell() {
        float x = Screen.width;
        float y = Screen.height;

        float beginX = (float)(Screen.width / 2 - (cellWidth / 0.98 * 1.5));
        float beginY = (float)(Screen.height / 2 - (cellWidth / 0.98 * 1.5));
        for (int i = 0; i < cells.Count; i++) {
            x = (float)(beginX + (i % 3 * cellWidth) + (i % 3 * cellSpace * 0.5));
            y = (float)(beginY + (i / 3 * cellWidth) + (i / 3 * cellSpace * 0.5));
            var r = new Rect(x, y, cellWidth, cellWidth);
            var td = CellT2D[0];
            if (cells[i] == 1)
                td = CellT2D[1];
            if (cells[i] == -1)
                td = CellT2D[2];
            if (GUI.Button(r, td, GUIStyle.none)) {
                PlayerCellClick(i);
            }
        }
    }

    public async void PlayerCellClick(int cell_num) {
        Debug.Log("-----------------Self------------------");
        Debug.Log($"User Click {cell_num}");
        if (cells[cell_num] == 0 &&
            !isGameOver &&
            this.DuelConn.able_update &&
            this.turn == this.player_sign
        ) {
            var tmp = new CellStatus {
            Key = this.DuelConn.current_room.Key,
            Turn = player_sign,
            CellNum = cell_num,
            };
            Debug.Log(tmp);
            try {
                await DuelConn.UpdateTurn(tmp);
                cellSetValue(cell_num, player_sign);
                onTurnComplete(this.player_sign);
            } catch (RpcException e) {
                Debug.LogError(e);
            }
        }
        Debug.Log("-----------------End Self------------------");

    }

    public void VsPlayerCellClick(int cell_num) {
        Debug.Log("-----------------VS------------------");
        Debug.Log($"Vs Player{cell_num}");
        cellSetValue(cell_num, player_sign * -1);
        onTurnComplete(this.player_sign * -1);
        Debug.Log("-----------------End VS------------------");
    }
    // @OK 
    public void backToMenu() {
        // GiveUp
        SceneManager.LoadScene("RoomSearch", LoadSceneMode.Single);
    }

    public IEnumerator GameAlertOpen(string msg) {
        if (AlertPanelObj != null) {
            yield return AlertPanelObj.PopShow(msg);
        }
        yield return false;
    }

    public async void giveUp() {
        Debug.Log("give up on click");
        await DuelConn.ExitRoom();
        backToMenu();
    }
    // ==============================================================================
    // Game and states control
    // ==============================================================================

    // --------------------------------------------------------------------------
    // Resets cells and set all variables to defaults. Used in Start() and buttonResetGame.onClick.
    public void gameReset() {
        int i;
        Debug.Log(cells);
        for (i = 0; i < cells.Count; i++) {
            cells[i] = 0; // Fill with zeros
        }
        Debug.Log(sums);
        for (i = 0; i < sums.Count; i++) {
            sums[i] = 0; // Fill with zeros
        }
        winnerCells.Clear();
        turn = 1; // "x" turn by default
        isGameOver = false; // Gaming is allowed
        winner = 0; // Draw by default
    }

    // --------------------------------------------------------------------------
    // Called when there is no turn, some player wins, or critical error occurs
    void gameStop(int theTurn) {
        // if (Math.Abs(theTurn) == 1) {
        turn = theTurn;
        // }
        // Override global value if parameter is set

        isGameOver = true; // Gaming is disabled
        gameUpdateGameOver();
        gameUpdateIndicator();

        if (Debug.isDebugBuild) {
            Debug.Log($"Call of gameStop({ theTurn}) complete");
        }
    }

    // --------------------------------------------------------------------------
    // Updates image of turn/winner and text near it
    void gameUpdateIndicator() { // Output "Indicator" text
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
        if (imageIndicator != null) {
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

    bool gameIsThereWinner() {
        cellSumsUpdate();
        foreach (int i in sums) {
            if (Math.Abs(i) >= 3) {
                return true;
            }
        }
        return false;
    }

    // --------------------------------------------------------------------------
    // Called when game is over to get winner and winning lines

    void gameUpdateGameOver() {
        if (!isGameOver)
            return;

        // Verify is there winner. Get list of winning cells to blink, mark or something
        winner = 0;
        winnerCells.Clear();
        for (int i = 0; i < sums.Count; i++) {
            if (Math.Abs(sums[i]) >= 3) {
                int a, b, c;
                if (cellBySum(i, out a, out b, out c)) {
                    winnerCells.Add(a);
                    winnerCells.Add(b);
                    winnerCells.Add(c);
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
    void onTurnComplete(int theTurn = 0) {
        // if (Math.Abs(theTurn) == 1) {
        turn = theTurn;
        // }
        // Override global value if parameter is set
        cellSumsUpdate();

        if (cellEmptyCount() < 1) {
            gameStop(turn);
            return; // Stop game right there, there is no cells to make turn. Todo: Verify is it Draw?
        }

        if (gameIsThereWinner()) {
            gameStop(turn);
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
    bool cellSetValue(int index, int value = 0) {
        if (index < 0 || index >= cells.Count) {
            Debug.Log(string.Format("Invalid index parameter for setCellValue({0}, {1})", index, value));
            return false;
        }

        if (Math.Abs(value) > 1) {
            Debug.Log(string.Format("Invalid value parameter for setCellValue({0}, {1})", index, value));
            return false;
        }

        cells[index] = value;
        return true;
    }

    // --------------------------------------------------------------------------
    // Returns number of empty cells
    int cellEmptyCount() {
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
    int cellSumOf3(int a, int b, int c) {
        return cells[a] + cells[b] + cells[c];
    }

    int cellSumOf3(int[] values) {
        return values[0] + values[1] + values[2];
    }

    // --------------------------------------------------------------------------
    // Updates sum scores for horizontal, vertical and diagonal lines
    void cellSumsUpdate() {
        for (int i = 0; i < mapCellToSum.GetLength(0); i++) {
            sums[i] = cellSumOf3(mapCellToSum[i, 0], mapCellToSum[i, 1], mapCellToSum[i, 2]);
        }
    }

    // --------------------------------------------------------------------------
    // Maps index of sums[] to index of cells[]

    bool cellBySum(int index, out int a, out int b, out int c) {
        if (index < 0 || index >= mapCellToSum.GetLength(0)) {
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

    private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight) {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = (1.0f / (float)targetWidth);
        float incY = (1.0f / (float)targetHeight);
        for (int px = 0; px < rpixels.Length; px++) {
            rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        return result;
    }
}