using System.Reflection;
using cs_string_test.Evaluator;

namespace cs_string_test.Tester
{
    public class PerformanceTester
    {
        private static Random random = new Random();

        private static IList<string> words = new List<string>();
        private static IDictionary<string, string> pairs = new Dictionary<string, string>();

        private IList<IEvaluator> evaluators = new List<IEvaluator>();

        private static int _nameSize = 0;

        public PerformanceTester(IList<IEvaluator> evaluators)
        {
            this.evaluators = evaluators;

            foreach (var evaluator in evaluators)
            {
                _nameSize = Math.Max(_nameSize, evaluator.GetName().Length);
            }
        }

        public void Populate(int group_qty, int group_size, int token_length)
        {
            Console.WriteLine($"Creating data: Starting");
            Console.WriteLine($"Populating {group_qty} groups of {group_size} words with {token_length} length");
            words = new List<string>();
            pairs = new Dictionary<string, string>();

            float total = group_qty * group_size;
            float IsAnagram = 0;
            float IsPalindrome = 0;

            for(int j = 0; j < group_qty; j++)
            {
                var len = token_length/(j+1) + 10;                
                for (int i = 0; i < group_size; i++)
                {
                    string key = CreateToken(len);
                    string value = new string(key);
                    
                    switch(i % 3)
                    {                        
                        case 0:
                            //same word: IsAnagram, Probably Not IsPalindrome
                            IsAnagram++;
                            break;

                        case 1:
                            //reverse word: IsAnagram, IsPalindrome                            
                            value = key + new string([.. key.Reverse()]);                            
                            key = value;
                            IsAnagram++;
                            IsPalindrome++;
                            break;

                        case 2:
                            //random word: Not IsAnagram, Not IsPalindrome
                            value = CreateToken(len + random.Next(-1, 5)) + i.ToString() + j.ToString();
                            break;
                    }
                    pairs[key] = value; 
                    words.Add(value);
                }
            }

            Console.WriteLine($"Populated {total} words:");            
            Console.WriteLine($"  [Palimdrome] \t{IsPalindrome}/{total}\t({float.Round(IsPalindrome*100/total, 6)}%)");
            Console.WriteLine($"  [Anagram]    \t{IsAnagram}/{total}\t({float.Round(IsAnagram*100/total, 6)}%)"); 
            Console.WriteLine($"Creating data: Finished");
        }

        private static string CreateToken(int length)
        {            
            if (length < 1)
            {
                return string.Empty;
            }

            const string chars = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789";
                return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Execute()
        {
            Console.WriteLine($"Performance test: Starting");
            foreach (var evaluator in evaluators)
            {
                Execute(evaluator);
            }
            Console.WriteLine($"Performance test: Finished");
        }

        public bool Test(IEvaluator evaluator)
        {
            var name = evaluator.GetName().PadRight(_nameSize);
            Console.WriteLine($"[{name}] Testing");
            
            var start = DateTime.Now;
           
            foreach (var word in words)
            {
                string reverse = evaluator.Reverse(word);
                string tester = new string([.. word.Reverse()]);

                if(reverse.Length != tester.Length)
                {
                    Console.WriteLine($"[{name}]   Reverse size test:          Error: {tester} / {reverse}");
                    return false;
                }

                if(reverse.CompareTo(tester) != 0)
                {
                    Console.WriteLine($"[{name}]   Reverse value test:         Error: {tester} / {reverse}");
                    return false;
                }

                if(!evaluator.IsPalindrome(word + reverse))
                {
                    Console.WriteLine($"[{name}]   IsPalindrome test:          Error: {word} / {reverse}");
                }
            }

            Console.WriteLine($"[{name}] Passed: {(DateTime.Now - start).TotalMilliseconds}ms");

            return true;
        }

        public void Execute(IEvaluator evaluator)
        {
            var name = evaluator.GetName().PadRight(_nameSize);

            if (!Test(evaluator))
            {
                Console.WriteLine($"[{name}] Testing: Failed");
                return;
            }

            Console.WriteLine($"[{name}] Starting");
            
            var start = DateTime.Now;
            var processStart = start;
            float totalWords = words.Count;
            float totalPairs = pairs.Count;

            words.Count(word => evaluator.Reverse(word).Length == word.Length);            
            
            Console.WriteLine($"[{name}]    Reverse:          {(DateTime.Now - start).TotalMilliseconds, 10:N4}ms");

            start = DateTime.Now;
            float isPalindrome = words.Count(w => evaluator.IsPalindrome(w));

            Console.WriteLine($"[{name}]    IsPalindrome:     {(DateTime.Now - start).TotalMilliseconds, 10:N4}ms\t{isPalindrome}/{totalWords}\t{float.Round(isPalindrome*100/totalWords, 6)}%");

            start = DateTime.Now;
            float IsAnagram = 0;

            foreach (var pair in pairs)
            {
                if(evaluator.IsAnagram(pair.Key, pair.Value))
                {
                    IsAnagram++;
                }
            }

            Console.WriteLine($"[{name}]    IsAnagram:        {(DateTime.Now - start).TotalMilliseconds, 10:N4}ms\t{IsAnagram}/{totalPairs}\t{float.Round(IsAnagram*100/totalPairs, 6)}%");

            Console.WriteLine($"[{name}]   Total:             {(DateTime.Now - processStart).TotalMilliseconds, 10:N4}ms");
        }
    }
}