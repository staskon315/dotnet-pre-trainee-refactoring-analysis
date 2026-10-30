# Refactoring Analysis: User Registration System

This project is a refactored version of  console application. The goal of the refactoring was to apply **SOLID**, **DRY**, **KISS**, and **YAGNI** principles to make the code easier to read, maintain, and extend.

---


##  Identified Problems & Refactoring Analysis

### Problem 1: The "God Object" (Violation of SRP)
**What was wrong:** The original `UserService` did everything: validated inputs, created the user object, saved data, sent notifications, and logged actions. 
**Principle Violated:** Single Responsibility Principle (SRP) and Separation of Concerns.
**Design Change:** The class was split into several smaller components:
*   `UserValidation` handles validation.
*   `UserRepository` handles storage.
*   `INotification` implementations handle message sending.
*   `UserService` now only coordinates the workflow.

### Problem 2: Duplicate Email Validation (Violation of DRY)
**What was wrong:** The logic to check if an email was empty and contained an `@` symbol was copy-pasted in both the `RegisterUser` and `UpdateEmail` methods.
**Principle Violated:** Don't Repeat Yourself (DRY).
**Design Change:** The email validation was extracted into a reusable static class `UserValidation`. If the email rules change in the future, we only need to update it in one place.

### Problem 3: Hardcoded Notification Logic (Violation of OCP)
**What was wrong:** The `UserService` contained an `if-else` chain checking `notificationType` (email, sms, push). Adding a new notification method  required modifying the `UserService` class.
**Principle Violated:** Open/Closed Principle (OCP).
**Design Change:** Introduced the `INotification` . The `UserService` now depends on the interface, not concrete implementations. Adding a new notification type only requires creating a new class that implements `INotification`.

### Problem 4: Tight Coupling / Hardcoded Dependencies (Violation of DIP)
**What was wrong:** The original service instantiated its own data list (`new List<User>()`) and was tightly coupled to the console infrastructure (`Console.WriteLine`).
**Principle Violated:** Dependency Inversion Principle (DIP).
**Design Change:** Introduced `IUserRepository`. The `UserService` now receives dependencies via its constructor (Constructor Injection). It depends on abstractions (`IUserRepository`), not concrete implementations. 

### Problem 5: Unused Method (Violation of YAGNI)
**What was wrong:** The method `GenerateAdvancedAnalyticsReport()` was present in the class but not used anywhere. 
**Principle Violated:** You Aren't Gonna Need It (YAGNI).
**Design Change:** The method was commented out. 

### Problem 6: Violation of Encapsulation (LSP & ISP related)
**What was wrong:** The original list of users was accessible and could be modified or cleared from anywhere.
**Principle Violated:** Encapsulation.
**Design Change:** `UserRepository` hides the `List<User>` behind a `private` modifier. The `GetAll()` method returns an `IEnumerable<User>`, which allows iterating over the users  but prevents external code from adding or removing elements accidentally.
