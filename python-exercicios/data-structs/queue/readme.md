# ✅ **FILAS — 10 Exercícios Progressivos (usando `deque`)**

### **1. Criando uma fila**

Crie uma fila vazia usando `deque`.
Adicione três elementos e exiba toda a fila.

---

### **2. Enfileirar**

Peça ao usuário três nomes de pessoas que chegaram e adicione na fila (fim da fila).

---

### **3. Desenfileirar**

Remova o primeiro elemento da fila usando `popleft()` e exiba quem foi atendido.

---

### **4. Verificando o próximo da fila**

Mostre qual é a próxima pessoa da fila (sem removê-la).

---

### **5. Tamanho da fila**

Exiba quantas pessoas estão atualmente na fila usando `len()`.

---

### **6. Fila com loop de atendimento**

Crie uma fila com 5 pessoas.
Simule o atendimento: enquanto a fila não estiver vazia, mostre e remova a pessoa do início.

---

### **7. Sistema de senha**

Crie um sistema onde:

* O usuário escolhe entre **gerar senha** e **atender senha**
* Senhas vão sendo geradas como números crescentes
* A fila guarda essas senhas
  O programa só para quando o usuário digitar "sair".

---

### **8. Fila com prioridade simples**

Crie duas filas:

* fila normal
* fila prioritária

Ao atender:

* sempre atenda primeiro a fila prioritária

---

### **9. Clonando filas**

Crie uma fila com 5 elementos.
Crie uma cópia exata dessa fila sem alterar a original.
Exiba as duas filas.

---

### **10. Simulação completa — caixa de banco**

Simule uma fila de banco:

* clientes chegam digitando "chegou"
* a cada passo o sistema pergunta: “Atender ou Aguardar?”
* se atender → remove cliente
* exiba sempre o estado atual da fila