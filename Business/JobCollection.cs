using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Business
{
    public class JobCollection : ICollection<IJob>
    {
        protected ArrayList _innerArray;
        protected bool _IsReadOnly;

        public JobCollection()
        {
            _innerArray = new ArrayList();
            _IsReadOnly = false;
        }

        public virtual IJob this[int index]
        {
            get
            {
                return (IJob)_innerArray[index];
            }
            set
            {
                _innerArray[index] = value;
            }
        }

        public void Add(IJob item)
        {
            _innerArray.Add(item);
        }

        public void Clear()
        {
            _innerArray.Clear();
        }

        public bool Contains(IJob item)
        {
            foreach (IJob obj in _innerArray)
            {
                if (obj.JobId == item.JobId)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(IJob[] array, int arrayIndex)
        {
            throw new Exception("This Method is not valid for this implementation.");
        }

        public int Count
        {
            get { return _innerArray.Count; }
        }

        public bool IsReadOnly
        {
            get { return _IsReadOnly; }
        }

        public bool Remove(IJob item)
        {
            bool result = false;

            for (int i = 0; i < _innerArray.Count; i++)
            {
                IJob obj = (IJob)_innerArray[i];

                if (obj.JobId == item.JobId)
                {
                    _innerArray.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }

        public IEnumerator<IJob> GetEnumerator()
        {
            return new JobEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new JobEnumerator(this);
        }
    }

    public class JobEnumerator : IEnumerator<IJob>
    {
        protected JobCollection _collection;
        protected int index;
        protected IJob _current;

        public JobEnumerator()
        {
        }

        public JobEnumerator(JobCollection collection)
        {
            _collection = collection;
            index = -1;
            _current = default(IJob);
        }

        public virtual IJob Current
        {
            get
            {
                return _current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _current;
            }
        }

        public virtual void Dispose()
        {
            _collection = null;
            _current = default(IJob);
            index = -1;
        }

        public virtual bool MoveNext()
        {
            if (++index >= _collection.Count)
            {
                return false;
            }
            else
            {
                _current = _collection[index];
            }
            return true;
        }

        // Reset the enumerator
        public virtual void Reset()
        {
            _current = default(IJob);
            index = -1;
        }
    }
}
