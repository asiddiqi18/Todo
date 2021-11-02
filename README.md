# Todo
A console-based app for a Todo List, written in C#

Usage:
```
❯ todo
Command    Syntax                              Description
---------- ----------------------------------- -----------------------------------
add        todo add <todo message>             Adds an item to your todo list
show       todo show                           Shows all of your tasks
remove     todo remove <id>                    Removes a selected task by its ID
purge      tasks purge                         Removes all tasks
search     todo search <query>                 Search for a task
edit       todo edit <id> <new message>        Edits a task given its ID
help       todo help                           Lists all implemented comments
```

Add a task to the list:
```
❯ todo add "take out the trash"
Successfully created a new task -- (take out the trash)
```

Show all tasks:
```
❯ todo show
1 -- read emails
2 -- take a shower
3 -- read textbook
4 -- take a nap
5 -- read bedtime story
6 -- take out the trash
```

Remove a task:
```
❯ todo remove 2
Successfully deleted task #2 (take a shower)
```

Edit a task:
```
❯ todo edit 3 "take a very short nap"
Successfully edited task 3
```

Search for a task with keywords:
```
❯ todo search "read"
Found 3 matches
1 -- read emails
2 -- read textbook
4 -- read bedtime story
```

Remove all tasks with a keyword:
```
❯ todo remove "read"
Successfully deleted task #1 (read emails)
Successfully deleted task #2 (read textbook)
Successfully deleted task #4 (read bedtime story)
```

Remove all tasks:
```
❯ todo purge
You have successfully purged all tasks (removed 6).
```
