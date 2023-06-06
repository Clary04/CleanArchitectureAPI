using Application.Interfaces;
using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
    builder.Services.
        AddDbContext<AppDBContext>
        (options => options.UseSqlite(connectionString));
     
     builder.Services.
         AddScoped<IUserRepository, UserRepository>();
    
     builder.Services.AddMediatR(typeof(CreateUser));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/api/users/{id}", async (IMediator mediator, int id) => 
{ 
    var getUser = new GetUserById { UserId = id };
    var user = await mediator.Send(getUser);
    return Results.Ok(user);
}).WithName("GetUserById");

app.MapPost("/api/users", async (IMediator mediator, User user) =>
{
    var createUser = new CreateUser { Name = user.Name };
    var userCreated = await mediator.Send(createUser);
    return Results.CreatedAtRoute("GetUserById", new { userCreated.ID }, userCreated);
});

app.MapGet("/api/users", async (IMediator mediator) =>
{
    var getCommand = new GetAllUsers();
    var users = await mediator.Send(getCommand);
    return Results.Ok(users);
});

app.MapPut("/api/users/{id}", async (IMediator mediator, User user, int id) =>
{
    var updateUser = new UpdateUser { UserId = id, User = user };
    var userUpdated = await mediator.Send(updateUser);
    return Results.Ok(userUpdated);
});

app.MapDelete("/api/users/{id}", async (IMediator mediator, int id) =>
{
    var deleteUser = new DeleteUser { UserId = id };
    var userDeleted = await mediator.Send(deleteUser);
    return Results.NoContent();
});

app.Run();
