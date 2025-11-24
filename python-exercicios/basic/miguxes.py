#!/usr/bin/env python3

word = input("Digite uma palavra: ")
result = ""

for i in range(0, len(word)):
    c = word[i]
    if i % 2 == 1:
        result += c.lower()
    else:
        result += c.upper()

print("A palavra formatada MiGuXêS é:", result)