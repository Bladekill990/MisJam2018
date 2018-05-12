using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Image image;
    public Player player;

    public Door[] doorList;

    private int state;
    private bool[] unlocked;

    // Use this for initialization
    void Start () {
        state = 0;
        unlocked = new bool[6];
        unlocked[0] = true;
        for (int i=1; i < 6; i++)
        {
            unlocked[i] = false;
        }
        unlocked[1] = true;
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case 5:
                text.text = "L. S. O. M.";
                break;
            case 4:
                text.text = "RC Car";
                break;
            case 3:
                text.text = "Playbot";
                break;
            case 2:
                text.text = "Stealth Suit";
                break;
            case 1:
                text.text = "Lockpick";
                break;
            default:
                text.text = "Interact";
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
                    break;
                case 3:
                    //text.text = "Playbot";
                    break;
                case 2:
                    //text.text = "Stealth Suit";
                    break;
                case 1:
                    foreach (Door door in doorList)
                    {
                        if (!door.locked) continue;
                        else
                        {
                            Vector3 doorPos = door.getPosition();
                            if (Mathf.Abs(playerPos.x - doorPos.x) + Mathf.Abs(playerPos.y - doorPos.y) + Mathf.Abs(playerPos.z - doorPos.z) <= 2)
                            {
                                door.open();
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
                            if (Mathf.Abs(playerPos.x-doorPos.x) + Mathf.Abs(playerPos.y - doorPos.y) + Mathf.Abs(playerPos.z - doorPos.z) <= 2)
                            {
                                door.open();
                            }
                        }
                    }



                    break;
            }
        }
    }
}