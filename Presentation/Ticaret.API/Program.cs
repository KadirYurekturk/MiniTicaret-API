using FluentValidation.AspNetCore;
using Ticaret.Application.Validators.Products;
using Ticaret.Infra.Filters;
using Ticaret.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
 policy.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:4200","https://localhost:4200")
 ));


// ProductCreateValidator is a custom validator class. And When we use FluentValidation.AspNetCore, it will automatically register the validator class from other classes in the same assembly.
// Add Custom Filter with FluentValidation
builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
    .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<ProductCreateValidator>())
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
