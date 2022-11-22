using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
	public class Tokenizer
	{
		private Char[] chars;
		private int length;
		private int index = 0;
		private int row = 0;
		private int col = 0;

		public Tokenizer(string source)
		{
			chars = source.ToCharArray();
			length = chars.Length;
		}

		public IEnumerable<Token> Tokenize()
		{
			var ch = chars[index];
			while (index < length)
			{
				if (Char.IsLetter(ch))
					yield return Identifier();
				else if (Char.IsDigit(ch))
					yield return Number();
				else if (Char.IsWhiteSpace(ch))
					yield return WhiteSpace();
				else switch (ch)
					{
						case '"': yield return Stringtoken(); break;
						case '-':
							index++;
							col++;
							ch = index < length ? chars[index] : '\0';
							switch (ch)
							{
								case '>': col++; index++; yield return new Token { source = "->", value = "->", row = row, column = col, type = TokenType.Operator }; break;
								default: yield return new Token { source = "-", value = "-", row = row, column = col, type = TokenType.Operator }; break;
							}
							break;
						case '{': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						case '}': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						case '.': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						case ';': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						case '[': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						case ']': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						case ':': col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Operator }; break;
						default:
							col++; index++; yield return new Token { source = $"{ch}", value = $"{ch}", row = row, column = col, type = TokenType.Unknown }; break;
					}

				ch = index < length ? chars[index] : '\0';
			}
		}

		Token Stringtoken()
		{
			var localIndex = index + 1;
			var localCols = col;
			var content = new StringBuilder();
			while (localIndex < length && chars[localIndex] != '"')
			{
				localCols++;
				if (chars[localIndex] == '\n')
				{
					row++;
					localCols = 0;
				}
				if (chars[localIndex] == '\\')
				{
					if (localIndex + 1 < length)
					{
						localIndex++;
						localCols++;
						if (chars[localIndex] == '\n')
						{
							row++;
							localCols = 0;
						}
					}
				}
				content.Append(chars[localIndex]);
				localIndex++;
			}
			var source = chars.AsSpan().Slice(index, localIndex - index + 1).ToString();
			var value = content.ToString();
			col = localCols + 1;
			index = localIndex + 1;
			return new Token { source = source, value = value, row = row, column = col, type = TokenType.String };
		}

		Token WhiteSpace()
		{
			var localIndex = index + 1;
			var localCols = col;
			while (localIndex < length && Char.IsWhiteSpace(chars[localIndex]))
			{
				localCols++;
				if (chars[localIndex] == '\n')
				{
					row++;
					localCols = 0;
				}
				localIndex++;
			}
			var value = chars.AsSpan().Slice(index, localIndex - index).ToString();
			col = localCols;
			index = localIndex;
			return new Token { source = value, value = value, row = row, column = col, type = TokenType.Whitespace };
		}

		Token Number()
		{
			var localIndex = index + 1;
			while (localIndex < length && Char.IsDigit(chars[localIndex]))
				localIndex++;
			var value = chars.AsSpan().Slice(index, localIndex - index).ToString();
			col += value.Length;
			index = localIndex;
			return new Token { source = value, value = value, row = row, column = col, type = TokenType.Number };
		}

		Token Identifier()
		{
			var localIndex = index + 1;
			while (localIndex < length && Char.IsLetterOrDigit(chars[localIndex]))
				localIndex++;
			var value = chars.AsSpan().Slice(index, localIndex - index).ToString();
			col += value.Length;
			index = localIndex;
			return new Token { source = value, value = value, row = row, column = col, type = TokenType.Identifier };
		}
	}

	public class Token
	{
		public int row;
		public int column;
		public string source;
		public string value;
		public TokenType type;
	}

	public enum TokenType
	{
		Identifier,
		Number,
		String,
		Whitespace,
		Operator,
		Unknown
	}
}