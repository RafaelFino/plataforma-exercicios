#!/usr/bin/env python3

word = input(">> Digite uma palavra para inverter: ")
result = ""
for char in word:
    result = char + result

print("## A palavra invertida é: " + result)
