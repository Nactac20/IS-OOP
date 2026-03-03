# Лабораторная работа 4: Файловый менеджер с поддержкой командной строки

## Описание проекта

Данная лабораторная работа представляет собой консольное приложение для взаимодействия и управления файловой системой. Проект демонстрирует применение принципов SOLID, а также поведенческих, структурных и порождающих паттернов проектирования.

Приложение позволяет выполнять навигацию по файловой системе, просматривать содержимое каталогов и файлов, а также выполнять различные операции с файлами (копирование, перемещение, удаление, переименование) через систему консольных команд.

## Цель работы

Проверить освоение принципов SOLID и паттернов проектирования при разработке приложения для взаимодействия с файловой системой.

## Архитектура проекта

### Ключевые компоненты:

#### 1. Команды (CommandsFiles)
- **`ICommand`** — интерфейс всех команд
- **`CommandResult`** — иерархия результатов выполнения команд (Success, Fail, InfoMessage)
- Реализации команд:
  - `CommandConnect` — подключение к файловой системе
  - `CommandDisconnect` — отключение от файловой системы
  - `CommandTreeGoto` — навигация по дереву каталогов
  - `CommandTreeList` — вывод содержимого каталога в виде дерева
  - `CommandFileShow` — просмотр содержимого файла
  - `CommandFileMove` — перемещение файла
  - `CommandFileCopy` — копирование файла
  - `CommandFileDelete` — удаление файла
  - `CommandFileRename` — переименование файла

#### 2. Обработчики команд (HandlerFiles)
- **`CommandHandler`** — абстрактный базовый класс с реализацией Chain of Responsibility
- **`HandlerChainBuilder`** — строитель цепочки обработчиков
- Специализированные обработчики для каждой команды:
  - `CommandConnectHandler`, `CommandDisconnectHandler`, `CommandTreeGotoHandler`, `CommandTreeListHandler`
  - `CommandFileShowHandler`, `CommandFileMoveHandler`, `CommandFileCopyHandler`
  - `CommandFileDeleteHandler`, `CommandFileRenameHandler`

#### 3. Состояние системы (StateFiles)
- **`IStateSystem`** — интерфейс состояния системы
- **`StateSystem`** — Singleton, хранящий текущий абсолютный путь и предоставляющий доступ к операциям с файлами и директориями
- Методы для работы с путями: `GetFullPath`, `ChangeAbsolutePath`, `Connect`, `Disconnect`, `GotoAction`

#### 4. Операции с файлами (SystemFiles)
- **`ISystemFile`** — интерфейс операций с файлами
- **`SystemFile`** — реализация операций: Copy, Delete, Move, Rename

#### 5. Операции с директориями (SystemDirectoryFiles)
- **`ISystemDirectory`** — интерфейс операций с директориями
- **`SystemDirectory`** — реализация операций: List, Delete, Move, Rename, Create

#### 6. Точка входа (Program.cs)
- Главный цикл обработки команд
- Построение цепочки обработчиков
- Вывод результатов выполнения

## Применённые паттерны

| Паттерн | Где используется | Назначение |
|---------|------------------|------------|
| **Chain of Responsibility** | Иерархия `CommandHandler` | Последовательная обработка команд |
| **Command** | Все классы `ICommand` | Инкапсуляция запросов как объектов |
| **Singleton** | `StateSystem` | Единое состояние системы |
| **Builder** | `HandlerChainBuilder` | Построение цепочки обработчиков |
| **Strategy** | `ISystemFile`, `ISystemDirectory` | Различные стратегии работы с ФС |
| **Factory Method** | Косвенно в парсинге команд | Создание команд по строке ввода |

## Функциональность

### Поддерживаемые команды

| Команда | Формат | Описание |
|---------|--------|----------|
| **connect** | `connect [Address] [-m Mode]` | Подключение к файловой системе |
| **disconnect** | `disconnect` | Отключение от файловой системы |
| **tree goto** | `tree goto [Path]` | Переход в указанный каталог |
| **tree list** | `tree list [-d Depth]` | Вывод дерева каталогов с указанной глубиной |
| **file show** | `file show [Path] [-m Mode]` | Просмотр содержимого файла |
| **file move** | `file move [SourcePath] [DestinationPath]` | Перемещение файла |
| **file copy** | `file copy [SourcePath] [DestinationPath]` | Копирование файла |
| **file delete** | `file delete [Path]` | Удаление файла |
| **file rename** | `file rename [Path] [Name]` | Переименование файла |

### Особенности реализации

- Поддержка абсолютных и относительных путей
- Вывод содержимого каталога в виде дерева с настраиваемой глубиной
- Обработка коллизий имён (проверка существования файлов)
- Расширяемая архитектура для добавления новых файловых систем
- Изоляция логики от консольного ввода/вывода

## Тестирование

