using System;
using System.Collections;

namespace PixelGame.Tool
{
    internal class ExecutableList : IEnumerable, IEnumerator
    {
        private IExecute[] _executableObjects;
        private int _index = -1;

        public int Length => _executableObjects.Length;
        public object Current => _executableObjects[_index];
        public IExecute this[int index]
        {
            get => _executableObjects[index];
            private set => _executableObjects[index] = value;
        }

        public void Add(IExecute execute)
        {
            if (!CheckForInstance(execute))
                return;

            Array.Resize(ref _executableObjects, Length + 1);
            _executableObjects[Length - 1] = execute;
        }

        public void Remove(IExecute execute) 
        {
            if (!CheckForInstance(execute)) 
                return;

            RemoveAt(Array.IndexOf(_executableObjects, execute));
        }

        public void RemoveAt(int index) 
        {
            if (index < 0 || index > Length) 
                return;

            for (int i = index; i < Length - 1; i++) 
            {
                _executableObjects[i] = _executableObjects[i + 1];
            }
            Array.Resize(ref _executableObjects, Length - 1);
        }

        public void Clear()
        {
            Array.Clear(_executableObjects, 0, Length);
            _executableObjects = null;
        }

        private bool CheckForInstance(IExecute execute) 
        {
            if (_executableObjects == null)
            {
                _executableObjects = new[] { execute };
                return false;
            }
            return true;
        }

        #region IEnumerable and IEnumerator implementation

        public bool MoveNext()
        {
            if (_index == Length - 1)
                return false;
            _index++;
            return true;
        }

        public void Reset() =>
            _index = -1;

        public IEnumerator GetEnumerator() 
            => this;

        #endregion

    }
}
