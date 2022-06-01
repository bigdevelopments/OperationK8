var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/add", (float p1, float p2) =>
{
	return p1 + p2;
}).WithName("Add");

app.MapGet("/sub", (float p1, float p2) =>
{
	return p1 - p2;
}).WithName("Subtract");

app.MapGet("/mul", (float p1, float p2) =>
{
	return p1 * p2;
}).WithName("Multiply");

app.MapGet("/div", (float p1, float p2) =>
{
	return p1 / p2;
}).WithName("Divide");

app.Run();

