# KnowledgeBase v2

**Full Clean-Architecture KnowledgeBase Project rework**

> Managing CLI-Commands, Code-Snippets/Implementations and Documentations

## Containing

### PresentationLayer

- [ ] WebAPI
- [ ] WPF Desktop App
  - Blazor Webapp
  - Vue/Angular FrontEnd

### Application Layer

- [ ] DTOs for Services
  - ServiceResponse
  - ServiceResponse\<T>
- [ ] Contracts
  - IKbCommand
  - IKbCode
  - IKbDocumentation

### Domain Layer

- [ ] Entities
  - KBCommand
  - KBCode
  - KBDocumentation
  - KBDescriptor
  - KBDescription
- [ ] DTOs for Entities
  - ValueDTO
  - NoIdDTO : ValueDTO
  - IdDTO : NoIdDTO
  - CreateDTO : NoIdDTO
  - ReadUpdateDTO : IdDTO

### Infrastructure Layer

- [ ] Data
  - RemoteDbContext
  - LocalDbContext

## Dependencies

- WebAPI

  - [x] Microsoft.EntityFrameworkCore
  - [x] Microsoft.EntityFrameworkCore.SqlServer
  - [x] Microsoft.EntityFrameworkCore.Tools

- Infrastructure
  - [x] Microsoft.EntityFrameworkCore
  - [x] Microsoft.EntityFrameworkCore.SqlServer
  - [x] Microsoft.EntityFrameworkCore.Tools
