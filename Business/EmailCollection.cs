using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Business
{
    public class EmailCollection : ICollection<IEmail>
    {
        protected ArrayList _innerArray;
        protected bool _IsReadOnly;

        public EmailCollection()
        {
            _innerArray = new ArrayList();
            _IsReadOnly = false;
        }

        public virtual IEmail this[int index]
        {
            get
            {
                return (IEmail)_innerArray[index];
            }
            set
            {
                _innerArray[index] = value;
            }
        }

        public void Add(IEmail item)
        {
            _innerArray.Add(item);
        }

        public void Clear()
        {
            _innerArray.Clear();
        }

        public bool Contains(IEmail item)
        {
            foreach (IEmail obj in _innerArray)
            {
                if (obj.EmailAddressTo == item.EmailAddressTo)
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(IEmail[] array, int arrayIndex)
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

        public bool Remove(IEmail item)
        {
            bool result = false;

            for (int i = 0; i < _innerArray.Count; i++)
            {
                IEmail obj = (IEmail)_innerArray[i];

                if (obj.EmailAddressTo == item.EmailAddressTo)
                {
                    _innerArray.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }

        public IEnumerator<IEmail> GetEnumerator()
        {
            return new EmailEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EmailEnumerator(this);
        }
    }

    public class EmailEnumerator : IEnumerator<IEmail>
    {
        protected EmailCollection _collection;
        protected int index;
        protected IEmail _current;

        public EmailEnumerator()
        {
        }

        public EmailEnumerator(EmailCollection collection)
        {
            _collection = collection;
            index = -1;
            _current = default(IEmail);
        }

        public virtual IEmail Current
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
            _current = default(IEmail);
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
            _current = default(IEmail);
            index = -1;
        }
    }
}
