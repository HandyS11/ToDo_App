# TOTO_SOGETI

![](https://github.com/HandyS11/ToDo_Sogeti/actions/workflows/dotnet.yml/badge.svg)

## 📝 Purpose

Create a **TODO** application to showcase developpement skills with [.NET](https://learn.microsoft.com/en-us/dotnet/)

You can find the context [here](./CONTEXT.md)

## 📊 Features

**Done:**
- Setup the repository & CI
- Create the Model
- Create the VM
- Create the MAUI front

**Not Done yet:**

- Create the EF Model &/or local Databse
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

<details><summary> Model </summary>

```mermaid
classDiagram

class ToDo {
    +-/Id : Guid
    +/Title : string
    +/IsDone : bool
    +/Description : string
    +-/CreationDate : DateTime
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
    +/NavigateBackCommand : ICommand
    +/GoToToDoDetail(ToDoVM vm)
    +/GoToAddTodo()
    +/GoToEditTodo(ToDoVM vm)
    +/AddToDo()
    +/EditToDo()
    +/DeleteToDo()
}
AppVM --> "1" ToDoManagerVM : ToDoManagerVM

class ToDoManagerVM {
    +-/Datamanager : IDataManager
    +/SelectedTodo ToDoVM
    - LoadToDos() Task
    + AddToDo(ToDoVM vm) Task
    + EditToDo(ToDoVM vm) Task
    + DeleteToDo(ToDoVM vm) Task
}
ToDoManagerVM --> "1" ToDoVM : SelectedTodo
ToDoManagerVM --> "*" ToDoVM : ToDosNotDone
ToDoManagerVM --> "*" ToDoVM : ToDosDone

class ToDoVM {
    +/Model : ToDo
    +-/Id : Guid
    +/Title : string
    +/IsDone : bool
    +/Description : string
    +-/CreationDate : DateTime
    ToDoVM(ToDo model)
}

class AddOrEditToDoVM {
    +/IsNewToDo : bool
    +/EditTitle : string
    +/EditDescription : string
    Clone(ToDoVM vm)
}
AddOrEditToDoVM ..|> ToDoVM
```
</details>

## ✍️ Credits 

* Author: [**Valetin Clergue**](https://github.com/HandyS11)