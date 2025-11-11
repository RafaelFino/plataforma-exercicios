#!/usr/bin/env python3


file = input(">> Digite o nome do arquivo para adicionar conteúdo: ")
with open(file, "a") as f:
    content = input(">> Digite o conteúdo para adicionar ao arquivo: ")
    f.write(content + "\n")
    print("## Conteúdo adicionado ao arquivo com sucesso.")