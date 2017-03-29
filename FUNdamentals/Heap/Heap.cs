using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.Heap
{
    class Heap<T> where T : IComparable
    {
        List<T> heap = new List<T>();

        public void Insert(T value)
        {
            heap.Add(value); // stick it on the end...
            int index = heap.Count - 1;

            FilterUp(index);
        }

        public void Delete(T value)
        {
            var indexesToDelete = heap.Where(x => x.CompareTo(value) == 0).Select((v, i) => i); // get all our indexes
            foreach(var index in indexesToDelete)
            {
                Swap(index, heap.Count - 1);
                heap.Remove(heap.Last());

                // Heapify
                if(index < heap.Count)
                {
                    if (value.CompareTo(heap[ParentIndex(index)]) > 0)
                        FilterUp(index);
                    else
                        FilterDown(index);
                }
            }
        }

        private void FilterUp(int index)
        {
            while (HasParent(index) && heap[index].CompareTo(heap[ParentIndex(index)]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[ParentIndex(index)];
                heap[ParentIndex(index)] = temp;
                index = ParentIndex(index);
            }
        }

        private void FilterDown(int index)
        {
            while (HasLeftChild(index) && heap[index].CompareTo(heap[LeftChildIndex(index)]) > 0 || HasRightChild(index) && heap[index].CompareTo(heap[RightChildIndex(index)]) > 0)
            {
                int childIndex = (!HasRightChild(index) || heap[LeftChildIndex(index)].CompareTo(heap[RightChildIndex(index)]) <= 0)
                        ? RightChildIndex(index)
                        : LeftChildIndex(index);
                Swap(index, childIndex);
                index = childIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = heap[index2];
            heap[index2] = heap[index1];
            heap[index1] = temp;
        }

        public bool HasParent(int index) => index > 0;
        public int ParentIndex(int index) => (index - 1) / 2;
        public bool HasLeftChild(int index) => index * 2 + 1 < heap.Count;
        public int LeftChildIndex(int index) => index * 2 + 1;
        public bool HasRightChild(int index) => index * 2 + 2 < heap.Count;
        public int RightChildIndex(int index) => index * 2 + 2;
    }
}
