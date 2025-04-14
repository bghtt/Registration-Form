# Поле для регистрации на C#
Это минималистичное приложение Windows Forms для регистрации пользователей с сохранением данных в PostgreSQL (pgAdmin4).
# Требования
+ NET Framework 4.7.2 или новее
+ PostgreSQL сервер
+ gAdmin4 для управления БД
+ Npgsql (PostgreSQL .NET Data Provider)
# Установка
1. Клонируйте репозиторий
2. Установите Npgsql через NuGet
   ``` C#
   Install-Package Npgsql -Version 4.1.10
   ```
3. Создайте БД в pgAdmin4
# Настройка подключения
Замените строку подключения в коде на ваши данные:
``` C#
   private string _connectionString = "Host=your_server;Username=your_user;Password=your_password;Database=your_db";
   ```
# Запуск приложения
Для запуска приложения выполните одну из следующих команд, в зависимости от установленной версии Docker Compose:
``` C#
   dockercompose up --build
```