// CLASSE DO NÓ
class No {
    constructor(dado) {
        this.dado = dado;
        this.proximo = null;
    }
}

// CLASSE DA LISTA ENCADEADA
class ListaEncadeada {
    constructor() {
        this.cabeca = null;
        this.tamanho = 0;
    }
    
    // Adicionar no início
    adicionarInicio(dado) {
        const novoNo = new No(dado);
        novoNo.proximo = this.cabeca;
        this.cabeca = novoNo;
        this.tamanho++;
        console.log(`✅ ${dado} adicionado no início`);
    }
    
    // Adicionar no final
    adicionarFim(dado) {
        const novoNo = new No(dado);
        
        if (!this.cabeca) {
            this.cabeca = novoNo;
        } else {
            let atual = this.cabeca;
            while (atual.proximo) {
                atual = atual.proximo;
            }
            atual.proximo = novoNo;
        }
        this.tamanho++;
        console.log(`✅ ${dado} adicionado no final`);
    }
    
    // Remover do início
    removerInicio() {
        if (!this.cabeca) {
            console.log("❌ Lista vazia!");
            return null;
        }
        
        const dadoRemovido = this.cabeca.dado;
        this.cabeca = this.cabeca.proximo;
        this.tamanho--;
        console.log(`✅ ${dadoRemovido} removido do início`);
        return dadoRemovido;
    }
    
    // Buscar elemento
    buscar(dado) {
        let atual = this.cabeca;
        let posicao = 0;
        
        while (atual) {
            if (atual.dado === dado) {
                console.log(`✅ Elemento ${dado} encontrado na posição ${posicao}`);
                return { encontrado: true, posicao };
            }
            atual = atual.proximo;
            posicao++;
        }
        
        console.log(`❌ Elemento ${dado} não encontrado`);
        return { encontrado: false, posicao: -1 };
    }
    
    // Imprimir lista
    imprimir() {
        if (!this.cabeca) {
            console.log("📝 Lista vazia!");
            return;
        }
        
        let atual = this.cabeca;
        const elementos = [];
        
        while (atual) {
            elementos.push(atual.dado);
            atual = atual.proximo;
        }
        
        console.log(`📝 Lista: ${elementos.join(' → ')}`);
        console.log(`📊 Tamanho: ${this.tamanho}`);
    }
    
    // Verificar se está vazia
    estaVazia() {
        return this.tamanho === 0;
    }
}

// PROGRAMA PRINCIPAL
function main() {
    console.log("🚀 INICIANDO LISTA ENCADEADA\n");
    
    const lista = new ListaEncadeada();
    
    // Testes automáticos
    lista.imprimir();
    
    lista.adicionarInicio(10);
    lista.adicionarInicio(5);
    lista.adicionarFim(20);
    lista.adicionarFim(30);
    
    lista.imprimir();
    
    lista.buscar(20);
    lista.buscar(100);
    
    lista.removerInicio();
    lista.imprimir();
    
    lista.removerInicio();
    lista.imprimir();
    
    console.log("\n✅ PROGRAMA CONCLUÍDO!");
}

// Executar
main();