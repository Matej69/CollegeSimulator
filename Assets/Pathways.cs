using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathways : MonoBehaviour {
    
    [System.Serializable]
    public class Pathway
    {
        public enum E_ID
        {
            COLLEGE,
            LIBRARY,
            BAR,
            WORKSHOP,
            SIZE
        }
        public E_ID id;
        public Transform cross, entrance;
        public Transform[] path;

        public bool IsEntrance(Transform _pos) { return _pos == entrance; }
        public bool IsCross(Transform _pos) { return _pos == cross; }
    }


    static public Pathways instance;

    public List<Pathway> pathways;



    void Awake()
    {
        instance = this;
    }

}
