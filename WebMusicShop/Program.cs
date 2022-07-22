using WebMusicShop.Helper;
using WebMusicShop.Models.Context;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.ICliente;
using WebMusicShop.Models.Interfaces.IProduto;
using WebMusicShop.Models.Interfaces.IUsuario;
using WebMusicShop.Models.Interfaces.IVenda;
using WebMusicShop.Models.Repositories;
using WebMusicShop.Models.Services;


var builder = WebApplication.CreateBuilder(args);
//conexão com banco de dados
builder.Services.AddScoped<IConnectionManager,ConnectionManager>();
//Clientes
builder.Services.AddScoped<IClienteContext, ClienteContext>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
//Produtos
builder.Services.AddScoped<IProdutoContext, ProdutoContext>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
//Usuario
builder.Services.AddScoped<IUsuarioContext, UsuarioContext>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
//Venda
builder.Services.AddScoped<IVendaContext, VendaContext>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IVendaService, VendaService>();
//Sessão
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
