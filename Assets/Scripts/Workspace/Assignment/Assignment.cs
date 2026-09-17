using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            //AS01_CountWords();
            //AS02_CountNumber();
            //AS03_CheckValidBrackets();
            //AS04_PrintReverseLinkedList();
            //AS05_FindMiddleElement();
            //AS06_MergeDictionaries();
            //AS07_RemoveDuplicatesFromLinkedList();
            //AS08_TopFrequentNumber();
            //AS09_PlayerInventory();
            //AS10_GameEventQueue();
            //AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            if (words == null) return;

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word] += 1;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }

            Debug.Log("--- AS01 Count Words ---");
            foreach (KeyValuePair<string, int> kvp in wordCount)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            if (numbers == null) return;

            Dictionary<int, int> numberCount = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (numberCount.ContainsKey(num))
                {
                    numberCount[num] += 1;
                }
                else
                {
                    numberCount.Add(num, 1);
                }
            }

            Debug.Log("--- AS02 Count Numbers ---");
            foreach (KeyValuePair<int, int> kvp in numberCount)
            {
                Debug.Log($"Number {kvp.Key}: {kvp.Value} times");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            if (string.IsNullOrEmpty(input)) return;

            LinkedList<char> bracketList = new LinkedList<char>();
            bool isValid = true;

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    bracketList.AddLast(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (bracketList.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char top = bracketList.Last.Value;
                    bracketList.RemoveLast();

                    if ((c == ')' && top != '(') || 
                        (c == '}' && top != '{') || 
                        (c == ']' && top != '['))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (bracketList.Count > 0) isValid = false;

            Debug.Log($"--- AS03 Check Valid Brackets ---");
            Debug.Log($"Input: {input} | Is Valid: {isValid}");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            Debug.Log("--- AS04 Reverse Linked List ---");
            
            LinkedListNode<int> currentNode = list.Last;
            while (currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            Debug.Log("--- AS05 Find Middle Element ---");

            if (list.Count == 0)
            {
                Debug.Log("List is empty.");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log($"Middle Element: {slow.Value}");
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            
            Dictionary<string, int> mergedDict = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> kvp in dict1)
            {
                mergedDict.Add(kvp.Key, kvp.Value);
            }

            foreach (KeyValuePair<string, int> kvp in dict2)
            {
                if (mergedDict.ContainsKey(kvp.Key))
                {
                    mergedDict[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergedDict.Add(kvp.Key, kvp.Value);
                }
            }

            Debug.Log("--- AS06 Merge Dictionaries ---");
            foreach (KeyValuePair<string, int> kvp in mergedDict)
            {
                Debug.Log($"{kvp.Key} => {kvp.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            
            Dictionary<int, bool> seenValues = new Dictionary<int, bool>();
            
            LinkedListNode<int> currentNode = list.First;
            while (currentNode != null)
            {
                LinkedListNode<int> nextNode = currentNode.Next;
                
                if (seenValues.ContainsKey(currentNode.Value))
                {
                    list.Remove(currentNode);
                }
                else
                {
                    seenValues.Add(currentNode.Value, true);
                }
                
                currentNode = nextNode;
            }

            Debug.Log("--- AS07 Remove Duplicates ---");
            foreach (int val in list)
            {
                Debug.Log(val);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0) return;

            Dictionary<int, int> counts = new Dictionary<int, int>();
            int maxFrequency = 0;
            int mostFrequentNumber = numbers[0];

            foreach (int num in numbers)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num] += 1;
                }
                else
                {
                    counts.Add(num, 1);
                }

                if (counts[num] > maxFrequency)
                {
                    maxFrequency = counts[num];
                    mostFrequentNumber = num;
                }
            }

            Debug.Log("--- AS08 Top Frequent Number ---");
            Debug.Log($"Most Frequent: {mostFrequentNumber} (Appears {maxFrequency} times)");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (!string.IsNullOrEmpty(itemName))
            {
                if (inventory.ContainsKey(itemName))
                {
                    inventory[itemName] += quantity;
                }
                else
                {
                    inventory.Add(itemName, quantity);
                }

                if (inventory[itemName] <= 0)
                {
                    inventory.Remove(itemName);
                }
            }

            Debug.Log("--- AS09 Player Inventory ---");
            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                Debug.Log($"Item: {kvp.Key} | Amount: {kvp.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            
            Debug.Log("--- AS10 Game Event Queue (Highest Priority First) ---");
            
            while (eventQueue.Count > 0)
            {
                LinkedListNode<GameEvent> current = eventQueue.First;
                LinkedListNode<GameEvent> highestNode = current;

                while (current != null)
                {
                    if (current.Value.Priority > highestNode.Value.Priority)
                    {
                        highestNode = current;
                    }
                    current = current.Next;
                }

                Debug.Log($"Processing Event: [{highestNode.Value.EventType}] {highestNode.Value.Name} (Priority: {highestNode.Value.Priority})");
                eventQueue.Remove(highestNode);
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            if (!string.IsNullOrEmpty(statName))
            {
                if (playerStats.ContainsKey(statName))
                {
                    playerStats[statName] += value;
                }
                else
                {
                    playerStats.Add(statName, value);
                }
            }

            Debug.Log("--- AS11 Player Stats Tracker ---");
            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log($"Stat: {stat.Key} = {stat.Value}");
            }
        }

        #endregion
    }
}
