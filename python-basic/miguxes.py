#!/usr/bin/env python3

word = input("Digite uma palavra: ")
result = ""
for i in range(0, len(word)):
    if i % 2 == 0:
        result += word[i].lower()
    else:
        result += word[i].upper()

print("A palavra formatada MiGuXêS é:", result)