class Roots:
    def __init__(self):
        self._name = "Roots"

    def get_name(self):
        return self._name

    def reverse(self, s: str) -> str:
        ret = ""
        for i in range(len(s)):
            ret = s[i] + ret     
        return ret
    
    def is_palindrome(self, s: str) -> bool:
        v = self.prepare(s)
        return v == self.reverse(v)
    
    def is_anagram(self, s1: str, s2: str) -> bool:
        str1 = self.prepare(s1)
        str2 = self.prepare(s2)

        if len(str1) != len(str2):
            return False

        aux = {}
        for c in str1:
            if c in aux:
                aux[c] += 1
            else:
                aux[c] = 1

        for c in str2:
            if c in aux:
                aux[c] -= 1
            else:
                return False
            
        for c in aux:
            if aux[c] != 0:
                return False
            
        return True        
    
    def prepare(self, s: str) -> str:
        return s.replace(" ", "").lower()

    