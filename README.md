# TOTO_SOGETI

![](https://github.com/HandyS11/ToDo_Sogeti/actions/workflows/dotnet.yml/badge.svg)

## 📝 Purpose

Create a **TODO** application to showcase developpement skills with [.NET](https://learn.microsoft.com/en-us/dotnet/)

You can find the context [here](./CONTEXT.md)

## 📊 Features

**Done:**
-  Setup the repository & CI
- Create the Model
- Create the VM

**Not Done yet:**

- Create the MAUI sample
- Create the EF Model &/or local Databse
- Create the MAUI front
- Link everything together

## 🛠 Languages & tools

![skills](https://skillicons.dev/icons?i=cs,dotnet,visualstudio)

## 🖊️ Versions 

- [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)
- [Android API](https://developer.android.com/reference) 33

## 📍 Visuals

<details><summary> Pages </summary>

| Sketchs | App |
| --- | --- |
| <img src="./Documentation/sketchs/HomePage.png" height="750"/> | <img src="./Documentation/screens/" height="750"/> |
| <img src="./Documentation/sketchs/ToDosPage.png" height="750"/> | <img src="./Documentation/screens/" height="750"/> | 
| <img src="./Documentation/sketchs/ToDoPage.png" height="750"/> | <img src="./Documentation/screens/" height="750"/> | 
| <img src="./Documentation/sketchs/NewToDoPage.png" height="750"/> | <img src="./Documentation/screens/" height="750"/> | 
| <img src="./Documentation/sketchs/EditToDoPage.png" height="750"/> | <img src="./Documentation/screens/" height="750"/> | 
</details>

## ⚙️ Architecture

> Theses diagrams are not fully accurate and only gave the global idea of the conception.

<details><summary> Models </summary>

```mermaid
classDiagram

class ToDo {
    +-/Id
    +/Title
    +/IsDone
    +/Description
    +-/CreationDate
    ToDo(string title)
    ToDo(string title, string description)
}
```
</details>

---

<details><summary> ViewModels </summary>

```mermaid
classDiagram

class AppVM {
    +-/NavigateBackCommand : ICommand
    ..
}
AppVM --> "1" ToDoManagerVM : ToDoManagerVM

class ToDoManagerVM {
    +-/Datamanager : IDataManager
    - LoadToDos() Task
    + AddToDo(ToDoVM vm) Task
    + EditToDo(ToDoVM vm) Task
    + DeleteToDo(ToDoVM vm) Task
}
ToDoManagerVM --> "1" ToDoVM : SelectedTodo
ToDoManagerVM --> "*" ToDoVM : Todos

class ToDoVM {
    +/Model
    +-/Id
    +/Title
    +/IsDone
    +/Description
    +-/CreationDate
    ToDoVM(ToDo model)
}
```
</details>

## ✍️ Credits 

* Author: [**Valetin Clergue**](https://github.com/HandyS11)