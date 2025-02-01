namespace cs_string_test.Evaluator
{
    public class RootsEvaluator : Evaluator.EvaluatorBase
    {
        public override string GetName() {
            return "Roots";
        }        
        public override string Reverse(string s) {
            var ret = string.Empty;
            foreach(char c in s.ToCharArray()) {
                ret = c + ret;
            }
            return ret;
        }

        public override bool IsPalindrome(string s) {
            string prepared = Prepare(s);
            string reversed = Reverse(prepared);
            
            return reversed.CompareTo(prepared) == 0;
        }

        public override bool IsAnagram(string str1, string str2) 
        {            
            var aux = new Dictionary<char, int>();
            var a = Prepare(str1);
            var b = Prepare(str2);

            if (a.Length != b.Length) {
                return false;
            }

            foreach(char c in Prepare(a).ToCharArray()) {
                if (aux.ContainsKey(c)) {
                    aux[c]++;
                } else {
                    aux[c] = 1;
                }
            }

            foreach(char c in Prepare(b).ToCharArray()) {
                if (aux.TryGetValue(c, out int value)) {
                    aux[c] = --value;
                    if (value == 0) {
                        aux.Remove(c);
                    }
                } else {
                    return false;
                }
            }

            if (aux.Count > 0) {
                return false;
            }

            return true;            
        }
    }
}