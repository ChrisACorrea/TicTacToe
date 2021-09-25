using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	class Simbolo
	{
		public static readonly Simbolo EMPTY = new(' ', 0);
		public static readonly Simbolo O = new('O', 1);
		public static readonly Simbolo X = new('X', -1);

		public char Nome { get; init; }
		public int Valor { get; init; }

		private Simbolo(char nome, int valor)
		{
			Nome = nome;
			Valor = valor;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Simbolo s = (Simbolo) obj;
			return this.Nome.Equals(s.Nome) && this.Valor.Equals(s.Valor);
		}
	}
}
