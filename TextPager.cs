using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MXPSQL.TextPager;
public static class TextPager
{
    public static void pager(String text, int maxDisplayLine){

        // more
        bool run = true;
        int line = 0;
        int maxLine = text.Split("\n").Length;

        if(maxDisplayLine < maxLine){
            while(run){
                Console.Clear();
                int currmaxdispline = 0;

                // display
                for(int i = line; i < line + maxDisplayLine; i++){
                    if(i < maxLine + 1){
                        Console.WriteLine(text.Split("\n")[i]);
                        currmaxdispline = i + 1;
                    }
                }

                // nex
                Console.Write($"{line}-{currmaxdispline}/{maxLine}:");
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.Enter){
                    if(line + maxDisplayLine < maxLine){
                        line++;
                    }
                }
                else if(key.Key == ConsoleKey.UpArrow){
                    if(line > 0){
                        line--;
                    }
                }
                else if(key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q){
                    run = false;
                }

            }
        }
        else{
            Console.WriteLine(text);
        }
    }

    static void Main(String[] args){
        if(args.Length > 0){
            pager(File.ReadAllText(args[0]), 10);
        }
        else{
            Console.WriteLine("Not enough args!");
        }

    }
}