using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataNormalizer {

    public static Character MaxStats = new Character();

    public static float Normalize(Stats stat, float value ) {
        return value / MaxStats.GetStat( stat );
    }
}
