# SecureDevelopment

ищешь папку Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools
1. Запускаешь командную строку под админом и вводишь команду (sn -k myNewKey.snk), где myNewKey - это произвольное имя ключа с обязательным форматом .snk
2. в свойствах проекта указываешь этот ключ
2.1. пересобрать проект, чтоб в <PropertyGroup> появилось указание ключа <AssemblyOriginatorKeyFile>C:\Users\myNewKey.snk</AssemblyOriginatorKeyFile>
3. ищешь папку Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools и в командной строке открываешь ее. Комнда: cd полный_путь_к_папке
4. находишь в папке с проектом dll с названием твоего проекта (на сколько понял нужна она... но хз) примерно тут bin\Debug\net6.0\
5. копируешь полный путь этого dll файла "полный_путь\имя_файла.dll"
6. в ком. строке с по ранее открытому пути к NETFX 4.8 Tools вводишь команду: gacutil -i полный_путь\имя_файла.dll 
Должна появиться надпись сборка добавлена в кэш. После этого можно использовать сборку из GAC
7. сборка будет лежать в папке C:\Windows\Microsoft.NET\assembly\GAC_MSIL. Ее можно подключать к проекту.