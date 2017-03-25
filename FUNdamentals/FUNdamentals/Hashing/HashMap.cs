using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.Hashing
{

    /// <summary>
    /// Let's start basic... Initialize buckets at size 100
    /// </summary>
    class HashMap<Key, Value>
    {
        int[] Buckets;

        public HashMap()
        {
            Buckets = new int[100];
            for(int i=0; i<100; i++)
            {
                Buckets[i] = i;
            }
        }


        public void Insert(Key key, Value value)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int targetBucket = hashCode % Buckets.Length;
        }
    }
}
