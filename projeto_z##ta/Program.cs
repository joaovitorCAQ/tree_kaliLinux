using System;
using System.Collections.Generic;

namespace projeto_z__ta {
    class avl {
        public int informacao;
        public avl esquerda;
        public avl direita;
        public int altura;
        public avl(int numero , int alt = 1) {
            informacao = numero;
            esquerda = null;
            direita = null;
            altura = alt;
        }
    }
    // as funcoes da arvore ficaram dentro dessa class 
    class funcoes_da_arvore { 
        // funcao para reti=ornar 1 altura minima de um no 
        public static int altura(avl no) {
            if (no == null) {
                return 0;
            } else {
                return no.altura;
            }
        }
        // funcao para calculo esq e dir
        public static int balancear(avl no) {
            if(no == null) {
                return 0;
            }else {
                return altura(no.esquerda) - altura(no.direita);
            }
        }
        //funcao para taualizar a altura
        public static int atualizarAltura(avl no){
            return no.altura = 1 + Math.Max(altura(no.esquerda), altura(no.direita));
        }
        // funcoes de rotacoes (simples esquerda)
        public static avl rotacao_s_esquerda(avl x) {
            avl y = x.direita;
            avl t2 = y.esquerda;

            y.esquerda = x;
            x.direita = t2;

            atualizarAltura(y);
            atualizarAltura(x);
            return y;
        }
        // funcoes de rotacoes (simples direita
        public static avl rotacao_s_direita(avl y) {
            avl x = y.esquerda;
            avl t2 = x.direita;

            x.direita = y;
            y.esquerda = t2;

            atualizarAltura(x);
            atualizarAltura(y);
            return x;
        } 
        // funcao rotacao dupla(esquerda_direita)
        public static avl rotacao_dupla_esquerda_direita(avl no) {
            no.esquerda = rotacao_s_esquerda(no.esquerda);
            return rotacao_s_direita(no);
        }
        // funcao rotacao dupla(esquerda_direita)
        public static avl rotacao_dupla_direita_esquerda(avl no) {
            no.direita = rotacao_s_direita(no.direita);
            return rotacao_s_esquerda(no);
        }
        // funcao de adcionar rotacoes 
        public static avl balance(avl raiz) {
            if (raiz == null) return null;

            int fb = balancear(raiz);

            if (fb > 1 && balancear(raiz.esquerda) >= 0) {
                return rotacao_s_direita(raiz);
            } else if (fb < -1 && balancear(raiz.direita) <= 0) {
                return rotacao_s_esquerda(raiz);
            } else if (fb > 1 && balancear(raiz.esquerda) < 0) {
                return rotacao_dupla_esquerda_direita(raiz);
            } else if (fb < -1 && balancear(raiz.direita) > 0) {
                return rotacao_dupla_direita_esquerda(raiz);
            }
            return raiz; 
        }
        // função de inserir na arvore
        public static avl inserir(avl no,int numero) {
            if(no == null) {
                return new avl(numero);
            }
            if(numero < no.informacao) {
                no.esquerda = inserir(no.esquerda, numero);
            } else if(numero > no.informacao) {
                no.direita = inserir(no.direita, numero);
            }else {
                return no;
            }
            atualizarAltura(no);
            return balance(no);
        }
        // funcao 1 para imprimir (kali linux)
        public static void ArvoreKali(avl no, string prefixo = "", bool ultimo = true) {
            if (no != null) {
                Console.WriteLine(prefixo + (ultimo ? "└── " : "├── ") + no.informacao);

                string novoPrefixo = prefixo + (ultimo ? "    " : "│   ");

                var filhos = new List<avl>();
                if (no.esquerda != null)
                    filhos.Add(no.esquerda);
                if (no.direita != null)
                    filhos.Add(no.direita);

                for (int i = 0; i < filhos.Count; i++) {
                    ArvoreKali(filhos[i], novoPrefixo, i == filhos.Count - 1);
                }
            }
        }
        // funcao 2 para imprimir a arvore (BFS)   
        public static void BFS(avl inicio) {
            if (inicio == null) return;

            Queue<avl> fila = new Queue<avl>();
            fila.Enqueue(inicio);

            Console.WriteLine("BFS - Impressao por nível:");

            while (fila.Count > 0) {
                int nivelSize = fila.Count;

                for (int i = 0; i < nivelSize; i++) {
                    avl atual = fila.Dequeue();
                    Console.Write(atual.informacao + "  "); 

                    if (atual.esquerda != null)
                        fila.Enqueue(atual.esquerda);

                    if (atual.direita != null)
                        fila.Enqueue(atual.direita);
                }
                Console.WriteLine(); 
            }
        }
    }
    class program { 
        static void Main(string[] args) {
            Console.WriteLine("hello Avl");
            avl raiz = null;

            raiz = funcoes_da_arvore.inserir(raiz, 50);
            raiz = funcoes_da_arvore.inserir(raiz, 30);
            raiz = funcoes_da_arvore.inserir(raiz, 70);
            raiz = funcoes_da_arvore.inserir(raiz, 20);
            raiz = funcoes_da_arvore.inserir(raiz, 40);
            raiz = funcoes_da_arvore.inserir(raiz, 60);
            raiz = funcoes_da_arvore.inserir(raiz, 80);
      
            Console.WriteLine("Escolha o tipo de impressso:");
            Console.WriteLine("1 (Formato Kali (arvore visual))");
            Console.WriteLine("2 (Formato BFS (por níveis))");
            Console.Write("Opcao: ");

            string opcao = Console.ReadLine();

            if (opcao == "1") {
                Console.WriteLine("\n arvore AVL ->> Formato Kali:");
                funcoes_da_arvore.ArvoreKali(raiz);
            } else if (opcao == "2") {
                Console.WriteLine("\n arvore AVL ->> Formato BFS:");
                funcoes_da_arvore.BFS(raiz);
            } else {
                Console.WriteLine("Opcao invalida");
            }

            Console.ReadLine();
        }
    
    }


}