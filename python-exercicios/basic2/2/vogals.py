#!/usr/bin/env python3

word = input(">> Digite uma palavra para contar as vogais: ")
vogais = "aeiouAEIOU"
contador = 0
for char in word:
    if char in vogais:
        contador += 1

print("## A palavra contém " + str(contador) + " vogais.")