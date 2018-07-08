using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rede
{
    class Network
    {
        private int qtdElementos;
        private int qtdArestas = 0;
        private bool contem ;

        private Dictionary<int, List<int>> Elemento = new Dictionary<int, List<int>>();

        public int QtdElementos
        {
            get { return qtdElementos; }
            set { qtdElementos = value; }
        }

        public int QtdArestas
        {
            get { return qtdArestas; }
            set { qtdArestas = value; }
        }

        public bool Contem
        {
            get { return contem; }
            set { contem = value; }
        }
        
        // criar grafo informa quantidade de elementos 
        public Network(int qtdElementos)
        {

            this.QtdElementos = qtdElementos;
             
            Console.WriteLine("Deseja preencher automaticamente? Sim = S Não = N");
            string resposta = Console.ReadLine();

            char resp = char.Parse(resposta);

            while (resp != 'N' && resp != 'S' && resp != 'n' && resp != 's')
            {
                Console.WriteLine("Opcao Invalida insira S ou N");
                resposta = Console.ReadLine();
                resp = char.Parse(resposta);
            }
            switch (resp)
            {
                case  'S':
                case  's':
                    for (int i = 1; i < (qtdElementos + 1); i++) Elemento.Add(i, new List<int>());
                    break;
                case 'N':
                case 'n':
                    for (int i = 1; i < (qtdElementos + 1); i++) {
                        Console.Write($"Valor do Elemento nº {i}: ");

                        var numero = Console.ReadLine();
                        while (!char.IsNumber(numero, 0))
                        {
                            Console.WriteLine("Valor precisa ser numerico");
                            Console.Write($"Valor do Elemento nº {i}: ");
                            numero = Console.ReadLine();
                        }
                     
                        Elemento.Add(Convert.ToInt32(numero), new List<int>());
                    }
                    break;
                
            }
            
        }

        // verifica se existe os elementos para poder formar a ligação
        public bool verifica_elementos(int ele1, int ele2)
        {
            bool existe = false;
            foreach(KeyValuePair<int, List<int>> i in Elemento)
            {
                if (Elemento.ContainsKey(ele1) && (Elemento.ContainsKey(ele2)))
                    existe = true;
                else
                    existe = false;
            }


            return existe;
        }
        //conecta dois elementos 
        public void connect(int val1, int val2)
        {
            

            foreach (KeyValuePair<int, List<int>> i in Elemento)
            {
                if (verifica_elementos(val1, val2))
                {

                    if (val1.Equals(i.Key))
                    {
                        if (!i.Value.Contains(val2))
                        {
                            i.Value.Add(val2);
                            qtdArestas++;
                        }
                    }

                    if (val2.Equals(i.Key))
                    {
                        if (!i.Value.Contains(val1))
                            i.Value.Add(val1);
                    }
                    
                }else
                {
                    Console.WriteLine("Um ou todos os elementos nao existem");
                   
                    break;
                }
                

            }
        }

        // Imprime elementos
        public void Imprime()
        {
            Console.Write("\nElementos: ");
            foreach (KeyValuePair<int, List<int>> i in Elemento)
            {
                Console.Write( i.Key + "  ");
            }
            Console.WriteLine(" ");
        }

        // Imprime ligaçoes
        public void ImprimeConexoes()
        {
            foreach (KeyValuePair<int, List<int>> i in Elemento)
            {
                Console.Write("\nLigações: " + i.Key + "  ");
                foreach (int j in (i.Value as List<int>)) Console.Write(j + "  ");
            }
            Console.WriteLine(" ");
        }
        // verifica se existe caminho entre 2 elementos
        public bool query(int val1, int val2)
        {
            List<int> path = null;
            var antes = new Dictionary<int, int>();
            var pesos = new Dictionary<int, int>();
            var nodes = new List<int>();

            //zerando o peso do item inicial e colocando max nos outros
            foreach (var item in Elemento)
            {
                if (item.Key == val1)
                {
                    pesos[item.Key] = 0;
                }
                else
                {
                    pesos[item.Key] = int.MaxValue;
                }

                nodes.Add(item.Key);
            }

            while (nodes.Count != 0)
            {
                //realiza o sort de acordo com a menor (chave - peso).
                // ex.: a(2,2) b(2, 2.71)  neste caso escolhe o b.
                nodes.Sort((x, y) => pesos[x] - pesos[y]);

                var menor = nodes[0];
                nodes.Remove(menor);
                // quando o menor for o valor procurado. 
                if (menor == val2)
                {
                    path = new List<int>();
                    while (antes.ContainsKey(menor))
                    {
                        path.Add(menor);
                        menor = antes[menor];
                    }
                    if (path.Count == 0)
                    {
                        Contem = false;
                    }
                    else { Contem = true; }
                        
                   break;
                    
                }

                if (pesos[menor] == int.MaxValue)
                {
                    break;
                }
                //pegando visinhos do elemento e atualizando pesos.
                foreach (var visinho in Elemento[menor])
                {
                    var atualiza = pesos[menor] + visinho;
                    if (atualiza < pesos[visinho])
                    {
                        pesos[visinho] = atualiza;

                        antes.Add(visinho, menor);
                    }
                }
            }

            return Contem;
        }

    }
}
