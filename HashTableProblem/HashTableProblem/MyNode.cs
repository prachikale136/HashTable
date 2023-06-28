using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProblem
{
      public class MyMappingNode<K, V>
        {
            private readonly int size;
            private readonly LinkedList<KeyValue<K, V>>[] items;

            public MyMappingNode(int size)
            {
                this.size = size;
                this.items = new LinkedList<KeyValue<K, V>>[size];
            }

            /// <summary>
            /// Gets a unique array items[] position for entered key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <returns></returns>
            protected int GetPositionInArray(K key)
            {
                /// Returns a unique position to each different key
                return Math.Abs(key.GetHashCode() % size);
            }
            /// <summary>
            /// Gets the linked list present at the entered position in the items[] array
            /// </summary>
            /// <param name="position">The position.</param>
            /// <returns></returns>
            protected LinkedList<KeyValue<K, V>> LinkedListBuilder(int position)
            {
                var linkedList = items[position];
                if (linkedList == null)
                {
                    /// Creates new linked list and update items[] array with the same
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }
                return linkedList;
            }

            /// <summary>
            /// Adds the specified key,value pair at the end of the linked list present at the position corresponding to the key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            public void AddValue(K key, V value)
            {
                /// Gets the position to the key
                int position = GetPositionInArray(key);
                /// Gets the linked list present at the position
                var linkedList = LinkedListBuilder(position);
                var item = new KeyValue<K, V>() { Key = key, Value = value };
                /// Adds the key-value pair at the end of the linked list
                linkedList.AddLast(item);
            }
            public V GetValue(K key)
            {
                int position = GetPositionInArray(key);
                var linkedList = LinkedListBuilder(position);
                foreach (var item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
                return default(V);
            }

            public void SetValue(K key, V value)
            {
                int position = GetPositionInArray(key);
                var linkedList = LinkedListBuilder(position);
                KeyValue<K, V> temp = new KeyValue<K, V>();
                foreach (var item in linkedList)
                {
                    if (item.Key.Equals(key))
                        temp = item;
                }
                temp.Value = value;
            }
        }
}
