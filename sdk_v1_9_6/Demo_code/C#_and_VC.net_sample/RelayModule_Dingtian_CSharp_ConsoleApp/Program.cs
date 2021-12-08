using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RelayModule_Dingtian_CSharp_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                string ipAddress = args[0];
                string relayNumber = args[1];
                string desiredState = args[2].ToLower();
                Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                MatchCollection result = ip.Matches(ipAddress);
                if (result.Count != 0)
                {
                    if (desiredState == "on" || desiredState == "off")
                    {
                        if (relayNumber == "1" || relayNumber == "2" || relayNumber == "3" || relayNumber == "4" || relayNumber == "5" || relayNumber == "6" || relayNumber == "7" || relayNumber == "8" )
                        {
                            SendTcpPacket(relayNumber, desiredState, ipAddress);
                        }
                        else
                        {
                            Console.WriteLine("Relay must be a number from 1 to 8");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid State informed. Please use only ON or OFF.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid IP address, please check the command and try again");
                }
            }
            else
            {
                Console.WriteLine("Use: RelayModule_Dingtian_CSharp_ConsoleApp [IPAddress] [RelayNumber(1~8)] [DesiredState(on/off)]");
                Console.WriteLine("Example: RelayModule_Dingtian_CSharp_ConsoleApp 192.168.1.100 1 on");
            }
        }


        public static bool SendTcpPacket(string relaynumber, string status, string ipaddress)
        {
            try
            {
                string text = "";
                Int32 port = 60001;
                TcpClient client = new TcpClient(ipaddress, port);

                if (relaynumber == "1")
                {
                    if (status == "on")
                    {
                        text = "11";
                    }
                    else
                    {
                        text = "21";
                    }

                }
                if (relaynumber == "2")
                {
                    if (status == "on")
                    {
                        text = "12";
                    }
                    else
                    {
                        text = "22";
                    }

                }
                if (relaynumber == "3")
                {
                    if (status == "on")
                    {
                        text = "13";
                    }
                    else
                    {
                        text = "23";
                    }

                }
                if (relaynumber == "4")
                {
                    if (status == "on")
                    {
                        text = "14";
                    }
                    else
                    {
                        text = "24";
                    }

                }
                if (relaynumber == "5")
                {
                    if (status == "on")
                    {
                        text = "15";
                    }
                    else
                    {
                        text = "25";
                    }

                }
                if (relaynumber == "6")
                {
                    if (status == "on")
                    {
                        text = "16";
                    }
                    else
                    {
                        text = "26";
                    }

                }
                if (relaynumber == "7")
                {
                    if (status == "on")
                    {
                        text = "17";
                    }
                    else
                    {
                        text = "27";
                    }

                }
                if (relaynumber == "8")
                {
                    if (status == "on")
                    {
                        text = "18";
                    }
                    else
                    {
                        text = "28";
                    }

                }
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                client.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail to connect to relay board. Error details: " + ex.ToString());
                return false;
            }

        }
       
    }
}
