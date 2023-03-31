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
     class Person {
        -int Id
        -string Name
        -string Email
        -string PasswordHash
        -Role Role
        -List<Skill> Skills
        -List<Task> Tasks
        -DateTime DateOfBirth
        -string ProfileImage
        -List<ContactInfo> ContactInfos
        -List<Address> Addresses
    }
    
    class Skill {
        -int Id
        -string Name
    }
    
    class Role {
        -int Id
        -string Name
        -List<Permission> Permissions
    } 
    

    class Permission{
        -int Id
        -PERMISSION_TYPE Type
        -string Name
    }

    class PERMISSION_TYPE{
        CREATE,
        READ
        UPDATE,
        DELETE,
    }

    class Task {
        -int Id
        -string Title
        -Person Assigner
        -List<Person> AssignedTo
        -Tag Tag
        -List<Issue> Issues
        -DateTime StartDate
        -string Description
        -DateTime Deadline
    }
    
    class Issue {
        -int Id
        -string Title
        -string Text
        -Person Author
        -Task ResponseOf
        -DateTime DateCreated
        -DateTime DateResolved
    }
    
    class Address {
        -int Id
        -string Street
        -string Number
        -string Complement
        -string Neighborhood
        -City City
        -string ZipCode
    } 

    class City{
        -int Id
        -string Name
        -State State
    }

    class State{
        -int Id
        -string Name
        -Country Name
    }

    class Country{
        -int Id
        -string Name
    }
    
    class ContactInfo {
        -int Id
        -ContactType Type
        -string Value
    }

    class ContactType{
        -int Id
        -string Name
    }
	
    class Tag {
        -int Id
        -string Title
        -string HexColor
    }
    
    class Project {
        -int Id
        -string Name
        -Person Manager
        -List<Squad> Squads
        -List<Task> Tasks
        -List<Milestone> Milestones
    }
    
    class Squad {
        -int Id
        -string Name
        -Person Leader
        -List<Person> Team
        -List<Task> Tasks
    }
    
    class Milestone {
        -int Id
        -string Title
        -string Description
        -DateTime StartDate
        -DateTime Deadline
        -List<Task> Tasks
    }

    class Call{
        -int Id
        -string Title
        -string Description
        -DateTime CreatedAt
        -Person Author
        -Project Project
        -Task Task
        -List<Issue> Issues
        -DateTime ResolutionDate
    }

    class Notification {
    -int Id
    -string Message
    -NotificationType Type
    -bool IsRead
    -DateTime CreatedAt
    -Person Recipient
}

    class NotificationType{
        -int Id
        -string Name
    }

	class Stakeholder {
    -int Id
    -Person Pessoa
    -List<Project> Projects
}

	Project "*"-->"*" Squad 
	Project "*"-->"1" Person 
	Squad "*" --> "1" Person 
	Squad "*" --> "*" Person 
	Person "*" --> "*" Skill 
	Person "*" --> "*" Role 
	Person "1" --> "1" Address 
	Person "0..**" --> "*" ContactInfo 
	Task "*" --> "*" Person 
	Issue "*" --> "1" Task 
	Tag "1" --> "*" Task 
	Milestone "*" -- "1" Task 
	Stakeholder "*" -- "1" Person 
	Stakeholder "*" -- "*" Task 
	Stakeholder "*" -- "*" Project
	Stakeholder "1" --> "*" Address 
	Stakeholder "0..**" --> "*" ContactInfo 
    Call"0..*" --o "1" Project
    Call "*"--> "1" Person
    Call "1"-->"1" Task
    Call "1"-->"1" Issue
    ContactInfo "*"-->"1" ContactType
    Role "*" --> "*" Permission
    Permission "*" --> "1" PERMISSION_TYPE
    Notification "*" --> "1" NotificationType
    Person "1"-->"*"Notification
    Address "*"-->"1" City
    City "*"-->"1" State
    State "*"-->"1" Country
```

#### Diagrama de Casos de Uso

```mermaid

```

#### Diagrama de Entidade Relacional

```mermaid

```
