using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;
using StockManagement.Api.Extensions;
using StockManagement.Identity.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});

var blobStorageConnection = builder.Configuration["ConnectionStrings:SMAdmin:BlobStorage"];

builder.Services.AddAzureClients(azureBuilder =>
{
    azureBuilder.AddBlobServiceClient(blobStorageConnection);
});

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7178",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7102"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.AddDataContexts();
builder.AddServices();
builder.Services.ConfigureIdentity();
builder.Services.AddAuthentication(builder.Configuration);

var app = builder.Build();

app.UseCors("wasm");

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapIdentityApi<User>();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
