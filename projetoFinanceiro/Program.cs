using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoFinanceiro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usuarioLogin = "mar";
            int usuarioSenha = 123;

            string login;
            int senha;
            int tentativas = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite o Login: ");
                login = Console.ReadLine();

                Console.WriteLine("Digite a Senha: ");
                senha = Convert.ToInt32(Console.ReadLine());

                tentativas++;

            } while (login != usuarioLogin && senha != usuarioSenha && tentativas < 3);

            if (login == usuarioLogin && senha == usuarioSenha)
            {
                Console.WriteLine("Seja bem vindo ao sistema!!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Login ou senha incorretos, digite novamente: ");
            }

            Console.ReadKey();

            Console.WriteLine("Qual operação deseja fazer: \n");
            Console.WriteLine("1 - Guardar dinheiro");
            Console.WriteLine("2 - Ver meu saldo");
            Console.WriteLine("3 - Ver Dividas");
            Console.WriteLine("4 - Limite de gastos");

            int operacao = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite quanto você ganha por mês: ");
            double salarioMes = double.Parse(Console.ReadLine());

            double resultado = 0;
            int prazo = 0;
            double valor = 0;
            double divida = 0;
            double limite = 0;

            switch (operacao)
            {
                case 1:
                    {
                        resultado = GuardarDinheiro(valor, prazo);
                        Console.WriteLine("Você precisa quardar {0} por {1}meses para ter {2}",valor,prazo,resultado);
                        break;
                    }
                case 2:
                    {
                        resultado = VerMeuSaldo(salarioMes, divida);
                        Console.WriteLine("Seu salldo é de: {0}", resultado);
                        break;
                    }
                case 3:
                    {
                        resultado = VerDividas(divida);
                        Console.WriteLine("Você tem {0} em dividas", resultado);
                        break;
                    }
                case 4:
                    {
                        resultado = LimiteDeGastos(salarioMes, limite);
                        Console.WriteLine("Você pode gastar {0} por mês", resultado);
                        break;
                    }
                default:
                    Console.WriteLine("Número invalído. Digite outro número");
                    break;
            }
            Console.ReadLine();

        }//Fim do Menu

        //Método Guardar Dinheiro

        public static double GuardarDinheiro(double valor, double prazo)
        {
            Console.WriteLine("Digite o prazo que você deseja guardar: ");
            prazo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja guardar: ");
            valor = double.Parse(Console.ReadLine());

            double resultado = valor * prazo;
            return resultado;
        }//Fim do método Soma

        //Método Ver meu Saldo
        public static double VerMeuSaldo(double salarioMes, double divida)
        {
            Console.WriteLine("Digite o valor de suas dividas: ");
            divida = double.Parse(Console.ReadLine());

            double resultado = salarioMes - divida;
            return resultado;
        }//Fim do método Ver meu saldo

        //Método Ver dividas
        public static double VerDividas(double divida)
        {
            Console.WriteLine("Digite o valor de suas dividas: ");
            divida = double.Parse(Console.ReadLine());

            double resultado = divida;
            return resultado;
        }//Fim do método Divisão

        //Método Limite de gastos
        public static double LimiteDeGastos(double salarioMes, double limite)
        {
            Console.WriteLine("Digite o limite de gastos: ");
            limite = double.Parse(Console.ReadLine());

            double resultado = salarioMes - limite;
            return resultado;
        }//Fim do método Limite de gastos

    }//Fim da classe
}//Fim do projeto
