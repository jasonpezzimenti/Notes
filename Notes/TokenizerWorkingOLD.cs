using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Notes
{
	public class TokenizerWorkingOLD
	{
		public StackList<TokenLESSOLD> tokens;
		private string publicGroupIdentifier;
		public string identifier,
			eventKeyeword,
			value = "",
			stringValue = "";
		public char character;
		public int position = 0;
		public bool isExpectingIdentifier,
			isExpectingAction = false,
			isExpectingEvent = true,
			isExpectingActionOperator,
			isExpectingCommand = true,
			isExpectingString,
			isInsideString;
		private bool isExpectingToVerb;
		private bool bracketFound;
		private bool backSlashFound;
		private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private bool isExpectingType = true;
		private bool doubleQuoteFound = false;

		public TokenizerWorkingOLD()
		{
			tokens = new StackList<TokenLESSOLD>();
		}

		public struct Types
		{
			public const string Note = "Note";
			public const string Group = "Group";
		}

		// Syntax
		// set group "" to "";
		public void Tokenize(string input)
		{
			if (!String.IsNullOrEmpty(input))
			{
				for (int index = 0; index < input.Length; index++)
				{
					int position = index;
					char character = input[position];

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
						if (character == '.')
						{
							if (value == "Note" || value == "Group")
							{
								if (!String.IsNullOrEmpty(value))
								{
									tokens.Add(new TokenLESSOLD()
									{
										Type = "Type",
										Value = value
									});

									value = "";
								}
							}
							else
							{
								tokens.Add(new TokenLESSOLD()
								{
									Type = "Identifier",
									Value = value
								});

								value = "";
							}
						}
						else if (character == ':')
						{
							if (!String.IsNullOrEmpty(value))
							{
								tokens.Add(new TokenLESSOLD()
								{
									Type = "Action",
									Value = value
								});

								value = "";
							}
						}
						else if (character == '"')
						{
							if (!isInsideString)
							{
								isInsideString = true;
							}
						}
						else if (character == ';')
						{
							tokens.Add(new TokenLESSOLD()
							{
								Type = "StringContent",
								Value = value
							});

							value = "";
						}
						else
						{
							if (!isInsideString && character != ' ')
							{
								value += character;
							}
						}
					}

				}
			}
		}
	}
}
