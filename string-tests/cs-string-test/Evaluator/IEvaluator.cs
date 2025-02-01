namespace cs_string_test.Evaluator
{
    public interface IEvaluator {
        string Reverse(string s);
        bool IsPalindrome(string s);
        bool IsAnagram(string str1, string str2);
        public string GetName();
    }
}