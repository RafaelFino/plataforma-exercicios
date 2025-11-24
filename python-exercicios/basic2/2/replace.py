#!/usr/bin/env python3

phrase = input(">> Digite uma frase: ")
old_word = input(">> Digite a palavra que deseja substituir: ")
new_word = input(">> Digite a nova palavra: ")  

new_phrase = phrase.replace(old_word, new_word)
print("## Frase resultante: " + new_phrase)