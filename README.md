# Projects Management

## Proposta

Um projeto para estudo do .net 6, tem como ideia ser um projeto que permita a gerencia de projetos, times, tasks e resposaveis por tasks, algo semelhante.

### Roadmap

| -   | Categoria   | Titulo                          | Descricao                                                                                | Concluida |
| --- | ----------- | ------------------------------- | ---------------------------------------------------------------------------------------- | --------- |
| 1   | Docs        | Modelar casos de uso do projeto | Realizar modelagem dos casos de uso do projeto                                           | N         |
| 2   | Docs        | Modelar classes do projeto      | Realizar modelagem do sistema                                                            | N         |
| 3   | Docs        | Modelar banco do projeto        | Realizar modelagem do banco de dados do projeto                                          | N         |
| 4   | Data Access | Mapear classes para o Entity    | Realizar mapeamento de classes para o Entity trabalhar corretamente com o banco de dados | N         |
| 5   | Auth        | Adicionar autenticacao          | Adicionar autenticacao ao projeto                                                        | N         |
| 6   | Auth        | Adicionar autorizacao           | Adicionar autorizacao ao projeto seguindo o diagrama de casos de uso                     | N         |






### Documentacao

#### Diagrama de Classe

```mermaid
classDiagram
    class Country {
        + Name : string
    }

    class Issue {
        + Title : string
        + Text : string
        + Author : Person?
        + Project : Project?
    }

    class Member {
        + StartDate : DateTime
        + EndDate : DateTime
        + Person : Person
        + Role : Role
        + Tasks : List<TaskAssignment>
    }

    class Milestone {
        + Title : string
        + Description : string
        + StartDate : DateTime
        + DeadLine : DateTime
        + Tasks : List<Task>
    }

    class Notification {
        + Message : string
        + Type : NotificationType
        + IsRead : bool
        + Recipient : Person
    }

    class NotificationType {
        + Name : string
    }

    class Permission {
        + Name : string
        + Roles : List<RolePermission>?
    }

    class Person {
        + Name : string
        + Email : string
        + PasswordHash : string
        + DateOfBirth : DateTime
        + Issue : List<Issue>
        + ProfileImage : string
        + Contacts : List<ContactInfo>
        + Addresses : List<Address>
    }

    class Project {
        + Name : string
        + Manager : Person
        + Release : string
        + Squads : List<Squad>
        + Issues : List<Issue>
        + Milestones : List<Milestone>
    }

    class Role {
        + Name : string
        + Permissions : List<RolePermission>?
    }

    class Squad {
        + Name : string
        + Team : List<Member>
    }

    class State {
        + Name : string
        + Country : Country
    }

    class Tag {
        + Title : string
        + HexColor : string
    }

    class Task {
        + Title : string
        + Description : string
        + Assigner : Person
        + Assignments : List<TaskAssignment>
        + Tags : List<Tag>
        + Issues : List<Issue>
        + Status : TaskStatus
        + StartDate : DateTime
        + ConclusionDate : DateTime
        + DeadLine : DateTime
    }

    class TaskAssignment {
        + MemberId : int
        + Member : Member
        + TaskId : int
        + Task : Task
    }

    class TaskStatus {
        + Name : string
        + Tasks : List<Task>?
    }

    class Ticket {
        + Title : string
        + Description : string
        + Author : Person
        + Project : Project?
        + ResolutionDate : DateTime
    }

    class TicketComment {
        + Text : string
        + Author : Person?
        + Ticket : Ticket?
    }

    Country --> "*" Person
    Issue --> "*" Person
    Issue --> "*" Project
    Member --> "*" TaskAssignment
    Member --> Person
    Member --> Role
    Milestone --> "*" Task
    Notification --> Person
    NotificationType --> "*" Notification
    Permission --> "*" RolePermission
    Permission --> "*" Role
    Person --> "*" Issue
    Person --> "*" ContactInfo
    Person --> "*" Address
    Project --> Person
    Project --> "*" Squad
    Project --> "*" Issue
    Project --> "*" Milestone
    Role --> "*" RolePermission
    Squad --> "*" Member
    State --> Country
    Task --> Person
    Task --> "*" TaskAssignment
    Task --> "*" Tag
    Task --> "*" Issue
    Task --> TaskStatus
    TaskAssignment --> Member
    TaskAssignment --> Task
    TaskStatus --> "*" Task
    Ticket --> Person
    Ticket --> "*" TicketComment
    Ticket --> Project
```



