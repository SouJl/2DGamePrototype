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
        private readonly Transform _mainRoot;
        private readonly Transform _root;

        public ObjectPool(LevelObjectView prefab, Transform mainRoot)
        {
            _prefab = prefab;
            _mainRoot = mainRoot;
            _root = new GameObject($"[{_prefab.name}]").transform;
            _root.position = mainRoot.position;
            _root.SetParent(_mainRoot);
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
            go.transform.SetParent(_mainRoot);
            go.OnStartExecute();
            return go;
        }

        public void Push(LevelObjectView go)
        {
            _stack.Push(go);
            go.transform.position = _root.position;
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
