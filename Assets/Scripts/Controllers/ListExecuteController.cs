using PixelGame.Interfaces;
using System;
using System.Collections;

namespace PixelGame.Controllers
{
    public class ListExecuteController : IEnumerable, IEnumerator
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;

        public int Length => _interactiveObject.Length;
        public object Current => _interactiveObject[_index];

        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }

        public ListExecuteController() { }

        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObject == null)
            {
                _interactiveObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;
        }

        #region IEnumerable/IEnumerator implementation

        public bool MoveNext()
        {
            if (_interactiveObject == null || _index == Length - 1)
                return false;
            _index++;
            return true;
        }

        public void Reset()
        {
            if (_interactiveObject == null) return;
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        #endregion
    }
}