Проект покрыт модульными тестами (xUnit), проверяющими ключевую функциональность:

| Тест | Описание | Проверка |
|------|----------|----------|
| `TestConnectCommand` | Подключение к существующей директории | Success |
| `TestDisconnectCommand` | Отключение от файловой системы | Success |
| `TestTreeGotoCommand` | Переход в существующий каталог | Success |
| `TestTreeListCommand` | Вывод дерева каталогов | InfoMessage |
| `TestFileShowCommand` | Просмотр содержимого файла | Содержимое совпадает |
| `TestFileDeleteCommand` | Удаление существующего файла | Success, файл удалён |
| `TestFileMoveCommand_SourceFileDoesNotExist` | Перемещение несуществующего файла | Fail |
| `TestFileCopyCommand_DestinationDirectoryDoesNotExist` | Копирование в несуществующую директорию | Fail |
| `TestFileRenameCommand_NewFileNameAlreadyExists` | Переименование в существующее имя | Fail |

### Тестирование парсера команд

Все тесты проверяют корректность создания команд с правильными аргументами при обработке консольного ввода.

## Нефункциональные требования

- **SOLID**: каждый класс имеет единственную ответственность
- **Расширяемость**: легко добавить новые команды и обработчики
- **Изоляция**: логика не привязана к консольному вводу/выводу
- **Параметризация**: символы дерева и отступы настраиваемы
- **Обработка коллизий**: проверка существования файлов/директорий
- **Независимость от ФС**: интерфейсы позволяют реализовать другие файловые системы
- **Chain of Responsibility**: гибкая обработка команд

## Структура проекта

```
Lab4/
├── CommandsFiles/                 # Реализации команд
│   ├── ICommand.cs
│   ├── CommandResult.cs
│   ├── CommandConnect.cs
│   ├── CommandDisconnect.cs
│   ├── CommandTreeGoto.cs
│   ├── CommandTreeList.cs
│   ├── CommandFileShow.cs
│   ├── CommandFileMove.cs
│   ├── CommandFileCopy.cs
│   ├── CommandFileDelete.cs
│   └── CommandFileRename.cs
├── HandlerFiles/                   # Обработчики команд (Chain of Responsibility)
│   ├── CommandHandler.cs
│   ├── HandlerChainBuilder.cs
│   ├── CommandConnectHandler.cs
│   ├── CommandDisconnectHandler.cs
│   ├── CommandTreeGotoHandler.cs
│   ├── CommandTreeListHandler.cs
│   ├── CommandFileShowHandler.cs
│   ├── CommandFileMoveHandler.cs
│   ├── CommandFileCopyHandler.cs
│   ├── CommandFileDeleteHandler.cs
│   └── CommandFileRenameHandler.cs
├── StateFiles/                      # Состояние системы
│   ├── IStateSystem.cs
│   └── StateSystem.cs (Singleton)
├── SystemFiles/                     # Операции с файлами
│   ├── ISystemFile.cs
│   └── SystemFile.cs
├── SystemDirectoryFiles/            # Операции с директориями
│   ├── ISystemDirectory.cs
│   └── SystemDirectory.cs
├── Program.cs                       # Точка входа
Tests/                           # Модульные тесты
    └── TestsCommands.cs             # 9 тестов
```

## Запуск проекта

1. Клонируйте репозиторий
2. Откройте решение в среде разработки (Rider/VS 2022+)
3. Соберите проект
4. Запустите приложение:
   ```bash
   dotnet run --project Lab4
   ```
5. Вводите команды в консоли (например: `connect C:\Users -m local`)

### Запуск тестов
```bash
dotnet test
```

## Используемые технологии

- .NET 8.0
- C# 12
- xUnit для модульного тестирования
- LINQ для работы с коллекциями

## Принципы проектирования

- **Single Responsibility**: каждый обработчик отвечает за одну команду
- **Open/Closed**: новые команды добавляются без изменения существующего кода
- **Liskov Substitution**: все команды корректно реализуют ICommand
- **Interface Segregation**: интерфейсы минимальны и специфичны
- **Dependency Inversion**: зависимость от абстракций, а не конкретных классов

## Особенности реализации

- **Chain of Responsibility** для обработки команд без громоздких switch/case
- **Command pattern** для инкапсуляции всех операций
- **Singleton** для глобального состояния системы
- **Абстрактные интерфейсы** для поддержки различных файловых систем
- **Рекурсивный обход** для построения дерева каталогов
- **Обработка ошибок** с детальными сообщениями

## Примеры использования

```bash
# Подключение к директории
connect C:\Projects -m local

# Просмотр содержимого с глубиной 2
tree list -d 2

# Переход в подкаталог
tree goto src

# Просмотр файла
file show readme.txt -m console

# Копирование файла
file copy file.txt backup/

# Переименование
file rename old.txt new.txt

# Отключение
disconnect
```