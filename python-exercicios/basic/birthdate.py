#!/usr/bin/env python3

from datetime import datetime

date = input("Digite a sua idade: ")
current_year = datetime.now().year
birth_year = current_year - int(date)
print("O seu ano de nascimento é:", birth_year) 
