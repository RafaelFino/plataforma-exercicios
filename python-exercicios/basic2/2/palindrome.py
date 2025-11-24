#!/usr/bin/env python3

word = input(">> Digite a palavra para descobrir se é um palindromo: ")

# Remove espaços e normalize para minúsculas
word = word.replace(" ", "").lower()

reverse = ""

for char in word:
    reverse = char + reverse

if word == reverse:
    print("## A palavra é um palíndromo")
else:
    print("## A palavra não é um palíndromo")
