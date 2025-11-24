#!/usr/bin/env python3

word = input(">> Digite uma palavra para verificar se é um anagrama: ")
# remove espaços e normalize para minúsculas e ordena as letras
sorted_word = sorted(word.replace(" ", "").lower())

anagram_candidate = input(">> Digite a palavra para comparar: ")

# remove espaços e normalize para minúsculas e ordena as letras
sorted_candidate = sorted(anagram_candidate.replace(" ", "").lower())

if sorted_word == sorted_candidate:
    print("## As palavras são anagramas.")
else:
    print("## As palavras não são anagramas.")
