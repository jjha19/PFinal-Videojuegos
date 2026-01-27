using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform StartPoint;
    public Transform[] path;
    private void Awake(){
        main = this;
    
    }
}
