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
    class Employee{
        -int Id
        -List<Skill> Skills
        -List<Task> Tasks
    }

     class Person {
        -int Id
        -string Name
        -string Email
        -string PasswordHash
        -List<Permission> Role
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
        -List<Employee> AssignedTo
        -Tag Tag
        -List<Issue> Issues
        -DateTime StartDate
        -DateTime ConclusionDate
        -string Description
        -DateTime Deadline
    }

    class TASK_PRIORITY{
        MINIMAL
        LOW
        MEDIUM
        HIGH
        CRITICAL
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

    class ProjectMember{
        <<Abstract>>
        -int Id
        -Role Role
        -Person Person
    }

    class MemberType{
        -int Id
        -string Label
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
        -Employee Manager
        -string Release
        -List<Squad> Squads
        -List<Task> Tasks
        -List<Milestone> Milestones
    }
    
    class Squad {
        -int Id
        -string Name
        -Employee Leader
        -List<Employee> Team
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

    class Ticket{
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

    class TicketComment{
        -int Id
        -Ticket Ticket
        -Person Author
        -string Text
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
    -List<Project> Projects
    }
    
    class ActivityLog{
        -int Id
        -DateTime Timestamp
        -Person Person
        -ActivityType ActivityType
        -string Description
    }
    class ActivityType{
        -int Id
        -string Name
    }

  
	Project "*"-->"*" Squad 
	Project "*"-->"1" Person 
	Squad "*" --> "1" Employee 
	Squad "*" --> "*" Employee 
	Employee "*" --> "*" Skill 
	Person "*" --> "*" Role 
	Person "1" --> "1" Address 
	Person "0..**" --> "*" ContactInfo 
	Task "*" --> "*" Employee 
	Issue "*" --> "1" Task 
	Tag "1" --> "*" Task 
	Milestone "1" -- "*" Task 
	Project "1" -- "*" Milestone 
	Stakeholder "*" -- "*" Task 
	Stakeholder "*" -- "*" Project
	Stakeholder "1" --> "*" Address 
	Stakeholder "0..**" --> "*" ContactInfo 
    Ticket"0..*" --o "1" Project
    Ticket "*"--> "1" Person
    Ticket "1"-->"1" Task
    Ticket "1"-->"*" TicketComment
    ContactInfo "*"-->"1" ContactType
    Role "*" --> "*" Permission
    Permission "*" --> "1" PERMISSION_TYPE
    Notification "*" --> "1" NotificationType
    Person "1"-->"*"Notification
    Address "*"-->"1" City
    City "*"-->"1" State
    State "*"-->"1" Country
    Task "*" --> "1" TASK_PRIORITY
    ActivityLog "*" --> "1" ActivityType
    ActivityLog "*" --> "1" Person
    Employee  --|>  ProjectMember
    Stakeholder  --|>  ProjectMember
    ProjectMember "1"-->"*" MemberType
```



