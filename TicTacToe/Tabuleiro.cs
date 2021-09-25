using System;

namespace TicTacToe
{
	class Tabuleiro
	{
		private readonly Simbolo[] casas = new Simbolo[9];
		private readonly string separador = "---+---+---";
		private readonly int valorVitoria = 3;

		public Tabuleiro()
		{
			Inicializar();
		}

		private void Inicializar()
		{
			for (int i = 0; i < casas.Length; i++)
			{
				casas[i] = Simbolo.EMPTY;
			}
		}

		public void Desenhar()
		{
			int passo = 3;
			string distancia = "\t\t";
			
			Console.WriteLine();
			for (int i = 0; i < casas.Length; i += passo)
			{
				Console.Write($" {i + 1} | {i + 2} | {i + 3} ");
				Console.Write(distancia);
				Console.WriteLine($" {casas[i].Nome} | {casas[i + 1].Nome} | {casas[i + 2].Nome}");

				if (i < casas.Length - passo)
				{
					Console.Write(separador);
					Console.Write(distancia);
					Console.WriteLine(separador);
				}
			}

			Console.WriteLine();
		}

		public bool MarcarCasa(int numeroCasa, Simbolo simbolo)
		{
			if(numeroCasa is < 1 or > 9)
			{
				throw new ArgumentException("A posição deve ser um número entre 1 e 9.");
			}

			byte posicao = (byte) (numeroCasa - 1);

			if (casas[posicao].Equals(simbolo))
				return false;

			casas[posicao] = simbolo;
			return true;
		}
	
		public ResultadoEnum VerificarResultado()
		{
			if (FoiVitoria())
				return ResultadoEnum.VITORIA;
			else if (FoiVelha())
			{
				return ResultadoEnum.VELHA;
			}

			return ResultadoEnum.NENHUM;
		}

		private bool FoiVitoria()
		{
			return VerificarLinhas() || VerificarColunas() || VerificarDiagonais();
		}

		private bool FoiVelha()
		{
			bool haCasaVazia = false;
			foreach (Simbolo casa in casas)
			{
				if (casa.Equals(Simbolo.EMPTY))
					haCasaVazia = true;
			}

			return !FoiVitoria() && !haCasaVazia;
		}

		private bool VerificarLinhas()
		{
			for (int i = 0; i < casas.Length; i += 3)
			{
				int somaLinha = casas[i].Valor + casas[i + 1].Valor + casas[i + 2].Valor;
				if (valorVitoria == Math.Abs(somaLinha))
					return true;
			}
			return false;
		}

		private bool VerificarColunas()
		{
			for (int i = 0; i < 3; i++)
			{
				int somaColuna = casas[i].Valor + casas[i + 3].Valor + casas[i + 6].Valor;
				if (valorVitoria == Math.Abs(somaColuna))
					return true;
			}
			return false;
		}

		private bool VerificarDiagonais()
		{
			int somaDiagonalP = casas[0].Valor + casas[4].Valor + casas[8].Valor;
			int somaDiagonalS = casas[2].Valor + casas[4].Valor + casas[6].Valor;
			if (valorVitoria == Math.Abs(somaDiagonalP) || valorVitoria == Math.Abs(somaDiagonalS))
				return true;
			return false;
		}

	}
}
