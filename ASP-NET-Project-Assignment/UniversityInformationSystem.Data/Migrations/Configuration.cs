namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityInformationSystem.Data.UisDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UniversityInformationSystem.Data.UisDataContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Administrator"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Administrator"));
            }

            if (!context.Roles.Any(role => role.Name == "Teacher"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Teacher"));
            }

            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Student"));
            }

            if (!context.Users.Any())
            {
                var firstUser = new ApplicationUser()
                {
                    UserName = "kirilvk1",
                    Email = "kiril.98.kirilov@gmail.com",
                    PhoneNumber = "0895964686",
                    FirstName = "Kiril",
                    LastName = "Kirilov",
                    BirthDate = new DateTime(1996, 1, 6)
                };
                var userManager = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(context));
                userManager.Create(firstUser, "");
                userManager.AddToRole(firstUser.Id, "Administrator");
            }

            context.Courses.AddOrUpdate(c => c.Name, new Course[]
                {
                    new Course()
                    {
                        Name = "Programming Basics",
                        Description = "����������� �����������, ���������� ����a \"Programming Basics\" � ����� C#! ���������� � ��������� � ��������� �� ������� ���������, ���� ���� ������� ������ �� ������������ � ����� C#, ���������� �� ������ ������������ ������������ � �������.",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Programming Fundamentals",
                        Description = "������ \"Programming Fundamentals\" ��������� ����������� �� ������� ������� ������ �� ������ �� ��������� ��� �� ����� \"������ �� ��������������\" � ��������� � ������ ������� � ����������� �� ����������� ������������ ����� �������� �� ������ ��������� �����������.",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Software Technologies",
                        Description = "������ \"Software Technologies\" ���� ������� �������� �� ���-������������ ��������� ���������� � ���������� � ��������� �� ���������� �� �� ���������� ��� ���������� �� ��������, �� �� �� �������� ��-�����������. �������� �� ������ ��������� �� front-end � back-end ������������. ������ �� ������ �� ������ �����: HTML5 ���������� (HTML + CSS + JavaScript + AJAX + REST), PHP ��� ���������� (PHP + MySQL), C# ��� ���������� (ASP.NET MVC + Entity Framework + SQL Server) � Java ��� ���������� (Java + Spring MVC + Hibernate + MySQL).",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "JS Fundamentals",
                        Description = "������ \"JavaScript Fundamentals\" �������� ������ ������ �� ������������ � ����� JavaScript. �������� �� ������������� �� JavaScript �� ���������� �� ��������� ������, ������ �����, ���������, ������, ������� �����������, ����� � ������ � �������. ������ �� �������� �� ������ � ������, ��������� � ��������� ������, ���������� �� ������, ����������� ������ � ���������. ������ � ������� �� ���-���������� ��������� � JS ���������� (������� �� ES2017).",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Databases Basics SQL Server",
                        Description = "������������ ���� �� ������ �� ������ ����� � �� �� �������e � ���� �� ���-������ ���������� ������� �� ���������� �� ���� ����� (DBMS), ���������� ��� ������������ �� ���������� ������������� ������� - Microsoft SQL Server. ������ ������ �������� �������� �� ����������� �����, ������������ �� ����� � ER �������� (������� � ���������� ������) � �������� ����� SQL (��������� �� �����, ��������, ��������, ����������, ���������, ���������, �������, ��������� � ��������).",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Wordpress Basics",
                        Description = "������ WordPress Basics �������� ������ ���������� ������ �� ���������� �� ��� ������� � WordPress: ��������� �� ������� � ������, ����������� � ������������� �� WordPress (WP), ����������� � ������������� �� ���� (themes) � ������� (plugins), ��������� � ����������� �� ��� ���������� (����� � � �������� ��� ���������), ��������� �� ��������, ����������, ������ � ����������.",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Data Structures",
                        Description = "������ �� ��������� �� ����� ��������� ����������� � ���-������������ ��������� ����� � �������������� ���� ��������� �� ������� ������ � ����� ����������� ������. �� �� ���������� � ��������� ��� ������� �������, ������, �������, ���-�������, �������, ����� � ����� ��������� ���� ���������� ��������� � ��������� (DFS) � ��������� � ������ (BFS). �� �� ������� �� �������� �� ���� � ������ ��������� ����������, �� � �� �������������� ��������� ���������. �� ������� ��� �� ����������� ���� ��� ��������� ����� �� �������� ���� ������ �� ���������� �� ����������� �� ����� ��������.",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Html + Css",
                        Description = "����� �� ����� \"Web Fundamentals - HTML5\" � �� ������ ������� ������ �� ��� ���������� � ��-��������� ����������� � HTML5 � CSS3. ���������� �� ������� ������ � ��� ������������, ��� ��������, ����������� �� HTML/CSS/DOM ���������� � �� �������� ����������� ������ �� ���������� �� ����� �� �������� �� ��� ���������� HTML � ����� �� ����������� �� ��� ���������� CSS. �������� �� CSS frameworks ���� Bootstrap.",
                        IsOpen = false
                    },
                      new Course()
                    {
                        Name = "C# OOP",
                        Description = "������ \"Object-Oriented Programming\" �� �� ����� �� ���������� �� �������-������������� ������������ (���), ��� �� �������� � ������� � ������, ��� �� �������� �������-����������� ���������� � �� ���������� �������� �� �������. �� �� �������� ��������� �������� �� ��� ���� ���������� (����������, ���������� �������), ������������, ����������� � ������������. �� ������� �������� �� ��������� ���� event-driven ������������, ������������ ������������ (������ �������, closures � LINQ), ��������� �� ����������.",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Linear Algebra",
                        Description = "����� � �����.",
                        IsOpen = false
                    },
                });


        }
    }
}
