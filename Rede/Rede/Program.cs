using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rede
{
   class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\t\t**********************************************");
            Console.WriteLine("\t\t*** Programa conexao de pontos no Conjunto ***");
            Console.WriteLine("\t\t**********************************************\n");
            
            Console.Write("Insira a quantidade de Elementos:  ");
            var entrada = Console.ReadLine();
            // controle da entrada de quantidades
            while (!char.IsNumber(entrada, 0))
            {
                Console.WriteLine("Opção precisa ser numerica");
                Console.Write("Insira a quantidade de Elementos:  ");

                entrada = Console.ReadLine();
            }

            int resposta =Convert.ToInt32(entrada);
            Network net = new Network(resposta);

            Console.Write("\nImprime Elementos = 1 \nCriar conexão     = 2 \nVerificaConexao   = 3"
                   + "\nImprimeConexoes   = 4 \nEncerrar          = 5\n \nSelecione a opção: ");

            var opt = Console.ReadLine();
            // controle de opcoes
            while (!char.IsNumber(opt, 0))
            {
                Console.WriteLine("Opção precisa ser numerica");
                Console.Write("\nImprime Elementos = 1 \nCriar conexão     = 2 \nVerificaConexao   = 3"
              + "\nImprimeConexoes   = 4 \nEncerrar          = 5\n \nSelecione a opção: ");

                opt = Console.ReadLine();
            }

            int opcao = Convert.ToInt32(opt);

            while (opcao != 5) { 
                switch (opcao)
                {
                    case 1:
                        net.Imprime();
                        break;
                    case 2:
                        string respost = null;
                        char resp = ' ';

                        do
                        {
                            Console.Write("Valor1 :");
                            var numero1 = Console.ReadLine();
                            while (!char.IsNumber(numero1, 0))
                            {
                                Console.WriteLine("Valor precisa ser numerico");
                                Console.Write("Valor1 :");
                                numero1 = Console.ReadLine();
                            }
                            int valor1 = Convert.ToInt32(numero1);

                            Console.Write("Valor2 :");

                            var numero2 = Console.ReadLine();
                            while (!char.IsNumber(numero2, 0))
                            {
                                Console.WriteLine("Valor precisa ser numerico");
                                Console.Write("Valor2 :");
                                numero2 = Console.ReadLine();
                            }

                            int valor2 = Convert.ToInt32(numero2);

                            net.connect(valor1, valor2);
                            Console.Write("Deseja Criar Nova Conexão? Sim=S Não = N  ");
                            respost = Console.ReadLine();
                            resp = char.Parse(respost);

                            while (resp != 'N' && resp != 'S' && resp != 'n' && resp != 's')
                            {
                                Console.Write("Opcao Invalida insira S ou N ");
                                respost = Console.ReadLine();
                                resp = char.Parse(respost);
                            }

                        } while (resp == 'S' || resp == 's');

                        break;
                    case 3:
                        Console.Write("Insira os valores a verificar se existe conexão\n");
                        Console.Write("Valor1 :");
                        var valo = Console.ReadLine();
                        while (!char.IsNumber(valo, 0))
                        {
                            Console.WriteLine("Valor precisa ser numerico");
                            Console.Write("Valor1 :");
                            valo = Console.ReadLine();
                        }

                        int valo1 = Convert.ToInt32(valo);

                        Console.Write("Valor2 :");

                        valo = Console.ReadLine();
                        while (!char.IsNumber(valo, 0))
                        {
                            Console.WriteLine("Valor precisa ser numerico");
                            Console.Write("Valor2 :");
                            valo = Console.ReadLine();
                        }

                        int valo2 = Convert.ToInt32(valo);

                        if (net.query(valo1, valo2))
                        {
                            Console.WriteLine("\nEstá conectado");
                        }
                        else
                        {
                            Console.WriteLine("\nNão está conectado");
                        }

                        break;
                    case 4:
                        net.ImprimeConexoes();
                        break;
                    default:
                        Console.WriteLine("\nOpção Invalida");
                        break;

                }
                Console.Write("\nImprime Elementos = 1 \nCriar conexão     = 2 \nVerificaConexao   = 3"
                       + "\nImprimeConexoes   = 4 \nEncerrar          = 5\n \nSelecione a opção: ");

                opt = Console.ReadLine();

                while (!char.IsNumber(opt, 0))
                {
                    Console.WriteLine("Opção precisa ser numerica");
                    Console.Write("\nImprime Elementos = 1 \nCriar conexão     = 2 \nVerificaConexao   = 3"
                  + "\nImprimeConexoes   = 4 \nEncerrar          = 5\n \nSelecione a opção: ");

                    opt = Console.ReadLine();
                }

                opcao = Convert.ToInt32(opt);

            }
            
        }
    }
}
