using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LCH
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private float[,] times = { };


        private int _index = -1;

        
        
        [ContextMenu("Run")]
        private void Run()
        {
            _index = (_index + 1) % 5;
            
            var array = new int[100_000];
            var enumerable = new IEnumerable<int>[100_000];
            
            var awake = DateTime.Now;
            
            var i = 0;
            var start = DateTime.Now;
            while (i < array.Length) { i++; }
            times[0, _index] = (DateTime.Now - start).Ticks;
            
            start = DateTime.Now;
            for (var j = 0; j < array.Length; j++) { }
            times[1, _index] = (DateTime.Now - start).Ticks;
            
            start = DateTime.Now;
            foreach (var item in array) { }
            times[2, _index] = (DateTime.Now - start).Ticks;

            start = DateTime.Now;
            foreach (var item in enumerable) { }
            times[3, _index] = (DateTime.Now - start).Ticks;
            
            start = DateTime.Now;
            foreach (var item in new IEnumerable<int>[100_000]) { }
            times[4, _index] = (DateTime.Now - start).Ticks;

            Debug.Log((DateTime.Now - awake).Ticks);
        }
    }
}