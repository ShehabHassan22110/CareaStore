using Carea.Api_s.Services;
using Carea.Api_s.Interfaces;
using Carea.BLL.Interface;
using Carea.BLL.Repo;
using Carea.Extend;
using Carea.Interfaces;
using Carea.Models;
using Carea.Services;
using Carea.Services.Interfaces;
using Carea.ViewModels;
using CorePush.Apple;
using CorePush.Google;
using EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
    // Use the default property (Pascal) casing
    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddMvc().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();

});


builder.Services.AddDbContext<ApplicationDbContext>(options => 

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRazorPages();


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBrandRep, BrandRep>();
builder.Services.AddTransient<ICarsRep, CarsRep>();
builder.Services.AddTransient<IOffersRep, OffersRep>();
builder.Services.AddTransient<IComplaints_SuggestionsService,Complaints_SuggestionsService>();
builder.Services.AddTransient<IPrivacyPolicyService,PrivacyPolicyService>();
builder.Services.AddTransient<ITerms_ConditionsSevice,Terms_ConditionsService>();
//FcmNotification
builder.Services.AddTransient<INotificationService,NotificationService>();
builder.Services.AddHttpClient<FcmSender>();
builder.Services.AddHttpClient<ApnSender>();
var appSettingsSection =builder.Configuration.GetSection("FcmNotification");
builder.Services.Configure<FcmNotificationSetting>(appSettingsSection);
//------------
builder.Services.AddTransient<ICar_Photo_ColorRep, Car_Photo_ColorRep>();
builder.Services.AddScoped<ICreateOrderService, CreateOrderService>();
builder.Services.AddScoped<ICarRateRep, CarRateRep>();
builder.Services.AddScoped<IOrderRequestRep, OrderRequestRep>();
builder.Services.AddScoped<IShippingRep, ShippingRep>();
builder.Services.AddScoped<ICreateOrderRep,CreateOrderRep>();
builder.Services.AddScoped(typeof(IDynamicRep<>), typeof(DynamicRep<>));
//------------Api Cors ------------
builder.Services.AddCors();
builder.Services.AddCors(options => {
	options.AddPolicy(name: "AllowOrigin",
		builder => {
			builder.WithOrigins("https://localhost:44363/","https://car-price-prediction-e99b.onrender.com/predict")
								.AllowAnyHeader()
								.AllowAnyMethod();
		});
});

//---------------------------------------------
//Api Interfaces
builder.Services.AddTransient<ICarsApiRep, CarsApiRep>();
builder.Services.AddTransient<IBrandApiRep, BrandApiRep>();
builder.Services.AddTransient<ICar_RateApiRep, Car_RateApiRep>();
builder.Services.AddTransient<IOffersApiRep, OffersApiRep>();
builder.Services.AddTransient<IOrderRequestApiRep, OrderRequestApiRep>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                    };
                });

IdentityBuilder identityBuilder = builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => {

    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<ApplicationDbContext>()
      .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
builder.Services.AddEndpointsApiExplorer();




var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseCors(builder => {
	builder
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader();
});
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
