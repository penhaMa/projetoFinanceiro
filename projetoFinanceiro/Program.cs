using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projetoFinanceiro
{
    class Program
    {
        // Dicionário para armazenar os usuários e senhas
        static Dictionary<string, string> usuarios = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            bool verificar = false;

            while (!verificar)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Cadastrar novo usuário");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FazerLogin();
                        verificar = true;
                        Escolha();
                        break;
                    case "2":
                        CadastrarUsuario();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void FazerLogin()
        {
            Console.Write("Digite o login: ");
            string inputLogin = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string inputSenha = Console.ReadLine();

            if (usuarios.ContainsKey(inputLogin) && VerificarSenha(inputSenha, usuarios[inputLogin]))
            {
                Console.WriteLine("Login bem-sucedido!");
                // Coloque o código adicional aqui para o que deseja fazer após o login.
            }
            else
            {
                Console.WriteLine("Login ou senha incorretos!");
            }
        }

        static void CadastrarUsuario()
        {
            Console.Write("Digite o novo login: ");
            string novoLogin = Console.ReadLine();

            if (usuarios.ContainsKey(novoLogin))
            {
                Console.WriteLine("O login já está em uso!");
                return;
            }

            Console.Write("Digite a nova senha: ");
            string novaSenha = Console.ReadLine();

            // Gerar hash da senha
            string senhaHash = GerarHashSenha(novaSenha);

            // Armazenar login e senha hash no dicionário
            usuarios[novoLogin] = senhaHash;

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        static string GerarHashSenha(string senha)
        {
            // Criar instância do algoritmo de hash SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converter a senha em bytes e calcular o hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                // Construir a representação em string do hash
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        static bool VerificarSenha(string senha, string senhaHash)
        {
            // Gerar o hash da senha digitada
            string hashSenha = GerarHashSenha(senha);

            // Comparar os hashes das senhas (ignorando diferenciação entre maiúsculas e minúsculas)
            return StringComparer.OrdinalIgnoreCase.Compare(hashSenha, senhaHash) == 0;
        }

        static void Escolha() 
        {

            Console.WriteLine("Qual operação deseja fazer: \n");
            Console.WriteLine("1 - Guardar dinheiro");
            Console.WriteLine("2 - Ver meu saldo");
            Console.WriteLine("3 - Ver Dividas");
            Console.WriteLine("4 - Limite de gastos");

            int operacao = int.Parse(Console.ReadLine());

            double salarioMes = 0;
            double resultado = 0;
            int prazo = 0;
            double valor = 0;
            double divida = 0;
            double limite = 0;

            switch (operacao)
            {
                case 1:
                    {
                        Console.WriteLine("Digite o prazo que você deseja guardar: ");
                        prazo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja guardar: ");
                        valor = double.Parse(Console.ReadLine());

                        resultado = GuardarDinheiro(valor, prazo);
                        Console.WriteLine("Você precisa guardar {0} por {1} meses para ter {2}",valor,prazo,resultado);
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
            double resultado = valor * prazo;
            return resultado;
        }//Fim do método Soma

        //Método Ver meu Saldo
        public static double VerMeuSaldo(double salarioMes, double divida)
        {
            Console.WriteLine("Digite quanto você ganha por mês: ");
            salarioMes = double.Parse(Console.ReadLine());

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
            Console.WriteLine("Digite quanto você ganha por mês: ");
            salarioMes = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o limite de gastos: ");
            limite = double.Parse(Console.ReadLine());

            double resultado = salarioMes - limite;
            return resultado;
        }//Fim do método Limite de gastos

    }//Fim da classe
}//Fim do projeto
