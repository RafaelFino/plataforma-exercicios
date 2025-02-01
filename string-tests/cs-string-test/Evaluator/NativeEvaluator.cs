namespace cs_string_test.Evaluator
{
    public class NativeEvaluator : Evaluator.EvaluatorBase
    {
        public override string GetName() {
            return "Native";
        }

        public override string Reverse(string s) {
            return new string([.. s.Reverse()]);
        }        

        public override bool IsPalindrome(string s) {
            string prepared = Prepare(s);
            string reversed = Reverse(prepared);
            
            return reversed.CompareTo(prepared) == 0;
        }

        public override bool IsAnagram(string a, string b) {
            return Prepare(a).OrderBy(c => c).SequenceEqual(Prepare(b).OrderBy(c => c));
        }
    }
}