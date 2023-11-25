# Private-Key-And-Seed-Excavator
This console application is designed to filter files with a user-defined extension within a user-specified folder. It extracts Ethereum private keys and seed phrases from these files and provides their corresponding public addresses as output.

![Excavator Gif Loading]([https://raw.githubusercontent.com/tractorAside/Dextools-Trending-Bot/main/DextoolsTrending.gif](https://raw.githubusercontent.com/tractorAside/Private-Key-And-Seed-Excavator/main/excavator.gif))

Features
* Customizable Folder and Extension: Users can specify the folder path and file extension to scan for Ethereum private keys and seed phrases.
* Output Public Addresses: The program outputs the public addresses corresponding to the extracted private keys.
* Security: The application prioritizes user security by allowing them to choose the folder and file extension for scanning.

TO-DO
* Fix for BTC Wallet Output Logic

Example Config:
```{
  "Settings": {
    "AccountSearchDirectory": "C:\\Users\\admin\\Documents\\",
    "Extension": ".xl*" // txt, js, py, cnf, conf, xls, xlsx, xlsm, json, bat, cmd, cs, xml
  }
}
