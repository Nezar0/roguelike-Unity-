using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RoomCount
{
    private static byte roomCount = 1;
    public static byte Count
    {
        get
        {
            return roomCount;
        }
        set
        {
            roomCount = value;
        }
    }
}
