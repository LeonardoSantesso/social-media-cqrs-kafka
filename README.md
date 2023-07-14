## Welcome to Social Media with CQRS, Kafka, EventSourcing and Microservices with .NET
This project is an experimental full-stack application I use to combine several cutting-edge technologies and architectural patterns. Thanks for getting here! please <b>give a ⭐</b> if you liked the project. It motivates me to keep improving it.
<br><br>

## Architecture
The overall architecture is organized with `CQRS.Core`, `Post Command` and `Post Query`.

### CQRS.Core
It defines all the building blocks and abstractions to be used on every underlying project.

### Post Command
It implements infrastructure matters to be used by microservices. Also, it centralizes third-party packages.

### Post Query
It contains projects with logic needed to cross over the microservices, such as `IdentityServer` and `API gateway`.

### Presentation
No presentations, only Api calls.

## Technologies used
<ul>
  <li>
    <a href='https://get.asp.net' target="_blank">APIs with ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx' target="_blank">C# 10</a>
    with:
    <ul>
      <li>.NET 6</li>
      <li>CQRS</li>
      <li>Event Sourcing</li>
      <li>Event Store with MongoDB</li>
      <li>Event Versioning</li>
      <li>Entity Framework Core (MS SQL and PostgreSQL)</li>
      <li>Microservices C# with .NET</li>
      <li>Apache Kafka as a Message Bus</li>
      <li>Optimistic Concurrency Control</li>
      <li>Microsoft SQL to Implement the Read Database</li>
      <li>Database-Per-Service Pattern</li>
      <li>Dependency Injection</li>
      <li>DDD-Oriented Microservices</li>
      <li>Docker</li>
      <li>Docker Compose</li>
      <li>Entity Framework Core 7.0.8</li>      
      <li>Swagger 6.5.0</li>            
    </ul>
  </li>  
</ul>

<br/><br/>


## What do you need to run it 

### Running the microservices using Docker

The project was designed to be easily run within docker containers, hence all you need is 1 command line to up everything. Make sure you have `Docker` installed and have fun!


- Download Docker: <a href="https://docs.docker.com/docker-for-windows/wsl/" target="_blank">Docker Desktop with support for WLS 2</a>
    
<br/>
After installing Docker, in your PowerShell terminal, access the project folder named "Docker" and execute the following command:

```console
 $ docker-compose -f docker-compose-complete.yml -p social-media-cqrs-kafka up -d
``` 
