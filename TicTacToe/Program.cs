using System;

namespace TicTacToe
{
	class Program
	{
		static void Main(string[] args)
		{
			bool jogoAtivo = true;
			Tabuleiro tabuleiro = new();
			Simbolo vez = Simbolo.X;

			while (jogoAtivo)
			{
				Console.Clear();
				tabuleiro.Desenhar();
				ReceberJogada();
				Console.Clear();
				tabuleiro.Desenhar();
				VerificarVitoria();

				vez = Simbolo.X.Nome == vez.Nome ? Simbolo.O : Simbolo.X;
			}

			void ReceberJogada()
			{
				bool jogadaValida = false;

				while (!jogadaValida)
				{
					Console.Write("Jogue em uma casa escolhendo um número de 1 a 9: ");
					int numeroEscolhido = int.Parse(Console.ReadLine());
					jogadaValida = tabuleiro.MarcarCasa(numeroEscolhido, vez);
				}
			}

			void VerificarVitoria()
			{
				ResultadoEnum resultado = tabuleiro.VerificarResultado();

				switch (resultado)
				{
					case ResultadoEnum.NENHUM:
						return;
					case ResultadoEnum.VELHA:
						Console.WriteLine("Deu Velha");
						jogoAtivo = false;
						break;
					case ResultadoEnum.VITORIA:
						Console.WriteLine($"O jogador {vez.Nome} venceu!!!");
						jogoAtivo = false;
						break;
				}
			}
		}
	}
}
