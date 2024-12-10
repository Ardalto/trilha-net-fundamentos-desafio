using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!veiculos.ContainsKey(placa))
            {
                veiculos.Add(placa, DateTime.Now);
                Console.WriteLine($"Veículo com placa {placa} foi adicionado às {DateTime.Now}.");
            }
            else
            {
                Console.WriteLine("Este veículo já está estacionado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.ContainsKey(placa))
            {
                DateTime horaEntrada = veiculos[placa];
                DateTime horaSaida = DateTime.Now;

                TimeSpan duracao = horaSaida - horaEntrada;
                int horas = (int)Math.Ceiling(duracao.TotalHours);

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove o veículo do estacionamento
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido. Tempo estacionado: {horas} hora(s). Valor total: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");

                Console.WriteLine("Deseja remover a placa incorreta do registro? (s/n)");
                string resposta = Console.ReadLine();
                if (resposta?.ToLower() == "s")
                {
                    Console.WriteLine("Digite a placa que deseja remover do registro:");
                    string placaParaRemover = Console.ReadLine();
                    if (veiculos.ContainsKey(placaParaRemover))
                    {
                        veiculos.Remove(placaParaRemover);
                        Console.WriteLine($"A placa {placaParaRemover} foi removida do registro.");
                    }
                    else
                    {
                        Console.WriteLine("Placa não encontrada no registro.");
                    }
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Key}, Hora de entrada: {veiculo.Value}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

            // Exibe o laço de repetição para listar todos os veículos registrados
            Console.WriteLine("\nLista completa de veículos registrados:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"Placa: {veiculo.Key}, Hora de entrada: {veiculo.Value}");
            }
        }
    }
}
