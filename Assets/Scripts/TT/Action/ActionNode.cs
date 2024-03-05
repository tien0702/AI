using System.Collections.Generic;
using UnityEngine;

namespace TT
{
    public class ActionNode : MonoBehaviour
    {
        protected LinkedList<ICondition> _conditions = new LinkedList<ICondition>();
        protected LinkedList<IHandle> _handles = new LinkedList<IHandle>();
        protected LinkedList<object> _children = new LinkedList<object>();

        public virtual int CountHandling { protected set; get; } = 0;

        public virtual void AddChild(object child)
        {
            if(child is Component)
            {
                _children.AddLast((Component)child);
            }
            if (child is ICondition)
            {
                _conditions.AddLast((ICondition)child);
            }
            else if (child is IHandle)
            {
                IHandle handle = (IHandle)child;
                _handles.AddLast(handle);
                handle.OnEndHandle = OnEndHandle;
            }
        }

        public virtual bool IsSuitable()
        {
            foreach (ICondition condition in _conditions)
            {
                if (!condition.IsSuitable) return false;
            }
            return true;
        }

        public virtual void ResetConditions()
        {
            foreach (var reset in _conditions)
            {
                reset.ResetCondition();
            }
        }

        public bool IsHandling() => CountHandling > 0;

        public virtual void Action()
        {
            CountHandling = _handles.Count;
            foreach (IHandle handle in _handles)
            {
                handle.Handle();
            }
        }

        protected virtual void OnEndHandle(IHandle handle)
        {
            --CountHandling;
            if (CountHandling == 0)
            {
                ClearHandles();
            }
        }

        protected virtual void ClearHandles()
        {
            foreach (var clear in _handles)
            {
                clear.ResetHandle();
            }
        }

        protected virtual void ClearChildren()
        {
            foreach(var child in _children)
            {
                if(child is Component)
                {
                    Destroy(child as Component);
                }
            }
            _children.Clear();
            _conditions.Clear();
            _handles.Clear();
        }
    }
}
