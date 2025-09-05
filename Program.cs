using System.Text;
using dtaplace.Endpoints;
using dtaplace.Models;
using dtaplace.Services.JWT;
using dtaplace.Services.Password;
using dtaplace.Services.Profiles;
using dtaplace.Services.Rooms;
using dtaplace.UseCases.AcceptInvitation;
using dtaplace.UseCases.CreateProfile;
using dtaplace.UseCases.CreateRoom;
using dtaplace.UseCases.DeleteRoomUser;
using dtaplace.UseCases.EditProfile;
using dtaplace.UseCases.GetInvitations;
using dtaplace.UseCases.GetPixels;
using dtaplace.UseCases.Getplans;
using dtaplace.UseCases.GetProfile;
using dtaplace.UseCases.GetRoles;
using dtaplace.UseCases.GetRooms;
using dtaplace.UseCases.Login;
using dtaplace.UseCases.PaintPixel;
using dtaplace.UseCases.SendInvitation;
using dtaplace.UseCases.SetRoles;
using dtaplace.UseCases.SignUpPlan;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DTAPlaceDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

//$env:SQL_CONNECTION = "Data Source=localhost; Initial Catalog=dtaplace; Trust Server Certificate=true; Integrated Security=true"
builder.Services.AddTransient<IPasswordService, PBKDF2Service>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddTransient<AcceptInvitationUseCase>();
builder.Services.AddTransient<CreateProfileUseCase>();
builder.Services.AddTransient<CreateRoomUseCase>();
builder.Services.AddTransient<DeleteRoomUserUseCase>();
builder.Services.AddTransient<EditProfileUseCase>();
builder.Services.AddTransient<GetInvitationsUseCase>();
builder.Services.AddTransient<GetPixelsUseCase>();
builder.Services.AddTransient<GetPlansUseCase>();
builder.Services.AddTransient<GetProfileUseCase>();
builder.Services.AddTransient<GetRolesUseCase>();
builder.Services.AddTransient<GetRoomsUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<PaintPixelUseCase>();
builder.Services.AddTransient<SendInvitationUseCase>();
builder.Services.AddTransient<SetRolesUseCase>();
builder.Services.AddTransient<SignUpPlanUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddSingleton<SecurityKey>(key);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "dtaplace",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureAuthEndpoints();
app.ConfigureRoomEndpoints();
app.ConfigureUserEndpoints();

app.Run();