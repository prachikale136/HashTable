using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProblem
{
    internal class Program
    {
        public static void Main(string[] args) 
        {
            HashTableBuilder hashTable = new HashTableBuilder();
            //Ability to find frequency of words in a large  paragraph phrase
            hashTable.Sentence = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            hashTable.WordToCheck = "paranoid";
            Console.WriteLine($"Frequency of word is {hashTable.FindFrequencyOfWord()}");
            Console.ReadLine();
        }
    }
}