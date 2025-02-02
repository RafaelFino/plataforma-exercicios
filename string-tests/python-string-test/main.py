from datetime import datetime
import uuid

def create_token() -> str:
    return (str(uuid.uuid4()) + str(uuid.uuid4()).upper() + str(uuid.uuid4()) + str(uuid.uuid4()).upper()).replace("-", "") + (str(uuid.uuid4()) + str(uuid.uuid4()).upper() + str(uuid.uuid4()) + str(uuid.uuid4()).upper()).replace("-", "")

qty = 5000000

words = []
pairs = {}

anagram_count = 0
palindrome_count = 0

for i in range(qty):
    key = create_token()
    value = key    

    match i % 3:
        case 0:
            #same value
            valeu = create_token()
            pass
        case 1:
            #reverse
            value = key + key[::-1]
            anagram_count += 1
            palindrome_count += 1         
        case 2:
            #anagram
            value = key[::-1]
            anagram_count += 1
    
    words.append(value)
    pairs[key] = value

print(f"Palindromes: {palindrome_count} - {palindrome_count*100/qty}%")
print(f"Anagrams:    {anagram_count} - {anagram_count*100/qty}%")
print(f"Qty:         {qty}")

def execute(eval):
    start = datetime.now()
    for word in words:
        eval.reverse(word)

    print(f"Reverse:      {datetime.now() - start}")

    start = datetime.now()
    is_palindrome = 0
    for word in words:
        if eval.is_palindrome(word):
            is_palindrome += 1

    print(f"Palindrome:   {datetime.now() - start} - {is_palindrome*100/qty}%")
    is_anagram = 0

    for key in pairs:
        if eval.is_anagram(key, pairs[key]):
            is_anagram += 1

    print(f"Anagram:      {datetime.now() - start} - {is_anagram*100/len(pairs)}%")

from native import Native
from roots import Roots

print("\nNative:")
execute(Native())

print("\nRoots:")
execute(Roots())