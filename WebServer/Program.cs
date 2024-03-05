using BookService;
using FilmService;
using Grpc.Net.Client;
using WebServer.Data;

var builder = WebApplication.CreateBuilder(args);

using var channel = GrpcChannel.ForAddress("http://host.docker.internal:5291");
var bookClient = new BookServ.BookServClient(channel);
var bookListReceiver = new BookServiceInteractor(bookClient);

using var channel2 = GrpcChannel.ForAddress("http://host.docker.internal:5136");
var filmClient = new FilmServ.FilmServClient(channel2);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(bookListReceiver);
builder.Services.AddSingleton(filmClient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();