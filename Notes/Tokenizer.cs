using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
	public class Tokenizer
	{
		public List<Token> tokens;

		public string identifier = String.Empty,
			value = String.Empty,
			content = String.Empty;

		public bool isInsideString = false;

		public char character;

		public int position = 0;

		public Tokenizer()
		{
			tokens = new List<Token>();
		}

		public struct Types
		{
			public const string Note = "Note";
			public const string Group = "Group";
		}

		public void Tokenize(string input)
		{
			tokens.Clear();

			if(!String.IsNullOrEmpty(input))
			{
				bool backSlashFound = false;
				string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

				for(int index = 0; index < input.Length; index++)
				{
					int position = index;
					character = input[position];

					if (isInsideString)
					{
						if (character == '\\')
						{
							backSlashFound = true;
							continue;
						}

						if (character == '"')
						{
							if (backSlashFound)
							{
								value += character;
								backSlashFound = false;
							}
							else
							{
								isInsideString = false;
								continue;
							}
						}
						else
						{
							value += character;
						}
					}
					else if (alphabet.Contains(character.ToString().ToUpper()))
					{
						value += character;
					}
					else
					{
						switch (character)
						{
							case '@':
								tokens.Add(new Token() { Type = "Type", Value = character.ToString() });
								break;
							case ':':
								if(!String.IsNullOrEmpty(value))
								{
									tokens.Add(new Token() { Type = "Identifier", Value = value });
									value = String.Empty;
								}
								else
								{
									continue;
								}
								break;
							case '"':
								if (!isInsideString)
								{
									isInsideString = true;
								}
								break;
							case ';':
								if (!String.IsNullOrEmpty(value))
								{
									tokens.Add(new Token() { Type = "StringContent", Value = value });
									tokens.Add(new Token() { Type = "EndOfStatement", Value = character.ToString() });
								}
								else
								{
									tokens.Add(new Token() { Type = "EndOfStatement", Value = character.ToString() });
								}

								value = String.Empty;
								break;
							case '(':
								tokens.Add(new Token() { Type = "Verb", Value = value });
								tokens.Add(new Token() { Type = "OpeningParenthesis", Value = character.ToString() });

								value = String.Empty;
								break;
							case ',':
								tokens.Add(new Token() { Type = "Parameter", Value = value });
								tokens.Add(new Token() { Type = "ContinuationOperator", Value = character.ToString() });

								value = String.Empty;
								break;
							case ')':
								if(!String.IsNullOrEmpty(value))
								{
									tokens.Add(new Token() { Type = "Parameter", Value = value });
									tokens.Add(new Token() { Type = "ClosingParenthesis", Value = character.ToString() });

									value = String.Empty;
								}
								else
								{
									tokens.Add(new Token() { Type = "ClosingParenthesis", Value = character.ToString() });

									value = String.Empty;
								}
								break;
							default:
								if (!isInsideString && character != ' ')
								{
									value += character;
								}
								break;
						}
					}
				}
			}

			foreach(Token token in tokens)
			{
				Console.WriteLine(token.Type + " " + token.Value);
			}
		}
	}
}
