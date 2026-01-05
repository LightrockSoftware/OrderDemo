OrderDemo — Lambda Expressions & EF Core Deep Dive

This repository contains a real-world demo application used throughout a deep-dive blog series on lambda expressions in C#, EF Core query translation, and performance trade-offs in modern .NET applications.

Rather than relying on toy examples, this project demonstrates how lambdas behave in real execution contexts: in-memory, translated to SQL, composed dynamically, and benchmarked under load.

If you’ve ever hit:

“The LINQ expression could not be translated…”

unexpected client-side evaluation

performance issues caused by innocent-looking lambdas

…this repository is for you.

Why This Repository Exists

Most lambda expression examples never fail.

In production systems, lambdas:

cross architectural layers

are reused in different execution contexts

are consumed by LINQ providers like EF Core

directly affect correctness, scalability, and performance

This repository exists to make those behaviors visible, testable, and measurable.

Architecture Overview

The solution follows Clean Architecture principles and is orchestrated locally using .NET Aspire.

Blazor UI
   ↓
ASP.NET Core Web API
   ↓
Application Layer (use cases + query logic)
   ↓
Domain Layer (entities + invariants)

Infrastructure (EF Core + PostgreSQL) executes and translates queries

Key characteristics

Blazor for UI (no business logic, no query composition)

ASP.NET Core Web API for orchestration

Application layer for reusable expressions and specifications

EF Core + PostgreSQL for real SQL translation behavior

.NET Aspire for local orchestration (API + DB + UI)

Benchmarks to compare execution strategies

Domain Model

The demo application models a simplified but realistic ordering system:

Tenants (multi-tenant boundary)

Customers

Orders

Order items

Order lifecycle states

This domain creates natural pressure for:

reusable predicates

expression composition

translation boundaries

server-side vs client-side execution

What This Repo Demonstrates

Delegates vs expression trees

How EF Core consumes expression trees

Why some lambdas cannot be translated to SQL

Specification pattern using expressions

Predicate composition (AND / OR)

Performance implications of execution context

EF Core compiled queries for hot paths

Testing expression-based queries

Benchmarking real EF Core behavior

Technology Stack

.NET 9 / .NET 10

C#

ASP.NET Core

Blazor

Entity Framework Core

PostgreSQL

.NET Aspire

BenchmarkDotNet

xUnit

Running the Demo Locally
Prerequisites

Visual Studio 2026

Docker Desktop (required for Aspire + PostgreSQL)

.NET Aspire workload installed

Run

Open the solution in Visual Studio

Set Ordering.AppHost as the startup project

Press F5

Aspire will:

start PostgreSQL in a container

start the Web API

start the Blazor app

open the Aspire dashboard

New posts extend this repository incrementally — earlier examples remain valid.

Repository Evolution

This repository is intentionally iterative.

As the series progresses:

new query scenarios are added

benchmarks evolve

architectural trade-offs are explored

code is refined based on real behavior

Think of this as a living reference project, not a static tutorial.

Discoverability Notes

If you found this repo via:

EF Core performance issues

lambda expression translation errors

Clean Architecture examples

.NET Aspire demos

real-world Blazor + Web API systems

You’re in the right place.

This project is designed to be searched, cloned, and explored.

Contact

If you’d like to discuss:

EF Core internals

lambda expression behavior

architecture decisions

performance tuning in .NET

You can reach me via https://dotnetconsult.tech

License

MIT License — use freely, learn from it, and adapt it for your own projects.
