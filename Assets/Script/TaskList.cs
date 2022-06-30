using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskList
{
    public static int stone;
    public static int relic;
    public static int index;

    public static int stoneCountTask;
    public static int relicCountTask;

    public static void setDefaultCount()
    {
        stoneCountTask = 0;
        relicCountTask = 0;
    }

    public static void setDefaultIndex()
    {
        index = 0;
    }
}
