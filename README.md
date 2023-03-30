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
        -List<Address> Addresses
        -List<ContactInfo> ContactInfos
        -DateTime DateOfBirth
        -string ProfileImage
        +int GetAge()
        +bool Login(string email, string password)
    }
    
    class Skill {
        -int Id
        -string Name
    }
    
    class Role {
        -int Id
        -string Name
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
        +void AddAssignee(Person assignee)
        +void RemoveAssignee(Person assignee)
        +void AddIssue(Issue issue)
        +void RemoveIssue(Issue issue)
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
        -string City
        -string State
        -string Country
        -string ZipCode
    } 
    
    class ContactInfo {
        -int Id
        -string Type
        -string Value
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
        +void AddSquad(Squad squad)
        +void RemoveSquad(Squad squad)
        +void AddTask(Task task)
        +void RemoveTask(Task task)
        +void AddMilestone(Milestone milestone)
        +void RemoveMilestone(Milestone milestone)
    }
    
    class Squad {
        -int Id
        -string Name
        -Person Leader
        -List<Person> Team
        -List<Task> Tasks
        +void AddTeamMember(Person member)
        +void RemoveTeamMember(Person member)
        +void AddTask(Task task)
        +void RemoveTask(Task task)
    }
    
    class Milestone {
        -int Id
        -string Title
        -string Description
        -DateTime StartDate
        -DateTime Deadline
        -List<Task> Tasks
        +void AddTask(Task task)
        +void RemoveTask(Task task)
    }

	 class Stakeholder {
    -int Id
    -string Name
    -List<ContactInfo> ContactInfos
    -List<Address> Addresses
    -List<Project> Projects
    +void AddAddress(Address address)
    +void RemoveAddress(Address address)
    +void AddContactInfo(ContactInfo contactInfo)
    +void RemoveContactInfo(ContactInfo contactInfo)
    +void AddProject(Project project)
    +void RemoveProject(Project project)
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
```

#### Diagrama de Casos de Uso

```mermaid

```

#### Diagrama de Entidade Relacional

```mermaid

```
