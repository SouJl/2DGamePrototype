using PixelGame.Interfaces;
using PixelGame.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Model.Utils
{
    public class ViewService : IViewService
    {
        private readonly Dictionary<string, ObjectPool> _viewCashe;

        private Transform _root = null;

        public ViewService(Transform root)
        {
            _viewCashe = new Dictionary<string, ObjectPool>();
            _root = root;
        }

        public T Instantiate<T>(LevelObjectView prefab)
        {
            if (!_viewCashe.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab, _root);
                _viewCashe[prefab.name] = viewPool;
            }

            if (viewPool.Pop().TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }


        public void Destroy(LevelObjectView gameObject)
        {
            _viewCashe[gameObject.name].Push(gameObject);
        }
    }
}
