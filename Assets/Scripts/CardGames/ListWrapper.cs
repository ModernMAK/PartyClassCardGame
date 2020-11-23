using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public class EventListArgs<T> : EventArgs
    {
        public T Item { get; set; }
    }

    public class EventListIndexedArgs<T> : EventListArgs<T>
    {
        public int Index { get; set; }
    }

    public interface IEventList<T> : IList<T>
    {
        event EventHandler<EventListIndexedArgs<T>> Added;
        event EventHandler Changed;
        event EventHandler<EventListIndexedArgs<T>> Removed;
    }

    public class EventList<T> : ListWrapper<T>, IEventList<T>
    {
        public event EventHandler<EventListIndexedArgs<T>> Added;
        public event EventHandler Changed;
        public event EventHandler<EventListIndexedArgs<T>> Removed;

        public EventList() : base() { }
        public EventList(IEnumerable<T> items) : base(items){ }

        public override void Add(T item)
        {
            base.Add(item);
            var e = new EventListIndexedArgs<T>()
            {
                Item = item,
                Index = base.Count - 1
            };
            OnAdded(e);
            OnChanged();
        }

        public override void Clear()
        {
            for (var i = 0; i < Count; i++)
            {
                var e = new EventListIndexedArgs<T>()
                {
                    Item = this[i], 
                    Index = i
                };
                OnRemoved(e);
            }
            OnChanged();
            base.Clear();
        }


        public override bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index < 0)
                return false;
            RemoveAt(index);
            return true;
        }


        public override void Insert(int index, T item)
        {
            base.Insert(index, item);
            var e = new EventListIndexedArgs<T>()
            {
                Item = item,
                Index = index
            };
            OnAdded(e);
            OnChanged();
        }

        public override void RemoveAt(int index)
        {
            var e = new EventListIndexedArgs<T>()
            {
                Item = this[index],
                Index = index
            };
            base.RemoveAt(index);
            OnRemoved(e);
            OnChanged();
        }

        public override T this[int index]
        {
            get => base[index];
            set
            {
                var old = base[index];
                var pre = new EventListIndexedArgs<T>()
                {
                    Item = old,
                    Index = index
                };
                var post = new EventListIndexedArgs<T>()
                {
                    Item = value,
                    Index = index
                };
                base[index] = value;
                OnRemoved(pre);
                OnAdded(post);
                OnChanged();

            }
            
        }

        protected virtual void OnAdded(EventListIndexedArgs<T> e)
        {
            Added?.Invoke(this, e);
        }

        protected virtual void OnRemoved(EventListIndexedArgs<T> e)
        {
            Removed?.Invoke(this, e);
        }

        protected virtual void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }

    public class ListWrapper<T> : IList<T>
    {
        private readonly List<T> _internal;

        public ListWrapper()
        {
            _internal = new List<T>();
        }

        public ListWrapper(IEnumerable<T> items)
        {
            _internal = new List<T>(items);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return _internal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _internal).GetEnumerator();
        }

        public virtual void Add(T item)
        {
            _internal.Add(item);
        }

        public virtual void Clear()
        {
            _internal.Clear();
        }

        public virtual bool Contains(T item)
        {
            return _internal.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            _internal.CopyTo(array, arrayIndex);
        }

        public virtual bool Remove(T item)
        {
            return _internal.Remove(item);
        }

        public virtual int Count => _internal.Count;

        public  virtual bool IsReadOnly => ((IList<T>) _internal).IsReadOnly;

        public virtual int IndexOf(T item)
        {
            return _internal.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            _internal.Insert(index, item);
        }

        public virtual void RemoveAt(int index)
        {
            _internal.RemoveAt(index);
        }

        public virtual T this[int index]
        {
            get => _internal[index];
            set => _internal[index] = value;
        }
    }
}