class Native:
    def __init__(self):
        self._name = "Native"

    def get_name(self):
        return self._name

    def reverse(self, s: str) -> str:
        return s[::-1]
    
    def is_palindrome(self, s: str) -> bool:
        v = self.prepare(s)
        return v == v[::-1]
    
    def is_anagram(self, s1: str, s2: str) -> bool:
        return sorted(self.prepare(s1)) == sorted(self.prepare(s2))
    
    def prepare(self, s: str) -> str:
        return s.lower().replace(" ", "")

    