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
        List<KeyValuePair<Key, Value>>[] Buckets;

        public HashMap()
        {
            Buckets = new List<KeyValuePair<Key, Value>>[100];
            for(int i=0; i<100; i++)
            {
                Buckets[i] = new List<KeyValuePair<Key, Value>>();
            }
        }

        public void Insert(Key key, Value value)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int index = hashCode % Buckets.Length;
            Buckets[index].Add(new KeyValuePair<Key, Value>(key, value));
        }

        public Value Get(Key key)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int index = hashCode % Buckets.Length;
            return Buckets[index].First(x => x.Key.Equals(key)).Value;
        }

        public bool ContainsKey(Key key)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int index = hashCode % Buckets.Length;
            return Buckets[index].Any(x => x.Key.Equals(key));
        }
    }

    #region test case proving it's faster than list iteration...
    //public static List<string> list = new List<string> { "cat", "dog", "horse", "pig", "chicken", "human", "kara", "strahd", "hen", "music", "pillow", "barovia", "something", "roger", "bannister", "mom", "dad", "tomato", "cucumber", "eggplant", "other things", "spinnach", "spanish", "french", "fries", "burger", "mouse", "rat", "fat", "penguin", "seal", "whale", "ice", "cream", "1", "4", "3", "2", "5", "6", "7", "8", "9", "10", };

    //static void Main(string[] args)
    //{
    //    List<KeyValuePair<string, int>> intList = new List<KeyValuePair<string, int>>
    //        {
    //            new KeyValuePair<string, int> ("cat", 3),
    //            new KeyValuePair<string, int> ("dog", 3),
    //            new KeyValuePair<string, int> ("horse", 5),
    //            new KeyValuePair<string, int> ("pig", 3),
    //            new KeyValuePair<string, int> ("chicken", 6),
    //            new KeyValuePair<string, int> ("human", 5),
    //            new KeyValuePair<string, int> ("kara", 4),
    //            new KeyValuePair<string, int> ("strahd", 5),
    //            new KeyValuePair<string, int> ("hen", 3),
    //            new KeyValuePair<string, int> ("music", 5),
    //            new KeyValuePair<string, int> ("pillow", 6),
    //            new KeyValuePair<string, int> ("barovia", 7),
    //            new KeyValuePair<string, int> ("something", 9),
    //            new KeyValuePair<string, int> ("roger", 5),
    //            new KeyValuePair<string, int> ("bannister", 9),
    //            new KeyValuePair<string, int> ("mom", 3),
    //            new KeyValuePair<string, int> ("dad", 3),
    //            new KeyValuePair<string, int> ("tomato", 6),
    //            new KeyValuePair<string, int> ("cucumber", 8),
    //            new KeyValuePair<string, int> ("eggplant", 8),
    //            new KeyValuePair<string, int> ("other things", 11),
    //            new KeyValuePair<string, int> ("spinnach", 8),
    //            new KeyValuePair<string, int> ("spanish", 7),
    //            new KeyValuePair<string, int> ("french", 6),
    //            new KeyValuePair<string, int> ("fries", 5),
    //            new KeyValuePair<string, int> ("burger", 6),
    //            new KeyValuePair<string, int> ("mouse", 5),
    //            new KeyValuePair<string, int> ("rat", 3),
    //            new KeyValuePair<string, int> ("fat", 3),
    //            new KeyValuePair<string, int> ("penguin", 7),
    //            new KeyValuePair<string, int> ("seal", 4),
    //            new KeyValuePair<string, int> ("whale", 5),
    //            new KeyValuePair<string, int> ("ice", 3),
    //            new KeyValuePair<string, int> ("cream", 5)
    //        };

    //    Stopwatch s1 = new Stopwatch();
    //    s1.Start();
    //    for (int i = 0; i < 1000; i++)
    //    {
    //        foreach (var s in list)
    //        {
    //            bool hasAny = intList.Any(x => x.Key.Equals(s));
    //        }
    //    }
    //    s1.Stop();
    //    Console.WriteLine($"Lookup took {s1.ElapsedTicks} miliseconds to run...");

    //    Hashing.HashMap<string, int> hashMap = new Hashing.HashMap<string, int>();
    //    hashMap.Insert("cat", 3);
    //    hashMap.Insert("dog", 3);
    //    hashMap.Insert("horse", 5);
    //    hashMap.Insert("pig", 3);
    //    hashMap.Insert("chicken", 6);
    //    hashMap.Insert("human", 5);
    //    hashMap.Insert("kara", 4);
    //    hashMap.Insert("strahd", 5);
    //    hashMap.Insert("hen", 3);
    //    hashMap.Insert("music", 5);
    //    hashMap.Insert("pillow", 6);
    //    hashMap.Insert("barovia", 7);
    //    hashMap.Insert("something", 9);
    //    hashMap.Insert("roger", 5);
    //    hashMap.Insert("bannister", 9);
    //    hashMap.Insert("mom", 3);
    //    hashMap.Insert("dad", 3);
    //    hashMap.Insert("tomato", 6);
    //    hashMap.Insert("cucumber", 8);
    //    hashMap.Insert("eggplant", 8);
    //    hashMap.Insert("other things", 11);
    //    hashMap.Insert("spinnach", 8);
    //    hashMap.Insert("spanish", 7);
    //    hashMap.Insert("french", 6);
    //    hashMap.Insert("fries", 5);
    //    hashMap.Insert("burger", 6);
    //    hashMap.Insert("mouse", 5);
    //    hashMap.Insert("rat", 3);
    //    hashMap.Insert("fat", 3);
    //    hashMap.Insert("penguin", 7);
    //    hashMap.Insert("seal", 4);
    //    hashMap.Insert("whale", 5);
    //    hashMap.Insert("ice", 3);
    //    hashMap.Insert("cream", 5);

    //    Stopwatch s2 = new Stopwatch();
    //    s2.Start();
    //    for (int i = 0; i < 1000; i++)
    //    {
    //        foreach (var s in list)
    //        {
    //            bool hasAny = hashMap.ContainsKey(s);
    //        }
    //    }
    //    s2.Stop();
    //    Console.WriteLine($"Lookup took {s2.ElapsedTicks} miliseconds to run...");

    //    Console.Read();
    //}
    #endregion
}
