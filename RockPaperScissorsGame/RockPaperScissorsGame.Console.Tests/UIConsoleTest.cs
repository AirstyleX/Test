using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace RockPaperScissorsGame.Console.Tests
{
    public class UIConsoleTest
    {
        private const string CONSOLE_TEST_CONTENT = "Some content";
        private const string CONSOLE_TEST_QUESTION = "Are you sure ? [Y]es [N]o";
        private const string CONSOLE_TEST_RESPONSE = "Y";
        private StringWriter _stringWriter;
        public UIConsoleTest()
        {
            _stringWriter = new StringWriter();
            System.Console.SetOut(_stringWriter);
        }

        [Fact]
        public void Someone_WriteLine_WriteInConsole()
        {
            var uIConsole = new UIConsole();

            uIConsole.WriteLine(CONSOLE_TEST_CONTENT);

            Assert.Equal(CONSOLE_TEST_CONTENT, ExtractStringWriter()[0]);
        }

        [Fact]
        public void Someone_ReadLine_ReadInConsole()
        {
            var uIConsole = new UIConsole();
            var stringReader = new StringReader(CONSOLE_TEST_CONTENT);
            System.Console.SetIn(stringReader);

            var result = uIConsole.ReadLine();

            Assert.Equal(CONSOLE_TEST_CONTENT, result);
        }

        [Fact]
        public void Someone_AskForAQuestion_GetTheAnswer()
        {
            var uIConsole = new UIConsole();
            var stringReader = new StringReader(CONSOLE_TEST_RESPONSE);
            System.Console.SetIn(stringReader);

            var result = uIConsole.Question(CONSOLE_TEST_QUESTION, new List<string>() { CONSOLE_TEST_RESPONSE});

            Assert.Equal(CONSOLE_TEST_RESPONSE, result);
        }

        private string[] ExtractStringWriter()
        {
            return _stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            
        }
    }
}
