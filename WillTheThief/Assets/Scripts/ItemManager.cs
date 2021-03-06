﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Image image;
    public Player player;
    public RCCar rckar;

    public Door[] doorList;
    public GameObject[] scrollList;
    public GameObject[] targetList;

    private int doorChannel;

    private int state;
    private bool[] unlocked;

    // Use this for initialization
    void Start () {
        doorChannel = -1;

        state = 0;
        unlocked = new bool[6];
        unlocked[0] = true;
        for (int i=1; i < 6; i++)
        {
            unlocked[i] = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(doorChannel >= 0)
        {
            channelDoor(doorChannel);
        }

        switch (state)
        {
            case 5:
                text.text = "L. S. O. M.";
                player.control = true;
                rckar.control = false;
                break;
            case 4:
                text.text = "RC Car";
                player.control = false;
                rckar.control = true;
                break;
            case 3:
                text.text = "Playbot";
                player.control = true;
                rckar.control = false;
                break;
            case 2:
                text.text = "Stealth Suit";
                player.control = true;
                rckar.control = false;
                break;
            case 1:
                text.text = "Lockpick";
                player.control = true;
                rckar.control = false;
                break;
            default:
                text.text = "Interact";
                player.control = true;
                rckar.control = false;
                break;
        }



        if (Input.GetKeyDown("q"))
        {
            if(unlocked[((state + 1) % 6)])
            {
                state = (state + 1) % 6;
            } else
            {
                int temp = (state + 1) % 6;
                while(temp != 0)
                {
                    temp = (temp + 1) % 6;
                    if (unlocked[temp])
                    {
                        break;
                    }
                }
                state = temp;
            }
        }


        if (Input.GetKeyDown("e"))
        {
            //use item!!!
            Vector3 playerPos = player.getPosition();
            switch (state)
            {
                case 5:
                    //text.text = "L. S. O. M.";
                    break;
                case 4:
                    //text.text = "RC Car";
                    Vector3 teleportPos = playerPos;
                    teleportPos.y += 2;
                    rckar.transform.position = teleportPos;
                    rckar.transform.rotation = Quaternion.identity;
                    break;
                case 3:
                    //text.text = "Playbot";
                    break;
                case 2:
                    //text.text = "Stealth Suit";
                    break;
                case 1:
                    int posInList = -1;
                    foreach (Door door in doorList)
                    {
                        posInList++;
                        if (!door.locked) continue;
                        else
                        {
                            Vector3 doorPos = door.getPosition();
                            if (Mathf.Abs(playerPos.x - doorPos.x) + Mathf.Abs(playerPos.y - doorPos.y) + Mathf.Abs(playerPos.z - doorPos.z) <= 2.5f)
                            {
                                door.open();
                                channelDoor(posInList);
                            }
                        }
                    }
                    break;
                default:
                    //distance between player and door is < 5?
                    foreach (Door door in doorList)
                    {
                        if (door.locked) continue; else
                        {
                            Vector3 doorPos = door.getPosition();
                            if (Mathf.Abs(playerPos.x-doorPos.x) + Mathf.Abs(playerPos.y - doorPos.y) + Mathf.Abs(playerPos.z - doorPos.z) <= 3.0f)
                            {
                                door.open();
                            }
                        }
                    }



                    break;
            }
        }

    }

    private void channelDoor(int doorNum)
    {
        doorChannel = doorNum;
        Door door = doorList[doorNum];
        Vector3 doorPos = door.getPosition();
        Vector3 playerPos = player.getPosition();
        if ((Mathf.Abs(playerPos.x - doorPos.x) + Mathf.Abs(playerPos.y - doorPos.y) + Mathf.Abs(playerPos.z - doorPos.z) > 5.0f) || (!door.amChannel()))
        {
            door.cancelChannel();
            doorChannel = -1;
            return;
        }
    }
}