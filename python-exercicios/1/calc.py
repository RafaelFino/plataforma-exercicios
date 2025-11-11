#!/usr/bin/env python3

print(">> Digite qual operação deseja realizar:")
print("     1: soma")
print("     2: substração")
print("     3: divisão")
print("     4: multiplicação")
op = int(input(">> Operação: "))

if op < 1 or op > 4:
    print("Operação inválida")
    exit(1)

val1 = float(input(">> Digite o primeiro valor: "))
val2 = float(input(">> Digite o segundo valor: "))
result = 0

match op:
    case 1:
        result = val1 + val2
    case 2:
        result = val1 - val2
    case 3:
        result = val1 / val2
    case 4:
        result = val1 * val2
        
print("## O resultado é " + str(result))
