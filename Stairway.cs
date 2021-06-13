﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairway : MonoBehaviour
{
    //References
    Game_manager gameManager;
    Player player;

    List<AbstractWaiter> waiters = new List<AbstractWaiter>();
    List<Vector2> positions = new List<Vector2>();

    private void MovePhysciallyUpTo(int index) 
    {
        for (int i = index; i < waiters.Count; i++)
        {
            ChangePos(waiters[i], i--);
        }
    }

    public void RegularGotHit()
    {
        int index = player.currentPositionIndex - 1;
        //Play Hit-Animation for player and Regular
        if (waiters[index].CheckHolyness()) { gameManager.Loose(); return; }
        waiters[index].GoToHell();
        waiters.RemoveAt(index);
        MovePhysciallyUpTo(index);
        if (player.currentPositionIndex == 0) { gameManager.PlayerGotToGates(); }
    }

    public void RegularGotHandShaken()
    {
        int index = player.currentPositionIndex - 1;
        //Play Handshake-Animation for player and Regular
        if (waiters[index].CheckHolyness())
        {
            Swap(player, waiters[index]);
        }
    }

    private void ChangePos(AbstractWaiter waiter, int index)
    {
        waiter.MoveToPos(positions[index]);  //physical Movement
        waiter.currentPositionIndex = index; //change index-reference
    }

    private void Swap(AbstractWaiter newFirst, AbstractWaiter newSecond)
    {
        waiters.RemoveAt(newFirst.currentPositionIndex);
        waiters.Insert(newSecond.currentPositionIndex, newFirst);
        ChangePos(newFirst, newFirst.currentPositionIndex);
        ChangePos(newSecond, newSecond.currentPositionIndex);
    }
}
