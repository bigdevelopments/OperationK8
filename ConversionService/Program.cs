using Arithmetic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string url = builder.Configuration["ARITHMETIC_URL"];

builder.Services.AddSingleton(new Calculator(url, new HttpClient()));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.Logger.LogInformation("Off we go then");
app.Logger.LogInformation("URL of arithmetic service {endpoint}", url);


app.MapGet("/ctof", async (ILogger<object> logger, Calculator calculator, float temp) =>
{
	logger.LogInformation("GET /ctof using {endpoint}", url);
	return await calculator.AddAsync(await calculator.DivideAsync(await calculator.MultiplyAsync(temp, 9), 5), 32);
}).WithName("CtoF");

app.MapGet("/ftoc", async (Calculator calculator, float temp) =>
{
	return await calculator.DivideAsync(await calculator.MultiplyAsync(await calculator.SubtractAsync(temp, 32), 5), 9);
}).WithName("FtoC");



app.MapGet("/kgtolbs", async (Calculator calculator, float weight) =>
{
	return await calculator.MultiplyAsync(weight, 2.20462);
}).WithName("KGtoLBS");

app.MapGet("/lbstokg", async (Calculator calculator, float weight) =>
{
	return await calculator.DivideAsync(weight, 2.20462);
}).WithName("LBStoKG");



app.MapGet("/kmtomiles", async (Calculator calculator, float distance) =>
{
	return await calculator.DivideAsync(distance, 1.60934);
}).WithName("KMtoMILES");

app.MapGet("/milesTokm", async (Calculator calculator, float distance) =>
{
	return await calculator.MultiplyAsync(distance, 1.60934);
}).WithName("MILEStoKM");


app.Run();

