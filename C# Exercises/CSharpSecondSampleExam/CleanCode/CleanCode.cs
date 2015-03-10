using System;
using System.Text;
class AstrologicalDigit
{
    static void Main()
    {
        int N = Int32.Parse(Console.ReadLine());
        StringBuilder str = new StringBuilder();
        StringBuilder buffer = new StringBuilder();
        int i = 0;
        bool multiLineComments = false;
        bool singleComments = false;
        bool isQue = false;
        bool link = false;
        //StreamReader reader = new StreamReader("test.008.in.txt");
        //string line = null;
        /*  while ((line = reader.ReadLine()) != null)
        {
            str.Append(line);
            str.Append('\n');
        }*/
        for (int k = 0; k < N; k++)
        {
            str.Append(Console.ReadLine());
            str.Append('\n');
        }

        while (i < str.Length)
        {
            if (!multiLineComments && !singleComments && str[i] == '"')
            {
                if (i >= 1)
                {
                    if (isQue && str[i - 1] != '\\')
                    {
                        isQue = false;
                    }
                    else if (!isQue && str[i - 1] != '\\')
                    {
                        isQue = true;
                    }

                }
                else
                {
                    if (isQue)
                    {
                        isQue = false;
                    }
                    else
                    {
                        isQue = true;
                    }
                }

            }
            else if (singleComments && str[i] == '\n')
            {
                singleComments = false;

            }
            else if (multiLineComments && str[i] == '*' && str[i + 1] == '/' && !isQue)
            {
                multiLineComments = false;
                i = i + 2;
                continue;
            }
            else if (str[i] == '/' && str[i + 1] == '/' && !isQue && !multiLineComments && !link)
            {
                if (i >= 1)
                {
                    if (str[i + 2] != '/' && str[i - 1] != '/')
                    {
                        singleComments = true;
                    }
                }
                else
                {
                    singleComments = true;
                }
            }
            else if (str[i] == '/' && str[i + 1] == '*' && !isQue && !singleComments)
            {
                multiLineComments = true;

            }
            else if (str[i] == 'h' && str[i + 1] == 't' && str[i + 2] == 't' && str[i + 3] == 'p')
            {
                link = true;
            }
            else if (str[i] == ' ' && link)
            {
                link = false;
            }

            if (!singleComments && !multiLineComments)
            {
                if (str[i] == '\n')
                {
                    string temp = buffer.ToString();
                    if (!String.IsNullOrWhiteSpace(temp))
                    {
                        buffer.Append('\n');
                        printBuffer(buffer);
                        buffer.Length = 0;
                        i++;
                        continue;
                    }
                    else
                    {
                        buffer.Length = 0;
                    }

                }
                else
                {
                    buffer.Append(str[i]);
                }

            }

            i++;
        }

        if (buffer.Length > 0)
        {
            printBuffer(buffer);
        }

        //reader.Close();
    }

    static void printBuffer(StringBuilder buffer)
    {

        Console.Write(buffer.ToString());

    }


}