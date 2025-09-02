### Шаблон для создания решения Visual Studio по чистой архитектуре.

***

### Описание проектов и слоев

### WebApiTemplate.Api - Web Api - основное приложение Rest Api

### Core - ядро приложения
* WebApiTemplate.Core.Domain - Домен приложения. Содержит: Models, Enums, Consts, Rules, ErrorMessages
* WebApiTemplate.Core.Input - Входные модели и валидаторы
* WebApiTemplate.Core.Output - Выходные модели

* WebApiTemplate.Core.Interfaces - Содержит: Интерфейсы (сервисов, репозиториев, внешних сервисов), настройки, паттерн ParameterObject, внутренние модели
* WebApiTemplate.Core.Services - Содержит сервисы с бизнес-логикой, расширения, мапперы, хелперы.

### Infrastructure - слой для взаимодействия с внешними зависимостями (такими как БД)
* WebApiTemplate.Infrastructure.Persistence - слой взаимодействия с базами данных
* WebApiTemplate.Infrastructure.Services - слой для взаимодействия с внешними сервисами (HTTP, GRPS, PUSH, EMAIL, Brokers)

### Tests - различные тесты
* WebApiTemplate.Tests.Unit - юнит тесты сервисов
* WebApiTemplate.Tests.Integration - интеграционные тесты. Например проверка что конфигурация EF Core корректна к реальной БД
* WebApiTemplate.Tests.Infrastructure.Persistence тесты слоя доступа к БД

