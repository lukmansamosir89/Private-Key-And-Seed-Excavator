using Nethereum.HdWallet;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.IO;
using System.Text;

namespace PrivateKeyAndSeedExcavator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Config appConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText(@Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\config.json"));
            string[] inputFiles = Directory.GetFiles(appConfig.Settings.AccountSearchDirectory, "*" + appConfig.Settings.Extension, SearchOption.AllDirectories);
            FileStream fs = new FileStream("found_addresses.txt", FileMode.Append);
            TextWriter sw = new StreamWriter(fs);
            int keyCount = 0;
            int fileCount = 0;
            string accountDatabase = "";
            foreach (var file in inputFiles)
            {
                FileInfo fi = new FileInfo(file);
                Console.WriteLine(fileCount + "/" + inputFiles.Length + " Files Processed \n");
                Console.WriteLine(Directory.GetParent(file).FullName);
                fileCount++;


                if (fi.Extension.Contains("xls"))
                {

                    try
                    {
                        if (file.Contains("$") && fi.Length == 165)
                        {
                            continue;
                        }

                        string excelLines = ReadXlsFile(file);
                        if (excelLines == "")
                        {
                            continue;
                        }
                        string[] lines = excelLines.Split('\n');
                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                            try
                            {
                                if (line.Length == 66 & line.StartsWith("0x") & !accountDatabase.Contains(line))
                                {
                                    var account = new Account(line);
                                    //Key privateKey = new Key(Encoders.Hex.DecodeData(line.TextAfter("0x")));
                                    //PubKey publicKey = privateKey.PubKey;
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"legacy{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"segwit{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"p2sh{ex.Message}");
                                    //}
                                    sw.WriteLine(keyCount + " - Private Key: " + line);
                                    sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                    accountDatabase = accountDatabase + " " + line;
                                    keyCount++;
                                }
                                else if (line.Length == 64 & !accountDatabase.Contains(line))
                                {
                                    var account = new Account(("0x" + line));
                                    //Key privateKey = new Key(Encoders.Hex.DecodeData(line));
                                    //PubKey publicKey = privateKey.PubKey;
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"legacy{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"segwit{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"p2sh{ex.Message}");
                                    //}

                                    sw.WriteLine(keyCount + " - Private Key: 0x" + line);
                                    sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                    accountDatabase = accountDatabase + " " + line;
                                    keyCount++;
                                }
                                else if (line.Length > 64)
                                {
                                    string[] _splitSpace = line.Split(' ', ',', '"', '.', ':', '/', '-', ';');
                                    foreach (string part in _splitSpace)
                                    {
                                        try
                                        {
                                            if (part.Length == 66 & part.StartsWith("0x") & !accountDatabase.Contains(part))
                                            {
                                                var account = new Account(part);
                                                //Key privateKey = new Key(Encoders.Hex.DecodeData(part.TextAfter("0x")));
                                                //PubKey publicKey = privateKey.PubKey;
                                                //try
                                                //{
                                                //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                                //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    Console.WriteLine($"legacy{ex.Message}");
                                                //}
                                                //try
                                                //{
                                                //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                                //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    Console.WriteLine($"segwit{ex.Message}");
                                                //}
                                                //try
                                                //{
                                                //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                                //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    Console.WriteLine($"p2sh{ex.Message}");
                                                //}

                                                sw.WriteLine(keyCount + " - Private Key: " + part);
                                                sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                                accountDatabase = accountDatabase + " " + part;
                                                keyCount++;

                                            }
                                            else if (part.Length == 64 & !accountDatabase.Contains(part))
                                            {

                                                var account = new Account(("0x" + part));
                                                //Key privateKey = new Key(Encoders.Hex.DecodeData(part));
                                                //PubKey publicKey = privateKey.PubKey;
                                                //try
                                                //{
                                                //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                                //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    Console.WriteLine($"legacy{ex.Message}");
                                                //}
                                                //try
                                                //{
                                                //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                                //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    Console.WriteLine($"segwit{ex.Message}");
                                                //}
                                                //try
                                                //{
                                                //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                                //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //    Console.WriteLine($"p2sh{ex.Message}");
                                                //}

                                                sw.WriteLine(keyCount + " - Private Key: 0x" + part);
                                                sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                                accountDatabase = accountDatabase + " " + part;
                                                keyCount++;
                                            }
                                            else
                                            {
                                                if (!accountDatabase.Contains(part))
                                                {
                                                    var account = new Wallet(part, "").GetAccount(0);
                                                    sw.WriteLine(keyCount + " - Seed: " + part);
                                                    sw.WriteLine(keyCount + " - PrivateKey: " + account.PrivateKey);
                                                    sw.WriteLine(keyCount + " - Address: " + account.Address);
                                                    accountDatabase = accountDatabase + " " + part;
                                                    keyCount++;
                                                }


                                            }
                                        }
                                        catch
                                        {

                                            continue;
                                        }
                                    }
                                    if (!accountDatabase.Contains(line))
                                    {
                                        var accountLine = new Wallet(line, "").GetAccount(0);
                                        sw.WriteLine(keyCount + " - Seed: " + line);
                                        sw.WriteLine(keyCount + " - PrivateKey: " + accountLine.PrivateKey);
                                        sw.WriteLine(keyCount + " - Address: " + accountLine.Address);
                                        accountDatabase = accountDatabase + " " + line;
                                        keyCount++;
                                    }
                                }

                            }
                            catch
                            {

                                continue;
                            }

                        }
                        Console.WriteLine(fi.FullName);
                        Console.Write("File : " + fileCount + " finished.");

                    }
                    catch (Exception ex)
                    {
                        FileStream fs2 = new FileStream("addresses+balances_found_error.txt", FileMode.Append);
                        TextWriter sw2 = new StreamWriter(fs2);

                        sw2.WriteLine((file));
                        sw2.WriteLine(ex.ToString());

                        Console.WriteLine();

                        sw2.Close();
                        throw;
                    }

                }
                else
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(file);
                        foreach (string line in lines)
                        {
                            if (line.Length == 66 && line.StartsWith("0x") && !accountDatabase.Contains(line))
                            {

                                try
                                {
                                    var account = new Account(line);
                                    //Key privateKey = new Key(Encoders.Hex.DecodeData(line));
                                    //PubKey publicKey = privateKey.PubKey;
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"legacy{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"segwit{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"p2sh{ex.Message}");
                                    //}

                                    sw.WriteLine(keyCount + " - Private Key: " + line);
                                    sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                    accountDatabase = accountDatabase + " " + line;
                                    keyCount++;
                                }
                                catch { }

                            }

                            if (line.Length == 64 && !accountDatabase.Contains(line))
                            {
                                try
                                {
                                    var account = new Account(("0x" + line));
                                    //Key privateKey = new Key(Encoders.Hex.DecodeData(line));
                                    //PubKey publicKey = privateKey.PubKey;
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"legacy{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"segwit{ex.Message}");
                                    //}
                                    //try
                                    //{
                                    //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                    //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    Console.WriteLine($"p2sh{ex.Message}");
                                    //}

                                    sw.WriteLine(keyCount + " - Private Key: 0x" + line);
                                    sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                    accountDatabase = accountDatabase + " " + line;
                                    keyCount++;
                                }
                                catch { }
                            }

                            if (line.Length > 64 && !line.StartsWith("0x"))
                            {
                                string[] _splitSpace = line.Split(' ', ',', '"', '.', ':', '/', '-', ';');

                                foreach (string part in _splitSpace)
                                {

                                    try
                                    {

                                        if (part.Length == 66 & part.StartsWith("0x") & !accountDatabase.Contains(part))
                                        {
                                            var account = new Account(part);
                                            sw.WriteLine(keyCount + " - PrivateKey: " + part);
                                            //Key privateKey = new Key(Encoders.Hex.DecodeData(part.TextAfter("0x")));
                                            //PubKey publicKey = privateKey.PubKey;
                                            //try
                                            //{
                                            //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                            //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                            //}
                                            //catch (Exception ex)
                                            //{
                                            //    Console.WriteLine($"legacy{ex.Message}");
                                            //}
                                            //try
                                            //{
                                            //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                            //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                            //}
                                            //catch (Exception ex)
                                            //{
                                            //    Console.WriteLine($"segwit{ex.Message}");
                                            //}
                                            //try
                                            //{
                                            //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                            //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                            //}
                                            //catch (Exception ex)
                                            //{
                                            //    Console.WriteLine($"p2sh{ex.Message}");
                                            //}

                                            sw.WriteLine(keyCount + " - Private Key: " + part);
                                            sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                            accountDatabase = accountDatabase + " " + part;
                                            keyCount++;
                                            continue;
                                        }
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex); }



                                    try
                                    {


                                        if (part.Length == 64 & !accountDatabase.Contains(part))
                                        {

                                            var account = new Account(("0x" + part));
                                            //Key privateKey = new Key(Encoders.Hex.DecodeData(part));
                                            //PubKey publicKey = privateKey.PubKey;
                                            //try
                                            //{
                                            //    BitcoinAddress BTCaddressLegacy = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

                                            //    sw.WriteLine(keyCount + " - BTC Legacy Address: " + BTCaddressLegacy.ToString());
                                            //}
                                            //catch (Exception ex)
                                            //{
                                            //    Console.WriteLine($"legacy{ex.Message}");
                                            //}
                                            //try
                                            //{
                                            //    BitcoinAddress BTCaddressSegwit = publicKey.GetAddress(ScriptPubKeyType.Segwit, Network.Main);

                                            //    sw.WriteLine(keyCount + " - BTC Segwit Address: " + BTCaddressSegwit.ToString());
                                            //}
                                            //catch (Exception ex)
                                            //{
                                            //    Console.WriteLine($"segwit{ex.Message}");
                                            //}
                                            //try
                                            //{
                                            //    BitcoinAddress BTCaddressSegwitP2SH = publicKey.GetAddress(ScriptPubKeyType.SegwitP2SH, Network.Main);

                                            //    sw.WriteLine(keyCount + " - BTC Segwit P2SH Address: " + BTCaddressSegwitP2SH.ToString());
                                            //}
                                            //catch (Exception ex)
                                            //{
                                            //    Console.WriteLine($"p2sh{ex.Message}");
                                            //}

                                            sw.WriteLine(keyCount + " - Private Key: 0x" + part);
                                            sw.WriteLine(keyCount + " - EVM Address: " + account.Address);
                                            accountDatabase = accountDatabase + " " + part;
                                            keyCount++;
                                            continue;
                                        }
                                    }
                                    catch { }
                                    try
                                    {

                                        if (!accountDatabase.Contains(part))
                                        {
                                            var account = new Wallet(part, "").GetAccount(0);
                                            sw.WriteLine(keyCount + " - Seed: " + part);
                                            sw.WriteLine(keyCount + " - PrivateKey: " + account.PrivateKey);
                                            sw.WriteLine(keyCount + " - Address: " + account.Address);
                                            accountDatabase = accountDatabase + " " + part;
                                            keyCount++;
                                            continue;
                                        }



                                    }
                                    catch { }

                                }
                                try
                                {

                                    if (!accountDatabase.Contains(line))
                                    {
                                        var accountLine = new Wallet(line, "").GetAccount(0);
                                        sw.WriteLine(keyCount + " - Seed: " + line);
                                        sw.WriteLine(keyCount + " - PrivateKey: " + accountLine.PrivateKey);
                                        sw.WriteLine(keyCount + " - Address: " + accountLine.Address);
                                        accountDatabase = accountDatabase + " " + line;
                                        keyCount++;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        FileStream fs2 = new FileStream("addresses+balances_found_error.txt", FileMode.Append);
                        TextWriter sw2 = new StreamWriter(fs2);
                        sw2.WriteLine(ex.ToString());
                        sw2.Close();
                        continue;
                    }

                }



            }
            sw.Close();


            Console.ReadLine();


        }
        static string ReadXlsFile(string fileName)
        {
            try
            {
                var fileInfo = new FileInfo(fileName);
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    StringBuilder resultBuilder = new StringBuilder();

                    foreach (var worksheet in package.Workbook.Worksheets)
                    {
                        foreach (var cell in worksheet.Cells)
                        {
                            resultBuilder.Append(cell.Text).Append("\n");
                        }
                        resultBuilder.AppendLine();
                    }

                    return resultBuilder.ToString();
                }
            }
            catch
            {

                return "";
            }

        }




        public class Config
        {
            public Settings Settings { get; set; }

        }

        public class Settings
        {

            public string AccountSearchDirectory { get; set; }
            public string Extension { get; set; }


        }
    }
    public static class Extension
    {
        public static string TextAfter(this string value, string search)
        {
            return value.Substring(value.IndexOf(search) + search.Length);
        }
    }
}
