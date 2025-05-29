Для запуска в Docker:

1. Нужно создать файл ".env" на основе ".env.example" в папке где лежит docker-compose.yml файл.
2. Засетать свои значения для переменных (в частности your_username и your_password).
3. Вызвать "cmd" в папке, где лежит docker-compose.yml файл.
4. Выполнить "docker-compose up --build".
5. http://localhost:8081/swagger
