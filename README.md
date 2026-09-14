# CyberTrace - Secure Version

CyberTrace is a web security educational project that demonstrates common web application vulnerabilities and their corresponding security protections.

This repository contains the secure version of the application, where defensive controls have been implemented to reduce or prevent the vulnerabilities demonstrated in the vulnerable version.

## Project Overview

The Secure version provides protected implementations for common web security issues.

It is designed to demonstrate how secure coding practices and server-side validation can improve web application security.

## Security Cases

The project includes secure implementations for the following 15 security cases:

1. SQL Injection
2. Reflected XSS
3. Stored XSS
4. DOM XSS
5. Cross-Site Request Forgery (CSRF)
6. Authentication Bypass
7. Brute Force
8. Command Injection
9. Server-Side Request Forgery (SSRF)
10. Information Disclosure
11. HTTP Security Misconfiguration
12. Dictionary Attack
13. Fuzzing / Improper Input Validation
14. Insecure Direct Object Reference (IDOR)
15. Broken Admin Access Control

## Security Measures

The secure version demonstrates several defensive techniques, including:

- Parameterized database queries and Entity Framework queries
- Output encoding to prevent XSS
- Safe DOM manipulation using `textContent`
- Anti-forgery tokens for CSRF protection
- Server-side authentication and authorization
- Login attempt limiting
- Temporary blocking after repeated failed attempts
- Command allowlisting
- SSRF URL and private-address validation
- Limiting sensitive information exposure
- Security HTTP response headers
- Input length and content validation
- Object-level authorization checks
- Role-based access control for administrative pages

## Technologies Used

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- HTML
- CSS
- JavaScript

## Project Structure

The project follows a standard ASP.NET Core MVC structure:

- `Controllers/` - Application controllers
- `Models/` - Data models
- `Data/` - Database context and data configuration
- `Views/` - MVC views
- `wwwroot/` - Static files
- `Properties/` - Project configuration
- `Program.cs` - Application entry point
- `appsettings.json` - Application configuration

## Purpose

The project is intended for educational purposes to demonstrate the difference between vulnerable and secure web application implementations.

The Secure version can be compared with the Vulnerable version to understand how security controls protect against common web application attacks.

## Disclaimer

This project is created for educational and authorized security testing purposes only.

Do not use the demonstrated techniques against systems or applications without proper authorization.
