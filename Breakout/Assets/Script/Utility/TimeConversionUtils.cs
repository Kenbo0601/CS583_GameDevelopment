using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utility class for time conversion 
public static class TimeConversionUtils
{
   public static string ConvertTime(float time)
   {
      // convert the elapsed time to minutes and seconds
      int min = Mathf.FloorToInt(time / 60F);
      int sec = Mathf.FloorToInt(time % 60F);
      int milliSec = Mathf.FloorToInt((time * 100F) % 100F); 
      
      return $"{min:D2}:{sec:D2}:{milliSec:D2}";
   }
}
