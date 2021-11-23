using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LCH
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private uint runNumber;


        private uint _defaultRunNumber;
        private readonly List<float>[] _times =
        {
            new List<float>(),
            new List<float>(),
            new List<float>(),
            new List<float>(),
            new List<float>(),
            new List<float>(),
        };


        private void Awake()
        {
            _defaultRunNumber = runNumber;
        }

        private void Start()
        {
            Run();
            DebugLog(10 < _defaultRunNumber);
        }


        private void Run()
        {
            var start = new DateTime();
            var array = new int[100_000];
            for (var i = 0; i < array.Length; i++) array[i] = i;
            while (0 < runNumber)
            {
                // GC.Collect(2);

                // start = DateTime.Now;
                // foreach (var a in array.Where(item => 0 <= item)) { }
                // _times[0].Add((DateTime.Now - start).Ticks);

                // start = DateTime.Now;
                // var where = array.Where(item => 0 <= item);
                // foreach (var w in where) { }
                // _times[1].Add((DateTime.Now - start).Ticks);
                
                // start = DateTime.Now;
                // foreach (var w in array) if (0 <= w) { }
                // _times[2].Add((DateTime.Now - start).Ticks);
                
                // var enumerable = new IEnumerable<int>[100_000];
                // start = DateTime.Now;
                // foreach (var item in enumerable) { }
                // _times[3].Add((DateTime.Now - start).Ticks);
                
                // var j = 0;
                // start = DateTime.Now;
                // while (j < array.Length) { j++; }
                // _times[4].Add((DateTime.Now - start).Ticks);

                // start = DateTime.Now;
                // for (var l = 0; l < new int[100_000].Length; l++) { }
                // _times[5].Add((DateTime.Now - start).Ticks);
                
                // start = DateTime.Now;
                // foreach (var item in new IEnumerable<int>[100_000]) { }
                // _times[6].Add((DateTime.Now - start).Ticks);

                runNumber--;
            }
        }

        private void DebugLog(bool onlyDebung)
        {
            foreach (var t in _times)
            {
                if (t == null || t.Count == 0) continue;
                
                if (onlyDebung)
                {
                    Debug.Log(t.Average());
                }
                else
                {
                    var sb = new StringBuilder();
                    foreach (var t1 in t) sb.Append($"{t1} ");
                    
                    Debug.Log($"{sb}, 평균: {t.Average()}");
                }
            }
        }
        
    }
}