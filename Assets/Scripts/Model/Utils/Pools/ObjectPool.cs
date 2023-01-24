using System;
using System.Collections.Generic;
using PixelGame.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PixelGame.Model.Utils
{
    public class ObjectPool: IDisposable
    {
        private readonly Stack<LevelObjectView> _stack = new Stack<LevelObjectView>();
        private readonly LevelObjectView  _prefab;
        private readonly Transform _root;

        public ObjectPool(LevelObjectView prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public LevelObjectView Pop()
        {
            LevelObjectView go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab);
                go.name = _prefab.name;
            }
            else
            {
                go = _stack.Pop();
            }
            go.SetActive(true);
            go.OnStartExecute();
            return go;
        }

        public void Push(LevelObjectView go)
        {
            _stack.Push(go); 
            go.SetActive(false);
            go.transform.SetParent(_root);
        }

        public void Dispose()
        {
            foreach (var gameObject in _stack)
            {
                Object.Destroy(gameObject);
            }

            _stack.Clear();
        }
    }
}
