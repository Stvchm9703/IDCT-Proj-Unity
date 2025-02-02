﻿using System;
using System.Collections;
using System.Collections.Generic;
//using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using PlayCli.ProtoMod;
//using SocketIOClient;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UIElements;
using UnityEngine.UI;
public class scriptGameVS : MonoBehaviour {
    // Background image from "board.png" asset
    public Texture2D background;
    // Cell image from "cell.png" asset
    public GameObject ImgBackground;

    public Texture2D cell;
    // List of sprites used in "cells" and other controls
    public List<Sprite> sprites;
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
    public List<GameObject> cellButton;
    private List<int> sums; // 3 Horizontal, 3 vertical and 2 diagonal sums to find best move or detect winning.
    // --------------------------------------------------------------------------
    // PlayCli implement 
    //  -1 == Host
    //  1 == Dueler
    private DuelConnObj DuelConn;
    public bool IsConnected = false;
    // public CancellationTokenSource close_tkn;
    public int player_sign = 1;

    // public DuelConnObjv2 
    // --------------------------------------------------------------------------
    public GameObject AlertPanel;

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Connector");
        if (objs.Length == 1) {
            DuelConn = objs[0].GetComponent<DuelConnObj>();
            IsConnected = true;
        }
    }

    // Initialization
    void Start() {
        //                           0 1 2
        // Cell array for the board: 3 4 5
        //                           6 7 8
        // cells = new List<int>(9) { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        sums = new List<int>(8) { 0, 0, 0, 0, 0, 0, 0, 0 }; // 3 Horizontal, 3 vertical and 2 diagonal
        winnerCells = new ArrayList();

        ImgBackground.SetActive(false);
        gameReset();
        // GUIRenderCell();
        Debug.Log("room key:" + this.DuelConn.current_room.Key);
        player_sign = this.DuelConn.IsHost ? 1 : -1;

        InitRoomStatus();
        GUIRenderCell();
        OnConnectionInit();
    }
    // --------------------------------------------------------------------------
    // Update everything
    void msgChatMsg(SocketIOClient.Arguments.ResponseArgs msgPack) {
        Debug.Log(msgPack.RawText);
    }

    void msgSystMsg(SocketIOClient.Arguments.ResponseArgs msgPack) {
        Debug.Log(msgPack.Text);
        var msg = CellStatusResp.Parser.ParseFrom(
            ByteString.FromBase64(msgPack.Text.Trim('"')));
        Debug.Log(msg);
        if (msg.ErrorMsg == null) {
            Debug.Log(msg.CellStatus);
            VsPlayerCellClick(msg.CellStatus.CellNum);
        } else {
            ErrorMsgHandler(msg);
        }
        gameUpdateIndicator();
        return;
    }

    void OnConnectionInit() {
        Debug.Log("start to connect Broadcast");
        // var KvMap = new Dictionary<string, SocketIOClient.EventHandler>();
        // KvMap.Add("chat_msg_recv", msgChatMsg);
        // KvMap.Add("syst_msg", msgSystMsg);
        // await this.DuelConn.ConnectToBroadcast(null, KvMap);

    }

    async void OnDestroy() {
        await this.DuelConn.ExitRoom();
    }

    void ErrorMsgHandler(CellStatusResp em) {
        Debug.Log(em);
        switch (em.ErrorMsg.MsgInfo) {
            case "ConnEnd":
                if (em.UserId != DuelConn.conn.HostId) {
                    if (em.UserId == DuelConn.current_room.HostId ||
                        em.UserId == DuelConn.current_room.DuelerId) {
                        Debug.Log("Player quit");
                    } else if (em.UserId == "RmSvrMgr") {
                        Debug.Log("RmSvrMgr");
                        // show UI alert
                    } else {
                        Debug.Log("watcher!");
                    }
                } else {
                    Debug.Log("self quit msg?");
                }
                break;
                // case "": 
            case "RoomClose":
                // show UI RoomClose alert 

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
        // Debug.Log("GUIRenderCell");
        Debug.Log(cells.Count);
        Debug.Log(this.sprites.Count);
        int i = 0;
        for (i = 0; i < cells.Count; i++) {
            Debug.Log("i:" + i.ToString() + ",v:" + cells[i]);
            Debug.Log(sprites[1].texture.name);
            // Debug.Log(this.cellButton[i].GetComponent<Image>());
            var tmp = this.cellButton[i];
            Debug.Log("thia");
            if (tmp == null) {
                Debug.Log("thia");
                tmp = GameObject.Find("cell" + i.ToString()).gameObject;
                Debug.Log("thia");

            }
            Debug.Log("tmp[" + i.ToString() + "]" + tmp.name);
            if (cells[i] == 1) {
                Debug.Log("in 1");
                this.cellButton[i].GetComponent<Image>().overrideSprite = sprites[1];
                // this.cellButton[i].
            } else if (cells[i] == -1) {
                Debug.Log("in -1");
                this.cellButton[i].GetComponent<Image>().overrideSprite = sprites[2];
            }
        }
        return;
    }
    public async void PlayerCellClick(int cell_num) {
        Debug.Log("-----------------Self------------------");
        Debug.Log(cell_num);
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
            } catch (RpcException e) {
                Debug.LogError(e);
            }
            cellSetValue(cell_num, player_sign);
            GUIRenderCell();
            onTurnComplete(this.player_sign);
        }
        Debug.Log("-----------------End Self------------------");

    }

    public void VsPlayerCellClick(int cell_num) {
        Debug.Log("-----------------VS------------------");
        Debug.Log(cell_num);
        // if (cells[cell_num] == 0 &&
        //     !isGameOver
        // ) {
        cellSetValue(cell_num, player_sign * -1);
        GUIRenderCell();
        onTurnComplete(this.player_sign * -1);
        // }
        Debug.Log("-----------------End VS------------------");
    }
    // @OK 
    public void backToMenu() {
        // GiveUp
        SceneManager.LoadScene("RoomSearch", LoadSceneMode.Single);
    }

    public void GameAlertOpen(string msg) {

        if (AlertPanel != null) {
            this.AlertPanel.SetActive(true);
            this.AlertPanel.transform.Find("Text").gameObject.GetComponent<Text>().text = msg;
        }
    }
    public void GameAlertClose() {

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
        if (Math.Abs(theTurn) == 1) {
            turn = theTurn;
        }
        // Override global value if parameter is set

        isGameOver = true; // Gaming is disabled
        gameUpdateGameOver();
        gameUpdateIndicator();

        if (Debug.isDebugBuild) {
            Debug.Log(string.Format("Call of gameStop({0}) complete", theTurn));
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

}