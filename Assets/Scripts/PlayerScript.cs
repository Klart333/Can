﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public struct Player
    {
        public Color colour { get; set; }
        public int twoFreeHouses { get; set; }
        public int twoFreeRoads { get; set; }
        public int oneFreeCandle { get; set; }

        public int woodAmount { get; set; }
        public int clayAmount { get; set; }
        public int sheepAmount { get; set; }
        public int wheatAmount { get; set; }
        public int stoneAmount { get; set; }

        public List<Hexagons.Tile> tileList { get; set; }

        public bool isBot { get; set; }
        public bool inTheEndgame { get; set; }
        public List<Vector2> winningPosition { get; set; }
    }


    public static Player player1 = new Player();
    public static Player player2 = new Player();
    public static Player player3 = new Player();
    public static Player player4 = new Player();

    public static Player activePlayer = new Player(); // Basically copy the info from the player whos turn it is to the activePlayer variable and use it everywhere

    void Start()
    {
        player1.colour = Color.red;
        player2.colour = Color.blue;
        player3.colour = Color.green;
        player4.colour = Color.yellow;

        player1.tileList = new List<Hexagons.Tile>();
        player2.tileList = new List<Hexagons.Tile>();
        player3.tileList = new List<Hexagons.Tile>();
        player4.tileList = new List<Hexagons.Tile>();

        player1.winningPosition = new List<Vector2>();
        player2.winningPosition = new List<Vector2>();
        player3.winningPosition = new List<Vector2>();
        player4.winningPosition = new List<Vector2>();

        activePlayer = player1;



        #region Reset

        player1.woodAmount = 0;
        player1.clayAmount = 0;
        player1.sheepAmount = 0;
        player1.wheatAmount = 0;
        player1.stoneAmount = 0;

        player2.woodAmount = 0;
        player2.clayAmount = 0;
        player2.sheepAmount = 0;
        player2.wheatAmount = 0;
        player2.stoneAmount = 0;

        player3.woodAmount = 0;
        player3.clayAmount = 0;
        player3.sheepAmount = 0;
        player3.wheatAmount = 0;
        player3.stoneAmount = 0;

        player3.woodAmount = 0;
        player3.clayAmount = 0;
        player3.sheepAmount = 0;
        player3.wheatAmount = 0;
        player3.stoneAmount = 0;

        player4.woodAmount = 0;
        player4.clayAmount = 0;
        player4.sheepAmount = 0;
        player4.wheatAmount = 0;
        player4.stoneAmount = 0;

        player1.inTheEndgame = false;
        player2.inTheEndgame = false;
        player3.inTheEndgame = false;
        player4.inTheEndgame = false;

        player1.twoFreeHouses = 0;
        player2.twoFreeHouses = 0;
        player3.twoFreeHouses = 0;
        player4.twoFreeHouses = 0;

        player1.twoFreeRoads = 0;
        player2.twoFreeRoads = 0;
        player3.twoFreeRoads = 0;
        player4.twoFreeRoads = 0;


        #endregion

    }

}