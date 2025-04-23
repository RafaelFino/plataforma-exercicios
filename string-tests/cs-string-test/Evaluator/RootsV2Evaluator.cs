namespace cs_string_test.Evaluator
{
    public class RootsV2Evaluator : Evaluator.EvaluatorBase
    {
        public override string GetName() {
            return "RootsV2";
        }

        public override string Reverse(string s) {
            int pos = s.Length-1;
            var ret = new char[s.Length];            
            
            foreach(char c in s.ToCharArray()) {
                ret[pos--] = c;
            }

            return new string(ret);
        }

        public override bool IsPalindrome(string s) {
            string prepared = Prepare(s);
            for (int i = 0; i < prepared.Length / 2; i++) {
                if (prepared[i] != prepared[prepared.Length - i - 1]) {
                    return false;
                }
            }
            return true;
        }

        public override bool IsAnagram(string str1, string str2) {
            var b = Prepare(str1);
            var a = Prepare(str2);

            if (a.Length != b.Length) {
                return false;
            }

            foreach(char c in a.ToCharArray()) {
                if (b.Contains(c)) {
                    b = b.Remove(b.IndexOf(c), 1);
                } else {
                    return false;
                }
            }

            if (b.Length > 0) {
                return false;
            }

            return true;
        }
    }
}    