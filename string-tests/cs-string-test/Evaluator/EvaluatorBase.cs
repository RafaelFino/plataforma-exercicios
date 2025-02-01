namespace cs_string_test.Evaluator
{
    public abstract class EvaluatorBase : Evaluator.IEvaluator
    {
        public abstract string Reverse(string s);
        public abstract bool IsPalindrome(string s);
        public abstract bool IsAnagram(string str1, string str2);

        public abstract string GetName();

        protected static string Prepare(string s) {
            return s.Replace(" ", string.Empty).ToLower();
        }        
    }
}