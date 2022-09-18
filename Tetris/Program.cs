using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace Tetris // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gitCommitTest = 0;

            gitCommitTest++;

            Game game = new Game();

            game.Run();
        }
    }
}